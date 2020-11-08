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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
         //   timer1.Start();
          //  timer1.Enabled = true;
        }

    /*    private void timer1_Tick(object sender, EventArgs e)
        {
            if (label8.ForeColor == Color.DarkGray)
            {
                label8.ForeColor = Color.White;
                timer1.Interval = 550;
            }
            else
            {
                label8.ForeColor = Color.DarkGray;
                timer1.Interval = 550;
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                    //SqlCommand comm = new SqlCommand("Select * from Users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'and SecretQuestion='" + comboBox1.Text + "'and SecretAnswer='" + textBox5.Text + "'", conn);
                   MySqlCommand comm=new MySqlCommand("Select Username,Password from dbsystem.users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlDataReader dr = comm.ExecuteReader();

                    if (dr.Read())
                    {
                       
                            MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'and SecretQuestion='" + comboBox1.Text + "'and SecretAnswer='" + textBox5.Text + "'", conn);
                            dr.Close();
                        comm2.ExecuteNonQuery();
                            MySqlDataReader dr2 = comm2.ExecuteReader();
                            
                        if (dr2.Read())
                            {
                                if (textBox3.Text == textBox4.Text)
                                {
                                    if (textBox2.Text == textBox3.Text)
                                    {
                                        MessageBox.Show("You cannot change into new password with your current password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                    else
                                    {
                                        dr2.Close();
                                        MySqlCommand comm3 = new MySqlCommand("update dbsystem.users set Password='" + textBox3.Text + "'where Username='" + textBox1.Text + "'", conn);
                                        comm3.ExecuteNonQuery();
                                        MessageBox.Show("Password changing success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else {
                                    MessageBox.Show("New Password and Confirm New Password don't match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                                }
                            }
                            else {
                                MessageBox.Show("The Secret Question and Secret Answer don't match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        
                      
                    }
                    else {
                        MessageBox.Show("This User doesn't exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
              
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login from = new Login();
            this.Hide();
            from.Show();
        }
    }
}
