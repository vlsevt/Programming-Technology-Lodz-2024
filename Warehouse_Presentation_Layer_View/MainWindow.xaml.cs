using System.Windows;
using WarehouseDataLayer;
using WarehouseLogicLayer;
using System.Linq;

namespace Warehouse_Presentation_Layer_View
{
    public partial class MainWindow : Window
    {
        private readonly WarehouseLogicAPI _warehouseLogic;

        public MainWindow()
        {
            InitializeComponent();

            var warehouseData = new WarehouseData();
            _warehouseLogic = new WarehouseLogic(warehouseData);

            InitializeData();
        }

        private void InitializeData()
        {
            // Populate the ListView controls with data
            ProductListView.ItemsSource = _warehouseLogic.ProductCatalog.ToList();
            InventoryListView.ItemsSource = _warehouseLogic.Inventory.ToList();
            StaffListView.ItemsSource = _warehouseLogic.Staff.ToList();
            CustomerListView.ItemsSource = _warehouseLogic.Customers.ToList();
            SupplierListView.ItemsSource = _warehouseLogic.Suppliers.ToList();
            InvoiceListView.ItemsSource = _warehouseLogic.Invoices.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Warehouse Management Application\nVersion 1.0", "About");
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to add a product
            var addProductWindow = new AddProductWindow(_warehouseLogic);
            addProductWindow.ShowDialog();
            InitializeData();
        }

        private void RestockProduct_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to restock a product
            var restockProductWindow = new RestockProductWindow(_warehouseLogic);
            restockProductWindow.ShowDialog();
            InitializeData();
        }

        private void FulfillOrder_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to fulfill an order
            var fulfillOrderWindow = new FulfillOrderWindow(_warehouseLogic);
            fulfillOrderWindow.ShowDialog();
            InitializeData();
        }
    }
}
