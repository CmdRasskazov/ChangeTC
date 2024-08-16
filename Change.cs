using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public class MyCash
    {
        private Dictionary<int, int> availableCoins;
        private Dictionary<int, int> change;
        private List<int> coinDenominations;
        int lastAmount;

        public MyCash(Dictionary<int, int> _availableCoins)
        {
            coinDenominations = _availableCoins.Keys.ToList();
            
            // check if value of coin is lower than 0
            foreach (int coin in coinDenominations)
            {
                int currentValueOfCoin = _availableCoins[coin];
                if (currentValueOfCoin < 0) throw new ArgumentException("Value of coins can not be <0", nameof(currentValueOfCoin));
            }
            coinDenominations.Sort((a, b) => b - a);
          
            change = new Dictionary<int, int>();
            availableCoins = _availableCoins;
            lastAmount = 0;
        }

        public (bool isAvailable, Dictionary<int, int> coins) CalculateChange(int amount)
        {
            if (amount <= 0)
                // negative value is unacceptable
                return (false, new Dictionary<int, int>());

            // check if amount is overFlow
            if (availableCoins.Sum(x => x.Key * x.Value) < amount)
                return (false, new Dictionary<int, int>());

            change.Clear();
            return HelpFunc(amount, 0);
        }

        private (bool isAvailable, Dictionary<int, int> coins) HelpFunc(int amount, int index)
        {
            if (amount < 0)
                return (false, new Dictionary<int, int>());

            if (amount == 0)
                return (true, change);

            if (index > coinDenominations.Count - 1)
                return (false, new Dictionary<int, int>());

            int currentAmount = amount;
            int currentCoin = coinDenominations[index];

            if (currentAmount >= currentCoin && availableCoins[currentCoin] > 0)
            {
                int maxCoins = Math.Min(currentAmount / currentCoin, availableCoins[currentCoin]);

                change.Add(currentCoin, maxCoins);
                lastAmount = currentAmount;

                currentAmount -= maxCoins * currentCoin;
                availableCoins[currentCoin] -= maxCoins;

                return HelpFunc(currentAmount, ++index);
            }

            else
            {
                if (change.Count != 0)
                {
                    int lastKey = change.Keys.Last();
                    change.Remove(lastKey);
                }

                if (lastAmount == 0)
                    return HelpFunc(amount, ++index);
                else
                    return HelpFunc(lastAmount, index);
            }
        }
    }
}
