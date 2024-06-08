using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseLogicLayer.API;
using WarehouseDataLayer.APIs;

namespace WarehouseLogicLayer.Fakes
{
    internal class UserFake: IUser 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public UserFake(int ID, string Name, string Surname)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
        }
    }
}
