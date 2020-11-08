using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using Microsoft.Office.Interop.Excel;
using LogIn.Properties;
using System.Collections;
using System.Drawing.Printing;





namespace LogIn
{
    using System.Collections;
    using DGVPrinterHelper;
    public partial class Reports : Form
    {

        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height

       
        private string _ReportHeader;
        
        
        
        string awaw222 = "";
        string numOfTransact = "";
        string a = "";
        Boolean founderngmgaadik = true;
        public Reports()
        {
            InitializeComponent();
        }
        #region Variables

       


       
      
        #endregion
       

      
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection(); 
            label9.Text = "0";
            if (radioButton1.Checked)
            {
                if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
                {
                    MessageBox.Show("Please input the date", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    string s = "/";
                     a = comboBox1.Text + s + comboBox2.Text + s + comboBox3.Text;

                }
                else
                {
                    string s = "/";
                    a = comboBox2.Text + s + comboBox1.Text + s + comboBox3.Text;

                    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand("Select tbltrans.TransID,tbltrans.Service,tbltrans.Price,tbltrans.StartTime,tbltrans.EndTime,tbltrans.FULLNAME,tbltrans.AssignedEMP,tbltrans.AssignedDriver,tbltrans.DateMade,tbltrans.DateOfService,tbltrans.status,tblcstmr.address from dbsystem.tbltrans INNER JOIN dbsystem.tblcstmr on tbltrans.FULLNAME=tblcstmr.FULLNAME where DateOfService='" + a + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlDataAdapter adapt = new MySqlDataAdapter();
                    adapt.SelectCommand = comm;
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapt.Fill(dt);

                    this.dataGridView1.DataSource = dt;
                    int numberOfRows = dataGridView1.Rows.Count;
                    //numberOfRows += 1;
                    label9.Text = numberOfRows.ToString();
                    label10.Visible = true;
                    label9.Visible = true;

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

                    this.dataGridView1.ClearSelection();


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
                    dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[10].Resizable = DataGridViewTriState.True;
                    dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[11].Resizable = DataGridViewTriState.True;

                }
            }
            else if (radioButton2.Checked)
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
               // MySqlCommand comm = new MySqlCommand("Select tbltrans.TransID,tbltrans.Service,tbltrans.Price,tbltrans.StartTime,tbltrans.EndTime,tbltrans.FULLNAME,tbltrans.AssignedEMP,tbltrans.AssignedDriver,tbltrans.DateMade,tbltrans.DateOfService,tbltrans.Status,tblcstmr.address from dbsystem.tbltrans INNER JOIN dbsystem.tblcstmr where DateOfService between'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", conn);
                //comm.ExecuteNonQuery();
              //  MySqlCommand comm = new MySqlCommand("Select TransID,Service,Price,StartTime,EndTime,FULLNAME,AssignedEMP,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tbltrans where DateOfService between'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", conn);
               // comm.ExecuteNonQuery();

                MySqlCommand comm = new MySqlCommand("Select tbltrans.TransID,tbltrans.Service,tbltrans.Price,tbltrans.StartTime,tbltrans.EndTime,tbltrans.FULLNAME,tbltrans.AssignedEMP,tbltrans.AssignedDriver,tbltrans.DateMade,tbltrans.DateOfService,tbltrans.Status,tblcstmr.address from dbsystem.tbltrans INNER JOIN dbsystem.tblcstmr on tbltrans.FULLNAME=tblcstmr.FULLNAME where DateOfService between'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", conn);
                 comm.ExecuteNonQuery();
                
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                System.Data.DataTable dt = new System.Data.DataTable();
                adapt.Fill(dt);

                this.dataGridView1.DataSource = dt;
                int numberOfRows2 = dataGridView1.Rows.Count;
              //  numberOfRows2 -= 1;
                label9.Text = numberOfRows2.ToString();
                label10.Visible = true;
                label9.Visible = true;
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

                this.dataGridView1.ClearSelection();



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
                dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[10].Resizable = DataGridViewTriState.True;

                dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[11].Resizable = DataGridViewTriState.True;

            }

          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = true;

            ws.Cells[1, 1] = "TransID";
            ws.Cells[1, 2] = "Service";
            ws.Cells[1, 3] = "StartTime";
            ws.Cells[1, 4] = "EndTime";
            ws.Cells[1, 5] = "StartTimeSession";
            ws.Cells[1, 6] = "EntTimeSession";
            ws.Cells[1, 7] = "ClientID";
            ws.Cells[1, 8] = "AssignedEmp";
            ws.Cells[1, 9] = "AssignedDriver";
            ws.Cells[1, 10] = "Date";

            for (int j = 2; j <=dataGridView1.Rows.Count; j++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    ws.Cells[j, i] = dataGridView1.Rows[j-2].Cells[i-1].Value;
                }
            }   
             */
        }

      

