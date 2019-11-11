namespace GraphProject
{
    partial class GraphChartRsi
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.lbl_OMX = new System.Windows.Forms.Label();
            this.lbl_MA200 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_PortfolioStart = new System.Windows.Forms.Label();
            this.lbl_PortfolioEnd = new System.Windows.Forms.Label();
            this.lbl_ReturnSek = new System.Windows.Forms.Label();
            this.lbl_ReturnProcent = new System.Windows.Forms.Label();
            this.lbl_WinnerProcent = new System.Windows.Forms.Label();
            this.gbx_Backtest = new System.Windows.Forms.GroupBox();
            this.lbl_Value_TimeSpan_Finish = new System.Windows.Forms.Label();
            this.lbl_Value_TimeSpan_Start = new System.Windows.Forms.Label();
            this.lbl_TimeSpan = new System.Windows.Forms.Label();
            this.lbl_Value_Name_Algo = new System.Windows.Forms.Label();
            this.lbl_Value_CAGR = new System.Windows.Forms.Label();
            this.lbl_Cagr = new System.Windows.Forms.Label();
            this.lbl_Value_Profit_Factor = new System.Windows.Forms.Label();
            this.lbl_ProfitFactor = new System.Windows.Forms.Label();
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
            this.lbl_SharpRatio = new System.Windows.Forms.Label();
            this.lbl_Value_Sharp_Ratio = new System.Windows.Forms.Label();
            this.gbx_Backtest.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(29, 12);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1130, 473);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(29, 524);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(1130, 185);
            this.cartesianChart2.TabIndex = 1;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // lbl_OMX
            // 
            this.lbl_OMX.AutoSize = true;
            this.lbl_OMX.Font = new System.Drawing.Font("Franklin Gothic Medium", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OMX.ForeColor = System.Drawing.Color.Blue;
            this.lbl_OMX.Location = new System.Drawing.Point(102, 21);
            this.lbl_OMX.Name = "lbl_OMX";
            this.lbl_OMX.Size = new System.Drawing.Size(170, 50);
            this.lbl_OMX.TabIndex = 2;
            this.lbl_OMX.Text = "OMXSPI";
            // 
            // lbl_MA200
            // 
            this.lbl_MA200.AutoSize = true;
            this.lbl_MA200.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MA200.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_MA200.Location = new System.Drawing.Point(107, 137);
            this.lbl_MA200.Name = "lbl_MA200";
            this.lbl_MA200.Size = new System.Drawing.Size(59, 17);
            this.lbl_MA200.TabIndex = 3;
            this.lbl_MA200.Text = "- MA 200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "* Entry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(107, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "* Exit";
            // 
            // lbl_PortfolioStart
            // 
            this.lbl_PortfolioStart.AutoSize = true;
            this.lbl_PortfolioStart.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PortfolioStart.ForeColor = System.Drawing.Color.White;
            this.lbl_PortfolioStart.Location = new System.Drawing.Point(18, 115);
            this.lbl_PortfolioStart.Name = "lbl_PortfolioStart";
            this.lbl_PortfolioStart.Size = new System.Drawing.Size(125, 17);
            this.lbl_PortfolioStart.TabIndex = 7;
            this.lbl_PortfolioStart.Text = "Portfolio value start : ";
            // 
            // lbl_PortfolioEnd
            // 
            this.lbl_PortfolioEnd.AutoSize = true;
            this.lbl_PortfolioEnd.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PortfolioEnd.ForeColor = System.Drawing.Color.White;
            this.lbl_PortfolioEnd.Location = new System.Drawing.Point(18, 161);
            this.lbl_PortfolioEnd.Name = "lbl_PortfolioEnd";
            this.lbl_PortfolioEnd.Size = new System.Drawing.Size(118, 17);
            this.lbl_PortfolioEnd.TabIndex = 8;
            this.lbl_PortfolioEnd.Text = "Portfolio value end :";
            // 
            // lbl_ReturnSek
            // 
            this.lbl_ReturnSek.AutoSize = true;
            this.lbl_ReturnSek.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReturnSek.ForeColor = System.Drawing.Color.White;
            this.lbl_ReturnSek.Location = new System.Drawing.Point(18, 208);
            this.lbl_ReturnSek.Name = "lbl_ReturnSek";
            this.lbl_ReturnSek.Size = new System.Drawing.Size(84, 17);
            this.lbl_ReturnSek.TabIndex = 9;
            this.lbl_ReturnSek.Text = "Return (SEK) :";
            // 
            // lbl_ReturnProcent
            // 
            this.lbl_ReturnProcent.AutoSize = true;
            this.lbl_ReturnProcent.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReturnProcent.ForeColor = System.Drawing.Color.White;
            this.lbl_ReturnProcent.Location = new System.Drawing.Point(18, 255);
            this.lbl_ReturnProcent.Name = "lbl_ReturnProcent";
            this.lbl_ReturnProcent.Size = new System.Drawing.Size(72, 17);
            this.lbl_ReturnProcent.TabIndex = 10;
            this.lbl_ReturnProcent.Text = "Return (%) :";
            // 
            // lbl_WinnerProcent
            // 
            this.lbl_WinnerProcent.AutoSize = true;
            this.lbl_WinnerProcent.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WinnerProcent.ForeColor = System.Drawing.Color.White;
            this.lbl_WinnerProcent.Location = new System.Drawing.Point(18, 350);
            this.lbl_WinnerProcent.Name = "lbl_WinnerProcent";
            this.lbl_WinnerProcent.Size = new System.Drawing.Size(80, 17);
            this.lbl_WinnerProcent.TabIndex = 11;
            this.lbl_WinnerProcent.Text = "Winners (%) :";
            // 
            // gbx_Backtest
            // 
            this.gbx_Backtest.BackColor = System.Drawing.Color.Transparent;
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Sharp_Ratio);
            this.gbx_Backtest.Controls.Add(this.lbl_SharpRatio);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_TimeSpan_Finish);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_TimeSpan_Start);
            this.gbx_Backtest.Controls.Add(this.lbl_TimeSpan);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Name_Algo);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_CAGR);
            this.gbx_Backtest.Controls.Add(this.lbl_Cagr);
            this.gbx_Backtest.Controls.Add(this.lbl_Value_Profit_Factor);
            this.gbx_Backtest.Controls.Add(this.lbl_ProfitFactor);
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
            this.gbx_Backtest.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Backtest.ForeColor = System.Drawing.Color.White;
            this.gbx_Backtest.Location = new System.Drawing.Point(1196, 3);
            this.gbx_Backtest.Name = "gbx_Backtest";
            this.gbx_Backtest.Size = new System.Drawing.Size(146, 718);
            this.gbx_Backtest.TabIndex = 12;
            this.gbx_Backtest.TabStop = false;
            this.gbx_Backtest.Text = "Backtest";
            // 
            // lbl_Value_TimeSpan_Finish
            // 
            this.lbl_Value_TimeSpan_Finish.AutoSize = true;
            this.lbl_Value_TimeSpan_Finish.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_TimeSpan_Finish.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_TimeSpan_Finish.Location = new System.Drawing.Point(20, 83);
            this.lbl_Value_TimeSpan_Finish.Name = "lbl_Value_TimeSpan_Finish";
            this.lbl_Value_TimeSpan_Finish.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_TimeSpan_Finish.TabIndex = 30;
            this.lbl_Value_TimeSpan_Finish.Text = "label14";
            // 
            // lbl_Value_TimeSpan_Start
            // 
            this.lbl_Value_TimeSpan_Start.AutoSize = true;
            this.lbl_Value_TimeSpan_Start.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_TimeSpan_Start.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_TimeSpan_Start.Location = new System.Drawing.Point(20, 68);
            this.lbl_Value_TimeSpan_Start.Name = "lbl_Value_TimeSpan_Start";
            this.lbl_Value_TimeSpan_Start.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_TimeSpan_Start.TabIndex = 29;
            this.lbl_Value_TimeSpan_Start.Text = "label13";
            // 
            // lbl_TimeSpan
            // 
            this.lbl_TimeSpan.AutoSize = true;
            this.lbl_TimeSpan.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeSpan.ForeColor = System.Drawing.Color.White;
            this.lbl_TimeSpan.Location = new System.Drawing.Point(20, 51);
            this.lbl_TimeSpan.Name = "lbl_TimeSpan";
            this.lbl_TimeSpan.Size = new System.Drawing.Size(74, 17);
            this.lbl_TimeSpan.TabIndex = 28;
            this.lbl_TimeSpan.Text = "Time span : ";
            // 
            // lbl_Value_Name_Algo
            // 
            this.lbl_Value_Name_Algo.AutoSize = true;
            this.lbl_Value_Name_Algo.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Name_Algo.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Name_Algo.Location = new System.Drawing.Point(18, 27);
            this.lbl_Value_Name_Algo.Name = "lbl_Value_Name_Algo";
            this.lbl_Value_Name_Algo.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_Name_Algo.TabIndex = 27;
            this.lbl_Value_Name_Algo.Text = "label12";
            // 
            // lbl_Value_CAGR
            // 
            this.lbl_Value_CAGR.AutoSize = true;
            this.lbl_Value_CAGR.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_CAGR.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_CAGR.Location = new System.Drawing.Point(20, 559);
            this.lbl_Value_CAGR.Name = "lbl_Value_CAGR";
            this.lbl_Value_CAGR.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_CAGR.TabIndex = 26;
            this.lbl_Value_CAGR.Text = "label12";
            // 
            // lbl_Cagr
            // 
            this.lbl_Cagr.AutoSize = true;
            this.lbl_Cagr.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cagr.ForeColor = System.Drawing.Color.White;
            this.lbl_Cagr.Location = new System.Drawing.Point(20, 542);
            this.lbl_Cagr.Name = "lbl_Cagr";
            this.lbl_Cagr.Size = new System.Drawing.Size(64, 17);
            this.lbl_Cagr.TabIndex = 25;
            this.lbl_Cagr.Text = "CAGR (%):";
            // 
            // lbl_Value_Profit_Factor
            // 
            this.lbl_Value_Profit_Factor.AutoSize = true;
            this.lbl_Value_Profit_Factor.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Profit_Factor.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Profit_Factor.Location = new System.Drawing.Point(20, 509);
            this.lbl_Value_Profit_Factor.Name = "lbl_Value_Profit_Factor";
            this.lbl_Value_Profit_Factor.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_Profit_Factor.TabIndex = 24;
            this.lbl_Value_Profit_Factor.Text = "label11";
            // 
            // lbl_ProfitFactor
            // 
            this.lbl_ProfitFactor.AutoSize = true;
            this.lbl_ProfitFactor.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProfitFactor.ForeColor = System.Drawing.Color.White;
            this.lbl_ProfitFactor.Location = new System.Drawing.Point(20, 492);
            this.lbl_ProfitFactor.Name = "lbl_ProfitFactor";
            this.lbl_ProfitFactor.Size = new System.Drawing.Size(79, 17);
            this.lbl_ProfitFactor.TabIndex = 23;
            this.lbl_ProfitFactor.Text = "Profit factor :";
            // 
            // lbl_Value_Avg_Loss
            // 
            this.lbl_Value_Avg_Loss.AutoSize = true;
            this.lbl_Value_Avg_Loss.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Avg_Loss.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Avg_Loss.Location = new System.Drawing.Point(18, 462);
            this.lbl_Value_Avg_Loss.Name = "lbl_Value_Avg_Loss";
            this.lbl_Value_Avg_Loss.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_Avg_Loss.TabIndex = 22;
            this.lbl_Value_Avg_Loss.Text = "label10";
            // 
            // lbl_AverageLoss
            // 
            this.lbl_AverageLoss.AutoSize = true;
            this.lbl_AverageLoss.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AverageLoss.ForeColor = System.Drawing.Color.White;
            this.lbl_AverageLoss.Location = new System.Drawing.Point(18, 445);
            this.lbl_AverageLoss.Name = "lbl_AverageLoss";
            this.lbl_AverageLoss.Size = new System.Drawing.Size(93, 17);
            this.lbl_AverageLoss.TabIndex = 21;
            this.lbl_AverageLoss.Text = "Avg loss (SEK) :";
            // 
            // lbl_Value_Avg_Gain
            // 
            this.lbl_Value_Avg_Gain.AutoSize = true;
            this.lbl_Value_Avg_Gain.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Avg_Gain.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Avg_Gain.Location = new System.Drawing.Point(18, 415);
            this.lbl_Value_Avg_Gain.Name = "lbl_Value_Avg_Gain";
            this.lbl_Value_Avg_Gain.Size = new System.Drawing.Size(43, 17);
            this.lbl_Value_Avg_Gain.TabIndex = 20;
            this.lbl_Value_Avg_Gain.Text = "label9";
            // 
            // lbl_AverageGain
            // 
            this.lbl_AverageGain.AutoSize = true;
            this.lbl_AverageGain.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AverageGain.ForeColor = System.Drawing.Color.White;
            this.lbl_AverageGain.Location = new System.Drawing.Point(18, 398);
            this.lbl_AverageGain.Name = "lbl_AverageGain";
            this.lbl_AverageGain.Size = new System.Drawing.Size(95, 17);
            this.lbl_AverageGain.TabIndex = 19;
            this.lbl_AverageGain.Text = "Avg gain (SEK) :";
            // 
            // lbl_Value_Nbr_Trades
            // 
            this.lbl_Value_Nbr_Trades.AutoSize = true;
            this.lbl_Value_Nbr_Trades.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Nbr_Trades.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Nbr_Trades.Location = new System.Drawing.Point(18, 322);
            this.lbl_Value_Nbr_Trades.Name = "lbl_Value_Nbr_Trades";
            this.lbl_Value_Nbr_Trades.Size = new System.Drawing.Size(43, 17);
            this.lbl_Value_Nbr_Trades.TabIndex = 18;
            this.lbl_Value_Nbr_Trades.Text = "label7";
            // 
            // lbl_NumberOfTrades
            // 
            this.lbl_NumberOfTrades.AutoSize = true;
            this.lbl_NumberOfTrades.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumberOfTrades.ForeColor = System.Drawing.Color.White;
            this.lbl_NumberOfTrades.Location = new System.Drawing.Point(18, 305);
            this.lbl_NumberOfTrades.Name = "lbl_NumberOfTrades";
            this.lbl_NumberOfTrades.Size = new System.Drawing.Size(71, 17);
            this.lbl_NumberOfTrades.TabIndex = 17;
            this.lbl_NumberOfTrades.Text = "Nbr trades :";
            // 
            // lbl_Value_Winners_Procent
            // 
            this.lbl_Value_Winners_Procent.AutoSize = true;
            this.lbl_Value_Winners_Procent.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Winners_Procent.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Winners_Procent.Location = new System.Drawing.Point(18, 367);
            this.lbl_Value_Winners_Procent.Name = "lbl_Value_Winners_Procent";
            this.lbl_Value_Winners_Procent.Size = new System.Drawing.Size(43, 17);
            this.lbl_Value_Winners_Procent.TabIndex = 16;
            this.lbl_Value_Winners_Procent.Text = "label8";
            // 
            // lbl_Value_Return_Procent
            // 
            this.lbl_Value_Return_Procent.AutoSize = true;
            this.lbl_Value_Return_Procent.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Return_Procent.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Return_Procent.Location = new System.Drawing.Point(18, 272);
            this.lbl_Value_Return_Procent.Name = "lbl_Value_Return_Procent";
            this.lbl_Value_Return_Procent.Size = new System.Drawing.Size(43, 17);
            this.lbl_Value_Return_Procent.TabIndex = 15;
            this.lbl_Value_Return_Procent.Text = "label6";
            // 
            // lbl_Value_Return_Sek
            // 
            this.lbl_Value_Return_Sek.AutoSize = true;
            this.lbl_Value_Return_Sek.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Return_Sek.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Return_Sek.Location = new System.Drawing.Point(18, 228);
            this.lbl_Value_Return_Sek.Name = "lbl_Value_Return_Sek";
            this.lbl_Value_Return_Sek.Size = new System.Drawing.Size(43, 17);
            this.lbl_Value_Return_Sek.TabIndex = 14;
            this.lbl_Value_Return_Sek.Text = "label5";
            // 
            // lbl_Value_Portfolio_End
            // 
            this.lbl_Value_Portfolio_End.AutoSize = true;
            this.lbl_Value_Portfolio_End.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Portfolio_End.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Portfolio_End.Location = new System.Drawing.Point(18, 181);
            this.lbl_Value_Portfolio_End.Name = "lbl_Value_Portfolio_End";
            this.lbl_Value_Portfolio_End.Size = new System.Drawing.Size(43, 17);
            this.lbl_Value_Portfolio_End.TabIndex = 13;
            this.lbl_Value_Portfolio_End.Text = "label4";
            // 
            // lbl_ValuePortfolio_Start
            // 
            this.lbl_ValuePortfolio_Start.AutoSize = true;
            this.lbl_ValuePortfolio_Start.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValuePortfolio_Start.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ValuePortfolio_Start.Location = new System.Drawing.Point(18, 132);
            this.lbl_ValuePortfolio_Start.Name = "lbl_ValuePortfolio_Start";
            this.lbl_ValuePortfolio_Start.Size = new System.Drawing.Size(43, 17);
            this.lbl_ValuePortfolio_Start.TabIndex = 12;
            this.lbl_ValuePortfolio_Start.Text = "label4";
            // 
            // lbl_SharpRatio
            // 
            this.lbl_SharpRatio.AutoSize = true;
            this.lbl_SharpRatio.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SharpRatio.ForeColor = System.Drawing.Color.White;
            this.lbl_SharpRatio.Location = new System.Drawing.Point(20, 588);
            this.lbl_SharpRatio.Name = "lbl_SharpRatio";
            this.lbl_SharpRatio.Size = new System.Drawing.Size(74, 17);
            this.lbl_SharpRatio.TabIndex = 31;
            this.lbl_SharpRatio.Text = "Sharp ratio :";
            // 
            // lbl_Value_Sharp_Ratio
            // 
            this.lbl_Value_Sharp_Ratio.AutoSize = true;
            this.lbl_Value_Sharp_Ratio.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Value_Sharp_Ratio.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Value_Sharp_Ratio.Location = new System.Drawing.Point(20, 605);
            this.lbl_Value_Sharp_Ratio.Name = "lbl_Value_Sharp_Ratio";
            this.lbl_Value_Sharp_Ratio.Size = new System.Drawing.Size(51, 17);
            this.lbl_Value_Sharp_Ratio.TabIndex = 32;
            this.lbl_Value_Sharp_Ratio.Text = "label15";
            // 
            // GraphChartRsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.gbx_Backtest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_MA200);
            this.Controls.Add(this.lbl_OMX);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "GraphChartRsi";
            this.Text = "GraphChartRsi";
            this.gbx_Backtest.ResumeLayout(false);
            this.gbx_Backtest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.Label lbl_OMX;
        private System.Windows.Forms.Label lbl_MA200;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Label lbl_ProfitFactor;
        private System.Windows.Forms.Label lbl_Value_CAGR;
        private System.Windows.Forms.Label lbl_Cagr;
        private System.Windows.Forms.Label lbl_TimeSpan;
        private System.Windows.Forms.Label lbl_Value_Name_Algo;
        private System.Windows.Forms.Label lbl_Value_TimeSpan_Start;
        private System.Windows.Forms.Label lbl_Value_TimeSpan_Finish;
        private System.Windows.Forms.Label lbl_Value_Sharp_Ratio;
        private System.Windows.Forms.Label lbl_SharpRatio;
    }
}