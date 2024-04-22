using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer
{
    public class InventoryProduct : Product
    {
        public InventoryProduct(int Id, int Quantity) : base(Id, Quantity, "")
        {
        }
    }
}
