using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    public abstract class ChangeCalculatorBase : IChangeCalculator
    {
        protected Dictionary<int, int> availableCoins;
        protected List<int> coinDenominations;

        public ChangeCalculatorBase()
        {
            availableCoins = new Dictionary<int, int>();
            coinDenominations = new List<int>();
        }

        public virtual void Init(Dictionary<int, int> _availableCoins)
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

        public abstract (bool isAvailable, List<int> coins) CalculateChange(int amount);
    }
}
