using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IProductDTO
    {
        int ID { get; set; }   
        string Name { get; set; }
        string Producer { get; set; }
        string Description { get; set; }

    }
}
