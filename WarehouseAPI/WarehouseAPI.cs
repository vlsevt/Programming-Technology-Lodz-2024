public class WarehouseAPI
{
    private WarehouseLogic _warehouseLogic;

    public WarehouseAPI(WarehouseLogic warehouseLogic)
    {
        _warehouseLogic = warehouseLogic;
    }

    public void RestockProduct(int productId, string productName, int quantity)
    {
        _warehouseLogic.RestockProduct(productId, productName, quantity);
    }

    public bool FulfillOrder(int productId, int quantity)
    {
        return _warehouseLogic.FulfillOrder(productId, quantity);
    }
}
