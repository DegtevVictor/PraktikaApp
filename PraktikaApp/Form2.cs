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
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;
        public Form2()
        {
            InitializeComponent();
        }

        private bool areAllFieldsFilled()
        {
            return !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(string.Format("INSERT INTO base VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10});",
                                                                                        textBox1.Text,
                                                                                        textBox2.Text,
                                                                                        textBox3.Text,
                                                                                        textBox4.Text,
                                                                                        (double.Parse(textBox3.Text) * double.Parse(textBox4.Text)).ToString().Replace(',', '.'),
                                                                                        textBox5.Text,
                                                                                        (uint.Parse(textBox5.Text) * 78.06).ToString().Replace(',', '.'),
                                                                                        (double.Parse(textBox4.Text) * 5.49).ToString().Replace(',', '.'),
                                                                                        (uint.Parse(textBox5.Text) * 9.3).ToString().Replace(',', '.'),
                                                                                        (uint.Parse(textBox5.Text) * 88.72).ToString().Replace(',', '.'),
                                                                                        (double.Parse(textBox3.Text) * double.Parse(textBox4.Text) + uint.Parse(textBox5.Text) * 78.06 + double.Parse(textBox4.Text) * 5.49 + uint.Parse(textBox5.Text) * 9.3 + uint.Parse(textBox5.Text) * 88.72).ToString().Replace(',', '.')), Form1.conn);
            try
            {
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Успешно внесены данные");
        }

        private void _TextChanged(object sender, EventArgs e)
        {
            if (areAllFieldsFilled()) button1.Enabled = true;
            else button1.Enabled = false;
        }
    }
}