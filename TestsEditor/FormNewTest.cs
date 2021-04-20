using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestsEditor
{
    public partial class FormNewTest : Form
    {
        bool visibal;
        public FormNewTest(bool visibal)
        {
            InitializeComponent();
            this.visibal = visibal;
        }

        private void buttonSaveTest_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            visibal = true;
            Close();
        }
    }
}
