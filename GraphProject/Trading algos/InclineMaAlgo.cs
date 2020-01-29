using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class gives buy and sell signals from an algo.
    /// This algo buys when price is below a RSI treshold and above a MA and when
    /// MA is pointing up. It sells when price is above a RSI treshold and below a MA.
    /// </summary>
    public class InclineMaAlgo
    {
        private string _algoName = "InclineMaAlgo";
        private int _lenghtRsi = 5;
        private int _lenghtMa = 200;
        private List<DailyDataPoint> _dataList;
        private int _index;

        public InclineMaAlgo(List<DailyDataPoint> dataList, int index)
        {
            _dataList = dataList;
            _index = index;
        }

        public string AlgoName
        {
            get { return _algoName; }
            set { _algoName = value; }
        }

        // --------- BUY PARTS -----------

        // RSI
        private bool AlgoBuy1()
        {
            if (_index > _lenghtRsi)
                return (_dataList[_index].RSI < 30) ? true : false;

            return false;
        }

        // MA
        private bool AlgoBuy2()
        {
            bool inclineOk = false;
            bool closeOverMA = false;

            if (_dataList[_index].Close > _dataList[_index].MA200)
                closeOverMA = true;

            if (_index > _lenghtMa)
            {
                for (int i = 0; i < 2; i++)
                {
                    if ((_dataList[_index - i].MA200 > _dataList[_index - i - 1].MA200))
                        inclineOk = true;
                }
            }

            return inclineOk && closeOverMA; 
        }

        // --------- SELL PARTS -----------

        // RSI
        private bool AlgoSell1()
        {
            if (_index > _lenghtRsi)
                return (_dataList[_index].RSI > 70) ? true : false;

            return false;
        }

        // MA
        private bool AlgoSell2()
        {
            if (_index > _lenghtMa)
                return (_dataList[_index].MA50 < _dataList[_index - 1].MA50) ? true : false;

            return false;
        }

        // --------- Combined buy and sell parts ---------

        // BUY
        public bool AlgoBuy()
        {
            if (AlgoBuy1() && AlgoBuy2())
                return true;

            return false;
        }

        // SELL
        public bool AlgoSell()
        {
            if (AlgoSell1())
                return true;

            return false;
        }
    }
}

