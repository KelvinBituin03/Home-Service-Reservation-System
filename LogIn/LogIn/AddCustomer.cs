using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace LogIn
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            if (label9.ForeColor == Color.DarkGray)
            {
                label9.ForeColor = Color.White;
                timer1.Interval = 550;
            }
            else
            {
                label9.ForeColor = Color.DarkGray;
                timer1.Interval = 550;
            }
        }*/

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            
           // timer1.Start();
            //timer1.Enabled = true;
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm3 = new MySqlCommand("Select fname,mname,lname from dbsystem.tblCstmr where fname='" + textBox1.Text + "'and mname='" + textBox2.Text + "'and lname='" + textBox3.Text + "'", conn2);
                MySqlDataReader dr = comm3.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("This user already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    string x = null;
                    comboBox1.Text = x;
                }
                else
                {
                    dr.Close();

                    string es = " ";
                    string ez = ",";
                    textBox7.Text = textBox3.Text +ez+ es + textBox1.Text + es + textBox2.Text;
                    MySqlCommand comm4 = new MySqlCommand("Insert into dbsystem.tblCstmr (fname,mname,lname,age,address,ContactNo,Gender,FULLNAME) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','"+textBox7.Text+"')", conn2);
                    comm4.ExecuteNonQuery();
                    MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    string x = null;
                    comboBox1.Text = x;
                   
                   



                }
                conn2.Close();
            }

        


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        string oldText = string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox2.Text.All(chr => char.IsLetter(chr)))
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
            textBox2.SelectionStart = textBox2.Text.Length;*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox3.Text.All(chr => char.IsLetter(chr)))
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
            textBox3.SelectionStart = textBox3.Text.Length;*/
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int myAge =
            DateTime.Today.Year - dateTimePicker1.Value.Year; // CurrentYear - YourBirthDate

            textBox5.Text = myAge.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
       
        
    }
}
