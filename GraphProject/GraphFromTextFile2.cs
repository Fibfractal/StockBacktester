using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphProject.Graph_Textfile;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;

namespace GraphProject
{
    public partial class GraphFromTextFile2 : Form
    {
        private ImportFromTextFile _dataTextFile;
        private TimeFrame _timeFrame;

        public GraphFromTextFile2()
        {
            InitializeComponent();
            _dataTextFile = new ImportFromTextFile();
            _timeFrame = new TimeFrame();
            UpdateGUI(_dataTextFile);
        }

        private void UpdateGUI(ImportFromTextFile dataTextFile)
        {
            var dayConfig = Mappers.Xy<DateModel>()
              .X(dateModel => dateModel.DateTime.Ticks / (_timeFrame.Years()))
              .Y(dateModel => dateModel.Value);

            cartesianChart1.AxisX.Add(_timeFrame.YearFormatter());
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString()
            });

            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;

            var listOfData = dataTextFile.ImportData();
            var seriesCollection = new SeriesCollection(dayConfig);
            var lineSeries = new LineSeries();
            var chartValues = new ChartValues<DateModel>();

            for (int i = 0; i < listOfData.Count; i++)
            {
                chartValues.Add(new DateModel());
                chartValues[i].DateTime = TimeTranslation(listOfData[i].MilliSeconds);
                chartValues[i].Value = listOfData[i].Close;
            }

            lineSeries.PointGeometrySize = 1;
            lineSeries.Fill = Brushes.Transparent;
            lineSeries.Values = chartValues;
            seriesCollection.Add(lineSeries);

            cartesianChart1.Series = seriesCollection;
        }

        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1970, 1, 1) + time;
            return date;
        }
    }
}
