using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class ProductDTO : IProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }

        public ProductDTO(int ID, string Name, string Producer, string Description)
        {
            this.ID = ID;
            this.Name = Name;
            this.Producer = Producer;
            this.Description = Description;
        }
    }
}
