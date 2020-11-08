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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == ""  || textBox3.Text == "" ||  textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                MySqlCommand comm2 = new MySqlCommand("Select fname,mname,lname from dbsystem.tblemp where fname='" + textBox1.Text + "'and mname='" + textBox2.Text + "'and lname='" + textBox3.Text + "'", conn);
                MySqlDataReader dr = comm2.ExecuteReader();
                if (dr.Read())
                {

                    MessageBox.Show("This user already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = ""; 
                    textBox6.Text = "";

                    string x = null;
                    comboBox1.Text = x;
                    comboBox2.Text = x;


                }
                else
                {
                    string es = " ";
                    string ez = ",";
                    textBox7.Text = textBox3.Text + ez + es + textBox1.Text + es + textBox2.Text;
                    dr.Close();
                    MySqlCommand comm = new MySqlCommand("Insert into dbsystem.tblemp (fname,mname,lname,age,address,ContactNo,Position,Gender,FULLNAME) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','"+textBox7.Text+"')", conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Success", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    string x = null;
                    comboBox1.Text = x;
                    comboBox2.Text = x;



                }
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        string oldText = string.Empty;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox5.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox5.Text;
                textBox5.Text = oldText;

                textBox5.BackColor = System.Drawing.Color.White;
                textBox5.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox5.Text = oldText;
                textBox5.BackColor = System.Drawing.Color.Red;
                textBox5.ForeColor = System.Drawing.Color.White;
            }
            textBox5.SelectionStart = textBox5.Text.Length;*/
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int myAge =
DateTime.Today.Year - dateTimePicker1.Value.Year; // CurrentYear - YourBirthDate

            textBox4.Text = myAge.ToString();
        }
      
    }
}
