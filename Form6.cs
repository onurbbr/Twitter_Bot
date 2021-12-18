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

        IWebElement profile_tag;
        WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));

        bool retweet_stat = false;
        bool like_stat = false;

        private void check_like()
        {
            IWebElement l_btn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//article[@data-testid = 'tweet']/descendant::div[contains(@data-testid , 'like')])[1]")));
            String stat = l_btn.GetAttribute("data-testid");
            if (stat == "unlike")
            {
                Like_btn.Text = "Liked";
                Like_btn.BackColor = ColorTranslator.FromHtml("#f91880");
                Like_btn.Font = new Font(Like_btn.Font.Name, 12, FontStyle.Bold);
            }
            else
            {
                Like_btn.Text = "Like";
                Like_btn.BackColor = SystemColors.Control;
                Like_btn.Font = new Font(Like_btn.Font.Name, 12, FontStyle.Regular);
            }
        }
        
        private void check_retweet()
        {
            IWebElement l_btn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//article[@data-testid = 'tweet']/descendant::div[contains(@data-testid , 'retweet')])[1]")));
            String stat = l_btn.GetAttribute("data-testid");
            if (stat == "unretweet")
            {
                Retweet_btn.BackColor = ColorTranslator.FromHtml("#00ba7c");
                Retweet_btn.Font = new Font(Like_btn.Font.Name, 12, FontStyle.Bold);
                Retweet_btn.Text = "Retweeted";
            }
            else
            {
                Retweet_btn.BackColor = SystemColors.Control;
                Retweet_btn.Font = new Font(Like_btn.Font.Name, 12, FontStyle.Regular);
                Retweet_btn.Text = "Retweet";
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Form1.driver.Navigate().Refresh();

            IWebElement profile_pic = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//a//div//img[contains(@src, 'profile_images')])[1]")));
            string pp_url = profile_pic.GetAttribute("src");
            pictureBox1.Load(pp_url);

            IWebElement profile_tweet = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//article//div[@dir='auto' and @lang])[1]")));
            label1.Text = profile_tweet.Text;

            IWebElement profile_name = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//a//div[@dir = 'auto']//span//span)[1]")));
            label2.Text = profile_name.Text;

            profile_tag = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//a//div[@dir = 'ltr'])[1]")));
            label3.Text = profile_tag.Text;
            
            check_retweet();
            check_like();
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
        
        private void Retweet_btn_Click(object sender, EventArgs e)
        {
            if (Retweet_btn.Text == "Retweet")
            {
                IWebElement r_btn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("(//article[@data-testid = 'tweet']/descendant::div[@data-testid = 'retweet'])[1]")));
                r_btn.Click();
                IWebElement r_btn2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role = 'menuitem' and @data-testid='retweetConfirm']")));
                r_btn2.Click();
                
                retweet_stat = true;
            }
            else
            {
                IWebElement unr_btn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-testid = 'unretweet']")));
                unr_btn.Click();
                IWebElement unr_btn2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role = 'menuitem' and @data-testid = 'unretweetConfirm']")));
                unr_btn2.Click();

                retweet_stat = false;
            }
            check_retweet();
        }

        private void Like_btn_Click(object sender, EventArgs e)
        {
            if (Like_btn.Text == "Like")
            {
                IWebElement l_btn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//article[@data-testid = 'tweet']/descendant::div[@data-testid = 'like'])[1]")));
                l_btn.Click();
                like_stat = true;
            }
            else
            {
                IWebElement unl_btn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//article[@data-testid = 'tweet']/descendant::div[@data-testid = 'unlike']")));
                unl_btn.Click();
                like_stat = false;
            }
            check_like();
        }

        private void Retweet_btn_MouseEnter(object sender, EventArgs e)
        {
            if (retweet_stat)
            {
                Retweet_btn.BackColor = ColorTranslator.FromHtml("#19d798");
                Retweet_btn.Text = "Unretweet";
            }
        }

        private void Retweet_btn_MouseLeave(object sender, EventArgs e)
        {
            if (retweet_stat)
            {
                Retweet_btn.BackColor = ColorTranslator.FromHtml("#00ba7c");
                Retweet_btn.Text = "Retweeted";
            }
        }

        private void Like_btn_MouseEnter(object sender, EventArgs e)
        {
            if (like_stat)
            {
                Like_btn.BackColor = ColorTranslator.FromHtml("#ff5aa6");
                Like_btn.Text = "Unlike";
            }
        }

        private void Like_btn_MouseLeave(object sender, EventArgs e)
        {
            if (like_stat)
            {
                Like_btn.BackColor = ColorTranslator.FromHtml("#fb3d94");
                Like_btn.Text = "Liked";
            }
        }
    }
}
