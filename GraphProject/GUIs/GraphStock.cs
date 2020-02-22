using GraphProject.Graph_Textfile;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Brushes = System.Windows.Media.Brushes;

namespace GraphProject
{
    /// <summary>
    /// This class presents a graphical user interface.
    /// The user will get the option to backtest a stock from the nasqaq100 stocklist,
    /// by picking dates and a trading strategy. The choice will result in a
    /// price chart with buy and sell signals, also viewed in a portfolio graph.
    /// A summary of the backtest of that stock will appear with key numbers,
    /// that will give clues if the trading strategy is profitable.
    /// There is a menu at the top of the interface, where you can update the
    /// entire stock list from the API, and then save it to a SQL database.
    /// In the menu there is also the option to not show the chart and only show
    /// the backtest key numbers. To avoid the plotting time of the chart.
    /// Finally, there is a button to open up another graphical user interface
    /// where you can backtest a strategy on multiple stocks at the same time.
    /// </summary>

    public partial class GraphStocks : Form
    {
        private ExportToSql _exportToSql;
        private ImportFromSql _importFromSql;
        private List<DailyDataPoint> _dataList;

        private TimeFrame _timeFrameStock;
        private TimeFrame _timeFrameBacktest;

        private CartesianMapper<DateModel> _dayConfigStock;
        private CartesianMapper<DateModel> _dayConfigBacktest;

        private DatePickerManager _datePicker;
        private int _startDateIndex;
        private int _endDateIndex;
        private bool _showChart;

        private SeriesCollection _seriesCollectionStock;
        private SeriesCollection _seriesCollectionBacktest;

        private LineSeries _seriesStock;
        private LineSeries _seriesMa;
        private LineSeries _seriesEntry;
        private LineSeries _seriesExit;

        private LineSeries _seriesEquityCurve;
        private LineSeries _seriesHigh;
        private LineSeries _seriesLow;

        private ChartValues<DateModel> _chartStock;
        private ChartValues<DateModel> _chartMa;
        private ChartValues<DateModel> _chartEntry;
        private ChartValues<DateModel> _chartExit;

        private ChartValues<DateModel> _chartEquityCurve;
        private ChartValues<DateModel> _chartHigh;
        private ChartValues<DateModel> _chartLow;

        private RsiManager _lastAverage;
        private int _lenghtMa200 = 200;
        private int _lenghtMa50 = 50;
        private int _lenghtMa20 = 20;
        private int _lenghtRsi = 5;

        private TradeManager _tradeManager;
        private Backtest _backtest;

        private AlgoPicker _algoPicker;
        private string _algoName;

        public delegate void guiAndThreads();
        guiAndThreads showUpdating;
        guiAndThreads hideUpdating;
        guiAndThreads showLoading;
        guiAndThreads hideLoading;
        guiAndThreads showLoadingBacktest;
        guiAndThreads hideLoadingBacktest;

        public GraphStocks()
        {
            InitializeComponent();
            InitializeFields();
            CreateAxels();
            FillGui();
            FillDataBaseFirstTime();
        }

        private void InitializeFields()
        {
            InitializeSqlConnection();
            InitializeTimeFrames();
            InitializeIndicators();
            InitializeBacktest();
            InitializeGuiAndTreads();
            InitializeLineSeries();
            InitializeChartValues();
        }

        private void InitializeSqlConnection()
        {
            _exportToSql = new ExportToSql();
            _importFromSql = new ImportFromSql();
        }

        private void InitializeTimeFrames()
        {
            _timeFrameStock = new TimeFrame();
            _timeFrameBacktest = new TimeFrame();
        }

        private void InitializeIndicators()
        {
            _lastAverage = new RsiManager();
        }

        private void InitializeBacktest()
        {
            _tradeManager = new TradeManager();
            _backtest = new Backtest(100000, 30000);
        }

        private void InitializeGuiAndTreads()
        {
            showUpdating = new guiAndThreads(ShowUpdating);
            hideUpdating = new guiAndThreads(HideUpdating);
            showLoading = new guiAndThreads(ShowLoading);
            hideLoading = new guiAndThreads(HideLoading);
            showLoadingBacktest = new guiAndThreads(ShowLoadingBacktest);
            hideLoadingBacktest = new guiAndThreads(HideLoadingBacktest);
        }

