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
            IWebElement profile_pic = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(@href, 'photo')]//img[contains(@src, 'profile')]")));
            string pp_url = profile_pic.GetAttribute("src");
            pictureBox1.Load(pp_url);
            
            IWebElement profile_name = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@data-testid = 'UserName']//div[@dir='auto']//span")));
            label1.Text = profile_name.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
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
    }
}
