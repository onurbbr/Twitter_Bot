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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(10));
            string username_url = "https://www.twitter.com/" + textBox1.Text;
            Form1.driver.Navigate().GoToUrl(username_url);
        }
    }
}
