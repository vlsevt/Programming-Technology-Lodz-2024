using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class StateDTO : IStateDTO
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public StateDTO(int id, int ProductID, int Quantity)
        {
            this.ID = ID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
        }
    }
}
