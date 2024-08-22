using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public class MyCash1 : ChangeCalculatorBase
    {
        public override (bool isAvailable, List<int> coins) CalculateChange(int amount)
        {
            var change = new List<int>();

            if (amount <= 0)
                // negative value is unacceptable
                return (false, change);

            // check if amount is overFlow
            if (availableCoins.Sum(x => x.Key * x.Value) < amount)
                return (false, change);

            return GetChangeCombination(amount, change, amount);
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
