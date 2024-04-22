using System.Collections.Generic;

namespace WarehouseDataLayer
{
    public class WarehouseData : WarehouseDataAPI
    {
        public List<CatalogProduct> ProductCatalog { get; set; } = new List<CatalogProduct>();
        public Dictionary<int, string> Invoices { get; set; } = new Dictionary<int, string>();
        public List<InventoryProduct> Inventory { get; set; } = new List<InventoryProduct>();

        public List<Staff> Staff { get; set; } = new List<Staff>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();

        private int productIdCounter = 0;
        private int invoiceIdCounter = 0;

        public int productIdAssignment()
        {
            productIdCounter++;
            return productIdCounter;
        }

        public int invoiceIdAssignment()
        {
            invoiceIdCounter++;
            return invoiceIdCounter;
        }

        public int AddProduct(string productName, int initialQuantity)
        {
            int newProductId = productIdAssignment();
            ProductCatalog.Add(new CatalogProduct(newProductId, productName));
            Inventory.Add(new InventoryProduct(newProductId, initialQuantity));
            return productIdCounter;
        }

        public bool RecordIncomingShipment(int productId, int quantity)
        {
            if (Inventory is null)
            {
                return false;
            }

            InventoryProduct? foundProduct = Inventory.FirstOrDefault(p => p.Id == productId);

            if (foundProduct != null)
            {
                foundProduct.Quantity += quantity;
                var product = ProductCatalog[productId - 1];
                int newInvoiceId = invoiceIdAssignment();
                if (product == null)
                {
                    return false;
                }
                Invoices.Add(newInvoiceId, $"Received {quantity} units of product {ProductCatalog[productId - 1].Name}");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RecordOutgoingShipment(int productId, int quantity)
        {
            InventoryProduct? product = Inventory.FirstOrDefault(p => p.Id == productId);

            if (product != null && product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                var catalogProduct = ProductCatalog[productId - 1];
                int newInvoiceId = invoiceIdAssignment();
                if (catalogProduct == null)
                {
                    return false;
                }
                Invoices.Add(newInvoiceId, $"Shipped {quantity} units of product {catalogProduct.Name}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
