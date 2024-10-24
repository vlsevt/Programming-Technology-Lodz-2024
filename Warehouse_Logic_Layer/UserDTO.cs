﻿using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class UserDTO : IUserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public UserDTO(int ID, string Name, string Surname)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
        }
    }
}
