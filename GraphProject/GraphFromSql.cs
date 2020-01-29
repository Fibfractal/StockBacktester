using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    public partial class GraphFromSql : Form
    {
        private ExportToSql _export;

        public GraphFromSql()
        {
            _export = new ExportToSql();
            InitializeComponent();
        }

        private void btn_ExportData_Click(object sender, EventArgs e)
        {
            _export.ExportData();
        }
    }
}
