using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        string usern = "TwisterYouken";
        string pass = "Youken123";



        public Login()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
        } 

        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_add_Click(object sender, EventArgs e)
        {

        }

        private void txt_add2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_flname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void txt_d_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_d_age_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_d_occupy_Click(object sender, EventArgs e)
        {

        }

        private void pan_reg1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_em_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nationalty_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_region_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Leave_Click(object sender, EventArgs e)
        {

        }

        private void btn_addcontact_Click(object sender, EventArgs e)
        {

        }

        private void panel_product_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if ((User_name.Text != "") && (Password.Text != ""))
            {
                if ((User_name.Text != "") && (User_name.Text == usern))
                {

                    if ((Password.Text != "") && (Password.Text == pass))
                    {

                        Main f2 = new Main();
                        f2.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password!!", "Error Messege",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Invalid User Name!!", "Error Messege",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter User Name and Password!!", "Error Messege",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void User_name_TextChanged(object sender, EventArgs e)
        {

        }


       
    }
}
