using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_serialize_and_deserialize
{
    public class StockData
    {
        public DateTime date { get; set; }
        public double close { get; set; }


        public override string ToString()
        {

            return string.Format("{0}   {1}", date.ToShortDateString(), close);
        }
    }
}
