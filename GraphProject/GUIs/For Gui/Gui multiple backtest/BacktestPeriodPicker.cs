using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    /// <summary>
    /// This class handles the result from the multiple backtest Gui.
    /// The chosen backtest period from the Gui, is translated to a 
    /// start and end indexes for backtest to be tested.
    /// </summary>
    public class BacktestPeriodPicker
    {
        private List<DailyDataPoint> _dataList;

        public BacktestPeriodPicker(List<DailyDataPoint> dataList)
        {
            _dataList = dataList;
        }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public void PickIndexesForPeriod(int cbxIndex)
        {
            switch (cbxIndex)
            {
                case 0:
                    PeriodAllData();
                    break;
                case 1:
                    PeriodTestSample(0.70);
                    break;
                case 2:
                    PeriodOutOfSample(0.30);
                    break;
            }
        }

        private void PeriodAllData()
        {
            StartIndex = 0;
            EndIndex = _dataList.Count - 1;
        }

        private void PeriodTestSample(double periodFraction)
        {
            int nbr;
            StartIndex = 0;
            EndIndex = _dataList.Count - 1;

            if (periodFraction > 0.0 && periodFraction < 1.0)
            {
                // Casted downward ex.  0.9 to 0
                nbr = (int)(_dataList.Count * periodFraction);

                EndIndex = nbr;

                double treshold = 1.0 / _dataList.Count;

                if (nbr < treshold)
                    MessageBox.Show(string.Format("Cant pick that small fraction with this little data! Pick {0} or bigger!", treshold));

            }
            else
                MessageBox.Show("Fraction needs to be > 0.0 and < 1.0!");
        }

        private void PeriodOutOfSample(double periodFraction)
        {
            int nbr;
            StartIndex = 0;
            EndIndex = _dataList.Count - 1;

            if (periodFraction > 0.0 && periodFraction < 1.0)
            {
                // Casted downward ex.  0.9 to 0
                nbr = (int)(_dataList.Count * periodFraction);
                double treshold = 1.0 / _dataList.Count;

                if (nbr > 0)
                    StartIndex = _dataList.Count - nbr;
                else
                    MessageBox.Show(string.Format("Cant pick that small fraction with this little data! Pick bigger than {0}!", treshold));
            }
            else
                MessageBox.Show("Fraction needs to be > 0.0 and < 1.0!");

        }

        public DateTime GetStartDate()
        {
            return _dataList[StartIndex].Date;
        }

        public DateTime GetEndDate()
        {
            return _dataList[EndIndex].Date;
        }
    }
}
