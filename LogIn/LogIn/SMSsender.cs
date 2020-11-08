using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
namespace LogIn
{
    public partial class SMSsender : Form
    {
        public SMSsender()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url= "http://smsc.vianett.no/v3/send.ashx?"+
                        "src="+textBox3.Text+"&"+
                        "dst=+"+textBox3.Text+"&"+
                        "msg="+System.Web.HttpUtility.UrlEncode(textBox4.Text,System.Text.Encoding.GetEncoding("ISO-8859-1"))+"&"+
                        "username="+System.Web.HttpUtility.UrlEncode(textBox1.Text)+"&"+
                        "password="+System.Web.HttpUtility.UrlEncode(textBox2.Text);
                        string result=client.DownloadString(url);

                if(result.Contains("OK")){
                                  MessageBox.Show("Your message has been successfully sent","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        }else{
                        MessageBox.Show("Message Failed","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        

        }

        private void SMSsender_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + textBox3.Text + "&" +
                        "dst=+" + textBox3.Text + "&" +
                        "msg=" + System.Web.HttpUtility.UrlEncode("You have a scheduled service for today, please text the no. 09153250308 to confirm your schedule for today, thank you", System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                        "username=" + System.Web.HttpUtility.UrlEncode(textBox1.Text) + "&" +
                        "password=" + System.Web.HttpUtility.UrlEncode(textBox2.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
