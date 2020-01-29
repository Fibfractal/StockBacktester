// Created by: Robert Nilsson
// When : 1 nov 2019
// Why : I wanted to create a stock backtesting program. And use it in my project portfolio. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    static class BacktestingProgram
    {
        /// <summary>
        /// This application backtests trading strategies for nasdaq100 stocks to see if they are
        /// profitable and robust. It updates stock data from an API and saves it to a SQL
        /// database, and gets the data from the database when backtesting.
        /// 
        /// You have to make your own algo classes (strategies), that match the
        /// structure of the premade algorithms, one buy signal and one sell signal.
        /// You also have to add the name of that algo in the Enum of algos and
        /// add it to the algopicker class. The library used to plot the trades in the
        /// graph, have limitations when plotting longer times series. Ten years will
        /// take about 7 minutes to plot, and thirty years 20 minutes. So the suggestion
        /// is to plot 2 years or less, and use it to see if your signals come where you want 
        /// them to come visualy using the indicators. You also have the option to turn the graph off 
        /// or on when testing one stock, all backtest calculations will appear directly, no lag.
        /// 
        /// The trades will apear in the stock graph and in the portfolio graph. The portfolio
        /// will also show new highs and maximum drawdown for it.
        /// The main purpose of the application is to be able to test a strategy on multiple stocks
        /// at the same time, and take averages of the keynumbers from the backtests. You can set
        /// tresholds for these keynumbers to see if the pass your overall criteria.
        /// You will find the tresholds in the MultipleBacktestDemand class.
        /// And get a PASS or FAIL scenario on the algoritm. There is are options to test and
        /// optimize your strategy on 70 % of the testdata, and after that test on 30 % OS (out of sample)
        /// data to see if its profitable. But you can test on all data aswell.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GraphStocks());
        }
    }
}
