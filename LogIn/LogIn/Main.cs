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
using LogIn.Models;

namespace LogIn
{
    public partial class Main : Form
    {
        double x = 0;
        int i = 1;
        int numberNgLastTransID;
        public Main()
        {
            InitializeComponent();

           
        }
        
        private List<CartItem> shoppingCart = new List<CartItem>();
        public string MyProperty { get; set; }
        public int MyProperty2 { get; set; }


        private void Main_Load(object sender, EventArgs e)
        {
           

           // MessageBox.Show(this.MyProperty);
            if (MyProperty == "admin")
            {
                label52.Visible = true;
                button10.Visible = true;

               // label50.Visible = true;
              //  btnReports.Visible = true;

                button7.Visible = true;
                button16.Visible = true;

                
                Application.DoEvents();
               
            }
            else { 
                label52.Visible = false;
                button10.Visible = false;

              //  label50.Visible = false;
              //  btnReports.Visible = false;

                button7.Visible = false;
                button16.Visible = false;

              
                Application.DoEvents();
            
            }
            label41.Visible = false;
            button45.Visible = false;
            dataGridView1.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            button40.Visible = false;
            button44.Visible = false;
            label15.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label20.Visible = false;
            label17.Visible= false;
            label21.Visible= false;
            label16.Visible= false;
            label22.Visible= false;
            button6.Hide();
            panel3.Hide();
            panel2.Hide();
            panel1.Hide();
          //  timer2.Start();
           // timer2.Enabled = true;
            btnReports.Visible = true;
            //panel5.Show();
           /* this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;*/
            // TODO: This line of code loads data into the 'usersDBDataSet2.TableClient' table. You can move, or remove it, as needed.
           // this.tableClientTableAdapter.Fill(this.usersDBDataSet2.TableClient);




       //     this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            button9.Visible = false;
            button12.Visible = false;
         //   panel1.Hide();
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button15.Visible = false;
            button16.Visible = false;

            //
            button8.Visible = true;

            button14.Visible = true;
            button13.Visible = true;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transactions from = new Transactions();
            from.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            button9.Visible = false;
            button12.Visible = true;
            button13.Visible = false;
            button14.Visible = false;
            button8.Visible = false;
            button7.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;*/
            button5.Visible = true;
                
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            /*
            button9.Visible = true;
             */
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddEmployee from = new AddEmployee();
            from.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AddCustomer from = new AddCustomer();
            from.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Update_Employees from = new Update_Employees();
            from.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {/*
            button9.Visible = false;
            button12.Visible = false;
          //  panel1.Hide();
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button8.Visible = false;
            
            button7.Visible = true;
            button15.Visible = true;
            button16.Visible = true;*/
        }

        private void button15_Click(object sender, EventArgs e)
        {
         
            
            Employees_Information from = new Employees_Information();
            

            Form fc = Application.OpenForms["Employees_Information"];

            if (fc != null)
            {
                fc.Close();
                from.Close();
            }
            else
            {
                from.Show();
            }
            
       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            label40.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Refresh();
            comboBox1.Visible = true;
            button6.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;*/
            if (comboBox1.Text != "")
            {
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                comboBox1.Refresh();
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                button6.Hide();



            }
            else
            {
                textBox1.Text = " ";
                panel1.Show();
                panel2.Show();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
           
            string a = "Full Body Massage";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value= a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString() ;
            comboBox3.Items.Add(a);
           /* if (comboBox3.Items.Contains(a))
            {
                
                comboBox3.Items.Add(a + i.ToString());
                i++;
              

            }
            else
            {
                comboBox3.Items.Add(a);
                
                
            }*/
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string a = "Foot Reflex";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string a = "Manicure and Pedicure";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string a = "Foot Spa";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string a = "Body Scrub";
            int b = 350;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string a = "Bentosa with Massage";
            int b = 500;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string a = "Hot Stone";
            int b = 500;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string a = "Hair Services and Waxing";
            //int b=
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
           // dataGridView1.Rows[n].Cells[1].Value = button18;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            string a = "Threading Waxing";
            int b = 200;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {





         //   int a = Convert.ToInt32(aa);
           // textBox24.Text = a.ToString(); 
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            string a = "Hair Dye";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            
            string a = "Hair Spa";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string a = "Hot Oil";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string a = "Blow Dry";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string a = "Half Legs Waxing";
            int b = 350;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string a = "Full Arm Waxing";
            int b = 350;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            string a = "Full Legs Waxing";
            int b = 500;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            string a = "Bikini Waxing  ";
            int b = 400;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string a = "Mens Chest Waxing";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string a = "Half Arm Waxing";
            int b = 300;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string a = "Eyebrow Waxing";
            int b = 200;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string a = "Underarm Waxing";
            int b = 250;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string a = "Brazillian Waxing";
            int b = 500;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string a = "Mens Full Back Waxing";
            int b = 300;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string a = "Upper Lip Waxing";
            int b = 150;
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = a;
            dataGridView1.Rows[n].Cells[1].Value = b;
            x += b;
            textBox1.Text = x.ToString();
            comboBox3.Items.Add(a);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            int a=0;
            textBox1.Text = a.ToString();
            x = 0;
            comboBox3.Items.Clear();
            comboBox3.Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            comboBox1.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select FULLNAME from dbsystem.tblCstmr", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                if (!comboBox11.Items.Contains(dr[0]))
                {
                    comboBox11.Items.Add(dr[0]);
                  
                }
            
                
            }
            comboBox11.Sorted = true;
           
           
           // timer1.Start();
          //  timer1.Enabled = true;
            conn.Close();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            textBox6.Enabled = false;
            textBox7.Enabled = false;

        }

        private void button41_Click(object sender, EventArgs e)
        {
           // panel1.Show();
            label41.Visible = true;
            button45.Visible = true ;
            dataGridView1.Visible = true;
            label1.Visible = true;
            textBox1.Visible = true;
            button40.Visible = true;
            button44.Visible = true;
            label15.Visible = true;
            label19.Visible = true;
            label18.Visible = true;
            label20.Visible = true;
            label17.Visible = true ;
            label21.Visible = true;
            label16.Visible = true;
            label22.Visible = true;
            button6.Show();
            panel3.Enabled = true;

            label40.Visible = true ;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        
            comboBox1.Visible = true;
            button6.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceName,ServiceType,Price,Duration from dbsystem.tblServices", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read()) {
                if (!comboBox1.Items.Contains(dr[0]))
                {

                    comboBox1.Items.Add(dr[0]);
                }
            }

            //test date
            //DateTime _date = DateTime.Now;
            //var _dateString = _date.ToString("dd/MM/yyyy");

          //  MessageBox.Show(_dateString);
         /*   SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Codes\C# Codes\LogIn\LogIn\UsersDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            conn.Open();
            SqlCommand comm = new SqlCommand("Select * from TableClient where ClientID='" + comboBox1.Text + "'", conn);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read()) {

                textBox2.Text = dr["fname"].ToString();
                textBox3.Text = dr["mname"].ToString();
                textBox4.Text = dr["lname"].ToString();
                textBox5.Text = dr["age"].ToString();
                textBox66.Text = dr["address"].ToString();
                textBox2.Text = dr["ContactNo"].ToString();
                textBox2.Text = dr["fname"].ToString();

            }*/
            if (comboBox11.Text == "" || comboBox11.Text.Length<8)
            {
                MessageBox.Show("Please select a Customer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panel1.Hide();
               

            }
            else
            {
                panel1.Show();
                button5.Hide();
               

                label19.Text = textBox17.Text;
                label20.Text = textBox2.Text;
                label21.Text = textBox3.Text;
                label22.Text = textBox4.Text;
                panel2.Hide();
                panel1.Show();
             
                textBox17.Clear();
                textBox17.Refresh();
                comboBox11.Items.Clear();
                comboBox11.Refresh();


                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr where ClientID='" + comboBox1.Text + "'", conn);
            MySqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {

                textBox2.Text = dr["fname"].ToString();
                textBox3.Text = dr["mname"].ToString();
                textBox4.Text = dr["lname"].ToString();
                textBox5.Text = dr["age"].ToString();
                textBox6.Text = dr["address"].ToString();
                textBox7.Text = dr["ContactNo"].ToString();
           

            }*/
        }

        private void button43_Click(object sender, EventArgs e)
        {
           /* MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
          MySqlCommand comm = new MySqlCommand("Select ClientID from dbsystem.tblCstmr", conn);
          MySqlDataReader dr = comm.ExecuteReader();

          while (dr.Read())
          {
              comboBox1.Items.Add(dr[0]);
          }
          dr.Close();
          dr.Dispose();*/
        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            if (label14.ForeColor == Color.DarkGray)
            {
                label14.ForeColor = Color.White;
                timer1.Interval = 550;
            }
            else
            {
                label14.ForeColor = Color.DarkGray;
                timer1.Interval = 550;
            }
        }*/

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {
           
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm2 = new MySqlCommand("SELECT MAX(TransID) FROM dbsystem.tbltrans", conn);
            int ID = (int)comm2.ExecuteScalar();
            comm2.ExecuteNonQuery();

         // MessageBox.Show(ID.ToString());

           //  Main from2 = new Main();
             //from2.MyProperty2 = ID;

          numberNgLastTransID = ID;

            string aa = textBox1.Text;
            int wa = Convert.ToInt32(aa);
            int waa = wa / 100;
            int result;
            result = waa * 12;
           // MessageBox.Show(result.ToString());
            string VatRes = result.ToString();
            textBox24.Text = VatRes;
            int firstTotal = wa - result;
            string firstTotalStr = Convert.ToString(firstTotal);
            textBox25.Text = firstTotalStr;
            if (dataGridView1.Rows.Count==0){
                MessageBox.Show("Please select some services", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                label40.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label42.Visible = false;
                label5.Visible = false;
                comboBox1.Items.Clear();
                comboBox1.Refresh();
                comboBox1.Visible = false;
                button6.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;

                panel3.Show();

            }
        }

       
      
        private void button45_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
           
            int a = 0;
            textBox1.Text = a.ToString();
            x = 0;
            panel1.Hide();
            panel2.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button48_Click(object sender, EventArgs e)
        {
            string zero = "0";
            //MessageBox.Show(numberNgLastTransID.ToString());
            DateTime nanaw = DateTime.Now;
            String vaar2 = nanaw.ToString("MM/dd/yyyy");

            x = 0;
            if ((comboBox6.Text == "1" && comboBox4.Text == "AM") || (comboBox6.Text == "2" && comboBox4.Text == "AM") || (comboBox6.Text == "3" && comboBox4.Text == "AM") || (comboBox6.Text == "4" && comboBox4.Text == "AM") || (comboBox6.Text == "5" && comboBox4.Text == "AM") || (comboBox6.Text == "6" && comboBox4.Text == "AM") || (comboBox6.Text == "7" && comboBox4.Text == "AM") || (comboBox6.Text == "8" && comboBox4.Text == "AM") || (comboBox6.Text == "" && comboBox4.Text == "AM") || (comboBox10.Text == "" || comboBox2.Text == "") || (comboBox6.Text == "" || comboBox7.Text == "" || comboBox4.Text == ""))
            {
                MessageBox.Show("Business is open from 1pm - 8pm only and check the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
                
        

            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                if (comboBox3.Text == "")
                {
                    MessageBox.Show("No service to be processed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (textBox16.Text == vaar2)
                {
                    // MessageBox.Show(vaar2);
                    var dedate = DateTime.Now.ToString("hh");
                    var dedate2 = DateTime.Now.ToString("mm");
                    // MessageBox.Show(dedate);
                    // MessageBox.Show(dedate2);
                    int starttime;
                    string aw = comboBox6.Text;
                    string aw2 = comboBox7.Text;
                    int awaw = Convert.ToInt32(aw);//for hour
                    int awaw2 = Convert.ToInt32(aw2);//for minutes
                  
                    starttime = Convert.ToInt32(+awaw + "" + awaw2+""+zero);

                    // MessageBox.Show(starttime.ToString());
                    String xx2 = dedate;
                    String yy2 = dedate2;
                    int xxx2 = Convert.ToInt32(xx2);
                    int yyy2 = Convert.ToInt32(yy2);

                    if (awaw <= xxx2)
                    {
                        if (awaw2 <= yyy2)
                        {

                            MessageBox.Show("Your Starting time has passed already, choose a different time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {//else brace
                            //else brace
                            //newvar dedate = DateTime.Now.ToString("hh");
                            //newtextBox2.Text = dedate;

                            if (comboBox6.Text == "" || comboBox7.Text == "" || comboBox4.Text == "")
                            {

                                MessageBox.Show("Please fill the time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                //MessageBox.Show(comboBox12.Items.Count.ToString());
                                int[] arr = new int[comboBox12.Items.Count];// for ex, 5 size.
                                int eh = 0;
                                bool found2 = false;
                                bool found = false;
                                for (int i = 0; i < arr.Length; i++)
                                {



                                    arr[i] = eh;
                                    eh = eh + 1;

                                    int[] arr2 = new int[100];
                                    string n = comboBox12.Items[arr[i]].ToString();
                                    int m = Convert.ToInt32(n);

                                    for (int a = 0; a < arr2.Length; a++)
                                    {
                                        arr2[a] = m;
                                        m = m + 1;


                                    }
                                    //  MessageBox.Show(found.ToString());

                                    string aa = comboBox6.Text.ToString();//hour sa starttime
                                    int xxx = Convert.ToInt32(aa);
                                    string bb = comboBox7.Text.ToString();//mins sa starttime
                                    int yyy = Convert.ToInt32(bb);
                                    int firstsum;

                                    firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);
                                    textBox15.Text = firstsum.ToString();
                                    label45.Text = firstsum.ToString();
                                    string cc = comboBox8.Text.ToString();//hour sa endtime
                                    int www = Convert.ToInt32(cc);
                                    string dd = comboBox9.Text.ToString();//mins sa endtime      
                                    int qqq = Convert.ToInt32(dd);
                                    int secondsum;
                                    secondsum = Convert.ToInt32(+www + "" + qqq+""+zero);

                                    for (int w = 0; w < arr2.Length; w++)
                                    {
                                        if (firstsum == arr2[w] || secondsum == arr2[w])
                                        {
                                            found = true;

                                        }

                                    }
                                }

                                if (found == true)
                                {
                                    MessageBox.Show("Time Conflict for this employee, please select another employee or time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);




                                }

                                else if (found == false)
                                {
                                    int[] arr3 = new int[comboBox13.Items.Count];// for ex, 5 size.
                                    int eh3 = 0;

                                    for (int i = 0; i < arr3.Length; i++)
                                    {

                                        arr3[i] = eh3;
                                        eh3 = eh3 + 1;

                                        int[] arr2 = new int[100];
                                        string n = comboBox13.Items[arr3[i]].ToString();
                                        int m = Convert.ToInt32(n);

                                        for (int a = 0; a < arr2.Length; a++)
                                        {
                                            arr2[a] = m;
                                            m = m + 1;

                                        }

                                        string aa = comboBox6.Text.ToString();//hour sa starttime
                                        int xxx = Convert.ToInt32(aa);
                                        string bb = comboBox7.Text.ToString();//mins sa starttime
                                        int yyy = Convert.ToInt32(bb);
                                        int firstsum;
                                        firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

                                        string cc = comboBox8.Text.ToString();//hour sa endtime
                                        int www = Convert.ToInt32(cc);
                                        string dd = comboBox9.Text.ToString();//mins sa endtime      
                                        int qqq = Convert.ToInt32(dd);
                                        int secondsum;
                                        secondsum = Convert.ToInt32(+www + "" + qqq+""+zero);
                                        for (int w = 0; w < arr2.Length; w++)
                                        {
                                            if (firstsum == arr2[w] || secondsum == arr2[w])
                                            {
                                                found2 = true;

                                            }

                                        }
                                    }



                                }

                                if (found2 == true)
                                {
                                    found2 = true;
                                    MessageBox.Show("Time Conflict for this Driver, please select another Driver or time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                }
                                else if (found == false && found2 == false)
                                {

                                    MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox18.Text + "'", conn);
                                    comm2.ExecuteNonQuery();
                                    MySqlDataReader dr = comm2.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        textBox14.Text = dr["FULLNAME"].ToString();

                                    }


                                    string cc2 = "";
                                    string c = " ";
                                    string a2 = comboBox6.Text + c + comboBox7.Text + c + comboBox4.Text;
                                    string b = comboBox8.Text + c + comboBox9.Text + c + comboBox5.Text;
                                    string ccc = comboBox6.Text + cc2 + comboBox7.Text;
                                    string cccc = comboBox8.Text + cc2 + comboBox9.Text;

                                    string thedate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                                    DateTime _date = DateTime.Now;
                                    var _dateString = _date.ToString("MM/dd/yyyy");

                                    dr.Close();
                                  //  int tagatrans = 6;
                                    int tagaProcessNgIDnumber = numberNgLastTransID + 1;
                                    MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                                    comm10.ExecuteNonQuery();

                                    decimal presyo = (decimal)comm10.ExecuteScalar();
                                   // MessageBox.Show(presyo.ToString());

                                    MySqlCommand comm = new MySqlCommand("Insert into dbsystem.tbltrans (Price,TransID,Service,StartTime,EndTime,StartTimeSession,EndTimeSession,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,st,et,DateOfService) values ('"+presyo+"','"+tagaProcessNgIDnumber+"','" + comboBox3.Text + "','" + a2 + "','" + b + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox18.Text + "','" + textBox14.Text + "','" + comboBox2.Text + "','" + comboBox10.Text + "','" + _dateString + "','" + ccc + "','" + cccc + "','" + thedate + "')", conn);
                                    comm.ExecuteNonQuery();
                                   

                                    MessageBox.Show("Transaction Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                   
                                   /*
                                    int n = dataGridView2.Rows.Add();
                                    dataGridView2.Rows[n].Cells[0].Value = comboBox3.Text;
                                    dataGridView2.Rows[n].Cells[1].Value = a2;
                                    dataGridView2.Rows[n].Cells[2].Value = b;
                                    dataGridView2.Rows[n].Cells[3].Value = textBox23.Text;
                                    dataGridView2.Rows[n].Cells[4].Value = comboBox2.Text;
                                    dataGridView2.Rows[n].Cells[5].Value = comboBox10.Text;
                                    dataGridView2.Rows[n].Cells[6].Value = textBox16.Text;
                                    dataGridView2.Rows[n].Cells[7].Value = textBox9.Text;*/
                                    CartItem item = new CartItem()
                                    {
                                        Services = comboBox3.Text,
                                        StartTime = a2,
                                        EndTime = b,
                                        FULLNAME = textBox23.Text,
                                     //   AssignedEmp = comboBox2.Text,
                                     //   AssignedDriver = comboBox10.Text,
                                        DateOfService = textBox16.Text,
                                        Address = textBox9.Text



                                    };
                                    shoppingCart.Add(item);
                                    dataGridView2.DataSource = null;
                                    dataGridView2.DataSource = shoppingCart;
                                    
                                    comboBox3.Items.Remove(comboBox3.Text);
                                    comboBox2.Text = null;
                                    comboBox10.Text = null;
                                    comboBox12.Text = null;
                                    comboBox13.Text = null;

                                    
                                }




                            }
                        }

                    }
                    else
                    {
                        //else brace
                        //else brace
                        //newvar dedate = DateTime.Now.ToString("hh");
                        //newtextBox2.Text = dedate;

                        if (comboBox6.Text == "" || comboBox7.Text == "" || comboBox4.Text == "")
                        {

                            MessageBox.Show("Please fill the time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            //MessageBox.Show(comboBox12.Items.Count.ToString());
                            int[] arr = new int[comboBox12.Items.Count];// for ex, 5 size.
                            int eh = 0;
                            bool found2 = false;
                            bool found = false;
                            for (int i = 0; i < arr.Length; i++)
                            {



                                arr[i] = eh;
                                eh = eh + 1;

                                int[] arr2 = new int[100];
                                string n = comboBox12.Items[arr[i]].ToString();
                                int m = Convert.ToInt32(n);

                                for (int a = 0; a < arr2.Length; a++)
                                {
                                    arr2[a] = m;
                                    m = m + 1;


                                }
                                //  MessageBox.Show(found.ToString());

                                string aa = comboBox6.Text.ToString();//hour sa starttime
                                int xxx = Convert.ToInt32(aa);
                                string bb = comboBox7.Text.ToString();//mins sa starttime
                                int yyy = Convert.ToInt32(bb);
                                int firstsum;
                                firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);
                                textBox15.Text = firstsum.ToString();
                                label45.Text = firstsum.ToString();
                                string cc = comboBox8.Text.ToString();//hour sa endtime
                                int www = Convert.ToInt32(cc);
                                string dd = comboBox9.Text.ToString();//mins sa endtime      
                                int qqq = Convert.ToInt32(dd);
                                int secondsum;
                                secondsum = Convert.ToInt32(+www + "" + qqq+""+zero);

                                for (int w = 0; w < arr2.Length; w++)
                                {
                                    if (firstsum == arr2[w] || secondsum == arr2[w])
                                    {
                                        found = true;

                                    }

                                }
                            }

                            if (found == true)
                            {
                                MessageBox.Show("Time Conflict for this employee, please select another employee or time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);




                            }

                            else if (found == false)
                            {
                                int[] arr3 = new int[comboBox13.Items.Count];// for ex, 5 size.
                                int eh3 = 0;

                                for (int i = 0; i < arr3.Length; i++)
                                {

                                    arr3[i] = eh3;
                                    eh3 = eh3 + 1;

                                    int[] arr2 = new int[100];
                                    string n = comboBox13.Items[arr3[i]].ToString();
                                    int m = Convert.ToInt32(n);

                                    for (int a = 0; a < arr2.Length; a++)
                                    {
                                        arr2[a] = m;
                                        m = m + 1;

                                    }

                                    string aa = comboBox6.Text.ToString();//hour sa starttime
                                    int xxx = Convert.ToInt32(aa);
                                    string bb = comboBox7.Text.ToString();//mins sa starttime
                                    int yyy = Convert.ToInt32(bb);
                                    int firstsum;
                                    firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

                                    string cc = comboBox8.Text.ToString();//hour sa endtime
                                    int www = Convert.ToInt32(cc);
                                    string dd = comboBox9.Text.ToString();//mins sa endtime      
                                    int qqq = Convert.ToInt32(dd);
                                    int secondsum;
                                    secondsum = Convert.ToInt32(+www + "" + qqq+""+zero);
                                    for (int w = 0; w < arr2.Length; w++)
                                    {
                                        if (firstsum == arr2[w] || secondsum == arr2[w])
                                        {
                                            found2 = true;

                                        }

                                    }
                                }



                            }

                            if (found2 == true)
                            {
                                found2 = true;
                                MessageBox.Show("Time Conflict for this Driver, please select another Driver or time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                            else if (found == false && found2 == false)
                            {

                                MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox18.Text + "'", conn);
                                comm2.ExecuteNonQuery();
                                MySqlDataReader dr = comm2.ExecuteReader();
                                if (dr.Read())
                                {
                                    textBox14.Text = dr["FULLNAME"].ToString();

                                }


                                string cc2 = "";
                                string c = " ";
                                string a2 = comboBox6.Text + c + comboBox7.Text + c + comboBox4.Text;
                                string b = comboBox8.Text + c + comboBox9.Text + c + comboBox5.Text;
                                string ccc = comboBox6.Text + cc2 + comboBox7.Text;
                                string cccc = comboBox8.Text + cc2 + comboBox9.Text;

                                string thedate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                                DateTime _date = DateTime.Now;
                                var _dateString = _date.ToString("MM/dd/yyyy");

                                dr.Close();
                              //  int tagatrans = 6;

                                MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                                comm10.ExecuteNonQuery();

                                decimal presyo = (decimal)comm10.ExecuteScalar();
                              //  MessageBox.Show(presyo.ToString());


                                int tagaProcessNgIDnumber = numberNgLastTransID + 1;
                                MySqlCommand comm = new MySqlCommand("Insert into dbsystem.tbltrans (Price,TransID,Service,StartTime,EndTime,StartTimeSession,EndTimeSession,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,st,et,DateOfService) values ('"+presyo+"','"+tagaProcessNgIDnumber+"','" + comboBox3.Text + "','" + a2 + "','" + b + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox18.Text + "','" + textBox14.Text + "','" + comboBox2.Text + "','" + comboBox10.Text + "','" + _dateString + "','" + ccc + "','" + cccc + "','" + thedate + "')", conn);
                                comm.ExecuteNonQuery();
                               

                                MessageBox.Show("Transaction Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                              
                             /*   int n = dataGridView2.Rows.Add();
                                dataGridView2.Rows[n].Cells[0].Value = comboBox3.Text;
                                dataGridView2.Rows[n].Cells[1].Value = a2;
                                dataGridView2.Rows[n].Cells[2].Value = b;
                                dataGridView2.Rows[n].Cells[3].Value = textBox23.Text;
                                dataGridView2.Rows[n].Cells[4].Value = comboBox2.Text;
                                dataGridView2.Rows[n].Cells[5].Value = comboBox10.Text;
                                dataGridView2.Rows[n].Cells[6].Value = textBox16.Text;
                                dataGridView2.Rows[n].Cells[7].Value = textBox9.Text;*/
                                CartItem item = new CartItem()
                                {
                                    Services = comboBox3.Text,
                                    StartTime = a2,
                                    EndTime = b,
                                    FULLNAME = textBox23.Text,
                                    AssignedEmp = comboBox2.Text,
                                    AssignedDriver = comboBox10.Text,
                                    DateOfService = textBox16.Text,
                                    Address = textBox9.Text



                                };
                                shoppingCart.Add(item);
                                dataGridView2.DataSource = null;
                                dataGridView2.DataSource = shoppingCart;
                                comboBox3.Items.Remove(comboBox3.Text);
                                comboBox2.Text = null;
                                comboBox10.Text = null;
                                comboBox12.Text = null;
                                comboBox13.Text = null;
                            }




                        }
                    }



                }
                else
                {//else brace
                    //newvar dedate = DateTime.Now.ToString("hh");
                    //newtextBox2.Text = dedate;

                    if (comboBox6.Text == "" || comboBox7.Text == "" || comboBox4.Text == "")
                    {

                        MessageBox.Show("Please fill the time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        //MessageBox.Show(comboBox12.Items.Count.ToString());
                        int[] arr = new int[comboBox12.Items.Count];// for ex, 5 size.
                        int eh = 0;
                        bool found2 = false;
                        bool found = false;
                        for (int i = 0; i < arr.Length; i++)
                        {



                            arr[i] = eh;
                            eh = eh + 1;

                            int[] arr2 = new int[100];
                            string n = comboBox12.Items[arr[i]].ToString();
                            int m = Convert.ToInt32(n);

                            for (int a = 0; a < arr2.Length; a++)
                            {
                                arr2[a] = m;
                                m = m + 1;


                            }
                            //   MessageBox.Show(found.ToString());

                            string aa = comboBox6.Text.ToString();//hour sa starttime
                            int xxx = Convert.ToInt32(aa);
                            string bb = comboBox7.Text.ToString();//mins sa starttime
                            int yyy = Convert.ToInt32(bb);
                            int firstsum;
                            firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);
                            textBox15.Text = firstsum.ToString();
                            label45.Text = firstsum.ToString();
                            string cc = comboBox8.Text.ToString();//hour sa endtime
                            int www = Convert.ToInt32(cc);
                            string dd = comboBox9.Text.ToString();//mins sa endtime      
                            int qqq = Convert.ToInt32(dd);
                            int secondsum;
                            secondsum = Convert.ToInt32(+www + "" + qqq+""+zero);

                            for (int w = 0; w < arr2.Length; w++)
                            {
                                if (firstsum == arr2[w] || secondsum == arr2[w])
                                {
                                    found = true;

                                }

                            }
                        }

                        if (found == true)
                        {
                            MessageBox.Show("Time Conflict for this employee, please select another employee or time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);




                        }

                        else if (found == false)
                        {
                            int[] arr3 = new int[comboBox13.Items.Count];// for ex, 5 size.
                            int eh3 = 0;

                            for (int i = 0; i < arr3.Length; i++)
                            {

                                arr3[i] = eh3;
                                eh3 = eh3 + 1;

                                int[] arr2 = new int[100];
                                string n = comboBox13.Items[arr3[i]].ToString();
                                int m = Convert.ToInt32(n);

                                for (int a = 0; a < arr2.Length; a++)
                                {
                                    arr2[a] = m;
                                    m = m + 1;

                                }

                                string aa = comboBox6.Text.ToString();//hour sa starttime
                                int xxx = Convert.ToInt32(aa);
                                string bb = comboBox7.Text.ToString();//mins sa starttime
                                int yyy = Convert.ToInt32(bb);
                                int firstsum;
                                firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

                                string cc = comboBox8.Text.ToString();//hour sa endtime
                                int www = Convert.ToInt32(cc);
                                string dd = comboBox9.Text.ToString();//mins sa endtime      
                                int qqq = Convert.ToInt32(dd);
                                int secondsum;
                                secondsum = Convert.ToInt32(+www + "" + qqq+""+zero);
                                for (int w = 0; w < arr2.Length; w++)
                                {
                                    if (firstsum == arr2[w] || secondsum == arr2[w])
                                    {
                                        found2 = true;

                                    }

                                }
                            }



                        }

                        if (found2 == true)
                        {
                            found2 = true;
                            MessageBox.Show("Time Conflict for this Driver, please select another Driver or time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                        else if (found == false && found2 == false)
                        {

                            MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox18.Text + "'", conn);
                            comm2.ExecuteNonQuery();
                            MySqlDataReader dr = comm2.ExecuteReader();
                            if (dr.Read())
                            {
                                textBox14.Text = dr["FULLNAME"].ToString();

                            }


                            string cc2 = "";
                            string c = " ";
                            string a2 = comboBox6.Text + c + comboBox7.Text + c + comboBox4.Text;
                            string b = comboBox8.Text + c + comboBox9.Text + c + comboBox5.Text;
                            string ccc = comboBox6.Text + cc2 + comboBox7.Text;
                            string cccc = comboBox8.Text + cc2 + comboBox9.Text;

                            string thedate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                            DateTime _date = DateTime.Now;
                            var _dateString = _date.ToString("MM/dd/yyyy");

                            dr.Close();
                            //int tagatrans = 6;

                            MySqlCommand comm10 = new MySqlCommand("Select Price from dbsystem.tblservices where ServiceName='" + comboBox3.Text + "'", conn);
                            comm10.ExecuteNonQuery();

                            decimal presyo = (decimal)comm10.ExecuteScalar();
                           // MessageBox.Show(presyo.ToString());


                            int tagaProcessNgIDnumber = numberNgLastTransID + 1;
                            MySqlCommand comm = new MySqlCommand("Insert into dbsystem.tbltrans (Price,TransID,Service,StartTime,EndTime,StartTimeSession,EndTimeSession,ClientID,FULLNAME,AssignedEmp,AssignedDriver,DateMade,st,et,DateOfService) values ('"+presyo+"','"+tagaProcessNgIDnumber+"','" + comboBox3.Text + "','" + a2 + "','" + b + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox18.Text + "','" + textBox14.Text + "','" + comboBox2.Text + "','" + comboBox10.Text + "','" + _dateString + "','" + ccc + "','" + cccc + "','" + thedate + "')", conn);
                            comm.ExecuteNonQuery();
                          

                            MessageBox.Show("Transaction Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        
                          /*  int n = dataGridView2.Rows.Add();
                            dataGridView2.Rows[n].Cells[0].Value = comboBox3.Text;
                            dataGridView2.Rows[n].Cells[1].Value = a2;
                            dataGridView2.Rows[n].Cells[2].Value = b;
                            dataGridView2.Rows[n].Cells[3].Value = textBox23.Text;
                            dataGridView2.Rows[n].Cells[4].Value = comboBox2.Text;
                            dataGridView2.Rows[n].Cells[5].Value = comboBox10.Text;
                            dataGridView2.Rows[n].Cells[6].Value = textBox16.Text;
                            dataGridView2.Rows[n].Cells[7].Value = textBox9.Text;*/
                            CartItem item = new CartItem()
                            {
                               Services=comboBox3.Text,
                                StartTime=a2,
                                EndTime=b,
                                FULLNAME=textBox23.Text,
                                AssignedEmp=comboBox2.Text,
                                AssignedDriver=comboBox10.Text,
                                DateOfService=textBox16.Text,
                                Address=textBox9.Text

                                

                            };
                            shoppingCart.Add(item);
                            dataGridView2.DataSource = null;
                            dataGridView2.DataSource = shoppingCart;
                          

                            comboBox3.Items.Remove(comboBox3.Text);
                            comboBox2.Text = null;
                            comboBox10.Text = null;
                            comboBox12.Text = null;
                            comboBox13.Text = null;
                        }




                    }

                }
            }
        }

      

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            //dateTimePicker1.Value = DateTime.Today;
            
           DateTime _date = DateTime.Now;
           // dateTimePicker1.MinDate = _date;
            var _dateString = _date.ToString("MM/dd/yyyy");
            label44.Text = _dateString.ToString();
            var _dateString2 = _date.ToString("MM/dd/yyyy");
           // dateTimePicker1.MinDate = DateTime.Now;
          //  MessageBox.Show(_dateString.ToString());
          /*  if (comboBox10.Text != "") {
                textBox15.Text = comboBox10.Text;
            }*/
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

           /* 
            MySqlCommand comm2 = new MySqlCommand("SELECT MAX(TransID) FROM dbsystem.tbltrans", conn);
            int ID = (int)comm2.ExecuteScalar();
            comm2.ExecuteNonQuery();
            */

            

            
            
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr where ClientID='" + label19.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read()) {
                textBox18.Text = dr["ClientID"].ToString();
                textBox13.Text = dr["fname"].ToString();
                textBox12.Text = dr["mname"].ToString();
                textBox11.Text = dr["lname"].ToString();
                textBox10.Text = dr["age"].ToString();
                textBox9.Text = dr["address"].ToString();
                textBox8.Text = dr["ContactNo"].ToString();
                textBox19.Text = dr["Gender"].ToString();
                textBox23.Text = dr["FULLNAME"].ToString();
                

            }
            conn.Close();
          

        }

        private void button42_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel1.Enabled = true;

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "11" && comboBox4.Text == "PM")
            {
                MessageBox.Show("Time to sleep for past 12", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string a = comboBox6.Text;
                int x = Convert.ToInt32(a);
                x += 1;
                string b = Convert.ToString(x);
                comboBox8.Text = b;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Text = comboBox7.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {



                comboBox5.Text = comboBox4.Text;
                if (comboBox6.Text == "11" && comboBox4.Text == "PM")
                {
                    MessageBox.Show("Time to sleep for past 12", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    if (comboBox6.Text == "11" && comboBox4.Text == "AM")
                    {

                        comboBox5.Text = "PM";

                    }
                    if (comboBox6.Text == "11" && comboBox4.Text == "PM")
                    {
                        comboBox5.Text = "AM";

                    }
                }
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.Items.Clear();
            comboBox10.Refresh();
            comboBox2.Items.Clear();
            comboBox2.Refresh();
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("Select ServiceType from dbsystem.tblServices where ServiceName='" + comboBox3.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {

                string a = dr["ServiceType"].ToString();


                dr.Close();
                string storage = "";
                if (a == "Massage")
                {
                    storage = "Therapist";

                }
                if (a == "Hair" || a=="Waxing")
                {

                    storage = "Beautician";
                }

              //  MessageBox.Show(storage);
                MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblEmp where Position='" + storage + "'", conn);
                comm2.ExecuteNonQuery();

                MySqlDataReader dr2 = comm2.ExecuteReader();
                while (dr2.Read())
                {
                    if (!comboBox2.Items.Contains(dr2["FULLNAME"].ToString()))
                    {
                        comboBox2.Items.Add(dr2["FULLNAME"].ToString());

                    }


                }
                dr2.Close();
                comboBox2.Sorted = true;

               string drdr="Driver";
               MySqlCommand comm7 = new MySqlCommand("Select * from dbsystem.tblEmp where Position='" + drdr + "'", conn);
                comm7.ExecuteNonQuery();
                MySqlDataReader dr7 = comm7.ExecuteReader();
                while (dr7.Read())
                {
                    if (!comboBox10.Items.Contains(dr7["FULLNAME"].ToString()))
                    {
                        comboBox10.Items.Add(dr7["FULLNAME"].ToString());

                    }

                }
                dr7.Close();
                comboBox10.Sorted = true;


            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Clients_Information from = new Clients_Information();

            Form fc = Application.OpenForms["Clients_Information"];

            if (fc != null)
            {
                fc.Close();
                from.Close();
            }
            else
            {
                from.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransactionUpdate from = new TransactionUpdate();
            from.Show();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            shoppingCart.Clear();
          //  dataGridView2.Rows.Clear();
           // dataGridView2.Refresh();
            button5.Visible = true;
            comboBox3.Items.Clear();
            comboBox3.Refresh();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            x = 0;
            panel3.Hide();
            panel1.Hide();
            panel1.Enabled = true;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*Update_Client from = new Update_Client();
            from.Show();*/
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reports from = new Reports();
            from.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Transaction_Time_Update from = new Transaction_Time_Update();
            from.Show();
        }

       /* private void timer2_Tick(object sender, EventArgs e)
        {
            if (label39.ForeColor == Color.Gray)
            {
                label39.ForeColor = Color.White;
                timer2.Interval = 550;
            }
            else
            {
                label39.ForeColor = Color.Gray;
                timer2.Interval = 550;
            }

        }*/

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr where FULLNAME='" + comboBox11.Text + "'", conn);
            MySqlDataReader dr = comm.ExecuteReader();
     
            if (dr.Read())
            {
               textBox17.Text = dr["ClientID"].ToString();
                textBox2.Text = dr["fname"].ToString();
                textBox3.Text = dr["mname"].ToString();
                textBox4.Text = dr["lname"].ToString();
                textBox5.Text = dr["age"].ToString();
                textBox6.Text = dr["address"].ToString();
                textBox7.Text = dr["ContactNo"].ToString();


            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblServices where ServiceName='" + comboBox1.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox20.Text = dr["ServiceType"].ToString();
                textBox21.Text = dr["Price"].ToString();
                textBox22.Text = dr["Duration"].ToString();


            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select some service/s", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox21.Text;

                string num = textBox21.Text.ToString() ;
                double numnumnum = Convert.ToDouble(num);//new
              //  int numnum = Convert.ToInt32(num);//old
              
                x += numnumnum;           
                textBox1.Text = x.ToString();
                comboBox3.Items.Add(comboBox1.Text);
            }


          
        

        }

        private void button17_Click_1(object sender, EventArgs e)
        {

            ServiceList from = new ServiceList();

            Form fc = Application.OpenForms["ServiceList"]; 

            if (fc != null)
            {

                fc.Close();
                from.Show();
            }
            else
            {
                from.Show();
            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            DateTime now=DateTime.Now;
            MySqlCommand comm = new MySqlCommand("Insert into dbsystem.userslogout(TimeOut) values ('" + now + "')", conn);
            comm.ExecuteNonQuery();

            this.Close();
            
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            Main sohai = new Main();
            sohai.Hide();
            Login from = new Login();
            from.Show();
            

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
           
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            

            
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            DateTime _date = DateTime.Now;
            var _dateString = _date.ToString("MM/dd/yyyy");
           

          //  string waw = textBox15.Text;
            comboBox12.Items.Clear();
            comboBox12.Refresh();
            MySqlConnection conn6 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn6.Open();
            MySqlCommand comm6 = new MySqlCommand("Select st from dbsystem.tblTrans where DateOfService='" + textBox16.Text + "'and Assignedemp='"+comboBox2.Text+"'", conn6);
            MySqlDataReader dr6 = comm6.ExecuteReader();

            while (dr6.Read())
            {
                if (!comboBox12.Items.Contains(dr6["st"].ToString()))
                {
                    comboBox12.Items.Add(dr6["st"].ToString());

                }


            }
            comboBox12.Sorted = true;
            comboBox12.Refresh();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn6 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn6.Open();
            MySqlCommand comm6 = new MySqlCommand("Select st from dbsystem.tblTrans where AssignedEmp='" + comboBox2.Text + "'", conn6);
            MySqlDataReader dr6 = comm6.ExecuteReader();

            while (dr6.Read())
            {
                if (!comboBox12.Items.Contains(dr6[0]))
                {
                    comboBox12.Items.Add(dr6[0]);

                }


            }
            for (Int16 i = 0; comboBox12.Items.Count - 1 >= i; i++)
            {
                MessageBox.Show(comboBox12.Items[i].ToString());

            }

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox13.Items.Clear();
            comboBox13.Refresh();

            DateTime _date = DateTime.Now;
            var _dateString = _date.ToString("MM/dd/yyyy");
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tbltrans where DateOfService='"+textBox16.Text+"'and AssignedDriver='" + comboBox10.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {

                if (!comboBox13.Items.Contains(dr["st"].ToString()))
                {
                    comboBox13.Items.Add(dr["st"].ToString());
                }

            }
            comboBox13.Sorted = true;
            comboBox13.Refresh();
        }


        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click_2(object sender, EventArgs e)
        { MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
        conn.Open();
            MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox18.Text + "'", conn);
            comm2.ExecuteNonQuery();
            
            MySqlDataReader dr = comm2.ExecuteReader();

            if (dr.Read())
            {
                string fn = dr["FULLNAME"].ToString();
                MessageBox.Show(fn.ToString());
            }
        }

        private void button20_Click_3(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            var vavar = dateTimePicker1.Value.Date;
            String vavavar = vavar.ToString("MM/dd/yyyy");
          //  DateTime nana = vavavar.ToString();
         //   string aw = vavavar;
          //  MessageBox.Show(aw);
            textBox16.Text = vavavar;
            comboBox2.Text = null;
            comboBox10.Text = null;
            comboBox12.Text = null;
            comboBox13.Text = null;
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {
            button5.Visible = true;

        }
       

        private void label49_Click(object sender, EventArgs e)
        {
          
        }

        private void label50_Click(object sender, EventArgs e)
        {
            ServiceList from = new ServiceList();

            Form fc = Application.OpenForms["ServiceList"];

            if (fc != null)
            {

                fc.Close();
                from.Show();
            }
            else
            {
                from.Show();
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Update_Client from = new Update_Client();
            from.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            this.printDocument1.DefaultPageSettings.Landscape = true;
            Image image = Resources.yeye;
           // e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
            string a = "FOREVER TOUCH BODY";
            e.Graphics.DrawString("FOREVER TOUCH BODY AND BEAUTY SPA", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 50));
            e.Graphics.DrawString("(90) Mindanao Alabang Village Muntinlupa City",new Font("Arial",15,FontStyle.Regular),Brushes.Black,new Point(360,90));

            e.Graphics.DrawString("Date : "+ DateTime.Now.ToShortDateString(),new Font("Arial",12,FontStyle.Regular),Brushes.Black,new Point(25,160));

            e.Graphics.DrawString("Client Name : " + textBox23.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 235));

            e.Graphics.DrawString("Service", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 255));
            e.Graphics.DrawString("StartTime", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(190, 255));
            e.Graphics.DrawString("EndTime", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(270, 255));
            e.Graphics.DrawString("FULLNAME", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 255));
         //   e.Graphics.DrawString("AssignedEmp", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(460, 255));
          //  e.Graphics.DrawString("AssignedDriver", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(590, 255));
            e.Graphics.DrawString("DateOfService", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(610, 255));
            e.Graphics.DrawString("Address", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(780, 255));
           // e.Graphics.DrawString("Service", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 255));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 270));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 700));
            e.Graphics.DrawString("Total Amount : P " + textBox25.Text + " PHP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, 720));
       
            e.Graphics.DrawString("Sales Tax :     P " + textBox24.Text + " PHP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, 750));
            e.Graphics.DrawString("Total To pay:    P " + textBox1.Text + " PHP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, 780));
            e.Graphics.DrawString("_______________________________ : ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(25, 730));
            e.Graphics.DrawString("Client's Signature Over Printed Name : ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(25, 760));
            int yPos = 295;

            foreach (var i in shoppingCart)
                
            {
                e.Graphics.DrawString(i.Services, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(i.StartTime, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(190, yPos));
                e.Graphics.DrawString(i.EndTime, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(270, yPos));
                e.Graphics.DrawString(i.FULLNAME, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, yPos));
                //e.Graphics.DrawString(i.AssignedEmp, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(460, yPos));
               // e.Graphics.DrawString(i.AssignedDriver, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(590, yPos));
                e.Graphics.DrawString(i.DateOfService, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(610, yPos));
                e.Graphics.DrawString(i.Address, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(780, yPos));
                
                yPos += 30; 
            }

           

        
        
        
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            this.printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
         
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            mainte_admin_AddNewService from = new mainte_admin_AddNewService();
            from.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            FirstNoti form = new FirstNoti();
            form.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Userslog from = new Userslog();
            from.Show();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click_2(object sender, EventArgs e)
        {
            string aa = comboBox6.Text.ToString();
            int xxx = Convert.ToInt32(aa);
            string bb = comboBox7.Text.ToString();//mins sa starttime
            int yyy = Convert.ToInt32(bb);

            string zero = "0";
            int firstsum;
            firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

            MessageBox.Show(firstsum.ToString());
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
