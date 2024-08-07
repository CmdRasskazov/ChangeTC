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
        public void TestMethod1()
        {
        }
    }
}