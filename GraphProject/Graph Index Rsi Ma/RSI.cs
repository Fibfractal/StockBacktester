using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class RSI
    {
        private int _index;
        private List<DailyDataPoint> _points;
        private List<double> _advance ;
        private List<double> _decline;
        private RsiManager _lastAverage;
        private int _lenghtRsi;

        public RSI(List<DailyDataPoint> points, int index, RsiManager lastAverage, int lengthRsi)
        {
            _points = points;
            _index = index;
            _advance = new List<double>();
            _decline = new List<double>();
            _lastAverage = lastAverage;
            _lenghtRsi = lengthRsi;
        }

        public double CalculateRsi()
        {
            if (_points.Count >= _lenghtRsi + 1)
            {
                double nbr = 50;

                if (_index > _lenghtRsi)
                {
                    nbr =  rsiFormula(SmoothedRS());
                }
                else if (_index == _lenghtRsi)
                {
                    CalcAdvanceOrDecline();
                    nbr =  rsiFormula(FirstRS());
                }
                return nbr;
            }
            else
            {
                return 0;
            }
        }

        private void CalcAdvanceOrDecline()
        {
            for (int i = _index - _lenghtRsi; i < _index; i++)
            {
                double diff = _points[i + 1]._Close - _points[i]._Close;

                if (diff > 0)
                {
                    _advance.Add(diff);
                }
                else if (diff < 0)
                {
                    _decline.Add(diff);
                }
            }
            _lastAverage.LastAverageGain = Average(_advance);
            _lastAverage.LastAverageLoss = Average(_decline);
        }

        private double SmoothedRS()
        {
            double todaysGain = 0;
            double todaysLoss = 0;

            double todaysDiff = _points[_index]._Close - _points[_index - 1]._Close;

            if (todaysDiff > 0)
            {
                todaysGain = todaysDiff;
            }
            else if (todaysDiff < 0)
            {
                todaysLoss = Math.Abs(todaysDiff);
            }

            var advanceAverageYesterDay = (_lastAverage.LastAverageGain * (_lenghtRsi-1) + todaysGain) / _lenghtRsi;
            var declineAverageYesterDay = (_lastAverage.LastAverageLoss * (_lenghtRsi-1) + todaysLoss) / _lenghtRsi;

            _lastAverage.LastAverageGain = advanceAverageYesterDay;
            _lastAverage.LastAverageLoss = declineAverageYesterDay;

            return (advanceAverageYesterDay / declineAverageYesterDay);
        }

        private double FirstRS()
        {
            return Average(_advance) / Average(_decline);
        }

        private double Average(List<double> list)
        {
            return Math.Abs(list.Sum() / _lenghtRsi);
        }

        private double rsiFormula(double rsValue)
        {
            return (100 - (100 / (1 + rsValue)));
        }
    }
}
