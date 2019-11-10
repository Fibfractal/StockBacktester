using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class RsiDummyAlgo //: IAlgos
    {
        private string _algoName = "Rsi dummy algo";

        public string AlgoName
        {
            get { return _algoName ; }
            set { _algoName = value; }
        }

        public bool AlgoBuy(List<DailyDataPoint> dataList, int index)
        {
            return (dataList[index]._RSI < 30) ? true : false;
        }

        public bool AlgoSell(List<DailyDataPoint> dataList, int index)
        {
            return (dataList[index]._RSI > 70) ? true : false;
        }
    }
}
