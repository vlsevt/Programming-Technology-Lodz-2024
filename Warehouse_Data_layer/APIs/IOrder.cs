using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer.APIs
{
    public interface IOrder
    {
        int ID { get; set; }
        int UserID { get; set; }
        int StateID { get; set; }
        DateTime Date { get; set; }
        public int? Quantity { get; set; }

    }
}