        private void InitializeLineSeries()
        {
            LineSeriesGraph();
            LineSeriesBacktest();
        }

        private void LineSeriesGraph()
        {

            _seriesCollectionStock = new SeriesCollection(_dayConfigStock);
            _seriesStock = new LineSeries();
            _seriesMa = new LineSeries();
            _seriesEntry = new LineSeries();
            _seriesExit = new LineSeries();


        }

        private void LineSeriesBacktest()
        {
            _seriesCollectionBacktest = new SeriesCollection(_dayConfigBacktest);
            _seriesEquityCurve = new LineSeries();
            _seriesHigh = new LineSeries();
            _seriesLow = new LineSeries();
        }

        private void InitializeChartValues()
        {
            ChartValuesGraph();
            ChartValuesBacktest();
        }

        private void ChartValuesGraph()
        {
            _chartStock = new ChartValues<DateModel>();
            _chartMa = new ChartValues<DateModel>();
            _chartEntry = new ChartValues<DateModel>();
            _chartExit = new ChartValues<DateModel>();
        }

        private void ChartValuesBacktest()
        {
            _chartEquityCurve = new ChartValues<DateModel>();
            _chartHigh = new ChartValues<DateModel>();
            _chartLow = new ChartValues<DateModel>();
        }

        private void CreateAxels()
        {
            GuiAxelsStock();
            GuiAxelsPortfolio();
        }

        private void GuiAxelsStock()
        {
            _dayConfigStock = Mappers.Xy<DateModel>()
                        .X(dateModel => dateModel.DateTime.Ticks / (_timeFrameStock.Years()))
                        .Y(dateModel => Math.Log(dateModel.Value, 10));

            AddStockAxels();
        }

        private void AddStockAxels()
        {
            StockChartGui.AxisX.Add(_timeFrameStock.YearFormatter());
            StockChartGui.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => Math.Pow(10, value).ToString("N0")
            });

