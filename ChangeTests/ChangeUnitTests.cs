namespace ChangeTests
{
    [TestClass]
    public class ChangeUnitTests
    {
        private Dictionary<int, int> availableCoins;
        MyCash myCash;


        [TestInitialize]
        public void Initialize()
        {
            availableCoins = new Dictionary<int, int> {
            { 100, 10 },
            { 50, 20 },
            { 10, 50 },
            { 5, 100 },
            { 2, 100 },
            { 1, 100 }
            };

            myCash = new MyCash(availableCoins);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_Negative_value()
        {

            // Act
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(-10);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_zero_value() {
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(0);
        }

        [TestMethod]
        public void Calculate_Positive_Value()
        {

            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(123);

            // Assert
            Assert.IsTrue(isAvailable);
            
        }

        [TestMethod]
        public void Calculate_From_Possitive_Value_Query() {
            Dictionary<int, int> expected_change = new Dictionary<int, int> {
                {100, 1},
                {10, 2},
                {2, 2}
            };

            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(124);
            Assert.AreEqual(expected_change[100], coins[100]);
            Assert.AreEqual(expected_change[10], coins[10]);
            Assert.AreEqual(expected_change[2], coins[2]);
        }


        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void Calculate_OverFLow_Value()
        {
            (bool isAvailable, Dictionary<int, int> coins) = myCash.CalculateChange(124);
            
        }
    }
}