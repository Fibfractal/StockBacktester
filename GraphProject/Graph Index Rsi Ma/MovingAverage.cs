using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public class MovingAverage
    {
        private int _index;
        private List<DailyDataPoint> _points;
        private int _lenghtMa;

        public MovingAverage(List<DailyDataPoint> points, int index, int lenghtMA)
        {
            _points = points;
            _index = index;
            _lenghtMa = lenghtMA;
        }


        public int LengthMA
        {
            get { return _lenghtMa; }
        }

        public double CalculateMa()
        {
            if (_points.Count >= _lenghtMa)
            {
                double nbr = _points[_index]._Close;

                if (_index >= _lenghtMa)
                {
                    nbr = MaFormula();
                }
                return nbr;
            }
            else
            {
                return _points[_index]._Close;
            }
        }

        private double MaFormula()
        {
            double sum = 0;

            for (int i = _index - _lenghtMa; i < _index; i++)
            {
                sum += _points[i]._Close;
            }

            return sum / _lenghtMa;
        }

    }
}
