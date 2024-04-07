using System;
using System.Collections.Generic;

public class WarehouseData
{
    public Dictionary<int, string> ProductCatalog { get; set; } = new Dictionary<int, string>();
    public List<string> Invoices { get; set; } = new List<string>();
    public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>();

    public void AddProduct(int productId, string productName, int initialQuantity)
    {
        ProductCatalog.Add(productId, productName);
        Inventory.Add(productId, initialQuantity);
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
            throw new KeyNotFoundException($"Product with ID {productId} does not exist in the inventory.");
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
