using System;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;

namespace Twitter_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login(WebDriver driver, string user_mail, string user_pass)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            try
            {
                // locate mail input location
                IWebElement mail = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@autocomplete = 'username']")));
                mail.SendKeys(user_mail + Keys.Enter);

                IWebElement pass = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("password")));
                pass.SendKeys(user_pass + Keys.Enter);
            }
            catch (Exception)
            {
                Console.WriteLine("Login error");
                //throw;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            //options.AddArguments("headless");

            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService("C:\\Program Files\\Google\\Chrome\\Application");
            driverService.HideCommandPromptWindow = true;

            WebDriver driver = new ChromeDriver(driverService, options);
            string url = "https://twitter.com/i/flow/login";

            driver.Navigate().GoToUrl(url);
            login(driver, textBox1.Text.ToString(), textBox2.Text.ToString());
            Thread.Sleep(1000);

            driver.Close();
            driver.Quit();

            string strCmdText;
            strCmdText = "/i /m chromedriver.exe /f";
            System.Diagnostics.Process.Start("taskkill.exe", strCmdText);
        }
    }
}