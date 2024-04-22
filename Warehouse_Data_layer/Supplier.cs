using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer
{
    public class Supplier : Person
    {
        public Supplier(string FirstName, string LastName, int Id) : base(FirstName, LastName, Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;
        }
    }
}
