using System.Collections.Generic;
using System.Linq;

namespace GraphProject
{
    /// <summary>
    /// This class analyses all backtests done from nasdaq 100, from a list of backtest
    /// when created an object of this class. Averages of key
    /// numbers from the list of backtest are calculated. All averages together
    /// gives a hint if the algo is profitable overall with good averages of 
    /// key numbers. If so then it's a robust algo.
    /// </summary>
    public class MultipleBacktestAnalyser
    {
        public MultipleBacktestAnalyser(List<OneStockBackTestData> _backTestList, string algoName)
        {
            _BackTestList = _backTestList;
            _AlgoName = algoName;
        }

        public string _AlgoName { get; set; }
        public List<OneStockBackTestData> _BackTestList { get; set; }
        public double _AveragePortfolioFinishValue { get; set; }
        public double _AverageReturnSek { get; set; }
        public double _AverageReturnPercent { get; set; }
        public double _AverageWinners { get; set; }
        public double _AverageCagr { get; set; }
        public double _AverageNumberOfTrades { get; set; }
        public int _TotalNumberOfTrades { get; set; }
        public double _AverageMaxDrawDown { get; set; }
        public double _AverageSharpRatio { get; set; }
        public double _AverageGainLoss { get; set; }
        public double _AverageAverageGainAverageLoss { get; set; }
        public double _PercentProfitableBackTests { get; set; }
        public double _PercentGoodSharpRatios { get; set; }
        public double _PercentSmallDrawDowns { get; set; }
        public double _PercentGoodProfitfactors { get; set; }
        public double _AverageProfitPerTrade { get; set; }

        public void CalculateAllAverageBackTestValues()
        {
            if (_BackTestList.Count > 0)
            {
                _AveragePortfolioFinishValue = AveragePortfolioFinishValue();
                _AverageReturnSek = AverageReturnSek();
                _AverageReturnPercent = AverageReturnPercent();
                _AverageWinners = AverageWinnersPercent();
                _AverageCagr = AverageCagr();
                _AverageNumberOfTrades = AverageNumberOfTrades();
                _TotalNumberOfTrades = TotalNumberOfTrades();
                _AverageMaxDrawDown = AverageMaxDrawDown();
                _AverageSharpRatio = AverageSharpRatio();
                _AverageGainLoss = AverageGainLoss();
                _AverageAverageGainAverageLoss = AverageAverageGainAverageLoss();
                _PercentProfitableBackTests = PercentProfitableBackTests();
                _PercentGoodSharpRatios = PercentGoodSharpRatios();
                _PercentSmallDrawDowns = PercentSmallDrawDowns();
                _PercentGoodProfitfactors = PercentGoodProfitfactors();
                _AverageProfitPerTrade = AverageProfitPerTrade();
            }
        }

        public double NumberOfActiveBacktest() => _BackTestList.Sum(x => x.NumberOfFinishedTrades > 0 ? 1 : 0);
        public double AveragePortfolioFinishValue() => _BackTestList.Sum(x => x.NumberOfFinishedTrades > 0 ? x.PortfolioValueFinish : 0) / NumberOfActiveBacktest();
        public double AverageReturnSek() => _BackTestList.Sum(x => x.ReturnSek) / NumberOfActiveBacktest();
        public double AverageReturnPercent() => _BackTestList.Sum(x => x.ReturnProcent) / NumberOfActiveBacktest();
        public double AverageWinnersPercent() => _BackTestList.Sum(x => x.Winners) / NumberOfActiveBacktest();
        public double AverageCagr() => _BackTestList.Sum(x => x.Cagr) / NumberOfActiveBacktest();
        public double AverageNumberOfTrades() => _BackTestList.Sum(x => x.NumberOfFinishedTrades) / NumberOfActiveBacktest();
        public int TotalNumberOfTrades() => _BackTestList.Sum(x => x.NumberOfFinishedTrades);
        public double AverageMaxDrawDown() => _BackTestList.Sum(x => x.MaxDrawDownPercent) / NumberOfActiveBacktest();


        public double AverageSharpRatio() => _BackTestList.Sum(x => x.NumberOfFinishedTrades > 0 ? x.SharpTop : 0.0) / _BackTestList.Sum(x => x.NumberOfFinishedTrades > 0 ? x.SharpBottom : 0.0);
        // Does not work when there is no losses or wins, get Inf or NaN --> 100 or 0 in one backtest. Not good to average later.
        // Use this as another ref when all backtests contain wins and losses.
        public double AverageSharpRatio2() => _BackTestList.Sum(x => x.SharpRatio) / _BackTestList.Count();

        public double AverageGainLoss() => _BackTestList.Sum(x => x.TotalGain) / _BackTestList.Sum(x => x.TotalLoss);
        // Does not work when there is no losses or wins, get Inf or NaN --> 100 or 0 in one backtest. Not good to average later.
        // Use this as another ref when all backtests contain wins and losses.
        public double AverageGainLoss2() => _BackTestList.Sum(x => x.ProfitFactor) / _BackTestList.Count();

        public double AverageAverageGainAverageLoss() => _BackTestList.Sum(x => x.AverageGain) / _BackTestList.Sum(x => x.AverageLoss);
        // Does not work when there is no losses or wins, get Inf or NaN
        public double AverageAverageGainAverageLoss2() => _BackTestList.Sum(x => (x.AverageGain / x.AverageLoss)) / _BackTestList.Count();


        public double PercentProfitableBackTests() => _BackTestList.Sum(x => x.ReturnSek > 0 ? 1 : 0) / NumberOfActiveBacktest() * 100;

        public double PercentGoodSharpRatios() => _BackTestList.Sum(x => x.SharpRatio > 0.8 ? 1 : 0) / NumberOfActiveBacktest() * 100;

        public double PercentSmallDrawDowns() => _BackTestList.Sum(x => x.MaxDrawDownPercent < 25 && x.NumberOfFinishedTrades > 0 ? 1 : 0) / NumberOfActiveBacktest() * 100;
        public double PercentGoodProfitfactors() => _BackTestList.Sum(x => x.ProfitFactor > 2 ? 1 : 0) / NumberOfActiveBacktest() * 100;

        public double AverageProfitPerTrade() => _BackTestList.Sum(x => x.ReturnProcent) / _TotalNumberOfTrades;

        public override string ToString()
        {
            if (_BackTestList.Count() > 0)
            {
                return string.Format("{0,-21} {1,-14:N1} {2,-15:N1} {3,-14:N0} {4,-17:N1} {5,-13:N2} {6,-14:N2} {7,-18:N2} {8,-18:N1} {9,-15:N1} {10,-20:N1} {11,-18:N1}",
                _AlgoName,
                _AverageReturnPercent,
                _AverageWinners,
                _TotalNumberOfTrades,
                _AverageMaxDrawDown,
                _AverageProfitPerTrade,
                _AverageGainLoss,
                _AverageAverageGainAverageLoss,
                _PercentProfitableBackTests,
                _PercentGoodSharpRatios,
                _PercentSmallDrawDowns,
                _PercentGoodProfitfactors
                );
            }
            else
                return "There were no backtests";
        }
    }
}
