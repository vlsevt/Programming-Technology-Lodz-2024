using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WarehouseDataLayer;
using WarehouseLogicLayer;

/*namespace Warehouse2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WarehouseDataAPI warehouseData = new WarehouseData();
            WarehouseLogicAPI warehouseLogic = new WarehouseLogic(warehouseData);
            
            var idOfProductA = warehouseData.AddProduct("Product A", 100);
            var idOfProductB = warehouseData.AddProduct("Product B", 50);

            Staff staffMember = new Staff("John", "Hendricks", 1);
            Customer customer = new Customer("Alice", "Murphy", 2);
            Supplier supplier = new Supplier("Bob", "Moyer", 3);



            warehouseData.Staff.Add(staffMember);
            warehouseData.Customers.Add(customer);
            warehouseData.Suppliers.Add(supplier);

            // Pass the instances to the main window
            MainWindow mainWindow = new MainWindow(warehouseData, warehouseLogic);
            mainWindow.Show();
        }
    }

}
*/