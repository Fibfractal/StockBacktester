namespace GraphProject
{
    partial class GraphRsi
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
            this.btn_ImportRSI = new System.Windows.Forms.Button();
            this.lbx_RSI = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(30, 29);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(708, 282);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // btn_ImportRSI
            // 
            this.btn_ImportRSI.Location = new System.Drawing.Point(53, 349);
            this.btn_ImportRSI.Name = "btn_ImportRSI";
            this.btn_ImportRSI.Size = new System.Drawing.Size(130, 36);
            this.btn_ImportRSI.TabIndex = 1;
            this.btn_ImportRSI.Text = "Import RSI data";
            this.btn_ImportRSI.UseVisualStyleBackColor = true;
            this.btn_ImportRSI.Click += new System.EventHandler(this.btn_ImportRSI_Click);
            // 
            // lbx_RSI
            // 
            this.lbx_RSI.FormattingEnabled = true;
            this.lbx_RSI.Location = new System.Drawing.Point(763, 37);
            this.lbx_RSI.Name = "lbx_RSI";
            this.lbx_RSI.Size = new System.Drawing.Size(207, 264);
            this.lbx_RSI.TabIndex = 2;
            // 
            // GraphRsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 450);
            this.Controls.Add(this.lbx_RSI);
            this.Controls.Add(this.btn_ImportRSI);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "GraphRsi";
            this.Text = "GraphRsi";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button btn_ImportRSI;
        private System.Windows.Forms.ListBox lbx_RSI;
    }
}