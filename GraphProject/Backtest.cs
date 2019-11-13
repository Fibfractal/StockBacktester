using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    public class Backtest
    {
        // Portfolio values
        private double _portfolioValueStart;
        private double _portfolioValue ;
        private double _valuePerPoint;
        private double _riskFreeRate = 0.05 * 100; // 2019-11-11 ,10-åringen

        // Portfolio max drawdown size and timepoint, also new high
        private double _max;
        private double _min = Math.Pow(10, 9);
        private double _maxDrawDown = 0;
        private double _maxDrawDownPercent = 0;
        private double _previousMaxDrawDown = 0;
        private double _currentDrawDown = 0;
        private bool _newHigh = false;
        private int _indexAtPreviousDrawDown = 0;
        private int _indexAtCurrentDrawDown = 0;
        private int _indexAtMaxDrawdown = 0;

        public Backtest(double portfolioValueStart, double valuePerpoint)
        {
            _portfolioValueStart = portfolioValueStart;
            _portfolioValue = portfolioValueStart;
            _valuePerPoint = valuePerpoint;
            _max = portfolioValueStart;
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

        public bool Newhigh
        {
            get { return _newHigh; }
        }

        public int IndexAtMaxDrawDown
        {
            get { return _indexAtMaxDrawdown; }
        }

        public double MaxDrawDownProp
        {
            get { return _maxDrawDownPercent ; }
        }

        public double ReturnSek()
        {
            return _portfolioValue - _portfolioValueStart;
        }

        public double ReturnProcent()
        {
            return (_portfolioValue - _portfolioValueStart) / _portfolioValueStart * 100;
        }

        // Portfoliovalue after that trade
        public double ChangePortFolValue(TradeManager tradeList, int index)
        {
            _portfolioValue += (tradeList.GetTradeList[index].ProfitTrade() / tradeList.GetTradeList[index].Sell) * _valuePerPoint;
            return _portfolioValue;
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

        // One contract applied with a linear eq curve, 100 000 kr initial. No ränta på ränta effekt.
        public double CagrAlternative(List<DailyDataPoint> pointList)
        {
            double nbrYears;
            nbrYears = (TimeTranslation(pointList[pointList.Count - 1]._MilliSeconds) - TimeTranslation(pointList[0]._MilliSeconds)).TotalDays / 365.2425;

            return ReturnProcent() / nbrYears; 
        }

        public double SharpRatio(TradeManager tradeList, List<DailyDataPoint> pointList)
        {
            return (CagrAlternative(pointList) - _riskFreeRate) / (StandardDeviation(tradeList) / _portfolioValueStart * 100);
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

        // If price hits a new high then current drawdown is saved a previous drawdown, and new high flag is true and current drawdown index is saved as previous.
        // If current drawdown is bigger when another high is hit , then previous is compared to current. The backtest always test current drawdown to
        // the saved previous drawdown when test ends, and picks the largest one.
        public void MaxDrawDown(int index)
        {
            if (_portfolioValue > _max)
            {
                _newHigh = true;

                if (_max - _min > _previousMaxDrawDown)
                    _indexAtPreviousDrawDown = _indexAtCurrentDrawDown;

                _previousMaxDrawDown = Math.Max(_previousMaxDrawDown, _max - _min);
                _min = Math.Pow(10, 9);
            }
            else
                _newHigh = false;

            if (_portfolioValue < _min)
                _indexAtCurrentDrawDown = index;

            _max = Math.Max(_max, _portfolioValue);
            _min = Math.Min(_min, _portfolioValue);
            _currentDrawDown = Math.Max(_currentDrawDown, _max - _min);

            _maxDrawDown = (_currentDrawDown > _previousMaxDrawDown) ? _currentDrawDown : _previousMaxDrawDown;
            _indexAtMaxDrawdown = (_currentDrawDown > _previousMaxDrawDown) ? _indexAtCurrentDrawDown : _indexAtPreviousDrawDown;

            _maxDrawDownPercent = _maxDrawDown / _portfolioValueStart * 100;
            _maxDrawDownPercent = (_maxDrawDownPercent < 100) ? _maxDrawDownPercent : 100;
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

        // 1970 is the correct start year, but due to problem to fit the labels on the x-axel in sync with data
        // 1971 is chosen above with a work around to fix the problem.
        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1970, 1, 1) + time;
            return date;
        }
    }
}
