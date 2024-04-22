using TestWarehouseDataLayer;

namespace WarehouseLogicLayer
{
    public class WarehouseLogic : WarehouseLogicAPI
    {
        private readonly IWarehouseData _warehouse;

        public WarehouseLogic(IWarehouseData warehouse) : base(warehouse) 
        {
            _warehouse = warehouse;
        }

        public override void RestockProduct(int productId, string productName, int quantity)
        {
            _warehouse.RecordIncomingShipment(productId, quantity);
        }

        public override bool FulfillOrder(int productId, int quantity)
        {
            return _warehouse.RecordOutgoingShipment(productId, quantity);
        }
    }
}
