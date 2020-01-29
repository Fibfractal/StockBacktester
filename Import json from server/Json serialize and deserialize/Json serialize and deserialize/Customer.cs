using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_serialize_and_deserialize
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Address Myaddress { get; set; }

        public override string ToString()
        {

            return string.Format("{0} {1} {2}",FirstName,Age, Gender);
        }

    }
}
