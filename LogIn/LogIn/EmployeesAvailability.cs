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
using LogIn.Properties;

namespace LogIn
{
    public partial class EmployeesAvailability : Form
    {
        public EmployeesAvailability()
        {
            InitializeComponent();
        }

        private void EmployeesAvailability_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Refresh();

          MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
          conn.Open();
          MySqlCommand comm = new MySqlCommand("Select FULLNAME from dbsystem.tblEmp",conn);
          MySqlDataReader dr = comm.ExecuteReader();

          while (dr.Read()) {
              comboBox1.Items.Add(dr["FULLNAME"]);
          }
          dr.Close();

          conn.Close();


        }
        string dedate = "";
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Refresh();
            MessageBox.Show(dateTimePicker1.Value.ToString("MM/dd/yyyy"));
            comboBox2.Items.Clear();
            comboBox2.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            String pos = "";
            //String[] sts = { "1 00 PM", "2 00 PM", "3 00 PM", "4 00 PM", "5 00 PM", "6 00 PM", "7 00 PM", "8 00 PM" };
            MySqlCommand comm2 = new MySqlCommand("Select Position from dbsystem.tblEmp where FULLNAME='" + comboBox1.Text + "'",conn);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            if (dr2.Read())
            {
                pos = dr2["Position"].ToString();
                MessageBox.Show(pos.ToString());
            }
            else
            {

                MessageBox.Show("Please Select an Employee", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dr2.Close();

            if (pos == "Beautician" || pos == "Therapist")
            {
              
                MySqlCommand comm = new MySqlCommand("Select StartTime from dbsystem.tbltrans where AssignedEmp='" + comboBox1.Text + "'and DateOfService='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", conn);
                comm.ExecuteNonQuery();

                MySqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    if (!comboBox2.Items.Contains(dr["StartTime"].ToString()))
                    {
                        comboBox2.Items.Add(dr["StartTime"].ToString());

                    }


                }

                comboBox2.Sorted = true;
                comboBox2.Refresh();
                dedate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            }
            else if(pos=="Driver")
            {
               
                MySqlCommand comm = new MySqlCommand("Select StartTime from dbsystem.tbltrans where AssignedDriver='" + comboBox1.Text + "'and DateOfService='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", conn);
                comm.ExecuteNonQuery();

                MySqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    if (!comboBox2.Items.Contains(dr["StartTime"].ToString()))
                    {
                        comboBox2.Items.Add(dr["StartTime"].ToString());

                    }


                }

                comboBox2.Sorted = true;
                comboBox2.Refresh();
                dedate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Refresh();
            listBox1.Items.Clear();
            listBox1.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            String[] sts = { "1 00 PM", "2 00 PM", "3 00 PM", "4 00 PM", "5 00 PM", "6 00 PM", "7 00 PM", "8 00 PM" };
            
            int bilangNgCB2=comboBox2.Items.Count;
            string[] arr = new string[bilangNgCB2];
          
            for (int i=0;i<bilangNgCB2;i++){
                arr[i] = comboBox2.Items[i].ToString();
                
            }

            string[] result = sts.Except(arr).ToArray();
            listBox1.Items.AddRange(result);
            /*
             int totalCountOfComboBoxItems =comboBox2.Items.Count;//example, size is 5

             for (int i = 0; i < sts.Length; i++)
             {
                 for (int x = 0; x < totalCountOfComboBoxItems; x++)
                 {
                    
                 }

             }*/
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Refresh();
            comboBox2.Items.Clear();
            comboBox2.Refresh();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
