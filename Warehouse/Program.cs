using System;

class Program
{
    static void Main(string[] args)
    {
        
        WarehouseData warehouseData = new WarehouseData();
        WarehouseLogic warehouseLogic = new WarehouseLogic(warehouseData);

        
        warehouseData.AddProduct(1, "Product A", 100);
        warehouseData.AddProduct(2, "Product B", 50);

        FulfillOrder(warehouseLogic, 1, 75);

        TakeInSupplies(warehouseLogic, 1, 50);
    }

    static void FulfillOrder(WarehouseLogic warehouseLogic, int productId, int quantity)
    {
        bool orderFulfilled = warehouseLogic.FulfillOrder(productId, quantity);

        if (orderFulfilled)
        {
            Console.WriteLine($"The order for product with ID {productId} and quantity {quantity} was fulfilled successfully.");
        }
        else
        {
            Console.WriteLine($"Error occurred while fulfilling the order for product with ID {productId} and quantity {quantity}.");
        }
    }

    static void TakeInSupplies(WarehouseLogic warehouseLogic, int productId, int quantity)
    {
        warehouseLogic.RestockProduct(productId, "Product A", quantity);
        Console.WriteLine($"Received {quantity} units of product with ID {productId}.");
    }
}
