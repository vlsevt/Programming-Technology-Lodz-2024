using NUnit.Framework;

[TestFixture]
public class WarehouseDataTests
{
    private WarehouseData warehouse;

    [SetUp]
    public void Initialize()
    {
        warehouse = new WarehouseData();
        var idOfProductA = warehouse.AddProduct("Product A", 100);
        var idOfProductB = warehouse.AddProduct("Product B", 50);

    }
    [Test]
    public void TestAddProduct()
    {
        warehouse.AddProduct("Product C", 200);

        
        Assert.IsTrue(warehouse.ProductCatalog.ContainsKey(3));
        Assert.AreEqual("Product C", warehouse.ProductCatalog[3]);
        Assert.IsTrue(warehouse.Inventory.ContainsKey(3));
        Assert.AreEqual(200, warehouse.Inventory[3]);
    }

    [Test]
    public void TestRecordIncomingShipment()
    {
        warehouse.AddProduct("Product A", 100);

        
        warehouse.RecordIncomingShipment(1, 50);

        
        Assert.AreEqual(150, warehouse.Inventory[1]);
    }

    [Test]
    public void TestRecordOutgoingShipment_Successful()
    {
        warehouse.AddProduct("Product A", 100);

        
        bool result = warehouse.RecordOutgoingShipment(1, 50);

        
        Assert.IsTrue(result);
        Assert.AreEqual(50, warehouse.Inventory[1]);
    }

    [Test]
    public void TestRecordOutgoingShipment_InsufficientStock()
    {
        warehouse.AddProduct("Product A", 100);

        
        bool result = warehouse.RecordOutgoingShipment(1, 150);

        
        Assert.IsFalse(result);
        Assert.AreEqual(100, warehouse.Inventory[1]);
    }

    [Test]
    public void TestAddUser()
    {
        warehouse.Users.Staff.Add("John");
        warehouse.Users.Customers.Add("Alice");
        warehouse.Users.Suppliers.Add("Bob");

        
        CollectionAssert.Contains(warehouse.Users.Staff, "John");
        CollectionAssert.Contains(warehouse.Users.Customers, "Alice");
        CollectionAssert.Contains(warehouse.Users.Suppliers, "Bob");
    }

    [Test]
    public void TestAssignedIdsAreDifferent()
    {
        var idOfProductA = warehouse.AddProduct("Product A", 100);
        var idOfProductB = warehouse.AddProduct("Product B", 50);
        Assert.AreNotEqual(idOfProductA, idOfProductB);
    }
}
