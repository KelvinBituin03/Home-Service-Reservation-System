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
    public partial class Update_Client : Form
    {
        public Update_Client()
        {
            InitializeComponent();
        }

        private void Update_Client_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["FULLNAME"]);

            }
            dr.Close();
            dr.Dispose();

        /*    MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblcstmr where ClientID='" + comboBox1.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            if (dr2.Read())
            {

                textBox2.Text = dr["fname"].ToString();
                textBox3.Text = dr["mname"].ToString();
                textBox4.Text = dr["lname"].ToString();
                textBox5.Text = dr["age"].ToString();
                textBox6.Text = dr["address"].ToString();
                textBox7.Text = dr["ContactNo"].ToString();
                textBox1.Text = dr["Gender"].ToString();
            }
            conn.Close();*/
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Update dbsystem.tblcstmr set fname='" + textBox2.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlCommand comm2 = new MySqlCommand("Update dbsystem.tblcstmr set mname='" + textBox3.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm2.ExecuteNonQuery();
                MySqlCommand comm3 = new MySqlCommand("Update dbsystem.tblcstmr set lname='" + textBox4.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm3.ExecuteNonQuery();
                MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tblcstmr set age='" + textBox5.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm4.ExecuteNonQuery();
                MySqlCommand comm5 = new MySqlCommand("Update dbsystem.tblcstmr set address='" + textBox6.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm5.ExecuteNonQuery();
                MySqlCommand comm6 = new MySqlCommand("Update dbsystem.tblcstmr set ContactNo='" + textBox7.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm6.ExecuteNonQuery();
                MySqlCommand comm7 = new MySqlCommand("Update dbsystem.tblcstmr set Gender='" + comboBox2.Text + "'where FULLNAME='" + comboBox1.Text + "'", conn);
                comm7.ExecuteNonQuery();
                comboBox2.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblcstmr where FULLNAME='" + comboBox1.Text + "'", conn);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            if (dr2.Read())
            {

                textBox2.Text = dr2["fname"].ToString();
                textBox3.Text = dr2["mname"].ToString();
                textBox4.Text = dr2["lname"].ToString();
                textBox5.Text = dr2["age"].ToString();
                textBox6.Text = dr2["address"].ToString();
                textBox7.Text = dr2["ContactNo"].ToString();
               comboBox2.Text = dr2["Gender"].ToString();
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string oldText = string.Empty;
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
            if (textBox4.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox4.Text;
                textBox4.Text = oldText;

                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox4.Text = oldText;
                textBox4.BackColor = System.Drawing.Color.Red;
                textBox4.ForeColor = System.Drawing.Color.White;
            }
            textBox4.SelectionStart = textBox4.Text.Length;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox6.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox6.Text;
                textBox6.Text = oldText;

                textBox6.BackColor = System.Drawing.Color.White;
                textBox6.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox6.Text = oldText;
                textBox6.BackColor = System.Drawing.Color.Red;
                textBox6.ForeColor = System.Drawing.Color.White;
            }
            textBox6.SelectionStart = textBox6.Text.Length;*/
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox7.Text.ToCharArray();
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
            textBox7.Text = actualdata;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox5.Text.ToCharArray();
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
            textBox5.Text = actualdata;
        }
    }
}
