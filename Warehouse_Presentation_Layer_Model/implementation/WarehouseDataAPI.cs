namespace PresentationLayer.Model
{
    public interface IWarehouseDataAPI
    {
        int AddProduct(string productName, int initialQuantity);
        bool RecordIncomingShipment(int productId, int quantity);
        bool RecordOutgoingShipment(int productId, int quantity);
        List<CatalogProduct> ProductCatalog { get; set; }
        Dictionary<int, string> Invoices { get; set; }
        List<InventoryProduct> Inventory { get; set; }
        List<Staff> Staff { get; set; }
        List<Customer> Customers { get; set; }
        List<Supplier> Suppliers { get; set; }
    }
}