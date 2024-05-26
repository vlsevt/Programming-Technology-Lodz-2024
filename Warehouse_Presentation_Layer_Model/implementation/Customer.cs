using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Presentation_Layer_Model.implementation
{
    public class Customer : Person
    {
        public Customer(string FirstName, string LastName, int Id) : base(FirstName, LastName, Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;
        }
    }
}
