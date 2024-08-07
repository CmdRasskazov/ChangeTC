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
    }
}