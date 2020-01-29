namespace GraphProject
{
    partial class MultipleBacktests
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleBacktests));
            this.lbx_Multiple_Backtest_Result = new System.Windows.Forms.ListBox();
            this.lbx_BackTest_Final = new System.Windows.Forms.ListBox();
            this.lbl_AlgoName = new System.Windows.Forms.Label();
            this.lbl_Ticker = new System.Windows.Forms.Label();
            this.lbl_TimeSpan = new System.Windows.Forms.Label();
            this.lbl_Return_SEK = new System.Windows.Forms.Label();
            this.lbl_Return_Procent = new System.Windows.Forms.Label();
            this.lbl_Number_Trades = new System.Windows.Forms.Label();
            this.lbl_Winners = new System.Windows.Forms.Label();
            this.lbl_Avg_Gain = new System.Windows.Forms.Label();
            this.lbl_Avg_Loss = new System.Windows.Forms.Label();
            this.lbl_Gain_Loss = new System.Windows.Forms.Label();
            this.lbl_Cagr = new System.Windows.Forms.Label();
            this.lbl_Sharp_Ratio = new System.Windows.Forms.Label();
            this.lbl_Max_DrawDown_Percent = new System.Windows.Forms.Label();
            this.lbl_Value_Start = new System.Windows.Forms.Label();
            this.lbl_Value_End = new System.Windows.Forms.Label();
            this.lbl_Agorithm_Final = new System.Windows.Forms.Label();
            this.lbl_Avg_Return_Percent = new System.Windows.Forms.Label();
            this.lbl_Avg_Winners_Percent = new System.Windows.Forms.Label();
            this.lbl_Total_Nbr_Trades = new System.Windows.Forms.Label();
            this.lbl_Avg_Max_DrawDown = new System.Windows.Forms.Label();
            this.lbl_Summary = new System.Windows.Forms.Label();
            this.lbl_Avg_Gain_Loss = new System.Windows.Forms.Label();
            this.lbl_Avg_AvgGain_Div_AvgLoss = new System.Windows.Forms.Label();
            this.lbl_Percent_Profitable_Backtests = new System.Windows.Forms.Label();
            this.lbl_Good_Sharp_Ratio = new System.Windows.Forms.Label();
            this.lbl_Small_Drawdowns = new System.Windows.Forms.Label();
            this.lbl_Good_Profitfactors = new System.Windows.Forms.Label();
            this.lbl_Average_Profit_Trade = new System.Windows.Forms.Label();
            this.lbl_Text_String_Demand = new System.Windows.Forms.Label();
            this.lbl_Text_String_Actual = new System.Windows.Forms.Label();
            this.lbl_Text_String_Final = new System.Windows.Forms.Label();
            this.lbl_String_text_Pass_Or_Fail = new System.Windows.Forms.Label();
            this.lbl_Text_String_Final_Status = new System.Windows.Forms.Label();
            this.lbl_Summary_Pass_Or_Fail = new System.Windows.Forms.Label();
            this.lbl_Multiple_Backtests = new System.Windows.Forms.Label();
            this.btn_Backtest_Stocks_2ndGui = new System.Windows.Forms.Button();
            this.cbx_Backtest_PreSelect_Periods = new System.Windows.Forms.ComboBox();
            this.lbl_Backtest_PreSelected_Periods = new System.Windows.Forms.Label();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.cbx_Algo_Multiple_Backtests = new System.Windows.Forms.ComboBox();
            this.lbl_Select_Algo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbx_Multiple_Backtest_Result
            // 
            this.lbx_Multiple_Backtest_Result.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbx_Multiple_Backtest_Result.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_Multiple_Backtest_Result.ForeColor = System.Drawing.Color.White;
            this.lbx_Multiple_Backtest_Result.FormattingEnabled = true;
            this.lbx_Multiple_Backtest_Result.Location = new System.Drawing.Point(31, 194);
            this.lbx_Multiple_Backtest_Result.Name = "lbx_Multiple_Backtest_Result";
            this.lbx_Multiple_Backtest_Result.Size = new System.Drawing.Size(1297, 199);
            this.lbx_Multiple_Backtest_Result.TabIndex = 0;
            // 
            // lbx_BackTest_Final
            // 
            this.lbx_BackTest_Final.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbx_BackTest_Final.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_BackTest_Final.ForeColor = System.Drawing.Color.White;
            this.lbx_BackTest_Final.FormattingEnabled = true;
            this.lbx_BackTest_Final.Location = new System.Drawing.Point(30, 522);
            this.lbx_BackTest_Final.Name = "lbx_BackTest_Final";
            this.lbx_BackTest_Final.Size = new System.Drawing.Size(1297, 43);
            this.lbx_BackTest_Final.TabIndex = 1;
            // 
            // lbl_AlgoName
            // 
            this.lbl_AlgoName.AutoSize = true;
            this.lbl_AlgoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AlgoName.ForeColor = System.Drawing.Color.White;
            this.lbl_AlgoName.Location = new System.Drawing.Point(28, 151);
            this.lbl_AlgoName.Name = "lbl_AlgoName";
            this.lbl_AlgoName.Size = new System.Drawing.Size(61, 12);
            this.lbl_AlgoName.TabIndex = 2;
            this.lbl_AlgoName.Text = "Algorithm :";
            // 
            // lbl_Ticker
            // 
            this.lbl_Ticker.AutoSize = true;
            this.lbl_Ticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ticker.ForeColor = System.Drawing.Color.White;
            this.lbl_Ticker.Location = new System.Drawing.Point(151, 151);
            this.lbl_Ticker.Name = "lbl_Ticker";
            this.lbl_Ticker.Size = new System.Drawing.Size(43, 12);
            this.lbl_Ticker.TabIndex = 3;
            this.lbl_Ticker.Text = "Ticker :";
            // 
            // lbl_TimeSpan
            // 
            this.lbl_TimeSpan.AutoSize = true;
            this.lbl_TimeSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeSpan.ForeColor = System.Drawing.Color.White;
            this.lbl_TimeSpan.Location = new System.Drawing.Point(209, 151);
            this.lbl_TimeSpan.Name = "lbl_TimeSpan";
            this.lbl_TimeSpan.Size = new System.Drawing.Size(60, 12);
            this.lbl_TimeSpan.TabIndex = 4;
            this.lbl_TimeSpan.Text = "Timespan :";
            // 
            // lbl_Return_SEK
            // 
            this.lbl_Return_SEK.AutoSize = true;
            this.lbl_Return_SEK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Return_SEK.ForeColor = System.Drawing.Color.White;
            this.lbl_Return_SEK.Location = new System.Drawing.Point(583, 151);
            this.lbl_Return_SEK.Name = "lbl_Return_SEK";
            this.lbl_Return_SEK.Size = new System.Drawing.Size(42, 24);
            this.lbl_Return_SEK.TabIndex = 5;
            this.lbl_Return_SEK.Text = "Return \r\n(SEK) :";
            // 
            // lbl_Return_Procent
            // 
            this.lbl_Return_Procent.AutoSize = true;
            this.lbl_Return_Procent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Return_Procent.ForeColor = System.Drawing.Color.White;
            this.lbl_Return_Procent.Location = new System.Drawing.Point(672, 151);
            this.lbl_Return_Procent.Name = "lbl_Return_Procent";
            this.lbl_Return_Procent.Size = new System.Drawing.Size(42, 24);
            this.lbl_Return_Procent.TabIndex = 6;
            this.lbl_Return_Procent.Text = "Return \r\n(%) :";
            // 
            // lbl_Number_Trades
            // 
            this.lbl_Number_Trades.AutoSize = true;
            this.lbl_Number_Trades.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Number_Trades.ForeColor = System.Drawing.Color.White;
            this.lbl_Number_Trades.Location = new System.Drawing.Point(749, 151);
            this.lbl_Number_Trades.Name = "lbl_Number_Trades";
            this.lbl_Number_Trades.Size = new System.Drawing.Size(44, 24);
            this.lbl_Number_Trades.TabIndex = 7;
            this.lbl_Number_Trades.Text = "Nbr \r\ntrades :";
            // 
            // lbl_Winners
            // 
            this.lbl_Winners.AutoSize = true;
            this.lbl_Winners.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Winners.ForeColor = System.Drawing.Color.White;
            this.lbl_Winners.Location = new System.Drawing.Point(814, 151);
            this.lbl_Winners.Name = "lbl_Winners";
            this.lbl_Winners.Size = new System.Drawing.Size(49, 24);
            this.lbl_Winners.TabIndex = 8;
            this.lbl_Winners.Text = "Winners \r\n(%) :";
            // 
            // lbl_Avg_Gain
            // 
            this.lbl_Avg_Gain.AutoSize = true;
            this.lbl_Avg_Gain.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_Gain.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_Gain.Location = new System.Drawing.Point(882, 151);
            this.lbl_Avg_Gain.Name = "lbl_Avg_Gain";
            this.lbl_Avg_Gain.Size = new System.Drawing.Size(53, 24);
            this.lbl_Avg_Gain.TabIndex = 9;
            this.lbl_Avg_Gain.Text = "Avg gain \r\n(SEK) :";
            // 
            // lbl_Avg_Loss
            // 
            this.lbl_Avg_Loss.AutoSize = true;
            this.lbl_Avg_Loss.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_Loss.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_Loss.Location = new System.Drawing.Point(961, 151);
            this.lbl_Avg_Loss.Name = "lbl_Avg_Loss";
            this.lbl_Avg_Loss.Size = new System.Drawing.Size(53, 24);
            this.lbl_Avg_Loss.TabIndex = 10;
            this.lbl_Avg_Loss.Text = "Avg loss \r\n(SEK) :";
            // 
            // lbl_Gain_Loss
            // 
            this.lbl_Gain_Loss.AutoSize = true;
            this.lbl_Gain_Loss.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gain_Loss.ForeColor = System.Drawing.Color.White;
            this.lbl_Gain_Loss.Location = new System.Drawing.Point(1037, 151);
            this.lbl_Gain_Loss.Name = "lbl_Gain_Loss";
            this.lbl_Gain_Loss.Size = new System.Drawing.Size(40, 24);
            this.lbl_Gain_Loss.TabIndex = 11;
            this.lbl_Gain_Loss.Text = "Gain\r\n/Loss :";
            // 
            // lbl_Cagr
            // 
            this.lbl_Cagr.AutoSize = true;
            this.lbl_Cagr.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cagr.ForeColor = System.Drawing.Color.White;
            this.lbl_Cagr.Location = new System.Drawing.Point(1102, 151);
            this.lbl_Cagr.Name = "lbl_Cagr";
            this.lbl_Cagr.Size = new System.Drawing.Size(32, 24);
            this.lbl_Cagr.TabIndex = 12;
            this.lbl_Cagr.Text = "Cagr \r\n(%) :";
            // 
            // lbl_Sharp_Ratio
            // 
            this.lbl_Sharp_Ratio.AutoSize = true;
            this.lbl_Sharp_Ratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sharp_Ratio.ForeColor = System.Drawing.Color.White;
            this.lbl_Sharp_Ratio.Location = new System.Drawing.Point(1163, 151);
            this.lbl_Sharp_Ratio.Name = "lbl_Sharp_Ratio";
            this.lbl_Sharp_Ratio.Size = new System.Drawing.Size(39, 24);
            this.lbl_Sharp_Ratio.TabIndex = 13;
            this.lbl_Sharp_Ratio.Text = "Sharp \r\nRatio :";
            // 
            // lbl_Max_DrawDown_Percent
            // 
            this.lbl_Max_DrawDown_Percent.AutoSize = true;
            this.lbl_Max_DrawDown_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Max_DrawDown_Percent.ForeColor = System.Drawing.Color.White;
            this.lbl_Max_DrawDown_Percent.Location = new System.Drawing.Point(1230, 151);
            this.lbl_Max_DrawDown_Percent.Name = "lbl_Max_DrawDown_Percent";
            this.lbl_Max_DrawDown_Percent.Size = new System.Drawing.Size(86, 24);
            this.lbl_Max_DrawDown_Percent.TabIndex = 14;
            this.lbl_Max_DrawDown_Percent.Text = "Max \r\nDrawdown (%) :";
            // 
            // lbl_Value_Start
            // 
            this.lbl_Value_Start.AutoSize = true;
            this.lbl_Value_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Start.ForeColor = System.Drawing.Color.White;
            this.lbl_Value_Start.Location = new System.Drawing.Point(401, 151);
            this.lbl_Value_Start.Name = "lbl_Value_Start";
            this.lbl_Value_Start.Size = new System.Drawing.Size(68, 24);
            this.lbl_Value_Start.TabIndex = 15;
            this.lbl_Value_Start.Text = "Value \r\nstart (SEK) :";
            // 
            // lbl_Value_End
            // 
            this.lbl_Value_End.AutoSize = true;
            this.lbl_Value_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_End.ForeColor = System.Drawing.Color.White;
            this.lbl_Value_End.Location = new System.Drawing.Point(494, 151);
            this.lbl_Value_End.Name = "lbl_Value_End";
            this.lbl_Value_End.Size = new System.Drawing.Size(62, 24);
            this.lbl_Value_End.TabIndex = 16;
            this.lbl_Value_End.Text = "Value \r\nend (SEK) :";
            // 
            // lbl_Agorithm_Final
            // 
            this.lbl_Agorithm_Final.AutoSize = true;
            this.lbl_Agorithm_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Agorithm_Final.ForeColor = System.Drawing.Color.White;
            this.lbl_Agorithm_Final.Location = new System.Drawing.Point(28, 482);
            this.lbl_Agorithm_Final.Name = "lbl_Agorithm_Final";
            this.lbl_Agorithm_Final.Size = new System.Drawing.Size(61, 12);
            this.lbl_Agorithm_Final.TabIndex = 17;
            this.lbl_Agorithm_Final.Text = "Algorithm :";
            // 
            // lbl_Avg_Return_Percent
            // 
            this.lbl_Avg_Return_Percent.AutoSize = true;
            this.lbl_Avg_Return_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_Return_Percent.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_Return_Percent.Location = new System.Drawing.Point(164, 482);
            this.lbl_Avg_Return_Percent.Name = "lbl_Avg_Return_Percent";
            this.lbl_Avg_Return_Percent.Size = new System.Drawing.Size(59, 24);
            this.lbl_Avg_Return_Percent.TabIndex = 18;
            this.lbl_Avg_Return_Percent.Text = "Avg return\r\n(%) :";
            // 
            // lbl_Avg_Winners_Percent
            // 
            this.lbl_Avg_Winners_Percent.AutoSize = true;
            this.lbl_Avg_Winners_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_Winners_Percent.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_Winners_Percent.Location = new System.Drawing.Point(254, 482);
            this.lbl_Avg_Winners_Percent.Name = "lbl_Avg_Winners_Percent";
            this.lbl_Avg_Winners_Percent.Size = new System.Drawing.Size(69, 24);
            this.lbl_Avg_Winners_Percent.TabIndex = 19;
            this.lbl_Avg_Winners_Percent.Text = "Avg winners\r\n(%) :";
            // 
            // lbl_Total_Nbr_Trades
            // 
            this.lbl_Total_Nbr_Trades.AutoSize = true;
            this.lbl_Total_Nbr_Trades.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total_Nbr_Trades.ForeColor = System.Drawing.Color.White;
            this.lbl_Total_Nbr_Trades.Location = new System.Drawing.Point(351, 482);
            this.lbl_Total_Nbr_Trades.Name = "lbl_Total_Nbr_Trades";
            this.lbl_Total_Nbr_Trades.Size = new System.Drawing.Size(57, 24);
            this.lbl_Total_Nbr_Trades.TabIndex = 20;
            this.lbl_Total_Nbr_Trades.Text = "Total nbr\r\nof trades :";
            // 
            // lbl_Avg_Max_DrawDown
            // 
            this.lbl_Avg_Max_DrawDown.AutoSize = true;
            this.lbl_Avg_Max_DrawDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_Max_DrawDown.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_Max_DrawDown.Location = new System.Drawing.Point(438, 482);
            this.lbl_Avg_Max_DrawDown.Name = "lbl_Avg_Max_DrawDown";
            this.lbl_Avg_Max_DrawDown.Size = new System.Drawing.Size(84, 24);
            this.lbl_Avg_Max_DrawDown.TabIndex = 21;
            this.lbl_Avg_Max_DrawDown.Text = "Avg max\r\ndrawdown (%) :";
            // 
            // lbl_Summary
            // 
            this.lbl_Summary.AutoSize = true;
            this.lbl_Summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Summary.ForeColor = System.Drawing.Color.White;
            this.lbl_Summary.Location = new System.Drawing.Point(28, 441);
            this.lbl_Summary.Name = "lbl_Summary";
            this.lbl_Summary.Size = new System.Drawing.Size(126, 16);
            this.lbl_Summary.TabIndex = 22;
            this.lbl_Summary.Text = "Result summary :\r\n";
            // 
            // lbl_Avg_Gain_Loss
            // 
            this.lbl_Avg_Gain_Loss.AutoSize = true;
            this.lbl_Avg_Gain_Loss.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_Gain_Loss.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_Gain_Loss.Location = new System.Drawing.Point(634, 482);
            this.lbl_Avg_Gain_Loss.Name = "lbl_Avg_Gain_Loss";
            this.lbl_Avg_Gain_Loss.Size = new System.Drawing.Size(57, 24);
            this.lbl_Avg_Gain_Loss.TabIndex = 24;
            this.lbl_Avg_Gain_Loss.Text = "Avg gain /\r\nloss :";
            // 
            // lbl_Avg_AvgGain_Div_AvgLoss
            // 
            this.lbl_Avg_AvgGain_Div_AvgLoss.AutoSize = true;
            this.lbl_Avg_AvgGain_Div_AvgLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Avg_AvgGain_Div_AvgLoss.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg_AvgGain_Div_AvgLoss.Location = new System.Drawing.Point(720, 482);
            this.lbl_Avg_AvgGain_Div_AvgLoss.Name = "lbl_Avg_AvgGain_Div_AvgLoss";
            this.lbl_Avg_AvgGain_Div_AvgLoss.Size = new System.Drawing.Size(88, 24);
            this.lbl_Avg_AvgGain_Div_AvgLoss.TabIndex = 25;
            this.lbl_Avg_AvgGain_Div_AvgLoss.Text = "Avg of avg gain \r\n / avg loss :";
            // 
            // lbl_Percent_Profitable_Backtests
            // 
            this.lbl_Percent_Profitable_Backtests.AutoSize = true;
            this.lbl_Percent_Profitable_Backtests.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Percent_Profitable_Backtests.ForeColor = System.Drawing.Color.White;
            this.lbl_Percent_Profitable_Backtests.Location = new System.Drawing.Point(836, 482);
            this.lbl_Percent_Profitable_Backtests.Name = "lbl_Percent_Profitable_Backtests";
            this.lbl_Percent_Profitable_Backtests.Size = new System.Drawing.Size(82, 24);
            this.lbl_Percent_Profitable_Backtests.TabIndex = 26;
            this.lbl_Percent_Profitable_Backtests.Text = "Profitable\r\nbacktests (%) :";
            // 
            // lbl_Good_Sharp_Ratio
            // 
            this.lbl_Good_Sharp_Ratio.AutoSize = true;
            this.lbl_Good_Sharp_Ratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Good_Sharp_Ratio.ForeColor = System.Drawing.Color.White;
            this.lbl_Good_Sharp_Ratio.Location = new System.Drawing.Point(947, 482);
            this.lbl_Good_Sharp_Ratio.Name = "lbl_Good_Sharp_Ratio";
            this.lbl_Good_Sharp_Ratio.Size = new System.Drawing.Size(66, 24);
            this.lbl_Good_Sharp_Ratio.TabIndex = 27;
            this.lbl_Good_Sharp_Ratio.Text = "Sharp ratios\r\n> 0.8 (%) :";
            // 
            // lbl_Small_Drawdowns
            // 
            this.lbl_Small_Drawdowns.AutoSize = true;
            this.lbl_Small_Drawdowns.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Small_Drawdowns.ForeColor = System.Drawing.Color.White;
            this.lbl_Small_Drawdowns.Location = new System.Drawing.Point(1046, 482);
            this.lbl_Small_Drawdowns.Name = "lbl_Small_Drawdowns";
            this.lbl_Small_Drawdowns.Size = new System.Drawing.Size(94, 24);
            this.lbl_Small_Drawdowns.TabIndex = 28;
            this.lbl_Small_Drawdowns.Text = "Drawdowns\r\n< 25 percent (%) :";
            // 
            // lbl_Good_Profitfactors
            // 
            this.lbl_Good_Profitfactors.AutoSize = true;
            this.lbl_Good_Profitfactors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Good_Profitfactors.ForeColor = System.Drawing.Color.White;
            this.lbl_Good_Profitfactors.Location = new System.Drawing.Point(1171, 482);
            this.lbl_Good_Profitfactors.Name = "lbl_Good_Profitfactors";
            this.lbl_Good_Profitfactors.Size = new System.Drawing.Size(66, 24);
            this.lbl_Good_Profitfactors.TabIndex = 29;
            this.lbl_Good_Profitfactors.Text = "Profit factor\r\n> 2 (%) :";
            // 
            // lbl_Average_Profit_Trade
            // 
            this.lbl_Average_Profit_Trade.AutoSize = true;
            this.lbl_Average_Profit_Trade.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Average_Profit_Trade.ForeColor = System.Drawing.Color.White;
            this.lbl_Average_Profit_Trade.Location = new System.Drawing.Point(548, 482);
            this.lbl_Average_Profit_Trade.Name = "lbl_Average_Profit_Trade";
            this.lbl_Average_Profit_Trade.Size = new System.Drawing.Size(59, 24);
            this.lbl_Average_Profit_Trade.TabIndex = 30;
            this.lbl_Average_Profit_Trade.Text = "Avg return\r\ntrade (%) :";
            // 
            // lbl_Text_String_Demand
            // 
            this.lbl_Text_String_Demand.AutoSize = true;
            this.lbl_Text_String_Demand.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Text_String_Demand.ForeColor = System.Drawing.Color.White;
            this.lbl_Text_String_Demand.Location = new System.Drawing.Point(28, 651);
            this.lbl_Text_String_Demand.Name = "lbl_Text_String_Demand";
            this.lbl_Text_String_Demand.Size = new System.Drawing.Size(276, 12);
            this.lbl_Text_String_Demand.TabIndex = 31;
            this.lbl_Text_String_Demand.Text = "Demand : Win percent must --> reward / risk ratio > B \r\n";
            // 
            // lbl_Text_String_Actual
            // 
            this.lbl_Text_String_Actual.AutoSize = true;
            this.lbl_Text_String_Actual.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Text_String_Actual.ForeColor = System.Drawing.Color.White;
            this.lbl_Text_String_Actual.Location = new System.Drawing.Point(492, 651);
            this.lbl_Text_String_Actual.Name = "lbl_Text_String_Actual";
            this.lbl_Text_String_Actual.Size = new System.Drawing.Size(220, 12);
            this.lbl_Text_String_Actual.TabIndex = 36;
            this.lbl_Text_String_Actual.Text = "Actual: reward / risk ratio , --> D % higher.";
            // 
            // lbl_Text_String_Final
            // 
            this.lbl_Text_String_Final.AutoSize = true;
            this.lbl_Text_String_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Text_String_Final.ForeColor = System.Drawing.Color.White;
            this.lbl_Text_String_Final.Location = new System.Drawing.Point(976, 651);
            this.lbl_Text_String_Final.Name = "lbl_Text_String_Final";
            this.lbl_Text_String_Final.Size = new System.Drawing.Size(187, 12);
            this.lbl_Text_String_Final.TabIndex = 37;
            this.lbl_Text_String_Final.Text = "Pass or fail: 4 of 5 demand passed   \r\n";
            // 
            // lbl_String_text_Pass_Or_Fail
            // 
            this.lbl_String_text_Pass_Or_Fail.AutoSize = true;
            this.lbl_String_text_Pass_Or_Fail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_String_text_Pass_Or_Fail.ForeColor = System.Drawing.Color.White;
            this.lbl_String_text_Pass_Or_Fail.Location = new System.Drawing.Point(1264, 652);
            this.lbl_String_text_Pass_Or_Fail.Name = "lbl_String_text_Pass_Or_Fail";
            this.lbl_String_text_Pass_Or_Fail.Size = new System.Drawing.Size(50, 13);
            this.lbl_String_text_Pass_Or_Fail.TabIndex = 38;
            this.lbl_String_text_Pass_Or_Fail.Text = "FAILED\r\n";
            // 
            // lbl_Text_String_Final_Status
            // 
            this.lbl_Text_String_Final_Status.AutoSize = true;
            this.lbl_Text_String_Final_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Text_String_Final_Status.ForeColor = System.Drawing.Color.White;
            this.lbl_Text_String_Final_Status.Location = new System.Drawing.Point(1204, 651);
            this.lbl_Text_String_Final_Status.Name = "lbl_Text_String_Final_Status";
            this.lbl_Text_String_Final_Status.Size = new System.Drawing.Size(45, 12);
            this.lbl_Text_String_Final_Status.TabIndex = 39;
            this.lbl_Text_String_Final_Status.Text = "Status :\r\n";
            // 
            // lbl_Summary_Pass_Or_Fail
            // 
            this.lbl_Summary_Pass_Or_Fail.AutoSize = true;
            this.lbl_Summary_Pass_Or_Fail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Summary_Pass_Or_Fail.ForeColor = System.Drawing.Color.White;
            this.lbl_Summary_Pass_Or_Fail.Location = new System.Drawing.Point(27, 607);
            this.lbl_Summary_Pass_Or_Fail.Name = "lbl_Summary_Pass_Or_Fail";
            this.lbl_Summary_Pass_Or_Fail.Size = new System.Drawing.Size(94, 16);
            this.lbl_Summary_Pass_Or_Fail.TabIndex = 40;
            this.lbl_Summary_Pass_Or_Fail.Text = "Pass or fail :\r\n";
            // 
            // lbl_Multiple_Backtests
            // 
            this.lbl_Multiple_Backtests.AutoSize = true;
            this.lbl_Multiple_Backtests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Multiple_Backtests.ForeColor = System.Drawing.Color.White;
            this.lbl_Multiple_Backtests.Location = new System.Drawing.Point(27, 104);
            this.lbl_Multiple_Backtests.Name = "lbl_Multiple_Backtests";
            this.lbl_Multiple_Backtests.Size = new System.Drawing.Size(141, 16);
            this.lbl_Multiple_Backtests.TabIndex = 41;
            this.lbl_Multiple_Backtests.Text = "Multiple backtests :\r\n";
            // 
            // btn_Backtest_Stocks_2ndGui
            // 
            this.btn_Backtest_Stocks_2ndGui.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Backtest_Stocks_2ndGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Backtest_Stocks_2ndGui.ForeColor = System.Drawing.Color.White;
            this.btn_Backtest_Stocks_2ndGui.Location = new System.Drawing.Point(30, 22);
            this.btn_Backtest_Stocks_2ndGui.Name = "btn_Backtest_Stocks_2ndGui";
            this.btn_Backtest_Stocks_2ndGui.Size = new System.Drawing.Size(182, 47);
            this.btn_Backtest_Stocks_2ndGui.TabIndex = 42;
            this.btn_Backtest_Stocks_2ndGui.Text = "Backtest stocks";
            this.btn_Backtest_Stocks_2ndGui.UseVisualStyleBackColor = false;
            this.btn_Backtest_Stocks_2ndGui.Click += new System.EventHandler(this.btn_Backtest_Stocks_2ndGui_Click);
            // 
            // cbx_Backtest_PreSelect_Periods
            // 
            this.cbx_Backtest_PreSelect_Periods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_Backtest_PreSelect_Periods.ForeColor = System.Drawing.Color.White;
            this.cbx_Backtest_PreSelect_Periods.FormattingEnabled = true;
            this.cbx_Backtest_PreSelect_Periods.Location = new System.Drawing.Point(600, 48);
            this.cbx_Backtest_PreSelect_Periods.Name = "cbx_Backtest_PreSelect_Periods";
            this.cbx_Backtest_PreSelect_Periods.Size = new System.Drawing.Size(208, 21);
            this.cbx_Backtest_PreSelect_Periods.TabIndex = 47;
            // 
            // lbl_Backtest_PreSelected_Periods
            // 
            this.lbl_Backtest_PreSelected_Periods.AutoSize = true;
            this.lbl_Backtest_PreSelected_Periods.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Backtest_PreSelected_Periods.ForeColor = System.Drawing.Color.White;
            this.lbl_Backtest_PreSelected_Periods.Location = new System.Drawing.Point(596, 22);
            this.lbl_Backtest_PreSelected_Periods.Name = "lbl_Backtest_PreSelected_Periods";
            this.lbl_Backtest_PreSelected_Periods.Size = new System.Drawing.Size(116, 12);
            this.lbl_Backtest_PreSelected_Periods.TabIndex = 48;
            this.lbl_Backtest_PreSelected_Periods.Text = "Pre-selected periods :";
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Loading.ForeColor = System.Drawing.Color.Lime;
            this.lbl_Loading.Location = new System.Drawing.Point(881, 48);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(75, 15);
            this.lbl_Loading.TabIndex = 49;
            this.lbl_Loading.Text = "Loading ...";
            this.lbl_Loading.Visible = false;
            // 
            // cbx_Algo_Multiple_Backtests
            // 
            this.cbx_Algo_Multiple_Backtests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_Algo_Multiple_Backtests.ForeColor = System.Drawing.Color.White;
            this.cbx_Algo_Multiple_Backtests.FormattingEnabled = true;
            this.cbx_Algo_Multiple_Backtests.Location = new System.Drawing.Point(314, 48);
            this.cbx_Algo_Multiple_Backtests.Name = "cbx_Algo_Multiple_Backtests";
            this.cbx_Algo_Multiple_Backtests.Size = new System.Drawing.Size(208, 21);
            this.cbx_Algo_Multiple_Backtests.TabIndex = 50;
            this.cbx_Algo_Multiple_Backtests.SelectedIndexChanged += new System.EventHandler(this.cbx_Algo_Multiple_Backtests_SelectedIndexChanged);
            // 
            // lbl_Select_Algo
            // 
            this.lbl_Select_Algo.AutoSize = true;
            this.lbl_Select_Algo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Select_Algo.ForeColor = System.Drawing.Color.White;
            this.lbl_Select_Algo.Location = new System.Drawing.Point(312, 22);
            this.lbl_Select_Algo.Name = "lbl_Select_Algo";
            this.lbl_Select_Algo.Size = new System.Drawing.Size(68, 12);
            this.lbl_Select_Algo.TabIndex = 51;
            this.lbl_Select_Algo.Text = "Select algo :";
            // 
            // MultipleBacktests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1354, 718);
            this.Controls.Add(this.lbl_Select_Algo);
            this.Controls.Add(this.cbx_Algo_Multiple_Backtests);
            this.Controls.Add(this.lbl_Loading);
            this.Controls.Add(this.lbl_Backtest_PreSelected_Periods);
            this.Controls.Add(this.cbx_Backtest_PreSelect_Periods);
            this.Controls.Add(this.btn_Backtest_Stocks_2ndGui);
            this.Controls.Add(this.lbl_Multiple_Backtests);
            this.Controls.Add(this.lbl_Summary_Pass_Or_Fail);
            this.Controls.Add(this.lbl_Text_String_Final_Status);
            this.Controls.Add(this.lbl_String_text_Pass_Or_Fail);
            this.Controls.Add(this.lbl_Text_String_Final);
            this.Controls.Add(this.lbl_Text_String_Actual);
            this.Controls.Add(this.lbl_Text_String_Demand);
            this.Controls.Add(this.lbl_Average_Profit_Trade);
            this.Controls.Add(this.lbl_Good_Profitfactors);
            this.Controls.Add(this.lbl_Small_Drawdowns);
            this.Controls.Add(this.lbl_Good_Sharp_Ratio);
            this.Controls.Add(this.lbl_Percent_Profitable_Backtests);
            this.Controls.Add(this.lbl_Avg_AvgGain_Div_AvgLoss);
            this.Controls.Add(this.lbl_Avg_Gain_Loss);
            this.Controls.Add(this.lbl_Summary);
            this.Controls.Add(this.lbl_Avg_Max_DrawDown);
            this.Controls.Add(this.lbl_Total_Nbr_Trades);
            this.Controls.Add(this.lbl_Avg_Winners_Percent);
            this.Controls.Add(this.lbl_Avg_Return_Percent);
            this.Controls.Add(this.lbl_Agorithm_Final);
            this.Controls.Add(this.lbl_Value_End);
            this.Controls.Add(this.lbl_Value_Start);
            this.Controls.Add(this.lbl_Max_DrawDown_Percent);
            this.Controls.Add(this.lbl_Sharp_Ratio);
            this.Controls.Add(this.lbl_Cagr);
            this.Controls.Add(this.lbl_Gain_Loss);
            this.Controls.Add(this.lbl_Avg_Loss);
            this.Controls.Add(this.lbl_Avg_Gain);
            this.Controls.Add(this.lbl_Winners);
            this.Controls.Add(this.lbl_Number_Trades);
            this.Controls.Add(this.lbl_Return_Procent);
            this.Controls.Add(this.lbl_Return_SEK);
            this.Controls.Add(this.lbl_TimeSpan);
            this.Controls.Add(this.lbl_Ticker);
            this.Controls.Add(this.lbl_AlgoName);
            this.Controls.Add(this.lbx_BackTest_Final);
            this.Controls.Add(this.lbx_Multiple_Backtest_Result);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultipleBacktests";
            this.Text = "MultipleBacktests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_Multiple_Backtest_Result;
        private System.Windows.Forms.ListBox lbx_BackTest_Final;
        private System.Windows.Forms.Label lbl_AlgoName;
        private System.Windows.Forms.Label lbl_Ticker;
        private System.Windows.Forms.Label lbl_TimeSpan;
        private System.Windows.Forms.Label lbl_Return_SEK;
        private System.Windows.Forms.Label lbl_Return_Procent;
        private System.Windows.Forms.Label lbl_Number_Trades;
        private System.Windows.Forms.Label lbl_Winners;
        private System.Windows.Forms.Label lbl_Avg_Gain;
        private System.Windows.Forms.Label lbl_Avg_Loss;
        private System.Windows.Forms.Label lbl_Gain_Loss;
        private System.Windows.Forms.Label lbl_Cagr;
        private System.Windows.Forms.Label lbl_Sharp_Ratio;
        private System.Windows.Forms.Label lbl_Max_DrawDown_Percent;
        private System.Windows.Forms.Label lbl_Value_Start;
        private System.Windows.Forms.Label lbl_Value_End;
        private System.Windows.Forms.Label lbl_Agorithm_Final;
        private System.Windows.Forms.Label lbl_Avg_Return_Percent;
        private System.Windows.Forms.Label lbl_Avg_Winners_Percent;
        private System.Windows.Forms.Label lbl_Total_Nbr_Trades;
        private System.Windows.Forms.Label lbl_Avg_Max_DrawDown;
        private System.Windows.Forms.Label lbl_Summary;
        private System.Windows.Forms.Label lbl_Avg_Gain_Loss;
        private System.Windows.Forms.Label lbl_Avg_AvgGain_Div_AvgLoss;
        private System.Windows.Forms.Label lbl_Percent_Profitable_Backtests;
        private System.Windows.Forms.Label lbl_Good_Sharp_Ratio;
        private System.Windows.Forms.Label lbl_Small_Drawdowns;
        private System.Windows.Forms.Label lbl_Good_Profitfactors;
        private System.Windows.Forms.Label lbl_Average_Profit_Trade;
        private System.Windows.Forms.Label lbl_Text_String_Demand;
        private System.Windows.Forms.Label lbl_Text_String_Actual;
        private System.Windows.Forms.Label lbl_Text_String_Final;
        private System.Windows.Forms.Label lbl_String_text_Pass_Or_Fail;
        private System.Windows.Forms.Label lbl_Text_String_Final_Status;
        private System.Windows.Forms.Label lbl_Summary_Pass_Or_Fail;
        private System.Windows.Forms.Label lbl_Multiple_Backtests;
        private System.Windows.Forms.Button btn_Backtest_Stocks_2ndGui;
        private System.Windows.Forms.ComboBox cbx_Backtest_PreSelect_Periods;
        private System.Windows.Forms.Label lbl_Backtest_PreSelected_Periods;
        private System.Windows.Forms.Label lbl_Loading;
        private System.Windows.Forms.ComboBox cbx_Algo_Multiple_Backtests;
        private System.Windows.Forms.Label lbl_Select_Algo;
    }
}