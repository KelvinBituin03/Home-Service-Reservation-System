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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select * from dbsystem.users where Username='" + textBox1.Text + "'and SecretQuestion='" + comboBox1.Text + "'and SecretAnswer='" + textBox2.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();


                if (dr.Read())
                {

                   
                    MessageBox.Show("Your Password is ---> "+ dr["Password"].ToString(),"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);




                }
                else
                {
                    MessageBox.Show("This Username doesn't exist or the Secret Question/Secret Answer is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Login from = new Login();
            this.Hide();
            from.Show();

        }

      /*  private void timer1_Tick(object sender, EventArgs e)
        {
            if (label5.ForeColor == Color.DarkGray)
            {
                label5.ForeColor = Color.White;
                timer1.Interval = 550;
            }
            else
            {
                label5.ForeColor = Color.DarkGray;
                timer1.Interval = 550;
            }
        }*/

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            //timer1.Start();
           // timer1.Enabled = true;
        }
    }
}
