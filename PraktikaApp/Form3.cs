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
        DataTable dataTable;
        public Form3()
        {
            InitializeComponent();
            populateNameList();
            populateValueList();
        }

        private void populateNameList()
        {
            dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fullName FROM base;", Form1.conn);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                comboBox1.Items.Add(dataRow.Field<string>("fullName"));
            }
            if (Form1.isAdmin) comboBox1.Items.Add("Выбрать всех");
        }

        private void populateValueList()
        {
            comboBox2.Items.Add("Плата за квартиру");
            comboBox2.Items.Add("Плата за холодную воду");
            comboBox2.Items.Add("Стоимость отопления");
            comboBox2.Items.Add("Плата за использование газа");
            comboBox2.Items.Add("Плата за горячую воду");
            comboBox2.Items.Add("Общая стоимость");
            comboBox2.Items.Add("Вывести всё");
        }

        Dictionary<int, string> dict = new Dictionary<int, string>
            {
                { 0, "flatPrice" },
                { 1, "coldWaterCost" },
                { 2, "heatingCost" },
                { 3, "gasCost" },
                { 4, "hotWaterCost" },
                { 5, "fullCost" }
            };

        private string createQuery()
        {
            string query;
            string needsWhereClause = (comboBox1.SelectedIndex == comboBox1.Items.Count - 1) ? "" : string.Format(" WHERE fullName = '{0}'", comboBox1.SelectedItem.ToString());
            string beginning = (comboBox1.SelectedIndex == comboBox1.Items.Count - 1) ? "SELECT fullName AS 'Имя', " : "SELECT ";
            if (comboBox2.SelectedIndex == 6) query = string.Format("SELECT * FROM base{0}", needsWhereClause);
            else query = string.Format("{0}{1} AS '{2}' FROM base{3}", beginning, dict[comboBox2.SelectedIndex], comboBox2.SelectedItem.ToString(), needsWhereClause);
            return query;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            string sorting = (metroCheckBox1.Checked) ? " ORDER BY fullName;" : ";";
            dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(createQuery() + sorting, Form1.conn);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}