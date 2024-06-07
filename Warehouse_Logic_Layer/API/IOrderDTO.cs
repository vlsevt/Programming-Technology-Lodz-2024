using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IOrderDTO
    {
        int ID { get; set; }
        int UserID { get; set; }
        int StateID { get; set; }
        DateTime Date { get; set; }
        public int? Quantity { get; set; }
    }
}
