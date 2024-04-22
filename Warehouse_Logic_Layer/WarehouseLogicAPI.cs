using TestWarehouseDataLayer;

namespace WarehouseLogicLayer
{
    public abstract class WarehouseLogicAPI
    {
        protected IWarehouseData _warehouse;

        protected WarehouseLogicAPI(IWarehouseData warehouse)
        {
            _warehouse = warehouse;
        }

        public abstract void RestockProduct(int productId, string productName, int quantity);
        public abstract bool FulfillOrder(int productId, int quantity);
    }
}
