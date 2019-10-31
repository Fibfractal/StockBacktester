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
    public partial class GraphFromSql : Form
    {
        private ExportToSql _export;
        private ImportFromSql _import;
        private TimeFrame _timeFrame;
        private CartesianMapper<DateModel> _dayConfig;

        public GraphFromSql()
        {
            InitializeComponent();
            _export = new ExportToSql();
            _import = new ImportFromSql();
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
            cartesianChart1.AxisX.Add(_timeFrame.YearFormatter());
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString()
            });
        }

        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1971, 1, 1) + time;
            return date;
        }

        private void btn_ExportData_Click(object sender, EventArgs e)
        {
            _export.ExportData();
        }

        private void btn_ImportSql_Click(object sender, EventArgs e)
        {
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;

            var listOfData = _import.ImportData();
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
    }
}
