using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public class MyCash
    {
        private readonly Dictionary<int, int> availableCoins;
        private List<int> coinDenominations;
        Dictionary<int, int> res;

        public MyCash(Dictionary<int, int> _availableCoins)
        {
            coinDenominations = _availableCoins.Keys.ToList();
            coinDenominations.Sort((a, b) => b - a);
            res = new Dictionary<int, int>();

            // check if value of coin is lower than 0
            foreach (int coin in coinDenominations)
            {
                int currentValueOfCoin = _availableCoins[coin];
                if (currentValueOfCoin < 0) throw new ArgumentException("Value of coins can not be <0", nameof(currentValueOfCoin));
            }

            availableCoins = _availableCoins;
        }

        public (bool isAvailable, Dictionary<int, int> coins) CalculateChange(int amount)
        {

            if (amount < 0)
            { // negative value is unacceptable
                throw new ArgumentException("Negative value");
            }

            if ( amount == 0)
            {
                throw new ArgumentException("Change is not needed");
            }

            // Add coins to the change list and subtract their value from the amount
            foreach (int coin in coinDenominations)
            {
                // calculate the maximum number of coins of the current denomination that can be used
                int maxCoins = Math.Min(availableCoins[coin], amount / coin);

                // add coins to the change list and subtract their value from the amount
                for (int i = 0; i < maxCoins; i++)
                {
                    if (res.ContainsKey(coin))
                    {
                        res[coin]++;
                    }
                    else
                    {
                        res.Add(coin, 1);
                    }

                    amount -= coin;
                }

                // If the amount is 0, we have successfully calculated the change.
                if (amount == 0)
                {
                    return (true, res);
                }
            }
            // If the amount is not 0, cannot give change.
            throw new ArgumentException("Change is impossible");
        }
    }
}
