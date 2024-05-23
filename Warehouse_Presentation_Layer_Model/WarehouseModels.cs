using System.Collections.Generic;

namespace PresentationLayer.Model
{

    public static class Converter
    {
        public static Staff ToPresentationStaff(this WarehouseDataLayer.Staff staff)
        {
            return new Staff(staff.FirstName, staff.LastName, staff.Id);
        }

        public static CatalogProduct ToPresentationCatalogProduct(this WarehouseDataLayer.CatalogProduct product)
        {
            return new CatalogProduct(product.Id, product.Name);
        }

        public static InventoryProduct ToPresentationInventoryProduct(this WarehouseDataLayer.InventoryProduct product)
        {
            return new InventoryProduct(product.Id, product.Quantity);
        }
    }


    public class ModelImplementation : ModelAPI
    {
        private readonly WarehouseLogicLayer.WarehouseLogicAPI _logicAPI;

        public ModelImplementation(WarehouseLogicLayer.WarehouseLogicAPI logicAPI)
        {
            _logicAPI = logicAPI;
        }

        public override IEnumerable<Staff> GetStaff()
        {
            return _logicAPI.Staff.Select(s => s.ToPresentationStaff());
        }

        public override IEnumerable<CatalogProduct> GetProductCatalog()
        {
            return _logicAPI.ProductCatalog.Select(p => p.ToPresentationCatalogProduct());
        }

        public override IEnumerable<InventoryProduct> GetInventory()
        {
            return _logicAPI.Inventory.Select(p => p.ToPresentationInventoryProduct());
        }

        public override IEnumerable<string> GetInvoices()
        {
            return _logicAPI.Invoices;
        }
    }

    public class CatalogProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public CatalogProduct(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class InventoryProduct
        {
            public int Id { get; set; }
            public int Quantity { get; set; }

            public InventoryProduct(int id, int quantity)
            {
                Id = id;
                Quantity = quantity;
            }
        }

        public class Product
        {
            public int Id { get; }
            public int Quantity { get; }
            public string Name { get; }

            public Product(int id, int quantity, string name)
            {
                Id = id;
                Quantity = quantity;
                Name = name;
            }
        }

        public class Person
        {
            public string FirstName { get; }
            public string LastName { get; }
            public int Id { get; }

            public Person(string firstName, string lastName, int id)
            {
                FirstName = firstName;
                LastName = lastName;
                Id = id;
            }

            public override string ToString()
            {
                return $"{FirstName} {LastName} (ID: {Id})";
            }
        }

        public class Customer : Person
        {
            public Customer(string firstName, string lastName, int id) : base(firstName, lastName, id)
            {
            }
        }

        public class Staff : Person
        {
            public Staff(string firstName, string lastName, int id) : base(firstName, lastName, id)
            {
            }
        }

        public class Supplier : Person
        {
            public Supplier(string firstName, string lastName, int id) : base(firstName, lastName, id)
            {
            }
        }
    
}

