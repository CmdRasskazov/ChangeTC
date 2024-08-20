using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public class MyCash1 : IChangeCalculator
    {
        public Dictionary<int, int> availableCoins { get; set; } = [];
        public List<int> coinDenominations { get; set; } = [];

        public void Init(Dictionary<int, int> _availableCoins)
        {
            coinDenominations = _availableCoins.Keys.ToList();

            // check if value of coin is lower than 0
            foreach (int coin in coinDenominations)
            {
                int currentValueOfCoin = _availableCoins[coin];
                if (currentValueOfCoin < 0) throw new ArgumentException("Value of coins can not be <0", nameof(currentValueOfCoin));
            }

            coinDenominations.Sort((a, b) => b - a);
            availableCoins = _availableCoins;
        }


        public (bool isAvailable, List<int> coins) CalculateChange(int amount)
        {
            var changeDictionary = new List<int>();

            if (amount <= 0)
                // negative value is unacceptable
                return (false, changeDictionary);

            // check if amount is overFlow
            if (availableCoins.Sum(x => x.Key * x.Value) < amount)
                return (false, changeDictionary);


            return GetChangeCombination(amount, changeDictionary, amount);
        }


        private (bool isAvailable, List<int>) GetChangeCombination(int remainingAmount, List<int> currentCombination, int amount)
        {
            if (remainingAmount == 0)
            { // we found combitation
                return (true, currentCombination);
            }

            // try to check all combinations
            foreach (int coin in coinDenominations)
            {
                if (coin <= remainingAmount && availableCoins[coin] > 0)
                {
                    availableCoins[coin]--;
                    currentCombination.Add(coin);

                    GetChangeCombination(remainingAmount - coin, currentCombination, amount);
                    /*if (currentCombination.Count != 0) return (true, currentCombination);*/ // if 1 combination is availible, return it

                    if (currentCombination.Sum() == amount)
                        return (true, currentCombination);

                    // if last denomination doesn`t allow to contine, then delite it, this combination is bad
                    int index = currentCombination.Count - 1;

                    availableCoins[currentCombination[index]]++;
                    currentCombination.RemoveAt(index);
                }
            }
            return (false, currentCombination);
        }
    }
}
