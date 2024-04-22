using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer
{
    public class CatalogProduct : Product
    {
        public CatalogProduct(int Id, string Name) : base(Id, 0, Name)
        {
        }
    }
}
