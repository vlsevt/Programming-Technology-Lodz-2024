using WarehouseDataLayer;
using WarehouseLogicLayer;

class Program
{
    static void Main(string[] args)
    {
        WarehouseDataAPI warehouseData = new WarehouseData();
        WarehouseLogicAPI warehouseLogic = new WarehouseLogic(warehouseData);

        var idOfProductA = warehouseData.AddProduct("Product A", 100);
        var idOfProductB = warehouseData.AddProduct("Product B", 50);

        Console.WriteLine("Product A id:" + idOfProductA);
        Console.WriteLine("Product B id:" + idOfProductB);


        warehouseData.Staff.Add("John");
        warehouseData.Customers.Add("Alice");
        warehouseData.Suppliers.Add("Bob");

        
        Console.WriteLine("Users in the warehouse:");
        Console.WriteLine("Staff:");
        foreach (var reader in warehouseData.Staff)
        {
            Console.WriteLine($"- {reader}");
        }
        Console.WriteLine("\nCustomers:");
        foreach (var customer in warehouseData.Customers)
        {
            Console.WriteLine($"- {customer}");
        }
        Console.WriteLine("\nSuppliers:");
        foreach (var supplier in warehouseData.Suppliers)
        {
            Console.WriteLine($"- {supplier}");
        }

        FulfillOrder(warehouseLogic, 1, 75);
        TakeInSupplies(warehouseLogic, 1, 50);
    }

    static void FulfillOrder(WarehouseLogicAPI warehouseLogic, int productId, int quantity)
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

    static void TakeInSupplies(WarehouseLogicAPI warehouseLogic, int productId, int quantity)
    {
        warehouseLogic.RestockProduct(productId, "Product A", quantity);
        Console.WriteLine($"Received {quantity} units of product with ID {productId}.");
    }
}
