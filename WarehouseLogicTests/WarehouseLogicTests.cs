using NUnit.Framework;

[TestFixture]
public class WarehouseLogicTests
{
    [Test]
    public void TestRestockProduct()
    {

        WarehouseData warehouse = new WarehouseData();
        WarehouseLogic logic = new WarehouseLogic(warehouse);


        warehouse.AddProduct(1, "Product A", 0);


        logic.RestockProduct(1, "Product A", 50);


        Assert.AreEqual(50, warehouse.Inventory[1]);
    }


    [Test]
    public void TestFulfillOrder_Successful()
    {

        WarehouseData warehouse = new WarehouseData();
        warehouse.AddProduct(1, "Product A", 100);
        WarehouseLogic logic = new WarehouseLogic(warehouse);


        bool result = logic.FulfillOrder(1, 50);


        Assert.IsTrue(result);
        Assert.AreEqual(50, warehouse.Inventory[1]);
    }

    [Test]
    public void TestFulfillOrder_InsufficientStock()
    {

        WarehouseData warehouse = new WarehouseData();
        warehouse.AddProduct(1, "Product A", 100);
        WarehouseLogic logic = new WarehouseLogic(warehouse);


        bool result = logic.FulfillOrder(1, 150);


        Assert.IsFalse(result);
        Assert.AreEqual(100, warehouse.Inventory[1]);
    }
}
