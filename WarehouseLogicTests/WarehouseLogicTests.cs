using NUnit.Framework;
using WarehouseDataLayer;
using WarehouseLogicLayer;


[TestFixture]
public class WarehouseLogicTests
{
    private WarehouseDataAPI warehouse;
    private WarehouseLogicAPI logic;

    [SetUp]
    public void initialize()
    {
        warehouse = new WarehouseData();
        logic = new WarehouseLogic(warehouse);

    }

    [Test]
    public void TestRestockProduct()
    {
        warehouse.AddProduct("Product A", 0);


        logic.RestockProduct(1, "Product A", 50);

        InventoryProduct productA = warehouse.Inventory.FirstOrDefault(p => p.Id == 1);

        Assert.AreEqual(50, productA.Quantity);
    }


    [Test]
    public void TestFulfillOrder_Successful()
    {
        warehouse.AddProduct("Product A", 100);

        bool result = logic.FulfillOrder(1, 50);

        InventoryProduct productA = warehouse.Inventory.FirstOrDefault(p => p.Id == 1);


        Assert.IsTrue(result);
        Assert.AreEqual(50, productA.Quantity);
    }

    [Test]
    public void TestFulfillOrder_InsufficientStock()
    {
        warehouse.AddProduct("Product A", 100);

        bool result = logic.FulfillOrder(1, 150);

        InventoryProduct productA = warehouse.Inventory.FirstOrDefault(p => p.Id == 1);

        Assert.IsFalse(result);
        Assert.AreEqual(100, productA.Quantity);
    }
}
