using System;
using System.Collections.Generic;

namespace GraphProject
{
    public class BollingerBands
    {
        private int _index;
        private List<DailyDataPoint> _dataList;
        private int _lenghtMa;

        public BollingerBands(List<DailyDataPoint> dataList, int index, int lenghtMA)
        {
            _dataList = dataList;
            _index = index;
            _lenghtMa = lenghtMA;
        }

        private double CalculateMa()
        {
            if (_dataList.Count >= _lenghtMa)
            {
                double nbr = _dataList[_index].Close;

                if (_index >= _lenghtMa)
                {
                    nbr = MaFormula();
                }
                return nbr;
            }
            else
            {
                return _dataList[_index].Close;
            }
        }

        private double MaFormula()
        {
            double sum = 0;

            for (int i = _index - _lenghtMa; i < _index; i++)
            {
                sum += _dataList[i].Close;
            }

            return sum / _lenghtMa;
        }


        private double StandardDeviation()
        {
            double sumSquaredDevFromMean = 0;

            if (_index > _lenghtMa)
            {
                for (int i = _index - _lenghtMa; i < _index; i++)
                {
                    sumSquaredDevFromMean += Math.Pow(_dataList[i].Close - CalculateMa(), 2);
                }
            }

            return Math.Sqrt(sumSquaredDevFromMean / _lenghtMa);
        }

        public double UpperBollingerBand() => CalculateMa() + 2 * StandardDeviation();
        public double LowerBollingerBand() => CalculateMa() - 2 * StandardDeviation();
    }
}
