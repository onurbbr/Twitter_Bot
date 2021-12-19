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

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\kaanm\source\repos\onurbbr\Twitter_Bot\userDatabase.accdb");
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

        /*
        private void showInformation()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=database.accdb");
            conn.Open();
            listView1.Items.Clear();
            
            
            AccessCommand.Connection = conn;
            AccessCommand.CommandText = ("Select * from LoginHistory");
            OleDbDataReader read = AccessCommand.ExecuteReader();
            while (read.Read())
            {
                ListViewItem addNew = new ListViewItem();
                addNew.Text = read["ID"].ToString();
                addNew.SubItems.Add(read["Username"].ToString());
                addNew.SubItems.Add(read["Usertag"].ToString());
                addNew.SubItems.Add(read["CurrDate"].ToString());
                listView1.Items.Add(addNew);
            }
            conn.Close();
        }
        */
        private void Form7_Load(object sender, EventArgs e)
        {
            //showInformation();
            listusers();
        }

    }
}
