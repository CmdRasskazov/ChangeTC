namespace ChangeTests
{
    [TestClass]
    public class ChangeUnitTests
    {
        //[TestCleanup]
        //public void clean()

        
        [TestMethod]
        public void Calculate_Negative_value()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(-10);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void Calculate_zero_value() {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(0);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void Calculate_Positive_Value()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(123);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void Calculate_From_Possitive_Value_Query() {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(124);
            Assert.IsTrue(isAvailable);
        }


        [TestMethod]
        public void Calculate_OverFLow_Value()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(3301);
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
            MyCash1 testInvalidValueCash = new MyCash1();
            testInvalidValueCash.Init(invalidCoins);
        }

        [TestMethod]
        public void Yoy()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 5, 1 },
            { 4, 1 },
            { 3, 2 },
            { 2, 1 },
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(10);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void CalculateNotStandardRunFunc()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 5, 3 },
            { 2, 8 },
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(116);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void CalculateWithoutNeededCoins()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 0 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(151);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void CalculateWithNoNeededCoins()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 5, 3 },
            { 2, 8 },
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(101);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void CalculateRightChangeSum()
        {
            MyCash1 myCash1;
            var availableCoins = new Dictionary<int, int> {
            { 100, 1 },
            { 5, 3 },
            { 2, 8 },
            };

            myCash1 = new MyCash1();
            myCash1.Init(availableCoins);
            (bool isAvailable, var coins) = myCash1.CalculateChange(102);

            int sum = coins.Sum();
            Assert.IsTrue(isAvailable);
            Assert.AreEqual(102, sum);
        }

        

        
        
    }

    [TestClass]
    public class RandomValues
    {
        // number of test iterations
        private int testCircle = 10;
        //coins amount
        private int cashCircle = 12;
        private int currentChange = 0;
        private bool testFlag;
        private Random random = new();
        private Dictionary<int, int> cashCoins = [];
        

        [TestMethod]
        public void CalculateRandomCash()
        {
            for (int index = 1; index <= testCircle; index++)
            {
                cashCoins.Clear();

                //coins initialization in cashs
                for (int i = 1; i <= cashCircle; i++)
                {
                    int coin = random.Next(1, 30);
                    int coinValue = random.Next(0, 20);

                    cashCoins.TryAdd(coin, coinValue);
                }

                currentChange = random.Next(10, 100);

                var cashes = new List<IChangeCalculator>() { new MyCash1(), new MyCash2() };
                var flags = new List<bool>();
                var changes = new List<List<int>>();

                foreach (var item in cashes)
                {
                    item.Init(cashCoins);
                    (bool flag, var change) = item.CalculateChange(currentChange);
                    flags.Add(flag);
                    changes.Add(change);
                }

                for (int i = 1; i < flags.Count; i++)
                {
                    bool testFlag = flags[i] == flags[i - 1];
                    if (!testFlag)
                    {
                        Console.WriteLine("Cash: ");

                        foreach (var item in cashCoins)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }

                        Console.WriteLine($"Change: {currentChange}");

                        foreach (var list in changes)
                        {
                            Console.WriteLine("Combination: ");
                            foreach (int coin in list)
                            {
                                Console.WriteLine(coin);
                            }
                        }
                    }
                    Assert.IsTrue(testFlag);
                } 
            }
        }

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    if (!testFlag)
        //    {
                

        //    }
        //}
    }
}