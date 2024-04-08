using System.Collections.Generic;

public class WarehouseData
{
    public Dictionary<int, string> ProductCatalog { get; set; } = new Dictionary<int, string>();
    public List<string> Invoices { get; set; } = new List<string>();
    public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>();
    public Users Users { get; set; } = new Users();
    private int productIdCounter = 0;

    public int idAssignment()
    {
        productIdCounter++;
        return productIdCounter;
    }

    public int AddProduct(string productName, int initialQuantity)
    {
        int newProductId = idAssignment();
        ProductCatalog.Add(newProductId, productName);
        Inventory.Add(newProductId, initialQuantity);
        return newProductId;
    }

    public void RecordIncomingShipment(int productId, int quantity)
    {
        Inventory[productId] += quantity;
        Invoices.Add($"Received {quantity} units of product {ProductCatalog[productId]}");
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

public class Users
{
    public List<string> Staff { get; set; } = new List<string>(); 
    public List<string> Customers { get; set; } = new List<string>();
    public List<string> Suppliers { get; set; } = new List<string>();
}
