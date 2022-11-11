using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.models
{
    public class AddressLastName
    {
        public int Room { get; set; }
        public string Address { get; set; }
        public string LastName { get; set; }

        public bool Equals(AddressLastName obj)
        {
            return Address.Equals(obj.Address) && LastName.Equals(obj.LastName) && Room.Equals(obj.Room);
        }
    }
}
