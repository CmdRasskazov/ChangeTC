namespace ChangeTests
{
    [TestClass]
    public class ChangeUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_Negative_value()
        {
            Dictionary<int, int> availableCoins;
            MyCash myCash;
            availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(-10);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_zero_value() {
            Dictionary<int, int> availableCoins;
            MyCash myCash;

            availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(0);
        }

        [TestMethod]
        public void Calculate_Positive_Value()
        {
            Dictionary<int, int> availableCoins;
            MyCash myCash;

            availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(123);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void Calculate_From_Possitive_Value_Query() {
            Dictionary<int, int> availableCoins;
            MyCash myCash;

            availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            Dictionary<int, int> expected_change = new Dictionary<int, int> {
                {100, 1},
                {10, 2},
                {2, 2}
            };

            myCash = new MyCash(availableCoins);

            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(124);
            Assert.AreEqual(expected_change[100], coins[100]);
            Assert.AreEqual(expected_change[10], coins[10]);
            Assert.AreEqual(expected_change[2], coins[2]);
        }


        [TestMethod]
        public void Calculate_OverFLow_Value()
        {
            Dictionary<int, int> availableCoins;
            MyCash myCash;

            availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(3301);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_Impossible_Value()
        {
            Dictionary<int, int> invalidCoins = new Dictionary<int, int>
            {
            { 100, -12 },
            { 50, -22 },
            { 10, -99 },
            { 5, -99 },
            { 2, -1 },
            { 1, -2 }
            };
            MyCash testInvalidValueCash = new MyCash(invalidCoins);
        }
    }
}