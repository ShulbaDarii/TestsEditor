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
    public partial class FormEdit : Form
    {
        Form form;
        public FormEdit(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Visible = true;
            Close();
        }

        private void buttonAddAns_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddQust_Click(object sender, EventArgs e)
        {

        }
    }
}
