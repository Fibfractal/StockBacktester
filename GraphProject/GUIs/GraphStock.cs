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
        // Data import from API and export to SQL
        private ExportToSql _exportToSql;

        // Data import from SQL to chart
        private ImportFromSql _importFromSql;
        private List<DailyDataPoint> _dataList;

        // Charts
        private TimeFrame _timeFrameStock;
        private TimeFrame _timeFrameBacktest;

        private CartesianMapper<DateModel> _dayConfigStock;
        private CartesianMapper<DateModel> _dayConfigBacktest;

        private DatePickerManager _datePicker;
        private int _startDateIndex;
        private int _endDateIndex;
        private bool _showChart;

        SeriesCollection _seriesCollectionStock;
        SeriesCollection _seriesCollectionBacktest;

        LineSeries _seriesStock;
        LineSeries _seriesMa;
        LineSeries _seriesEntry;
        LineSeries _seriesExit;

        LineSeries _seriesEquityCurve;
        LineSeries _seriesHigh;
        LineSeries _seriesLow;

        ChartValues<DateModel> _chartStock;
        ChartValues<DateModel> _chartMa;
        ChartValues<DateModel> _chartEntry;
        ChartValues<DateModel> _chartExit;

        ChartValues<DateModel> _chartEquityCurve;
        ChartValues<DateModel> _chartHigh;
        ChartValues<DateModel> _chartLow;

        // Pre-calculated indicators
        private RsiManager _lastAverage;
        private int _lenghtMa200 = 200;
        private int _lenghtMa50 = 50;
        private int _lenghtMa20 = 20;
        private int _lenghtRsi = 5;

        // Trades and backtest
        private TradeManager _tradeManager;
        private Backtest _backtest;

        // Algo
        private AlgoPicker _algoPicker;
        private string _algoName;

        // Delagates
        public delegate void guiAndThreads();
        guiAndThreads showUpdating;
        guiAndThreads hideUpdating;
        guiAndThreads showLoading;
        guiAndThreads hideLoading;
        guiAndThreads showLoadingBacktest;
        guiAndThreads hideLoadingBacktest;

        /// <summary>
        /// The constructor creates the Gui and fills it with it's
        /// elements.
        /// </summary>
        public GraphStocks()
        {
            InitializeComponent();
            InitializeFields();
            CreateAxels();
            FillGui();
        }

        /// <summary>
        /// Objects of all needed classes are created.
        /// </summary>
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

        /// <summary>
        /// When program starts, the Gui elements is shown or hidden.
        /// </summary>
        private void CreateAxels()
        {
            GuiAxelsStock();
            GuiAxelsPortfolio();
        }

        /// <summary>
        /// The x and y axels of the price chart are configured.
        /// </summary>
        private void GuiAxelsStock()
        {
            _dayConfigStock = Mappers.Xy<DateModel>()
                        .X(dateModel => dateModel.DateTime.Ticks / (_timeFrameStock.Years()))
                        .Y(dateModel => Math.Log(dateModel.Value, 10));

            // YearFormatter doesnt seem to work, spaces between years is not consistent
            // Works without it, and start year 1971
            StockChart.AxisX.Add(_timeFrameStock.YearFormatter());
            StockChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Price",
                LabelFormatter = value => Math.Pow(10, value).ToString("N0")
            });

            StockChart.AxisX[0].Separator.StrokeThickness = 0;
            StockChart.AxisY[0].Separator.StrokeThickness = 0;
        }

        /// <summary>
        /// The x and y axels of the portfolio chart are configured.
        /// </summary>
        private void GuiAxelsPortfolio()
        {
            _dayConfigBacktest = Mappers.Xy<DateModel>()
                          .X(dateModel => dateModel.DateTime.Ticks / (_timeFrameBacktest.Years()))
                          .Y(dateModel => dateModel.Value);

            // YearFormatter doesnt seem to work, spaces between years is not consistent
            // Works without it, and start year 1971
            BacktestChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Years"
            });
            BacktestChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Portfolio (SEK)",
                LabelFormatter = value => value.ToString("N0")
            });

            BacktestChart.AxisX[0].Separator.StrokeThickness = 0;
            BacktestChart.AxisY[0].Separator.StrokeThickness = 0;
        }



        /// <summary>
        /// Fills the Gui with all visual elements
        /// </summary>
        private void FillGui()
        {
            FillListBoxGui();
            FillComboBox();
            FillDatePickerGui();
            FillOrHideGui();
        }

        /// <summary>
        /// Fills the list in the Gui with all the names of the 
        /// stocks in the nasdaq 100.
        /// </summary>
        private void FillListBoxGui()
        {
            var arrayOfNames = (NasdaqStockNames[])Enum.GetValues(typeof(NasdaqStockNames));
            foreach (var item in arrayOfNames)
            {
                lbx_StockList.Items.Add(item.ToString().Replace("_", " "));
            }
        }

        /// <summary>
        /// The list with stocks names is filled in the Gui.
        /// </summary>
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
            _dataList = _importFromSql.ImportStockData("AAPL");
            _datePicker = new DatePickerManager(_dataList);
            dtp_Start_Date.Value = _datePicker.StandardStartDate();
            dtp_End_date.Value = _datePicker.StandardEndDate();
        }

        private void FillOrHideGui()
        {
            StockChart.Hide();
            BacktestChart.Hide();
            gbx_Backtest.Hide();
            lbl_Entry.Hide();
            lbl_Exit.Hide();
            lbl_MA200.Hide();
            lbl_NewHigh.Hide();
            lbl_Show_Point_MaxDrawDown.Hide();

            _showChart = true;

        }

        /// <summary>
        /// Calculates all indicators and plotts the price chart.
        /// Calculates the backtest and plotts the portfolio chart.
        /// Give the option to show charts or not.
        /// </summary>
        private void ChartData()
        {
            CalcAndPlotAlgosAndIndicators(_dataList);
            PortfolioAndBacktest();
            if (_showChart)
                MakeNewTread(LoadingThread);
        }


        /// <summary>
        /// All indicators are calculated. An the stock price, MA200, entries and exits of trades
        /// from the algo is plotted in a chart.
        /// </summary>
        /// <param name="listOfData">One stock price and datetime data</param>
        private void CalcAndPlotAlgosAndIndicators(List<DailyDataPoint> listOfData)
        {
            StockChart.LegendLocation = LiveCharts.LegendLocation.None;

            // All indicators are plotted
            CalcIndicatorsForAllValues();

            // Create counter for ChartValues
            int chart = 0;
            int chart2 = 0;

            // Create an algo picker
            _algoPicker = new AlgoPicker(listOfData, _algoName, _tradeManager);

            // Go through stock data from database
            for (int i = _startDateIndex; i < _endDateIndex + 1; i++)
            {
                _algoPicker.Index = i;

                // Plot close values at datetime in graph
                _chartStock.Add(new DateModel());
                //chartValues[i].DateTime = TimeTranslation(listOfData[i].MilliSeconds);
                _chartStock[chart].DateTime = TimeTranslation2(listOfData[i].Date);
                _chartStock[chart].Value = listOfData[i].Close;
                // Count one up for chart
                chart++;

                // Plot MA in graph at datetime
                if (i >= _lenghtMa200)
                {
                    _chartMa.Add(new DateModel());
                    //chartValues5[i - _lenghtMa].DateTime = TimeTranslation(listOfData[i].MilliSeconds);
                    _chartMa[chart2].DateTime = TimeTranslation2(listOfData[i].Date);
                    _chartMa[chart2].Value = listOfData[i].MA200;
                    chart2++;
                }

                // Plot algo buy signals in graph and save trade.
                // Now the buy and sell signals are at close, so your action can first be at
                // the next open. But I dont have data for open, so backtes wont be 100% correct.
                // A solution is to add i < listOfData.Count - 1 to if() and listOfData[i+1].Open to tradelist
                // but to plot listOfData[i+1].Close in chart. And have a messenger class. 

                // Plot algo buy signals in graph and save trade.
                if (_algoPicker.PickAlgoBuy())
                {
                    if (_tradeManager.AddNewTradeOk())
                    {
                        //_tradeManager.AddTrade(new OneTrade { Buy = listOfData[i+1].Open, BuyDate = TimeTranslation(listOfData[i+1].MilliSeconds) });
                        _tradeManager.AddTrade(new OneTrade { Buy = listOfData[i].Close, BuyDate = TimeTranslation2(listOfData[i].Date) });

                        _chartEntry.Add(new DateModel());
                        var length = _chartEntry.Count();
                        //chartValues6[length - 1].DateTime = TimeTranslation(listOfData[i+1].MilliSeconds);
                        _chartEntry[length - 1].DateTime = TimeTranslation2(listOfData[i].Date);
                        _chartEntry[length - 1].Value = listOfData[i].Close;
                    }
                }

                // Plot algo sell signals in graph and save trade.
                // Now the buy and sell signals are at close, so your action can first be at
                // the next open. But I dont have data for open, so backtes wont be 100% correct.
                // A solution is to add i < listOfData.Count - 1 to if() and listOfData[i+1].Open to tradelist
                // but to plot listOfData[i+1].Close in chart. And have a messenger class. 

                // Plot algo sell signals in graph and save trade.
                if (_algoPicker.PickAlgoSell())
                {
                    if (_tradeManager.UnFinishedTrade())
                    {
                        _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].Sell = listOfData[i].Close;
                        //_tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].SellDate = TimeTranslation(listOfData[i+1].MilliSeconds);
                        _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].SellDate = TimeTranslation2(listOfData[i].Date);

                        _chartExit.Add(new DateModel());
                        var length = _chartExit.Count();
                        //chartValues7[length - 1].DateTime = TimeTranslation(listOfData[i+1].MilliSeconds);
                        _chartExit[length - 1].DateTime = TimeTranslation2(listOfData[i].Date);
                        _chartExit[length - 1].Value = listOfData[i].Close;

                    }
                }
            }
            // StockChart.Background = Brushes.Black;

            PropertiesForStockChart();
            PlotInStockChart();
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
                StockChart.Series = _seriesCollectionStock;
        }

        /// <summary>
        /// A pre-selected algo is selected in the Gui.
        /// </summary>
        private void AlgoInComboBox()
        {
            _algoName = cbx_Pick_Algo.SelectedItem.ToString();
        }

        /// <summary>
        /// When a stock is picked in the list of stocks, the selected dates
        /// is choosen and verified.
        /// </summary>
        private void GetDatesGui()
        {
            _datePicker = new DatePickerManager(_dataList);
            _datePicker.StartDate = dtp_Start_Date.Value;
            _datePicker.EndDate = dtp_End_date.Value;
            _datePicker.VerifyDates();
            _startDateIndex = _datePicker.StartDateIndex;
            _endDateIndex = _datePicker.EndDateIndex;
        }

        /// <summary>
        /// Imports data from SQL database and verifies it.
        /// </summary>
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

        /// <summary>
        /// Imports stock data from SQL.
        /// </summary>
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

        /// <summary>
        /// All available indicator values are calculated for each price in time
        /// for that stock.
        /// </summary>
        private void CalcIndicatorsForAllValues()
        {
            for (int i = 0; i < _dataList.Count; i++)
            {
                // Calculate Rsi, Ma and Bollingerbands
                _dataList[i].RSI = (new RSI(_dataList, i, _lastAverage, _lenghtRsi)).CalculateRsi();
                _dataList[i].MA200 = (new MovingAverage(_dataList, i, _lenghtMa200)).CalculateMa();
                _dataList[i].MA50 = (new MovingAverage(_dataList, i, _lenghtMa50)).CalculateMa();
                _dataList[i].MA20 = (new MovingAverage(_dataList, i, _lenghtMa20)).CalculateMa();

                // These takes long time to calculate
                //_dataList[i].UpperBollingerBand = (new BollingerBands(_dataList, i, _lenghtMa200)).UpperBollingerBand();
            }
        }

        /// <summary>
        /// The portfolio graph is plotted depending on the trades.
        /// The backtest is calculated and shown in Gui.
        /// </summary>
        private void PortfolioAndBacktest()
        {
            BacktestChart.LegendLocation = LiveCharts.LegendLocation.None;



            // Start value for portfolio
            _chartEquityCurve.Add(new DateModel());
            //chartValues2[0].DateTime = TimeTranslation(_dataList[0].MilliSeconds);
            _chartEquityCurve[0].DateTime = TimeTranslation2(_datePicker.StartDate);
            _chartEquityCurve[0].Value = 100000;

            // Count highs
            int nbrHighs = 0;

            for (int i = 0; i < _tradeManager.GetTradeList.Count; i++)
            {
                if (_tradeManager.GetTradeList[i].Finished)
                {
                    // Plot eq curve according to the list of saved trades
                    _chartEquityCurve.Add(new DateModel());
                    _chartEquityCurve[_chartEquityCurve.Count - 1].DateTime = _tradeManager.GetTradeList[i].SellDate; // Allready adjusted for x-axel
                    _chartEquityCurve[_chartEquityCurve.Count - 1].Value = _backtest.ChangePortFolValue(_tradeManager, i);
                    _backtest.MaxDrawDown(i);

                    // Plot new highs
                    if (_backtest.Newhigh)
                    {
                        _chartHigh.Add(new DateModel());
                        _chartHigh[_chartHigh.Count - 1].DateTime = _tradeManager.GetTradeList[i].SellDate;
                        _chartHigh[_chartHigh.Count - 1].Value = _chartEquityCurve[_chartEquityCurve.Count - 1].Value;
                        nbrHighs++;
                    }
                }
            }


            // End value for portfolio
            _chartEquityCurve.Add(new DateModel());
            //chartValues2[chartValues2.Count - 1].DateTime = TimeTranslation(_dataList[_dataList.Count - 1].MilliSeconds);
            _chartEquityCurve[_chartEquityCurve.Count - 1].DateTime = TimeTranslation2(_datePicker.EndDate);
            _chartEquityCurve[_chartEquityCurve.Count - 1].Value = _backtest.PortfolioValue;

            // Trade list must contain losing trades, to plot max drawdown
            if (_backtest.MaxDrawDownProp > 0)
            {
                // Give values at index for highest drawdown to chart
                _chartLow.Add(new DateModel());
                _chartLow[0].DateTime = _tradeManager.GetTradeList[_backtest.IndexAtMaxDrawDown].SellDate;

                foreach (var item in _chartEquityCurve)
                {
                    // If date matches, take that portfolio value as value for maxdrawdown point
                    if (_chartLow[0].DateTime == item.DateTime)
                    {
                        _chartLow[0].Value = item.Value;
                    }
                }

            }

            //BacktestChart.Background = Brushes.Black;
            PropertiesForBacktest();
            PlotInBacktestChart();
            BacktestDataOneStock();
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
                BacktestChart.Series = _seriesCollectionBacktest;
        }

        /// <summary>
        /// The backtest for one stock is calculated and shown in the Gui.
        /// </summary>
        private void BacktestDataOneStock()
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
        /// <param name="datePrice">The date for a price</param>
        /// <returns></returns>
        private DateTime TimeTranslation2(DateTime datePrice)
        {

            DateTime date = new DateTime(1971, 1, 1);
            DateTime date2 = new DateTime(1972, 1, 1);
            TimeSpan oneYear = date2 - date;
            DateTime newDate = datePrice + oneYear;

            return newDate;
        }

        /// <summary>
        /// When an algo in Gui is chosen, the picked algo
        /// is updated.
        /// </summary>
        private void cbx_Pick_Algo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlgoInComboBox();
        }

        /// <summary>
        /// A stock in the stocklist is selected in the Gui.
        /// The stock and portfolio charts are now shown.
        /// The data for that stock is imported from SQL and verified.
        /// The selected dates in the Gui are verified.
        /// All indicators are calculated and price and MA200 are shown i the graph.
        /// The portfolio values are calculated and shown in portfolio graph.
        /// The backtest is calculated and shown in Gui.
        /// Some changes to the Gui are made.
        /// </summary>
        private void lbx_StockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeFields();
            SecondFillGUI();
            ImportAndVerifyData();
            GetDatesGui();
            ChartData();

            OtherGuiChanges();
        }

        /// <summary>
        /// The stock and portfolio charts are now shown in the Gui.
        /// </summary>
        private void SecondFillGUI()
        {
            StockChart.Show();
            BacktestChart.Show();
            StockChart.Series.Clear();
            BacktestChart.Series.Clear();

            gbx_Backtest.Show();
            lbl_Entry.Show();
            lbl_Exit.Show();
            lbl_MA200.Show();
            lbl_NewHigh.Show();
            lbl_Show_Point_MaxDrawDown.Show();
        }

        /// <summary>
        /// Some Gui elements are changed.
        /// </summary>
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
            _exportToSql.GetAllStockData();
            // In pratice 10 min delay
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
            //_exportToSql.GetAllStockData();
            MakeNewTread(UpdatingThread);
        }

        /// <summary>
        /// When pressing "Exit" in the menu, the program closes.
        /// </summary>
        private void mst_File_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// When start date is changed in the Gui. The value is verified and 
        /// a new start date value is given.
        /// </summary>
        private void dtp_Start_Date_ValueChanged(object sender, EventArgs e)
        {
            _datePicker.StartDate = dtp_Start_Date.Value;
            _datePicker.PickCorrectDayAndDate();
            dtp_Start_Date.Value = _datePicker.StartDate;
        }

        /// <summary>
        /// When end date is changed in the Gui. The value is verified and 
        /// a new end date value is given.
        /// </summary>
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
            // Updating sequence
            lbl_Updating.Text = "Updating ...";
            lbl_Updating.Visible = true;
            pcbx_Loading_Sequence.Visible = true;

            // Left GUI
            lbx_StockList.Enabled = false;
            cbx_Pick_Algo.Enabled = false;
            btn_Backtest_Multiple_Stocks.Enabled = false;

            // Right GUI
            gbx_Backtest.Visible = false;

            HideMiddleGui();
        }

        /// <summary>
        /// When the stock list is updated, only some parts
        /// in the Gui is shown and some is disabled.
        /// </summary>
        private void HideUpdating()
        {
            // Updating sequence
            lbl_Updating.Visible = false;
            pcbx_Loading_Sequence.Visible = false;

            // Left GUI
            lbx_StockList.Enabled = true;
            cbx_Pick_Algo.Enabled = true;
            btn_Backtest_Multiple_Stocks.Enabled = true;

            // Update gui after stock update
            FillDatePickerGui();
        }

        /// <summary>
        /// Method shows the middle part of the Gui.
        /// Including both graphs and labels
        /// </summary>
        private void ShowMiddleGui()
        {
            // Charts
            StockChart.Show();
            BacktestChart.Show();

            // Middle labels
            lbl_MA200.Visible = true;
            lbl_Entry.Visible = true;
            lbl_Exit.Visible = true;
            lbl_Stock_Ticker.Visible = true;
            lbl_NewHigh.Visible = true;
            lbl_Show_Point_MaxDrawDown.Visible = true;
        }

        /// <summary>
        /// Method hides the middle part of the Gui. Including
        /// both graphs and the labels.
        /// </summary>
        private void HideMiddleGui()
        {
            // Charts
            StockChart.Hide();
            BacktestChart.Hide();

            // Middle labels
            lbl_MA200.Visible = false;
            lbl_Entry.Visible = false;
            lbl_Exit.Visible = false;
            lbl_Stock_Ticker.Visible = false;
            lbl_NewHigh.Visible = false;
            lbl_Show_Point_MaxDrawDown.Visible = false;
        }

        /// <summary>
        /// Shows the text "Loading ..." int the Gui.
        /// </summary>
        private void ShowLoading()
        {
            lbl_Updating.Text = "Loading ...";
            lbl_Updating.Visible = true;
        }

        /// <summary>
        /// Hides the text "Loading ..." int the Gui.
        /// </summary>
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
