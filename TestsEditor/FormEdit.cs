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
using System.Xml.Serialization;
using Xml2CSharp;

namespace TestsEditor
{
    public partial class FormEdit : Form
    {
        Form form;
        Test test;
        List<Question> questions;
        List<Answer> answers;
        int right = 0;
        public FormEdit(Form form)
        {
            InitializeComponent();
            this.form = form;
            questions = new List<Question>();
            answers = new List<Answer>();
            if (Directory.Exists("test\\"))
            {
                string[] files = Directory.GetFiles("test\\");
                foreach (string s in files)
                {
                    comboBox1.Items.Add(s.Substring(5));
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Author = textBoxAutor.Text;
            test.Qty_questions = textBoxQty.Text;
            test.TestName = textBoxTitle.Text;
            test.Question = questions;

            XmlSerializer formatter = new XmlSerializer(typeof(Test));

            using (FileStream fs = new FileStream($"test\\{comboBox1.SelectedItem.ToString()}", FileMode.Create))
            {
                formatter.Serialize(fs, test);

            }
            form.Visible = true;
            Close();
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
        private void ClearQust()
        {
            textBoxAnswer.Text = "";
            textBoxQustin.Text = "";
            listBoxAnswer.Items.Clear();
            answers.Clear();
            numericUpDown1.Value = 1;
            checkBox1.Checked = false;
            textBox1.Text = "";
            checkBox2.Checked = false;
            right = 0;
        }
        private void buttonAddQust_Click(object sender, EventArgs e)
        {
            if (right == 1)
            {
                List<Answer> answers2 = new List<Answer>();
                foreach (Answer answer in answers)
                {
                    answers2.Add(answer);
                }
                Question question = new Question() { Answer = answers2, Description = textBoxQustin.Text, Difficulty = numericUpDown1.Value.ToString() };
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

        private void FormEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            questions.Clear();
            answers.Clear();
            listBoxQustion.Items.Clear();
            XmlSerializer formatter = new XmlSerializer(typeof(Test));
            using (FileStream fs = new FileStream($"test\\{comboBox1.SelectedItem}", FileMode.OpenOrCreate))
            {
                test = (Test)formatter.Deserialize(fs);
            }
            textBoxTitle.Text = test.TestName;
            textBoxAutor.Text = test.Author;
            textBoxQty.Text = test.Qty_questions;
            foreach (Question question in test.Question)
            {
                listBoxQustion.Items.Add(question);
                questions.Add(question);
            }

        }

        private void listBoxQustion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxQustion.SelectedItem != null)
            {
                listBoxAnswer.Items.Clear();
                answers.Clear();
                right = 1;
                foreach (var answer in (listBoxQustion.SelectedItem as Question).Answer)
                {
                    answers.Add(answer);
                    listBoxAnswer.Items.Add(answer);
                }
                textBoxQustin.Text = (listBoxQustion.SelectedItem as Question).Description;
                numericUpDown1.Value = Convert.ToInt32((listBoxQustion.SelectedItem as Question).Difficulty);
            }
        }

        private void listBoxAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAnswer.SelectedItem != null)
            {
                textBox1.Text = (listBoxAnswer.SelectedItem as Answer).Description;
                if ((listBoxAnswer.SelectedItem as Answer).IsRight == "True")
                    checkBox2.Checked = true;
                else
                    checkBox2.Checked = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            questions.Remove(questions[listBoxQustion.SelectedIndex]);
            listBoxQustion.Items.Remove(listBoxQustion.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if((listBoxAnswer.SelectedItem as Answer).IsRight == "True")
            {
                if (!checkBox2.Checked)
                    right--;
            }
            else
            {
                if (checkBox2.Checked)
                    right++;
            }
            answers[listBoxAnswer.SelectedIndex] = new Answer() { Description = textBox1.Text, IsRight = checkBox2.Checked.ToString() };
            listBoxAnswer.Items[listBoxAnswer.SelectedIndex] = new Answer() { Description = textBox1.Text, IsRight = checkBox2.Checked.ToString() };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (right == 1)
            {
                List<Answer> answers2 = new List<Answer>();
                foreach (Answer answer in answers)
                {
                    answers2.Add(answer);
                }
                Question question = new Question() { Answer = answers2, Description = textBoxQustin.Text, Difficulty = numericUpDown1.Value.ToString() };
                questions[listBoxQustion.SelectedIndex]=question;
                listBoxQustion.Items[listBoxQustion.SelectedIndex]=question;
                textBoxQty.Text = listBoxQustion.Items.Count.ToString();
                ClearQust();
            }
            else
            {
                MessageBox.Show("must be 1 rigth qustion");
            }
        }
    }
}
