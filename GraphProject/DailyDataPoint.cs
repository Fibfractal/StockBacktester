using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class DailyDataPoint //: IDataPoint
    {
        
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double MilliSeconds { get; set; }
        

        /*
        private double _open;
        private double _high;
        private double _low;
        private double _close;
        private double _milliSeconds;



        public double Open
        {
            get { return _open; }
            set { _open = value; }
        }
        

        public double High
        {
            get { return _high; }
            set { _high = value; }
        }

        public double Low
        {
            get { return Low; }
            set { Low = value; }
        }

        public double Close
        {
            get { return _close; }
            set { _close = value; }
        }

        public double MilliSeconds
        {
            get { return _milliSeconds; }
            set { _milliSeconds = value; }
        }
        */






        public override string ToString()
        {
            string strOut = string.Format("{0,-18} {1,-11} {2,-19} {3,-12} {4}",
                Open, High, Low, Close, MilliSeconds);
            return strOut;
        }
    }
}
