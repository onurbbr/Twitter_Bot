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
        OleDbConnection databasecon;
        OleDbCommand connectdat;
        OleDbDataAdapter da;


        void listusers ()
        {
            databasecon = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb");
            databasecon.Open ();
            da = new OleDbDataAdapter("select * from LoginHistory", databasecon);
            DataTable tablo = new DataTable();
            da.Fill (tablo);

        }
        public Form7()
        {
            InitializeComponent();
        }

    }
}
