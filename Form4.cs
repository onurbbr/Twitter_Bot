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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
            IWebElement profile_pic = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, 'photo')]//img[contains(@src, 'profile_images')]")));
            string pp_url = profile_pic.GetAttribute("src");
            pictureBox1.Load(pp_url);
            
            IWebElement profile_name = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@data-testid = 'UserName']//div[@dir='auto']//span")));
            label1.Text = profile_name.Text;

            IWebElement tweet_count = Form1.driver.FindElement(By.XPath("//div[contains(text(), 'Tweet')]"));
            string t_count = tweet_count.Text;
            if(t_count.Substring(0,1) == "0")
            {
                label2.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 formshow3 = new Form3();
            formshow3.ShowDialog();
            formshow3 = null;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.driver.Quit();
        }
    }
}
