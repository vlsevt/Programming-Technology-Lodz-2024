using PresentationLayer.Model;

public abstract class ModelAPI
{
    public abstract IEnumerable<Staff> GetStaff();
    public abstract IEnumerable<CatalogProduct> GetProductCatalog();
    public abstract IEnumerable<InventoryProduct> GetInventory();
    public abstract IEnumerable<string> GetInvoices();

    public static ModelAPI Create(WarehouseLogicLayer.WarehouseLogicAPI logicAPI)
    {
        return new ModelImplementation(logicAPI);
    }
}