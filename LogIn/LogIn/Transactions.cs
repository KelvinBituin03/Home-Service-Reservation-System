using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
using LogIn.Properties;


namespace LogIn
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            //string now = "ddMyyyy";
           // now = DateTime.Now.ToString("ddMyyyy");
            DateTime date = DateTime.Now;
            string formatted = date.ToString("MM/dd/yyyy");
            MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where DateMade='"+formatted.ToString()+"'", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[9], ListSortDirection.Ascending);
            int numberOfRows = dataGridView1.Rows.Count;
            numberOfRows -= 1;
            label1.Text = numberOfRows.ToString();

            if (numberOfRows == 0)
            {
                MessageBox.Show("No Transaction/s found", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string dedate = "";
        private void Transactions_Load(object sender, EventArgs e)
        {
            
            comboBox7.Items.Clear();
            comboBox7.Refresh();

            MySqlConnection conn100 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn100.Open();
            MySqlCommand comm100 = new MySqlCommand("Select FULLNAME from dbsystem.tblEmp", conn100);
            MySqlDataReader dr100 = comm100.ExecuteReader();

            while (dr100.Read())
            {
                comboBox7.Items.Add(dr100["FULLNAME"]);
            }
            dr100.Close();

            conn100.Close();


            MySqlConnection conn20 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn20.Open();
            MySqlCommand comm20 = new MySqlCommand("Select * from dbsystem.tbltrans", conn20);
            comm20.ExecuteNonQuery();
            MySqlDataReader dr20 = comm20.ExecuteReader();
            while (dr20.Read())
            {

                comboBox6.Items.Add(dr20["TransID"]);

            }
            dr20.Close();
            dr20.Dispose();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            //textBox1.Enabled = false;
          //  label10.Visible = false;
          //  comboBox3.Visible = false;
           // textBox1.Visible = false;
            label10.Visible = true;

            comboBox3.Text = null;
            comboBox3.Visible = true;
            textBox1.Text = "";
            textBox1.Visible = true;

            label2.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            button7.Visible = false;

            comboBox1.Text = null;
            comboBox4.Text = null;
            comboBox2.Text = null;
            comboBox1.Visible = false;
            comboBox4.Visible = false;
            comboBox2.Visible = false;

            dateTimePicker1.Visible = false;


            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select FULLNAME from dbsystem.tblEmp", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                if (!comboBox5.Items.Contains(dr[0]))
                {
                    comboBox5.Items.Add(dr[0]);

                }


            }
            comboBox5.Sorted = true;
            dr.Close();
            conn.Close();


            DateTime _date = DateTime.Now;
            // dateTimePicker1.MinDate = _date;
            var _dateString = _date.ToString("MM/dd/yyyy");

         //   dateTimePicker2.MinDate = _dateString;

            /*
            MySqlConnection conn50 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn50.Open();
            MySqlCommand comm50 = new MySqlCommand("Select FULLNAME from dbsystem.tblEmp", conn50);
            MySqlDataReader dr50 = comm50.ExecuteReader();
            while (dr50.Read())
            {
                if (!comboBox7.Items.Contains(dr50[0]))
                {
                    comboBox7.Items.Add(dr50[0]);

                }


            }
            comboBox7.Sorted = true;
            dr50.Close();
            conn50.Close();*/

 

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
          
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[9], ListSortDirection.Ascending);

            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int numberOfRows = dataGridView1.Rows.Count;
            numberOfRows -= 1;
            label1.Text = numberOfRows.ToString();

            if (numberOfRows == 0)
            {
                MessageBox.Show("No Transaction/s found", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == " " || comboBox3.Text == "")
            {
              //  MessageBox.Show("Please select a filter first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // textBox1.Enabled = false;
            }
            else if(comboBox3.Text=="Employee")
            {
                textBox1.Enabled = true;
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where AssignedEmp like '%" + textBox1.Text + "%'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();
            }
            else if (comboBox3.Text == "Customer")
            {
                textBox1.Enabled = true;
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where FULLNAME like '%" + textBox1.Text + "%'", conn);

                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();
            }
            else if (comboBox3.Text == "Driver")
            {
                textBox1.Enabled = true;
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where AssignedDriver like '%" + textBox1.Text + "%'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();
            }
            else if (comboBox3.Text == "Date")
            {
                textBox1.Enabled = true;
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where DateOfService like '%" + textBox1.Text + "%'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();

            }
            else if (comboBox3.Text == "Service")
            {
                textBox1.Enabled = true;
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where Service like '%" + textBox1.Text + "%'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();

            }
         
            
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans where AssignedEmp like '%" + textBox1.Text + "%'", conn);

                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Rows.Count == 0)
                {

                    MessageBox.Show("No records found!", "No records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
       */

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            service_status_update from = new service_status_update();
            from.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans where FULLNAME like '%" + textBox2.Text + "%'", conn);

            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;*/
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Refresh();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where Status='Success' || Status='Success,no payment'", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[9], ListSortDirection.Ascending);
            int numberOfRows = dataGridView1.Rows.Count;
            numberOfRows -= 1;
            label1.Text = numberOfRows.ToString();

            if (numberOfRows == 0)
            {
                MessageBox.Show("No Transaction/s found", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where Status IN ('Failed,no payment','Failed,no show')", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[9], ListSortDirection.Ascending);
            int numberOfRows = dataGridView1.Rows.Count;
            numberOfRows -= 1;
            label1.Text = numberOfRows.ToString();

            if (numberOfRows == 0)
            {
                MessageBox.Show("No Transaction/s found", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status,DateCancelled from dbsystem.tblTrans2 where Status='Cancelled'", conn);
                
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Sort(dataGridView1.Columns[9], ListSortDirection.Ascending);
                int numberOfRows = dataGridView1.Rows.Count;
                numberOfRows -= 1;
                label1.Text = numberOfRows.ToString();

                if (numberOfRows == 0)
                {
                    MessageBox.Show("No Transaction/s found", "Nothing found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            label10.Visible = true;
            
            comboBox3.Text = null;
            comboBox3.Visible = true;
            textBox1.Text = "";
            textBox1.Visible = true;

            label2.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            button7.Visible = false;

            comboBox1.Text = null;
            comboBox4.Text = null;
            comboBox2.Text = null;
            comboBox1.Visible = false;
            comboBox4.Visible = false;
            comboBox2.Visible = false;

            dateTimePicker1.Visible = false;

            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            label2.Visible = true;
            label3.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            button7.Visible = true;
            comboBox1.Visible = true;
            comboBox4.Visible = true;
            comboBox2.Visible = true;

            dateTimePicker1.Visible = true ;

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            label10.Visible = false ;

            comboBox3.Text = null;
            comboBox3.Visible = false ;
            textBox1.Text = "";
            textBox1.Visible = false; 


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var vavar = dateTimePicker1.Value.Date;
            String vavavar = vavar.ToString("MM/dd/yyyy");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            if (comboBox1.Text == "Employee")
            {

                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblemp where Position='Therapist' OR Position='Beautician'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();

                
                    while (dr.Read())
                    {
                        if (!comboBox4.Items.Contains(dr["FULLNAME"]))
                        {
                            comboBox4.Items.Add(dr["FULLNAME"]);

                        }


                    }
                    comboBox4.Sorted = true;

                
            }
          else if (comboBox1.Text == "Driver")
            {
              
                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblemp where Position='Driver'", conn2);
                comm2.ExecuteNonQuery();
                MySqlDataReader dr2 = comm2.ExecuteReader();

                while (dr2.Read())
                {
                    if (!comboBox4.Items.Contains(dr2["FULLNAME"]))
                    {
                        comboBox4.Items.Add(dr2["FULLNAME"]);

                    }
                }
                comboBox4.Sorted = true;


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var vavar = dateTimePicker1.Value.Date;
            String vavavar = vavar.ToString("MM/dd/yyyy");

            if (comboBox1.Text == "" || comboBox4.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox1.Text=="Employee")
            {

                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where AssignedEmp='" + comboBox4.Text + "'and DateOfService='"+vavavar+"'and Status='"+comboBox2.Text+"'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();
            }
            else if (comboBox1.Text == "Driver")
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where AssignedDriver='" + comboBox4.Text + "'and DateOfService='" + vavavar + "'and Status='" + comboBox2.Text + "'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                conn.Dispose();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SMSsender from = new SMSsender();
            from.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var vavar = dateTimePicker2.Value.Date;
            String vavavar = vavar.ToString("MM/dd/yyyy");

            MessageBox.Show(vavavar.ToString());
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,FULLNAME,AssignedEMP,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tbltrans where DateOfService='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'and Status='" + "" + "'", conn);
            comm.ExecuteNonQuery();
          
            
           
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;




        }

        private void deleteThisTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("DELETE from dbsystem.tbltrans where TransID='" + textBox2.Text + "'", conn);
            comm.ExecuteNonQuery();

            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["TransID"].Value.ToString();
           // this.dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 

           

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tblTrans where TransID='" + comboBox6.Text + "'", conn);

            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

            int A = 0, B = 0;

            for (A = 0; A < dataGridView1.Rows.Count; ++A)
            {

                B += Convert.ToInt32(dataGridView1.Rows[A].Cells[2].Value);

            }

            string eh = ".00";

            string bb = Convert.ToString(B);
            string bbb = bb + eh;
            label100.Text = bbb.ToString();
            
            conn.Close();
            conn.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            int[] sts ={ 100, 200, 300, 400, 500, 600, 700, 800};
            MySqlCommand comm = new MySqlCommand("");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EmployeesAvailability from = new EmployeesAvailability();
            from.Show();
        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Refresh();
            dateTimePicker4.Refresh();
            comboBox2.Items.Clear();
            comboBox2.Refresh();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Refresh();
            dateTimePicker4.Refresh();
           // MessageBox.Show(dateTimePicker4.Value.ToString("MM/dd/yyyy"));
            comboBox8.Items.Clear();
            comboBox8.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            String pos = "";
            //String[] sts = { "1 00 PM", "2 00 PM", "3 00 PM", "4 00 PM", "5 00 PM", "6 00 PM", "7 00 PM", "8 00 PM" };
            MySqlCommand comm2 = new MySqlCommand("Select Position from dbsystem.tblEmp where FULLNAME='" + comboBox7.Text + "'", conn);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            if (dr2.Read())
            {
                pos = dr2["Position"].ToString();
             //   MessageBox.Show(pos.ToString());
            }
            else
            {

                MessageBox.Show("Please Select an Employee", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dr2.Close();

            if (pos == "Beautician" || pos == "Therapist")
            {

                MySqlCommand comm = new MySqlCommand("Select StartTime from dbsystem.tbltrans where AssignedEmp='" + comboBox7.Text + "'and DateOfService='" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "'", conn);
                comm.ExecuteNonQuery();

                MySqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    if (!comboBox8.Items.Contains(dr["StartTime"].ToString()))
                    {
                        comboBox8.Items.Add(dr["StartTime"].ToString());

                    }


                }

                comboBox8.Sorted = true;
                comboBox8.Refresh();
                dedate = dateTimePicker4.Value.ToString("MM/dd/yyyy");
            }
            else if (pos == "Driver")
            {

                MySqlCommand comm = new MySqlCommand("Select StartTime from dbsystem.tbltrans where AssignedDriver='" + comboBox7.Text + "'and DateOfService='" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "'", conn);
                comm.ExecuteNonQuery();

                MySqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    if (!comboBox8.Items.Contains(dr["StartTime"].ToString()))
                    {
                        comboBox8.Items.Add(dr["StartTime"].ToString());

                    }


                }

                comboBox8.Sorted = true;
                comboBox8.Refresh();
                dedate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please select an employee", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dateTimePicker4.Refresh();
                listBox2.Items.Clear();
                listBox2.Refresh();
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                String[] sts = { "1 00 PM", "2 00 PM", "3 00 PM", "4 00 PM", "5 00 PM", "6 00 PM", "7 00 PM", "8 00 PM" };

                int bilangNgCB2 = comboBox8.Items.Count;
                string[] arr = new string[bilangNgCB2];

                for (int i = 0; i < bilangNgCB2; i++)
                {
                    arr[i] = comboBox8.Items[i].ToString();

                }

                string[] result = sts.Except(arr).ToArray();
                listBox2.Items.AddRange(result);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
            DGVPrinter printer = new DGVPrinter();
            printDocument1.DefaultPageSettings.Landscape = true;

            printer.Title = "FOREVER TOUCH BODY AND BEAUTY SPA \n (90) Mindanao Ayala Alabang Village Muntinlupa City \n Customer Report  \n \n";

            string qa = label100.Text;
            string qq = qa.Remove(qa.Length - 3);
            int ws = Convert.ToInt32(qq);
            int ed = ws / 100;
            int rf = ed * 12;
            string ss = Convert.ToString(rf);
            int result = ws - rf;
            string ww = Convert.ToString(result);
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
           // printer.PageNumbers = true;
          //  printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.FooterAlignment = StringAlignment.Near;
            printer.Footer = "Total Ammount : "+ww+" PHP"+"\n\n"+"Sales Tax : "+ss+" PHP"+"\n\n"+"Total to pay : "+label100.Text+"";//footer
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
         

          //  System.Drawing.Printing.PrintPageEventArgs es;
          //  es.Graphics.DrawString("Total Amount : P " + label100.Text + " PHP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, 720));
           
          //  es.Graphics.DrawString("Sales Tax :     P " + ss + " PHP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, 750));
           // es.Graphics.DrawString("Total To pay:    P " + ww + " PHP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, 780));
           // es.Graphics.DrawString("_______________________________ : ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(25, 730));
           // es.Graphics.DrawString("Client's Signature Over Printed Name : ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(25, 760));
            
            }
        Bitmap bitmap;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 250);
            this.printDocument1.DefaultPageSettings.Landscape = true;
            Image image = Resources.yeye;
            e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
            e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
        }

        //END OF METHODS
        }
    }

