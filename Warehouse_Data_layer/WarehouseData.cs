namespace WarehouseDataLayer
{
    public class WarehouseData : WarehouseDataAPI
    {
        private int productIdCounter = 0;
        public int idAssignment()
        {
            productIdCounter++;
            return productIdCounter;
        }

        public override int AddProduct(string productName, int initialQuantity)
        {
            int newProductId = idAssignment();
            ProductCatalog.Add(newProductId, productName);
            Inventory.Add(newProductId, initialQuantity);
            return newProductId;
        }

        public override void RecordIncomingShipment(int productId, int quantity)
        {
            Inventory[productId] += quantity;
            Invoices.Add($"Received {quantity} units of product {ProductCatalog[productId]}");
        }

        public override bool RecordOutgoingShipment(int productId, int quantity)
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