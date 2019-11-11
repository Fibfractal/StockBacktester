using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public  class OneTrade
    {
        private double _buy = -1;
        private double _sell = -1;
        private double _spread = 0.0006;

        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }

        public double Buy
        {
            get { return _buy; }
            set 
            {
                if(value >=0)
                _buy = value; 
            }
        }

        public double Sell
        {
            get { return _sell; }
            set 
            {
                if(value >= 0)
                _sell = value; 
            }
        }

        // See if trade is active or done
        public bool Bought => _buy >= 0;
        public bool Sold => _sell >= 0;
        public bool Finished => Bought && Sold;
        public double ProfitTrade()
        {
            return (Finished) ? (_sell - _buy - _spread * _sell) : 0.00;
        }
    }
}
