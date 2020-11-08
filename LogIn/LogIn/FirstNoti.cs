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
    public partial class FirstNoti : Form
    {
        public FirstNoti()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void FirstNoti_Load(object sender, EventArgs e)
        {

          //  dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
           // dataGridView1.MultiSelect = false;
            DateTime _dateString = DateTime.Now;
            var vavar = _dateString;
            var vavavar = vavar.ToString("MM/dd/yyyy");
           // MessageBox.Show(vavavar.ToString());

            
            //var vavar = dateTimePicker1.Value.Date;
        //    String vavavar = vavar.ToString("MM/dd/yyyy");

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select tbltrans.TransID,tbltrans.Service,tbltrans.StartTime,tbltrans.EndTime,tbltrans.FULLNAME,tbltrans.AssignedEMP,tbltrans.AssignedDriver,tbltrans.DateMade,tbltrans.DateOfService,tbltrans.Status,tblcstmr.ContactNo from dbsystem.tbltrans INNER JOIN dbsystem.tblcstmr on tbltrans.FULLNAME=tblcstmr.FULLNAME where DateOfService='" + vavavar + "'and Status='" + "" + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;

            int numberOfRows = dataGridView1.Rows.Count;
            numberOfRows -= 1;
            label1.Text = numberOfRows.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["TransID"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Service"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["StartTime"].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells["EndTime"].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells["FULLNAME"].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells["AssignedEmp"].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells["AssignedDriver"].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells["DateMade"].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells["DateOfService"].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells["ContactNo"].Value.ToString();
            
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + "+63"+textBox11.Text + "&" +
                        "dst=+" + "+63" + textBox11.Text + "&" +
                        "msg=" + System.Web.HttpUtility.UrlEncode("You have a scheduled service for today, please text the no. 09153250308 to confirm your schedule for today, thank you", System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                        "username=" + System.Web.HttpUtility.UrlEncode("banjo.rae.rondilla@globalcity.sti.edu") + "&" +
                        "password=" + System.Web.HttpUtility.UrlEncode("ocxp3");
                    string result = client.DownloadString(url);

                    if (result.Contains("OK"))
                    {
                        MessageBox.Show("Your message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Message Failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
          string s= "+63"+textBox11.Text ;
          MessageBox.Show(s);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int numberOfRows = dataGridView1.Rows.Count - 1;
            comboBox1.Items.Clear();
            comboBox1.Refresh();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
              
                if (item.Cells.Count >= 2 && //atleast two columns
                      item.Cells[10].Value != null) //value is not null
                {
                    comboBox1.Items.Add("+63"+item.Cells[10].Value.ToString());
                }

              
              
            }

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                MessageBox.Show(comboBox1.Items[i].ToString());

                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    try
                    {

                        /*SMS ACCOUNT BACKUP
                          xtinaaaa@yahoo.com
                          j9l99
                          
                          */
                         
                         
                        string url = "http://smsc.vianett.no/v3/send.ashx?" +
                            "src="  + comboBox1.Items[i].ToString() + "&" +
                            "dst=+" + comboBox1.Items[i].ToString() + "&" +
                            "msg=" + System.Web.HttpUtility.UrlEncode("Good day!, please be informed that you have a scheduled service for today, Thank you!", System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                            "username=" + System.Web.HttpUtility.UrlEncode("banjo.rae.rondilla@globalcity.sti.edu") + "&" +
                            "password=" + System.Web.HttpUtility.UrlEncode("ocxp3");
                        string result = client.DownloadString(url);

                        if (result.Contains("OK"))
                        {
                            MessageBox.Show("Your message has been successfully sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Message Failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
               
            }
          

           
        }
    }
}
