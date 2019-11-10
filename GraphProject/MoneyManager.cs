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

        public double AverageGain(TradeManager tradeList)
        {
            double gainWinningTrades = 0;
            double nbrWinners = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() > 0 && item.Finished)
                {
                    gainWinningTrades += item.ProfitTrade() / item.Sell * _valuePerPoint;
                    nbrWinners++;
                }
            }
            return gainWinningTrades / nbrWinners;
        }

        public double AverageLoss(TradeManager tradeList)
        {
            double lossLosingTrades = 0;
            double nbrLosers = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() < 0 && item.Finished)
                {
                    lossLosingTrades += item.ProfitTrade() / item.Sell * _valuePerPoint;
                    nbrLosers++;
                }
            }
            return Math.Abs(lossLosingTrades / nbrLosers);
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

        public double ProfitFactor(TradeManager tradeList)
        {
            double lossLosingTrades = 0;
            double gainWinningTrades = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() > 0 && item.Finished)
                {
                    gainWinningTrades += item.ProfitTrade() / item.Sell * _valuePerPoint;
                }
                else if (item.ProfitTrade() < 0 && item.Finished)
                {
                    lossLosingTrades += item.ProfitTrade() / item.Sell * _valuePerPoint;
                }
            }
            return Math.Abs(gainWinningTrades / lossLosingTrades);
        }

        public double Cagr(List<DailyDataPoint> pointList)
        {
            double nbrYears;
            nbrYears = (TimeTranslation(pointList[pointList.Count - 1]._MilliSeconds) - TimeTranslation(pointList[0]._MilliSeconds)).TotalDays / 365.2425;

            return ( Math.Pow((1 + ReturnProcent() / 100), 1/nbrYears) - 1 ) * 100;
        }

        public String TimespanStart(List<DailyDataPoint> pointList)
        {
            return TimeTranslation(pointList[0]._MilliSeconds).ToShortDateString() + " - ";
        }

        public String TimespanFinish(List<DailyDataPoint> pointList)
        {
            return TimeTranslation(pointList[pointList.Count - 1]._MilliSeconds).ToShortDateString();
        }

        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1970, 1, 1) + time;
            return date;
        }
    }
}
