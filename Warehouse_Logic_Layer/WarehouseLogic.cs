using WarehouseDataLayer;

namespace WarehouseLogicLayer
{
    public class WarehouseLogic : WarehouseLogicAPI
    {
        public WarehouseLogic(IWarehouseDataAPI warehouse) : base(warehouse) { }

        public override bool RestockProduct(int productId, string productName, int quantity)
        {
            return _warehouse.RecordIncomingShipment(productId, quantity);
        }

        public override bool FulfillOrder(int productId, int quantity)
        {
            return _warehouse.RecordOutgoingShipment(productId, quantity);
        }
    }
}
