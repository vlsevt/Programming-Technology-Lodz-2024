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
    }
}
