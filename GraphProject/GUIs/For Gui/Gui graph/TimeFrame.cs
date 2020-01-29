using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GraphProject
{
    /// <summary>
    /// This class is used to format the x-axels period  when plotting a chart.
    /// The only timeframe used at this moment is Years.
    /// </summary>
    public class TimeFrame 
    {
        private Axis _axis = new Axis();

        public double FifteenMinutes() => TimeSpan.FromMinutes(15).Ticks;
        public double Hours() => TimeSpan.FromHours(1).Ticks;
        public double Days() => TimeSpan.FromDays(1).Ticks;
        public double Months() => TimeSpan.FromDays(1).Ticks * 30.44;
        public double Years() => TimeSpan.FromDays(1).Ticks * 365.2425;

        public Axis FifteenMinFormatter() 
        {
            _axis.Title = "Minutes";
            _axis.LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromMinutes(15).Ticks)).ToString("t");
            return _axis;
        } 

        public Axis HourFormatter()
        {
            _axis.Title = "Hours";
            _axis.LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");
            return _axis;
        }

        public Axis DayFormatter()
        {
            _axis.Title = "Days";
            _axis.LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d");
            return _axis;
        }

        public Axis MonthFormatter()
        {
            _axis.Title = "Months";
            _axis.LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("M"); ;
            return _axis;
        }

        public Axis YearFormatter()
        {
            _axis.Title = "Years";
            return _axis;
        }
    }
}
