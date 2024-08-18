using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public class MyCash
    {
        private Dictionary<int, int> availableCoins;
        private Dictionary<int, int> changeDictionary;
        private List<int> coinDenominations;
        

        public MyCash(Dictionary<int, int> _availableCoins)
        {
            coinDenominations = _availableCoins.Keys.ToList();
            
            // check if value of coin is lower than 0
            foreach (int coin in coinDenominations)
            {
                int currentValueOfCoin = _availableCoins[coin];
                if (currentValueOfCoin < 0) throw new ArgumentException("Value of coins can not be <0", nameof(currentValueOfCoin));
            }
            coinDenominations.Sort();
          
            changeDictionary = new Dictionary<int, int>();
            availableCoins = _availableCoins;
            
        }

        public (bool isAvailable, Dictionary<int, int> coins) CalculateChange(int amount)
        {
            if (amount <= 0)
                // negative value is unacceptable
                return (false, new Dictionary<int, int>());

            // check if amount is overFlow
            if (availableCoins.Sum(x => x.Key * x.Value) < amount)
                return (false, new Dictionary<int, int>());

            changeDictionary.Clear();

            (bool isAvailable, Dictionary<int, int>) GetChangeCombination(int remainingAmount, List<int> currentCombination)
            {
                if (remainingAmount == 0)
                { // we found combitation
                    return (true, changeDictionary);
                }

                // try to check all combinations
                foreach (int coin in coinDenominations)
                {
                    if (coin <= remainingAmount && availableCoins[coin] > 0)
                    {
                        availableCoins[coin]--;
                        currentCombination.Add(coin);

                        GetChangeCombination(remainingAmount - coin, currentCombination);
                        if (changeDictionary.Count != 0) return (true, changeDictionary); // if 1 combination is availible, return it

                        if (currentCombination.Sum() == amount)
                        {
                            foreach (int changeCoin in currentCombination)
                            {
                                if (changeDictionary.ContainsKey(changeCoin))
                                {
                                    changeDictionary[changeCoin]++;
                                }

                                else
                                {
                                    changeDictionary.Add(changeCoin, 1);
                                }
                            }
                            return (true, changeDictionary);
                        }

                        // if last denomination doesn`t allow to contine, then delite it, this combination is bad
                        int index = currentCombination.Count - 1;

                        availableCoins[currentCombination[index]]++;
                        currentCombination.RemoveAt(index);
                    }
                }
                return (false, changeDictionary);
            }
            return GetChangeCombination(amount, new List<int>());
        } 
    }
}
