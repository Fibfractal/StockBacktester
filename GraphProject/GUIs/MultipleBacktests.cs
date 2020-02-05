using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GraphProject
{
    /// <summary>
    /// This class presents a graphical user interface.
    /// The purpose of this class is to backtest all stocks in nastdaq100 with a
    /// a trading strategy. So the user can choose a trading strategy and a period
    /// to test it on. The user can test it on all the data, 70 % and 30 % of the data.
    /// The reason of the division of the data is to backtest and optimize on 70 %, 
    /// and se the result of it on the 30 % of the data. A backtest on all stocks will
    /// show a backtest for each stock in list with all it's key numbers. A mean or
    /// a summary will appear on those key numbers, below. Pre selected tresholds of
    /// the key numbers will then show if the strategy will PASS or FAIL the criteria.
    /// 
    /// The trading strategies and the criteria is created in the source code, by
    /// the user. Where, is explained in the summary the BacktestingProgram class.
    /// A future extension of the program can be to pick these in the Gui,
    /// example pick a MA or a RSI, and a Gain/Loss ratio treshold.
    /// </summary>
    public partial class MultipleBacktests : Form
    {
        // Data import from SQL to chart
        private ImportFromSql _importFromSql;
        private List<DailyDataPoint> _dataList;

        // Pre-calculated indicators
        private RsiManager _lastAverage;
        private int _lenghtMa200 = 200; // Is plotted
        private int _lenghtMa50 = 50;
        private int _lenghtMa20 = 20;
        private int _lenghtRsi = 5;

        // Trades and backtest
        private BacktestPeriodPicker _backtestPeriodPicker;
        private int _startDateIndex;
        private int _endDateIndex;
        private List<OneStockBackTestData> _backTestList;
        private MultipleBacktestAnalyser _multipleBacktestAnalyser;
        private MultipleBacktestDemand _multiBacktestDemand;
        private TradeManager _tradeManager;
        private Backtest _backtest;
        private AlgoPicker _algoPicker;
        private string _algoName;

        // Delagates
        public delegate void guiAndThreads();
        guiAndThreads showLoading;
        guiAndThreads hideLoading;

        /// <summary>
        /// The constructor creates the Gui and fills it with the
        /// initial settings.
        /// </summary>
        public MultipleBacktests()
        {
            InitializeComponent();
            FillComboboxGui();
            HideGui();
        }

        /// <summary>
        /// Creation of objects of all needed classes.
        /// </summary>
        private void InitializeAttributes()
        {
            _importFromSql = new ImportFromSql();
            _lastAverage = new RsiManager();
            _tradeManager = new TradeManager();
            _backtest = new Backtest(100000, 30000);
        }

        /// <summary>
        /// Fills the test period combobox with test periods.
        /// Fills the algo combobox with algorithms (algos).
        /// </summary>
        private void FillComboboxGui()
        {
            FillTestPeriodComboBox();
            FillAlgoComboBox();
        }

        /// <summary>
        /// Fills the test period combobox with test periods, and
        /// selects one as pre-selected.
        /// </summary>
        private void FillTestPeriodComboBox()
        {
            cbx_Backtest_PreSelect_Periods.Items.Add("Backtest all data");
            cbx_Backtest_PreSelect_Periods.Items.Add("Backtest first 70 % as test data");
            cbx_Backtest_PreSelect_Periods.Items.Add("Backtest last 30 % as OS data");
            cbx_Backtest_PreSelect_Periods.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the algo combobox with algorithms (algos), and
        /// selects one as pre-selected.
        /// </summary>
        private void FillAlgoComboBox()
        {
            var algoArray = Enum.GetNames(typeof(EnumOfAlgos));
            cbx_Algo_Multiple_Backtests.Items.AddRange(algoArray);
            cbx_Algo_Multiple_Backtests.SelectedIndex = 0;
        }

        /// <summary>
        /// Hide the result of the lower part of the Gui.
        /// </summary>
        private void HideGui()
        {
            lbl_String_text_Pass_Or_Fail.Hide();
            lbl_Text_String_Final_Status.Hide();
            lbl_Text_String_Final.Hide();
            lbl_Text_String_Actual.Hide();
            lbl_Text_String_Demand.Hide();
        }

        /// <summary>
        /// Depending on which backtest period is selected in the Gui, the method
        /// calculates the indexes of the start and end dates for that period.
        /// This period is used for all the backtests.
        /// </summary>
        private void BacktestPeriodPicker()
        {
            _backtestPeriodPicker = new BacktestPeriodPicker(_dataList);
            _backtestPeriodPicker.PickIndexesForPeriod(cbx_Backtest_PreSelect_Periods.SelectedIndex);
            _startDateIndex = _backtestPeriodPicker.StartIndex;
            _endDateIndex = _backtestPeriodPicker.EndIndex;
        }

        /// <summary>
        /// When the "Backtest stocks" button is pressed.
        /// The Gui gets updated and loads.
        /// Backtests for all stocks is calculated, and key numbers from these is calculated.
        /// The Gui is filled with the result.
        /// </summary>
        private void btn_Backtest_Stocks_2ndGui_Click(object sender, EventArgs e)
        {
            UpdateGui();
            Loading();
            Calculations();
            FillGui();
        }

        /// <summary>
        /// Some parts of the Gui is shown and others i cleared of data.
        /// </summary>
        private void UpdateGui()
        {
            lbl_String_text_Pass_Or_Fail.Show();
            lbl_Text_String_Final_Status.Show();
            lbl_Text_String_Final.Show();
            lbl_Text_String_Actual.Show();
            lbl_Text_String_Demand.Show();

            lbx_Multiple_Backtest_Result.Items.Clear();
            lbx_BackTest_Final.Items.Clear();
        }

        /// <summary>
        /// The backtest for all stocks are calculated.
        /// The key numbers for all backtests are calculated.
        /// The result of when the key numbers are tested against the
        /// demands are calculated.
        /// </summary>
        private void Calculations()
        {
            _backTestList = new List<OneStockBackTestData>();
            _multipleBacktestAnalyser = new MultipleBacktestAnalyser(_backTestList, _algoName);
            _multiBacktestDemand = new MultipleBacktestDemand(_multipleBacktestAnalyser);
            CalcBacktestStockList();
            CalcFinalBacktestStockList();
            CalcPassOrFailBacktestDemand();
        }

        /// <summary>
        /// A new thread is created when backtest calculations
        /// are loading.
        /// </summary>
        private void Loading()
        {
            showLoading = new guiAndThreads(ShowLoading);
            hideLoading = new guiAndThreads(HideLoading);
            MakeNewTread(LoadingThread);
        }

        /// <summary>
        /// When the calculations has finished, the result is
        /// presented in the Gui.
        /// </summary>
        private void FillGui()
        {
            FillBackTestListBox();
            FillBackTestFinalListbox();
            FillDemandStrings();
        }

        /// <summary>
        /// Gets all the stock tickers.
        /// Backtests all stocks, one by one.
        /// Gets the data from the SQL data base and verifies it.
        /// Does the backtest within the test period.
        /// Calculates the backtests.
        /// </summary>
        private void CalcBacktestStockList()
        {
            // All stock tickers in an array
            var stockArray = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));

            // Adding all backtests for all stocks
            for (int i = 0; i < stockArray.Length; i++)
            {
                // One backtest for one stock
                InitializeAttributes();
                string stockName = stockArray[i].ToString();
                _dataList = _importFromSql.ImportStockData(stockName);
                VerifyData();
                BacktestPeriodPicker();
                BuyAndSellSignals(_dataList);
                // One backtest added to backtest list
                OneStockBackTest(stockName);
            }
        }

        /// <summary>
        /// Imports data for one stock from the SQL data base, and verifies it.
        /// </summary>
        private void VerifyData()
        {
            try
            {
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
        /// Calculates all indicators for one stock.
        /// Makes all the trades from the buy and sell signals
        /// depending of the chosen algo.
        /// </summary>
        /// <param name="listOfData">Price and datetime data for one stock</param>
        private void BuyAndSellSignals(List<DailyDataPoint> listOfData)
        {
            // Create algopicker
            _algoPicker = new AlgoPicker(listOfData, _algoName, _tradeManager);

            // Indicators need to be precalculated for all data before buy and sell signals for the chosen period.
            // Else, there would be a void for no data indicators in the chosen period. Ma200 need 200 days before first data point.
            for (int i = 0; i < listOfData.Count; i++)
            {
                // Calculate Rsi and Ma
                CalcIndicators(listOfData, i);
            }

            // Go through stock data from database
            for (int i = _startDateIndex; i < _endDateIndex + 1; i++)
            {
                _algoPicker.Index = i;

                // Get and save buy signals
                AlgoBuy(listOfData, i, _algoPicker);

                // Get and save sell signals
                AlgoSell(listOfData, i, _algoPicker);
            }
        }

        /// <summary>
        /// Calculating the indicator values for an index 
        /// postion in that stock data.
        /// </summary>
        /// <param name="listOfData">One stock data</param>
        /// <param name="i">one index position of that stock data</param>
        private void CalcIndicators(List<DailyDataPoint> listOfData, int i)
        {
            // Calculate Rsi, Ma and Bollingerbands
            listOfData[i].RSI = (new RSI(listOfData, i, _lastAverage, _lenghtRsi)).CalculateRsi();
            listOfData[i].MA200 = (new MovingAverage(listOfData, i, _lenghtMa200)).CalculateMa();
            listOfData[i].MA50 = (new MovingAverage(listOfData, i, _lenghtMa50)).CalculateMa();
            listOfData[i].MA20 = (new MovingAverage(listOfData, i, _lenghtMa20)).CalculateMa();

            // These takes long time to calculate
            //listOfData[i].UpperBollingerBand = (new BollingerBands(listOfData, i, _lenghtMa200)).UpperBollingerBand();
        }

        /// <summary>
        /// Sees if there is a buysignal for that index postion of that stock.
        /// If so, adds the trade to the trade list.
        /// </summary>
        /// <param name="listOfData">one stock data</param>
        /// <param name="i">index in the stockdata</param>
        /// <param name="_algoPicker">chooses the algo</param>
        private void AlgoBuy(List<DailyDataPoint> listOfData, int i, AlgoPicker _algoPicker)
        {
            // Last condition is because, can't buy untills tomorrows close
            if (_algoPicker.PickAlgoBuy())
            {
                if (_tradeManager.AddNewTradeOk())
                {
                    _tradeManager.AddTrade(new OneTrade { Buy = listOfData[i].Close, BuyDate = TimeTranslation2(listOfData[i].Date) });
                }
            }
        }

        /// <summary>
        /// Sees if there is a sellsignal for that index position of that stock.
        /// If so takes the sell price and date, and checks it as an finished trade.
        /// </summary>
        /// <param name="listOfData">one stock data</param>
        /// <param name="i">index in the stockdata</param>
        /// <param name="_algoPicker">chooses the algo</param>
        private void AlgoSell(List<DailyDataPoint> listOfData, int i, AlgoPicker _algoPicker)
        {
            if (_algoPicker.PickAlgoSell())
            {
                if (_tradeManager.UnFinishedTrade())
                {
                    _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].Sell = listOfData[i].Close;
                    _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].SellDate = TimeTranslation2(listOfData[i].Date);
                }
            }
        }

        /// <summary>
        /// Calculates the backtest for one stock and adds it to
        /// the list of all backtests.
        /// </summary>
        /// <param name="stockName">the name of the stock</param>
        private void OneStockBackTest(string stockName)
        {
            for (int i = 0; i < _tradeManager.GetTradeList.Count; i++)
            {
                if (_tradeManager.GetTradeList[i].Finished)
                {
                    _backtest.ChangePortFolValue(_tradeManager, i);
                    _backtest.MaxDrawDown(i);
                }
            }

            if (_tradeManager.GetTradeList.Count > 0)
            {
                // Add one stock backtest to all stock testlist
                _backTestList.Add(_backtest.GetOneStockBacktest(_tradeManager, _dataList, _algoName, stockName, _backtestPeriodPicker.GetStartDate(), _backtestPeriodPicker.GetEndDate()));
            }
        }

        /// <summary>
        /// When a new algo is picked in the Gui, a new algoname is
        /// selected.
        /// </summary>
        private void cbx_Algo_Multiple_Backtests_SelectedIndexChanged(object sender, EventArgs e)
        {
            _algoName = cbx_Algo_Multiple_Backtests.SelectedItem.ToString();
        }

        /// <summary>
        /// All backtests are shown in the list in the Gui, and gets sorted 
        /// after a criteria before.
        /// </summary>
        private void FillBackTestListBox()
        {
            // Sort after best sharp ratio, descending
            _backTestList.Sort((x, y) => y.SharpRatio.CompareTo(x.SharpRatio));

            lbx_Multiple_Backtest_Result.Items.AddRange(_backTestList.ToArray());
        }

        /// <summary>
        /// The key numbers are calculated as averages of all backtests.
        /// </summary>
        private void CalcFinalBacktestStockList()
        {
            _multipleBacktestAnalyser.CalculateAllAverageBackTestValues();
        }

        /// <summary>
        /// The result of the calculated key numbers averages is shown in a
        /// list in the Gui.
        /// </summary>
        private void FillBackTestFinalListbox()
        {
            lbx_BackTest_Final.Items.Add("");
            lbx_BackTest_Final.Items.Add(_multipleBacktestAnalyser.ToString());
        }

        /// <summary>
        /// Calculations are made to see if the criteria for profitable and robust
        /// algo and backtest are fullfilled.
        /// </summary>
        private void CalcPassOrFailBacktestDemand()
        {
            _multiBacktestDemand.CalcDemands();
        }

        /// <summary>
        /// The result of testing the criteria is presented in the Gui.
        /// </summary>
        private void FillDemandStrings()
        {
            // Demand to be profitable
            ProfitDemand();

            // Pass or fail to be tradeable
            AllDemands();
        }

        /// <summary>
        /// Shows text strings, tells if the algo is profitable or not.
        /// </summary>
        private void ProfitDemand()
        {
            lbl_Text_String_Demand.Text = _multiBacktestDemand.RewardRiskDemandString();
            lbl_Text_String_Actual.Text = _multiBacktestDemand.RewardRiskPerfString();
        }

        /// <summary>
        /// Shows a text string, dependent if the algo PASS or FAIL the criteria set.
        /// </summary>
        private void AllDemands()
        {
            lbl_Text_String_Final.Text = _multiBacktestDemand.DemandNbrFilledString();

            if (_multiBacktestDemand.PassOrFail)
            {
                lbl_String_text_Pass_Or_Fail.ForeColor = Color.Green;
                lbl_String_text_Pass_Or_Fail.Text = "PASS";
            }
            else
            {
                lbl_String_text_Pass_Or_Fail.ForeColor = Color.Red;
                lbl_String_text_Pass_Or_Fail.Text = "FAIL";
            }
        }

        /// <summary>
        /// The text "Loading ..." is shown.
        /// </summary>
        private void ShowLoading()
        {
            lbl_Loading.Text = "Loading ...";
            lbl_Loading.Visible = true;
        }

        /// <summary>
        /// The text "Loading ..." is hidden.
        /// </summary>
        private void HideLoading()
        {
            lbl_Loading.Visible = false;
        }

        /// <summary>
        /// The showLoading and hideLoading delgates är invoked
        /// in a new thread. First to show a part in the Gui and
        /// then to hide it.
        /// </summary>
        private void LoadingThread()
        {
            this.Invoke(this.showLoading);
            System.Threading.Thread.Sleep(1500);
            this.Invoke(this.hideLoading);
        }

        /// <summary>
        /// A new thread is created.
        /// </summary>
        /// <param name="methodName">The method to run in the tread</param>
        private void MakeNewTread(Action methodName)
        {
            ThreadStart myThreadStart = new ThreadStart(methodName);
            Thread myThread = new Thread(myThreadStart);
            myThread.Start();
        }

        /// <summary>
        /// The date from API is correct, but have to add one year for
        /// adjust for the incorrect x-axel. So both match up.
        /// </summary>
        /// <param name="datePrice">The date for current price</param>
        /// <returns></returns>
        private DateTime TimeTranslation2(DateTime datePrice)
        {
            DateTime date = new DateTime(1971, 1, 1);
            DateTime date2 = new DateTime(1972, 1, 1);
            TimeSpan oneYear = date2 - date;
            DateTime newDate = datePrice + oneYear;

            return newDate;
        }
    }
}
