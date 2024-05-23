using WarehouseDataLayer;

namespace WarehouseLogicLayer
{
    public abstract class WarehouseLogicAPI
    {
        protected IWarehouseDataAPI _warehouse;

        protected WarehouseLogicAPI(IWarehouseDataAPI warehouse)
        {
            _warehouse = warehouse;
        }

        public abstract bool RestockProduct(int productId, string productName, int quantity);
        public abstract bool FulfillOrder(int productId, int quantity);

        public IEnumerable<Staff> Staff => _warehouse.Staff;
        public IEnumerable<CatalogProduct> ProductCatalog => _warehouse.ProductCatalog;
        public IEnumerable<InventoryProduct> Inventory => _warehouse.Inventory;
        public IEnumerable<string> Invoices => _warehouse.Invoices.Values;
    }
}
