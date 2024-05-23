using System;
using System.Windows;
using WarehouseLogicLayer;

namespace WarehousePresentationLayer
{
    public partial class AddProductWindow : Window
    {
        private readonly WarehouseLogicAPI _warehouseLogic;

        public AddProductWindow(WarehouseLogicAPI warehouseLogic)
        {
            InitializeComponent();
            _warehouseLogic = warehouseLogic;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            if (int.TryParse(InitialQuantityTextBox.Text, out int initialQuantity) && !string.IsNullOrEmpty(productName))
            {
                _warehouseLogic.AddProduct(productName, initialQuantity);
                MessageBox.Show("Product added successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid details.");
            }
        }
    }
}
