using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTests
{
    interface IChangeCalculator
    {
        Dictionary<int, int> availableCoins { get; set; }
        List<int> coinDenominations { get; set; }

        void Init(Dictionary<int, int> _availableCoins);
        (bool isAvailable, List<int> coins) CalculateChange(int amount);
    }
}
