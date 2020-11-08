using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using LogIn.Properties;

namespace LogIn
{


    public partial class ServiceList : Form
    {
        public ServiceList()
        {
            InitializeComponent();
        }

        private void ServiceList_Load(object sender, EventArgs e)
        {
          
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblServices", conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
        
            DataTable dt = new DataTable();
            adapt.Fill(dt);
          
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblServices where ServiceName like '%" + textBox1.Text + "%'", conn);

          //  .Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
          
            dataGridView1.DataSource = dt;
           


        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblServices where ServiceName like '%" + textBox1.Text + "%'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count == 0)
            {

                MessageBox.Show("No records found!", "No records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();
            //printDocument1.DefaultPageSettings.Landscape = true;
            printer.printDocument.DefaultPageSettings.Landscape = true;

            printer.Title = "FOREVER TOUCH BODY AND BEAUTY SPA \n\n\n Services List  \n \n";
            printer.Footer = "CYKA BLYAT RUSH B";//footer
            printer.FooterSpacing = 15;
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.printDocument.PrintPage += PrintPage;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.PrintDataGridView(dataGridView1);
        }
         private void PrintPage(object o, PrintPageEventArgs e)
        {
            Image image = Resources.relax;
            e.Graphics.DrawImage(image, 100, 30, image.Width, image.Height);
            e.Graphics.DrawString("(90) Mindanao Ayala Alabang Village Muntinlupa City", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(370, 70));


        }
    }
}
