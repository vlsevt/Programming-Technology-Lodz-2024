using System;

class Program
{
    static void Main(string[] args)
    {
        WarehouseData warehouseData = new WarehouseData();
        WarehouseLogic warehouseLogic = new WarehouseLogic(warehouseData);
        WarehouseAPI warehouseAPI = new WarehouseAPI(warehouseLogic);

        warehouseData.AddProduct(1, "Product A", 100);
        warehouseData.AddProduct(2, "Product B", 50);

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
