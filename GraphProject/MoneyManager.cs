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
        private double _riskFreeRate = 0.05 * 100; // 2019-11-11 ,10-åringen

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

        // Portfoliovalue after that trade
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

        // If position only works on same amount of money, 100 000 kr initial. No ränta på ränta effekt, linear return curve.
        public double CagrAlternative(List<DailyDataPoint> pointList)
        {
            double nbrYears;
            nbrYears = (TimeTranslation(pointList[pointList.Count - 1]._MilliSeconds) - TimeTranslation(pointList[0]._MilliSeconds)).TotalDays / 365.2425;

            return ReturnProcent() / nbrYears; 
        }

        public double SharpRatio(TradeManager tradeList, List<DailyDataPoint> pointList)
        {
            return ((CagrAlternative(pointList) - _riskFreeRate) / (StandardDeviation(tradeList) / _portfolioValueStart * 100) );
        }

        public double StandardDeviation(TradeManager tradeList)
        {
            double sumSquaredDevFromMean = 0;
            foreach (var item in tradeList.GetTradeList)
            {
                sumSquaredDevFromMean += Math.Pow(item.ProfitTrade() / item.Sell * _valuePerPoint - AverageProfit(tradeList), 2);
            }

            return Math.Sqrt(sumSquaredDevFromMean / tradeList.NbrFinishedTrades());
        }

        public double AverageProfit(TradeManager tradeList)
        {
            double sumProfitInSek = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                sumProfitInSek += item.ProfitTrade() / item.Sell * _valuePerPoint;
            }

            return sumProfitInSek / tradeList.NbrFinishedTrades();
        }

        public String TimespanStart(List<DailyDataPoint> pointList)
        {
            TimeSpan oneYear = new DateTime(2019, 01, 01) - new DateTime(2018, 01, 01);
            TimeSpan add = TimeSpan.FromMilliseconds(pointList[0]._MilliSeconds) - oneYear;
            DateTime date = new DateTime(1971, 1, 1) + add;
            return date.ToShortDateString() + " - ";
        }

        public String TimespanFinish(List<DailyDataPoint> pointList)
        {
            TimeSpan oneYear = new DateTime(2019, 01, 01) - new DateTime(2018, 01, 01);
            TimeSpan add = TimeSpan.FromMilliseconds(pointList[pointList.Count - 1]._MilliSeconds) - oneYear;
            DateTime date = new DateTime(1971, 1, 1) + add;
            return date.ToShortDateString();
        }

        // 1970 är det korrekta, men får inte till x-axeln, tvingas kompensera
        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1970, 1, 1) + time;
            return date;
        }
    }
}
