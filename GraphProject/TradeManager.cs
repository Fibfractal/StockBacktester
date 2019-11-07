using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class TradeManager
    {
        private List<OneTrade> _tradeList;

        public TradeManager()
        {
            _tradeList = new List<OneTrade>();
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
                sum += item.ProfitTrade;
            }
            return sum;
        }
    }
}
