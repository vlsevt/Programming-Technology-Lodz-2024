using WarehouseDataLayer;

namespace WarehouseLogicLayer
{
    public abstract class WarehouseLogicAPI
    {
        protected WarehouseDataAPI _warehouse;

        protected WarehouseLogicAPI(WarehouseDataAPI warehouse)
        {
            _warehouse = warehouse;
        }

        public abstract void RestockProduct(int productId, string productName, int quantity);
        public abstract bool FulfillOrder(int productId, int quantity);
    }
}
