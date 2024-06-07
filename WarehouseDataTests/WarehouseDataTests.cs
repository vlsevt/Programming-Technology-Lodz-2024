using NUnit.Framework;
using WarehouseDataLayer;
using WarehouseDataLayer.APIs;


[TestFixture]
public class WarehouseDataTests
{
    private IWarehouseDataAPI warehouse;
    private int idOfProductA;
    private int idOfProductB;

    [SetUp]
    public void Initialize()
    {
        warehouse = new WarehouseData();
        idOfProductA = warehouse.AddProduct("Product A", 100);
        idOfProductB = warehouse.AddProduct("Product B", 50);
    }

    [Test]
    public void TestAddProduct()
    {
        string productName = "Product C";
        int productQuantity = 200;
        int expectedProductId = 3;

        warehouse.AddProduct(productName, productQuantity);

        var addedCatalogProduct = warehouse.ProductCatalog.FirstOrDefault(p => p.Id == expectedProductId);
        var addedInventoryProduct = warehouse.Inventory.FirstOrDefault(p => p.Id == expectedProductId);

        // For ProductCatalog
        Assert.IsNotNull(addedCatalogProduct, "Product C should be in the catalog.");
        Assert.AreEqual(expectedProductId, addedCatalogProduct.Id, "Product IDs do not match.");
        Assert.AreEqual(productName, addedCatalogProduct.Name, "Product names do not match.");

        // For Inventory
        Assert.IsNotNull(addedInventoryProduct, "Product C should be in the inventory.");
        Assert.AreEqual(expectedProductId, addedInventoryProduct.Id, "Product IDs do not match.");
        Assert.AreEqual(productQuantity, addedInventoryProduct.Quantity, "Product quantities do not match.");
    }



    [Test]
    public void TestRecordIncomingShipment()
    {
        warehouse.RecordIncomingShipment(1, 50);

        InventoryProduct product = warehouse.Inventory.FirstOrDefault(p => p.Id == 1);

        Assert.AreEqual(150, product.Quantity);
    }

    [Test]
    public void TestRecordOutgoingShipment_Successful()
    {
        bool result = warehouse.RecordOutgoingShipment(1, 50);

        InventoryProduct product = warehouse.Inventory.FirstOrDefault(p => p.Id == 1);

        Assert.IsTrue(result);
        Assert.AreEqual(50, product.Quantity);
    }

    [Test]
    public void TestRecordOutgoingShipment_InsufficientStock()
    {
        bool result = warehouse.RecordOutgoingShipment(1, 150);

        InventoryProduct product = warehouse.Inventory.FirstOrDefault(p => p.Id == 1);

        Assert.IsFalse(result);
        Assert.AreEqual(100, product.Quantity);
    }

    [Test]
    public void TestAddUser()
    {
        Staff staffMember = new Staff("John", "Hendricks", 1);
        Customer customer = new Customer("Alice", "Murphy", 2);
        Supplier supplier = new Supplier("Bob", "Moyer", 3);

        warehouse.Staff.Add(staffMember);
        warehouse.Customers.Add(customer);
        warehouse.Suppliers.Add(supplier);



        CollectionAssert.Contains(warehouse.Staff, staffMember);
        CollectionAssert.Contains(warehouse.Customers, customer);
        CollectionAssert.Contains(warehouse.Suppliers, supplier);
    }

    [Test]
    public void TestAssignedIdsAreDifferent()
    {
        Assert.AreNotEqual(idOfProductA, idOfProductB);
    }
}
