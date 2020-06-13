using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tea_and_Coffee
{
    public partial class registerform : Form
    {
        public registerform()
        {
            InitializeComponent();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            runQuery();
        }
        private void runQuery()
        {

            string n = name.Text;
            string num = phone.Text;
            string em = email.Text;
            string pass = password.Text;
            if (n == "" || num == "" || em == "" || pass == "")
            {
                MessageBox.Show("Incorrect Username or Password");
                return;
            }
            string query = "Insert into user(name, username, password, phone) values(@name, @username, @password, @phone)";
            string sqlConn1 = "datasource=127.0.0.1;port=3306;username=root;password=;database=CDMS";
            string sqlConn = "Server=localhost;database=CDMS;UID=root;pwd=";
            MySqlConnection dataConn = new MySqlConnection(sqlConn);
            dataConn.Open();
            MySqlCommand cmdDatabase;
            try
            {

                cmdDatabase = dataConn.CreateCommand();
                cmdDatabase.CommandText = "Insert into user(ID,name, phone, username, password) values(@id,@name, @phone, @username, @password)";
                cmdDatabase.Parameters.AddWithValue("@id", "");
                cmdDatabase.Parameters.AddWithValue("@name", name.Text);
                cmdDatabase.Parameters.AddWithValue("@username", email.Text);
                cmdDatabase.Parameters.AddWithValue("@password", password.Text);
                cmdDatabase.Parameters.AddWithValue("@phone", phone.Text);
                cmdDatabase.ExecuteNonQuery();
                dataConn.Close();
                MessageBox.Show("Inserted");
                Form1 obj1 = new Form1();
                obj1.Show();
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error", e.Message);
            }

        }
    }
}
