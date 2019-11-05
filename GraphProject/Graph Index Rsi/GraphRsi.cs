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
    public partial class GraphRsi : Form
    {
        private ImportFromSql _import;
        private RsiManager _lastAverage;
        private TimeFrame _timeFrame;
        private CartesianMapper<DateModel> _dayConfig;

        public GraphRsi()
        {
            InitializeComponent();
            _import = new ImportFromSql();
            _lastAverage = new RsiManager();
            _timeFrame = new TimeFrame();
            UpdateGUI();
        }

        private void UpdateGUI()
        {

            _dayConfig = Mappers.Xy<DateModel>()
              .X(dateModel => dateModel.DateTime.Ticks / (_timeFrame.Years()))
              .Y(dateModel => dateModel.Value);

            // YearFormatter doesnt seem to work, spaces between years is not consistent
            // Works without it, and start year 1971
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Year"
            }); 
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "RSI 14",
                LabelFormatter = value => value.ToString()
            });
        }

        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1971, 1, 1) + time;
            return date;
        }

        private void btn_ImportRSI_Click(object sender, EventArgs e)
        {
            var listOfData = _import.ImportData();

            for ( int i = 0; i < listOfData.Count; i++)
            {
                listOfData[i]._RSI = (new RSI(listOfData, i, _lastAverage)).CalculateRsi();
            }

            //lbx_RSI.Items.AddRange(listOfData.ConvertAll(x => x.ToString()).ToArray()); 


            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;

            var seriesCollection = new SeriesCollection(_dayConfig);
            var lineSeries = new LineSeries();
            var chartValues = new ChartValues<DateModel>();

            for (int i = 0; i < listOfData.Count; i++)
            {
                chartValues.Add(new DateModel());
                chartValues[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues[i].Value = listOfData[i]._RSI;
            }

            lineSeries.PointGeometrySize = 1;
            //((LineSeries)ABValuesSC[0]).Fill = Brushes.Aqua; //change fill of first series
            lineSeries.Fill = Brushes.Transparent;
            lineSeries.Stroke = Brushes.Red;
            lineSeries.Values = chartValues;
            seriesCollection.Add(lineSeries);

            cartesianChart1.Series = seriesCollection;

        }
    }
}
