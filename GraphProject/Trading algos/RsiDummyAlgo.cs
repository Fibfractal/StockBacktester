using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class gives buy and sell signals from an algo.
    /// It buys when RSI of a lenght, is below 30. And sells
    /// when it's above 70.
    /// </summary>
    public class RsiDummyAlgo 
    {
        private string _algoName = "Rsi dummy algo";
        private int _lenghtRsi = 5;

        public string AlgoName
        {
            get { return _algoName ; }
            set { _algoName = value; }
        }

        public bool AlgoBuy(List<DailyDataPoint> dataList, int index)
        {
            if(index > _lenghtRsi)
                return (dataList[index].RSI < 30) ? true : false;

            return false;
        }

        public bool AlgoSell(List<DailyDataPoint> dataList, int index)
        {
            if (index > _lenghtRsi)
                return (dataList[index].RSI > 70) ? true : false;

            return false;
        }
    }
}
