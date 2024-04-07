public class WarehouseLogic
{
    private WarehouseData _warehouse;

    public WarehouseLogic(WarehouseData warehouse)
    {
        _warehouse = warehouse;
    }

    public void RestockProduct(int productId, string productName, int quantity)
    {
        _warehouse.RecordIncomingShipment(productId, quantity);
    }

    public bool FulfillOrder(int productId, int quantity)
    {
        return _warehouse.RecordOutgoingShipment(productId, quantity);
    }
}
