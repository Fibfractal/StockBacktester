namespace GraphProject
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
            this.SuspendLayout();
            // 
            // btn_ExportData
            // 
            this.btn_ExportData.Location = new System.Drawing.Point(100, 72);
            this.btn_ExportData.Name = "btn_ExportData";
            this.btn_ExportData.Size = new System.Drawing.Size(170, 58);
            this.btn_ExportData.TabIndex = 0;
            this.btn_ExportData.Text = "Export Data";
            this.btn_ExportData.UseVisualStyleBackColor = true;
            this.btn_ExportData.Click += new System.EventHandler(this.btn_ExportData_Click);
            // 
            // GraphFromSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ExportData);
            this.Name = "GraphFromSql";
            this.Text = "GraphFromSql";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ExportData;
    }
}