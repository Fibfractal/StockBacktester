using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class gives buy and sell signals from an algo.
    /// It buys when MA200 is mostly declining during the period and when the price does a 100 day high.
    /// And it sells after X number of days.
    /// </summary>
    public class NegMaImpuls 
    {
        private string _algoName = "NegMaImpuls";
        private int _sellAfterDays = 60;
        private int _lenghtMa = 200;
        private int _index;
        private int _nbrDays = 0;
        private double _declineDays = 200;
        private double _percentDecline = 0.8;
        private List<DailyDataPoint> _dataList;
        private TradeManager _tradeManager;

        public NegMaImpuls(List<DailyDataPoint> dataList, int index, TradeManager tradeManager)
        {
            _dataList = dataList;
            _index = index;
            _tradeManager = tradeManager;
        }

        public int GetNbrDays() => _nbrDays;

        public string AlgoName
        {
            get { return _algoName; }
            set { _algoName = value; }
        }

        public bool AlgoBuy()
        {
            if (FallingMa200() && New100DayHigh())
                return true;

            return false;
        }
        
        public bool AlgoSell(int nbrDays)
        {
            if (SellAfterDays(_sellAfterDays, nbrDays))
                return true;

            return false;
        }
        
        private bool FallingMa200()
        {
            bool declineOk = false;
            int counter = 0;

            if (_index > _lenghtMa)
            {
                for (int i = 0; i < _declineDays; i++)
                {
                    if ((_dataList[_index - i].MA200 < _dataList[_index - i - 1].MA200))
                        counter++;
                }

                if((counter/_declineDays) > _percentDecline)
                    declineOk = true;
            }

            return declineOk;
        }

        private bool New100DayHigh()
        {
            double highestPrice = 0;
            int listLenght = _dataList.Count;

            if (_index > 99)
            {
                for (int i = _index - 99; i < _index; i++)
                {
                    highestPrice = Math.Max(highestPrice, _dataList[i - 1].Close);
                }

                return _dataList[_index].Close > highestPrice ? true : false;
            }
            else
                return false;
        }

        private bool SellAfterDays(int exitdays, int nbrDays)
        {

            if (_tradeManager.UnFinishedTrade())
            {
                nbrDays++;
                _nbrDays += nbrDays;
            }

            if (_nbrDays == exitdays)
            {
                _nbrDays = 0;
                return true;
            }
            else
                return false;
        }
    }
}
