    using NUnit.Framework;
    using WarehouseDataLayer;


    [TestFixture]
    public class WarehouseDataTests
    {
        private WarehouseDataAPI warehouse;

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
            Person staffMember = new Person { FirstName = "John", LastName = "Hendricks", Id = 1 };
            Person customer = new Person { FirstName = "Alice", LastName = "Murphy", Id = 2 };
            Person supplier = new Person { FirstName = "Bob", LastName = "Moyer", Id = 3 };

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
            var idOfProductA = warehouse.AddProduct("Product A", 100);
            var idOfProductB = warehouse.AddProduct("Product B", 50);
            Assert.AreNotEqual(idOfProductA, idOfProductB);
        }
    }
