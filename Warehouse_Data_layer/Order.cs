﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;

namespace WarehouseDataLayer
{
    internal class Order: IOrder
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int StateID { get; set; }
        public DateTime Date { get; set; }
        public int? Quantity { get; set; }

        public Order(int ID, int UserID, int StateID, DateTime Date, int? Quantity)
        {
            this.ID = ID;
            this.UserID = UserID;
            this.StateID = StateID;
            this.Date = Date;    
            this.Quantity = Quantity;
        }
    }
}
