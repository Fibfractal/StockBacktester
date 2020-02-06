namespace GraphProject
{
    partial class GraphStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphStocks));
            this.StockChartGui = new LiveCharts.WinForms.CartesianChart();
            this.BacktestChartGui = new LiveCharts.WinForms.CartesianChart();
            this.lbl_Stock_Ticker = new System.Windows.Forms.Label();
            this.lbl_MA200 = new System.Windows.Forms.Label();
            this.lbl_Entry = new System.Windows.Forms.Label();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.lbl_PortfolioStart = new System.Windows.Forms.Label();
            this.lbl_PortfolioEnd = new System.Windows.Forms.Label();
            this.lbl_ReturnSek = new System.Windows.Forms.Label();
            this.lbl_ReturnProcent = new System.Windows.Forms.Label();
            this.lbl_WinnerProcent = new System.Windows.Forms.Label();
            this.gbx_Backtest = new System.Windows.Forms.GroupBox();
            this.lbl_Ticker = new System.Windows.Forms.Label();
            this.lbl_Value_Max_DrawDown = new System.Windows.Forms.Label();
            this.lbl_MaxDrawDown = new System.Windows.Forms.Label();
            this.lbl_Value_Sharp_Ratio = new System.Windows.Forms.Label();
            this.lbl_SharpRatio = new System.Windows.Forms.Label();
            this.lbl_Value_TimeSpan_Finish = new System.Windows.Forms.Label();
            this.lbl_Value_TimeSpan_Start = new System.Windows.Forms.Label();
            this.lbl_Period = new System.Windows.Forms.Label();
            this.lbl_Value_Ticker = new System.Windows.Forms.Label();
            this.lbl_Value_CAGR = new System.Windows.Forms.Label();
            this.lbl_Cagr = new System.Windows.Forms.Label();
            this.lbl_Value_Profit_Factor = new System.Windows.Forms.Label();
            this.lbl_Gain_Loss = new System.Windows.Forms.Label();
            this.lbl_Value_Avg_Loss = new System.Windows.Forms.Label();
            this.lbl_AverageLoss = new System.Windows.Forms.Label();
            this.lbl_Value_Avg_Gain = new System.Windows.Forms.Label();
            this.lbl_AverageGain = new System.Windows.Forms.Label();
            this.lbl_Value_Nbr_Trades = new System.Windows.Forms.Label();
            this.lbl_NumberOfTrades = new System.Windows.Forms.Label();
            this.lbl_Value_Winners_Procent = new System.Windows.Forms.Label();
            this.lbl_Value_Return_Procent = new System.Windows.Forms.Label();
            this.lbl_Value_Return_Sek = new System.Windows.Forms.Label();
            this.lbl_Value_Portfolio_End = new System.Windows.Forms.Label();
            this.lbl_ValuePortfolio_Start = new System.Windows.Forms.Label();
            this.lbl_NewHigh = new System.Windows.Forms.Label();
            this.lbl_Show_Point_MaxDrawDown = new System.Windows.Forms.Label();
            this.lbx_StockList = new System.Windows.Forms.ListBox();
            this.btn_Backtest_Multiple_Stocks = new System.Windows.Forms.Button();
            this.cbx_Pick_Algo = new System.Windows.Forms.ComboBox();
            this.pcbx_Loading_Sequence = new System.Windows.Forms.PictureBox();
            this.lbl_Updating = new System.Windows.Forms.Label();
            this.dtp_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.dtp_End_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_Date_Start = new System.Windows.Forms.Label();
            this.lbl_Date_End = new System.Windows.Forms.Label();
            this.mst_Menu = new System.Windows.Forms.MenuStrip();
            this.mst_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mst_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mst_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.mst_Tools_Hide_Show_Chart = new System.Windows.Forms.ToolStripMenuItem();
            this.mst_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.mst_Update_Pick = new System.Windows.Forms.ToolStripMenuItem();
            this.gbx_Backtest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Loading_Sequence)).BeginInit();
            this.mst_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.StockChartGui.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StockChartGui.BackColorTransparent = true;
            this.StockChartGui.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StockChartGui.Location = new System.Drawing.Point(252, 62);
            this.StockChartGui.Name = "cartesianChart1";
            this.StockChartGui.Size = new System.Drawing.Size(925, 423);
            this.StockChartGui.TabIndex = 0;
            this.StockChartGui.Text = "cartesianChart1";
            // 
            // cartesianChart2
            // 
            this.BacktestChartGui.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BacktestChartGui.Location = new System.Drawing.Point(234, 524);
            this.BacktestChartGui.Name = "cartesianChart2";
            this.BacktestChartGui.Size = new System.Drawing.Size(925, 185);
            this.BacktestChartGui.TabIndex = 1;
            this.BacktestChartGui.Text = "cartesianChart2";
            // 
            // lbl_Stock_Ticker
            // 
            this.lbl_Stock_Ticker.AutoSize = true;
            this.lbl_Stock_Ticker.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Stock_Ticker.Font = new System.Drawing.Font("Franklin Gothic Medium", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Stock_Ticker.ForeColor = System.Drawing.Color.White;
            this.lbl_Stock_Ticker.Location = new System.Drawing.Point(303, 14);
            this.lbl_Stock_Ticker.Name = "lbl_Stock_Ticker";
            this.lbl_Stock_Ticker.Size = new System.Drawing.Size(0, 50);
            this.lbl_Stock_Ticker.TabIndex = 2;
            // 
            // lbl_MA200
            // 
            this.lbl_MA200.AutoSize = true;
            this.lbl_MA200.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MA200.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MA200.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_MA200.Location = new System.Drawing.Point(563, 42);
            this.lbl_MA200.Name = "lbl_MA200";
            this.lbl_MA200.Size = new System.Drawing.Size(59, 17);
            this.lbl_MA200.TabIndex = 3;
            this.lbl_MA200.Text = "- MA 200";
            // 
            // lbl_Entry
            // 
            this.lbl_Entry.AutoSize = true;
            this.lbl_Entry.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Entry.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Entry.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Entry.Location = new System.Drawing.Point(435, 42);
            this.lbl_Entry.Name = "lbl_Entry";
            this.lbl_Entry.Size = new System.Drawing.Size(46, 17);
            this.lbl_Entry.TabIndex = 4;
            this.lbl_Entry.Text = "* Entry";
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Exit.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Exit.ForeColor = System.Drawing.Color.Red;
            this.lbl_Exit.Location = new System.Drawing.Point(498, 42);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(38, 17);
            this.lbl_Exit.TabIndex = 5;
            this.lbl_Exit.Text = "* Exit";
            // 
            // lbl_PortfolioStart
            // 
            this.lbl_PortfolioStart.AutoSize = true;
            this.lbl_PortfolioStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PortfolioStart.ForeColor = System.Drawing.Color.White;
            this.lbl_PortfolioStart.Location = new System.Drawing.Point(18, 139);
            this.lbl_PortfolioStart.Name = "lbl_PortfolioStart";
            this.lbl_PortfolioStart.Size = new System.Drawing.Size(95, 13);
            this.lbl_PortfolioStart.TabIndex = 7;
            this.lbl_PortfolioStart.Text = "Portfolio start : ";
            // 
            // lbl_PortfolioEnd
            // 
            this.lbl_PortfolioEnd.AutoSize = true;
            this.lbl_PortfolioEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PortfolioEnd.ForeColor = System.Drawing.Color.White;
            this.lbl_PortfolioEnd.Location = new System.Drawing.Point(18, 185);
            this.lbl_PortfolioEnd.Name = "lbl_PortfolioEnd";
            this.lbl_PortfolioEnd.Size = new System.Drawing.Size(87, 13);
            this.lbl_PortfolioEnd.TabIndex = 8;
            this.lbl_PortfolioEnd.Text = "Portfolio end :";
            // 
            // lbl_ReturnSek
            // 
            this.lbl_ReturnSek.AutoSize = true;
            this.lbl_ReturnSek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReturnSek.ForeColor = System.Drawing.Color.White;
            this.lbl_ReturnSek.Location = new System.Drawing.Point(18, 232);
            this.lbl_ReturnSek.Name = "lbl_ReturnSek";
            this.lbl_ReturnSek.Size = new System.Drawing.Size(89, 13);
            this.lbl_ReturnSek.TabIndex = 9;
            this.lbl_ReturnSek.Text = "Return (SEK) :";
            // 
            // lbl_ReturnProcent
            // 
            this.lbl_ReturnProcent.AutoSize = true;
            this.lbl_ReturnProcent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReturnProcent.ForeColor = System.Drawing.Color.White;
            this.lbl_ReturnProcent.Location = new System.Drawing.Point(18, 279);
            this.lbl_ReturnProcent.Name = "lbl_ReturnProcent";
            this.lbl_ReturnProcent.Size = new System.Drawing.Size(74, 13);
            this.lbl_ReturnProcent.TabIndex = 10;
            this.lbl_ReturnProcent.Text = "Return (%) :";
            // 
            // lbl_WinnerProcent
            // 
            this.lbl_WinnerProcent.AutoSize = true;
            this.lbl_WinnerProcent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WinnerProcent.ForeColor = System.Drawing.Color.White;
            this.lbl_WinnerProcent.Location = new System.Drawing.Point(18, 367);
            this.lbl_WinnerProcent.Name = "lbl_WinnerProcent";
            this.lbl_WinnerProcent.Size = new System.Drawing.Size(82, 13);
            this.lbl_WinnerProcent.TabIndex = 11;
            this.lbl_WinnerProcent.Text = "Winners (%) :";
            // 
            // gbx_Backtest
            // 
            this.gbx_Backtest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbx_Backtest.Controls.Add(this.lbl_Ticker);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Max_DrawDown);
            this.gbx_Backtest.Controls.Add(this.lbl_MaxDrawDown);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Sharp_Ratio);
            this.gbx_Backtest.Controls.Add(this.lbl_SharpRatio);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_TimeSpan_Finish);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_TimeSpan_Start);
            this.gbx_Backtest.Controls.Add(this.lbl_Period);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Ticker);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_CAGR);
            this.gbx_Backtest.Controls.Add(this.lbl_Cagr);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Profit_Factor);
            this.gbx_Backtest.Controls.Add(this.lbl_Gain_Loss);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Avg_Loss);
            this.gbx_Backtest.Controls.Add(this.lbl_AverageLoss);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Avg_Gain);
            this.gbx_Backtest.Controls.Add(this.lbl_AverageGain);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Nbr_Trades);
            this.gbx_Backtest.Controls.Add(this.lbl_NumberOfTrades);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Winners_Procent);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Return_Procent);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Return_Sek);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Portfolio_End);
            this.gbx_Backtest.Controls.Add(this.lbl_ValuePortfolio_Start);
            this.gbx_Backtest.Controls.Add(this.lbl_PortfolioStart);
            this.gbx_Backtest.Controls.Add(this.lbl_WinnerProcent);
            this.gbx_Backtest.Controls.Add(this.lbl_PortfolioEnd);
            this.gbx_Backtest.Controls.Add(this.lbl_ReturnProcent);
            this.gbx_Backtest.Controls.Add(this.lbl_ReturnSek);
            this.gbx_Backtest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Backtest.ForeColor = System.Drawing.Color.White;
            this.gbx_Backtest.Location = new System.Drawing.Point(1196, 3);
            this.gbx_Backtest.Name = "gbx_Backtest";
            this.gbx_Backtest.Size = new System.Drawing.Size(146, 687);
            this.gbx_Backtest.TabIndex = 12;
            this.gbx_Backtest.TabStop = false;
            this.gbx_Backtest.Text = "Backtest";
            // 
            // lbl_Ticker
            // 
            this.lbl_Ticker.AutoSize = true;
            this.lbl_Ticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ticker.ForeColor = System.Drawing.Color.White;
            this.lbl_Ticker.Location = new System.Drawing.Point(20, 30);
            this.lbl_Ticker.Name = "lbl_Ticker";
            this.lbl_Ticker.Size = new System.Drawing.Size(55, 13);
            this.lbl_Ticker.TabIndex = 35;
            this.lbl_Ticker.Text = "Ticker : ";
            // 
            // lbl_Value_Max_DrawDown
            // 
            this.lbl_Value_Max_DrawDown.AutoSize = true;
            this.lbl_Value_Max_DrawDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Max_DrawDown.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Max_DrawDown.Location = new System.Drawing.Point(20, 657);
            this.lbl_Value_Max_DrawDown.Name = "lbl_Value_Max_DrawDown";
            this.lbl_Value_Max_DrawDown.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_Max_DrawDown.TabIndex = 34;
            this.lbl_Value_Max_DrawDown.Text = "label16";
            // 
            // lbl_MaxDrawDown
            // 
            this.lbl_MaxDrawDown.AutoSize = true;
            this.lbl_MaxDrawDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaxDrawDown.ForeColor = System.Drawing.Color.White;
            this.lbl_MaxDrawDown.Location = new System.Drawing.Point(20, 640);
            this.lbl_MaxDrawDown.Name = "lbl_MaxDrawDown";
            this.lbl_MaxDrawDown.Size = new System.Drawing.Size(120, 13);
            this.lbl_MaxDrawDown.TabIndex = 33;
            this.lbl_MaxDrawDown.Text = "Max drawdown (%) :";
            // 
            // lbl_Value_Sharp_Ratio
            // 
            this.lbl_Value_Sharp_Ratio.AutoSize = true;
            this.lbl_Value_Sharp_Ratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Sharp_Ratio.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Sharp_Ratio.Location = new System.Drawing.Point(20, 610);
            this.lbl_Value_Sharp_Ratio.Name = "lbl_Value_Sharp_Ratio";
            this.lbl_Value_Sharp_Ratio.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_Sharp_Ratio.TabIndex = 32;
            this.lbl_Value_Sharp_Ratio.Text = "label15";
            // 
            // lbl_SharpRatio
            // 
            this.lbl_SharpRatio.AutoSize = true;
            this.lbl_SharpRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SharpRatio.ForeColor = System.Drawing.Color.White;
            this.lbl_SharpRatio.Location = new System.Drawing.Point(20, 593);
            this.lbl_SharpRatio.Name = "lbl_SharpRatio";
            this.lbl_SharpRatio.Size = new System.Drawing.Size(124, 13);
            this.lbl_SharpRatio.TabIndex = 31;
            this.lbl_SharpRatio.Text = "Sharp ratio (period) :";
            // 
            // lbl_Value_TimeSpan_Finish
            // 
            this.lbl_Value_TimeSpan_Finish.AutoSize = true;
            this.lbl_Value_TimeSpan_Finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_TimeSpan_Finish.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_TimeSpan_Finish.Location = new System.Drawing.Point(20, 107);
            this.lbl_Value_TimeSpan_Finish.Name = "lbl_Value_TimeSpan_Finish";
            this.lbl_Value_TimeSpan_Finish.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_TimeSpan_Finish.TabIndex = 30;
            this.lbl_Value_TimeSpan_Finish.Text = "label14";
            // 
            // lbl_Value_TimeSpan_Start
            // 
            this.lbl_Value_TimeSpan_Start.AutoSize = true;
            this.lbl_Value_TimeSpan_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_TimeSpan_Start.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_TimeSpan_Start.Location = new System.Drawing.Point(20, 92);
            this.lbl_Value_TimeSpan_Start.Name = "lbl_Value_TimeSpan_Start";
            this.lbl_Value_TimeSpan_Start.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_TimeSpan_Start.TabIndex = 29;
            this.lbl_Value_TimeSpan_Start.Text = "label13";
            // 
            // lbl_Period
            // 
            this.lbl_Period.AutoSize = true;
            this.lbl_Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Period.ForeColor = System.Drawing.Color.White;
            this.lbl_Period.Location = new System.Drawing.Point(20, 75);
            this.lbl_Period.Name = "lbl_Period";
            this.lbl_Period.Size = new System.Drawing.Size(55, 13);
            this.lbl_Period.TabIndex = 28;
            this.lbl_Period.Text = "Period : ";
            // 
            // lbl_Value_Ticker
            // 
            this.lbl_Value_Ticker.AutoSize = true;
            this.lbl_Value_Ticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Ticker.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Ticker.Location = new System.Drawing.Point(22, 47);
            this.lbl_Value_Ticker.Name = "lbl_Value_Ticker";
            this.lbl_Value_Ticker.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_Ticker.TabIndex = 27;
            this.lbl_Value_Ticker.Text = "label12";
            // 
            // lbl_Value_CAGR
            // 
            this.lbl_Value_CAGR.AutoSize = true;
            this.lbl_Value_CAGR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_CAGR.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_CAGR.Location = new System.Drawing.Point(20, 564);
            this.lbl_Value_CAGR.Name = "lbl_Value_CAGR";
            this.lbl_Value_CAGR.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_CAGR.TabIndex = 26;
            this.lbl_Value_CAGR.Text = "label12";
            // 
            // lbl_Cagr
            // 
            this.lbl_Cagr.AutoSize = true;
            this.lbl_Cagr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cagr.ForeColor = System.Drawing.Color.White;
            this.lbl_Cagr.Location = new System.Drawing.Point(20, 547);
            this.lbl_Cagr.Name = "lbl_Cagr";
            this.lbl_Cagr.Size = new System.Drawing.Size(104, 13);
            this.lbl_Cagr.TabIndex = 25;
            this.lbl_Cagr.Text = "Yearly return (%):";
            // 
            // lbl_Value_Profit_Factor
            // 
            this.lbl_Value_Profit_Factor.AutoSize = true;
            this.lbl_Value_Profit_Factor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Profit_Factor.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Profit_Factor.Location = new System.Drawing.Point(20, 521);
            this.lbl_Value_Profit_Factor.Name = "lbl_Value_Profit_Factor";
            this.lbl_Value_Profit_Factor.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_Profit_Factor.TabIndex = 24;
            this.lbl_Value_Profit_Factor.Text = "label11";
            // 
            // lbl_Gain_Loss
            // 
            this.lbl_Gain_Loss.AutoSize = true;
            this.lbl_Gain_Loss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gain_Loss.ForeColor = System.Drawing.Color.White;
            this.lbl_Gain_Loss.Location = new System.Drawing.Point(20, 504);
            this.lbl_Gain_Loss.Name = "lbl_Gain_Loss";
            this.lbl_Gain_Loss.Size = new System.Drawing.Size(81, 13);
            this.lbl_Gain_Loss.TabIndex = 23;
            this.lbl_Gain_Loss.Text = "Gain / Loss :";
            // 
            // lbl_Value_Avg_Loss
            // 
            this.lbl_Value_Avg_Loss.AutoSize = true;
            this.lbl_Value_Avg_Loss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Avg_Loss.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Avg_Loss.Location = new System.Drawing.Point(18, 474);
            this.lbl_Value_Avg_Loss.Name = "lbl_Value_Avg_Loss";
            this.lbl_Value_Avg_Loss.Size = new System.Drawing.Size(48, 13);
            this.lbl_Value_Avg_Loss.TabIndex = 22;
            this.lbl_Value_Avg_Loss.Text = "label10";
            // 
            // lbl_AverageLoss
            // 
            this.lbl_AverageLoss.AutoSize = true;
            this.lbl_AverageLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AverageLoss.ForeColor = System.Drawing.Color.White;
            this.lbl_AverageLoss.Location = new System.Drawing.Point(18, 457);
            this.lbl_AverageLoss.Name = "lbl_AverageLoss";
            this.lbl_AverageLoss.Size = new System.Drawing.Size(99, 13);
            this.lbl_AverageLoss.TabIndex = 21;
            this.lbl_AverageLoss.Text = "Avg loss (SEK) :";
            // 
            // lbl_Value_Avg_Gain
            // 
            this.lbl_Value_Avg_Gain.AutoSize = true;
            this.lbl_Value_Avg_Gain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Avg_Gain.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Avg_Gain.Location = new System.Drawing.Point(18, 427);
            this.lbl_Value_Avg_Gain.Name = "lbl_Value_Avg_Gain";
            this.lbl_Value_Avg_Gain.Size = new System.Drawing.Size(41, 13);
            this.lbl_Value_Avg_Gain.TabIndex = 20;
            this.lbl_Value_Avg_Gain.Text = "label9";
            // 
            // lbl_AverageGain
            // 
            this.lbl_AverageGain.AutoSize = true;
            this.lbl_AverageGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AverageGain.ForeColor = System.Drawing.Color.White;
            this.lbl_AverageGain.Location = new System.Drawing.Point(18, 410);
            this.lbl_AverageGain.Name = "lbl_AverageGain";
            this.lbl_AverageGain.Size = new System.Drawing.Size(101, 13);
            this.lbl_AverageGain.TabIndex = 19;
            this.lbl_AverageGain.Text = "Avg gain (SEK) :";
            // 
            // lbl_Value_Nbr_Trades
            // 
            this.lbl_Value_Nbr_Trades.AutoSize = true;
            this.lbl_Value_Nbr_Trades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Nbr_Trades.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Nbr_Trades.Location = new System.Drawing.Point(18, 339);
            this.lbl_Value_Nbr_Trades.Name = "lbl_Value_Nbr_Trades";
            this.lbl_Value_Nbr_Trades.Size = new System.Drawing.Size(41, 13);
            this.lbl_Value_Nbr_Trades.TabIndex = 18;
            this.lbl_Value_Nbr_Trades.Text = "label7";
            // 
            // lbl_NumberOfTrades
            // 
            this.lbl_NumberOfTrades.AutoSize = true;
            this.lbl_NumberOfTrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumberOfTrades.ForeColor = System.Drawing.Color.White;
            this.lbl_NumberOfTrades.Location = new System.Drawing.Point(18, 322);
            this.lbl_NumberOfTrades.Name = "lbl_NumberOfTrades";
            this.lbl_NumberOfTrades.Size = new System.Drawing.Size(74, 13);
            this.lbl_NumberOfTrades.TabIndex = 17;
            this.lbl_NumberOfTrades.Text = "Nbr trades :";
            // 
            // lbl_Value_Winners_Procent
            // 
            this.lbl_Value_Winners_Procent.AutoSize = true;
            this.lbl_Value_Winners_Procent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Winners_Procent.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Winners_Procent.Location = new System.Drawing.Point(18, 384);
            this.lbl_Value_Winners_Procent.Name = "lbl_Value_Winners_Procent";
            this.lbl_Value_Winners_Procent.Size = new System.Drawing.Size(41, 13);
            this.lbl_Value_Winners_Procent.TabIndex = 16;
            this.lbl_Value_Winners_Procent.Text = "label8";
            // 
            // lbl_Value_Return_Procent
            // 
            this.lbl_Value_Return_Procent.AutoSize = true;
            this.lbl_Value_Return_Procent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Return_Procent.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Return_Procent.Location = new System.Drawing.Point(18, 296);
            this.lbl_Value_Return_Procent.Name = "lbl_Value_Return_Procent";
            this.lbl_Value_Return_Procent.Size = new System.Drawing.Size(41, 13);
            this.lbl_Value_Return_Procent.TabIndex = 15;
            this.lbl_Value_Return_Procent.Text = "label6";
            // 
            // lbl_Value_Return_Sek
            // 
            this.lbl_Value_Return_Sek.AutoSize = true;
            this.lbl_Value_Return_Sek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Return_Sek.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Return_Sek.Location = new System.Drawing.Point(18, 252);
            this.lbl_Value_Return_Sek.Name = "lbl_Value_Return_Sek";
            this.lbl_Value_Return_Sek.Size = new System.Drawing.Size(41, 13);
            this.lbl_Value_Return_Sek.TabIndex = 14;
            this.lbl_Value_Return_Sek.Text = "label5";
            // 
            // lbl_Value_Portfolio_End
            // 
            this.lbl_Value_Portfolio_End.AutoSize = true;
            this.lbl_Value_Portfolio_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Portfolio_End.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Value_Portfolio_End.Location = new System.Drawing.Point(18, 205);
            this.lbl_Value_Portfolio_End.Name = "lbl_Value_Portfolio_End";
            this.lbl_Value_Portfolio_End.Size = new System.Drawing.Size(41, 13);
            this.lbl_Value_Portfolio_End.TabIndex = 13;
            this.lbl_Value_Portfolio_End.Text = "label4";
            // 
            // lbl_ValuePortfolio_Start
            // 
            this.lbl_ValuePortfolio_Start.AutoSize = true;
            this.lbl_ValuePortfolio_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValuePortfolio_Start.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_ValuePortfolio_Start.Location = new System.Drawing.Point(18, 156);
            this.lbl_ValuePortfolio_Start.Name = "lbl_ValuePortfolio_Start";
            this.lbl_ValuePortfolio_Start.Size = new System.Drawing.Size(41, 13);
            this.lbl_ValuePortfolio_Start.TabIndex = 12;
            this.lbl_ValuePortfolio_Start.Text = "label4";
            // 
            // lbl_NewHigh
            // 
            this.lbl_NewHigh.AutoSize = true;
            this.lbl_NewHigh.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NewHigh.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewHigh.ForeColor = System.Drawing.Color.White;
            this.lbl_NewHigh.Location = new System.Drawing.Point(285, 507);
            this.lbl_NewHigh.Name = "lbl_NewHigh";
            this.lbl_NewHigh.Size = new System.Drawing.Size(70, 17);
            this.lbl_NewHigh.TabIndex = 13;
            this.lbl_NewHigh.Text = "* New high";
            // 
            // lbl_Show_Point_MaxDrawDown
            // 
            this.lbl_Show_Point_MaxDrawDown.AutoSize = true;
            this.lbl_Show_Point_MaxDrawDown.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Show_Point_MaxDrawDown.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Show_Point_MaxDrawDown.ForeColor = System.Drawing.Color.Red;
            this.lbl_Show_Point_MaxDrawDown.Location = new System.Drawing.Point(361, 507);
            this.lbl_Show_Point_MaxDrawDown.Name = "lbl_Show_Point_MaxDrawDown";
            this.lbl_Show_Point_MaxDrawDown.Size = new System.Drawing.Size(101, 17);
            this.lbl_Show_Point_MaxDrawDown.TabIndex = 14;
            this.lbl_Show_Point_MaxDrawDown.Text = "* Max drawdown";
            // 
            // lbx_StockList
            // 
            this.lbx_StockList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbx_StockList.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_StockList.ForeColor = System.Drawing.Color.White;
            this.lbx_StockList.FormattingEnabled = true;
            this.lbx_StockList.ItemHeight = 16;
            this.lbx_StockList.Location = new System.Drawing.Point(27, 206);
            this.lbx_StockList.Name = "lbx_StockList";
            this.lbx_StockList.Size = new System.Drawing.Size(194, 484);
            this.lbx_StockList.TabIndex = 15;
            this.lbx_StockList.SelectedIndexChanged += new System.EventHandler(this.lbx_StockList_SelectedIndexChanged);
            // 
            // btn_Backtest_Multiple_Stocks
            // 
            this.btn_Backtest_Multiple_Stocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Backtest_Multiple_Stocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Backtest_Multiple_Stocks.ForeColor = System.Drawing.Color.White;
            this.btn_Backtest_Multiple_Stocks.Location = new System.Drawing.Point(27, 50);
            this.btn_Backtest_Multiple_Stocks.Name = "btn_Backtest_Multiple_Stocks";
            this.btn_Backtest_Multiple_Stocks.Size = new System.Drawing.Size(194, 34);
            this.btn_Backtest_Multiple_Stocks.TabIndex = 16;
            this.btn_Backtest_Multiple_Stocks.Text = "Backtest multiple stocks";
            this.btn_Backtest_Multiple_Stocks.UseVisualStyleBackColor = false;
            this.btn_Backtest_Multiple_Stocks.Click += new System.EventHandler(this.btn_Backtest_Multiple_Stocks_Click);
            // 
            // cbx_Pick_Algo
            // 
            this.cbx_Pick_Algo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_Pick_Algo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Pick_Algo.ForeColor = System.Drawing.Color.White;
            this.cbx_Pick_Algo.FormattingEnabled = true;
            this.cbx_Pick_Algo.Location = new System.Drawing.Point(27, 106);
            this.cbx_Pick_Algo.Name = "cbx_Pick_Algo";
            this.cbx_Pick_Algo.Size = new System.Drawing.Size(194, 20);
            this.cbx_Pick_Algo.TabIndex = 17;
            this.cbx_Pick_Algo.SelectedIndexChanged += new System.EventHandler(this.cbx_Pick_Algo_SelectedIndexChanged);
            // 
            // pcbx_Loading_Sequence
            // 
            this.pcbx_Loading_Sequence.BackgroundImage = global::GraphProject.Properties.Resources.greyScale;
            this.pcbx_Loading_Sequence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pcbx_Loading_Sequence.Image = global::GraphProject.Properties.Resources.tetris;
            this.pcbx_Loading_Sequence.Location = new System.Drawing.Point(769, 27);
            this.pcbx_Loading_Sequence.Name = "pcbx_Loading_Sequence";
            this.pcbx_Loading_Sequence.Size = new System.Drawing.Size(106, 34);
            this.pcbx_Loading_Sequence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbx_Loading_Sequence.TabIndex = 19;
            this.pcbx_Loading_Sequence.TabStop = false;
            this.pcbx_Loading_Sequence.Visible = false;
            // 
            // lbl_Updating
            // 
            this.lbl_Updating.AutoSize = true;
            this.lbl_Updating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Updating.ForeColor = System.Drawing.Color.Lime;
            this.lbl_Updating.Location = new System.Drawing.Point(668, 25);
            this.lbl_Updating.Name = "lbl_Updating";
            this.lbl_Updating.Size = new System.Drawing.Size(85, 15);
            this.lbl_Updating.TabIndex = 35;
            this.lbl_Updating.Text = "Updating ... ";
            this.lbl_Updating.Visible = false;
            // 
            // dtp_Start_Date
            // 
            this.dtp_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Start_Date.Location = new System.Drawing.Point(27, 164);
            this.dtp_Start_Date.Name = "dtp_Start_Date";
            this.dtp_Start_Date.Size = new System.Drawing.Size(91, 20);
            this.dtp_Start_Date.TabIndex = 37;
            this.dtp_Start_Date.ValueChanged += new System.EventHandler(this.dtp_Start_Date_ValueChanged);
            // 
            // dtp_End_date
            // 
            this.dtp_End_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_End_date.Location = new System.Drawing.Point(130, 164);
            this.dtp_End_date.Name = "dtp_End_date";
            this.dtp_End_date.Size = new System.Drawing.Size(91, 20);
            this.dtp_End_date.TabIndex = 38;
            this.dtp_End_date.ValueChanged += new System.EventHandler(this.dtp_End_date_ValueChanged);
            // 
            // lbl_Date_Start
            // 
            this.lbl_Date_Start.AutoSize = true;
            this.lbl_Date_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date_Start.ForeColor = System.Drawing.Color.White;
            this.lbl_Date_Start.Location = new System.Drawing.Point(24, 144);
            this.lbl_Date_Start.Name = "lbl_Date_Start";
            this.lbl_Date_Start.Size = new System.Drawing.Size(40, 12);
            this.lbl_Date_Start.TabIndex = 36;
            this.lbl_Date_Start.Text = "Start : ";
            // 
            // lbl_Date_End
            // 
            this.lbl_Date_End.AutoSize = true;
            this.lbl_Date_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date_End.ForeColor = System.Drawing.Color.White;
            this.lbl_Date_End.Location = new System.Drawing.Point(127, 144);
            this.lbl_Date_End.Name = "lbl_Date_End";
            this.lbl_Date_End.Size = new System.Drawing.Size(34, 12);
            this.lbl_Date_End.TabIndex = 39;
            this.lbl_Date_End.Text = "End : ";
            // 
            // mst_Menu
            // 
            this.mst_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mst_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mst_File,
            this.mst_Tools,
            this.mst_Update});
            this.mst_Menu.Location = new System.Drawing.Point(0, 0);
            this.mst_Menu.Name = "mst_Menu";
            this.mst_Menu.Size = new System.Drawing.Size(1354, 24);
            this.mst_Menu.TabIndex = 40;
            this.mst_Menu.Text = "menuStrip1";
            // 
            // mst_File
            // 
            this.mst_File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mst_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mst_File_Exit});
            this.mst_File.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_File.ForeColor = System.Drawing.Color.White;
            this.mst_File.Name = "mst_File";
            this.mst_File.Size = new System.Drawing.Size(38, 20);
            this.mst_File.Text = "File";
            // 
            // mst_File_Exit
            // 
            this.mst_File_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mst_File_Exit.ForeColor = System.Drawing.Color.White;
            this.mst_File_Exit.Name = "mst_File_Exit";
            this.mst_File_Exit.Size = new System.Drawing.Size(94, 22);
            this.mst_File_Exit.Text = "Exit";
            this.mst_File_Exit.Click += new System.EventHandler(this.mst_File_Exit_Click);
            // 
            // mst_Tools
            // 
            this.mst_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mst_Tools_Hide_Show_Chart});
            this.mst_Tools.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_Tools.ForeColor = System.Drawing.Color.White;
            this.mst_Tools.Name = "mst_Tools";
            this.mst_Tools.Size = new System.Drawing.Size(45, 20);
            this.mst_Tools.Text = "Tools";
            // 
            // mst_Tools_Hide_Show_Chart
            // 
            this.mst_Tools_Hide_Show_Chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mst_Tools_Hide_Show_Chart.ForeColor = System.Drawing.Color.White;
            this.mst_Tools_Hide_Show_Chart.Name = "mst_Tools_Hide_Show_Chart";
            this.mst_Tools_Hide_Show_Chart.Size = new System.Drawing.Size(128, 22);
            this.mst_Tools_Hide_Show_Chart.Text = "Hide chart";
            this.mst_Tools_Hide_Show_Chart.Click += new System.EventHandler(this.mst_Tools_Hide_Show_Chart_Click);
            // 
            // mst_Update
            // 
            this.mst_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mst_Update.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mst_Update_Pick});
            this.mst_Update.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_Update.ForeColor = System.Drawing.Color.White;
            this.mst_Update.Name = "mst_Update";
            this.mst_Update.Size = new System.Drawing.Size(55, 20);
            this.mst_Update.Text = "Update";
            // 
            // mst_Update_Pick
            // 
            this.mst_Update_Pick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mst_Update_Pick.ForeColor = System.Drawing.Color.White;
            this.mst_Update_Pick.Name = "mst_Update_Pick";
            this.mst_Update_Pick.Size = new System.Drawing.Size(146, 22);
            this.mst_Update_Pick.Text = "Update stocks";
            this.mst_Update_Pick.Click += new System.EventHandler(this.mst_Update_Pick_Click);
            // 
            // GraphChartRsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.lbl_Date_End);
            this.Controls.Add(this.lbl_Date_Start);
            this.Controls.Add(this.dtp_End_date);
            this.Controls.Add(this.dtp_Start_Date);
            this.Controls.Add(this.lbl_Updating);
            this.Controls.Add(this.pcbx_Loading_Sequence);
            this.Controls.Add(this.cbx_Pick_Algo);
            this.Controls.Add(this.btn_Backtest_Multiple_Stocks);
            this.Controls.Add(this.lbx_StockList);
            this.Controls.Add(this.lbl_Show_Point_MaxDrawDown);
            this.Controls.Add(this.lbl_NewHigh);
            this.Controls.Add(this.gbx_Backtest);
            this.Controls.Add(this.lbl_Exit);
            this.Controls.Add(this.lbl_Entry);
            this.Controls.Add(this.lbl_MA200);
            this.Controls.Add(this.lbl_Stock_Ticker);
            this.Controls.Add(this.BacktestChartGui);
            this.Controls.Add(this.StockChartGui);
            this.Controls.Add(this.mst_Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mst_Menu;
            this.Name = "GraphChartRsi";
            this.Text = "GraphStocks";
            this.gbx_Backtest.ResumeLayout(false);
            this.gbx_Backtest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Loading_Sequence)).EndInit();
            this.mst_Menu.ResumeLayout(false);
            this.mst_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart StockChartGui;
        private LiveCharts.WinForms.CartesianChart BacktestChartGui;
        private System.Windows.Forms.Label lbl_Stock_Ticker;
        private System.Windows.Forms.Label lbl_MA200;
        private System.Windows.Forms.Label lbl_Entry;
        private System.Windows.Forms.Label lbl_Exit;
        private System.Windows.Forms.Label lbl_PortfolioStart;
        private System.Windows.Forms.Label lbl_PortfolioEnd;
        private System.Windows.Forms.Label lbl_ReturnSek;
        private System.Windows.Forms.Label lbl_ReturnProcent;
        private System.Windows.Forms.Label lbl_WinnerProcent;
        private System.Windows.Forms.GroupBox gbx_Backtest;
        private System.Windows.Forms.Label lbl_Value_Winners_Procent;
        private System.Windows.Forms.Label lbl_Value_Return_Procent;
        private System.Windows.Forms.Label lbl_Value_Return_Sek;
        private System.Windows.Forms.Label lbl_Value_Portfolio_End;
        private System.Windows.Forms.Label lbl_ValuePortfolio_Start;
        private System.Windows.Forms.Label lbl_Value_Nbr_Trades;
        private System.Windows.Forms.Label lbl_NumberOfTrades;
        private System.Windows.Forms.Label lbl_Value_Avg_Loss;
        private System.Windows.Forms.Label lbl_AverageLoss;
        private System.Windows.Forms.Label lbl_Value_Avg_Gain;
        private System.Windows.Forms.Label lbl_AverageGain;
        private System.Windows.Forms.Label lbl_Value_Profit_Factor;
        private System.Windows.Forms.Label lbl_Gain_Loss;
        private System.Windows.Forms.Label lbl_Value_CAGR;
        private System.Windows.Forms.Label lbl_Cagr;
        private System.Windows.Forms.Label lbl_Period;
        private System.Windows.Forms.Label lbl_Value_Ticker;
        private System.Windows.Forms.Label lbl_Value_TimeSpan_Start;
        private System.Windows.Forms.Label lbl_Value_TimeSpan_Finish;
        private System.Windows.Forms.Label lbl_Value_Sharp_Ratio;
        private System.Windows.Forms.Label lbl_SharpRatio;
        private System.Windows.Forms.Label lbl_MaxDrawDown;
        private System.Windows.Forms.Label lbl_Value_Max_DrawDown;
        private System.Windows.Forms.Label lbl_NewHigh;
        private System.Windows.Forms.Label lbl_Show_Point_MaxDrawDown;
        private System.Windows.Forms.ListBox lbx_StockList;
        private System.Windows.Forms.Button btn_Backtest_Multiple_Stocks;
        private System.Windows.Forms.ComboBox cbx_Pick_Algo;
        private System.Windows.Forms.PictureBox pcbx_Loading_Sequence;
        private System.Windows.Forms.Label lbl_Updating;
        private System.Windows.Forms.Label lbl_Ticker;
        private System.Windows.Forms.DateTimePicker dtp_Start_Date;
        private System.Windows.Forms.DateTimePicker dtp_End_date;
        private System.Windows.Forms.Label lbl_Date_Start;
        private System.Windows.Forms.Label lbl_Date_End;
        private System.Windows.Forms.MenuStrip mst_Menu;
        private System.Windows.Forms.ToolStripMenuItem mst_File;
        private System.Windows.Forms.ToolStripMenuItem mst_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem mst_Tools;
        private System.Windows.Forms.ToolStripMenuItem mst_Tools_Hide_Show_Chart;
        private System.Windows.Forms.ToolStripMenuItem mst_Update;
        private System.Windows.Forms.ToolStripMenuItem mst_Update_Pick;
    }
}