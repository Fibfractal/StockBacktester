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

        public MovingAverage(List<DailyDataPoint> points, int index)
        {
            _points = points;
            _index = index;
        }

        public double CalculateMa()
        {
            if (_points.Count >= 200)
            {
                double nbr = _points[_index]._Close;

                if (_index >= 200)
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

            for (int i = _index - 200; i < _index; i++)
            {
                sum += _points[i]._Close;
            }

            return sum / 200;
        }

    }
}
