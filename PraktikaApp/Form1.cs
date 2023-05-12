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

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = string.Format("server=127.0.0.1;uid={0};pwd={1};database=utilities", textBox1.Text, textBox2.Text);
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (conn.State.ToString() == "Open")
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
