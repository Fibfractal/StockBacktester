using System;
using System.Collections.Generic;

namespace GraphProject
{
    /// <summary>
    /// This class calculates key numbers derrived from the trades made from the buy and sell signals from
    /// the algo. All numbers together builds the backtest, and reveals if it's profitable. 
    /// The following properties and methods are calulated; "ReturnSEK", "ReturnPercent",
    /// "Winners" in percent, "Average Gain" and "Average Loss", "Total Gain" and "Total Loss" from winning and losing trades,
    /// "ProfitFactor", "Cagr", "SharpRatio", "NumberOfWinners", "NumberOffinishedTrades", "StandardDeviation" ,"MaxDrawDown"
    /// and "PortFolioValue".
    /// </summary>
    public class Backtest
    {
        private string _ticker;

        // Portfolio values
        private double _portfolioValueStart;
        private double _portfolioValue;
        private double _valuePerPoint;
        private double _riskFreeRate = 0.0005 * 100; // Date 2019-11-11 , 10-year intrest

        // Portfolio max drawdown and that index (datetime), also new high
        private double _maxPortfolioValue;
        private double _currentMinPortfolioValue = Math.Pow(10, 9);
        private double _maxDrawDown = 0;
        private double _maxDrawDownPercent = 0;
        private double _previousMaxPortfolioDrawDown = 0;
        private bool _newHigh = false;
        private int _indexAtPreviousDrawDown = 0;
        private int _indexAtCurrentDrawDown = 0;
        private int _indexAtMaxDrawdown = 0;

        public Backtest(double portfolioValueStart, double valuePerpoint)
        {
            _portfolioValueStart = portfolioValueStart;
            _portfolioValue = portfolioValueStart;
            _valuePerPoint = valuePerpoint;
            _maxPortfolioValue = portfolioValueStart;
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

        public string Ticker
        {
            get { return _ticker; }
            set { _ticker = value; }
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
            get { return _maxDrawDownPercent; }
        }

        public double ReturnSek()
        {
            return _portfolioValue - _portfolioValueStart;
        }

        public double ReturnProcent()
        {
            return (_portfolioValue - _portfolioValueStart) / _portfolioValueStart * 100;
        }

        /// <summary>
        /// Portfolio value after a trade
        /// </summary>
        public double ChangePortFolValue(TradeManager tradeList, int index)
        {
            _portfolioValue += (tradeList.GetTradeList[index].ProfitTrade() / tradeList.GetTradeList[index].Sell) * _valuePerPoint;
            return _portfolioValue;
        }

        public double WinnersPercent(TradeManager tradeList)
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

            if (nbrFinishedTrades == 0)
                return 0;
            else
                return (nbrWinners / nbrFinishedTrades) * 100;
        }

