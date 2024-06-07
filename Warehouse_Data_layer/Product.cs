using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;

namespace WarehouseDataLayer
{
    internal class Product: IProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }

        public Product(int ID, string Name, string Producer, string Description)
        {
            this.ID = ID;
            this.Name = Name;
            this.Producer = Producer;
            this.Description = Description;
        }
    }
}
