using System.Collections.Generic;
using WarehouseDataLayer;

namespace TestWarehouseDataLayer
{
    public class WarehouseDataFake : IWarehouseData
    {
        private int productIdCounter = 0;
        public Dictionary<int, string> ProductCatalog { get; set; } = new Dictionary<int, string>();
        public List<string> Invoices { get; set; } = new List<string>();
        public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>();

        public List<Person> Staff { get; set; } = new List<Person>();
        public List<Person> Customers { get; set; } = new List<Person>();
        public List<Person> Suppliers { get; set; } = new List<Person>();

        public int AddProduct(string productName, int initialQuantity)
        {
            productIdCounter++;
            ProductCatalog.Add(productIdCounter, productName);
            Inventory.Add(productIdCounter, initialQuantity);
            return productIdCounter;
        }

        public void RecordIncomingShipment(int productId, int quantity)
        {
            if (Inventory.ContainsKey(productId))
            {
                Inventory[productId] += quantity;
                Invoices.Add($"Received {quantity} units of product {ProductCatalog[productId]}");
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found in inventory.");
            }
        }

        public bool RecordOutgoingShipment(int productId, int quantity)
        {
            if (Inventory.ContainsKey(productId) && Inventory[productId] >= quantity)
            {
                Inventory[productId] -= quantity;
                Invoices.Add($"Shipped {quantity} units of product {ProductCatalog[productId]}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
