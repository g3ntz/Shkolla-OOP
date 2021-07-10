using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkolla_OOP
{
    class Address
    {
        public string city { get; set; }
        public string number { get; set; }
        public string streetName { get; set; }

        public Address(string city,string number,string streetName)
        {
            this.city = city;
            this.number = number;
            this.streetName = streetName;
        }
    }
}
