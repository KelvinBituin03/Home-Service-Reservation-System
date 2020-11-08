using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogIn
{
    public partial class TransactionUpdate : Form
    {
        public TransactionUpdate()
        {
            InitializeComponent();
        }

        private void TransactionUpdate_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read()) {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            dr.Dispose();

            conn.Close();
            conn.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Refresh();
            comboBox4.Items.Clear();
            comboBox4.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans where TransID='" + comboBox1.Text + "'", conn);
            comm.ExecuteNonQuery();

            MySqlDataReader dr = comm.ExecuteReader();
          
            if (dr.Read()) {
                textBox4.Text = dr["ClientID"].ToString();
                
                textBox2.Text = dr["Service"].ToString();
                textBox1.Text = dr["AssignedEmp"].ToString();
                textBox3.Text = dr["AssignedDriver"].ToString();
                dr.Close();

            }
           
            MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox4.Text + "'", conn);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();

            if (dr2.Read())
            {
                textBox5.Text = dr2["FULLNAME"].ToString();
                dr2.Close();
            }
            conn.Close();

           

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox3.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Refresh();
            comboBox4.Items.Clear();
            comboBox4.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            if (comboBox3.Text == "Full Body Massage" || comboBox3.Text == "Foot Reflex" || comboBox3.Text == "Foot Spa" || comboBox3.Text == "Body Scrub" || comboBox3.Text == "Bentosa with Massage" || comboBox3.Text == "Hot Stone")
            {
                MySqlCommand comm = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Therapist'",conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {

                    comboBox2.Items.Add(dr[0]);
                }
                dr.Close();
                dr.Dispose();


            }
            else if (comboBox3.Text == "Hair Spa" || comboBox3.Text == "Hair Dye" || comboBox3.Text == "Hot Oil" || comboBox3.Text == "Blow Dry")
            {
                MySqlCommand comm3 = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Beautician'",conn);
                comm3.ExecuteNonQuery();
                MySqlDataReader dr3 = comm3.ExecuteReader();
                while (dr3.Read())
                {

                    comboBox2.Items.Add(dr3[0]);
                }
                dr3.Close();
                dr3.Dispose();

            }
            else if (comboBox3.Text == "Men's Full Back Waxing" || comboBox3.Text == "Half Legs Waxing" || comboBox3.Text == "Half Arm Waxing" || comboBox3.Text == "Men's Chest Waxing" || comboBox3.Text == "Underarm Waxing" || comboBox3.Text == "Eyebrow Waxing" || comboBox3.Text == "Full Legs Waxing" || comboBox3.Text == "Full Arm Waxing" || comboBox3.Text == "Brazillian Waxing" || comboBox3.Text == "Upper Lip Waxing" || comboBox3.Text == "Bikini Waxing" || comboBox3.Text == "Threading Waxing" || comboBox3.Text == "Manicure and Pedicure")
            {
                MySqlCommand comm4 = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Beautician'",conn);
                comm4.ExecuteNonQuery();
                MySqlDataReader dr4 = comm4.ExecuteReader();
                while (dr4.Read())
                {

                    comboBox2.Items.Add(dr4[0]);
                }
                dr4.Close();
                dr4.Dispose();

            }

            MySqlCommand comm5 = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Driver'", conn);
            comm5.ExecuteNonQuery();
            MySqlDataReader dr5 = comm5.ExecuteReader();
            while (dr5.Read())
            {

                comboBox4.Items.Add(dr5[0]);
            }
            dr5.Close();
            dr5.Dispose();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblemp where Position='Driver'", conn);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            while (dr2.Read()) {

                comboBox4.Items.Add(dr2[0]);
            }
            dr2.Close();
            dr2.Dispose();

            */
           /* if (comboBox3.Text == "Full Body Massage" || comboBox3.Text == "Foot Reflex" || comboBox3.Text == "Foot Spa" || comboBox3.Text == "Body Scrub" || comboBox3.Text == "Bentosa with Massage" || comboBox3.Text == "Hot Stone")
            {
                MySqlCommand comm = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Therapist'");
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {

                    comboBox2.Items.Add(dr[0]);
                }
                dr.Close();
                dr.Dispose();


            }
            else if (comboBox3.Text == "Hair Spa" || comboBox3.Text == "Hair Dye" || comboBox3.Text == "Hot Oil" || comboBox3.Text == "Blow Dry")
            {
                MySqlCommand comm3 = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Beautician'");
                comm3.ExecuteNonQuery();
                MySqlDataReader dr3 = comm3.ExecuteReader();
                while (dr3.Read())
                {

                    comboBox2.Items.Add(dr3[0]);
                }
                dr3.Close();
                dr3.Dispose();

            }
            else if (comboBox3.Text == "Men's Full Back Waxing" || comboBox3.Text == "Half Legs Waxing" || comboBox3.Text == "Half Arm Waxing" || comboBox3.Text == "Men's Chest Waxing" || comboBox3.Text == "Underarm Waxing" || comboBox3.Text == "Eyebrow Waxing" || comboBox3.Text == "Full Legs Waxing" || comboBox3.Text == "Full Arm Waxing" || comboBox3.Text == "Brazillian Waxing" || comboBox3.Text == "Upper Lip Waxing" || comboBox3.Text == "Bikini Waxing" || comboBox3.Text == "Threading Waxing" || comboBox3.Text == "Manicure and Pedicure")
            {
                MySqlCommand comm4 = new MySqlCommand("Select fname from dbsystem.tblemp where Position='Beautician'");
                comm4.ExecuteNonQuery();
                MySqlDataReader dr4 = comm4.ExecuteReader();
                while (dr4.Read())
                {

                    comboBox2.Items.Add(dr4[0]);
                }
                dr4.Close();
                dr4.Dispose();
            
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            if(comboBox1.Text==""){
                MessageBox.Show("No transaction to be processed!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else{

                if (comboBox3.Text == "" || comboBox2.Text == "" || comboBox4.Text == "")
                {
                    MessageBox.Show("Please Fill the blanks!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand comm = new MySqlCommand("update dbsystem.tbltrans set Service='" + comboBox3.Text + "' where TransID='" + comboBox1.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlCommand comm2 = new MySqlCommand("update dbsystem.tbltrans set AssignedEmp='" + comboBox2.Text + "' where TransID='" + comboBox1.Text + "'", conn);

                    comm2.ExecuteNonQuery();
                    MySqlCommand comm3 = new MySqlCommand("update dbsystem.tbltrans set AssignedDriver='" + comboBox4.Text + "' where TransID='" + comboBox1.Text + "'", conn);
                    comm3.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string clear = null;
                    comboBox3.Text = clear;
                    comboBox4.Text = clear;
                    comboBox2.Text = clear;
                }

            }

            comboBox3.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Refresh();
            comboBox4.Items.Clear();
            comboBox4.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
