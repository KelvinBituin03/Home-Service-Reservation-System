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
    public partial class Transaction_Time_Update : Form
    {
        public Transaction_Time_Update()
        {
            InitializeComponent();
        }

        private void Transaction_Time_Update_Load(object sender, EventArgs e)
        {
           
          
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select TransID from dbsystem.tbltrans", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            dr.Dispose();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_stEmp.Items.Clear();
            cb_stEmp.Refresh();
            cb_stDriver.Items.Clear();
            cb_stDriver.Refresh();

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("select * from dbsystem.tbltrans where TransID='" + comboBox1.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {

                textBox4.Text = dr["ClientID"].ToString();
                textBox1.Text = dr["Service"].ToString();
                textBox2.Text = dr["StartTime"].ToString();
                textBox5.Text = dr["EndTime"].ToString();
                tb_emp.Text = dr["AssignedEmp"].ToString();
                tb_driver.Text = dr["AssignedDriver"].ToString();
                textBox6.Text = dr["DateOfService"].ToString();
            }
            dr.Close();

         
            MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox4.Text + "'", conn);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();

            if (dr2.Read())
            {
                textBox3.Text = dr2["FULLNAME"].ToString();
                dr2.Close();
            }
            conn.Close();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = comboBox2.Text;
            int x = Convert.ToInt32(a);
            x += 1;
            string b = Convert.ToString(x);
            comboBox5.Text = b;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Refresh();
            string a = comboBox3.Text;
            int x = Convert.ToInt32(a);
         //   x += 1;
            string b = Convert.ToString(x);
            comboBox6.Text = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zero = "0";
            DateTime nanaw = DateTime.Now;
            String vaar2 = nanaw.ToString("MM/dd/yyyy");//  MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
         //   conn.Open();
            if ((comboBox2.Text == "12" && comboBox4.Text == "AM") || (comboBox2.Text == "1" && comboBox4.Text == "AM") || (comboBox2.Text == "2" && comboBox4.Text == "AM") || (comboBox2.Text == "3" && comboBox4.Text == "AM") || (comboBox2.Text == "4" && comboBox4.Text == "AM") || (comboBox2.Text == "5" && comboBox4.Text == "AM") || (comboBox2.Text == "6" && comboBox4.Text == "AM") || (comboBox2.Text == "7" && comboBox4.Text == "AM") || (comboBox2.Text == "8" && comboBox4.Text == "AM"))
            {
                MessageBox.Show("The business is only open from 1pm-11pm", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (comboBox1.Text == "")
            {

                MessageBox.Show("Select a Transaction ID first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                if (comboBox3.Text == "")
                {
                    MessageBox.Show("No service to be processed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (textBox9.Text == vaar2)
                {
                    // MessageBox.Show(vaar2);
                    var dedate = DateTime.Now.ToString("hh");
                    var dedate2 = DateTime.Now.ToString("mm");
                    // MessageBox.Show(dedate);
                    // MessageBox.Show(dedate2);
                    int starttime;
                    string aw = comboBox2.Text;
                    string aw2 = comboBox3.Text;
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

                            if (comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
                            {

                                MessageBox.Show("Please fill the time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                //MessageBox.Show(comboBox12.Items.Count.ToString());
                                int[] arr = new int[cb_stEmp.Items.Count];// for ex, 5 size.
                                int eh = 0;
                                bool found2 = false;
                                bool found = false;
                                for (int i = 0; i < arr.Length; i++)
                                {



                                    arr[i] = eh;
                                    eh = eh + 1;

                                    int[] arr2 = new int[100];
                                    string n = cb_stEmp.Items[arr[i]].ToString();
                                    int m = Convert.ToInt32(n);

                                    for (int a = 0; a < arr2.Length; a++)
                                    {
                                        arr2[a] = m;
                                        m = m + 1;


                                    }
                                    //  MessageBox.Show(found.ToString());

                                    string aa = comboBox2.Text.ToString();//hour sa starttime
                                    int xxx = Convert.ToInt32(aa);
                                    string bb = comboBox3.Text.ToString();//mins sa starttime
                                    int yyy = Convert.ToInt32(bb);
                                    int firstsum;
                                    firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);
                                    textBox7.Text = firstsum.ToString();//AOSDOWIJWQOIDJOIJEWQIOEWQ
                                    label16.Text = firstsum.ToString();
                                    string cc = comboBox5.Text.ToString();//hour sa endtime
                                    int www = Convert.ToInt32(cc);
                                    string dd = comboBox6.Text.ToString();//mins sa endtime      
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
                                    int[] arr3 = new int[cb_stDriver.Items.Count];// for ex, 5 size.
                                    int eh3 = 0;

                                    for (int i = 0; i < arr3.Length; i++)
                                    {

                                        arr3[i] = eh3;
                                        eh3 = eh3 + 1;

                                        int[] arr2 = new int[100];
                                        string n = cb_stDriver.Items[arr3[i]].ToString();
                                        int m = Convert.ToInt32(n);

                                        for (int a = 0; a < arr2.Length; a++)
                                        {
                                            arr2[a] = m;
                                            m = m + 1;

                                        }

                                        string aa = comboBox2.Text.ToString();//hour sa starttime
                                        int xxx = Convert.ToInt32(aa);
                                        string bb = comboBox3.Text.ToString();//mins sa starttime
                                        int yyy = Convert.ToInt32(bb);
                                        int firstsum;
                                        firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

                                        string cc = comboBox5.Text.ToString();//hour sa endtime
                                        int www = Convert.ToInt32(cc);
                                        string dd = comboBox6.Text.ToString();//mins sa endtime      
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

                                    MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox4.Text + "'", conn);
                                    comm2.ExecuteNonQuery();
                                    MySqlDataReader dr = comm2.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        textBox14.Text = dr["FULLNAME"].ToString();//!!!!!!

                                    }
                                    dr.Close();

                                    string s10 = " ";
                                    string a10 = comboBox2.Text + s10 + comboBox3.Text + s10 + comboBox4.Text;
                                    string b10 = comboBox5.Text + s10 + comboBox6.Text + s10 + comboBox7.Text;
                                    MySqlCommand comm = new MySqlCommand("Update dbsystem.tbltrans set StartTime='" + a10 + "'where TransID='" + comboBox1.Text + "'", conn);
                                    comm.ExecuteNonQuery();
                                    MySqlCommand comm10 = new MySqlCommand("Update dbsystem.tbltrans set EndTime='" + b10 + "'where TransID='" + comboBox1.Text + "'", conn);
                                    comm10.ExecuteNonQuery();
                                    MySqlCommand comm3 = new MySqlCommand("Update dbsystem.tbltrans set StartTimeSession='" + comboBox4.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                                    comm3.ExecuteNonQuery();
                                    MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tbltrans set EndTimeSession='" + comboBox7.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                                    comm4.ExecuteNonQuery();
                                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                 //   MessageBox.Show("Transaction Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    tb_emp.Text = null;
                                    tb_driver.Text = null;
                                    cb_stEmp.Text = null;
                                    cb_stDriver.Text = null;
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

                        if (comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
                        {

                            MessageBox.Show("Please fill the time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            //MessageBox.Show(comboBox12.Items.Count.ToString());
                            int[] arr = new int[cb_stEmp.Items.Count];// for ex, 5 size.
                            int eh = 0;
                            bool found2 = false;
                            bool found = false;
                            for (int i = 0; i < arr.Length; i++)
                            {



                                arr[i] = eh;
                                eh = eh + 1;

                                int[] arr2 = new int[100];
                                string n = cb_stEmp.Items[arr[i]].ToString();
                                int m = Convert.ToInt32(n);

                                for (int a = 0; a < arr2.Length; a++)
                                {
                                    arr2[a] = m;
                                    m = m + 1;


                                }
                                //  MessageBox.Show(found.ToString());

                                string aa = comboBox2.Text.ToString();//hour sa starttime
                                int xxx = Convert.ToInt32(aa);
                                string bb = comboBox3.Text.ToString();//mins sa starttime
                                int yyy = Convert.ToInt32(bb);
                                int firstsum;
                                firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);
                                textBox7.Text = firstsum.ToString();
                                label16.Text = firstsum.ToString();
                                string cc = comboBox5.Text.ToString();//hour sa endtime
                                int www = Convert.ToInt32(cc);
                                string dd = comboBox6.Text.ToString();//mins sa endtime      
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
                                int[] arr3 = new int[cb_stDriver.Items.Count];// for ex, 5 size.
                                int eh3 = 0;

                                for (int i = 0; i < arr3.Length; i++)
                                {

                                    arr3[i] = eh3;
                                    eh3 = eh3 + 1;

                                    int[] arr2 = new int[100];
                                    string n = cb_stDriver.Items[arr3[i]].ToString();
                                    int m = Convert.ToInt32(n);

                                    for (int a = 0; a < arr2.Length; a++)
                                    {
                                        arr2[a] = m;
                                        m = m + 1;

                                    }

                                    string aa = comboBox2.Text.ToString();//hour sa starttime
                                    int xxx = Convert.ToInt32(aa);
                                    string bb = comboBox3.Text.ToString();//mins sa starttime
                                    int yyy = Convert.ToInt32(bb);
                                    int firstsum;
                                    firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

                                    string cc = comboBox5.Text.ToString();//hour sa endtime
                                    int www = Convert.ToInt32(cc);
                                    string dd = comboBox6.Text.ToString();//mins sa endtime      
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

                               MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox4.Text + "'", conn);
                                comm2.ExecuteNonQuery();
                                MySqlDataReader dr = comm2.ExecuteReader();
                                if (dr.Read())
                                {
                                    textBox14.Text = dr["FULLNAME"].ToString();

                                }


                                dr.Close();

                                string s10 = " ";
                                string a10 = comboBox2.Text + s10 + comboBox3.Text + s10 + comboBox4.Text;
                                string b10 = comboBox5.Text + s10 + comboBox6.Text + s10 + comboBox7.Text;
                                MySqlCommand comm = new MySqlCommand("Update dbsystem.tbltrans set StartTime='" + a10 + "'where TransID='" + comboBox1.Text + "'", conn);
                                comm.ExecuteNonQuery();
                                MySqlCommand comm10 = new MySqlCommand("Update dbsystem.tbltrans set EndTime='" + b10 + "'where TransID='" + comboBox1.Text + "'", conn);
                                comm10.ExecuteNonQuery();
                                MySqlCommand comm3 = new MySqlCommand("Update dbsystem.tbltrans set StartTimeSession='" + comboBox4.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                                comm3.ExecuteNonQuery();
                                MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tbltrans set EndTimeSession='" + comboBox7.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                                comm4.ExecuteNonQuery();
                                MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //   MessageBox.Show("Transaction Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                tb_emp.Text = null;
                                tb_driver.Text = null;
                                cb_stEmp.Text = null;
                                cb_stDriver.Text = null;
                            }




                        }
                    }



                }
                else
                {//else brace
                    //newvar dedate = DateTime.Now.ToString("hh");
                    //newtextBox2.Text = dedate;

                    if (comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
                    {

                        MessageBox.Show("Please fill the time", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        //MessageBox.Show(comboBox12.Items.Count.ToString());
                        int[] arr = new int[cb_stEmp.Items.Count];// for ex, 5 size.
                        int eh = 0;
                        bool found2 = false;
                        bool found = false;
                        for (int i = 0; i < arr.Length; i++)
                        {



                            arr[i] = eh;
                            eh = eh + 1;

                            int[] arr2 = new int[100];
                            string n = cb_stEmp.Items[arr[i]].ToString();
                            int m = Convert.ToInt32(n);

                            for (int a = 0; a < arr2.Length; a++)
                            {
                                arr2[a] = m;
                                m = m + 1;


                            }
                            //   MessageBox.Show(found.ToString());

                            string aa = comboBox2.Text.ToString();//hour sa starttime
                            int xxx = Convert.ToInt32(aa);
                            string bb = comboBox3.Text.ToString();//mins sa starttime
                            int yyy = Convert.ToInt32(bb);
                            int firstsum;
                            firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);
                            textBox7.Text = firstsum.ToString();
                            label16.Text = firstsum.ToString();
                            string cc = comboBox5.Text.ToString();//hour sa endtime
                            int www = Convert.ToInt32(cc);
                            string dd = comboBox6.Text.ToString();//mins sa endtime      
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
                            int[] arr3 = new int[cb_stDriver.Items.Count];// for ex, 5 size.
                            int eh3 = 0;

                            for (int i = 0; i < arr3.Length; i++)
                            {

                                arr3[i] = eh3;
                                eh3 = eh3 + 1;

                                int[] arr2 = new int[100];
                                string n = cb_stDriver.Items[arr3[i]].ToString();
                                int m = Convert.ToInt32(n);

                                for (int a = 0; a < arr2.Length; a++)
                                {
                                    arr2[a] = m;
                                    m = m + 1;

                                }

                                string aa = comboBox2.Text.ToString();//hour sa starttime
                                int xxx = Convert.ToInt32(aa);
                                string bb = comboBox3.Text.ToString();//mins sa starttime
                                int yyy = Convert.ToInt32(bb);
                                int firstsum;
                                firstsum = Convert.ToInt32(+xxx + "" + yyy+""+zero);

                                string cc = comboBox5.Text.ToString();//hour sa endtime
                                int www = Convert.ToInt32(cc);
                                string dd = comboBox6.Text.ToString();//mins sa endtime      
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

                            MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from dbsystem.tblcstmr where ClientID='" + textBox4.Text + "'", conn);
                            comm2.ExecuteNonQuery();
                            MySqlDataReader dr = comm2.ExecuteReader();
                            if (dr.Read())
                            {
                                textBox14.Text = dr["FULLNAME"].ToString();

                            }


                            dr.Close();

                            string s10 = " ";
                            string a10 = comboBox2.Text + s10 + comboBox3.Text + s10 + comboBox4.Text;
                            string b10 = comboBox5.Text + s10 + comboBox6.Text + s10 + comboBox7.Text;
                            MySqlCommand comm = new MySqlCommand("Update dbsystem.tbltrans set StartTime='" + a10 + "'where TransID='" + comboBox1.Text + "'", conn);
                            comm.ExecuteNonQuery();
                            MySqlCommand comm10 = new MySqlCommand("Update dbsystem.tbltrans set EndTime='" + b10 + "'where TransID='" + comboBox1.Text + "'", conn);
                            comm10.ExecuteNonQuery();
                            MySqlCommand comm3 = new MySqlCommand("Update dbsystem.tbltrans set StartTimeSession='" + comboBox4.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                            comm3.ExecuteNonQuery();
                            MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tbltrans set EndTimeSession='" + comboBox7.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                            comm4.ExecuteNonQuery();
                            MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //   MessageBox.Show("Transaction Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            tb_emp.Text = null;
                            tb_driver.Text = null;
                            cb_stEmp.Text = null;
                            cb_stDriver.Text = null;
                        }




                    }

                }
           
               /* string s10 = " ";
                string a10 = comboBox2.Text + s10 + comboBox3.Text + s10 + comboBox4.Text;
                string b10 = comboBox5.Text + s10 + comboBox6.Text + s10 + comboBox7.Text;
                MySqlCommand comm = new MySqlCommand("Update dbsystem.tbltrans set StartTime='" + a10 + "'where TransID='" + comboBox1.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlCommand comm2 = new MySqlCommand("Update dbsystem.tbltrans set EndTime='" + b10 + "'where TransID='" + comboBox1.Text + "'", conn);
                comm2.ExecuteNonQuery();
                MySqlCommand comm3 = new MySqlCommand("Update dbsystem.tbltrans set StartTimeSession='" + comboBox4.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                comm3.ExecuteNonQuery();
                MySqlCommand comm4 = new MySqlCommand("Update dbsystem.tbltrans set EndTimeSession='" + comboBox7.Text + "'where TransID='" + comboBox1.Text + "'", conn);
                comm4.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Text = comboBox4.Text;

            if (comboBox2.Text == "11" && comboBox4.Text == "AM")
            {

                comboBox7.Text = "PM";

            }
            if (comboBox2.Text == "11" && comboBox4.Text == "PM")
            {
                comboBox7.Text = "AM";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            int yow=Convert.ToInt32(comboBox6.Text);
            if (yow >= 30)
            {


                if (comboBox8.Text == "30")
                {
                    string a = comboBox6.Text;
                    int x = Convert.ToInt32(a);
                    string b = comboBox8.Text;
                    int y = Convert.ToInt32(b);
                    int xy = x - y;


                    comboBox6.Text = xy.ToString() ;
                    string yes = comboBox5.Text;
                    int yaya = Convert.ToInt32(yes);
                    yaya += 1;
                    comboBox5.Text = yaya.ToString() ;
                    if (comboBox5.Text == "12")
                    {

                        comboBox7.Text = "PM";
                    }

                }

                if (comboBox8.Text == "60")
                {
                   
                    string ye = comboBox5.Text;
                    int yo = Convert.ToInt32(ye);
                    string h = comboBox5.Text;
                    int g = Convert.ToInt32(h);
                    if (g >= 12)
                    {
                        comboBox5.Text = "1";
                        comboBox7.Text = "PM";
                        
                    }
                    else
                    {
                        yo += 1;
                    }

                   
                }

                label12.Text = "150";
            }
            else
            {
                if (comboBox8.Text == "60")
                {

                    string ye = comboBox5.Text;
                    int yo = Convert.ToInt32(ye);
                    string h = comboBox5.Text;
                    int g = Convert.ToInt32(h);
                    if (g >= 12)
                    {
                        comboBox5.Text = "1";
                        comboBox7.Text = "PM";

                    }
                    else
                    {
                        yo += 1;
                    }


                }
                else
                {
                    string hmm = comboBox8.Text;
                    int hmmm = Convert.ToInt32(hmm);
                    string haa = comboBox6.Text;
                    int haaa = Convert.ToInt32(haa);
                    int haya = haaa + hmmm;

                    int yeyeye = haya;
                    comboBox6.Text = yeyeye.ToString();
                }
                label12.Text = "150";

            }

            if (comboBox8.Text == "60")
            {

                if (comboBox5.Text == "12")
                {
                    comboBox5.Text = "1";
                    comboBox7.Text = "PM";

                }
                else
                {

                    string hay = comboBox5.Text;
                    int hahay = Convert.ToInt32(hay);

                    hahay += 1;

                    comboBox5.Text = hahay.ToString();
                    label12.Text = "200";
                    comboBox7.Text = "PM";
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
            label10.Visible = false;
            comboBox8.Visible = false;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true; 
            comboBox5.Visible = true ;
            comboBox6.Visible = true;
            comboBox7.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = true;
            label10.Visible = true;
            comboBox8.Visible = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)

        {
            cb_stEmp.Items.Clear();
            cb_stEmp.Refresh();
            cb_stDriver.Items.Clear();
            cb_stDriver.Refresh();
            var vavar = dateTimePicker1.Value.Date;
            String vavavar = vavar.ToString("MM/dd/yyyy");
            //  DateTime nana = vavavar.ToString();
            //   string aw = vavavar;
            //  MessageBox.Show(aw);
            textBox9.Text = vavavar;

            MySqlConnection conn6 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn6.Open();
            MySqlCommand comm6 = new MySqlCommand("Select st from dbsystem.tblTrans where DateOfService='" + textBox9.Text + "'and Assignedemp='" + tb_emp.Text + "'", conn6);
            MySqlDataReader dr6 = comm6.ExecuteReader();

            while (dr6.Read())
            {
                if (!cb_stEmp.Items.Contains(dr6["st"].ToString()))
                {
                    cb_stEmp.Items.Add(dr6["st"].ToString());

                }


            }
            cb_stEmp.Sorted = true;
            cb_stEmp.Refresh();
            dr6.Close();

            
           MySqlCommand comm7 = new MySqlCommand("Select st from dbsystem.tblTrans where DateOfService='" + textBox9.Text + "'and AssignedDriver='" + tb_driver.Text + "'", conn6);
           MySqlDataReader dr7 = comm7.ExecuteReader();

           while (dr7.Read())
           {
               if (!cb_stDriver.Items.Contains(dr7["st"].ToString()))
               {
                   cb_stDriver.Items.Add(dr7["st"].ToString());

               }

           }
           cb_stDriver.Sorted = true;
           cb_stDriver.Refresh();
           dr7.Close();

           conn6.Close();
           conn6.Dispose();
        }

        private void tb_emp_TextChanged(object sender, EventArgs e)
        {
            /*
            MySqlConnection conn6 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn6.Open();
            MySqlCommand comm6 = new MySqlCommand("Select st from dbsystem.tblTrans where DateOfService='" + textBox9.Text + "'and Assignedemp='" + tb_emp.Text + "'", conn6);
            MySqlDataReader dr6 = comm6.ExecuteReader();

            while (dr6.Read())
            {
                if (!cb_stEmp.Items.Contains(dr6["st"].ToString()))
                {
                    cb_stEmp.Items.Add(dr6["st"].ToString());

                }

                
            }
            cb_stEmp.Sorted = true;
            cb_stEmp.Refresh();*/
        }
    }
}
