using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class manages the trades. Methods adds new trades, sees if last trade
    /// is finished or unfinished, count number of trades and summerises total profit
    /// </summary>
    public class TradeManager
    {
        private List<OneTrade> _tradeList;

        public TradeManager()
        {
            _tradeList = new List<OneTrade>();
        }

        public List<OneTrade> GetTradeList
        {
            get
            {
                return _tradeList;
            }
        }

        /// <summary>
        /// Returns true, if previous trade has finished or if list count is 0. 
        /// Then a new trade can be added.
        /// </summary>
        public bool AddNewTradeOk()
        {
            if (_tradeList.Count > 0 )
            {
                if (_tradeList[_tradeList.Count - 1].Finished)
                {
                    return true;
                }
            }
            else if(_tradeList.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks the last trade in tradelist, to see if its unfinished, returns true if so.
        /// </summary>
        public bool UnFinishedTrade()
        {
            return (_tradeList.Count > 0 && _tradeList[_tradeList.Count - 1].Bought && (_tradeList[_tradeList.Count - 1].Sold == false)) ? true : false;
        }

        public void AddTrade(OneTrade oneTrade)
        {
            if (oneTrade != null)
                _tradeList.Add(oneTrade);
        }

        public bool VerifyCompletedTrades()
        {
            bool flag = true;
            foreach (var item in _tradeList)
            {
                if ((item.Bought && item.Sold) == false)
                    flag = false;
            }
            return flag;
        }

        public double TotalProfit()
        {
            double sum = 0;
            foreach (var item in _tradeList)
            {
                sum += item.ProfitTrade();
            }
            return sum;
        }

        public int NbrFinishedTrades()
        {
            int nbrFinishedTrades = 0;
            foreach (var item in _tradeList)
            {
                if (item.Finished)
                    nbrFinishedTrades++;
            }
            return nbrFinishedTrades;
        }
    }
}
