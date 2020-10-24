using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            HRM f2 = new HRM();
            f2.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Inventory f2 = new Inventory();
            f2.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login f2 = new Login();
            f2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
