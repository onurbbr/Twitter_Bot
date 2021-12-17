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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
            IWebElement profile_pic = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//a//div//img[contains(@src, 'profile_images')])[1]")));
            string pp_url = profile_pic.GetAttribute("src");
            pictureBox1.Load(pp_url);

            IWebElement profile_tweet = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//article//div[@dir='auto' and @lang])[1]")));
            label1.Text = profile_tweet.Text;

            IWebElement profile_name = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//a//div[@dir = 'auto']//span//span)[1]")));
            label2.Text = profile_name.Text;

            IWebElement profile_tag = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//a//div[@dir = 'ltr'])[1]")));
            label3.Text = profile_tag.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 formshow2 = new Form5();
            formshow2.ShowDialog();
            formshow2 = null;
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.driver.Quit();
        }
    }
}
