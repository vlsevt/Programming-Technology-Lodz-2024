using WarehouseDataLayer;

namespace WarehouseLogicLayer {
    public class WarehouseLogic : WarehouseLogicAPI
    {
        public WarehouseLogic(WarehouseDataAPI warehouse) : base(warehouse) { }

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
