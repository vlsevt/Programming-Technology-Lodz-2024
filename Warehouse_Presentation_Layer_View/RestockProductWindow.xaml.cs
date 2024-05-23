using System;
using System.Windows;
using WarehouseLogicLayer;

namespace WarehousePresentationLayer
{
    public partial class RestockProductWindow : Window
    {
        private readonly WarehouseLogicAPI _warehouseLogic;

        public RestockProductWindow(WarehouseLogicAPI warehouseLogic)
        {
            InitializeComponent();
            _warehouse
            Logic = warehouseLogic;
        }

        private void RestockButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ProductIdTextBox.Text, out int productId) && int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                bool success = _warehouseLogic.RestockProduct(productId, "", quantity); // Assuming product name is not needed for restocking
                if (success)
                {
                    MessageBox.Show("Product restocked successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to restock the product. Please check the product ID and quantity.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid details.");
            }
        }
    }
}
