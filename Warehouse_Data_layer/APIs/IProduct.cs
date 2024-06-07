using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer.APIs
{
    public interface IProduct
    {
        int ID { get; }
        string Name { get; set; }
        string Producer { get; set; }
        string Description { get; set; }
    }
}
