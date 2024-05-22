
namespace PresentationLayer.Model
{
    public class WarehouseLogic : WarehouseLogicAPI
    {
        private new readonly IWarehouseDataAPI _warehouse;

        public WarehouseLogic(IWarehouseDataAPI warehouse) : base(warehouse)
        {
            _warehouse = warehouse;
        }

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
