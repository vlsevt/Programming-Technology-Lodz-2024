using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer;

namespace WarehouseLogicTests
{
    internal class WarehouseDataMock : WarehouseDataAPI
    {
        public List<CatalogProduct> ProductCatalog { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<int, string> Invoices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<InventoryProduct> Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Customer> Customers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Supplier> Suppliers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Staff> Staff { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int AddProduct(string productName, int initialQuantity)
        {
            return 1;
        }

        public bool RecordIncomingShipment(int productId, int quantity)
        {
            return true;
        }

        public bool RecordOutgoingShipment(int productId, int quantity)
        {
            return true;
        }
    }
}
