using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraktikaApp
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter;
        public Form3()
        {
            InitializeComponent();
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT * FROM base;"), Form1.conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
