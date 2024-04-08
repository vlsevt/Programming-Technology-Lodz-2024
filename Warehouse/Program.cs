using System;

class Program
{
    static void Main(string[] args)
    {
        WarehouseData warehouseData = new WarehouseData();
        WarehouseLogic warehouseLogic = new WarehouseLogic(warehouseData);
        WarehouseAPI warehouseAPI = new WarehouseAPI(warehouseLogic);

        var idOfProductA = warehouseData.AddProduct("Product A", 100);
        var idOfProductB = warehouseData.AddProduct("Product B", 50);

        Console.WriteLine("Product A id:" + idOfProductA);
        Console.WriteLine("Product B id:" + idOfProductB);


        warehouseData.Users.Staff.Add("John");
        warehouseData.Users.Customers.Add("Alice");
        warehouseData.Users.Suppliers.Add("Bob");

        
        Console.WriteLine("Users in the warehouse:");
        Console.WriteLine("Staff:");
        foreach (var reader in warehouseData.Users.Staff)
        {
            Console.WriteLine($"- {reader}");
        }
        Console.WriteLine("\nCustomers:");
        foreach (var customer in warehouseData.Users.Customers)
        {
            Console.WriteLine($"- {customer}");
        }
        Console.WriteLine("\nSuppliers:");
        foreach (var supplier in warehouseData.Users.Suppliers)
        {
            Console.WriteLine($"- {supplier}");
        }

        FulfillOrder(warehouseAPI, 1, 75);
        TakeInSupplies(warehouseAPI, 1, 50);
    }

    static void FulfillOrder(WarehouseAPI warehouseAPI, int productId, int quantity)
    {
        bool orderFulfilled = warehouseAPI.FulfillOrder(productId, quantity);

        if (orderFulfilled)
        {
            Console.WriteLine($"The order for product with ID {productId} and quantity {quantity} was fulfilled successfully.");
        }
        else
        {
            Console.WriteLine($"Error occurred while fulfilling the order for product with ID {productId} and quantity {quantity}.");
        }
    }

    static void TakeInSupplies(WarehouseAPI warehouseAPI, int productId, int quantity)
    {
        warehouseAPI.RestockProduct(productId, "Product A", quantity);
        Console.WriteLine($"Received {quantity} units of product with ID {productId}.");
    }
}
