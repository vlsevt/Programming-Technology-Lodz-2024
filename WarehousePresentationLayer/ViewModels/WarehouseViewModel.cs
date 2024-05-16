using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseDataLayer;
using WarehouseLogicLayer;

namespace WarehouseApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly WarehouseLogicAPI _warehouseLogic;

        public ObservableCollection<CatalogProduct> ProductCatalog { get; }
        public ObservableCollection<InventoryProduct> Inventory { get; }
        public ObservableCollection<string> Invoices { get; }

        public MainViewModel(WarehouseDataAPI warehouseData)
        {
            _warehouseLogic = new WarehouseLogic(warehouseData);
            ProductCatalog = new ObservableCollection<CatalogProduct>(_warehouseLogic.ProductCatalog);
            Inventory = new ObservableCollection<InventoryProduct>(_warehouseLogic.Inventory);
            Invoices = new ObservableCollection<string>(_warehouseLogic.Invoices);
        }

        // Commands
        private ICommand _restockCommand;
        public ICommand RestockCommand => _restockCommand ?? (_restockCommand = new RelayCommand(RestockProduct));

        private ICommand _fulfillOrderCommand;
        public ICommand FulfillOrderCommand => _fulfillOrderCommand ?? (_fulfillOrderCommand = new RelayCommand(FulfillOrder));

        // Methods bound to commands
        private void RestockProduct(object parameter)
        {
            if (parameter is Tuple<int, string, int> tuple)
            {
                int productId = tuple.Item1;
                string productName = tuple.Item2;
                int quantity = tuple.Item3;

                _warehouseLogic.RestockProduct(productId, productName, quantity);
                ProductCatalog.Add(new CatalogProduct(productId, productName));
                Inventory.Add(new InventoryProduct(productId, quantity));
                Invoices.Add($"Received {quantity} units of product {productName}");
            }
        }

        private void FulfillOrder(object parameter)
        {
            if (parameter is Tuple<int, int> tuple)
            {
                int productId = tuple.Item1;
                int quantity = tuple.Item2;

                _warehouseLogic.FulfillOrder(productId, quantity);
                int index = Inventory.FindIndex(p => p.Id == productId);
                if (index >= 0)
                {
                    Inventory[index].Quantity -= quantity;
                }
                Invoices.Add($"Shipped {quantity} units of product {ProductCatalog[productId - 1].Name}");
            }
        }
    }
}
