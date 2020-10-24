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
    public partial class Inventory : Form
    {

        //////////materials//////////////////////////////////////
        //meterial re order veriables

        int reOrderCopperWire = 75;
        int reOrderSpringSteelWire = 0;
        int reOrderPolypropoline = 50;
        int reOrderMasterBatch = 1;
        int reOrderBlowupChemical = 10;
        int reOrderTapOrigng = 2000;
        int reOrderTPESeal = 2;
        int reOrderTapNails = 1000;
        int reOrderTapBox = 25;
        // // // // // // // // // //

        //meteril minimum size
        int curralert;
        string amtName;
        string mtName;
        int MinimumCopperWire = 25;
        int MinimumSpringSteelWire = 0;
        int MinimumPolypropoline = 50;
        int MinimumMasterBatch = 0;
        int MinimumBlowupChemical = 0;
        int MinimumTapOrigng = 1000;
        int MinimumTPESeal = 1;
        int MinimumTapNails = 200;
        int MinimumTapBox = 10;
        // // // // // // // // // //

        string mtquantity;
        int currmt_qun;
        int upadd;
        int used;
        int currquntity;
        string currnt_date;
        ///////////////////////////////

        string product_id = "";
        string custormer_id="";
        string order_stdate = "";
        string order_enddate = "";
        string product_uprice = "";
        int product_unitprice = 0;
        string product_netprice = "";
        int product_totleprice = 0;

        int product_qunty = 0;

        //////////////////////////////////

/////////////////////////////////material////////////////////////////////////////////////////////////////////////////////




        public Inventory()
        {
            InitializeComponent();
            FillcomboMaterial();
            Fillcombo_customers();
            Fillcombo_suppler();
            FillComboOrders();
            Fillcombo_order_customers();
        }


        void FillcomboMaterial()
        {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial;";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string mtName = MyReader.GetString("meterial_name");
                    com_metirial.Items.Add(mtName);
                    string umtName = MyReader.GetString("meterial_name");
                    cmb_m_update.Items.Add(umtName);
                    string dmtName = MyReader.GetString("meterial_name");
                    cmb_m_delete.Items.Add(dmtName);

                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        void Fillcombo_order_customers()
        {

            string con = "server=localhost;user id=root;password=;database=youken_springs";
            string quarry = "select * from youken_springs.customers;";
            MySqlConnection ConDataBase = new MySqlConnection(con);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string cuName = MyReader.GetString("customer_name");
                    cmb_inv_order_customer.Items.Add(cuName);



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        void alert()
        {
            try
            {
                string Constring = "datasource=localhost;port=3306;username=root;password=";
                string quarry = "select * from youken_springs.meterial;";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
                MySqlDataReader MyReader;

                try
                {

                    ConDataBase.Open();
                    MyReader = cmdDataBase.ExecuteReader();


                    while (MyReader.Read())
                    {

                        curralert = MyReader.GetInt32("quantity");
                        string amtName = MyReader.GetString("meterial_name");
                        if (amtName == "Copper Wire")
                        {
                            if ((MinimumCopperWire <= curralert) && (curralert <= reOrderCopperWire))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumCopperWire)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }///////1

                        if (amtName == "Spring steel wire")
                        {
                            if ((MinimumSpringSteelWire <= curralert) && (curralert <= reOrderSpringSteelWire))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumSpringSteelWire)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }/////////2
                        if (amtName == "Polypropoline")
                        {
                            if ((MinimumPolypropoline <= curralert) && (curralert <= reOrderPolypropoline))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);


                            }
                            else if (curralert <= MinimumPolypropoline)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }/////3

                        if (amtName == "Master-batch")
                        {
                            if ((MinimumMasterBatch <= curralert) && (curralert <= reOrderMasterBatch))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumMasterBatch)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }/////////4

                        if (amtName == "Blowup-chemical")
                        {
                            if ((MinimumBlowupChemical <= curralert) && (curralert <= reOrderBlowupChemical))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumBlowupChemical)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }//////////5

                        if (amtName == "Tap-o-rigng")
                        {
                            if ((MinimumTapOrigng <= curralert) && (curralert <= reOrderTapOrigng))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumTapOrigng)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }////////////6

                        if (amtName == "TPE-Seal")
                        {
                            if ((MinimumTPESeal <= curralert) && (curralert <= reOrderTPESeal))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumTPESeal)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }/////////7

                        if (amtName == "Tap-nails")
                        {
                            if ((MinimumTapNails <= curralert) && (curralert <= reOrderTapNails))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumTapNails)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }/////////8

                        if (amtName == "Tap-box")
                        {
                            if ((MinimumTapBox <= curralert) && (curralert <= reOrderTapBox))
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!!", "Critical Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                reOrderPolypropoline = 75;

                            }
                            else if (curralert <= MinimumTapBox)
                            {
                                MessageBox.Show(amtName + "" + " is very low.Please regenarate the stock!! ASAP ASAP", "Important Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }/////////9



                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }




            }
            catch (Exception ed) { MessageBox.Show(ed.Message); }

        }


        private void panel_billing_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_material_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'youken_springsDataSet.meterial_histry' table. You can move, or remove it, as needed.
           // this.meterial_histryTableAdapter.Fill(this.youken_springsDataSet.meterial_histry);

           // this.reportViewer1.RefreshReport();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel_material.Visible = true;
            panel_product.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel_material.Visible = true;
            panel_product.Visible = true;
            panel_billing.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel_material.Visible = true;
            alert();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Main f2 = new Main();
            f2.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel_product_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel_material.Visible =false;
            panel_product.Visible = false;
            panel_billing.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel_material.Visible = false;
            panel_product.Visible = false;
            panel_billing.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_material.Visible = false;
            panel_product.Visible = false;
            panel_billing.Visible = false;
        }

        private void btn_m_new_update_Click(object sender, EventArgs e)
        {
            if (cmb_m_update.Text != "")
            {
                if (txt_m_up_name.Text != "")
                {

                    string Constring = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection ConDataBase = new MySqlConnection(Constring);

                    string quarry = "update youken_springs.meterial set meterial_name= @meterial_name   where meterial_id =@id;";
                    MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                    cmdDataBase.Parameters.AddWithValue("@id", lbl_m_u_id.Text);
                    cmdDataBase.Parameters.AddWithValue("@meterial_name", txt_m_up_name.Text);
                    try
                    {

                        ConDataBase.Open();
                        cmdDataBase.ExecuteNonQuery();
                        MessageBox.Show("Name updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Messege",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("Plaese enter the new material name!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Plaese select the material!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btn_m_addnew_Click(object sender, EventArgs e)
        {
            if (txt_m_new_name.Text != "")
            {
                if (txt_m_new_quantity.Text != "")
                {

                    string Constring = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection ConDataBase = new MySqlConnection(Constring);

                    string quarry = "insert into youken_springs.meterial(meterial_name,quantity ) Values(@meterial_name,@quantity);";
                    MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                    cmdDataBase.Parameters.AddWithValue("@meterial_name", txt_m_new_name.Text);
                    cmdDataBase.Parameters.AddWithValue("@quantity", txt_m_new_quantity.Text);
                    try
                    {

                        ConDataBase.Open();
                        cmdDataBase.ExecuteNonQuery();
                        MessageBox.Show("Sucessfully Add New Metirial!!", "",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Messege",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("Plaese enter the quantity!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Plaese enter the material name!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btn_m_delete_Click(object sender, EventArgs e)
        {


            if (cmb_m_delete.Text != "")
            {
                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                string quarry = "delete from youken_springs.meterial where meterial_id =@id;";
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                cmdDataBase.Parameters.AddWithValue("@id", lbl_m_d_id.Text);

                try
                {

                    ConDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Meterial Deleted!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Plaese select the material!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmb_m_update_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial where meterial_name ='" + cmb_m_update.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string umtName = MyReader.GetString("meterial_name");
                    txt_m_up_name.Text = umtName;
                    string umid = MyReader.GetInt32("meterial_id").ToString();
                    lbl_m_u_id.Text = umid;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmb_m_delete_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial where meterial_name ='" + cmb_m_delete.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string dmid = MyReader.GetInt32("meterial_id").ToString();
                    lbl_m_d_id.Text = dmid;
                    string dmtName = MyReader.GetString("meterial_name");
                    lbl_m_name_delete.Text = dmtName;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void com_metirial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial where meterial_name ='" + com_metirial.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();



                while (MyReader.Read())
                {

                    mtName = MyReader.GetString("meterial_name");
                    mtquantity = MyReader.GetInt32("quantity").ToString();

                    string mid = MyReader.GetInt32("meterial_id").ToString();
                    lbl_m_name.Text = mtName;
                    lbl_currnt_stock.Text = mtquantity;
                    lbl_mid.Text = mid;

                    currmt_qun = int.Parse(mtquantity);


                    //try { mtquantity = MyReader.GetInt32("quantity").ToString(); }
                    //catch (Exception ex) { MessageBox.Show(ex.Message); }
                    //= int.Parse(lbl_currnt_stock.Text);



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_m_update_Click(object sender, EventArgs e)
        {

            if (com_metirial.Text != "")
            {
                if (txt_m_stocke_up.Text != "")
                {
                    if (!Int32.TryParse(txt_m_stocke_up.Text, out upadd))
                    {

                        MessageBox.Show("Please add valid deatiles", "Error Messege",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        string Constring = "datasource=localhost;port=3306;username=root;password=";


                        if (upadd > 0)
                        {
                            try
                            {
                                int currquntity;
                                if (!Int32.TryParse(lbl_currnt_stock.Text, out currquntity))
                                { }

                                if (!Int32.TryParse(txt_m_stocke_up.Text, out upadd))
                                {
                                    // MessageBox.Show("Please add valid deatiles", "Error Messege",
                                    //   MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }//txt_m_stocke_up

                                string newquntity = (currquntity + upadd).ToString();
                                lbl_currnt_stock.Text = newquntity;

                                DateTime today_date = DateTime.Now;
                                currnt_date = today_date.ToShortDateString();


                            }

                            catch (Exception er)
                            {
                                MessageBox.Show(er.Message, "Error Messege",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                            MySqlConnection ConDataBase = new MySqlConnection(Constring);

                            string quarry = "update youken_springs.meterial set quantity= @quantity   where meterial_id =@id; insert into youken_springs.meterial_histry(meterial_id,meterial_name,date,update_qun) Values (@meterial_id,@meterial_name,@date,@update_qun);";
                            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                            cmdDataBase.Parameters.AddWithValue("@id", lbl_mid.Text);
                            cmdDataBase.Parameters.AddWithValue("@quantity", lbl_currnt_stock.Text);

                            cmdDataBase.Parameters.AddWithValue("@meterial_id", lbl_mid.Text);
                            cmdDataBase.Parameters.AddWithValue("@meterial_name", lbl_m_name.Text);
                            cmdDataBase.Parameters.AddWithValue("@date", currnt_date);
                            cmdDataBase.Parameters.AddWithValue("@update_qun", txt_m_stocke_up.Text);

                            try
                            {

                                ConDataBase.Open();
                                cmdDataBase.ExecuteNonQuery();
                                MessageBox.Show("updated!!", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error Messege",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                        else
                        {
                            MessageBox.Show("Plaese add valid details!!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }


                    }

                }


                else
                {
                    MessageBox.Show("Plaese enter the new stock quantity!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Plaese select the material!!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
            

        private void btn_m_used_Click(object sender, EventArgs e)
        {


            if (com_metirial.Text != "")
            {
                if (txt_m_usd_quntity.Text != "")
                {

                    if (!Int32.TryParse(txt_m_usd_quntity.Text, out used))
                    {

                        MessageBox.Show("Please add valid deatiles", "Error Messege",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {

                        string Constring = "datasource=localhost;port=3306;username=root;password=";

                        if ((used > 0) && (currmt_qun >= used))
                        {
                            try
                            {

                                currmt_qun = int.Parse(lbl_currnt_stock.Text);
                                // int currquntity;
                                if (!Int32.TryParse(lbl_currnt_stock.Text, out currquntity))
                                { }
                                // int used;
                                if (!Int32.TryParse(txt_m_usd_quntity.Text, out used))
                                { }
                                string usequntity = (currquntity - used).ToString();
                                lbl_currnt_stock.Text = usequntity;
                                currmt_qun = int.Parse(lbl_currnt_stock.Text);

                                DateTime today_date = DateTime.Now;
                                currnt_date = today_date.ToShortDateString();

                            }

                            catch (Exception er) { MessageBox.Show(er.Message); }



                            MySqlConnection ConDataBase = new MySqlConnection(Constring);

                            string quarry = "update youken_springs.meterial set quantity= @quantity where meterial_id =@id;insert into youken_springs.meterial_histry(meterial_id,meterial_name,date,used_qun) Values (@meterial_id,@meterial_name,@date,@used_qun);";
                            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                            cmdDataBase.Parameters.AddWithValue("@id", lbl_mid.Text);
                            cmdDataBase.Parameters.AddWithValue("@quantity", lbl_currnt_stock.Text);

                            cmdDataBase.Parameters.AddWithValue("@meterial_id", lbl_mid.Text);
                            cmdDataBase.Parameters.AddWithValue("@meterial_name", lbl_m_name.Text);
                            cmdDataBase.Parameters.AddWithValue("@date", currnt_date);
                            cmdDataBase.Parameters.AddWithValue("@used_qun", txt_m_usd_quntity.Text);
                          
                            


                            try
                            {

                                ConDataBase.Open();
                                cmdDataBase.ExecuteNonQuery();
                                MessageBox.Show("updated!!", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error Messege",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Plaese add valid details!!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Please enter the today used quantity!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Plaese select the material!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }



///////////////////////////////////////////////Billing//////////////////////////////////////////////////////////////


        void Fillcombo_customers()
        {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.customers;";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string cuName = MyReader.GetString("customer_name");
                    cmb_b_p_custeme.Items.Add(cuName);



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void Fillcombo_suppler()
        {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.suplier;";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string suName = MyReader.GetString("suplier_name");
                    cmb_b_m_suppler.Items.Add(suName);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void cmb_b_p_custeme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.customers where customer_name ='" + cmb_b_p_custeme.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();



                while (MyReader.Read())
                {

                    string cuName = MyReader.GetString("customer_name");


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmb_b_p_custeme.Text != "")
            {
                invoice f2 = new invoice();
                f2.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Plaese select the customer name!!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmb_b_p_custeme.Text != "")
            {
                Quotation f2 = new Quotation();
                f2.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Plaese select the customer name!!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cmb_b_p_custeme.Text != "")
            {

            }
            else
            {
                MessageBox.Show("Plaese select the customer name!!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_b_p_pinvoice_Click(object sender, EventArgs e)
        {
            if (cmb_b_p_custeme.Text != "")
            {

            }
            else
            {
                MessageBox.Show("Plaese select the customer name!!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmb_b_m_suppler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.suplier where suplier_name='" + cmb_b_m_suppler.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();



                while (MyReader.Read())
                {

                    string suName = MyReader.GetString("suplier_name");


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_b_m_quotation_Click(object sender, EventArgs e)
        {
            if (cmb_b_m_suppler.Text != "")
            {
                Purchase f2 = new Purchase();
                f2.ShowDialog();
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                MessageBox.Show("Plaese select the suppler name!!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_b_m_gnr_Click(object sender, EventArgs e)
        {
            if (cmb_b_m_suppler.Text != "")
            {

            }
            else
            {
                MessageBox.Show("Plaese select the suppler name!!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


////////////////////////////////////////////////////////////order///////////////////////////////////////

        void FillComboOrders()
        {
            string con = "datasource=localhost;port=3306;username=root;password=";
            string query = "select * from youken_springs.products;";
            MySqlConnection ConDataBase = new MySqlConnection(con);
            MySqlCommand cmdDataBase = new MySqlCommand(query, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();

                while (MyReader.Read())
                {

                    string prname = MyReader.GetString("name");
                    cmb_Product.Items.Add(prname);
                }

                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmb_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string query = "select * from youken_springs.products where name ='" + cmb_Product.Text + "';";
          
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(query, ConDataBase);
           
            MySqlDataReader MyReader;
           
            try
            {
               ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();
             

                while (MyReader.Read())
                {


                  
                    product_id = MyReader.GetString("product_id");
                 
                    product_uprice = MyReader.GetInt32("unit_price").ToString();
                   // txt_p_custemer.Text = product_uprice;

                }

              
                ConDataBase.Close();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dmp_p_enddate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_p_quntity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_inv_met_rep_Click(object sender, EventArgs e)
        {
            pan_reporte.Visible = true;
            panel_billing.Visible = true;
            panel_product.Visible = true;


            // TODO: This line of code loads data into the 'youken_springsDataSet.meterial_histry' table. You can move, or remove it, as needed.
            this.meterial_histryTableAdapter.Fill(this.youken_springsDataSet.meterial_histry);

            this.reportViewer1.RefreshReport();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pan_reporte.Visible = false;
            panel_material.Visible = true;
            panel_billing.Visible = false;
            panel_product.Visible = false;

        }

        private void txt_p_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_inv_order_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string query = "select * from youken_springs.customers where customer_name ='" + cmb_inv_order_customer.Text + "';";

            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(query, ConDataBase);

            MySqlDataReader MyReader;

            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {



                    custormer_id = MyReader.GetString("cus_id");
                    

                }


                ConDataBase.Close();
                lbl_rs.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_p_custemer_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {



            if ((txt_p_custemer.Text != "") && (cmb_inv_order_customer.Text != "") && (cmb_Product.Text != ""))
            {

                if (!Int32.TryParse(txt_p_custemer.Text, out product_unitprice))
                {

                    MessageBox.Show("Please add valid deatiles", "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    try
                    {

                        order_stdate = dmp_P_stardate.Value.ToShortDateString();
                        order_enddate = dmp_p_enddate.Value.ToShortDateString();

                        product_qunty = int.Parse(txt_p_custemer.Text);

                        product_unitprice = int.Parse(product_uprice);

                        product_totleprice = product_qunty * product_unitprice;

                        lbl_p_tprize.Text = product_totleprice.ToString();
                        lbl_rs.Visible = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Messege",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        lbl_p_duration.Text = Convert.ToString((dmp_p_enddate.Value - dmp_P_stardate.Value).TotalDays) + "Days";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                    string Constring = "datasource=localhost;port=3306;username=root;password=";
                    MySqlConnection ConDataBase = new MySqlConnection(Constring);

                    string quarry = "insert into youken_springs.orders(product_id,order_date,cus_id,supply_date,worth,quantity) Values(@product_id,@order_date,@cus_id,@supply_date,@worth,@quantity );";
                    MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                    cmdDataBase.Parameters.AddWithValue("@product_id", product_id);
                    cmdDataBase.Parameters.AddWithValue("@order_date", order_stdate);
                    cmdDataBase.Parameters.AddWithValue("@cus_id", custormer_id);
                    cmdDataBase.Parameters.AddWithValue("@supply_date", order_enddate);
                    cmdDataBase.Parameters.AddWithValue("@worth", lbl_p_tprize.Text);
                    cmdDataBase.Parameters.AddWithValue("@quantity", txt_p_custemer.Text);

                    try
                    {

                        ConDataBase.Open();
                        cmdDataBase.ExecuteNonQuery();
                        MessageBox.Show("Sucessfully Add Order Details", "",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_rs.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Messege",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
               
                }

            }

            else {
                MessageBox.Show("Please Enter Order Details", "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
            

        }

 



    }
}
