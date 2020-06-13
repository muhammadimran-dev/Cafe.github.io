using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tea_and_Coffee
{
    public partial class OrderPlace : Form
    {
        public OrderPlace()
        {
            InitializeComponent();
        }

        private void Orderbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Succesfully Placed.");
            OrderItems obj1 = new OrderItems();
            obj1.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }
    }
}
