using System.Collections.Generic;

namespace GraphProject
{
    /// <summary>
    /// This class calculates a moving average of a price and a 
    /// selected lenght. The moving average can be used as an indicator
    /// for creating trading strategies.
    /// </summary>
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
                double nbr = _points[_index].Close;

                if (_index >= _lenghtMa)
                {
                    nbr = MaFormula();
                }
                return nbr;
            }
            else
                return _points[_index].Close;
        }

        private double MaFormula()
        {
            double sum = 0;

            for (int i = _index - _lenghtMa; i < _index; i++)
            {
                sum += _points[i].Close;
            }

            return sum / _lenghtMa;
        }
    }
}
