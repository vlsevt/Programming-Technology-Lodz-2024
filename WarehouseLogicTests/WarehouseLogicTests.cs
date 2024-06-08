using NUnit.Framework;
using WarehouseLogicLayer;
using WarehouseLogicLayer.Fakes;

namespace WarehouseLogicTests
{

    [TestFixture]
    public class LogicTests
    {
        private WarehouseDataMock warehouse;
        private WarehouseLogicAPI logic;

        [SetUp]
        public void Initialize()
        {
            warehouse = new WarehouseDataMock();
            logic = new WarehouseLogic(warehouse);
        }

        [Test]
        public void TestRestockProduct()
        {
            Assert.IsTrue(logic.RestockProduct(1, "Product A", 50));
        }


        [Test]
        public void TestFulfillOrder_Successful()
        {
            Assert.True(logic.FulfillOrder(1, 50));
        }
    }
}
