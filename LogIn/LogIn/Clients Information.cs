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
    public partial class Clients_Information : Form
    {
        public Clients_Information()
        {
            InitializeComponent();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            
               // string s = "/";
              //  string a = comboBox1.Text + s + comboBox2.Text + s + comboBox3.Text;
                //MessageBox.Show(a);
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr where FULLNAME like '%" + textBox1.Text + "%'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Clients_Information_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection(); 
            dataGridView1.AllowUserToAddRows = false;
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
           // MySqlCommand comm = new MySqlCommand("Select ClientID,fname,mname,lname,age,address,ContactNo from dbsystem.tblcstmr", conn);
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr", conn);
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
          
            conn.Close();
            conn.Dispose();

            dataGridView1.ClearSelection(); 
            
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from dbsystem.tblcstmr where FULLNAME like '%" + textBox1.Text + "%'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;*/

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Bitmap bitmap;
        private void button2_Click_1(object sender, EventArgs e)
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


            printer.Title = "FOREVER TOUCH BODY AND BEAUTY SPA \n\n\n Clients Report  \n \n";
            printer.Footer = "CYKA BLYAT RUSH B";//footer
            printer.FooterSpacing = 15;
                            
            printer.SubTitle=string.Format("Date: {0}",DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.printDocument.PrintPage += PrintPage;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.SubTitleFormatFlags=StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers=true;
            printer.PageNumberInHeader=false;
            printer.PorportionalColumns=true;
            printer.HeaderCellAlignment = StringAlignment.Near;
           
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
