using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class shows the properies of one trade.
    /// Shows the buying and selling price and dates.
    /// An if a trade is active or finished, and if
    /// it was a win or loss. Spread and courtage
    /// is considered.
    /// </summary>
    public  class OneTrade
    {
        private double _buy = -1;
        private double _sell = -1;
        private double _spread = 0.0006;   // 0.06 %
        private double _courtage = 0.0000; // 0.00 % I am courtage free

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

        /// <summary>
        /// Ways to see if trade is active or finished
        /// </summary>
        public bool Bought => _buy >= 0;
        public bool Sold => _sell >= 0;
        public bool Finished => Bought && Sold;

        public double ProfitTrade() => Finished ? (_sell - _buy - _spread * _sell - _courtage * _buy - _courtage * _sell) : 0.00;
    }
}
