using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PresentationLayer.Model;

namespace PresentationLayer.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : ViewModelBase
    {
        private readonly ModelAPI _model;

        public ObservableCollection<CatalogProduct> ProductCatalog { get; }
        public ObservableCollection<InventoryProduct> Inventory { get; }
        public ObservableCollection<string> Invoices { get; }

        public MainViewModel(ModelAPI model)
        {
            _model = model;
            ProductCatalog = new ObservableCollection<CatalogProduct>(_model.GetProductCatalog());
            Inventory = new ObservableCollection<InventoryProduct>(_model.GetInventory());
            Invoices = new ObservableCollection<string>(_model.GetInvoices());
        }

        // Commands
        private ICommand _restockCommand;
        public ICommand RestockCommand => _restockCommand ??= new RelayCommand(RestockProduct);

        private ICommand _fulfillOrderCommand;
        public ICommand FulfillOrderCommand => _fulfillOrderCommand ??= new RelayCommand(FulfillOrder);

        // Methods bound to commands
        private void RestockProduct(object parameter)
        {
            if (parameter is Tuple<int, string, int> tuple)
            {
                int productId = tuple.Item1;
                string productName = tuple.Item2;
                int quantity = tuple.Item3;

                _model.RestockProduct(productId, productName, quantity);
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

                _model.FulfillOrder(productId, quantity);
                var product = Inventory.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    product.Quantity -= quantity;
                }
                var catalogProduct = ProductCatalog.FirstOrDefault(p => p.Id == productId);
                if (catalogProduct != null)
                {
                    Invoices.Add($"Shipped {quantity} units of product {catalogProduct.Name}");
                }
            }
        }
    }
}
