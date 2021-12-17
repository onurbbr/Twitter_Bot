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

        public static string SetValueForText1 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible= false;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label2.Text = "Must not be empty";
                label2.Visible=true;
            }
            else
            {
                WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(10));
                string username_url = "https://www.twitter.com/" + textBox1.Text;
                Form1.driver.Navigate().GoToUrl(username_url);

                //if this ACCOUNT doesn't exists try catch will find this element
                try
                {
                    WebDriverWait wait2 = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
                    IWebElement text = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-testid = 'emptyState']")));
                    label2.Text = "This account doesn't exist";
                    label2.Visible = true;
                }
                catch (Exception)
                {
                    //catched an exception means this ACCOUNT does exists
                    label2.Visible = false;
                    SetValueForText1 = textBox1.Text;
                    this.Hide();
                    Form4 formshow3 = new Form4();
                    formshow3.ShowDialog();
                    formshow3 = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 formshow2 = new Form2();
            formshow2.ShowDialog();
            formshow2 = null;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.driver.Quit();
        }
    }
}
