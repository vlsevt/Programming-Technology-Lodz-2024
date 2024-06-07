using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IStateDTO
    {
        int ID { get; set; }
        int ProductID { get; set; }
        int Quantity { get; set; }
    }
}
