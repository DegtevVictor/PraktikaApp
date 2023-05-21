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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static MySql.Data.MySqlClient.MySqlConnection conn;
        public static bool isAdmin = false;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("SELECT * FROM logins WHERE login = '{0}' AND pass = '{1}';", textBox1.Text, textBox2.Text), conn);
            dataAdapter.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr.Field<string>("role") == "admin") isAdmin = true;
                }
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                if (isAdmin) metroButton1.Visible = true;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Неверные данные для входа");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
