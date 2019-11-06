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
        private List<DailyDataPoint> _dataList;

        // Index chart
        private TimeFrame _timeFrame;
        private CartesianMapper<DateModel> _dayConfig;

        // RSI Indicator chart
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
            try
            {
                _dataList = _import.ImportData();
                _import.VerifyData(_dataList);

                if (!_import.VerifyData(_dataList))
                    MessageBox.Show("Import of sql stock data is not complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Import of sql stock data failed!");
            }
            
            for (int i = 0; i < _dataList.Count; i++)
            {
                _dataList[i]._RSI = (new RSI(_dataList, i, _lastAverage)).CalculateRsi();
            }

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

            cartesianChart1.AxisX[0].Separator.StrokeThickness = 0;
            cartesianChart1.AxisY[0].Separator.StrokeThickness = 0;
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
            }) ;
            cartesianChart2.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "RSI 14",
                LabelFormatter = value => value.ToString()
            });

            cartesianChart2.AxisX[0].Separator.StrokeThickness = 0;
            cartesianChart2.AxisY[0].Separator.StrokeThickness = 0;
        }

        private void ImportChartData()
        {
            ImportIndexAndMa(_dataList);
            ImportRsi(_dataList);
        }

        private void ImportIndexAndMa(List<DailyDataPoint> listOfData)
        {
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.None;

            for (int i = 0; i < listOfData.Count; i++)
            {
                listOfData[i]._MA = (new MovingAverage(listOfData, i)).CalculateMa();
            }

            var seriesCollection = new SeriesCollection(_dayConfig);
            var lineSeries = new LineSeries();
            var lineSeries5 = new LineSeries();
            var lineSeries6 = new LineSeries();
            var lineSeries7 = new LineSeries();

            var chartValues = new ChartValues<DateModel>();
            var chartValues5 = new ChartValues<DateModel>();
            var chartValues6 = new ChartValues<DateModel>();
            var chartValues7 = new ChartValues<DateModel>();

            for (int i = 0; i < listOfData.Count; i++)
            {
                chartValues.Add(new DateModel());
                chartValues[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues[i].Value = listOfData[i]._Close;

                if (i >= 200)
                {
                    chartValues5.Add(new DateModel());
                    chartValues5[i-200].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                    chartValues5[i-200].Value = listOfData[i]._MA;
                }

                if (listOfData[i]._RSI < 30)
                {
                    chartValues6.Add(new DateModel());
                    var length = chartValues6.Count();
                    chartValues6[length - 1].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                    chartValues6[length - 1].Value = listOfData[i]._Close;
                }

                if (listOfData[i]._RSI > 70)
                {
                    chartValues7.Add(new DateModel());
                    var length = chartValues7.Count();
                    chartValues7[length - 1].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                    chartValues7[length - 1].Value = listOfData[i]._Close;
                }
            }

            // OMX 30
            lineSeries.PointGeometrySize = 1;
            lineSeries.Fill = Brushes.Transparent;
            lineSeries.Stroke = Brushes.Blue;
            lineSeries.Values = chartValues;

            // Ma 200
            lineSeries5.PointGeometrySize = 1;
            lineSeries5.Fill = Brushes.Transparent;
            lineSeries5.Stroke = Brushes.Yellow;
            lineSeries5.Values = chartValues5;
            cartesianChart1.Background = Brushes.Black;

            // Rsi < 30
            lineSeries6.PointGeometrySize = 3;
            lineSeries6.Fill = Brushes.Transparent;
            lineSeries6.PointForeground = Brushes.White;
            lineSeries6.Values = chartValues6;
            lineSeries6.StrokeThickness = 0;

            // Rsi > 70
            lineSeries7.PointGeometrySize = 3;
            lineSeries7.Fill = Brushes.Transparent;
            lineSeries7.PointForeground = Brushes.Red;
            lineSeries7.Values = chartValues7;
            lineSeries7.StrokeThickness = 0;

            seriesCollection.Add(lineSeries5);
            seriesCollection.Add(lineSeries);
            seriesCollection.Add(lineSeries6);
            seriesCollection.Add(lineSeries7);

            cartesianChart1.Series = seriesCollection;
        }

        private void ImportRsi(List<DailyDataPoint> listOfData)
        {
            cartesianChart2.LegendLocation = LiveCharts.LegendLocation.None;

            var seriesCollection2 = new SeriesCollection(_dayConfig2);
            var lineSeries2 = new LineSeries();
            var lineSeries3 = new LineSeries();
            var lineSeries4 = new LineSeries();

            var chartValues2 = new ChartValues<DateModel>();
            var chartValues3 = new ChartValues<DateModel>();
            var chartValues4 = new ChartValues<DateModel>();

            for (int i = 0; i < listOfData.Count; i++)
            {
                if (i >= 14)
                {
                    chartValues2.Add(new DateModel());
                    chartValues2[i - 14].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                    chartValues2[i - 14].Value = listOfData[i]._RSI;
                }

                chartValues3.Add(new DateModel());
                chartValues3[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues3[i].Value = 70;

                chartValues4.Add(new DateModel());
                chartValues4[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues4[i].Value = 30;
            }

            lineSeries2.PointGeometrySize = 1;
            lineSeries2.Fill = Brushes.Transparent;
            lineSeries2.Stroke = Brushes.Yellow;
            lineSeries2.Values = chartValues2;
            lineSeries2.LineSmoothness = 0;

            lineSeries3.PointGeometrySize = 1;
            lineSeries3.Fill = Brushes.Transparent;
            lineSeries3.Stroke = Brushes.Blue;
            lineSeries3.LineSmoothness = 0;
            lineSeries3.Values = chartValues3;

            lineSeries4.PointGeometrySize = 1;
            lineSeries4.Fill = Brushes.Transparent;
            lineSeries4.Stroke = Brushes.Blue;
            lineSeries4.Values = chartValues4;
            lineSeries4.LineSmoothness = 0;

            seriesCollection2.Add(lineSeries2);
            seriesCollection2.Add(lineSeries3);
            seriesCollection2.Add(lineSeries4);

            cartesianChart2.Background = Brushes.Black;
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
