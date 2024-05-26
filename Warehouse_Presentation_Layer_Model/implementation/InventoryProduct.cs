using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Presentation_Layer_Model.implementation
{
    public class InventoryProduct : Product
    {
        public InventoryProduct(int Id, int Quantity) : base(Id, Quantity, "")
        {
        }
    }
}
