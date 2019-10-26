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
    public partial class Test : Form
    {
        private ImportFromTextFile _textfile;
        
        public Test()
        {
            InitializeComponent();
            _textfile = new ImportFromTextFile();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            lbx_TestList.Items.AddRange(_textfile.ImporteraData().ConvertAll(x => x.ToString()).ToArray());
        }



    }
}
