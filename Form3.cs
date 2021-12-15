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
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(10));
            string username_url = "https://www.twitter.com/" + textBox1.Text;
            Form1.driver.Navigate().GoToUrl(username_url);

            //if this account doesn't exists try catch will find this element
            try
            {
                WebDriverWait wait2 = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
                IWebElement text = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div/div[2]/main/div/div/div/div/div/div[2]/div/div/div[2]/div[1]/span")));
                label2.Visible = true;
            }
            catch (Exception)
            {
                //catched an exception means this account does exists
                label2.Visible = false;
                this.Hide();
                Form4 formshow3 = new Form4();
                formshow3.ShowDialog();
                formshow3 = null;
            }
        }
    }
}
