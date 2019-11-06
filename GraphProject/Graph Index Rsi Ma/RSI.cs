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

        public RSI(List<DailyDataPoint> points, int index, RsiManager lastAverage)
        {
            _points = points;
            _index = index;
            _advance = new List<double>();
            _decline = new List<double>();
            _lastAverage = lastAverage;
        }

        public double CalculateRsi()
        {
            if (_points.Count >= 15)
            {
                double nbr = 50;

                if (_index > 14)
                {
                    nbr =  rsiFormula(SmoothedRS());
                }
                else if (_index == 14)
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
            for (int i = _index - 14; i < _index; i++)
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

            var advanceAverageYesterDay = (_lastAverage.LastAverageGain * 13 + todaysGain) / 14;
            var declineAverageYesterDay = (_lastAverage.LastAverageLoss * 13 + todaysLoss) / 14;

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
            return Math.Abs(list.Sum() / 14);
        }

        private double rsiFormula(double rsValue)
        {
            return (100 - (100 / (1 + rsValue)));
        }
    }
}
