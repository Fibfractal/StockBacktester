﻿namespace GraphProject
{
    partial class GraphFromSql
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
            this.btn_ExportData = new System.Windows.Forms.Button();
            this.btn_ImportSql = new System.Windows.Forms.Button();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // btn_ExportData
            // 
            this.btn_ExportData.Location = new System.Drawing.Point(251, 593);
            this.btn_ExportData.Name = "btn_ExportData";
            this.btn_ExportData.Size = new System.Drawing.Size(170, 35);
            this.btn_ExportData.TabIndex = 0;
            this.btn_ExportData.Text = "Export Data";
            this.btn_ExportData.UseVisualStyleBackColor = true;
            this.btn_ExportData.Click += new System.EventHandler(this.btn_ExportData_Click);
            // 
            // btn_ImportSql
            // 
            this.btn_ImportSql.Location = new System.Drawing.Point(32, 593);
            this.btn_ImportSql.Name = "btn_ImportSql";
            this.btn_ImportSql.Size = new System.Drawing.Size(166, 35);
            this.btn_ImportSql.TabIndex = 1;
            this.btn_ImportSql.Text = "Import Data";
            this.btn_ImportSql.UseVisualStyleBackColor = true;
            this.btn_ImportSql.Click += new System.EventHandler(this.btn_ImportSql_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(32, 27);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1185, 515);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // GraphFromSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 653);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.btn_ImportSql);
            this.Controls.Add(this.btn_ExportData);
            this.Name = "GraphFromSql";
            this.Text = "GraphFromSql";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ExportData;
        private System.Windows.Forms.Button btn_ImportSql;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}