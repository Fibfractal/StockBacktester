using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        // Stockchart
        private TimeFrame _timeFrame;
        private CartesianMapper<DateModel> _dayConfig;
        private DatePickerManager _datePicker;
        private int _startDateIndex;
        private int _endDateIndex;
        private bool _showChart;

        // Backtestchart
        private TimeFrame _timeFrame2;
        private CartesianMapper<DateModel> _dayConfig2;

        // Pre-calculated indicators
        private RsiManager _lastAverage;
        private int _lenghtMa200 = 200; // Is plotted
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
            FillListBoxGui();
            InitializeAttributes();
            FirstFillGUI();
            FillComboBox();
            FillDatePickerGui();
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
        /// Objects of all needed classes are created.
        /// </summary>
        private void InitializeAttributes()
        {
            _exportToSql = new ExportToSql();
            _importFromSql = new ImportFromSql();
            _timeFrame = new TimeFrame();

            _lastAverage = new RsiManager();
            _timeFrame2 = new TimeFrame();

            _tradeManager = new TradeManager();
            _backtest = new Backtest(100000, 30000);

            showUpdating = new guiAndThreads(ShowUpdating);
            hideUpdating = new guiAndThreads(HideUpdating);
            showLoading = new guiAndThreads(ShowLoading);
            hideLoading = new guiAndThreads(HideLoading);
            showLoadingBacktest = new guiAndThreads(ShowLoadingBacktest);
            hideLoadingBacktest = new guiAndThreads(HideLoadingBacktest);
        }

        /// <summary>
        /// When program starts, the Gui elements is shown or hidden.
        /// </summary>
        private void FirstFillGUI()
        {
            cartesianChart1.Hide();
            GuiAxelsIndex();

            cartesianChart2.Hide();
            GuiAxelsPortfolio();

            gbx_Backtest.Hide();
            lbl_Entry.Hide();
            lbl_Exit.Hide();
            lbl_MA200.Hide();
            lbl_NewHigh.Hide();
            lbl_Show_Point_MaxDrawDown.Hide();

            _showChart = true;
        }

        /// <summary>
        /// A pre-selected algo is selected in the Gui.
        /// </summary>
        private void AlgoInComboBox()
        {
            _algoName = cbx_Pick_Algo.SelectedItem.ToString();
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
                //var stockName = _stockSymbols.symbolsList[index].Symbol;
                var stockArray = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));
                string stockName = stockArray[index].ToString();
                lbl_Stock_Ticker.Text = stockName;
                _backtest.Ticker = stockName;
                _dataList = _importFromSql.ImportStockData(stockName);
            }
        }

        /// <summary>
        /// The x and y axels of the price chart are configured.
        /// </summary>
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

        /// <summary>
        /// The x and y axels of the portfolio chart are configured.
        /// </summary>
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

        /// <summary>
        /// Calculates all indicators and plotts the price chart.
        /// Calculates the backtest and plotts the portfolio chart.
        /// Give the option to show charts or not.
        /// </summary>
        private void ChartData()
        {
            CalcAndPlotAlgosAndIndicators(_dataList);
            PortfolioAndBacktest();
            if(_showChart)
                MakeNewTread(LoadingThread);
        }

        /// <summary>
        /// All indicators are calculated. An the stock price, MA200, entries and exits of trades
        /// from the algo is plotted in a chart.
        /// </summary>
        /// <param name="listOfData">One stock price and datetime data</param>
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
                chartValues.Add(new DateModel());
                //chartValues[i].DateTime = TimeTranslation(listOfData[i].MilliSeconds);
                chartValues[chart].DateTime = TimeTranslation2(listOfData[i].Date);
                chartValues[chart].Value = listOfData[i].Close;
                // Count one up for chart
                chart++;

                // Plot MA in graph at datetime
                if (i >= _lenghtMa200) 
                {
                    chartValues5.Add(new DateModel());
                    //chartValues5[i - _lenghtMa].DateTime = TimeTranslation(listOfData[i].MilliSeconds);
                    chartValues5[chart2].DateTime = TimeTranslation2(listOfData[i].Date); 
                    chartValues5[chart2].Value = listOfData[i].MA200; 
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
                        
                        chartValues6.Add(new DateModel());
                        var length = chartValues6.Count();
                        //chartValues6[length - 1].DateTime = TimeTranslation(listOfData[i+1].MilliSeconds);
                        chartValues6[length - 1].DateTime = TimeTranslation2(listOfData[i].Date);
                        chartValues6[length - 1].Value = listOfData[i].Close;
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
                        
                        chartValues7.Add(new DateModel());
                        var length = chartValues7.Count();
                        //chartValues7[length - 1].DateTime = TimeTranslation(listOfData[i+1].MilliSeconds);
                        chartValues7[length - 1].DateTime = TimeTranslation2(listOfData[i].Date);
                        chartValues7[length - 1].Value = listOfData[i].Close;
                        
                    }
                }
            }

            // Stock 
            lineSeries.PointGeometrySize = 1;
            lineSeries.Fill = Brushes.Transparent;
            lineSeries.Stroke = Brushes.LightGray;
            lineSeries.Values = chartValues;

            // Ma 200
            lineSeries5.PointGeometrySize = 1;
            lineSeries5.Fill = Brushes.Transparent;
            lineSeries5.Stroke = Brushes.Yellow;
            lineSeries5.Values = chartValues5;
            //cartesianChart1.Background = Brushes.Black;

            // Entries
            lineSeries6.PointGeometrySize = 5;
            lineSeries6.Fill = Brushes.Transparent;
            lineSeries6.PointForeground = Brushes.Yellow;
            lineSeries6.Values = chartValues6;
            lineSeries6.StrokeThickness = 0;

            // Exits
            lineSeries7.PointGeometrySize = 5;
            lineSeries7.Fill = Brushes.Transparent;
            lineSeries7.PointForeground = Brushes.Red;
            lineSeries7.Values = chartValues7;
            lineSeries7.StrokeThickness = 0;

            // Entries are plotted
            if(chartValues6.Count() > 0)
            seriesCollection.Add(lineSeries6);

            // Trade need to be finished with exit to be plotted, else (0,0) will 
            // be wrongly plotted ie nothing in lineSeries7.
            if (chartValues7.Count() > 0)
                seriesCollection.Add(lineSeries7);

            // Price and ma200 is plotted 
            seriesCollection.Add(lineSeries5);
            seriesCollection.Add(lineSeries);

            // If option no chart is unchecked
            if(_showChart)
                cartesianChart1.Series = seriesCollection;
        }

        /// <summary>
        /// All available indicator values are calculated for each price in time
        /// for that stock.
        /// </summary>
        private void CalcIndicatorsForAllValues()
        {
            for (int i = 0; i < _dataList.Count; i++)
            {
                // Calculate Rsi and Ma
                _dataList[i].RSI = (new RSI(_dataList, i, _lastAverage, _lenghtRsi)).CalculateRsi();
                _dataList[i].MA200 = (new MovingAverage(_dataList, i, _lenghtMa200)).CalculateMa();
                _dataList[i].MA50 = (new MovingAverage(_dataList, i, _lenghtMa50)).CalculateMa();
                _dataList[i].MA20 = (new MovingAverage(_dataList, i, _lenghtMa20)).CalculateMa();
            }
        }

        /// <summary>
        /// The portfolio graph is plotted depending on the trades.
        /// The backtest is calculated and shown in Gui.
        /// </summary>
        private void PortfolioAndBacktest()
        {
            cartesianChart2.LegendLocation = LiveCharts.LegendLocation.None;

            // Creation of objects of classes needed for plotting portfolio chart.
            var seriesCollection2 = new SeriesCollection(_dayConfig2);
            var lineSeries2 = new LineSeries();
            var lineSeries8 = new LineSeries();
            var lineSeries9 = new LineSeries();
            var chartValues2 = new ChartValues<DateModel>();
            var chartValues8 = new ChartValues<DateModel>();
            var chartValues9 = new ChartValues<DateModel>();

            // Start value for portfolio
            chartValues2.Add(new DateModel());
            //chartValues2[0].DateTime = TimeTranslation(_dataList[0].MilliSeconds);
            chartValues2[0].DateTime = TimeTranslation2(_datePicker.StartDate);
            chartValues2[0].Value = 100000;

            // Count highs
            int nbrHighs = 0;

            for (int i = 0; i < _tradeManager.GetTradeList.Count; i++)
            {
                if (_tradeManager.GetTradeList[i].Finished)
                {
                    // Plot eq curve according to the list of saved trades
                    chartValues2.Add(new DateModel());
                    chartValues2[chartValues2.Count - 1].DateTime = _tradeManager.GetTradeList[i].SellDate; // Allready adjusted for x-axel
                    chartValues2[chartValues2.Count - 1].Value = _backtest.ChangePortFolValue(_tradeManager, i);
                    _backtest.MaxDrawDown(i);

                    // Plot new highs
                    if (_backtest.Newhigh)
                    {
                        chartValues8.Add(new DateModel());
                        chartValues8[chartValues8.Count - 1].DateTime = _tradeManager.GetTradeList[i].SellDate;
                        chartValues8[chartValues8.Count - 1].Value = chartValues2[chartValues2.Count - 1].Value;
                        nbrHighs++;
                    }
                }
            }

            
            // End value for portfolio
            chartValues2.Add(new DateModel());
            //chartValues2[chartValues2.Count - 1].DateTime = TimeTranslation(_dataList[_dataList.Count - 1].MilliSeconds);
            chartValues2[chartValues2.Count - 1].DateTime = TimeTranslation2(_datePicker.EndDate);
            chartValues2[chartValues2.Count - 1].Value = _backtest.PortfolioValue;

            // Trade list must contain losing trades, to plot max drawdown
            if (_backtest.MaxDrawDownProp > 0)
            {
                // Give values at index for highest drawdown to chart
                chartValues9.Add(new DateModel());
                chartValues9[0].DateTime = _tradeManager.GetTradeList[_backtest.IndexAtMaxDrawDown].SellDate;
                
                foreach (var item in chartValues2)
                {
                    // If date matches, take that portfolio value as value for maxdrawdown point
                    if (chartValues9[0].DateTime == item.DateTime)
                    {
                        chartValues9[0].Value = item.Value;
                    }
                }

            }

            // Equity curve
            lineSeries2.PointGeometrySize = 5;
            lineSeries2.Fill = Brushes.Gray;
            lineSeries2.Stroke = Brushes.Yellow;
            lineSeries2.Values = chartValues2;
            lineSeries2.LineSmoothness = 0;
            lineSeries2.StrokeThickness = 1;
            lineSeries2.PointForeground = Brushes.White;

            // New highs
            lineSeries8.PointGeometrySize = 7;
            lineSeries8.Fill = Brushes.Transparent;
            lineSeries8.PointForeground = Brushes.White;
            lineSeries8.Values = chartValues8;
            lineSeries8.StrokeThickness = 0;

            // Max drawdown
            lineSeries9.PointGeometrySize = 7;
            lineSeries9.Fill = Brushes.Transparent;
            lineSeries9.PointForeground = Brushes.Red;
            lineSeries9.Values = chartValues9;
            lineSeries9.StrokeThickness = 0;

            // Equity curve is added
            seriesCollection2.Add(lineSeries2);

            // Only added to graph if there is new highs, or else
            // plot gets wrong inluced ie the coordinat (0,0) for lineSeries8.
            if (chartValues8.Count > 0)
                seriesCollection2.Add(lineSeries8);


            // Only added to graph if there is a drawdown, or else
            // plot gets wrong ie inluced the coordinat (0,0) for lineSeries9.
            if (chartValues9.Count > 0)
                seriesCollection2.Add(lineSeries9);

            //cartesianChart2.Background = Brushes.Black;
            if (_showChart)
                cartesianChart2.Series = seriesCollection2;

            // Calculates the backtest for one stock
            BacktestData();
        }

        /// <summary>
        /// The backtest for one stock is calculated and shown in the Gui.
        /// </summary>
        private void BacktestData()
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
            lbl_Value_CAGR.Text = string.Format("{0:N1}", _backtest.Cagr(_dataList,_datePicker.StartDate, _datePicker.EndDate));
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
            InitializeAttributes();
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
            cartesianChart1.Show();
            cartesianChart2.Show();
            cartesianChart1.Series.Clear();
            cartesianChart2.Series.Clear();

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
            _datePicker.StartDate = dtp_Start_Date.Value ;
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
            cartesianChart1.Show();
            cartesianChart2.Show();

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
            cartesianChart1.Hide();
            cartesianChart2.Hide();

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
