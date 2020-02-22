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
        private ImportFromSql _importFromSql;
        private List<DailyDataPoint> _dataList;

        private RsiManager _lastAverage;
        private int _lenghtMa200 = 200;
        private int _lenghtMa50 = 50;
        private int _lenghtMa20 = 20;
        private int _lenghtRsi = 5;

        private int _startDateIndex;
        private int _endDateIndex;
        private AlgoPicker _algoPicker;
        private string _algoName;
        private TradeManager _tradeManager;

        private BacktestPeriodPicker _backtestPeriodPicker;
        private List<OneStockBackTestData> _backTestList;
        private MultipleBacktestAnalyser _multipleBacktestAnalyser;
        private MultipleBacktestDemand _multiBacktestDemand;
        private Backtest _backtest;

        public delegate void guiAndThreads();
        guiAndThreads showLoading;
        guiAndThreads hideLoading;

        public MultipleBacktests()
        {
            InitializeComponent();
            FillComboboxGui();
            HideGui();
        }

        private void FillComboboxGui()
        {
            FillTestPeriodComboBox();
            FillAlgoComboBox();
        }

        private void FillTestPeriodComboBox()
        {
            cbx_Backtest_PreSelect_Periods.Items.Add("Backtest all data");
            cbx_Backtest_PreSelect_Periods.Items.Add("Backtest first 70 % as test data");
            cbx_Backtest_PreSelect_Periods.Items.Add("Backtest last 30 % as OS data");
            cbx_Backtest_PreSelect_Periods.SelectedIndex = 0;
        }

        private void FillAlgoComboBox()
        {
            var algoArray = Enum.GetNames(typeof(EnumOfAlgos));
            cbx_Algo_Multiple_Backtests.Items.AddRange(algoArray);
            cbx_Algo_Multiple_Backtests.SelectedIndex = 0;
        }

        private void HideGui()
        {
            lbl_String_text_Pass_Or_Fail.Hide();
            lbl_Text_String_Final_Status.Hide();
            lbl_Text_String_Final.Hide();
            lbl_Text_String_Actual.Hide();
            lbl_Text_String_Demand.Hide();
        }

        private void btn_Backtest_Stocks_2ndGui_Click(object sender, EventArgs e)
        {
            InitializeFields1();
            UpdateGui();
            Loading();
            Calculations();
            FillGui();
        }

        private void InitializeFields1()
        {
            _backTestList = new List<OneStockBackTestData>();
            _multipleBacktestAnalyser = new MultipleBacktestAnalyser(_backTestList, _algoName);
            _multiBacktestDemand = new MultipleBacktestDemand(_multipleBacktestAnalyser);
        }

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

        private void Calculations()
        {
            CalcBacktestForAllStocks();
            _multipleBacktestAnalyser.CalculateAllAverageBackTestValues();
            _multiBacktestDemand.CalcDemands();
        }

        private void CalcBacktestForAllStocks()
        {
            var allStockTickersArray = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));

            for (int i = 0; i < allStockTickersArray.Length; i++)
            {
                InitializeFields2();
                string stockName = allStockTickersArray[i].ToString();
                _dataList = _importFromSql.ImportStockData(stockName);
                VerifyData();
                BacktestPeriodPicker();
                BuyAndSellSignals(_dataList);
                OneStockBackTest(stockName);
            }
        }

        private void InitializeFields2()
        {
            _importFromSql = new ImportFromSql();
            _lastAverage = new RsiManager();
            _tradeManager = new TradeManager();
            _backtest = new Backtest(100000, 30000);
        }

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

        private void BacktestPeriodPicker()
        {
            _backtestPeriodPicker = new BacktestPeriodPicker(_dataList);
            _backtestPeriodPicker.PickIndexesForPeriod(cbx_Backtest_PreSelect_Periods.SelectedIndex);
            _startDateIndex = _backtestPeriodPicker.StartIndex;
            _endDateIndex = _backtestPeriodPicker.EndIndex;
        }

        private void BuyAndSellSignals(List<DailyDataPoint> listOfData)
        {
            _algoPicker = new AlgoPicker(listOfData, _algoName, _tradeManager);

            // Indicators need to be precalculated for all data before buy and sell signals for the chosen period.
            // Else, there would be a void for no data indicators in the chosen period. Ma200 need 200 days before first data point.
            for (int i = 0; i < listOfData.Count; i++)
            {
                CalcIndicators(listOfData, i);
            }

            for (int i = _startDateIndex; i < _endDateIndex + 1; i++)
            {
                _algoPicker.Index = i;
                AlgoBuy(listOfData, i, _algoPicker);
                AlgoSell(listOfData, i, _algoPicker);
            }
        }

        private void CalcIndicators(List<DailyDataPoint> listOfData, int i)
        {
            listOfData[i].RSI = (new RSI(listOfData, i, _lastAverage, _lenghtRsi)).CalculateRsi();
            listOfData[i].MA200 = (new MovingAverage(listOfData, i, _lenghtMa200)).CalculateMa();
            listOfData[i].MA50 = (new MovingAverage(listOfData, i, _lenghtMa50)).CalculateMa();
            listOfData[i].MA20 = (new MovingAverage(listOfData, i, _lenghtMa20)).CalculateMa();
        }

        private void AlgoBuy(List<DailyDataPoint> listOfData, int i, AlgoPicker _algoPicker)
        {
            // Last condition is because, can't buy untills tomorrows close
            if (_algoPicker.PickAlgoBuy() && _tradeManager.AddNewTradeOk())
                _tradeManager.AddTrade(new OneTrade { Buy = listOfData[i].Close, BuyDate = TimeTranslation2(listOfData[i].Date) });
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

        private void AlgoSell(List<DailyDataPoint> listOfData, int i, AlgoPicker _algoPicker)
        {
            if (_algoPicker.PickAlgoSell() && _tradeManager.UnFinishedTrade())
            {
                _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].Sell = listOfData[i].Close;
                _tradeManager.GetTradeList[_tradeManager.GetTradeList.Count - 1].SellDate = TimeTranslation2(listOfData[i].Date);
            }
        }

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
                _backTestList.Add(_backtest.GetOneStockBacktest(_tradeManager, _dataList, _algoName, stockName, _backtestPeriodPicker.GetStartDate(), _backtestPeriodPicker.GetEndDate()));
            }
        }

        private void FillGui()
        {
            FillBackTestListBox();
            FillBackTestAverageListbox();
            FillDemandStrings();
        }

        private void FillBackTestListBox()
        {
            _backTestList.Sort((x, y) => y.SharpRatio.CompareTo(x.SharpRatio));
            lbx_Multiple_Backtest_Result.Items.AddRange(_backTestList.ToArray());
        }

        private void FillBackTestAverageListbox()
        {
            lbx_BackTest_Final.Items.Add("");
            lbx_BackTest_Final.Items.Add(_multipleBacktestAnalyser.ToString());
        }

        private void FillDemandStrings()
        {
            ProfitDemand();
            AllDemands();
        }

        private void ProfitDemand()
        {
            lbl_Text_String_Demand.Text = _multiBacktestDemand.RewardRiskDemandString();
            lbl_Text_String_Actual.Text = _multiBacktestDemand.RewardRiskPerfString();
        }

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

        private void cbx_Algo_Multiple_Backtests_SelectedIndexChanged(object sender, EventArgs e)
        {
            _algoName = cbx_Algo_Multiple_Backtests.SelectedItem.ToString();
        }
    }
}
