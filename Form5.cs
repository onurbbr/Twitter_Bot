using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Windows.Forms;

namespace Twitter_Bot
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label2.Text = "Must not be empty";
                label2.Visible = true;
            }
            else
            {
                if (textBox1.Text.Length < 28 || textBox1.Text.Substring(0, 20) != "https://twitter.com/" || !textBox1.Text.Contains("status"))
                {
                    label2.Text = "Your link must start with https://twitter.com/";
                    label2.Visible = true;
                }
                else
                {
                    Form1.driver.Navigate().GoToUrl(textBox1.Text);
                    //if this TWEET doesn't exists try catch will find this element
                    try
                    {
                        WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
                        IWebElement text = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-testid = 'error-detail']")));
                        label2.Text = "This tweet doesn't exist";
                        label2.Visible = true;
                    }
                    catch (Exception)
                    {
                        //catched an exception means this TWEET does exists
                        label2.Visible = false;
                        this.Hide();
                        Form6 formshow6 = new Form6();
                        formshow6.ShowDialog();
                        formshow6 = null;
                    }
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

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.driver.Quit();
            System.Windows.Forms.Application.Exit();
        }
    }
}
