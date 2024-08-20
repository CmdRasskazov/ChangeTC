using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public class MyCash2 : IChangeCalculator
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
            if (amount < 0)
            { // negative value is unacceptable
                return (false, new List<int>());
            }
            if (amount == 0)
            {
                return (false, new List<int>());
            }

            var changeCoins = new List<int>();

            // Add coins to the change list and subtract their value from the amount
            foreach (int coin in coinDenominations)
            {
                // We calculate the maximum number of coins of the current denomination that can be used
                int maxCoins = Math.Min(availableCoins[coin], amount / coin);

                // Add coins to the change list and subtract their value from the amount
                for (int i = 1; i <= maxCoins; i++)
                {
                    changeCoins.Add(coin);
                    amount -= coin;
                }

                // If the amount is 0, we have successfully calculated the change.
                if (amount == 0)
                {
                    return (true, changeCoins);
                }
            }
            return (false, new List<int>());
        }
    }
}
