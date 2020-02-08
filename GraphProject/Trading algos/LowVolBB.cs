using System.Collections.Generic;

namespace GraphProject
{
    public class LowVolBB
    {
        private string _algoName = "LowVolBB";
        private int _lenghtMa200 = 200;
        private int _lenghtMa20 = 20;
        private List<DailyDataPoint> _dataList;
        int _index;

        public LowVolBB(List<DailyDataPoint> dataList, int index)
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
            bool MA20OverBB200 = false;

            if (_index > _lenghtMa200)
            {
                if (_dataList[_index].MA20 > _dataList[_index].UpperBollingerBand)
                    MA20OverBB200 = true;
            }

            return MA20OverBB200;
        }

        public bool AlgoSell()
        {
            bool closeUnderBB = false;

            if (_index > _lenghtMa20)
            {
                if (_dataList[_index].MA20 < _dataList[_index].UpperBollingerBand)
                    closeUnderBB = true;
            }

            return closeUnderBB;
        }
    }
}
