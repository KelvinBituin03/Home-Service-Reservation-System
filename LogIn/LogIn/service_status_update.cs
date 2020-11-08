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
    public partial class service_status_update : Form
    {
        public service_status_update()
        {
            InitializeComponent();
        }
        string storeData;

        private void service_status_update_Load(object sender, EventArgs e)
        {
            string a = "";
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select TransID from dbsystem.tbltrans where Status='"+a+"'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            dr.Dispose();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            comboBox1.Items.Remove(storeData);
            comboBox1.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans where TransID='" + comboBox1.Text + "'", conn);
            comm.ExecuteNonQuery();

            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox4.Text = dr["ClientID"].ToString();
                textBox5.Text = dr["FULLNAME"].ToString();
                textBox2.Text = dr["Service"].ToString();
                textBox1.Text = dr["AssignedEmp"].ToString();
                textBox3.Text = dr["AssignedDriver"].ToString();
                textBox6.Text = dr["StartTime"].ToString();
                textBox7.Text = dr["EndTime"].ToString();
                textBox8.Text = dr["DateOfService"].ToString();
                label10.Text = dr["DateMade"].ToString();
                dr.Close();
            

            }*/
            comboBox3.Text = "";
            comboBox3.Items.Clear();
            comboBox3.Refresh();
            MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn2.Open();
            MySqlCommand comm2 = new MySqlCommand("Select Service from dbsystem.tbltrans where TransID='"+comboBox1.Text+"'", conn2);
            MySqlDataReader dr2 = comm2.ExecuteReader();

            while (dr2.Read())
            {
                if (!comboBox3.Items.Contains(dr2[0]))
                {
                    comboBox3.Items.Add(dr2[0]);

                }


            }
            comboBox3.Sorted = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

           // var a=DateTime.Parse(textBox8.Text);
          //  DateTime vava = a;


           // MessageBox.Show(vava.ToString());
            
          //  DateTime _date = DateTime.Today;
         //   MessageBox.Show(_date.ToShortDateString());

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
            if (comboBox2.Text == "" || comboBox1.Text=="")
            {
                MessageBox.Show("Please Select a status or TransID ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
 
                if (comboBox2.Text == "Success")
                {

                    DateTime nownow = DateTime.Today;
                    DateTime nownownow = DateTime.Now;
                    var _dateString = nownow.ToString("MM/dd/yyyy");
                    var v = textBox8.Text;
                    if (MessageBox.Show("Transaction's date is " + v.ToString() + " and current date is " + _dateString.ToString() + "", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                        comm10.ExecuteNonQuery();

                        decimal presyo = (decimal)comm10.ExecuteScalar();
                        MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tblTrans set Status='" + comboBox2.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                        comm4.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DateTime now = DateTime.Now;
                        MySqlCommand comm5 = new MySqlCommand("Insert into dbsystem.tbltrans2 (Price,TransID,Status,ClientID,FULLNAME,Service,AssignedEmp,AssignedDriver,StartTime,EndTime,DateCancelled,DateMade,DateOfService) values ('"+presyo+"','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + nownownow.ToString() + "','" + label10.Text + "','" + textBox8.Text + "')", conn);
                        comm5.ExecuteNonQuery();
                      //  comboBox1.Items.Remove(comboBox1.Text);
                        comboBox1.Text = null;
                        comboBox2.Text = null;
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox2.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";

                        
                        
                    }

                }
                else if(comboBox2.Text=="Success,no payment")
                {
                    MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                    comm10.ExecuteNonQuery();

                    decimal presyo = (decimal)comm10.ExecuteScalar();
                    MySqlCommand comm = new MySqlCommand("Update dbsystem.tblTrans set Status='" + comboBox2.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DateTime now = DateTime.Now;
                    MySqlCommand comm2 = new MySqlCommand("Insert into dbsystem.tbltrans2 (Price,TransID,Status,ClientID,FULLNAME,Service,AssignedEmp,AssignedDriver,StartTime,EndTime,DateCancelled,DateMade,DateOfService) values ('"+presyo+"','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + now.ToString() + "','" + label10.Text + "','" + textBox8.Text + "')", conn);
                    comm2.ExecuteNonQuery();
                  //  comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = null;
                    comboBox2.Text = null;
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                else if (comboBox2.Text == "Failed,no show")
                {
                    MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                    comm10.ExecuteNonQuery();

                    decimal presyo = (decimal)comm10.ExecuteScalar();
                    MySqlCommand comm = new MySqlCommand("Delete from dbsystem.tbltrans where TransID='" + comboBox1.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DateTime now = DateTime.Now;
                    MySqlCommand comm2 = new MySqlCommand("Insert into dbsystem.tbltrans2 (Price,TransID,Status,ClientID,FULLNAME,Service,AssignedEmp,AssignedDriver,StartTime,EndTime,DateCancelled,DateMade,DateOfService) values ('"+presyo+"','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + now.ToString() + "','" + label10.Text + "','" + textBox8.Text + "')", conn);
                    comm2.ExecuteNonQuery();
                 //   comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = null;
                    comboBox2.Text = null;
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                else if (comboBox2.Text == "Ongoing")
                {
                    MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                    comm10.ExecuteNonQuery();

                    decimal presyo = (decimal)comm10.ExecuteScalar();
                    MySqlCommand comm = new MySqlCommand("Update dbsystem.tblTrans set Status='" + comboBox2.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DateTime now = DateTime.Now;
                    MySqlCommand comm2 = new MySqlCommand("Insert into dbsystem.tbltrans2 (Price,TransID,Status,ClientID,FULLNAME,Service,AssignedEmp,AssignedDriver,StartTime,EndTime,DateCancelled,DateMade,DateOfService) values ('"+presyo+"','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + now.ToString() + "','" + label10.Text + "','" + textBox8.Text + "')", conn);
                    comm2.ExecuteNonQuery();
                  //  comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = null;
                    comboBox2.Text = null;
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                else if (comboBox2.Text == "Cancelled")
                {

                    MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                    comm10.ExecuteNonQuery();

                    decimal presyo = (decimal)comm10.ExecuteScalar();
                    MySqlCommand comm = new MySqlCommand("Delete from dbsystem.tbltrans where TransID='" + comboBox1.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DateTime now = DateTime.Now;
                    MySqlCommand comm2 = new MySqlCommand("Insert into dbsystem.tbltrans2 (Price,TransID,Status,ClientID,FULLNAME,Service,AssignedEmp,AssignedDriver,StartTime,EndTime,DateCancelled,DateMade,DateOfService) values ('"+presyo+"','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + now.ToString() + "','" + label10.Text + "','" + textBox8.Text + "')", conn);
                    comm2.ExecuteNonQuery();
                //    comboBox1.Items.Remove(comboBox1.Text);
                    comboBox1.Text = null;
                    comboBox2.Text = null;
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                
               
            }

           






        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SMSsender from = new SMSsender();
            from.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select FULLNAME from dbsystem.tblCstmr", conn);
            MySqlDataReader dr = comm.ExecuteReader();*/

             comboBox1.Items.Remove(storeData);
            comboBox1.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans where TransID='" + comboBox1.Text + "'and Service='"+comboBox3.Text+"'", conn);
            comm.ExecuteNonQuery();

            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox4.Text = dr["ClientID"].ToString();
                textBox5.Text = dr["FULLNAME"].ToString();
                textBox2.Text = dr["Service"].ToString();
                textBox1.Text = dr["AssignedEmp"].ToString();
                textBox3.Text = dr["AssignedDriver"].ToString();
                textBox6.Text = dr["StartTime"].ToString();
                textBox7.Text = dr["EndTime"].ToString();
                textBox8.Text = dr["DateOfService"].ToString();
                label10.Text = dr["DateMade"].ToString();
                dr.Close();
            }
        }
    }
}
