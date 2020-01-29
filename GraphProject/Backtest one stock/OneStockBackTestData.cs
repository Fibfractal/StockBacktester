using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class contains all properties of a backtest of one stock.
    /// </summary>
    public class OneStockBackTestData
    {
        public string AlgoName { get; set; }
        public string Ticker { get; set; }
        public string TimeSpanStart { get; set; }
        public string TimeSpanFinish { get; set; }
        public double PortfolioValueStart { get; set; }
        public double PortfolioValueFinish { get; set; }
        public double ReturnSek { get; set; }
        public double ReturnProcent { get; set; }
        public int NumberOfFinishedTrades { get; set; }
        public double Winners { get; set; }
        public double TotalGain { get; set; }
        public double TotalLoss { get; set; }
        public double AverageGain { get; set; }
        public double AverageLoss { get; set; }
        public double ProfitFactor { get; set; }
        public double Cagr { get; set; }
        public double SharpRatio { get; set; }
        public double SharpTop { get; set; }
        public double SharpBottom { get; set; }
        public double MaxDrawDownPercent { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -19} {1,-8} {2,-14} {3,-16} {4,-14:N0} {5,-14:N0} {6,-14:N0} {7,-12:N1} {8,-10:N0} {9,-10:N1} {10,-12:N0} {11,-12:N0} {12,-10:N1} {13,-10:N1} {14,-10:N2} {15,-10:N1}",
                AlgoName,
                Ticker,
                TimeSpanStart,
                TimeSpanFinish,
                PortfolioValueStart,
                PortfolioValueFinish,
                ReturnSek,
                ReturnProcent,
                NumberOfFinishedTrades,
                Winners,
                AverageGain,
                AverageLoss,
                ProfitFactor,
                Cagr,
                SharpRatio,
                MaxDrawDownPercent
                );
        }
    }
}
