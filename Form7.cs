using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitter_Bot
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\twitterbot\userDatabase.accdb");
        OleDbCommand AccessCommand;
        OleDbDataAdapter da;

        void listusers()
        {  
            conn.Open();
            da = new OleDbDataAdapter("select * from UserTable", conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }

        
        private void Form7_Load(object sender, EventArgs e)
        {
            listusers();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formshow = new Form1();
            formshow.ShowDialog();
            formshow = null;
        }
    }
}
