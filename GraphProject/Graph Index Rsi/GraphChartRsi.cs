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
    public partial class GraphChartRsi : Form
    {
        // Sql import
        private ImportFromSql _import;

        // Index chart
        private TimeFrame _timeFrame;
        private CartesianMapper<DateModel> _dayConfig;

        // Indicator chart
        private RsiManager _lastAverage;
        private TimeFrame _timeFrame2;
        private CartesianMapper<DateModel> _dayConfig2;

        public GraphChartRsi()
        {
            InitializeComponent();
            _import = new ImportFromSql();
            _timeFrame = new TimeFrame();

            _lastAverage = new RsiManager();
            _timeFrame2 = new TimeFrame();

            UpdateGUI();
            ImportChartData();
        }

        private void UpdateGUI()
        {
            GuiIndex();
            GuiRsi();
        }

        private void GuiIndex()
        {
            _dayConfig = Mappers.Xy<DateModel>()
                        .X(dateModel => dateModel.DateTime.Ticks / (_timeFrame.Years()))
                        .Y(dateModel => dateModel.Value);

            // YearFormatter doesnt seem to work, spaces between years is not consistent
            // Works without it, and start year 1971
            cartesianChart1.AxisX.Add(_timeFrame.YearFormatter());
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString()
            });
        }

        private void GuiRsi()
        {
            _dayConfig2 = Mappers.Xy<DateModel>()
                          .X(dateModel => dateModel.DateTime.Ticks / (_timeFrame2.Years()))
                          .Y(dateModel => dateModel.Value);

            // YearFormatter doesnt seem to work, spaces between years is not consistent
            // Works without it, and start year 1971
            cartesianChart2.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Years"
            });
            cartesianChart2.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "RSI 14",
                LabelFormatter = value => value.ToString()
            });
        }

        private void ImportChartData()
        {
            var listOfData = _import.ImportData();
            ImportIndex(listOfData);
            ImportRsi(listOfData);
        }

        private void ImportIndex(List<DailyDataPoint> listOfData)
        {
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;

            var seriesCollection = new SeriesCollection(_dayConfig);
            var lineSeries = new LineSeries();
            var chartValues = new ChartValues<DateModel>();

            for (int i = 0; i < listOfData.Count; i++)
            {
                chartValues.Add(new DateModel());
                chartValues[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues[i].Value = listOfData[i]._Close;
            }

            lineSeries.PointGeometrySize = 1;
            lineSeries.Fill = Brushes.Transparent;
            lineSeries.Values = chartValues;
            seriesCollection.Add(lineSeries);

            cartesianChart1.Series = seriesCollection;

        }

        private void ImportRsi(List<DailyDataPoint> listOfData)
        {
            cartesianChart2.LegendLocation = LiveCharts.LegendLocation.Right;

            for (int i = 0; i < listOfData.Count; i++)
            {
                listOfData[i].RSI = (new RSI(listOfData, i, _lastAverage)).CalculateRsi();
            }

            var seriesCollection2 = new SeriesCollection(_dayConfig2);
            var lineSeries2 = new LineSeries();
            var lineSeries3 = new LineSeries();
            var lineSeries4 = new LineSeries();

            var chartValues2 = new ChartValues<DateModel>();
            var chartValues3 = new ChartValues<DateModel>();
            var chartValues4 = new ChartValues<DateModel>();

            for (int i = 0; i < listOfData.Count; i++)
            {

                chartValues2.Add(new DateModel());
                chartValues2[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues2[i].Value = listOfData[i].RSI;

                chartValues3.Add(new DateModel());
                chartValues3[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues3[i].Value = 70;

                chartValues4.Add(new DateModel());
                chartValues4[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues4[i].Value = 30;
            }

            lineSeries2.PointGeometrySize = 1;
            lineSeries2.Fill = Brushes.Transparent;
            lineSeries2.Stroke = Brushes.Red;
            lineSeries2.Values = chartValues2;
            lineSeries2.LineSmoothness = 0;

            lineSeries3.PointGeometrySize = 1;
            lineSeries3.Fill = Brushes.Transparent;
            lineSeries3.Stroke = Brushes.Black;
            lineSeries3.LineSmoothness = 0;
            lineSeries3.Values = chartValues3;
            //lineSeries3.StrokeDashArray = new System.Windows.Media.DoubleCollection(20);
            //lineSeries3.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69));

            lineSeries4.PointGeometrySize = 1;
            lineSeries4.Fill = Brushes.Transparent;
            lineSeries4.Stroke = Brushes.Black;
            lineSeries4.Values = chartValues4;
            lineSeries4.LineSmoothness = 0;
            //lineSeries4.StrokeDashArray = new System.Windows.Media.DoubleCollection(20);
            //lineSeries4.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69));

            seriesCollection2.Add(lineSeries2);
            seriesCollection2.Add(lineSeries3);
            seriesCollection2.Add(lineSeries4);

            cartesianChart2.Series = seriesCollection2;
        }

        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1971, 1, 1) + time;
            return date;
        }
    }
}
