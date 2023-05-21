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
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter;
        DataTable dataTable;
        public Form4()
        {
            InitializeComponent();
            populateNameList();
        }

        private void populateNameList()
        {
            metroComboBox1.Items.Clear();
            dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fullName FROM base;", Form1.conn);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                metroComboBox1.Items.Add(dataRow.Field<string>("fullName"));
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить данные о " + metroComboBox1.SelectedItem.ToString() + "?", "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("DELETE FROM base WHERE fullName = '{0}'", metroComboBox1.SelectedItem.ToString()), Form1.conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
            }
            else return;
            populateNameList();
        }
    }
}
