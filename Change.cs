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
        private readonly List<int> coinDenominations;

        public MyCash(Dictionary<int, int> _availableCoins)
        {
            coinDenominations = _availableCoins.Keys.ToList();
            coinDenominations.Sort();

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

            if (amount <= 0)
                // negative value is unacceptable
                return (false, new Dictionary<int, int>());

            // check if amount is overFlow
            if (availableCoins.Sum(x => x.Key * x.Value) < amount)
                return (false, new Dictionary<int, int>());

            bool[] myBoolTable = new bool[amount + 1];
            myBoolTable[0] = true; // cause 0 is always availavle

            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coinDenominations)
                {
                    if (i >= coin && availableCoins[coin] > 0 && myBoolTable[i - coin])
                    {
                        myBoolTable[i] = true;
                        break; // if find case we need move to the next sum
                    }
                }
            }

            if (!myBoolTable[amount])
                return (false, new Dictionary<int, int>()); // sorry, change is not availible

            // itterations to compare coins
            var change = new Dictionary<int, int>();
            int currentAmount = amount;
            for (int i = coinDenominations.Count - 1; i >= 0; i--)
            {
                int coin = coinDenominations[i];
                while (currentAmount >= coin && availableCoins[coin] > 0 && myBoolTable[currentAmount - coin])
                {
                    availableCoins[coin]--; // i spent here 2 hours to find a mistake
                    if (change.ContainsKey(coin))
                        change[coin]++;
                    else
                        change.Add(coin, 1);

                    currentAmount -= coin;

                    if (currentAmount < 0)
                    {
                        if (change.ContainsKey(coin))
                            change[coin]--;
                        else
                            change.Add(coin, -1);

                        currentAmount += coin;
                        break;
                    }
                }
            }
            return (true, change);
        }
    }
}
