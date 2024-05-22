namespace PresentationLayer.Model
{
    public class WarehouseData : IWarehouseDataAPI
    {
        public List<CatalogProduct> ProductCatalog { get; set; } = new List<CatalogProduct>();
        public Dictionary<int, string> Invoices { get; set; } = new Dictionary<int, string>();
        public List<InventoryProduct> Inventory { get; set; } = new List<InventoryProduct>();
        public List<Staff> Staff { get; set; } = new List<Staff>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();

        private int productIdCounter = 0;
        private int invoiceIdCounter = 0;

        private int GenerateProductId() => ++productIdCounter;
        private int GenerateInvoiceId() => ++invoiceIdCounter;

        public int AddProduct(string productName, int initialQuantity)
        {
            int newProductId = GenerateProductId();
            ProductCatalog.Add(new CatalogProduct(newProductId, productName));
            Inventory.Add(new InventoryProduct(newProductId, initialQuantity));
            return newProductId;
        }

        public bool RecordIncomingShipment(int productId, int quantity)
        {
            var product = Inventory.FirstOrDefault(p => p.Id == productId);
            if (product == null) return false;

            product.Quantity += quantity;
            var catalogProduct = ProductCatalog.FirstOrDefault(p => p.Id == productId);
            if (catalogProduct == null) return false;

            Invoices.Add(GenerateInvoiceId(), $"Received {quantity} units of product {catalogProduct.Name}");
            return true;
        }

        public bool RecordOutgoingShipment(int productId, int quantity)
        {
            var product = Inventory.FirstOrDefault(p => p.Id == productId);
            if (product == null || product.Quantity < quantity) return false;

            product.Quantity -= quantity;
            var catalogProduct = ProductCatalog.FirstOrDefault(p => p.Id == productId);
            if (catalogProduct == null) return false;

            Invoices.Add(GenerateInvoiceId(), $"Shipped {quantity} units of product {catalogProduct.Name}");
            return true;
        }
    }
}