        private void Reports_Load(object sender, EventArgs e)
        {
          //  dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
           // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
         //   dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
           dataGridView1.AllowUserToAddRows = false;
            label10.Visible = false;
            label9.Visible = false;
         //   _printDocument1.DefaultPageSettings.Landscape = true;
            label7.Visible = false;
            label8.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            try
            {
             
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                var vavar = dateTimePicker1.Value.Date;
                String vavavar = vavar.ToString("MM/dd/yyyy");
                MySqlCommand comm = new MySqlCommand("SELECT Service,COUNT(Service) AS MostChosen from dbsystem.tbltrans where DateMade='"+vavavar+"' group by Service order by MostChosen DESC LIMIT 1", conn);
                comm.ExecuteNonQuery();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                System.Data.DataTable dt = new System.Data.DataTable();
                adapt.Fill(dt);

                this.dataGridView2.DataSource = dt;
               // awaw222 = dataGridView2.Rows[0].Cells[0].Value.ToString();
                conn.Close();
                conn.Dispose();
             
            }
            catch (Exception ee)
            {
                founderngmgaadik = false;
                MessageBox.Show(ee.ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        Bitmap bitmap;
       
        private void btnPrint_Click(object sender, EventArgs e)
        {
             

             
        
            
          
          
           // e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
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

            if (radioButton1.Checked)
            {
                DGVPrinter printer = new DGVPrinter();
                printDocument1.DefaultPageSettings.Landscape = true;
                printer.printDocument.DefaultPageSettings.Landscape = true;




                printer.Title = "FOREVER TOUCH BODY AND BEAUTY SPA \n\n\n Reservations Report  \n \n";
                printer.Footer = "FOREVER TOUCH BODY AND BEAUTY SPA";//footer
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
            else if (radioButton2.Checked) 
            
            {

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[0].Resizable = DataGridViewTriState.True;

                DGVPrinter printer = new DGVPrinter();
                printDocument1.DefaultPageSettings.Landscape = true;
                printer.printDocument.DefaultPageSettings.Landscape = true;

                Image image = Resources.yeye;
               printer.Title = "FOREVER TOUCH BODY AND BEAUTY SPA \n\n\n Reservations Report  \n \n";
           
                printer.Footer = "FOREVER TOUCH BODY AND BEAUTY SPA";//footer
                printer.FooterSpacing = 15;
                printer.printDocument.PrintPage += PrintPage;
              
                printer.SubTitle = string.Format("From: {0}", dateTimePicker1.Value.ToString("MM/dd/yyyy") + " to "+ dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;

                printer.PrintDataGridView(dataGridView1);

            }

        }

        private void PrintPage(object o,PrintPageEventArgs e)
        {

            Image image = Resources.relax;
            e.Graphics.DrawImage(image, 100, 30, image. Width, image.Height);
            e.Graphics.DrawString("Total AMT : " + label100.Text, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(56, 180));
            e.Graphics.DrawString("(90) Mindanao Ayala Alabang Village Muntinlupa City", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(370, 70));
            e.Graphics.DrawString("Generated by : Ritchie Del Mundo", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(750, 140));

        }



       
       



        /*
             if (radioButton2.Checked)
             {
                 //Print the contents.
                 e.Graphics.DrawImage(bitmap, 0, 250);
                 this.printDocument1.DefaultPageSettings.Landscape = true;
                 Image image = Resources.yeye;
                 e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
                 e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
                 e.Graphics.DrawString("Total Number of Transaction : " + label9.Text, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 225));
                 e.Graphics.DrawString("Transaction from " + dateTimePicker1.Value.ToString("MM/dd/yyyy") + " to " + dateTimePicker2.Value.ToString("MM/dd/yyyy"), new System.Drawing.Font("Arial", 18, FontStyle.Underline), Brushes.Black, new System.Drawing.Point(328, 185));
             }
             else if (radioButton1.Checked)
             {
                 e.Graphics.DrawImage(bitmap, 0, 250);
                 this.printDocument1.DefaultPageSettings.Landscape = true;
                 Image image = Resources.yeye;
                 e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
                 e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
                 e.Graphics.DrawString("Total Number of Transaction : " + label9.Text, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 225));
                 e.Graphics.DrawString("              Transaction for " + a, new System.Drawing.Font("Arial", 18, FontStyle.Underline), Brushes.Black, new System.Drawing.Point(328, 185));

             }
             else
             {
                 e.Graphics.DrawImage(bitmap, 0, 250);
                 this.printDocument1.DefaultPageSettings.Landscape = true ;
                 Image image = Resources.yeye;
                 e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
                 e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
                 e.Graphics.DrawString("Total Number of Transaction : " + label9.Text, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 225));
                 e.Graphics.DrawString("             Most Chosen Service Today " + a, new System.Drawing.Font("Arial", 18, FontStyle.Underline), Brushes.Black, new System.Drawing.Point(328, 185));

             }
              */
       


       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            label7.Visible = true;
            label8.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

           dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            label7.Visible = false;
            label8.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            if (founderngmgaadik == true)
            {
                var vavar = dateTimePicker1.Value.Date;
                String vavavar = vavar.ToString("MM/dd/yyyy");
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select TransID,Service,StartTime,EndTime,FULLNAME,AssignedEMP,AssignedDriver,DateMade,DateOfService,Status from dbsystem.tbltrans where Service='" + awaw222 + "'and DateMade='" + vavavar + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                System.Data.DataTable dt = new System.Data.DataTable();
                adapt.Fill(dt);

                this.dataGridView1.DataSource = dt;
                int numberOfRows = dataGridView1.Rows.Count;
               // numberOfRows -= 1;

                label9.Text = numberOfRows.ToString();
                label10.Visible = true;
                label9.Visible = true;
                conn.Close();
                conn.Dispose();

            }
            else if(founderngmgaadik==false)
            {
                MessageBox.Show("No Transaction has been made this day", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender,
    System.Drawing.Printing.PrintPageEventArgs e)
{
    if (radioButton2.Checked)
    {
        //Print the contents.
        e.Graphics.DrawImage(bitmap, 0, 250);
        this.printDocument1.DefaultPageSettings.Landscape = true;
        Image image = Resources.yeye;
        e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
        e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
        e.Graphics.DrawString("Total Number of Transaction : " + label9.Text, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 225));
        e.Graphics.DrawString("Transaction from " + dateTimePicker1.Value.ToString("MM/dd/yyyy") + " to " + dateTimePicker2.Value.ToString("MM/dd/yyyy"), new System.Drawing.Font("Arial", 18, FontStyle.Underline), Brushes.Black, new System.Drawing.Point(328, 185));
    }
    else if (radioButton1.Checked)
    {
        e.Graphics.DrawImage(bitmap, 0, 250);
        this.printDocument1.DefaultPageSettings.Landscape = true;
        Image image = Resources.yeye;
        e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
        e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
        e.Graphics.DrawString("Total Number of Transaction : " + label9.Text, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 225));
        e.Graphics.DrawString("              Transaction for " + a, new System.Drawing.Font("Arial", 18, FontStyle.Underline), Brushes.Black, new System.Drawing.Point(328, 185));

    }
    else
    {
        e.Graphics.DrawImage(bitmap, 0, 250);
        this.printDocument1.DefaultPageSettings.Landscape = true;
        Image image = Resources.yeye;
        e.Graphics.DrawImage(image, 290, 0, image.Width, image.Height);
        e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 200));
        e.Graphics.DrawString("Total Number of Transaction : " + label9.Text, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 225));
        e.Graphics.DrawString("             Most Chosen Service Today " + a, new System.Drawing.Font("Arial", 18, FontStyle.Underline), Brushes.Black, new System.Drawing.Point(328, 185));

    }
}


      

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

           
    }
}
 
