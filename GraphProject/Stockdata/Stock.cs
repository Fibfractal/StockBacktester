using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class contains the ticker and price history for one stock.
    /// </summary>
    public class Stock
    {
        public string symbol { get; set; }
        public List<DailyDataPoint> historical { get; set; }
    }
}
