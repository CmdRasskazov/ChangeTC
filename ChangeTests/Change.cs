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


        public MyCash(Dictionary<int, int> availableCoins)
        {
            this.availableCoins = availableCoins;
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

            // create a list of available coin denominations.
            var coinDenominations = availableCoins.Keys.ToList();

            // sort the coin denominations in descending order.
            coinDenominations.Sort((a, b) => b - a);

            // initialize the list to store the coins used for change.
            List<int> changeCoins = new List<int>();
            Dictionary<int, int> res = new Dictionary<int, int>();

            



            return (false, availableCoins);

        }


    }
}
