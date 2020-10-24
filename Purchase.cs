using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            date();
            FillcomboMaterial();
        }

        void date()
        {
            lbl_order_date.Text = DateTime.Now.ToShortDateString();


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

                    string mtName1 = MyReader.GetString("meterial_name");
                    cmb_mat_name1.Items.Add(mtName1);

                    string mtName2 = MyReader.GetString("meterial_name");
                    cmb_mat_name2.Items.Add(mtName2);

                    string mtName3 = MyReader.GetString("meterial_name");
                    cmb_mat_name3.Items.Add(mtName3);

                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory f2 = new Inventory();
            f2.ShowDialog();
            System.Windows.Forms.Application.Exit();
        }

        private void cmb_mat_name1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial where meterial_name ='" + cmb_mat_name1.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_mat_id1.Text = MyReader.GetUInt32("meterial_id").ToString();


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmb_mat_name2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial where meterial_name ='" + cmb_mat_name2.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_mat_id2.Text = MyReader.GetUInt32("meterial_id").ToString();


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmb_mat_name3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.meterial where meterial_name ='" + cmb_mat_name3.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_mat_id3.Text = MyReader.GetUInt32("meterial_id").ToString();


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

        private void btn_add_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                int unit_price1 = int.Parse(txt_up1.Text);
                int quan1 = int.Parse(txt_mat_qa1.Text);
                int sub1 = unit_price1 * quan1;
                lbl_mat_subTot1.Text = sub1.ToString();

                int unit_price2 = int.Parse(txt_up2.Text);
                int quan2 = int.Parse(txt_mat_qa2.Text);
                int sub2 = unit_price2 * quan2;
                lbl_mat_subTot2.Text = sub2.ToString();

                int unit_price3 = int.Parse(txt_up3.Text);
                int quan3 = int.Parse(txt_mat_qa3.Text);
                int sub3 = unit_price3 * quan3;
                lbl_mat_subTot3.Text = sub3.ToString();

                int total = sub1 + sub2 + sub3;
                lbl_mat_Total.Text = total.ToString();



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
                this.FindAndReplace(wordApp, "<po_date>", DateTime.Now.ToShortDateString());
                this.FindAndReplace(wordApp, "<sup_name>", txt_cus_name.Text);
                this.FindAndReplace(wordApp, "<s_addL1>", txt_addL1.Text);
                this.FindAndReplace(wordApp, "<s_addL2>", txt_addL2.Text);
                this.FindAndReplace(wordApp, "<s_city>", txt_city.Text);
                this.FindAndReplace(wordApp, "<s_cun>", txt_cunt.Text);
                this.FindAndReplace(wordApp, "<d_name>", textBox7.Text);
                this.FindAndReplace(wordApp, "<add1>", textBox5.Text);
                this.FindAndReplace(wordApp, "<add2>", textBox6.Text);
                this.FindAndReplace(wordApp, "<city>", textBox4.Text);
                this.FindAndReplace(wordApp, "<cuntry>", textBox3.Text);
                this.FindAndReplace(wordApp, "<o_num>", txt_ordrNo.Text);
                this.FindAndReplace(wordApp, "<s_id>", txt_sup_id.Text);
              
                this.FindAndReplace(wordApp, "<m_id1>", lbl_mat_id1.Text);
                this.FindAndReplace(wordApp, "<m_id2>", lbl_mat_id2.Text);
                this.FindAndReplace(wordApp, "<m_id3>", lbl_mat_id3.Text);
                this.FindAndReplace(wordApp, "<des1>", txt_des1.Text);
                this.FindAndReplace(wordApp, "<des2>", txt_des2.Text);
                this.FindAndReplace(wordApp, "<des3>", txt_des3.Text);
                this.FindAndReplace(wordApp, "<qa1>", txt_mat_qa1.Text);
                this.FindAndReplace(wordApp, "<qa2>",txt_mat_qa2.Text );
                this.FindAndReplace(wordApp, "<qa3>", txt_mat_qa3.Text);
                this.FindAndReplace(wordApp, "<up1>", txt_up1.Text);
                this.FindAndReplace(wordApp, "<up2>", txt_up2.Text);
                this.FindAndReplace(wordApp, "<up3>", txt_up3.Text);
                this.FindAndReplace(wordApp, "<st1>",  lbl_mat_subTot1.Text);
                this.FindAndReplace(wordApp, "<st2>", lbl_mat_subTot2.Text);
                this.FindAndReplace(wordApp, "<st3>", lbl_mat_subTot3.Text);
                this.FindAndReplace(wordApp, "<total>", lbl_mat_Total.Text);
            }
        }

        
    }
}
