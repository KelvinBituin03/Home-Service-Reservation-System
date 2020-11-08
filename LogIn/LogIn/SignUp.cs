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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                try
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Password and Confirm Password don't match!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {



                        MySqlCommand comm = new MySqlCommand("Insert into dbsystem.users values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "')", conn);
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    }
                catch {
                    MessageBox.Show("Username is already taken, choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            
            
            }

           /* MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Insert into dbsystem.users values ('" + textBox1.Text + "','" + textBox2.Text + "','"+comboBox1.Text+"','"+textBox4.Text+"')", conn);
            comm.ExecuteNonQuery();
            MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

       /* private void timer1_Tick(object sender, EventArgs e)
        {
            if (label7.ForeColor == Color.DarkGray)
            {
                label7.ForeColor = Color.White;
                timer1.Interval = 550;
            }
            else
            {
                label7.ForeColor = Color.DarkGray;
                timer1.Interval = 550;
            }
        }*/

        private void SignUp_Load(object sender, EventArgs e)
        {
            
            //timer1.Start();
          //  timer1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login from = new Login();
            this.Hide();
            from.Show();
        }
       
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {


        }
      


    }
}
