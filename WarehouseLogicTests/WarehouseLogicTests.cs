using NUnit.Framework;

[TestFixture]
public class WarehouseLogicTests
{
    private WarehouseData warehouse;
    private WarehouseLogic logic;

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
