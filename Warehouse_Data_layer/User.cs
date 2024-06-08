using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;

namespace WarehouseDataLayer
{
    internal class User : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User(int ID, string Name, string Surname)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
        }
    }
}
