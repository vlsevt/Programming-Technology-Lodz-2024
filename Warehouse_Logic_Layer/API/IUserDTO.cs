﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IUserDTO
    {
        int ID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}