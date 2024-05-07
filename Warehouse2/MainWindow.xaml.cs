using System;
using System.Windows;
using WarehouseDataLayer;
using WarehouseLogicLayer;

namespace Warehouse
{
    public partial class MainWindow : Window
    {
        private WarehouseDataAPI warehouseData;
        private WarehouseLogicAPI warehouseLogic;

        public MainWindow()
        {
            InitializeComponent();

            warehouseData = new WarehouseData();
            warehouseLogic = new WarehouseLogic(warehouseData);

            var idOfProductA = warehouseData.AddProduct("Product A", 100);
            var idOfProductB = warehouseData.AddProduct("Product B", 50);

            Staff staffMember = new Staff("John", "Hendricks", 1);
            Customer customer = new Customer("Alice", "Murphy", 2);
            Supplier supplier = new Supplier("Bob", "Moyer", 3);

            warehouseData.Staff.Add(staffMember);
            warehouseData.Customers.Add(customer);
            warehouseData.Suppliers.Add(supplier);

            UpdateUserListBox();
        }

        private void UpdateUserListBox()
        {
            UserListBox.Items.Clear();
            foreach (var staffMember in warehouseData.Staff)
            {
                UserListBox.Items.Add($"Staff: {staffMember.FirstName} {staffMember.LastName}");
            }
            foreach (var customer in warehouseData.Customers)
            {
                UserListBox.Items.Add($"Customer: {customer.FirstName} {customer.LastName}");
            }
            foreach (var supplier in warehouseData.Suppliers)
            {
                UserListBox.Items.Add($"Supplier: {supplier.FirstName} {supplier.LastName}");
            }
        }

        private void FulfillOrderButton_Click(object sender, RoutedEventArgs e)
        {
            FulfillOrder(1, 75);
        }

        private void TakeInSuppliesButton_Click(object sender, RoutedEventArgs e)
        {
            TakeInSupplies(1, 50);
        }

        private void FulfillOrder(int productId, int quantity)
        {
            bool orderFulfilled = warehouseLogic.FulfillOrder(productId, quantity);

            if (orderFulfilled)
            {
                MessageBox.Show($"The order for product with ID {productId} and quantity {quantity} was fulfilled successfully.");
            }
            else
            {
                MessageBox.Show($"Error occurred while fulfilling the order for product with ID {productId} and quantity {quantity}.");
            }
        }

        private void TakeInSupplies(int productId, int quantity)
        {
            warehouseLogic.RestockProduct(productId, "Product A", quantity);
            MessageBox.Show($"Received {quantity} units of product with ID {productId}.");
        }
    }
}
