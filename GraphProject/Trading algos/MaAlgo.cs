using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class gives buy and sell signals from an algo.
    /// It buys when the price is above a MA and when other MA is
    /// pointning up. It sells when price is below a MA.
    /// </summary>
    public class MaAlgo 
    {
        private string _algoName = "MaAlgo";
        private int _lenghtMa = 200;
        private List<DailyDataPoint> _dataList;
        int _index;

        public MaAlgo(List<DailyDataPoint> dataList, int index)
        {
            _dataList = dataList;
            _index = index;
        }

        public string AlgoName
        {
            get { return _algoName; }
            set { _algoName = value; }
        }

        public bool AlgoBuy()
        {
            bool inclineOk = false;
            bool closeOverMA = false;

            if (_dataList[_index].Close > _dataList[_index].MA50)
                closeOverMA = true;

            if (_index > _lenghtMa)
            {
                for (int i = 0; i < 4; i++)
                {
                    if ((_dataList[_index - i].MA20 > _dataList[_index - i - 1].MA20))
                        inclineOk = true;
                }
            }

            return inclineOk && closeOverMA; 
        }

        public bool AlgoSell()
        {
            bool closeOverMA = false;

            if (_dataList[_index].Close < _dataList[_index].MA50)
                closeOverMA = true;


            return closeOverMA;
        }
    }
}
