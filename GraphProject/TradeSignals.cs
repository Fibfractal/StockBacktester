using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class TradeSignals
    {
        private readonly IAlgos _algo;
        private readonly List<DailyDataPoint> _dataList;
        private readonly int _index;
        private bool _tradeOn = false;

        public TradeSignals(IAlgos algo, List<DailyDataPoint> dataList, int index)
        {
            _algo = algo;
            _dataList = dataList;
            _index = index;
        }

        public bool TradeOn { get => _tradeOn; }

        public bool BuySignal()
        {
            if(_algo.AlgoBuy(_dataList, _index))
                _tradeOn = true;

            return _algo.AlgoBuy(_dataList,_index);
        }
        public bool SellSignal()
        {
            if (_algo.AlgoSell(_dataList,_index))
                _tradeOn = false;

            return _algo.AlgoBuy(_dataList,_index);
        }


    }
}
