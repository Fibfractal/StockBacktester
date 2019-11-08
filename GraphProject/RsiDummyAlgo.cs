using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class RsiDummyAlgo //: IAlgos
    {
        public bool AlgoBuy(List<DailyDataPoint> dataList, int index)
        {
            return (dataList[index]._RSI < 30) ? true : false;
        }

        public bool AlgoSell(List<DailyDataPoint> dataList, int index)
        {
            return (dataList[index]._RSI > 50) ? true : false;
        }
    }
}
