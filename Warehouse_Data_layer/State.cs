using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;

namespace WarehouseDataLayer
{
    internal class State: IState
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public State(int ID, int ProductID, int Quantity = 0)
        { 
            this.ID = ID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
        }
    }
}
