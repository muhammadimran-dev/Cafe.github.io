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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            runQuery();
        }
        private void runQuery()
        {

            string username = user.Text;
            string password = pass.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Incorrect Username or Password");
                return;
            }
            string query = "Select * From user";
            string sqlConn = "datasource=127.0.0.1;port=3306;username=root;password=;database=CDMS";

            MySqlConnection dataConn = new MySqlConnection(sqlConn);
            MySqlCommand cmdDatabase = new MySqlCommand(query, dataConn);
            try
            {
                dataConn.Open();
                MySqlDataReader sqlReader = cmdDatabase.ExecuteReader();
                bool flag = false;
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        //MessageBox.Show(sqlReader.GetString(3));
                        if (sqlReader.GetString(3) == username && sqlReader.GetString(4) == password)
                        {
                            flag = true;
                            OrderItems obj1 = new OrderItems();
                            obj1.Show();
                            this.Hide();
                        }
                    }
                    if (flag == false)
                    {
                        MessageBox.Show("Incorrect Username or Password");
                        return;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query Error", e.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registerform obj1 = new registerform();
            obj1.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
