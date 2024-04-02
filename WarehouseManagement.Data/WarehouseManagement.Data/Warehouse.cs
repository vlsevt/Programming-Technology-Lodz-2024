using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Data
{
    public class Warehouse
    {
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
