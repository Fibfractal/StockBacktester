using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    public class MoneyManager
    {
        private double _portfolioValueStart;
        private double _portfolioValue ;
        private double _valuePerPoint;

        public MoneyManager(double portfolioValueStart, double valuePerpoint)
        {
            _portfolioValueStart = portfolioValueStart;
            _portfolioValue = portfolioValueStart;
            _valuePerPoint = valuePerpoint;
        }

        public double PortfolioValueStart
        {
            get { return _portfolioValueStart; }
            set
            {
                if (value >= 0)
                    _portfolioValueStart = value;
            }
        }

        public double PortfolioValue
        {
            get { return _portfolioValue; }
        }

        public double ChangePortFolValue(TradeManager tradeList, int index)
        {
            _portfolioValue += (tradeList.GetTradeList[index].ProfitTrade() / tradeList.GetTradeList[index].Sell) * _valuePerPoint ;
            return _portfolioValue;
        }

        public double ReturnSek()
        {
            return _portfolioValue - _portfolioValueStart;
        }

        public double ReturnProcent()
        {
            return (_portfolioValue - _portfolioValueStart) / _portfolioValueStart * 100;
        }

        public double Winners(TradeManager tradeList)
        {
            double nbrWinners = 0;
            double nbrFinishedTrades = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() > 0 && item.Finished)
                    nbrWinners++;
                if (item.Finished)
                    nbrFinishedTrades++;

            }

            return (nbrWinners / nbrFinishedTrades) * 100;
        }

        public double NumberOfFinishedTrades(TradeManager tradeList)
        {
            double nbrFinishedTrades = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.Finished)
                    nbrFinishedTrades++;
            }

            return nbrFinishedTrades;
        }

    }
}
