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
    public partial class Quotation : Form
    {
        public Quotation()
        {
            InitializeComponent();
            date();
            FillcomboProduct();
        }

        void date()
        {
            lbl_qat_date.Text = DateTime.Now.ToShortDateString();


        }

        void FillcomboProduct()
        {

            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.products;";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string pdName1 = MyReader.GetString("name");
                    cmb_product_name1.Items.Add(pdName1);

                    string pdName2 = MyReader.GetString("name");
                    cmb_product_name2.Items.Add(pdName2);

                    string pdName3 = MyReader.GetString("name");
                    cmb_product_name3.Items.Add(pdName3);

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

        private void cmb_product_name1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.products where name ='" + cmb_product_name1.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_prduct_id1.Text = MyReader.GetUInt32("product_id").ToString();
                    lbl_des1.Text = MyReader.GetString("description");
                    lbl_unitP1.Text = MyReader.GetUInt32("unit_price").ToString();


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmb_product_name2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.products where name ='" + cmb_product_name2.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_prduct_id2.Text = MyReader.GetUInt32("product_id").ToString();
                    lbl_des2.Text = MyReader.GetString("description");
                    lbl_unitP2.Text = MyReader.GetUInt32("unit_price").ToString();


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmb_product_name3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.products where name ='" + cmb_product_name3.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_prduct_id3.Text = MyReader.GetUInt32("product_id").ToString();
                    lbl_des3.Text = MyReader.GetString("description");
                    lbl_unitP3.Text = MyReader.GetUInt32("unit_price").ToString();


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
                int unit_price1 = int.Parse(lbl_unitP1.Text);
                int quan1 = int.Parse(txt_qa1.Text);
                int sub1 = unit_price1 * quan1;
                lbl_subTot1.Text = sub1.ToString();

                int unit_price2 = int.Parse(lbl_unitP2.Text);
                int quan2 = int.Parse(txt_qa2.Text);
                int sub2 = unit_price2 * quan2;
                lbl_subTot2.Text = sub2.ToString();

                int unit_price3 = int.Parse(lbl_unitP3.Text);
                int quan3 = int.Parse(txt_qa3.Text);
                int sub3 = unit_price3 * quan3;
                lbl_subTot3.Text = sub3.ToString();

                int total = sub1 + sub2 + sub3;
                lbl_Total.Text = total.ToString();



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
                this.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
                this.FindAndReplace(wordApp, "<cus_name>", txt_cus_name.Text);
                this.FindAndReplace(wordApp, "<add_line1>", txt_addL1.Text);
                this.FindAndReplace(wordApp, "<add_line2>", txt_addL2.Text);
                this.FindAndReplace(wordApp, "<city>", txt_city.Text);
                this.FindAndReplace(wordApp, "<country>", txt_cunt.Text);
                this.FindAndReplace(wordApp, "<product_id1>", lbl_prduct_id1.Text);
                this.FindAndReplace(wordApp, "<product_id2>", lbl_prduct_id2.Text);
                this.FindAndReplace(wordApp, "<product_id3>", lbl_prduct_id3.Text);
                this.FindAndReplace(wordApp, "<description1>", lbl_des1.Text);
                this.FindAndReplace(wordApp, "<description2>", lbl_des2.Text);
                this.FindAndReplace(wordApp, "<description3>", lbl_des3.Text);
                this.FindAndReplace(wordApp, "<qu1>", txt_qa1.Text);
                this.FindAndReplace(wordApp, "<qa2>", txt_qa2.Text);
                this.FindAndReplace(wordApp, "<qa3>", txt_qa3.Text);
                this.FindAndReplace(wordApp, "<unit_price1>", lbl_unitP1.Text);
                this.FindAndReplace(wordApp, "<unit_price2>", lbl_unitP2.Text);
                this.FindAndReplace(wordApp, "<unit_price3>", lbl_unitP3.Text);
                this.FindAndReplace(wordApp, "<sub_total1>", lbl_subTot1.Text);
                this.FindAndReplace(wordApp, "<sub_total2>", lbl_subTot2.Text);
                this.FindAndReplace(wordApp, "<sub_total3>", lbl_subTot3.Text);
                this.FindAndReplace(wordApp, "<total>", lbl_Total.Text);
            }
        }
    }
}
