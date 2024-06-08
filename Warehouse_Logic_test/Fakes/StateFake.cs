using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseLogicLayer.API;
using WarehouseDataLayer.APIs;

namespace WarehouseLogicLayer.Fakes
{
    internal class StateFake: IState
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public StateFake(int ID, int ProductID, int Quantity = 0)
        {
            this.ID = ID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
        }
    }
}
