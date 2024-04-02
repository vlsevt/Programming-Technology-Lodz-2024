using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Data
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
    }
}
