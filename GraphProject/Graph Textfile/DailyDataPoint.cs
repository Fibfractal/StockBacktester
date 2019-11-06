using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class DailyDataPoint
    {
        
        public double _Open { get; set; }
        public double _High { get; set; }
        public double _Low { get; set; }
        public double _Close { get; set; }
        public double _MilliSeconds { get; set; }
        public double _RSI { get; set; }
        public double _MA { get; set; }

        // Used to visualize that the calculated RSI values in GraphRsi matches dummy RSI values from data in website 
        public override string ToString()
        {
            return string.Format("{0}",_RSI);
        }
    }
}
