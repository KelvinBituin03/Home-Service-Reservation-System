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
    public partial class userloginformTRY : Form
    {
        public userloginformTRY()
        {
            InitializeComponent();
        }

        private void userloginformTRY_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select username from userlogintryy.accounts where username='" + textBox1.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MySqlCommand comm2 = new MySqlCommand("Select username,password from userlogintryy.accounts where username='" + textBox1.Text + "'and password='"+textBox2.Text+"'", conn);
                    comm2.ExecuteNonQuery();
                   
                    MySqlDataReader dr2 = comm2.ExecuteReader();
                    if (dr2.Read()) 
                    {
                        MessageBox.Show("Successfully logged-in");
                    }
                    else
                    {

                        MessageBox.Show("Incorrect Password");
                    }


                }
                else
                {

                    MessageBox.Show("This user Doesn't exist");
                }

 


        }
    }
}
