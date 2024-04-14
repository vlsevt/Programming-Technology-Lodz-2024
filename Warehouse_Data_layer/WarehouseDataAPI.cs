namespace WarehouseDataLayer
{
    public abstract class WarehouseDataAPI
    {
        public Dictionary<int, string> ProductCatalog { get; set; } = new Dictionary<int, string>();
        public List<string> Invoices { get; set; } = new List<string>();
        public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>();
        public List<string> Staff { get; set; } = new List<string>();
        public List<string> Customers { get; set; } = new List<string>();
        public List<string> Suppliers { get; set; } = new List<string>();
        public abstract int AddProduct(string productName, int initialQuantity);
        public abstract void RecordIncomingShipment(int productId, int quantity);
        public abstract bool RecordOutgoingShipment(int productId, int quantity);
    }
}
