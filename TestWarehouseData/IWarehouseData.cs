using WarehouseDataLayer;

namespace TestWarehouseDataLayer
{
    public interface IWarehouseData
    {
        int AddProduct(string productName, int initialQuantity);
        void RecordIncomingShipment(int productId, int quantity);
        bool RecordOutgoingShipment(int productId, int quantity);
        public Dictionary<int, string> ProductCatalog { get; set; }
        public List<string> Invoices { get; set; }
        public Dictionary<int, int> Inventory { get; set; }
        public List<Person> Staff { get; set; }
        public List<Person> Customers { get; set; }
        public List<Person> Suppliers { get; set; }
    }
}
