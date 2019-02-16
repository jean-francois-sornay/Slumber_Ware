using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slumber_Ware
{
    public class StructurePerso
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            string res = "";
            res += Id + "\n" + LastName + "\n" + FirstName + "\n" + Address + "\n";
            return res;
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            string res = "";
            res += Street + "\n" + ZipCode + "\n" + City + "\n" + Country + "\n";
            return res;
        }
    }
}
