namespace ChangeTests
{
    [TestClass]
    public class ChangeUnitTests
    {
        [TestMethod]
        public void Calculate_Negative_value()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(-10);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void Calculate_zero_value() {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(0);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void Calculate_Positive_Value()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(123);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void Calculate_From_Possitive_Value_Query() {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);

            (bool isAvailable, var coins) = myCash.CalculateChange(124);
            Assert.IsTrue(isAvailable);
        }


        [TestMethod]
        public void Calculate_OverFLow_Value()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(3301);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_Impossible_Value()
        {
            var invalidCoins = new Dictionary<int, int>
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

        [TestMethod]
        public void Yoy()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 5, 1 },
            { 4, 1 },
            { 3, 2 },
            { 2, 1 },
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(10);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void CalculateNotStandardRunFunc()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 5, 3 },
            { 2, 8 },
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(116);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void CalculateWithoutNeededCoins()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 0 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(151);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void CalculateWithNoNeededCoins()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 5, 3 },
            { 2, 8 },
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(101);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void CalculateRightChangeSum()
        {
            MyCash myCash;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 5, 3 },
            { 2, 8 },
            };

            myCash = new MyCash(availableCoins);
            (bool isAvailable, var coins) = myCash.CalculateChange(102);

            int sum = coins.Sum();
            Assert.IsTrue(isAvailable);
            Assert.AreEqual(102, sum);
        }

        [TestMethod]
        public void CalculateRandomCash()
        {
            Random random = new();

            int cashCircle = 10;
            int changeCircle = 5;

            var cashCoins = new Dictionary<int, int>();
            List<int> changes = new List<int>();

            for (int i = 1; i <= cashCircle; i++)
            {
                int coin = random.Next(1, 50);
                int coinValue = random.Next(0, 20);

                cashCoins.TryAdd(coin, coinValue);
            }

            for (int i = 1; i <= changeCircle; i++)
            {
                int currentChange = random.Next(10, 100);

                changes.Add(currentChange);
            }

            
            for (int i = 0; i < changes.Count; i++)
            {
                MyCash myCash = new MyCash(cashCoins);

                int sum = changes[i];
                (bool flag, var change) = myCash.CalculateChange(changes[i]);
            }
        }
    }
}