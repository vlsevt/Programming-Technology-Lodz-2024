using NUnit.Framework;

[TestFixture]
public class WarehouseDataTests
{
    [Test]
    public void TestAddProduct()
    {

        WarehouseData warehouse = new WarehouseData();


        warehouse.AddProduct(1, "Product A", 100);


        Assert.IsTrue(warehouse.ProductCatalog.ContainsKey(1));
        Assert.AreEqual("Product A", warehouse.ProductCatalog[1]);
        Assert.IsTrue(warehouse.Inventory.ContainsKey(1));
        Assert.AreEqual(100, warehouse.Inventory[1]);
    }

    [Test]
    public void TestRecordIncomingShipment()
    {

        WarehouseData warehouse = new WarehouseData();
        warehouse.AddProduct(1, "Product A", 100);


        warehouse.RecordIncomingShipment(1, 50);


        Assert.AreEqual(150, warehouse.Inventory[1]);
    }

    [Test]
    public void TestRecordOutgoingShipment_Successful()
    {

        WarehouseData warehouse = new WarehouseData();
        warehouse.AddProduct(1, "Product A", 100);


        bool result = warehouse.RecordOutgoingShipment(1, 50);


        Assert.IsTrue(result);
        Assert.AreEqual(50, warehouse.Inventory[1]);
    }

    [Test]
    public void TestRecordOutgoingShipment_InsufficientStock()
    {

        WarehouseData warehouse = new WarehouseData();
        warehouse.AddProduct(1, "Product A", 100);


        bool result = warehouse.RecordOutgoingShipment(1, 150);


        Assert.IsFalse(result);
        Assert.AreEqual(100, warehouse.Inventory[1]);
    }
}
