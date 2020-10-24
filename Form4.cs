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
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Profile : Form
    {
        string e_id = "";
        
        public Profile()
        {
            InitializeComponent();
            Fillcomboemployee();
        }

        void Fillcomboemployee()
        {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.employee;";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string mtName = MyReader.GetString("e_id");
                    comboBox4.Items.Add(mtName);

                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWhildCard = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord, ref matchWhildCard,
                ref matchSoundLike, ref nmatchAllForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida, ref matchDiactitics,
                ref matchAlefHamza, ref matchControl);
           

        }




        private void btn_hrm_res_resignation_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                object fileName = open.FileName;
                object readOnly = true;
                object isVisible = true;
                object missing = System.Reflection.Missing.Value;

                wordApp.Visible = true;
                Word.Document newDoc = wordApp.Documents.Open(ref fileName, ref missing, ref readOnly,
                                                              ref missing, ref missing, ref missing,
                                                              ref missing, ref missing, ref missing,
                                                              ref missing, ref missing, ref isVisible);

                newDoc.Activate();
                this.FindAndReplace(wordApp, "<name>", txt_flname.Text);
                this.FindAndReplace(wordApp, "<address>", lbl_fullAdd.Text);
                this.FindAndReplace(wordApp, "<join_date>", txt_joinDate.Text);
                this.FindAndReplace(wordApp, "<position>", txt_position.Text);
                this.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());

            }
        }

        private void btn_hrm_res_backhrm_Click(object sender, EventArgs e)
        {
            HRM f2 = new HRM();
            f2.ShowDialog();
            this.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.employee where e_id ='" + comboBox4.Text + "';";
            string quarry2 = "select * from youken_springs.job where e_id ='" + comboBox4.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlConnection ConDataBase2 = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlCommand cmdDataBase2 = new MySqlCommand(quarry2, ConDataBase2);
            MySqlDataReader MyReader;
            MySqlDataReader MyReader2;
           
            
            
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();

              /* IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                 DateTime join_date = DateTime.ParseExact(txt_joinDate.Text, "dd/MM/yyyy", theCultureInfo);
                 DateTime today = DateTime.Now;
                 txt_wkdduration.Text = ((today - join_date).TotalDays).ToString();*/

               //DateTime date = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null)theCultureInfo
                while (MyReader.Read())
                {


                    txt_flname.Text = MyReader.GetString("e_full_name");
                    txt_add1.Text = MyReader.GetString("address_line1");
                    txt_add2.Text = MyReader.GetString("address_line2");
                    txt_addCity.Text = MyReader.GetString("city");
                    // txt_sal.Text = (MyReader["salary"].ToString());
                    lbl_em_id.Text = MyReader.GetUInt32("e_id").ToString();
                    lbl_pro_em_id.Text = MyReader.GetUInt32("e_id").ToString();
                    e_id = lbl_pro_em_id.Text;

                    lbl_fullAdd.Text = txt_add1.Text +","+"" + txt_add2.Text +","+""+ txt_addCity.Text;

                }


                ConDataBase.Close();
                ConDataBase2.Open();
                MyReader2 = cmdDataBase2.ExecuteReader();

                while (MyReader2.Read())
                {
                    txt_joinDate.Text = MyReader2.GetString("join_date");
                    txt_position.Text = MyReader2.GetString("designation");

                }
                ConDataBase2.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

          


        }

        private void btn_hrm_res__Click(object sender, EventArgs e)
        {
            Main f2 = new Main();
            f2.ShowDialog();
            this.Close();
        }

        private void btn_hrm_more_detail_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {


                pnl_hrm_pro_detail.Visible = true;


                btn_pro_3.Visible = false;
                btn_pro_6.Visible = false;
                btn_pro_7.Visible = false;
                btn_pro_14.Visible = false;
                btn_pro_15.Visible = false;
                btn_pro_16.Visible = false;



                string Constring = "datasource=localhost;port=3306;username=root;password=";

                string query = "select * from youken_springs.employee where e_id ='" + lbl_pro_em_id.Text + "';";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);
                MySqlConnection ConDataBase2 = new MySqlConnection(Constring);
                MySqlCommand cmdDataBase = new MySqlCommand(query, ConDataBase);
                MySqlDataReader MyReader;

                try
                {
                    ConDataBase.Open();
                    MyReader = cmdDataBase.ExecuteReader();


                    while (MyReader.Read())
                    {


                        // txt_p_name.Text = MyReader.GetString("name");

                        txt_pro_em_name.Text = MyReader.GetString("e_full_name");
                        txt_pro_nameIn.Text = MyReader.GetString("name_in_initials");
                        txt_pro_sex.Text = MyReader.GetString("sex");
                        txt_pro_bldGroup.Text = MyReader.GetString("blood_group");
                        txt_pro_dob.Text = MyReader.GetString("DOB");
                        txt_pro_e_age.Text = MyReader.GetString("age");
                        txt_pro_religion.Text = MyReader.GetString("religion");
                        txt_pro_nationalty.Text = MyReader.GetString("nationality");
                        txt_pro_medifit.Text = MyReader.GetString("medical_fitness");
                        txt_pro_marituals.Text = MyReader.GetString("maritual_status");
                        txt_pro_addL1.Text = MyReader.GetString("address_line1");
                        txt_pro_addL2.Text = MyReader.GetString("address_line2");
                        txt_pro_city.Text = MyReader.GetString("city");
                        txt_pro_posCode.Text = MyReader.GetString("pos_code");
                        txt_pro_dis.Text = MyReader.GetString("province");
                        txt_pro_nu_dependent.Text = MyReader.GetString("depend_no");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            else
            {
                MessageBox.Show("Plaese select employee name!!", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btn_hrm_up_detail_Click(object sender, EventArgs e)
        {
             if (comboBox4.Text != "")
            {

                pnl_hrm_pro_detail.Visible = true;
                btn_pro_3.Visible = true;
                btn_pro_6.Visible = true;
                btn_pro_7.Visible = true;
                btn_pro_14.Visible = true;
                btn_pro_15.Visible = true;
                btn_pro_16.Visible = true;
                btn_pro_update.Visible = false;


                string Constring = "datasource=localhost;port=3306;username=root;password=";

                string query = "select * from youken_springs.employee where e_id ='" + lbl_pro_em_id.Text + "';";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);
                MySqlCommand cmdDataBase = new MySqlCommand(query, ConDataBase);
                MySqlDataReader MyReader;

                try
                {
                    ConDataBase.Open();
                    MyReader = cmdDataBase.ExecuteReader();


                    while (MyReader.Read())
                    {


                        // txt_p_name.Text = MyReader.GetString("name");

                        txt_pro_em_name.Text = MyReader.GetString("e_full_name");
                        txt_pro_nameIn.Text = MyReader.GetString("name_in_initials");
                        txt_pro_sex.Text = MyReader.GetString("sex");
                        txt_pro_bldGroup.Text = MyReader.GetString("blood_group");
                        txt_pro_dob.Text = MyReader.GetString("DOB");
                        txt_pro_e_age.Text = MyReader.GetString("age");
                        txt_pro_religion.Text = MyReader.GetString("religion");
                        txt_pro_nationalty.Text = MyReader.GetString("nationality");
                        txt_pro_medifit.Text = MyReader.GetString("medical_fitness");
                        txt_pro_marituals.Text = MyReader.GetString("maritual_status");
                        txt_pro_addL1.Text = MyReader.GetString("address_line1");
                        txt_pro_addL2.Text = MyReader.GetString("address_line2");
                        txt_pro_city.Text = MyReader.GetString("city");
                        txt_pro_posCode.Text = MyReader.GetString("pos_code");
                        txt_pro_dis.Text = MyReader.GetString("province");
                        txt_pro_nu_dependent.Text = MyReader.GetString("depend_no");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Plaese select employee name!!", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            pnl_hrm_pro_detail.Visible = false; 
        }

        private void btn_pro_update_Click(object sender, EventArgs e)
        {
            btn_pro_3.Visible = true;
            btn_pro_6.Visible = true;
            btn_pro_7.Visible = true;
            btn_pro_14.Visible = true;
            btn_pro_15.Visible = true;
            btn_pro_16.Visible = true;
        }

        private void btn_pro_3_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.employee set address_line1 = @addline1,address_line2 = @addline2,city = @city where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@addline1", txt_pro_addL1.Text);
            cmdDataBase.Parameters.AddWithValue("@addline2", txt_pro_addL2.Text);
            cmdDataBase.Parameters.AddWithValue("@city", txt_pro_city.Text);

            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pro_6_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.employee set pos_code = @pos_code where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@pos_code", txt_pro_posCode.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_pro_7_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.employee set province = @province where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@province", txt_pro_dis.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pro_16_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.employee set medical_fitness = @medical_fitness where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@medical_fitness", txt_pro_medifit.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pro_14_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.employee set maritual_status = @maritual_status where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@maritual_status", txt_pro_marituals.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pro_15_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.employee set depend_no = @depend_no where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@depend_no", txt_pro_nu_dependent.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pro_upcontact_Click(object sender, EventArgs e)
        {
            pnl_hrm_detail_contact.Visible = true;


            string Constring = "datasource=localhost;port=3306;username=root;password=";

            string query = "select * from youken_springs.contact_detail where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(query, ConDataBase);
            MySqlDataReader MyReader;

            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {


                    txt_land.Text = MyReader.GetString("land");
                    txt_mob.Text = MyReader.GetString("mobile");
                    txt_email.Text = MyReader.GetString("email");
                    txt_conAdd.Text = MyReader.GetString("contact_add");
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void gb_conDetail_Enter(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pnl_hrm_detail_contact.Visible = false;
        }

        private void txt_pro_addL1_TextChanged(object sender, EventArgs e)
        {

        }





        private void mobile_up_Click_1(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.contact_detail set mobile = @mobile where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@mobile", txt_mob.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        
        private void add_up_Click_1(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.contact_detail set contact_add = @contact_add where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@contact_add", txt_conAdd.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        
        private void email_up_Click_1(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.contact_detail set email = @email where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@email", txt_email.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        
        
        private void land_up_Click(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            string quarry = "update youken_springs.contact_detail set land = @land where e_id ='" + lbl_pro_em_id.Text + "';";
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

            cmdDataBase.Parameters.AddWithValue("@land", txt_land.Text);


            try
            {

                ConDataBase.Open();
                cmdDataBase.ExecuteNonQuery();
                MessageBox.Show("Updated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            mobile_up.Visible = true;
            land_up.Visible = true;
            email_up.Visible = true;
            add_up.Visible = true;
        }

        private void pan_h_pro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_joinDate_Click(object sender, EventArgs e)
        {

        }

        private void lbl_position_Click(object sender, EventArgs e)
        {

        }

        private void txt_addCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_joinDate_TextChanged(object sender, EventArgs e)
        {

        }

        








   }
}
    

