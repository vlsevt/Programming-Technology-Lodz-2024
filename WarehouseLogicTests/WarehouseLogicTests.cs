using NUnit.Framework;
using TestWarehouseDataLayer;
using WarehouseLogicLayer;

namespace WarehouseLogicLayer.Tests
{
    [TestFixture]
    public class WarehouseLogicTests
    {
        private IWarehouseData warehouse;
        private WarehouseLogicAPI logic;

        [SetUp]
        public void Initialize()
        {
            warehouse = new WarehouseDataFake(); 
            logic = new WarehouseLogic(warehouse);
        }

        [Test]
        public void TestRestockProduct()
        {
            warehouse.AddProduct("Product A", 0);

            logic.RestockProduct(1, "Product A", 50);

            Assert.AreEqual(50, warehouse.Inventory[1]);
        }

        [Test]
        public void TestFulfillOrder_Successful()
        {
            warehouse.AddProduct("Product A", 100);

            bool result = logic.FulfillOrder(1, 50);

            Assert.IsTrue(result);
            Assert.AreEqual(50, warehouse.Inventory[1]);
        }

        [Test]
        public void TestFulfillOrder_InsufficientStock()
        {
            warehouse.AddProduct("Product A", 100);

            bool result = logic.FulfillOrder(1, 150);

            Assert.IsFalse(result);
            Assert.AreEqual(100, warehouse.Inventory[1]);
        }
    }
}
