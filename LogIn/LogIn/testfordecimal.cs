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
    public partial class testfordecimal : Form
    {
        public testfordecimal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            double price;
            if (double.TryParse(textBox1.Text, out price))
            {
                label1.Text = string.Format("{0:.00}", price);
               // label1.Text = price.ToString(); 
              //  MessageBox.Show(price)


                MySqlCommand comm = new MySqlCommand("Insert into dbsystem.tbltest values ('" + label1.Text + "')", conn);
                comm.ExecuteNonQuery();*/

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltest where DateOfService between'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            System.Data.DataTable dt = new System.Data.DataTable();
            adapt.Fill(dt);

            this.dataGridView1.DataSource = dt;
            conn.Close();
            conn.Dispose();

            
        }

        private void testfordecimal_Load(object sender, EventArgs e)
        {
            var dedate = DateTime.Now.ToString("hh");
            textBox2.Text = dedate;
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           // var vavar = dateTimePicker1.Value.Date;
           // String vavavar = vavar.ToString("dd/MM/yyyy");
            //  DateTime nana = vavavar.ToString();
          //  string aw = vavavar;
         //   DateTime.Now.ToString("h:mm:ss tt");
            var a = DateTime.Now.ToString("h");
            textBox2.Text = a;
        }
    }
}
