using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using System.Data.OleDb;

namespace Twitter_Bot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 formshow2 = new Form3();
            formshow2.ShowDialog();
            formshow2 = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 formshow3 = new Form5();
            formshow3.ShowDialog();
            formshow3 = null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.SetValueForText1;

            Form1.driver.Navigate().GoToUrl("https://twitter.com/" + Form1.SetValueForText1);

            WebDriverWait wait = new WebDriverWait(Form1.driver, TimeSpan.FromSeconds(5));
            IWebElement userName_web = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@data-testid = 'UserName']/descendant::div[@dir = 'auto']/descendant::span/descendant::span")));
            string userName_str = userName_web.Text;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\twitterbot\userDatabase.accdb");
            OleDbDataAdapter da;
            conn.Open();
            OleDbCommand command = new OleDbCommand("insert into UserTable (UserName, UserTag) values ('" + Form1.SetValueForText1.ToString() + "', '" + userName_str.ToString() + "')", conn);
            conn.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.driver.Quit();
        }
    }
}
