using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace PraktikaApp
{
    public partial class Form1 : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;

        public Form1()
        {
            InitializeComponent();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=utilities");
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Невозможно вставить пустое значение");
                return;
            }
            dataGridView1.Visible = true;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("INSERT INTO base VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10});",
                                                                                        "Иванов И.К.", 
                                                                                        "пр. Стачек",
                                                                                        20,
                                                                                        60,
                                                                                        20*60,
                                                                                        uint.Parse(textBox1.Text),
                                                                                        (uint.Parse(textBox1.Text)*double.Parse(textBox2.Text.Replace('.', ','))).ToString().Replace(',', '.'),
                                                                                        5,
                                                                                        9,
                                                                                        88,
                                                                                        60), conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }
    }
}
