using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace Twitter_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool login(WebDriver driver, string user_mail, string user_pass)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));//a[@data-testid = 'login']
            try
            {
                //first login button
                IWebElement button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@data-testid, 'login')]")));
                button.Click();

                // locate mail input location
                IWebElement mail = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@dir = 'auto']")));
                mail.SendKeys(user_mail + Keys.Enter);

                //locate input only one input apears usually
                IWebElement telephone_input = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@dir = 'auto']")));

                //get name of input
                String input_name = telephone_input.GetAttribute("name");

                //if input name is text it means that wants username of tel
                if (input_name == "text")
                {
                    telephone_input.SendKeys(textBox1.Text + Keys.Enter);
                }

                //locate pass input and write pass
                IWebElement pass = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("password")));
                pass.SendKeys(user_pass + Keys.Enter);

                Thread.Sleep(5000);

                if (driver.Url == "https://twitter.com/i/flow/login")
                {
                    return false;
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public static WebDriver driver;
        public static string SetValueForText1 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Substring(0, 1) != "@")
            {
                label3.Text = "Your username must start with \"@\"";
                label3.Visible = true;
                return;
            }
            label3.Visible = false;
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            //options.AddArgument("--user-data-dir=" + System.IO.Path.GetTempPath() + "\\twitter_bot_user_data\\" + textBox1.Text.ToString());
            options.AddArguments("headless");

            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService("C:\\Program Files\\Google\\Chrome\\Application");
            driverService.HideCommandPromptWindow = true;


            // !login(driver, textBox1.Text.ToString(), textBox2.Text.ToString())
            // 1 != 1
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label3.Visible = true;
            }
            else
            {
                driver = new ChromeDriver(driverService, options);
                string url = "https://twitter.com/";
                driver.Navigate().GoToUrl(url);

                if (!login(driver, textBox1.Text.ToString(), textBox2.Text.ToString()))
                {
                    Console.WriteLine("Login Error! Plz try again!");
                    label3.Visible = true;
                    driver.Quit();
                }
                else
                {

                    SetValueForText1 = textBox1.Text;
                    this.Hide();
                    Form2 formshow = new Form2();
                    formshow.ShowDialog();
                    formshow = null;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "jopqzijeudbr@pussport.com";
            textBox2.Text = "9YNkEfnv";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 formshow = new Form7();
            formshow.ShowDialog();
            formshow = null;
        }
    }
}