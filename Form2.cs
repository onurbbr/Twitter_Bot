using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;

namespace Twitter_Bot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 formshow2 = new Form3();
            formshow2.ShowDialog();
            formshow2 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.SetValueForText1;
        }
    }
}
