﻿using System;
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
        bool visibal = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNewTest form = new FormNewTest(Visible);
            form.Show();
            Visible = false;
        }
    }
}
