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
    public partial class HRM : Form

    {
        ////////////HRM(employee reg)////////////////////////////

        string fullname;
        string initialname;
        string addline1;
        string addline2;
        string city;
        string pocode;
        string province;
        string nationality;
        string religion;
        string bgroup;
        string mobile;
        string land;
        string caddress;
        string email;
        string depno;
        string d_name;
        string d_age;
        string d_reltoemp;
        string d_conno;
        string d_occupy;
        string medfit = "";
        string marstatus = "";
        string sex = "";
        string DOB = "";
        string e_age = "";
        string dateOfJOin = "";
        string dateOfConfirm = "";
        string dateOfIncrement = "";
      //  string e_id = "";
        string sourcePath;
        string destinationPath;

        //////////////////////////////////////////////////////////
        

        
        public HRM()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
            pan_reg1.Visible = true;
         
            panel_dep_dependen.Visible = true;
           
        }

        private void btn_next_Click(object sender, EventArgs e)
        {

            if ((txt_em_name.Text != "") && (txt_nameIn.Text != "") && (txt_addL1.Text != "")
    && (txt_addL2.Text != "") && (txt_city.Text != ""))
            {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            try
            {



                string query1 = "SELECT * FROM youken_springs.employee ORDER BY e_id DESC LIMIT 1 ;";

                MySqlCommand cmdDataBase1 = new MySqlCommand(query1, ConDataBase);
                MySqlDataReader MyReader;
                ConDataBase.Open();
                cmdDataBase1.ExecuteNonQuery();
                MyReader = cmdDataBase1.ExecuteReader();



                while (MyReader.Read())
                {

                    string e_id = MyReader.GetInt32("e_id").ToString();
                    fullname = MyReader.GetString("e_full_name");
                    lbl_hrm_em_proname.Text = fullname;
                    lbl_hrm_em_proid.Text = e_id;


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
            
            
            
            pan_reg2.Visible = true;
          // pan_reg1.Visible = false;
            panel_dep_dependen.Visible = false;
           // txt_em_name.Text = txt_nwi.Text;

            }
            else
            {
                MessageBox.Show("Please Enter Employee Details!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }



        }

        private void btn_prv1_Click(object sender, EventArgs e)
        {
            pan_reg1.Visible = true;
            pan_reg2.Visible = false;
            panel_dep_dependen.Visible = true;
           
        }

        private void btn_next1_Click(object sender, EventArgs e)
        {
            if (Txt_countrylogo.Text != "")
            {
                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                try
                {



                    string query1 = "SELECT * FROM youken_springs.employee ORDER BY e_id DESC LIMIT 1 ;";

                    MySqlCommand cmdDataBase1 = new MySqlCommand(query1, ConDataBase);
                    MySqlDataReader MyReader;
                    ConDataBase.Open();
                    cmdDataBase1.ExecuteNonQuery();
                    MyReader = cmdDataBase1.ExecuteReader();



                    while (MyReader.Read())
                    {

                        string e_id = MyReader.GetInt32("e_id").ToString();
                        fullname = MyReader.GetString("e_full_name");
                        lbl_hrm_reg_jname.Text = fullname;
                        lbl_hrm_job_e_id.Text = e_id;


                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }






                pan_reg3.Visible = true;
                // pan_reg1.Visible = true;
                pan_reg2.Visible = false;
                // pan_reg1.Visible = false;
                // panel_dep_dependen.Visible = true;
                // txt_em_name.Text = lbl_hrm_reg_jname.Text;


            }

            else
            {
                MessageBox.Show("Please Enter Employee Profile Picture!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btn_hrm_job_back_Click(object sender, EventArgs e)
        {
            pan_reg3.Visible = false;
            pan_reg2.Visible = true;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Profile f2 = new Profile();
            f2.ShowDialog();
            this.Close();  
        }

        private void btn_hrm_res_backhrm_Click(object sender, EventArgs e)
        {


        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void btn_hrm_job_upload_Click(object sender, EventArgs e)
        {
            try
            {
                dateOfJOin = dtp_joining.Value.ToShortDateString();

                //DateTime allowDateTime = DateTime.Now.AddMonths(2);
                //dateOfJOin = allowDateTime.ToString("M/dd/yyyy");
                //DateTime dt = DateTime.ParseExact(dateOfJOin, "M/dd/yyyy", null);

                dateOfConfirm = dtp_confirmation.Value.ToShortDateString();

                //DateTime allowDateTime1 = DateTime.Now.AddMonths(3);
                //dateOfConfirm = allowDateTime.ToString("M/dd/yyyy");
                //DateTime dt1 = DateTime.ParseExact(dateOfConfirm, "M/dd/yyyy", null);

                dateOfIncrement = dtp_promotion.Value.ToShortDateString();

                //DateTime allowDateTime2 = DateTime.Now.AddMonths(3);
                //dateOfIncrement = allowDateTime.ToString("M/dd/yyyy");
                //DateTime dt2 = DateTime.ParseExact(dateOfIncrement, "M/dd/yyyy", null);


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            if ((txt_branch.Text != "") && (txt_desig.Text != ""))
            {

                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                string quarry = "insert into youken_springs.job(e_id,designation,join_date,confirm_date,last_increment_date,last_increment,branch) Values (@e_id,@designation,@join_date,@confirm_date,@last_increment_date,@last_increment,@branch);";
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                cmdDataBase.Parameters.AddWithValue("@e_id", lbl_hrm_job_e_id.Text);
                cmdDataBase.Parameters.AddWithValue("@designation", txt_desig.Text);
                cmdDataBase.Parameters.AddWithValue("@join_date", dateOfJOin);
                cmdDataBase.Parameters.AddWithValue("@confirm_date", dateOfConfirm);
                cmdDataBase.Parameters.AddWithValue("@last_increment_date", dateOfIncrement);
                cmdDataBase.Parameters.AddWithValue("@last_increment", txt_last_increment.Text);
                cmdDataBase.Parameters.AddWithValue("@branch", txt_branch.Text);


                try
                {

                    ConDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully Add Job Details!!", "",
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
                MessageBox.Show("You must fill fileds ", "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void btn_hrm_emreg1_add_Click(object sender, EventArgs e)
        {
            if ((txt_em_name.Text != "") && (txt_nameIn.Text != "") && (txt_addL1.Text != "")
    && (txt_addL2.Text != "") && (txt_city.Text != ""))
            {



                /*
                 * 
                 */

                medfit = "";
                bool isChecked = rad_mf_yes.Checked;
                if (isChecked)
                    medfit = rad_mf_yes.Text;
                else
                    medfit = rad_mf_no.Text;

                marstatus = "";
                bool isChecked2 = rad_ms_yes.Checked;
                if (isChecked2)
                    marstatus = rad_ms_yes.Text;
                else
                    marstatus = rad_ms_no.Text;

                sex = "";
                bool isChecked3 = rad_male.Checked;
                if (isChecked3)
                    sex = rad_male.Text;
                else
                    sex = rad_female.Text;

                try
                {
                    DOB = "";

                    DOB = dtp_DOB.Value.ToShortDateString();

                   // DateTime allowDateTime = DateTime.Now.AddMonths(1);
                   // DOB = allowDateTime.ToString("M/dd/yyyy");
                   // DateTime dt = DateTime.ParseExact(DOB, "M/dd/yyyy", null);


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }


                ////////////data base connct////////////////////////////////////

                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                string quarry = "insert into youken_springs.employee(e_full_name,name_in_initials,sex,blood_group,DOB,age,religion,nationality,medical_fitness,maritual_status,address_line1,address_line2,city,pos_code,province,depend_no)VALUES(@fullname,@initialname,@sex,@bgroup,@DOB,@e_age,@religion,@nationality,@medfit,@marstatus,@addline1,@addline2,@city,@pocode,@province,@depend_no);";
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
                 
                
              


                cmdDataBase.Parameters.AddWithValue("@fullname", txt_em_name.Text);
                cmdDataBase.Parameters.AddWithValue("@initialname", txt_nameIn.Text);
                cmdDataBase.Parameters.AddWithValue("@sex", sex);
                cmdDataBase.Parameters.AddWithValue("@bgroup", txt_bldGroup.Text);
                cmdDataBase.Parameters.AddWithValue("@DOB", DOB);
                cmdDataBase.Parameters.AddWithValue("@e_age", txt_e_age.Text);
                cmdDataBase.Parameters.AddWithValue("@religion", txt_religion.Text);
                cmdDataBase.Parameters.AddWithValue("@nationality", txt_nationalty.Text);
                cmdDataBase.Parameters.AddWithValue("@medfit", medfit);
                cmdDataBase.Parameters.AddWithValue("@marstatus", marstatus);
                cmdDataBase.Parameters.AddWithValue("@addline1", txt_addL1.Text);
                cmdDataBase.Parameters.AddWithValue("@addline2", txt_addL2.Text);
                cmdDataBase.Parameters.AddWithValue("@city", txt_city.Text);
                cmdDataBase.Parameters.AddWithValue("@pocode", txt_posCode.Text);
                cmdDataBase.Parameters.AddWithValue("@province", txt_dis.Text);
                cmdDataBase.Parameters.AddWithValue("@depend_no", txt_noChild.Text);


                
               // @fullname=fullname;
                //txt_em_name.Text = fullname;
                //fullname = lbl_hrm_reg_jname.Text;
               // fullname = txt_nwi.Text;
               // fullname = lbl_dpn_name.Text;


                try
                {



                    
                    ConDataBase.Open();
                   
                    cmdDataBase.ExecuteNonQuery();

                    

                    //long id = cmdDataBase.LastInsertedId;
                    // e_id = Convert.ToString("id");
                    
                    MessageBox.Show("Sucessfully Add New employee!!", "",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConDataBase.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                try
                {

                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }






  /*                try
                  {
                      string query1 = "SELECT max(e_id) FROM youken_springs.employee;";



                 //insert into youken_springs.employee

                      MySqlCommand cmdDataBase1 = new MySqlCommand(query1, ConDataBase);
                      MySqlDataReader MyReader;
                      ConDataBase.Open();
                      cmdDataBase1.ExecuteNonQuery();
                      MyReader = cmdDataBase.ExecuteReader();



                      while (MyReader.Read())
                    {
                        e_id = MyReader.GetString("e_id");
                        e_id = lbl_hrm_reg_jname.Text;
                    }


                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message, "Error Messege",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }*/



                 





            }
            else
            {
                MessageBox.Show("Please fill the Required Fields", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_hrm_emreg1_contact_Click(object sender, EventArgs e)
        {

            if ((txt_mob.Text != "") && (txt_land.Text != "") && (txt_email.Text != ""))
            {

                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                string quarry = "insert into youken_springs.contact_detail(	e_id,land,mobile,email,contact_add) Values(LAST_INSERT_ID(),@land,@mobile,@email,@caaddress);";
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
                  //
                //cmdDataBase.Parameters.AddWithValue("@e_id", contac_eid.Text);
                cmdDataBase.Parameters.AddWithValue("@land", txt_land.Text);
                cmdDataBase.Parameters.AddWithValue("@mobile", txt_mob.Text);
                cmdDataBase.Parameters.AddWithValue("@email", txt_email.Text);
                cmdDataBase.Parameters.AddWithValue("@caaddress", txt_conAdd.Text);
                try
                {

                    ConDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully Add New Contact Detail!!", "",
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
                MessageBox.Show("Please fill the Required Fields", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btn_hrm_emreg1_depends_Click(object sender, EventArgs e)
        {
            if ((txt_noChild.Text != "") && (txt_noChild.Text != "0"))
            { pan_reg1.Visible = false;



            string Constring = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);

            try
            {



                string query1 = "SELECT * FROM youken_springs.employee ORDER BY e_id DESC LIMIT 1 ;";

                MySqlCommand cmdDataBase1 = new MySqlCommand(query1, ConDataBase);
                MySqlDataReader MyReader;
                ConDataBase.Open();
                cmdDataBase1.ExecuteNonQuery();
                MyReader = cmdDataBase1.ExecuteReader();



                while (MyReader.Read())
                {

                    string e_id = MyReader.GetInt32("e_id").ToString();
                    fullname = MyReader.GetString("e_full_name");
                    lbl_dpn_name.Text = fullname;
                    lbl_dpn_id.Text = e_id;


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            }

            else
            {
                MessageBox.Show("you havent dependents or does not add the fild!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_hrm_ereg2_browes_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Image img = new Bitmap(open.FileName);
                    string imagename = open.SafeFileName;

                    //Txt_countrylogo.Text = imagename;
                    picb_proPic.Image = img.GetThumbnailImage(picb_proPic.Width, picb_proPic.Height, null, new IntPtr());
                    open.RestoreDirectory = true;

                }


                var fd = new SaveFileDialog();
                fd.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg";
                fd.AddExtension = true;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (Path.GetExtension(fd.FileName).ToUpper())
                    {
                        case ".BMP":
                            picb_proPic.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case ".JPG":
                            picb_proPic.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".PNG":
                            picb_proPic.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }


                }
                Txt_countrylogo.Text = fd.FileName;

            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (Txt_countrylogo.Text != "")
            {
                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                string quarry = "insert into youken_springs.emp_pro_pic(e_id,pro_pic) Values(@e_id,@pro_pic);";
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                cmdDataBase.Parameters.AddWithValue("@e_id", lbl_hrm_em_proid.Text);
                cmdDataBase.Parameters.AddWithValue("@pro_pic", Txt_countrylogo.Text);

                try
                {




                    ConDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully Add Profile Picture!!", "",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // File.Copy("C:\\Users\\Public\\Pictures\\Sample Pictures\\" + Txt_countrylogo.Text, "E:\\projects\\Software(2nd Semester final project)\\New folder\\interface\\pro pics");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Select the profile picture", "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            pan_reg1.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {




            if ((txt_em_name.Text != "") && (txt_nameIn.Text != "") && (txt_addL1.Text != "")
    && (txt_addL2.Text != "") && (txt_city.Text != ""))
            {

                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                try
                {



                    string query1 = "SELECT * FROM youken_springs.employee ORDER BY e_id DESC LIMIT 1 ;";

                    MySqlCommand cmdDataBase1 = new MySqlCommand(query1, ConDataBase);
                    MySqlDataReader MyReader;
                    ConDataBase.Open();
                    cmdDataBase1.ExecuteNonQuery();
                    MyReader = cmdDataBase1.ExecuteReader();



                    while (MyReader.Read())
                    {

                        string e_id = MyReader.GetInt32("e_id").ToString();
                        fullname = MyReader.GetString("e_full_name");
                        lbl_hrm_em_proname.Text = fullname;
                        lbl_hrm_em_proid.Text = e_id;


                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Messege",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                pan_reg2.Visible = true;
                panel_dep_dependen.Visible = false;
                pan_reg1.Visible = false;

            }
            else
            {
                MessageBox.Show("Please Enter Details!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            

           
        }

        private void btn_hrm_depends_add_Click(object sender, EventArgs e)
        {


            if ((txt_d_name.Text != "") && (txt_d_age.Text != "") && (txt_d_occupy.Text != "") && (txt_d_contact.Text != "") && (txt_d_relation.Text != ""))
            {

                string Constring = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection ConDataBase = new MySqlConnection(Constring);

                string quarry = "insert into youken_springs.dependent (name,age,occupy,	contact_no,Relationship_to_the_employee,e_id) Values(@name,@age,@occupy,@contact_no,@relation,@e_id);";
                MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);

                cmdDataBase.Parameters.AddWithValue("@name", txt_d_name.Text);
                cmdDataBase.Parameters.AddWithValue("@age", txt_d_age.Text);
                cmdDataBase.Parameters.AddWithValue("@occupy", txt_d_occupy.Text);
                cmdDataBase.Parameters.AddWithValue("@contact_no", txt_d_contact.Text);
                cmdDataBase.Parameters.AddWithValue("@relation", txt_d_relation.Text);
                cmdDataBase.Parameters.AddWithValue("@e_id", lbl_dpn_id.Text);
                try
                {

                    ConDataBase.Open();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully Add New Dependant Details!!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            else
            {
                MessageBox.Show("Please add Dependant Details!!", "Error Messege",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pan_reg3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            pan_reg1.Visible = false;
            panel_dep_dependen.Visible = false;
            pan_reg2.Visible = false;
            pan_reg3.Visible = false;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pan_reg1.Visible = false;
            panel_dep_dependen.Visible = false;
            pan_reg2.Visible = false;
            pan_reg3.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Main f2 = new Main();
            f2.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dpn_name_Click(object sender, EventArgs e)
        {

        }

        private void HRM_Load(object sender, EventArgs e)
        {
            
        }

     
    
    
    
    



    
    
    
    
    }    

 }