        public int NbrOfWinners(TradeManager tradeList)
        {
            int nbrWinners = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() > 0 && item.Finished)
                    nbrWinners++;
            }
            return nbrWinners;
        }

        public double AverageGain(TradeManager tradeList)
        {
            double nbrWinners = 0;
            double totalGain = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() > 0 && item.Finished)
                {
                    totalGain += item.ProfitTrade() / item.Sell * _valuePerPoint;
                    nbrWinners++;
                }
            }

            if (nbrWinners == 0)
                return 0;
            else
                return totalGain / nbrWinners;

        }

        public double AverageLoss(TradeManager tradeList)
        {
            double nbrLosers = 0;
            double totalLoss = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.ProfitTrade() < 0 && item.Finished)
                {
                    totalLoss += item.ProfitTrade() / item.Sell * _valuePerPoint;
                    nbrLosers++;
                }
            }

            if (nbrLosers == 0)
                return 0;
            else
                return Math.Abs(totalLoss / nbrLosers);
        }

        public double TotalGain(TradeManager tradelist)
        {
            double totalGain = 0;

            foreach (var item in tradelist.GetTradeList)
            {
                if (item.ProfitTrade() > 0 && item.Finished)
                {
                    totalGain += item.ProfitTrade() / item.Sell * _valuePerPoint;
                }
            }

            return totalGain;
        }

        public double TotalLoss(TradeManager tradelist)
        {
            double totalLoss = 0;

            foreach (var item in tradelist.GetTradeList)
            {
                if (item.ProfitTrade() < 0 && item.Finished)
                {
                    totalLoss += item.ProfitTrade() / item.Sell * _valuePerPoint;
                }
            }

            return Math.Abs(totalLoss);
        }

        public int NumberOfFinishedTrades(TradeManager tradeList)
        {
            int nbrFinishedTrades = 0;

            foreach (var item in tradeList.GetTradeList)
            {
                if (item.Finished)
                    nbrFinishedTrades++;
            }
            return nbrFinishedTrades;
        }

        /// <summary>
        /// Calculates the total gain / total loss ratio.
        /// Depends on 4 cases, and the result will be presented depending on those.
        /// 1. If we have no trades, profit factor is 0.
        /// 2. If we only have winning trades profit factor gets capped to 100.
        /// 3. If we only have losingtrades profit factor is 0.
        /// 4. If we have both winning and losing trades, profit factor is calculated.
        /// </summary>
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

            if (lossLosingTrades == 0 && gainWinningTrades == 0)
                return 0;
            else if (lossLosingTrades == 0 && gainWinningTrades != 0)
                return 100;
            else if (lossLosingTrades != 0 && gainWinningTrades == 0)
                return 0;
            else
                return Math.Abs(gainWinningTrades / lossLosingTrades);
        }

        /// <summary>
        /// The average return per year in percent, compounding considered.
        /// </summary>
        public double Cagr(List<DailyDataPoint> pointList, DateTime startDate, DateTime endDate)
        {
            double nbrYears;
            nbrYears = (endDate - startDate).TotalDays / 365.2425;

            if (ReturnProcent() <= -100)
                return -100;
            else
                return (Math.Pow((1 + ReturnProcent() / 100), 1 / nbrYears) - 1) * 100;
        }

        /// <summary>
        /// One contract applied with a linear eq curve, no compounding effect.
        /// </summary>
        public double CagrAlternative(List<DailyDataPoint> pointList, DateTime startDate, DateTime endDate)
        {
            double nbrYears;
            nbrYears = (endDate - startDate).TotalDays / 365.2425;

            if (ReturnProcent() <= -100)
                return -100;
            else
                return ReturnProcent() / nbrYears;
        }

        /// <summary>
        /// A ratio, where the returns are risk adjusted.
        /// The result is presented depending on 5 cases.
        /// 1. We have a positive cagr, and only have one trade, the standard deviation is 0, bottom is 0. 
        /// 2. We have a negative cagr, and only have one trade, the standard deviation is 0, bottom is 0.
        /// 3. We have no trades.
        /// 4. We have a cagr less then -100 %, top is < - 100.
        /// 5. We have more then one trade and top > -100. The sharp ratio is calculated.
        /// </summary>
        public double SharpRatio(TradeManager tradeList, List<DailyDataPoint> pointList, DateTime startDate, DateTime endDate)
        {
            var top = Cagr(pointList, startDate, endDate) - _riskFreeRate;
            var bottom = StandardDeviation(tradeList) / _portfolioValueStart * 100;

            // If only one trade there is no variance and sharp ratio is useless, ie bottom is 0.
            if (top > 0 && bottom == 0)
                return 100;
            else if (top < 0 && bottom == 0)
                return -100;
            else if (NumberOfFinishedTrades(tradeList) == 0)
                return 0;
            else if (top <= -100)
                return -100;
            else
                return top / bottom;
        }

        /// <summary>
        /// Sharp ratio calculated depending an alternate cagr
        /// </summary>
        public double SharpRatioAlternative(TradeManager tradeList, List<DailyDataPoint> pointList, DateTime startDate, DateTime endDate)
        {
            var top = CagrAlternative(pointList, startDate, endDate) - _riskFreeRate;
            var bottom = StandardDeviation(tradeList) / _portfolioValueStart * 100;

            if (top > 0 && bottom == 0)
                return 100;
            else if (top < 0 && bottom == 0)
                return -100;
            else if (NumberOfFinishedTrades(tradeList) == 0)
                return 0;
            else if (top <= -100)
                return -100;
            else
                return top / bottom;
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

        /// <summary>
        /// Max draw down and the index (datetime) is saved.
        /// If price hits a new high then current drawdown is saved as previous drawdown, and new high flag is true and current drawdown index is saved as previous.
        /// If current drawdown is bigger when another high is hit , then previous is compared to current. The backtest always test current drawdown to
        /// the saved previous drawdown when test ends, and picks the largest one.
        /// </summary>
        public void MaxDrawDown(int index)
        {
            NewPortfolioHigh();
            CheckIndexAtCurrentDrawDown(index);
            MaxAndMinPortfolioValues();

            SetMaxDrawDown();
            SetIndexAtMaxDrawDown();
            SetMaxDrawDownPercent();
        }

        private void NewPortfolioHigh()
        {
            if (_portfolioValue > _maxPortfolioValue)
            {
                _newHigh = true;

                if (_maxPortfolioValue - _currentMinPortfolioValue > _previousMaxPortfolioDrawDown)
                    _indexAtPreviousDrawDown = _indexAtCurrentDrawDown;

                _previousMaxPortfolioDrawDown = Math.Max(_previousMaxPortfolioDrawDown, CurrentMaxPortfolioDrawdown());
                // When a new high is set, _currenMinPortfolioValue is set to default, a very low value
                _currentMinPortfolioValue = Math.Pow(10, 9);
            }
            else
                _newHigh = false;
        }

        private void CheckIndexAtCurrentDrawDown(int index)
        {
            if (_portfolioValue < _currentMinPortfolioValue)
                _indexAtCurrentDrawDown = index;
        }

        private void MaxAndMinPortfolioValues()
        {
            _maxPortfolioValue = Math.Max(_maxPortfolioValue, _portfolioValue);
            //When a new high is set _portfolioValue will always be _currentMinPortfolioValue
            _currentMinPortfolioValue = Math.Min(_currentMinPortfolioValue, _portfolioValue);
        }

        private void SetMaxDrawDown()
        {
            _maxDrawDown = (CurrentMaxPortfolioDrawdown() > _previousMaxPortfolioDrawDown) ? CurrentMaxPortfolioDrawdown() : _previousMaxPortfolioDrawDown;

        }

        private void SetIndexAtMaxDrawDown()
        {
            _indexAtMaxDrawdown = (CurrentMaxPortfolioDrawdown() > _previousMaxPortfolioDrawDown) ? _indexAtCurrentDrawDown : _indexAtPreviousDrawDown;

        }

        private void SetMaxDrawDownPercent()
        {
            _maxDrawDownPercent = _maxDrawDown / _portfolioValueStart * 100;
            // Maxdrawdown percent can only be max 100
            _maxDrawDownPercent = (_maxDrawDownPercent < 100) ? _maxDrawDownPercent : 100;
        }
        private double CurrentMaxPortfolioDrawdown()
        {
            return _maxPortfolioValue - _currentMinPortfolioValue;
        }

        public OneStockBackTestData GetOneStockBacktest(TradeManager _tradeManager, List<DailyDataPoint> _dataList, string algoName, string stockName, DateTime startDate, DateTime endDate)
        {
            var backTestData = new OneStockBackTestData();
            backTestData.AlgoName = algoName;
            backTestData.Ticker = stockName;
            backTestData.TimeSpanStart = startDate.ToShortDateString();
            backTestData.TimeSpanFinish = endDate.ToShortDateString();
            backTestData.PortfolioValueStart = PortfolioValueStart;
            backTestData.PortfolioValueFinish = PortfolioValue;
            backTestData.ReturnSek = ReturnSek();
            backTestData.ReturnProcent = ReturnProcent();
            backTestData.NumberOfFinishedTrades = NumberOfFinishedTrades(_tradeManager);
            backTestData.Winners = WinnersPercent(_tradeManager);
            backTestData.TotalGain = TotalGain(_tradeManager);
            backTestData.TotalLoss = TotalLoss(_tradeManager);
            backTestData.AverageGain = AverageGain(_tradeManager);
            backTestData.AverageLoss = AverageLoss(_tradeManager);
            backTestData.ProfitFactor = ProfitFactor(_tradeManager);
            backTestData.Cagr = Cagr(_dataList, startDate, endDate);
            backTestData.SharpRatio = SharpRatio(_tradeManager, _dataList, startDate, endDate);
            backTestData.MaxDrawDownPercent = MaxDrawDownProp;
            return backTestData;
        }

        public String TimespanStart(List<DailyDataPoint> pointList) => pointList[0].Date.ToShortDateString();
        public String TimespanFinish(List<DailyDataPoint> pointList) => pointList[pointList.Count - 1].Date.ToShortDateString();
    }
}
