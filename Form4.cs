using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        private bool log_check()
        {
            try
            {
                IWebElement log = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href = '/login']")));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void follow_check()
        {
            IWebElement follow_button = Form1.driver.FindElement(By.XPath("//div[contains(@aria-label, '@" + Form3.SetValueForText1 + "')]"));
            String follow_check = follow_button.GetAttribute("data-testid");
            if (follow_check.Contains("-follow"))
            {
                follow_stat = false;
                followUser.BackColor = ColorTranslator.FromHtml("#eff3f4");
                followUser.ForeColor = ColorTranslator.FromHtml("#0f1419");
                followUser.Text = "Follow User";
            }
            else if (follow_check.Contains("-unfollow"))
            {
                follow_stat = true;
                followUser.Text = "Following";
                followUser.BackColor = ColorTranslator.FromHtml("#15202b");
                followUser.ForeColor = ColorTranslator.FromHtml("#eff3f4");
            }
        }

        private void block_check()
        {
            try
            {
                IWebElement block_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@data-testid, 'block')]")));
                block_stat = true;
                follow_stat = false;
                followUser.Enabled = false;

                followUser.Text = "Follow User";
                followUser.BackColor = Color.Gray;

                blockUserbtn.BackColor = ColorTranslator.FromHtml("#f4212e");
                blockUserbtn.Text = "Blocked";
            }
            catch (Exception)
            {
                block_stat = false;
                followUser.Enabled = true;

                blockUserbtn.BackColor = Color.Gray;
                blockUserbtn.Text = "Block User";

                followUser.BackColor = ColorTranslator.FromHtml("#eff3f4");
                followUser.ForeColor = ColorTranslator.FromHtml("#0f1419");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            while (log_check())
            {
                Form1.driver.Navigate().Refresh();
            }
            IWebElement profile_pic = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, 'photo')]//img[contains(@src, 'profile_images')]")));
            string pp_url = profile_pic.GetAttribute("src");
            pictureBox1.Load(pp_url);

            IWebElement profile_name = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@data-testid = 'UserName']//div[@dir='auto']//span")));
            label1.Text = profile_name.Text;

            IWebElement tweet_count = Form1.driver.FindElement(By.XPath("//div[contains(text(), 'Tweet')]"));
            string t_count = tweet_count.Text;
            if (t_count.Substring(0, 1) == "0")
            {
                label2.Visible = true;
                followUser.Enabled = false;
                blockUserbtn.Enabled = false;
            }

            block_check();

            if (!block_stat)
            {
                follow_check();
            }
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
                IWebElement confirm_button = Form1.driver.FindElement(By.XPath("//div[@data-testid = 'confirmationSheetConfirm']"));
                confirm_button.Click();
                follow_stat = false;
            }

            follow_check();
            block_check();
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

                followUser.Text = "Follow User";
                followUser.BackColor = Color.Gray;
                followUser.ForeColor = Color.Black;
                followUser.Enabled = false;
            }
            else
            {
                IWebElement block_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@data-testid , 'block')]")));
                block_button.Click();
                IWebElement confirm_button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-testid = 'confirmationSheetConfirm']")));
                confirm_button.Click();
                block_stat = false;
            }

            block_check();

        }

        private void followUser_MouseEnter(object sender, EventArgs e)
        {
            if (follow_stat)
            {
                followUser.Text = "Unfollow User";
                followUser.BackColor = ColorTranslator.FromHtml("#2c202c");
                followUser.ForeColor = ColorTranslator.FromHtml("#f4212e");
            }
            else
            {
                followUser.Text = "Follow User";
                followUser.BackColor = ColorTranslator.FromHtml("#d7dbdc");
                followUser.ForeColor = ColorTranslator.FromHtml("#0f1419");
            }
        }

        private void followUser_MouseLeave(object sender, EventArgs e)
        {
            if (follow_stat)
            {
                followUser.Text = "Following";
                followUser.BackColor = ColorTranslator.FromHtml("#15202b");
                followUser.ForeColor = ColorTranslator.FromHtml("#eff3f4");
            }
            else
            {
                followUser.Text = "Follow User";
                followUser.BackColor = ColorTranslator.FromHtml("#eff3f4");
                followUser.ForeColor = ColorTranslator.FromHtml("#0f1419");
            }
        }

        private void blockUserbtn_MouseEnter(object sender, EventArgs e)
        {
            if (block_stat)
            {
                blockUserbtn.Text = "Unblock";
                blockUserbtn.BackColor = ColorTranslator.FromHtml("#dc1e29");
            }
        }

        private void blockUserbtn_MouseLeave(object sender, EventArgs e)
        {
            if (block_stat)
            {
                blockUserbtn.Text = "Blocked";
                blockUserbtn.BackColor = ColorTranslator.FromHtml("#f4212e");
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.driver.Quit();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#2b3640");
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#15202b");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 formshow3 = new Form3();
            formshow3.ShowDialog();
            formshow3 = null;
        }
    }
}
