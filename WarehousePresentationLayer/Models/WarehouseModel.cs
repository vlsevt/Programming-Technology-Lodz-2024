using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Models
{
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
