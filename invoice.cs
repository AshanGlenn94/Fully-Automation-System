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
    public partial class invoice : Form
    {
        public invoice()
        {
            InitializeComponent();
            date();
            invoice_id();
            FillcomboProduct();
            
        }


        void InvoiceFill(bool Fill)
        {
            int AllTot;

            Fill = true;

            if (txt_quantity1.Text != null && lbl_U_priz1.Text != null)
            {
                string quantity1 = txt_quantity1.Text;
                string price1 = lbl_U_priz1.Text;
                int qan1 = int.Parse(quantity1);
                int prz1 = int.Parse(price1);
                int total_1 = qan1 * prz1;
                string tot1 = total_1.ToString();
                lbl_subTot_1.Text = tot1;

                AllTot = int.Parse(lbl_subTot_1.Text);
                string tot_all = AllTot.ToString();
                lbl_allTot.Text = tot_all;
            }
            else if (txt_quantity2.Text != null && lbl_U_priz2.Text != null)
            {
                

                string quantity2 = txt_quantity2.Text;
                string price2 = lbl_U_priz2.Text;
                int qan2 = int.Parse(quantity2);
                int prz2 = int.Parse(price2);
                int total_2 = qan2 * prz2;
                string tot_2 = total_2.ToString();
                lbl_subTot_2.Text = tot_2;


                AllTot = int.Parse(lbl_subTot_1.Text) + int.Parse(lbl_subTot_2.Text);
                string tot_all2 = AllTot.ToString();
                lbl_allTot.Text = tot_all2;
            }
            else if (txt_quantity1.Text != null && lbl_U_priz1.Text != null && txt_quantity2.Text != null && lbl_U_priz2.Text != null && txt_quantity3.Text != null && lbl_U_priz3.Text != null)
            {

                string quantity3 = txt_quantity3.Text;
                string price3 = lbl_U_priz3.Text;
                int qan3 = int.Parse(quantity3);
                int prz3 = int.Parse(price3);
                int total_3 = qan3 * prz3;
                string tot_3 = total_3.ToString();
                lbl_subTot_3.Text = tot_3;



                AllTot = int.Parse(lbl_subTot_1.Text) + int.Parse(lbl_subTot_2.Text) + int.Parse(lbl_subTot_3.Text);
                string tot_all3 = AllTot.ToString();
                lbl_allTot.Text = tot_all3;
            }
            else if (txt_quantity1.Text != null && lbl_U_priz1.Text != null && txt_quantity2.Text != null && lbl_U_priz2.Text != null && txt_quantity3.Text != null && lbl_U_priz3.Text != null && txt_quantity4.Text != null && lbl_U_priz4.Text != null)
            {

                string quantity4 = txt_quantity4.Text;
                string price4 = lbl_U_priz4.Text;
                int qan4 = int.Parse(quantity4);
                int prz4 = int.Parse(price4);
                int total_4 = qan4 * prz4;
                string tot_4 = total_4.ToString();
                lbl_subTot_4.Text = tot_4;

                AllTot = int.Parse(lbl_subTot_1.Text) + int.Parse(lbl_subTot_2.Text) + int.Parse(lbl_subTot_3.Text) + int.Parse(lbl_subTot_4.Text);
                string tot_all4 = AllTot.ToString();
                lbl_allTot.Text = tot_all4;
            }
            else if (txt_quantity1.Text != null && lbl_U_priz1.Text != null && txt_quantity2.Text != null && lbl_U_priz2.Text != null && txt_quantity3.Text != null && lbl_U_priz3.Text != null && txt_quantity4.Text != null && lbl_U_priz4.Text != null && txt_quantity5.Text != null && lbl_U_priz5.Text != null)
            {

                string quantity5 = txt_quantity5.Text;
                string price5 = lbl_U_priz5.Text;
                int qan5 = int.Parse(quantity5);
                int prz5 = int.Parse(price5);
                int total_5 = qan5 * prz5;
                string tot_5 = total_5.ToString();
                lbl_subTot_5.Text = tot_5;

                AllTot = int.Parse(lbl_subTot_1.Text) + int.Parse(lbl_subTot_2.Text) + int.Parse(lbl_subTot_3.Text) + int.Parse(lbl_subTot_4.Text) + int.Parse(lbl_subTot_5.Text);
                string tot_all5 = AllTot.ToString();
                lbl_allTot.Text = tot_all5;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        void date()
        {
            lbl_date.Text = DateTime.Now.ToShortDateString();


        }

        void invoice_id()
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.invoice;";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;

            try
            {

                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {

                    string in_id = MyReader.GetInt32("invoice_id").ToString();
                    int invice = int.Parse(in_id);
                    invice += 1;
                    lbl_in_id.Text = invice.ToString();
                }




            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

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

                    string pdName4 = MyReader.GetString("name");
                    cmb_product_name4.Items.Add(pdName4);

                    string pdName5 = MyReader.GetString("name");
                    cmb_product5.Items.Add(pdName5);

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
                    lbl_description1.Text = MyReader.GetString("description");
                    lbl_U_priz1.Text = MyReader.GetUInt32("unit_price").ToString();


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
                    lbl_description2.Text = MyReader.GetString("description");
                    lbl_U_priz2.Text = MyReader.GetUInt32("unit_price").ToString();


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
                    lbl_description3.Text = MyReader.GetString("description");
                    lbl_U_priz3.Text = MyReader.GetUInt32("unit_price").ToString();


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmb_product_name4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.products where name ='" + cmb_product_name4.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_prduct_id4.Text = MyReader.GetUInt32("product_id").ToString();
                    lbl_description4.Text = MyReader.GetString("description");
                    lbl_U_priz4.Text = MyReader.GetUInt32("unit_price").ToString();


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmb_product5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Constring = "datasource=localhost;port=3306;username=root;password=";
            string quarry = "select * from youken_springs.products where name ='" + cmb_product5.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(Constring);
            MySqlCommand cmdDataBase = new MySqlCommand(quarry, ConDataBase);
            MySqlDataReader MyReader;
            try
            {
                ConDataBase.Open();
                MyReader = cmdDataBase.ExecuteReader();


                while (MyReader.Read())
                {
                    lbl_prduct_id5.Text = MyReader.GetUInt32("product_id").ToString();
                    lbl_description5.Text = MyReader.GetString("description");
                    lbl_U_priz5.Text = MyReader.GetUInt32("unit_price").ToString();


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
                InvoiceFill(true);

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
                this.FindAndReplace(wordApp, "<cus_name>", txt_cuName.Text);
                this.FindAndReplace(wordApp, "<add_line1>", txt_addLine1.Text);
                this.FindAndReplace(wordApp, "<add_line2>", txt_addLine2.Text);
                this.FindAndReplace(wordApp, "<city>", txt_city.Text);
                this.FindAndReplace(wordApp, "<country>", txt_cuntry.Text);
                this.FindAndReplace(wordApp, "<phone_number>", txt_phoneNum.Text);
                this.FindAndReplace(wordApp, "<product_id1>", lbl_prduct_id1.Text);
                this.FindAndReplace(wordApp, "<product_id2>", lbl_prduct_id2.Text);
                this.FindAndReplace(wordApp, "<product_id3>", lbl_prduct_id3.Text);
                this.FindAndReplace(wordApp, "<product_id4>", lbl_prduct_id4.Text);
                this.FindAndReplace(wordApp, "<product_id5>", lbl_prduct_id5.Text);
                this.FindAndReplace(wordApp, "<description1>", lbl_description1.Text);
                this.FindAndReplace(wordApp, "<description2>", lbl_description2.Text);
                this.FindAndReplace(wordApp, "<description3>", lbl_description3.Text);
                this.FindAndReplace(wordApp, "<description4>", lbl_description4.Text);
                this.FindAndReplace(wordApp, "<description5>", lbl_description5.Text);
                this.FindAndReplace(wordApp, "<quantity1>", txt_quantity1.Text);
                this.FindAndReplace(wordApp, "<quantity2>", txt_quantity2.Text);
                this.FindAndReplace(wordApp, "<quantity3>", txt_quantity3.Text);
                this.FindAndReplace(wordApp, "<quantity4>", txt_quantity4.Text);
                this.FindAndReplace(wordApp, "<quantity5>", txt_quantity5.Text);
                this.FindAndReplace(wordApp, "<unit_price1>", lbl_U_priz1.Text);
                this.FindAndReplace(wordApp, "<unit_price2>", lbl_U_priz2.Text);
                this.FindAndReplace(wordApp, "<unit_price3>", lbl_U_priz3.Text);
                this.FindAndReplace(wordApp, "<unit_price4>", lbl_U_priz4.Text);
                this.FindAndReplace(wordApp, "<unit_price5>", lbl_U_priz5.Text);
                this.FindAndReplace(wordApp, "<total1>", lbl_subTot_1.Text);
                this.FindAndReplace(wordApp, "<total2>", lbl_subTot_2.Text);
                this.FindAndReplace(wordApp, "<total3>", lbl_subTot_3.Text);
                this.FindAndReplace(wordApp, "<total4>", lbl_subTot_4.Text);
                this.FindAndReplace(wordApp, "<total5>", lbl_subTot_5.Text);
                this.FindAndReplace(wordApp, "<total>", lbl_allTot.Text);
            }
        }

        private void invoice_Load(object sender, EventArgs e)
        {

        }
    }
}
