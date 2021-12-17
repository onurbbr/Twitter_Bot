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

        WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
        bool follow_stat = false;
        bool block_stat = false;

        private void follow_check() {
            IWebElement follow_button = Form1.driver.FindElement(By.XPath("//div[contains(@aria-label, '@" + Form3.SetValueForText1 + "')]"));
            String follow_check = follow_button.GetAttribute("data-testid");
            if (follow_check.Contains("-follow"))
            {
                this.followUser.BackColor = Color.Gray;
                this.followUser.Text = "Follow User";
            }
            else if (follow_check.Contains("-unfollow"))
            {
                follow_stat = true;
                this.followUser.BackColor = Color.Green;
                this.followUser.Text = "Following User";
                this.followUser.ForeColor = Color.White;
            }
        }

        private void block_check()
        {
            try
            {
                IWebElement block_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@data-testid, 'block')]")));
                block_stat = true;
                this.followUser.Enabled = false;
                blockUserbtn.BackColor = Color.Red;
                blockUserbtn.Text = "Blocked";
                follow_stat = false;
                followUser.Text = "Follow User";
                followUser.BackColor = Color.Gray;
            }
            catch (Exception)
            {
                block_stat = false;
                this.followUser.Enabled = true;
                blockUserbtn.BackColor = Color.Gray;
                blockUserbtn.Text = "Block User";
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Form1.driver.Navigate().Refresh();

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
                this.followUser.Enabled = false;
                blockUserbtn.Enabled = false;
            }

            follow_check();

            block_check();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 formshow3 = new Form3();
            formshow3.ShowDialog();
            formshow3 = null;
        }

        private void followUser_Click(object sender, EventArgs e)
        {
            if (followUser.Text == "Follow User")
            {
                IWebElement follow_button = Form1.driver.FindElement(By.XPath("//div[contains(@aria-label, '@" + Form3.SetValueForText1 + "')]"));
                follow_button.Click();
                follow_stat = true;
            }
            else
            {
                IWebElement follow_button = Form1.driver.FindElement(By.XPath("//div[contains(@aria-label, '@" + Form3.SetValueForText1 + "')]"));
                follow_button.Click();
                IWebElement confirm_buttın = Form1.driver.FindElement(By.XPath("//div[@data-testid = 'confirmationSheetConfirm']"));
                confirm_buttın.Click();
                follow_stat = false;
            }
            follow_check();
        }

        private void blockUserbtn_Click(object sender, EventArgs e)
        {
            if (!block_stat)
            {
                IWebElement action_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-testid = 'userActions']")));
                action_button.Click();
                IWebElement block_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-testid = 'block']")));
                block_button.Click();
                IWebElement confirm_button = Form1.driver.FindElement(By.XPath("//div[@data-testid = 'confirmationSheetConfirm']"));
                confirm_button.Click();
                block_stat = true;
            }
            else
            {
                IWebElement block_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@data-testid , 'block')]")));
                block_button.Click();
                IWebElement confirm_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-testid = 'confirmationSheetConfirm']")));
                confirm_button.Click();
                block_stat=false;
            }

            block_check();
        }

        private void followUser_MouseEnter(object sender, EventArgs e)
        {
            if (follow_stat)
            {
                followUser.Text = "Unfollow User";
                followUser.BackColor = Color.Red;
                followUser.ForeColor = Color.White;
            }
            else
            {
                followUser.Text = "Follow User";
                followUser.BackColor = Color.Gray;
                followUser.ForeColor = Color.Black;
            }
        }

        private void followUser_MouseLeave(object sender, EventArgs e)
        {
            if (follow_stat)
            {
                followUser.Text = "Following User";
                followUser.BackColor = Color.Green;
                followUser.ForeColor = Color.White;
            }
            else
            {
                followUser.Text = "Follow User";
                followUser.BackColor = Color.Gray;
                followUser.ForeColor = Color.Black;
            }
        }

        private void blockUserbtn_MouseEnter(object sender, EventArgs e)
        {
            if (block_stat)
            {
                blockUserbtn.Text = "Unblock";
            }
        }

        private void blockUserbtn_MouseLeave(object sender, EventArgs e)
        {
            if (block_stat)
            {
                blockUserbtn.Text = "Blocked";
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.driver.Quit();
        }
    }
}
