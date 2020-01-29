using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    /// <summary>
    /// This class manages the start and end dates picked in graph GUI.
    /// The dates must follow som rules.
    /// 1. The initial standard start and end dates are set, when Gui is loaded.
    /// 2. Date picked in Gui can't be on a saturday or a sunday. Else standard dates i chosen.
    /// 3. The start date must be before the end date. Else standard dates i chosen.
    /// 4. Start and end dates must be within the date range of thats stock data. Else start date is the first date, and end date is the last.
    /// 6. There must be enough stock data so the standard start date can be chosen, else start date is the first date.
    /// </summary>
    public class DatePickerManager
    {
        private List<DailyDataPoint> _dataList;
        private int _nbrDaysBefore = 60;

        public DatePickerManager(List<DailyDataPoint> dataList)
        {
            _dataList = dataList;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartDateIndex { get; set; }
        public int EndDateIndex { get; set; }

        public void VerifyDates()
        {
            CheckChangeDates();
            InformAboutDates();

            var datesOk = VerifyDataListLenght() && VerifyDateOrder() && VerifyStartDate() && VerifyEndDate() && 
               FindIndexStartDate() && FindIndexEndDate();

            if (!datesOk)
                MessageBox.Show("Verification of dates failed!");
        }

        /// <summary>
        /// If the choice of dates is not valid the first and the last
        /// dates are chosen, as start and end dates.
        /// </summary>
        private void CheckChangeDates()
        {
            if (!VerifyStartDate())
                StartDate = _dataList[0].Date;
            if (!VerifyEndDate())
                EndDate = _dataList[_dataList.Count() - 1].Date;
        }

        private void InformAboutDates()
        {
            if (!VerifyDataListLenght())
                MessageBox.Show("There is no data for this stock!");
            if (!VerifyDateOrder())
            {
                MessageBox.Show("Start date must be before end date!");
                CorrectDateOrder();
            }
        }

        /// <summary>
        /// The standard start date is preselected, and nbr of days before end date
        /// is chosen to be the start date. That date have to be verified so there
        /// is enough data in the price list, to be able to be picked.
        /// </summary>
        public DateTime StandardStartDate()
        {
            if (!VerifyStandardStartDate())
                return StartDate = _dataList[0].Date;
            else
                return StartDate = _dataList[_dataList.Count() - 1 - _nbrDaysBefore].Date;
        }

        /// <summary>
        /// The preselected end date is always the last date in the price list.
        /// </summary>
        public DateTime StandardEndDate() => _dataList[_dataList.Count() - 1].Date;

        /// <summary>
        ///  When a start date is chosen, the corresponding index (for that date) in the price list must be found.
        /// </summary>
        public bool FindIndexStartDate()
        {
            var startIndex = 0;
            bool foundIndex = false;
            for (int i = 0; i < _dataList.Count; i++)
            {
                if(_dataList[i].Date == StartDate)
                {
                    startIndex = i;
                    foundIndex = true;
                }
            }
            if (!foundIndex)
                MessageBox.Show("Did not find matching start dates and it's index!");

            StartDateIndex = startIndex;
            return foundIndex;
        }

        /// <summary>
        ///  When a end date is chosen, the corresponding index (for that date) in the price list must be found.
        /// </summary>
        public bool FindIndexEndDate()
        {
            var endIndex = _dataList.Count - 1;
            bool foundIndex = false;
            for (int i = 0; i < _dataList.Count; i++)
            {
                if (_dataList[i].Date == EndDate)
                {
                    endIndex = i;
                    foundIndex = true;
                }
            }
            if (!foundIndex)
                MessageBox.Show("Did not find matching end dates and it's index!");

            EndDateIndex = endIndex;
            return foundIndex;
        }

        /// <summary>
        /// When a date is picked in a Gui, it can not be a saturday or sunday.
        /// </summary>
        /// <returns></returns>
        public bool PickCorrectDayAndDate()
        {
            if (StartDate.DayOfWeek == System.DayOfWeek.Saturday)
            {
                MessageBox.Show("You can't pick a Saturday as start date!");
                StartDate = StandardStartDate();
                return false;
            }
            else if (StartDate.DayOfWeek == System.DayOfWeek.Sunday)
            {
                MessageBox.Show("You can't pick a Sunday as start date!");
                StartDate = StandardStartDate();
                return false;
            }

            if (EndDate.DayOfWeek == System.DayOfWeek.Saturday)
            {
                MessageBox.Show("You can't pick a Saturday as end date!");
                EndDate = StandardEndDate();
                return false;
            }
            else if (EndDate.DayOfWeek == System.DayOfWeek.Sunday)
            {
                MessageBox.Show("You can't pick a Sunday as end date!");
                EndDate = StandardEndDate();
                return false;
            }
            return true;
        }

        private bool VerifyDataListLenght() => _dataList.Count() > 0 ? true : false;
        private bool VerifyDateOrder() => (EndDate - StartDate).TotalDays > 0 ? true : false;
        private void CorrectDateOrder()
        {
            if (!VerifyDateOrder())
            {
                StartDate = StandardStartDate();
                EndDate = StandardEndDate();
            }
        }
        private bool VerifyStartDate() => (StartDate - _dataList[0].Date).TotalDays >= 0 ? true : false;
        private bool VerifyEndDate() => (_dataList[_dataList.Count() - 1].Date - EndDate).TotalDays >= 0 ? true : false;
        private bool VerifyStandardStartDate() => _dataList.Count()  > _nbrDaysBefore ? true : false;
    }
}
