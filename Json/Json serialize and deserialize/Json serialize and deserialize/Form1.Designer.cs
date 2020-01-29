namespace Json_serialize_and_deserialize
{
    partial class Form1
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
            this.btn_CreateJsonfile = new System.Windows.Forms.Button();
            this.btn_ImportJSon = new System.Windows.Forms.Button();
            this.lbx_Customers = new System.Windows.Forms.ListBox();
            this.tbx_Smhi = new System.Windows.Forms.RichTextBox();
            this.btn_SMHI = new System.Windows.Forms.Button();
            this.tbx_IG = new System.Windows.Forms.RichTextBox();
            this.btn_Import_IG = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CreateJsonfile
            // 
            this.btn_CreateJsonfile.Location = new System.Drawing.Point(30, 26);
            this.btn_CreateJsonfile.Name = "btn_CreateJsonfile";
            this.btn_CreateJsonfile.Size = new System.Drawing.Size(114, 53);
            this.btn_CreateJsonfile.TabIndex = 1;
            this.btn_CreateJsonfile.Text = "Create jsonfile";
            this.btn_CreateJsonfile.UseVisualStyleBackColor = true;
            this.btn_CreateJsonfile.Click += new System.EventHandler(this.btn_CreateJsonfile_Click);
            // 
            // btn_ImportJSon
            // 
            this.btn_ImportJSon.Location = new System.Drawing.Point(179, 26);
            this.btn_ImportJSon.Name = "btn_ImportJSon";
            this.btn_ImportJSon.Size = new System.Drawing.Size(114, 53);
            this.btn_ImportJSon.TabIndex = 2;
            this.btn_ImportJSon.Text = "Import jsonfile";
            this.btn_ImportJSon.UseVisualStyleBackColor = true;
            this.btn_ImportJSon.Click += new System.EventHandler(this.btn_ImportJSon_Click);
            // 
            // lbx_Customers
            // 
            this.lbx_Customers.FormattingEnabled = true;
            this.lbx_Customers.Location = new System.Drawing.Point(30, 106);
            this.lbx_Customers.Name = "lbx_Customers";
            this.lbx_Customers.Size = new System.Drawing.Size(265, 121);
            this.lbx_Customers.TabIndex = 3;
            // 
            // tbx_Smhi
            // 
            this.tbx_Smhi.Location = new System.Drawing.Point(30, 376);
            this.tbx_Smhi.Name = "tbx_Smhi";
            this.tbx_Smhi.Size = new System.Drawing.Size(133, 64);
            this.tbx_Smhi.TabIndex = 4;
            this.tbx_Smhi.Text = "";
            // 
            // btn_SMHI
            // 
            this.btn_SMHI.Location = new System.Drawing.Point(30, 297);
            this.btn_SMHI.Name = "btn_SMHI";
            this.btn_SMHI.Size = new System.Drawing.Size(114, 53);
            this.btn_SMHI.TabIndex = 5;
            this.btn_SMHI.Text = "Import SMHI";
            this.btn_SMHI.UseVisualStyleBackColor = true;
            this.btn_SMHI.Click += new System.EventHandler(this.btn_SMHI_Click);
            // 
            // tbx_IG
            // 
            this.tbx_IG.Location = new System.Drawing.Point(181, 379);
            this.tbx_IG.Name = "tbx_IG";
            this.tbx_IG.Size = new System.Drawing.Size(133, 64);
            this.tbx_IG.TabIndex = 6;
            this.tbx_IG.Text = "";
            // 
            // btn_Import_IG
            // 
            this.btn_Import_IG.Location = new System.Drawing.Point(181, 297);
            this.btn_Import_IG.Name = "btn_Import_IG";
            this.btn_Import_IG.Size = new System.Drawing.Size(114, 53);
            this.btn_Import_IG.TabIndex = 7;
            this.btn_Import_IG.Text = "Import IG";
            this.btn_Import_IG.UseVisualStyleBackColor = true;
            this.btn_Import_IG.Click += new System.EventHandler(this.btn_Import_IG_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 503);
            this.Controls.Add(this.btn_Import_IG);
            this.Controls.Add(this.tbx_IG);
            this.Controls.Add(this.btn_SMHI);
            this.Controls.Add(this.tbx_Smhi);
            this.Controls.Add(this.lbx_Customers);
            this.Controls.Add(this.btn_ImportJSon);
            this.Controls.Add(this.btn_CreateJsonfile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_CreateJsonfile;
        private System.Windows.Forms.Button btn_ImportJSon;
        private System.Windows.Forms.ListBox lbx_Customers;
        private System.Windows.Forms.RichTextBox tbx_Smhi;
        private System.Windows.Forms.Button btn_SMHI;
        private System.Windows.Forms.RichTextBox tbx_IG;
        private System.Windows.Forms.Button btn_Import_IG;
    }
}

