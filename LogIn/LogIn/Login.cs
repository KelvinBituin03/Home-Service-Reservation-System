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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignUp from = new SignUp();
            this.Hide();
            from.Show();
           

        }
       
     public void button1_Click(object sender, EventArgs e)
        {

            string userIdentifier = "";

         //  testfordecimal from5 = new testfordecimal();
           // from5.Show();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
           
                userIdentifier = "admin";
                Main from = new Main();
                from.MyProperty = userIdentifier;
                this.Hide();
                from.Show();
                DateTime now=DateTime.Now;


                MySqlCommand comm = new MySqlCommand("insert into dbsystem.userslogin(Username,TimeIn) values ('" + textBox1.Text + "','" + now + "')", conn);
                comm.ExecuteNonQuery();
                

            }
            else
            {
                
                MySqlCommand comm = new MySqlCommand("Select Username,Password from dbsystem.users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    DateTime now = DateTime.Now;

                    dr.Close();  
                    MySqlCommand comm2 = new MySqlCommand("insert into dbsystem.userslogin(Username,TimeIn) values ('" + textBox1.Text + "','" + now + "')", conn);
                    comm2.ExecuteNonQuery();
                  //  MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    userIdentifier = "receptionist";
                    
                    Main from = new Main();
                    from.MyProperty = userIdentifier;
                    this.Hide();
                    from.Show();
                  
                 //   testfordecimal test = new testfordecimal();
                   // test.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label7.Hide();
           // timer1.Start();
            //timer1.Enabled = true;
            linkLabel2.Hide();
        }

       /* private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random(); 
            int A = rand.Next(169,169); 
            int R = rand.Next(0, 255);
            int G = rand.Next(169,169); 
            int B = rand.Next(0,255); 
            label5.ForeColor = Color.FromArgb(A, R, G, B);
            if (label5.ForeColor == Color.DarkGray)
            {
                label5.ForeColor = Color.White; 
                timer1.Interval = 550; 
            } else {
                label5.ForeColor = Color.DarkGray;
             timer1.Interval =550; }


        }*/

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp from = new SignUp();
            this.Hide();
            from.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword from = new ForgotPassword();
            this.Hide();
            from.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword from = new ChangePassword();
            this.Hide();
            from.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