            StockChartGui.AxisX[0].Separator.StrokeThickness = 0;
            StockChartGui.AxisY[0].Separator.StrokeThickness = 0;

        }

        private void GuiAxelsPortfolio()
        {
            _dayConfigBacktest = Mappers.Xy<DateModel>()
                          .X(dateModel => dateModel.DateTime.Ticks / (_timeFrameBacktest.Years()))
                          .Y(dateModel => dateModel.Value);

            AddPortfolioAxels();
        }

        private void AddPortfolioAxels()
        {
            BacktestChartGui.AxisX.Add(new Axis
            {
                Title = "Years"
            });
            BacktestChartGui.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Portfolio (SEK)",
                LabelFormatter = value => value.ToString("N0")
            });

            BacktestChartGui.AxisX[0].Separator.StrokeThickness = 0;
            BacktestChartGui.AxisY[0].Separator.StrokeThickness = 0;
        }

        private void FillGui()
        {
            FillListBoxGui();
            FillComboBox();
            FillDatePickerGui();
            FillOrHideGui();
        }

        private void FillListBoxGui()
        {
            var arrayOfNames = (NasdaqStockNames[])Enum.GetValues(typeof(NasdaqStockNames));
            foreach (var item in arrayOfNames)
            {
                lbx_StockList.Items.Add(item.ToString().Replace("_", " "));
            }
        }

        private void FillComboBox()
        {
            string[] algoArray = Enum.GetNames(typeof(EnumOfAlgos));
            cbx_Pick_Algo.Items.AddRange(algoArray);
            cbx_Pick_Algo.SelectedIndex = (int)EnumOfAlgos.InclineMaAlgo;
            _algoName = algoArray[0];
        }

        /// <summary>
        /// When program starts, last imported date must be loaded.
        /// So one stock ex. AAPL is loaded, and fills the date picker in the Gui.
        /// </summary>
        private void FillDatePickerGui()
        {
            if (DataInFirstTable())
            {
                _dataList = _importFromSql.ImportStockData("AAPL");
                _datePicker = new DatePickerManager(_dataList);
                dtp_Start_Date.Value = _datePicker.StandardStartDate();
                dtp_End_date.Value = _datePicker.StandardEndDate();
            }
        }

        private bool DataInFirstTable()
        {
            return _importFromSql.ImportStockData("AAPL").Count > 0;
        }

        private void FillOrHideGui()
        {
            StockChartGui.Hide();
            BacktestChartGui.Hide();
            gbx_Backtest.Hide();

            lbl_Entry.Hide();
            lbl_Exit.Hide();
            lbl_MA200.Hide();
            lbl_NewHigh.Hide();
            lbl_Show_Point_MaxDrawDown.Hide();

            _showChart = true;
        }

        private void FillDataBaseFirstTime()
        {
            if (!DataInFirstTable())
                MakeNewTread(UpdatingThread);
        }

        private void ChartData()
        {
            StockChart();
            BacktestChart();
            if (_showChart)
                MakeNewTread(LoadingThread);
        }

        private void StockChart()
        {
            StockChartGui.LegendLocation = LiveCharts.LegendLocation.None;
            _algoPicker = new AlgoPicker(_dataList, _algoName, _tradeManager);

            CalculateIndicators();
            AlgoSignals();
            PropertiesForStockChart();
            PlotInStockChart();
        }

        private void AlgoSignals()
        {
            int counterStock = 0;
            int counterMa = 0;

            for (int i = _startDateIndex; i < _endDateIndex + 1; i++)
            {
                _algoPicker.Index = i;

                AddStockPrice(i, counterStock);
                counterStock++;

                if (i >= _lenghtMa200)
                {
                    AddMovingAverage(i, counterMa);
                    counterMa++;
                }

                BuySignal(i);
                SellSignal(i);
            }
        }

        private void AddStockPrice(int index, int counterStock)
        {
            _chartStock.Add(new DateModel());
            _chartStock[counterStock].DateTime = TimeTranslation2(_dataList[index].Date);
            _chartStock[counterStock].Value = _dataList[index].Close;
        }

        private void AddMovingAverage(int index, int counterMa)
        {
            _chartMa.Add(new DateModel());
            _chartMa[counterMa].DateTime = TimeTranslation2(_dataList[index].Date);
            _chartMa[counterMa].Value = _dataList[index].MA200;
        }

        /// <summary>
        /// In real life we buy on open price after signal.
        /// since we have only close price in database,
        /// The backtest will not 100% correct.
        /// In future, filter all new buy signals.
        /// Same for sell signals.
        /// </summary>
        private void BuySignal(int index)
        {
            if (_algoPicker.PickAlgoBuy())
            {
                if (_tradeManager.AddNewTradeOk())
                {
                    AddOpenedTrade(index);
                    EntryValuesToPlot(index);
                }
            }
        }

        private void SellSignal(int index)
        {
            if (_algoPicker.PickAlgoSell())
            {
                if (_tradeManager.UnFinishedTrade())
                {
                    AddFinishedTrade(index);
                    ExitValuesToPlot(index);
                }
            }
        }

        private void AddOpenedTrade(int index)
        {
            _tradeManager.AddTrade(new OneTrade { Buy = _dataList[index].Close, BuyDate = TimeTranslation2(_dataList[index].Date) });
        }

        private void EntryValuesToPlot(int index)
        {
            _chartEntry.Add(new DateModel());
            var length = _chartEntry.Count();
            _chartEntry[length - 1].DateTime = TimeTranslation2(_dataList[index].Date);
            _chartEntry[length - 1].Value = _dataList[index].Close;
        }

        private void AddFinishedTrade(int index)
        {
            _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].Sell = _dataList[index].Close;
            _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].SellDate = TimeTranslation2(_dataList[index].Date);
        }

        private void ExitValuesToPlot(int index)
        {
            _chartExit.Add(new DateModel());
            var length = _chartExit.Count();
            _chartExit[length - 1].DateTime = TimeTranslation2(_dataList[index].Date);
            _chartExit[length - 1].Value = _dataList[index].Close;
        }

        private void PropertiesForStockChart()
        {
            StockSeriesProperties();
            MaSeriesProperties();
            EntrySeriesProperties();
            ExitSeriesProperties();
        }

        private void StockSeriesProperties()
        {
            _seriesStock.PointGeometrySize = 1;
            _seriesStock.Fill = Brushes.Transparent;
            _seriesStock.Stroke = Brushes.LightGray;
            _seriesStock.Values = _chartStock;
        }

        private void MaSeriesProperties()
        {
            _seriesMa.PointGeometrySize = 1;
            _seriesMa.Fill = Brushes.Transparent;
            _seriesMa.Stroke = Brushes.Yellow;
            _seriesMa.Values = _chartMa;
        }

        private void EntrySeriesProperties()
        {
            _seriesEntry.PointGeometrySize = 5;
            _seriesEntry.Fill = Brushes.Transparent;
            _seriesEntry.PointForeground = Brushes.Yellow;
            _seriesEntry.Values = _chartEntry;
            _seriesEntry.StrokeThickness = 0;
        }

        private void ExitSeriesProperties()
        {
            _seriesExit.PointGeometrySize = 5;
            _seriesExit.Fill = Brushes.Transparent;
            _seriesExit.PointForeground = Brushes.Red;
            _seriesExit.Values = _chartExit;
            _seriesExit.StrokeThickness = 0;
        }

        private void PlotInStockChart()
        {
            _seriesCollectionStock.Add(_seriesStock);
            _seriesCollectionStock.Add(_seriesMa);

            if (_chartEntry.Count() > 0)
                _seriesCollectionStock.Add(_seriesEntry);

            if (_chartExit.Count() > 0)
                _seriesCollectionStock.Add(_seriesExit);

            if (_showChart)
                StockChartGui.Series = _seriesCollectionStock;
        }

        private void AlgoInComboBox()
        {
            _algoName = cbx_Pick_Algo.SelectedItem.ToString();
        }

        private void GetDatesGui()
        {
            _datePicker = new DatePickerManager(_dataList);
            _datePicker.StartDate = dtp_Start_Date.Value;
            _datePicker.EndDate = dtp_End_date.Value;
            _datePicker.VerifyDates();
            _startDateIndex = _datePicker.StartDateIndex;
            _endDateIndex = _datePicker.EndDateIndex;
        }

        private void ImportAndVerifyData()
        {
            try
            {
                ImportSqlData();
                _importFromSql.VerifyData(_dataList);

                if (!_importFromSql.VerifyData(_dataList))
                    MessageBox.Show("Import of sql stock data is not complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import of sql stock data failed!");
            }
        }

        private void ImportSqlData()
        {
            int index = lbx_StockList.SelectedIndex;

            if (index >= 0)
            {
                var stockArray = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));
                string stockName = stockArray[index].ToString();
                lbl_Stock_Ticker.Text = stockName;
                _backtest.Ticker = stockName;
                _dataList = _importFromSql.ImportStockData(stockName);
            }
        }

        private void CalculateIndicators()
        {
            for (int i = 0; i < _dataList.Count; i++)
            {
                _dataList[i].RSI = (new RSI(_dataList, i, _lastAverage, _lenghtRsi)).CalculateRsi();
                _dataList[i].MA200 = (new MovingAverage(_dataList, i, _lenghtMa200)).CalculateMa();
                _dataList[i].MA50 = (new MovingAverage(_dataList, i, _lenghtMa50)).CalculateMa();
                _dataList[i].MA20 = (new MovingAverage(_dataList, i, _lenghtMa20)).CalculateMa();
            }
        }

        private void BacktestChart()
        {
            BacktestChartGui.LegendLocation = LiveCharts.LegendLocation.None;
            Portfolio();
            PropertiesForBacktest();
            PlotInBacktestChart();
            DisplayBacktestOneStock();
        }

        private void Portfolio()
        {
            AddStartValuePortfolio();
            int highsCounter = 0;

            for (int i = 0; i < _tradeManager.GetTradeList.Count; i++)
            {
                if (_tradeManager.GetTradeList[i].Finished)
                {
                    AddEquityCurveValue(i);
                    _backtest.MaxDrawDown(i);
                    AddNewHigh(i);
                    highsCounter++;
                }
            }

            AddEndValuePortfolio();
            AddMaxDrawDown();
        }

        private void AddEquityCurveValue(int index)
        {
            _chartEquityCurve.Add(new DateModel());
            _chartEquityCurve[_chartEquityCurve.Count - 1].DateTime = _tradeManager.GetTradeList[index].SellDate;
            _chartEquityCurve[_chartEquityCurve.Count - 1].Value = _backtest.ChangePortFolValue(_tradeManager, index);
        }

        private void AddNewHigh(int index)
        {
            if (_backtest.Newhigh)
            {
                _chartHigh.Add(new DateModel());
                _chartHigh[_chartHigh.Count - 1].DateTime = _tradeManager.GetTradeList[index].SellDate;
                _chartHigh[_chartHigh.Count - 1].Value = _chartEquityCurve[_chartEquityCurve.Count - 1].Value;
            }
        }

        private void AddStartValuePortfolio()
        {
            _chartEquityCurve.Add(new DateModel());
            _chartEquityCurve[0].DateTime = TimeTranslation2(_datePicker.StartDate);
            _chartEquityCurve[0].Value = 100000;
        }

        private void AddEndValuePortfolio()
        {
            _chartEquityCurve.Add(new DateModel());
            _chartEquityCurve[_chartEquityCurve.Count - 1].DateTime = TimeTranslation2(_datePicker.EndDate);
            _chartEquityCurve[_chartEquityCurve.Count - 1].Value = _backtest.PortfolioValue;
        }

        private void AddMaxDrawDown()
        {
            if (_backtest.MaxDrawDownProp > 0)
            {
                _chartLow.Add(new DateModel());
                _chartLow[0].DateTime = _tradeManager.GetTradeList[_backtest.IndexAtMaxDrawDown].SellDate;
                FindPortfolioValueForMaxDrawDown();
            }
        }

        private void FindPortfolioValueForMaxDrawDown()
        {
            foreach (var item in _chartEquityCurve)
            {
                if (_chartLow[0].DateTime == item.DateTime)
                {
                    _chartLow[0].Value = item.Value;
                }
            }
        }

        private void PropertiesForBacktest()
        {
            EquitySeriesProperties();
            HighSeriesProperties();
            LowSeriesProperties();
        }

        private void EquitySeriesProperties()
        {
            _seriesEquityCurve.PointGeometrySize = 5;
            _seriesEquityCurve.Fill = Brushes.Gray;
            _seriesEquityCurve.Stroke = Brushes.Yellow;
            _seriesEquityCurve.Values = _chartEquityCurve;
            _seriesEquityCurve.LineSmoothness = 0;
            _seriesEquityCurve.StrokeThickness = 1;
            _seriesEquityCurve.PointForeground = Brushes.White;
        }

        private void HighSeriesProperties()
        {
            _seriesHigh.PointGeometrySize = 7;
            _seriesHigh.Fill = Brushes.Transparent;
            _seriesHigh.PointForeground = Brushes.White;
            _seriesHigh.Values = _chartHigh;
            _seriesHigh.StrokeThickness = 0;
        }

        private void LowSeriesProperties()
        {
            _seriesLow.PointGeometrySize = 7;
            _seriesLow.Fill = Brushes.Transparent;
            _seriesLow.PointForeground = Brushes.Red;
            _seriesLow.Values = _chartLow;
            _seriesLow.StrokeThickness = 0;
        }

        private void PlotInBacktestChart()
        {
            _seriesCollectionBacktest.Add(_seriesEquityCurve);

            if (_chartHigh.Count > 0)
                _seriesCollectionBacktest.Add(_seriesHigh);

            if (_chartLow.Count > 0)
                _seriesCollectionBacktest.Add(_seriesLow);

            if (_showChart)
                BacktestChartGui.Series = _seriesCollectionBacktest;
        }

        private void DisplayBacktestOneStock()
        {
            lbl_ValuePortfolio_Start.Text = string.Format("{0:N0}", _backtest.PortfolioValueStart);
            lbl_Value_Portfolio_End.Text = string.Format("{0:N0}", _backtest.PortfolioValue);
            lbl_Value_Return_Sek.Text = string.Format("{0:N0}", _backtest.ReturnSek());
            lbl_Value_Return_Procent.Text = string.Format("{0:N1}", _backtest.ReturnProcent());
            lbl_Value_Nbr_Trades.Text = string.Format("{0:N0}", _backtest.NumberOfFinishedTrades(_tradeManager));
            lbl_Value_Winners_Procent.Text = string.Format("{0:N1}", _backtest.WinnersPercent(_tradeManager));
            lbl_Value_Avg_Gain.Text = string.Format("{0:N0}", _backtest.AverageGain(_tradeManager));
            lbl_Value_Avg_Loss.Text = string.Format("{0:N0}", _backtest.AverageLoss(_tradeManager));
            lbl_Value_Profit_Factor.Text = string.Format("{0:N2}", _backtest.ProfitFactor(_tradeManager));
            lbl_Value_CAGR.Text = string.Format("{0:N1}", _backtest.Cagr(_dataList, _datePicker.StartDate, _datePicker.EndDate));
            lbl_Value_TimeSpan_Start.Text = _datePicker.StartDate.ToShortDateString();
            lbl_Value_TimeSpan_Finish.Text = _datePicker.EndDate.ToShortDateString();
            lbl_Value_Ticker.Text = _backtest.Ticker;
            lbl_Value_Sharp_Ratio.Text = string.Format("{0:N2}", _backtest.SharpRatio(_tradeManager, _dataList, _datePicker.StartDate, _datePicker.EndDate));
            lbl_Value_Max_DrawDown.Text = string.Format("{0:N1}", _backtest.MaxDrawDownProp);
        }

        /// <summary>
        /// The date from API is correct, but have to add one year for 
        /// adjust for the incorrect x-axel. So both match up.
        /// </summary>
        private DateTime TimeTranslation2(DateTime datePrice)
        {

            DateTime date = new DateTime(1971, 1, 1);
            DateTime date2 = new DateTime(1972, 1, 1);
            TimeSpan oneYear = date2 - date;
            DateTime newDate = datePrice + oneYear;

            return newDate;
        }

        private void cbx_Pick_Algo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlgoInComboBox();
        }

        private void lbx_StockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeFields();
            SecondFillGUI();
            ImportAndVerifyData();
            GetDatesGui();
            ChartData();

            OtherGuiChanges();
        }

        private void SecondFillGUI()
        {
            StockChartGui.Show();
            BacktestChartGui.Show();
            StockChartGui.Series.Clear();
            BacktestChartGui.Series.Clear();

            gbx_Backtest.Show();
            lbl_Entry.Show();
            lbl_Exit.Show();
            lbl_MA200.Show();
            lbl_NewHigh.Show();
            lbl_Show_Point_MaxDrawDown.Show();
        }

        private void OtherGuiChanges()
        {
            lbl_Stock_Ticker.Visible = true;
            if (!_showChart)
                HideMiddleGui();
            gbx_Backtest.Visible = true;

            dtp_Start_Date.Value = _datePicker.StartDate;
            dtp_End_date.Value = _datePicker.EndDate;
        }

        /// <summary>
        /// when the "Backtest multiple stock" button is pressed,
        /// another Gui is opened up.
        /// </summary>
        private void btn_Backtest_Multiple_Stocks_Click(object sender, EventArgs e)
        {
            MakeNewTread(MultipleBacktestTread);
        }

        /// <summary>
        /// When "Update" is chosen in the menu; all stock data gets updated. To 
        /// illustrate that this process is active, a GIF is shown. If it's done
        /// in a new thread the Gui doesn't lock it self.
        /// </summary>
        private void UpdatingThread()
        {
            this.Invoke(this.showUpdating);
            _exportToSql.ExportToDatabase();
            System.Threading.Thread.Sleep(400000);
            this.Invoke(this.hideUpdating);
        }

        /// <summary>
        /// When a new stock i picked in the list, it takes som time to 
        /// plot this. It's illustrated with "Loading ..." in the Gui.
        /// </summary>
        private void LoadingThread()
        {
            this.Invoke(this.showLoading);
            System.Threading.Thread.Sleep(1500);
            this.Invoke(this.hideLoading);
        }
        /// <summary>
        /// "Loading ..." is showed in Gui.
        ///  A new Gui is opened, to do multiple backtests.
        /// </summary>
        private void MultipleBacktestTread()
        {
            this.Invoke(this.showLoadingBacktest);

            var openForm = new MultipleBacktests();
            openForm.ShowDialog();

            System.Threading.Thread.Sleep(1000);
            this.Invoke(this.hideLoadingBacktest);
        }

        /// <summary>
        /// A method that starts a new thread, running a certain method.
        /// </summary>
        /// <param name="methodName">The method to run</param>
        private void MakeNewTread(Action methodName)
        {
            ThreadStart myThreadStart = new ThreadStart(methodName);
            Thread myThread = new Thread(myThreadStart);
            myThread.Start();
        }

        /// <summary>
        /// If picked "Hide chart" / "Show chart" in the menu in Gui. The purpose is to have the option
        /// to hide price graph and save loading time when backtesting long timeseries.
        /// </summary>
        private void mst_Tools_Hide_Show_Chart_Click(object sender, EventArgs e)
        {
            if (_showChart)
            {
                _showChart = false;
                mst_Tools_Hide_Show_Chart.Text = "Show chart";
            }
            else
            {
                _showChart = true;
                mst_Tools_Hide_Show_Chart.Text = "Hide chart";
            }
        }

        /// <summary>
        /// When pressing the "Update chart" in the menu, the
        /// process of updating the stocklist starts.
        /// </summary>
        private void mst_Update_Pick_Click(object sender, EventArgs e)
        {
            MakeNewTread(UpdatingThread);
        }

        private void mst_File_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtp_Start_Date_ValueChanged(object sender, EventArgs e)
        {
            _datePicker.StartDate = dtp_Start_Date.Value;
            _datePicker.PickCorrectDayAndDate();
            dtp_Start_Date.Value = _datePicker.StartDate;
        }

        private void dtp_End_date_ValueChanged(object sender, EventArgs e)
        {
            _datePicker.EndDate = dtp_End_date.Value;
            _datePicker.PickCorrectDayAndDate();
            dtp_End_date.Value = _datePicker.EndDate;
        }

        /// <summary>
        /// When the stock list is updating, only some parts
        /// in the Gui is shown and some is disabled.
        /// </summary>
        private void ShowUpdating()
        {
            UpdatingSequenceShow();
            LeftGuiShow();
            RightGuiShow();
            HideMiddleGui();
        }

        private void UpdatingSequenceShow()
        {
            lbl_Updating.Text = "Updating ...";
            lbl_Updating.Visible = true;
            pcbx_Loading_Sequence.Visible = true;
        }

        private void LeftGuiShow()
        {
            lbx_StockList.Enabled = false;
            cbx_Pick_Algo.Enabled = false;
            btn_Backtest_Multiple_Stocks.Enabled = false;
        }

        private void RightGuiShow()
        {
            gbx_Backtest.Visible = false;
        }

        private void HideMiddleGui()
        {
            StockChartGui.Hide();
            BacktestChartGui.Hide();
            HideMiddleLabels();
        }

        private void HideMiddleLabels()
        {
            lbl_MA200.Visible = false;
            lbl_Entry.Visible = false;
            lbl_Exit.Visible = false;
            lbl_Stock_Ticker.Visible = false;
            lbl_NewHigh.Visible = false;
            lbl_Show_Point_MaxDrawDown.Visible = false;
        }

        /// <summary>
        /// When the stock list is updated, only some parts
        /// in the Gui is shown and some is disabled.
        /// </summary>
        private void HideUpdating()
        {
            UpdatingSequenceHide();
            LeftGuiHide();
            FillDatePickerGui();
        }

        private void UpdatingSequenceHide()
        {
            lbl_Updating.Visible = false;
            pcbx_Loading_Sequence.Visible = false;
        }

        private void LeftGuiHide()
        {
            lbx_StockList.Enabled = true;
            cbx_Pick_Algo.Enabled = true;
            btn_Backtest_Multiple_Stocks.Enabled = true;
        }

        private void ShowLoading()
        {
            lbl_Updating.Text = "Loading ...";
            lbl_Updating.Visible = true;
        }

        private void HideLoading()
        {
            lbl_Updating.Visible = false;
        }

        /// <summary>
        /// When opening the multiple backtest Gui, the text
        /// "Loading ..." is shown and some parts of the Gui
        /// is disabled.
        /// </summary>
        private void ShowLoadingBacktest()
        {
            lbl_Updating.Text = "Loading ...";
            lbl_Updating.Visible = true;

            lbx_StockList.Enabled = false;
            cbx_Pick_Algo.Enabled = false;
        }

        /// <summary>
        /// When the multiple backtest Gui has opened, the text
        /// "Loading ..." is hidden and some parts of the Gui
        /// is enabled.
        /// </summary>
        private void HideLoadingBacktest()
        {
            lbl_Updating.Visible = false;

            lbx_StockList.Enabled = true;
            cbx_Pick_Algo.Enabled = true;
        }
    }
}
