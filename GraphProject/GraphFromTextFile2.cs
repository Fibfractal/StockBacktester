using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GraphProject
{
    public partial class GraphFromTextFile2 : Form
    {
        private ImportFromTextFile _dataTextFile;

        public GraphFromTextFile2()
        {
            InitializeComponent();
            _dataTextFile = new ImportFromTextFile();
            UpdateGUI(_dataTextFile);
        }

        private void UpdateGUI(ImportFromTextFile dataTextFile)
        {
            /*
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Years",
                Labels = new[]
                   { "1970","1971","1972","1973","1974","1975","1976","1977","1978","1979",
                  "1980","1981","1982","1983","1984","1985","1986","1987","1988","1989",
                  "1990","1991","1992","1993","1994","1995","1996","1997","1998","1999",
                  "2000","2001","2002","2003","2004","2005","2006","2007","2008","2009",
                  "2010","2011","2012","2013","2014","2015","2016","2017","2018","2019",
                }

            });

            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
            */

            var listOfData = dataTextFile.ImportData();


            // Init data
            //cartesianChart1.Series.Clear();

            var seriesCollection = new SeriesCollection();
            var lineSeries = new LineSeries();
            var chartValues = new ChartValues<ObservablePoint>();// { new ObservablePoint(1, 10), new ObservablePoint(2, 20), new ObservablePoint(3, 5) };

            /*
            foreach (var item in listOfData)
            {
                chartValues.Add(new ObservablePoint(TimeTranslation(item.MilliSeconds), item.Close));
            }*/

            for (int i = 0; i < 2000; i++)
            {
                chartValues.Add(new ObservablePoint(TimeTranslation(listOfData[i].MilliSeconds), listOfData[i].Close));
            }
            

            /*
            chartValues.Add(new ObservablePoint(1, 10));
            chartValues.Add(new ObservablePoint(2, 15));
            chartValues.Add(new ObservablePoint(3, 5));
            */

            lineSeries.PointGeometrySize = 1;
            
            lineSeries.Values = chartValues;
            seriesCollection.Add(lineSeries);

            cartesianChart1.Series = seriesCollection;
        }

        private double TimeTranslation(double ticks)
        {
            //double ticks = double.Parse(timeMs);
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            double time2 = time.TotalDays - 14442;
            DateTime date = new DateTime(1970, 1, 1) + time;
            //double nbrDays = date.Total
            return time2;
        }
    }
}
