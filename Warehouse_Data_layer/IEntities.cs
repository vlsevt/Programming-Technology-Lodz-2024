using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer
{
    public interface ICatalogProduct : IProduct
    {
        public class CatalogProduct : ICatalogProduct
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Name { get; set; }

            public CatalogProduct(int id, string name)
            {
                Id = id;
                Quantity = 0;
                Name = name;
            }
        }
    }

    public interface IInventoryProduct : IProduct
    {
        public class InventoryProduct : IInventoryProduct
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Name { get; set; }

            public InventoryProduct(int id, int quantity)
            {
                Id = id;
                Quantity = quantity;
                Name = string.Empty;
            }
        }
    }


    public interface IProduct
    {
        int Id { get; set; }
        int Quantity { get; set; }
        string Name { get; set; }

        public class Product : IInventoryProduct, ICatalogProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }

    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Id { get; set; }

        public class Person : IPerson
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }

    public interface ICustomer : IPerson
    {
        public class Customer : ICustomer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }

            public Customer(string firstName, string lastName, int id)
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

    }

    public interface IStaff : IPerson
    {
        public class Staff : IStaff
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }

            public Staff(string firstName, string lastName, int id)
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
    }

    public interface ISupplier : IPerson
    {

        public class Supplier : ISupplier
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }

            public Supplier(string firstName, string lastName, int id)
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
    }
}
