namespace WarehouseDataLayer
{
    public interface WarehouseDataAPI
    {
        int AddProduct(string productName, int initialQuantity);
        void RecordIncomingShipment(int productId, int quantity);
        bool RecordOutgoingShipment(int productId, int quantity);
        public List<CatalogProduct> ProductCatalog { get; set; }
        public Dictionary<int, string> Invoices { get; set; }
        public List<InventoryProduct> Inventory { get; set; }
        public List<Staff> Staff { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}