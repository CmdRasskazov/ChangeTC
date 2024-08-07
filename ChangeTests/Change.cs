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
            return (false, availableCoins);

        }


    }
}
