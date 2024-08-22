using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    interface IChangeCalculator
    {
        void Init(Dictionary<int, int> _availableCoins);
        (bool isAvailable, List<int> coins) CalculateChange(int amount);
    }
}
