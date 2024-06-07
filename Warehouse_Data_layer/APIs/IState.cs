using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer.APIs
{
    public interface IState
    {
        int ID { get; set; }
        int ProductID { get; set; }
        int Quantity { get; set; }
    }
}
