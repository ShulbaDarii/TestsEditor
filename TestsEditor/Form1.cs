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
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNewTest form = new FormNewTest(this);
            form.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNewTest form = new FormNewTest(this);
            form.Show();
            Visible = false;
        }
    }
}
