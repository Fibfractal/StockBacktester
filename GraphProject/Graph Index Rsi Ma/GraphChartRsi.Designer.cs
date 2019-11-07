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
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(29, 12);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1219, 473);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(29, 524);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(1219, 185);
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
            this.lbl_MA200.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MA200.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_MA200.Location = new System.Drawing.Point(107, 81);
            this.lbl_MA200.Name = "lbl_MA200";
            this.lbl_MA200.Size = new System.Drawing.Size(72, 21);
            this.lbl_MA200.TabIndex = 3;
            this.lbl_MA200.Text = "- MA 200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "* RSI 14 <  30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(107, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "* RSI 14 >  70";
            // 
            // GraphChartRsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_MA200);
            this.Controls.Add(this.lbl_OMX);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "GraphChartRsi";
            this.Text = "GraphChartRsi";
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
    }
}