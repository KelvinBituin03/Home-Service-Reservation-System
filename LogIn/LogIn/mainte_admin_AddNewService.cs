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
    public partial class mainte_admin_AddNewService : Form
    {
        public mainte_admin_AddNewService()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
       /* private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && textBox1.Text.Length == 7)
            {
                e.SuppressKeyPress = true;
            }
        }*/

        string oldText = string.Empty;
       /* private void textBox1_TextChanged(object sender, EventArgs e)
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
        }*/

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string actualdata = string.Empty;
            char[] entereddata = textBox2.Text.ToCharArray();
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
            textBox2.Text = actualdata;
        }

      /*  private void textBox3_TextChanged(object sender, EventArgs e)
        {

            string actualdata = string.Empty;
            char[] entereddata = textBox3.Text.ToCharArray();
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
            textBox3.Text = actualdata;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceName,ServiceType,Price,Duration from dbsystem.tblServices where ServiceName='" + textBox1.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            string a = textBox2.Text.ToString();
            int aa = Convert.ToInt32(a);
            if (aa <= 100)
            {
                MessageBox.Show("Make your price much more real!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox3.Text == "" || textBox4.Text == "")
                {

                    MessageBox.Show("Please fill-up the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {

                    if (dr.Read())
                    {
                        MessageBox.Show("This Service exists already!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string y = null;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox3.Text = y;
                        textBox4.Text = "";

                    }
                    else
                    {
                        if (MessageBox.Show("Add Service?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                             double price;
                             if (double.TryParse(textBox2.Text, out price))
                             {
                                 label15.Text = string.Format("{0:.00}", price);
                             }
                            string tagaMinutes = "minutes";
                            string forDuration;
                            forDuration=textBox4.Text+" "+tagaMinutes;
                            dr.Close();
                            MySqlCommand comm2 = new MySqlCommand("Insert into dbsystem.tblServices (ServiceName,ServiceType,Price,Duration) values ('" + textBox1.Text + "','" + comboBox3.Text + "','" + label15.Text + "','" + forDuration + "')", conn);
                            comm2.ExecuteNonQuery();
                            MessageBox.Show("Sucess!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comboBox1.Items.Add(textBox1.Text);
                            comboBox5.Items.Add(textBox1.Text);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            string y = null;
                            comboBox3.Text = y;
                            textBox4.Text = "";
                            comboBox1.Refresh();

                        }
                        else
                        {


                        }
                    }

                }
            }
    
        }

        private void mainte_admin_AddNewService_Load(object sender, EventArgs e)
        {
            

            comboBox6.Enabled = false;
            comboBox6.Text = "Minutes";
            comboBox7.Enabled = false;
            comboBox7.Text = "Minutes";
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceName,ServiceType,Price,Duration from dbsystem.tblServices", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                if (!comboBox1.Items.Contains(dr[0]))
                {
                    comboBox1.Items.Add(dr[0]);

                }

                if (!comboBox5.Items.Contains(dr[0]))
                {
                    comboBox5.Items.Add(dr[0]);

                }


            }

            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string n = null;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.Text = n;
            comboBox3.Refresh();
            textBox4.Text = "";
            Login from = new Login();
            this.Close();
            from.Show();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            comboBox1.Refresh();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceName,ServiceType,Price,Duration from dbsystem.tblServices where ServiceName='" + comboBox1.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
           
           
            if (dr.Read())
            {
                textBox9.Text = dr["Price"].ToString();
                textBox9.Text = textBox9.Text.Remove(textBox9.Text.Length - 3, 3);
            //    MessageBox.Show(textBox9.Text.ToString());
                   

                textBox8.Text = dr["ServiceName"].ToString();
                comboBox2.Text = dr["ServiceType"].ToString();
                textBox6.Text = textBox9.Text;
                textBox5.Text = dr["Duration"].ToString();
              



            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox8.Text == "" || comboBox2.Text== "" || textBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill-up the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                if (MessageBox.Show("Update Service?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string awaw = textBox6.Text.ToString();
                    int awa = Convert.ToInt32(awaw);

                    if (awa <= 100)
                    {
                        MessageBox.Show("Make your price much more real!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        double price;
                        if (double.TryParse(textBox6.Text, out price))
                        {
                            label16.Text = string.Format("{0:.00}", price);
                        }
                        string tagaMinutes = "minutes";
                        string forDuration;
                        forDuration = textBox5.Text + " " + tagaMinutes;
                        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                        conn.Open();
                        MySqlCommand comm2 = new MySqlCommand("Update dbsystem.tblServices set ServiceType='" + comboBox2.Text + "'where ServiceName='" + comboBox1.Text + "'", conn);
                        comm2.ExecuteNonQuery();
                        MySqlCommand comm3 = new MySqlCommand("Update dbsystem.tblServices set Price='" + label16.Text + "'where ServiceName='" + comboBox1.Text + "'", conn);
                        comm3.ExecuteNonQuery();
                        MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tblServices set Duration='" + forDuration + "'where ServiceName='" + comboBox1.Text + "'", conn);
                        comm4.ExecuteNonQuery();
                        MySqlCommand comm = new MySqlCommand("Update dbsystem.tblServices set ServiceName='" + textBox8.Text + "'where ServiceName='" + comboBox1.Text + "'", conn);
                        comm.ExecuteNonQuery();


                        MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string x = null;
                        textBox8.Text = "";
                        //  textBox7.Text = "";
                        textBox6.Text = "";
                        textBox5.Text = "";
                        comboBox2.Text = x;
                        comboBox1.Text = x;
                        comboBox1.Refresh();
                    }
                }
            }


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           /*if (textBox8.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox8.Text;
                textBox8.Text = oldText;

                textBox8.BackColor = System.Drawing.Color.White;
                textBox8.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox8.Text = oldText;
                textBox8.BackColor = System.Drawing.Color.Red;
                textBox8.ForeColor = System.Drawing.Color.White;
            }
            textBox8.SelectionStart = textBox8.Text.Length;*/
        }

       /* private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = textBox7.Text;
                textBox7.Text = oldText;

                textBox7.BackColor = System.Drawing.Color.White;
                textBox7.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox7.Text = oldText;
                textBox7.BackColor = System.Drawing.Color.Red;
                textBox7.ForeColor = System.Drawing.Color.White;
            }
            textBox7.SelectionStart = textBox7.Text.Length;
        }*/

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

        private void button3_Click(object sender, EventArgs e)
        {
            string x = null;
            textBox8.Text = "";
            //textBox7.Text = "";
            comboBox2.Text = x;
            comboBox2.Refresh();
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox1.Text = x;
            comboBox1.Refresh();
            Login from = new Login();
            this.Close();
            from.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceName,ServiceType,Price,Duration from dbsystem.tblServices where ServiceName='" + comboBox5.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();


            if (dr.Read())
            {

              
               // MessageBox.Show(textBox9.Text.ToString());
                   
                comboBox5.Text = dr["ServiceName"].ToString();
                comboBox4.Text = dr["ServiceType"].ToString();
                textBox7.Text = dr["Price"].ToString();
                textBox3.Text = dr["Duration"].ToString();




            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceName,ServiceType,Price,Duration from dbsystem.tblServices", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                if (!comboBox5.Items.Contains(dr[0]))
                {
                    comboBox5.Items.Add(dr[0]);

                }


            }

            dr.Close();*/
            comboBox5.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a=comboBox5.Text;
            if (MessageBox.Show("Are you sure to delete "+a+"","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Delete from dbsystem.tblServices where ServiceName='" + comboBox5.Text + "'", conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string b = null;
                comboBox5.Text = b;
                comboBox4.Text = b;
                textBox3.Text = "";
                textBox7.Text = "";
                conn.Close();
                conn.Dispose();
                comboBox5.Refresh();

            }
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
                 //   MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox5.Text = actualdata;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
            Login from = new Login();
            from.Show();
            
        }

       
    }
}
