using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimeTable
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.login = LOGINtextBox.Text;
            Program.password = PASSWORDtextBox.Text;
            Program.strcon = "user id=" + Program.login + ";password=" + Program.password + ";server=MOZZG\\sqlexpress;Initial Catalog=ForTimeTable;Trusted_Connection=true;connection timeout=30";
            SqlConnection constr = new SqlConnection(Program.strcon);
            try
            {
                constr.Open();
                constr.Close();
                Visible = false;
                MainForm f = new MainForm();
                f.Show();
            }
            catch
            {
                MessageBox.Show("Failed to connect to data source");
            }
        }
    }
}
