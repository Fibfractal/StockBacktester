using System.Collections.Generic;

namespace GraphProject
{
    /// <summary>
    /// This class will pick one algo depending on which algo string name
    /// is sent to the class. And then see if that algo has a buy or a sell signal.
    /// </summary>
    public class AlgoPicker
    {
        private List<DailyDataPoint> _dataList;
        private int _index;
        private string _nameOfAlgo;
        private TradeManager _tradeManager;
        private int _nbrDays = 0;

        public AlgoPicker(List<DailyDataPoint> dataList, string nameOFAlgo, TradeManager tradeManager)
        {
            _dataList = dataList;
            _nameOfAlgo = nameOFAlgo;
            _tradeManager = tradeManager;
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        // Add new algos when the are created.
        // But if you can solve the problem of creating an object from a class named the same as the algo , 
        // direct from string algo name, so you dont have to add if else every time.

        /// <summary>
        /// If add a new algo, do the following steps:
        /// 1. Create a new class as an algo 
        /// 2. Add same class name in the enum table
        /// 3. Add the algo in the algo picker below
        /// </summary>
        public bool PickAlgoBuy()
        {
            if (_nameOfAlgo == "InclineMaAlgo")
            {
                return new InclineMaAlgo(_dataList, _index).AlgoBuy();
            }
            else if (_nameOfAlgo == "MaAlgo")
            {
                return new MaAlgo(_dataList, _index).AlgoBuy();
            }
            else if (_nameOfAlgo == "NegMaImpuls")
            {
                return new NegMaImpuls(_dataList, _index, _tradeManager).AlgoBuy();
            }
            else if (_nameOfAlgo == "LowVolBB")
            {
                return new LowVolBB(_dataList, _index).AlgoBuy();
            }
            else
            {
                return false;
            }
        }

        public bool PickAlgoSell()
        {
            if (_nameOfAlgo == "InclineMaAlgo")
            {
                return new InclineMaAlgo(_dataList, _index).AlgoSell();
            }
            else if (_nameOfAlgo == "MaAlgo")
            {
                return new MaAlgo(_dataList, _index).AlgoSell();
            }
            else if (_nameOfAlgo == "NegMaImpuls")
            {
                var sell = new NegMaImpuls(_dataList, _index, _tradeManager);
                var sellOk = sell.AlgoSell(_nbrDays);
                _nbrDays = sell.GetNbrDays();

                return sellOk;
            }
            else if (_nameOfAlgo == "LowVolBB")
            {
                return new LowVolBB(_dataList, _index).AlgoSell();
            }
            else
            {
                return false;
            }
        }
    }
}
