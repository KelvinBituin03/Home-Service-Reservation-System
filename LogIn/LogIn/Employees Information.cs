using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using LogIn.Properties;
using DGVPrinterHelper;
using System.Drawing.Printing;
namespace LogIn
{
    public partial class Employees_Information : Form
    {
        public Employees_Information()
        {
            InitializeComponent();
            AutoCompleteText();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
             MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblemp", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;



            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.True;


            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].Resizable = DataGridViewTriState.True;


            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].Resizable = DataGridViewTriState.True;


            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].Resizable = DataGridViewTriState.True;

            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].Resizable = DataGridViewTriState.True;
           

            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].Resizable = DataGridViewTriState.True;

            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[6].Resizable = DataGridViewTriState.True;

            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[7].Resizable = DataGridViewTriState.True;

            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[8].Resizable = DataGridViewTriState.True;

            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[9].Resizable = DataGridViewTriState.True;
            dataGridView1.ClearSelection();

            conn.Close();
            conn.Dispose();
        }

        private void button44_Click(object sender, EventArgs e)
        {

             MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblemp", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            conn.Dispose();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblEmp where FULLNAME like '%" + textBox1.Text + "%'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Information_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
      //      MySqlCommand comm = new MySqlCommand("Select FULLNAME from dbsystem.tblEmp", conn);
            MySqlCommand comm = new MySqlCommand("Select FULLNAME from dbsystem.tblEmp where Position IN ('Therapist','Beautician')", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                if (!comboBox1.Items.Contains(dr[0]))
                {
                    comboBox1.Items.Add(dr[0]);

                }


            }
            dr.Close();
            conn.Close();
            comboBox1.Sorted = true;

            MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn2.Open();

            MySqlCommand comm2 = new MySqlCommand("Select ServiceName from dbsystem.tblServices", conn2);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            while (dr2.Read())
            {
                if (!comboBox2.Items.Contains(dr2[0]))
                {
                    comboBox2.Items.Add(dr2[0]);
                }
            }
            dr2.Close();
            
            comboBox2.Sorted = true;
            conn2.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblEmp where FULLNAME like '%" + comboBox1.Text + "%'", conn);

            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblEmp where FULLNAME like '%" + textBox2.Text + "%'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;*/
        }
        void AutoCompleteText()
        {/*
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblEmp",conn);

            comm.ExecuteNonQuery();
            MySqlDataReader dr=comm.ExecuteReader();
                    try{

                    while(dr.Read()){
                        string sName = dr["FULLNAME"].ToString();
                     coll.Add(sName);
                    }

                    }catch(Exception ex){

                    MessageBox.Show(ex.ToString());
                    }
                    textBox2.AutoCompleteCustomSource = coll;*/


        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            /*MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblEmp where FULLNAME='"+textBox2.Text+"'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            while (dr.Read())
            {

                string searcher = dr["FULLNAME"].ToString();
                coll.Add(searcher);
            }
            textBox2.AutoCompleteCustomSource = coll;

            dr.Close();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;*/
   /////
            
            /*    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();  
            MySqlCommand comm = new MySqlCommand("Select Position from dbsystem.tblEmp where FULLNAME='"+textBox2.Text+"'",conn);
            comm.ExecuteNonQuery();
            MySqlCommand comm2=new MySqlCommand("Select * from dbsystem.tblServices where")
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;*/
           
        }

            private  void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            bool ye = true;
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select Position from dbsystem.tblEmp where FULLNAME='"+comboBox1.Text+"'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
 
            if (dr.Read())
            {
              
                string a = dr["Position"].ToString();
                
                dr.Close();
                string storage = "";
                string storage2 = "";
                if (a == "Therapist")
                {
                    storage = "Massage";
                    ye=true;
                   
                }
                if (a == "Beautician")
                {
        
                    storage = "Hair";
                    storage2="Waxing";
                    ye = false;
                   
                }

                if (ye == false)
                {

                    MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblServices where ServiceType IN ('"+storage+"','"+storage2+"')",conn);
                       MySqlDataAdapter adapt = new MySqlDataAdapter();
                    adapt.SelectCommand = comm2;
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                    conn.Dispose();
                }else if(ye==true)
                {
                    MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblServices where ServiceType='" + storage + "'", conn);
                    comm2.ExecuteNonQuery();
                 
                    MySqlDataAdapter adapt = new MySqlDataAdapter();
                    adapt.SelectCommand = comm2;
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                    conn.Dispose();


                }

            }

            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = "";
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceType from dbsystem.tblServices where ServiceName='" + comboBox2.Text + "'", conn);
            comm.ExecuteNonQuery();
            
            MySqlDataReader dr= comm.ExecuteReader();
            if (dr.Read())
            {
              a = dr["ServiceType"].ToString();
            }
            dr.Close();
         
            if (a == "Massage")
            {
                MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblEmp where Position='Therapist'", conn);
                comm2.ExecuteNonQuery();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm2;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                conn.Close();
                conn.Dispose();


            }
            else if (a == "Hair" || a == "Waxing")
            {
                MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblEmp where Position IN ('Thereapist','Beautician')", conn);
                comm2.ExecuteNonQuery();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm2;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                conn.Close();
                conn.Dispose();

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {
            string a = "";
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select ServiceType from dbsystem.tblServices where ServiceName like '%" + textBox1.Text + "%'", conn);

            comm.ExecuteNonQuery();

            MySqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                a = dr["ServiceType"].ToString();
            }
            dr.Close();

            if (a == "Massage")
            {
                MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblEmp where Position='Therapist'", conn);
                comm2.ExecuteNonQuery();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm2;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                conn.Close();
                conn.Dispose();


            }
            else if (a == "Hair" || a == "Waxing")
            {
                MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblEmp where Position IN ('Thereapist','Beautician')", conn);
                comm2.ExecuteNonQuery();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm2;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                conn.Close();
                conn.Dispose();

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool ye = true;
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select Position from dbsystem.tblEmp where FULLNAME like '%" + textBox3.Text + "%'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {

                string a = dr["Position"].ToString();

                dr.Close();
                string storage = "";
                string storage2 = "";
                if (a == "Therapist")
                {
                    storage = "Massage";
                    ye = true;

                }
                if (a == "Beautician")
                {

                    storage = "Hair";
                    storage2 = "Waxing";
                    ye = false;

                }

                if (ye == false)
                {

                    MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblServices where ServiceType IN ('" + storage + "','" + storage2 + "')", conn);
                    MySqlDataAdapter adapt = new MySqlDataAdapter();
                    adapt.SelectCommand = comm2;
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                    conn.Dispose();
                }
                else if (ye == true)
                {
                    MySqlCommand comm2 = new MySqlCommand("Select * from dbsystem.tblServices where ServiceType='" + storage + "'", conn);
                    comm2.ExecuteNonQuery();

                    MySqlDataAdapter adapt = new MySqlDataAdapter();
                    adapt.SelectCommand = comm2;
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                    conn.Dispose();


                }

            }
        }
        Bitmap bitmap;
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Fill your list first by selecting a date to print!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                printDocument1.DefaultPageSettings.Landscape = true;
                //Resize DataGridView to full height.
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

                //Create a Bitmap and draw the DataGridView on it.
                bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

                //Resize DataGridView back to original height.
                dataGridView1.Height = height;

                //Show the Print Preview Dialog.
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();

            }*/
            DGVPrinter printer = new DGVPrinter();
            printDocument1.DefaultPageSettings.Landscape = true;
            printer.printDocument.DefaultPageSettings.Landscape = true;


            printer.Title = "FOREVER TOUCH BODY AND BEAUTY SPA \n\n\n Employees Report  \n \n";
            printer.Footer = "CYKA BLYAT RUSH B";//footer
            printer.FooterSpacing = 15;
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.printDocument.PrintPage += PrintPage;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
           
            printer.PrintDataGridView(dataGridView1);
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            Image image = Resources.relax;
            e.Graphics.DrawImage(image, 100, 30, image.Width, image.Height);
            e.Graphics.DrawString("(90) Mindanao Ayala Alabang Village Muntinlupa City", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(370, 70));


        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 250);
            this.printDocument1.DefaultPageSettings.Landscape = true;
            Image image = Resources.yeye;
            e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
            e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
