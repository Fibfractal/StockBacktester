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

        // Trade
        //private TradeSignal _tradeSignal;
        private TradeManager _tradeManager;
        private MoneyManager _moneyManager;
        private RsiDummyAlgo _rsiDummyAlgo;

        public GraphChartRsi()
        {
            InitializeComponent();
            InitializeAttributes();
            ImportData();
            GUI();
            ChartData();
        }

        private void InitializeAttributes()
        {
            _import = new ImportFromSql();
            _timeFrame = new TimeFrame();

            _lastAverage = new RsiManager();
            _timeFrame2 = new TimeFrame();

            _tradeManager = new TradeManager();
            _moneyManager = new MoneyManager(100000, 250000);
        }

        private void ImportData()
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
                MessageBox.Show(ex.Message, "Import of sql stock data failed!");
            }
        }

        private void GUI()
        {
            GuiAxelsIndex();
            GuiAxelsPortfolio();
        }

        private void GuiAxelsIndex()
        {
            _dayConfig = Mappers.Xy<DateModel>()
                        .X(dateModel => dateModel.DateTime.Ticks / (_timeFrame.Years()))
                        .Y(dateModel => Math.Log(dateModel.Value, 10));

            // YearFormatter doesnt seem to work, spaces between years is not consistent
            // Works without it, and start year 1971
            cartesianChart1.AxisX.Add(_timeFrame.YearFormatter());
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => Math.Pow(10, value).ToString("N0")
            });

            cartesianChart1.AxisX[0].Separator.StrokeThickness = 0;
            cartesianChart1.AxisY[0].Separator.StrokeThickness = 0;
        }

        private void GuiAxelsPortfolio()
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
                Title = "Portfolio (SEK)",
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart2.AxisX[0].Separator.StrokeThickness = 0;
            cartesianChart2.AxisY[0].Separator.StrokeThickness = 0;
        }

        private void ChartData()
        {
            CalcAndPlotAlgosAndIndicators(_dataList);
            PortfolioAndBacktest(_dataList);
        }

        private void CalcAndPlotAlgosAndIndicators(List<DailyDataPoint> listOfData)
        {
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.None;

            // Create series to plot
            var seriesCollection = new SeriesCollection(_dayConfig);
            var lineSeries = new LineSeries();
            var lineSeries5 = new LineSeries();
            var lineSeries6 = new LineSeries();
            var lineSeries7 = new LineSeries();

            var chartValues = new ChartValues<DateModel>();
            var chartValues5 = new ChartValues<DateModel>();
            var chartValues6 = new ChartValues<DateModel>();
            var chartValues7 = new ChartValues<DateModel>();

            // Create algo for backtest signals
            _rsiDummyAlgo = new RsiDummyAlgo();

            // Go through index data from database
            for (int i = 0; i < listOfData.Count; i++)
            {
                // Calculate Rsi and Ma
                listOfData[i]._RSI = (new RSI(listOfData, i, _lastAverage)).CalculateRsi();
                listOfData[i]._MA = (new MovingAverage(listOfData, i)).CalculateMa();

                // Plot close values at datetime in graph
                chartValues.Add(new DateModel());
                chartValues[i].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                chartValues[i].Value = listOfData[i]._Close;

                // Plot MA200 in graph at datetime
                if (i >= 200)
                {
                    chartValues5.Add(new DateModel());
                    chartValues5[i - 200].DateTime = TimeTranslation(listOfData[i]._MilliSeconds);
                    chartValues5[i - 200].Value = listOfData[i]._MA;
                }

                // Plot algo buy signals in graph and save trade
                if (_rsiDummyAlgo.AlgoBuy(listOfData,i))
                {
                    if (_tradeManager.AddNewTradeOk())
                    {
                        _tradeManager.AddTrade(new OneTrade { Buy = listOfData[i+1]._Open, BuyDate = TimeTranslation(listOfData[i+1]._MilliSeconds) });

                        chartValues6.Add(new DateModel());
                        var length = chartValues6.Count();
                        chartValues6[length - 1].DateTime = TimeTranslation(listOfData[i+1]._MilliSeconds);
                        chartValues6[length - 1].Value = listOfData[i+1]._Open;
                    }
                }

                // Plot algo sell signals in graph and save trade
                if (_rsiDummyAlgo.AlgoSell(listOfData, i))
                {
                    if (_tradeManager.UnFinishedTrade())
                    {
                        _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].Sell = listOfData[i+1]._Open;
                        _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].SellDate = TimeTranslation(listOfData[i+1]._MilliSeconds);

                        chartValues7.Add(new DateModel());
                        var length = chartValues7.Count();
                        chartValues7[length - 1].DateTime = TimeTranslation(listOfData[i+1]._MilliSeconds);
                        chartValues7[length - 1].Value = listOfData[i+1]._Open;
                    }
                }
            }

            // OMXSPI 
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

            // Entries
            lineSeries6.PointGeometrySize = 5;
            lineSeries6.Fill = Brushes.Transparent;
            lineSeries6.PointForeground = Brushes.White;
            lineSeries6.Values = chartValues6;
            lineSeries6.StrokeThickness = 0;

            // Exits
            lineSeries7.PointGeometrySize = 5;
            lineSeries7.Fill = Brushes.Transparent;
            lineSeries7.PointForeground = Brushes.Red;
            lineSeries7.Values = chartValues7;
            lineSeries7.StrokeThickness = 0;

            // Add collections to series for plotting
            seriesCollection.Add(lineSeries5);
            seriesCollection.Add(lineSeries);
            seriesCollection.Add(lineSeries6);
            seriesCollection.Add(lineSeries7);

            cartesianChart1.Series = seriesCollection;
        }

        private void PortfolioAndBacktest(List<DailyDataPoint> listOfData)
        {
            cartesianChart2.LegendLocation = LiveCharts.LegendLocation.None;

            var seriesCollection2 = new SeriesCollection(_dayConfig2);
            var lineSeries2 = new LineSeries();
            var chartValues2 = new ChartValues<DateModel>();

            // Start value for portfolio
            chartValues2.Add(new DateModel());
            chartValues2[0].DateTime = TimeTranslation(_dataList[0]._MilliSeconds);
            chartValues2[0].Value = 100000;

            for (int i = 0; i < _tradeManager.GetTradeList.Count; i++)
            {
                if (_tradeManager.GetTradeList[i].Finished)
                {
                    chartValues2.Add(new DateModel());
                    chartValues2[i + 1].DateTime = _tradeManager.GetTradeList[i].SellDate;
                    chartValues2[i + 1].Value = _moneyManager.ChangePortFolValue(_tradeManager, i);
                }
            }

            // End value for portfolio
            chartValues2.Add(new DateModel());
            chartValues2[chartValues2.Count - 1].DateTime = TimeTranslation(_dataList[_dataList.Count - 1]._MilliSeconds);
            chartValues2[chartValues2.Count - 1].Value = _moneyManager.PortfolioValue;

            lineSeries2.PointGeometrySize = 5;
            //lineSeries2.Fill = Brushes.Yellow;
            lineSeries2.Stroke = Brushes.Yellow;
            lineSeries2.Values = chartValues2;
            lineSeries2.LineSmoothness = 0;
            lineSeries2.StrokeThickness = 1;
            lineSeries2.PointForeground = Brushes.Red;
            seriesCollection2.Add(lineSeries2);

            cartesianChart2.Background = Brushes.Black;
            cartesianChart2.Series = seriesCollection2;

            BacktestData();
        }

        private void BacktestData()
        {
            lbl_ValuePortfolio_Start.Text = string.Format("{0:N0}", _moneyManager.PortfolioValueStart);
            lbl_Value_Portfolio_End.Text = string.Format("{0:N0}", _moneyManager.PortfolioValue);
            lbl_Value_Return_Sek.Text = string.Format("{0:N0}", _moneyManager.ReturnSek());
            lbl_Value_Return_Procent.Text = string.Format("{0:N0}", _moneyManager.ReturnProcent());
            lbl_Value_Nbr_Trades.Text = string.Format("{0:N0}", _moneyManager.NumberOfFinishedTrades(_tradeManager));
            lbl_Value_Winners_Procent.Text = string.Format("{0:N0}", _moneyManager.Winners(_tradeManager));
            lbl_Value_Avg_Gain.Text = string.Format("{0:N0}", _moneyManager.AverageGain(_tradeManager));
            lbl_Value_Avg_Loss.Text = string.Format("{0:N0}", _moneyManager.AverageLoss(_tradeManager));
            lbl_Value_Profit_Factor.Text = string.Format("{0:N1}", _moneyManager.ProfitFactor(_tradeManager));
            lbl_Value_CAGR.Text = string.Format("{0:N1}", _moneyManager.CagrAlternative(_dataList));
            lbl_Value_TimeSpan_Start.Text = _moneyManager.TimespanStart(_dataList);
            lbl_Value_TimeSpan_Finish.Text = _moneyManager.TimespanFinish(_dataList);
            lbl_Value_Name_Algo.Text = _rsiDummyAlgo.AlgoName;
            lbl_Value_Sharp_Ratio.Text = string.Format("{0:N2}", _moneyManager.SharpRatio(_tradeManager, _dataList));
        }

        private DateTime TimeTranslation(double ticks)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(ticks);
            DateTime date = new DateTime(1971, 1, 1) + time;
            return date;
        }

        private void GoodToHaveCode()
        {
            // Used to plot the RSI14 indicator
            /*
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
                
            }*/
        }
    }
}
