using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Twitter_Bot
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static string SetValueForText1 = "";

        private void next_form()
        {
            label2.Visible = false;
            SetValueForText1 = textBox1.Text;
            this.Hide();
            Form4 formshow3 = new Form4();
            formshow3.ShowDialog();
            formshow3 = null;
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
                WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
                string username_url = "https://www.twitter.com/" + textBox1.Text;
                Form1.driver.Navigate().GoToUrl(username_url);

                //if this ACCOUNT doesn't exists try catch will find this element
                try
                {
                    IWebElement text = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-testid = 'emptyState']")));
                    try
                    {
                        IWebElement text2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-testid = 'emptyState']/descendant::div[@role = 'button']")));
                        next_form();
                    }
                    catch (Exception)
                    {
                        label2.Text = "This account doesn't exist";
                        label2.Visible = true;
                    }
                }
                catch (Exception)
                {
                    //catched an exception means this ACCOUNT does exists
                    next_form();
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
            System.Windows.Forms.Application.Exit();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#2b3640");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#15202b");
        }
    }
}
