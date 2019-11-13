using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    class MaAlgo
    {
        private string _algoName = "MA incline / decline algo";
        private int _lenghtMa = 50;

        public string AlgoName
        {
            get { return _algoName; }
            set { _algoName = value; }
        }

        public bool AlgoBuy(List<DailyDataPoint> dataList, int index)
        {
            if(index > _lenghtMa)
            return (dataList[index]._MA2 > dataList[index - 1]._MA2) ? true : false;

            return false;
        }

        public bool AlgoSell(List<DailyDataPoint> dataList, int index)
        {
            if(index > _lenghtMa)
            return (dataList[index]._MA2 < dataList[index - 1]._MA2) ? true : false;

            return false;
        }
    }
}
