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
    public partial class Userslog : Form
    {
        public Userslog()
        {
            InitializeComponent();
        }

        private void Userslog_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select userslogin.UserLogNumber,userslogin.Username,userslogin.TimeIn,userslogout.Timeout from dbsystem.userslogin inner join dbsystem.userslogout on userslogin.UserLogNumber=userslogout.UserLogNumber",conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
