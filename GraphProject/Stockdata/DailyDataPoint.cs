using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class has properties that describes the stock price.
    /// Open, Close, High and Low are properties of the price it self.
    /// While RSI, MA are calculations derrived from this price.
    /// Date is the date that the other properties occur.
    /// </summary>
    public class DailyDataPoint
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double MilliSeconds { get; set; }
        public double RSI { get; set; }
        public double MA200 { get; set; }
        public double MA50 { get; set; }
        public double MA20 { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", Date, Close, RSI, MA200, MA50, MA20);
        }
    }
}
