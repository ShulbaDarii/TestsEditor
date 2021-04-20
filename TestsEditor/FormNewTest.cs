using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xml2CSharp;

namespace TestsEditor
{
    public partial class FormNewTest : Form
    {
        Form form;
        List<Question> questions;
        List<Answer> answers;
        int right = 0;
        public FormNewTest(Form form)
        {
            InitializeComponent();
            questions = new List<Question>();
            answers = new List<Answer>();
            this.form=form;
        }

        private void buttonSaveTest_Click(object sender, EventArgs e)
        {

                Test test = new Test();
                test.Author = textBoxAutor.Text;
                test.Qty_questions = textBoxQty.Text;
                test.TestName = textBoxTitle.Text;
                test.Question = questions;
            
                XmlSerializer formatter = new XmlSerializer(typeof(Test));

                using (FileStream fs = new FileStream($"test\\{textBoxFileTest.Text}.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, test);

                }
                form.Visible = true;
                Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Visible = true;
            Close();
        }

        private void FormNewTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Visible = true;
        }

        private void buttonAddAns_Click(object sender, EventArgs e)
        {
            Answer answer = new Answer() { Description = textBoxAnswer.Text, IsRight = checkBox1.Checked.ToString() };
            answers.Add(answer);
            listBoxAnswer.Items.Add(answer);
            if (checkBox1.Checked)
            {
                right++;
            }
        }

        private void buttonAddQust_Click(object sender, EventArgs e)
        {
            if (right == 1)
            {
                List<Answer> answers2 = new List<Answer>();
                foreach (Answer answer in answers) {
                    answers2.Add(answer);
                        }
                Question question = new Question() { Answer =answers2, Description = textBoxQustin.Text, Difficulty = numericUpDown1.Value.ToString() };
                questions.Add(question);
                listBoxQustion.Items.Add(question);
                textBoxQty.Text = listBoxQustion.Items.Count.ToString();
                ClearQust();
            }
            else
            {
                MessageBox.Show("must be 1 rigth qustion");
            }
        }

        private void listBoxAnswer_DoubleClick(object sender, EventArgs e)
        {
            int i = listBoxAnswer.SelectedIndex;
            if ((listBoxAnswer.SelectedItem as Answer).IsRight == "True")
            {
                listBoxAnswer.Items[i] = new Answer() { Description = (listBoxAnswer.SelectedItem as Answer).Description, IsRight = "False" };
                answers[i] = new Answer() { Description = (listBoxAnswer.SelectedItem as Answer).Description, IsRight = "False" };
                right--;
            }
            else
            {
                listBoxAnswer.Items[i] = new Answer() { Description = (listBoxAnswer.SelectedItem as Answer).Description, IsRight = "True" };
                answers[i] = new Answer() { Description = (listBoxAnswer.SelectedItem as Answer).Description, IsRight = "True" };
                right++;
            }
        }
        private void ClearQust()
        {
            textBoxAnswer.Text = "";
            textBoxQustin.Text = "";
            listBoxAnswer.Items.Clear();
            answers.Clear();
            numericUpDown1.Value = 1;
            checkBox1.Checked = false;
            right = 0;
        }
        private void buttonClearQust_Click(object sender, EventArgs e)
        {
            ClearQust();
        }
    }
}
