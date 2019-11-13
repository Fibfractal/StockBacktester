﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class RsiDummyAlgo //: IAlgos
    {
        private string _algoName = "Rsi dummy algo";
        private int _lenghtRsi = 14;

        public string AlgoName
        {
            get { return _algoName ; }
            set { _algoName = value; }
        }

        public bool AlgoBuy(List<DailyDataPoint> dataList, int index)
        {
            if(index > _lenghtRsi)
                return (dataList[index]._RSI < 30) ? true : false;

            return false;
        }

        public bool AlgoSell(List<DailyDataPoint> dataList, int index)
        {
            if (index > _lenghtRsi)
                return (dataList[index]._RSI > 70) ? true : false;

            return false;
        }
    }
}
