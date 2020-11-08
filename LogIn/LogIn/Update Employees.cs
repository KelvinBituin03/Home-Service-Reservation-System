using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace LogIn
{
    public partial class Update_Employees : Form
    {
        public Update_Employees()
        {
            InitializeComponent();
        }

        private void Update_Employees_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblemp", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["FULLNAME"]);
            }
            dr.Close();
            dr.Dispose();
            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblEmp where FULLNAME='" + comboBox3.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["fname"].ToString();
                textBox2.Text = dr["mname"].ToString();
                textBox3.Text = dr["lname"].ToString();
                textBox4.Text = dr["age"].ToString();
                textBox5.Text = dr["address"].ToString();
                textBox6.Text = dr["ContactNo"].ToString();
                comboBox2.Text = dr["Gender"].ToString();
                comboBox1.Text = dr["Position"].ToString();




            }
            dr.Close();
            dr.Dispose();
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Successfully updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("update dbsystem.tblEmp set fname='" + textBox1.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlCommand comm2 = new MySqlCommand("update dbsystem.tblEmp set mname='" + textBox2.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm2.ExecuteNonQuery();
                MySqlCommand comm3 = new MySqlCommand("update dbsystem.tblEmp set lname='" + textBox3.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm3.ExecuteNonQuery();
                MySqlCommand comm4 = new MySqlCommand("update dbsystem.tblEmp set age='" + textBox4.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm4.ExecuteNonQuery();
                MySqlCommand comm5 = new MySqlCommand("update dbsystem.tblEmp set address='" + textBox5.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm5.ExecuteNonQuery();
                MySqlCommand comm6 = new MySqlCommand("update dbsystem.tblEmp set ContactNo='" + textBox6.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm6.ExecuteNonQuery();
                MySqlCommand comm7 = new MySqlCommand("update dbsystem.tblEmp set Gender='" + comboBox2.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm7.ExecuteNonQuery();
                MySqlCommand comm8 = new MySqlCommand("update dbsystem.tblEmp set Position='" + comboBox1.Text + "'where FULLNAME='" + comboBox3.Text + "'", conn);
                comm8.ExecuteNonQuery();
                MessageBox.Show("Successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboBox3.Text = " ";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";

            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string oldText = string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox1.Text;
                textBox1.Text = oldText;

                textBox1.BackColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox1.Text = oldText;
                textBox1.BackColor = System.Drawing.Color.Red;
                textBox1.ForeColor = System.Drawing.Color.White;
            }
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox2.Text;
                textBox2.Text = oldText;

                textBox2.BackColor = System.Drawing.Color.White;
                textBox2.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox2.Text = oldText;
                textBox2.BackColor = System.Drawing.Color.Red;
                textBox2.ForeColor = System.Drawing.Color.White;
            }
            textBox2.SelectionStart = textBox2.Text.Length;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox3.Text;
                textBox3.Text = oldText;

                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox3.Text = oldText;
                textBox3.BackColor = System.Drawing.Color.Red;
                textBox3.ForeColor = System.Drawing.Color.White;
            }
            textBox3.SelectionStart = textBox3.Text.Length;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox4.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox4.Text = actualdata;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox6.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox6.Text = actualdata;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
