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
        public double RSI { get; set; }

        /*
        public override string ToString()
        {
            string strOut = string.Format("{0,-18} {1,-11} {2,-19} {3,-12} {4}",
                _Open, _High, _Low, _Close, _MilliSeconds);
            return strOut;
        }
        */

        public override string ToString()
        {
            return string.Format("{0}",RSI);
        }


    }
}
