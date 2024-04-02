using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Logic
{
    internal class InventoryManager
    {
        private Inventory inventory;

        public InventoryManager()
        {
            inventory = new Inventory();
            // Initialize inventory data
        }

        public int CheckStock(Product product)
        {
            // Check stock of a product
        }

        // Implement other inventory management functions
    }
}
