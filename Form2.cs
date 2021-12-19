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

            IWebElement userName_web = Form1.driver.FindElement(By.XPath("//div[@data-testid = 'SideNav_AccountSwitcher_Button']/descendant::div[@dir = 'auto']/descendant::span"));
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
