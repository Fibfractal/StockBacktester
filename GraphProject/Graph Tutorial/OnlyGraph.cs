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
    public partial class OnlyGraph : Form
    {
        public OnlyGraph()
        {
            InitializeComponent();
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
        }
    }
}
