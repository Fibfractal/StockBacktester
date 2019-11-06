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
    public partial class OnlyGraph : Form
    {
        private TimeFrame _timeFrame;
        private CartesianMapper<DateModel> _dayConfig;

        public OnlyGraph()
        {
            InitializeComponent();

            // Alt 2
            _timeFrame = new TimeFrame();

            _dayConfig = Mappers.Xy<DateModel>()
            .X(dateModel => dateModel.DateTime.Ticks / (_timeFrame.Days()))
            .Y(dateModel => dateModel.Value);

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Time",
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d")
            });
            
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => value.ToString()
            });

            var seriesCollection = new SeriesCollection(_dayConfig);

            var lineSeries = new LineSeries();
            var lineSeries2 = new LineSeries();
            var chartValues = new ChartValues<DateModel>();
            var chartValues2 = new ChartValues<DateModel>();

            var dateModel1 = new DateModel { DateTime = new DateTime(2017, 1, 18), Value = 10 };
            var dateModel2 = new DateModel { DateTime = new DateTime(2017, 1, 22), Value = 15 };
            var dateModel3 = new DateModel { DateTime = new DateTime(2017, 1, 18), Value = 20 };
            var dateModel4 = new DateModel { DateTime = new DateTime(2017, 1, 22), Value = 5 };

            chartValues.Add(dateModel1);
            chartValues.Add(dateModel2);
            chartValues2.Add(dateModel3);
            chartValues2.Add(dateModel4);

            lineSeries.Values = chartValues;
            lineSeries2.Values = chartValues2;

            lineSeries.PointForeground = Brushes.Black;
            lineSeries2.PointForeground = Brushes.Red;

            seriesCollection.Add(lineSeries);
            seriesCollection.Add(lineSeries2);

            cartesianChart1.Series = seriesCollection;


            // Nedan fungerar även med att skapa flera objekt med new och ta det i en annan ordning
            // , ska du använda Mapper måste det lösas med alt 2.

            // Alt 1
            /*
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(1,1),
                        new ObservablePoint(2,2),
                        new ObservablePoint(3,3),
                        new ObservablePoint(4,2),
                        new ObservablePoint(5,5)
                    },
                    PointGeometrySize = 3
                },

                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(1,-1),
                        new ObservablePoint(2,-4),
                        new ObservablePoint(3,-2),
                        new ObservablePoint(4,-3),
                        new ObservablePoint(5,-6)
                    },
                    PointGeometrySize = 3
                }

            };
            */


        }
    }
}
