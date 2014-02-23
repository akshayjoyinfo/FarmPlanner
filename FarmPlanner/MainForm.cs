using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Farm.BusinessLayer;
using Farm.CommonClass;
using System.Collections;
using System.Reflection;
using Microsoft.Office.Interop;
using System.IO;

namespace FarmPlanner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<Corp> listCorpItems = new List<Corp>();
        List<FarmView> listFarmViewSection = new List<FarmView>();
        List<FarmView> listModifiedFarmSection = new List<FarmView>();
        string selectedCorps = "";



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listCrops.SelectedItem != null)
                {
                    string selctedItem = listCrops.SelectedItem.ToString();

                    string[] ItemArray = selctedItem.Split('-');


                    int validperiod = int.Parse(ItemArray[1].ToString());

                    string farmSection = comboFarmSection.SelectedItem.ToString();
                    string selectedMonth = comboMonth.SelectedItem.ToString();

                    for (int i = 0; i < dgvFarmView.Rows.Count - 1; i++)
                    {
                        if (dgvFarmView.Rows[i].Cells[0].Value.ToString().Equals(farmSection))
                        {
                            DataGridViewRow currentRow = dgvFarmView.Rows[i];

                            Corp corpDetails = listCorpItems.Find(c => c.Name == ItemArray[0]);
                            Color cellColor = Color.FromName(corpDetails.Color);
                            int month = DateTime.Parse("1." + selectedMonth + " "+ comboYear.SelectedItem.ToString()).Month;
                            DateTime sDate = DateTime.Parse("1/" + selectedMonth + "/" + comboYear.SelectedItem.ToString());
                            DateTime eDate = sDate.AddMonths(validperiod - 1).AddDays(27);
                            int validPeriodMonth = 0;
                            if (listCrops.GetItemCheckState(listCrops.SelectedIndex) == System.Windows.Forms.CheckState.Checked)
                            {
                                FarmView farmViewObj = new FarmView(farmSection, corpDetails.Name, sDate, eDate);
                                
                                if (FarmDAO.CheckFarmViewExist(farmViewObj)) // if (month + validperiod <= 13)
                                {
                                    validPeriodMonth = month + validperiod;

                                    if (validPeriodMonth > 13)
                                    {
                                        validPeriodMonth = 13;
                                    }

                                    if (currentRow.Cells[month].Value == null && currentRow.Cells[validPeriodMonth - 1].Value == null)
                                    {
                                        for (int j = month; j < validPeriodMonth; ++j)
                                            {
                                                currentRow.Cells[j].Style.BackColor = cellColor;
                                                currentRow.Cells[j].Style.ForeColor = cellColor;
                                                currentRow.Cells[j].Style.SelectionBackColor = cellColor;
                                                currentRow.Cells[j].Style.SelectionForeColor = cellColor;
                                                currentRow.Cells[j].Value = corpDetails.Name;
                                            }

                                            
                                            listFarmViewSection.Add(farmViewObj);
                                            listModifiedFarmSection.Add(farmViewObj);
                                   
                                    }
                                    else
                                    {
                                        ShowMessage("Already occupied by one Item", "Farm Planner - Info", MessageBoxIcon.Warning);
                                        listCrops.SetItemCheckState(listCrops.SelectedIndex, CheckState.Unchecked);
                                    }
                                }
                            
                                else
                                {
                                    ShowMessage("Exceeds the period for this Year !!", "Farm Planner - Info", MessageBoxIcon.Warning);
                                    listCrops.SetItemCheckState(listCrops.SelectedIndex, CheckState.Unchecked);
                                }


                            }
                            else
                            {
                                if (validPeriodMonth <= 13)
                                {
                                    for (int j = month; j < validPeriodMonth; ++j)
                                    {
                                        currentRow.Cells[j].Style.BackColor = Color.White;
                                        currentRow.Cells[j].Style.ForeColor = Color.White;
                                        currentRow.Cells[j].Style.SelectionBackColor = Color.White;
                                        currentRow.Cells[j].Style.SelectionForeColor = Color.White;
                                        currentRow.Cells[j].Value = null;
                                    }
                                }

                            }
                        }

                    }


                }

            }
            catch (Exception exp)
            {
                ShowMessage("Error while choosing the Corps " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }

        }

        protected void ShowMessage(string message, string title, MessageBoxIcon IconType)
        {
            //MessageBox.Show(message, title, MessageBoxButtons.OK, IconType);
            if (IconType == MessageBoxIcon.Error)
            {
                lblMessage.Text = message;
                lblMessage.ForeColor = Color.Red;
                MessageBox.Show(message, title, MessageBoxButtons.OK, IconType);

            }
            else if (IconType == MessageBoxIcon.Warning)
            {
                lblMessage.Text = message;
                lblMessage.ForeColor = Color.Red;
                MessageBox.Show(message, title, MessageBoxButtons.OK, IconType);
            }
            else
            {
                lblMessage.Text = message;
                lblMessage.ForeColor = Color.Green;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFarmSectionItems();
                LoadFarmCrops();
                LoadColors();
                LoadGridFarmView();
                LoadCurrentItems();
                LoadFarmViewResult();
                


            }
            catch (Exception exp)
            {
                ShowMessage("Error while launching the Application " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void LoadColors()
        {
            try
            {
                List<string> ColorList = new List<string>();
                Type colorType = typeof(System.Drawing.Color);
                PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
                foreach (PropertyInfo c in propInfoList)
                {
                    comboColor.Items.Add(c.Name);
                }



            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadColors " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentItems()
        {
            try
            {

                comboMonth.SelectedItem = "January";
                comboYear.SelectedItem = DateTime.Now.Year.ToString();
                comboFarmSection.SelectedItem = dgvFarmView.Rows[0].Cells[0].Value;

            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadCurrentItems " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void LoadFarmViewResult()
        {
            try
            {
                listFarmViewSection.Clear();
                listFarmViewSection = FarmDAO.GetAllFarmSections(int.Parse(comboYear.SelectedItem.ToString()));

                foreach (FarmView obj in listFarmViewSection)
                {
                    for (int i = 0; i < dgvFarmView.Rows.Count - 1; i++)
                    {
                        DataGridViewRow currentRow = dgvFarmView.Rows[i];

                        if (dgvFarmView.Rows[i].Cells[0].Value.ToString().Equals(obj.Section))
                        {

                            int startmonth = obj.StartDate.Month;
                            int startYear = obj.StartDate.Year;
                            int endMonth = obj.EndDate.Month;
                            int endYear = obj.EndDate.Year;

                            if (startYear == endYear)
                            {

                                for (int posMonth = startmonth; posMonth <= endMonth; ++posMonth)
                                {
                                    Corp corpDetails = listCorpItems.Find(c => c.Name == obj.Corp);
                                    Color cellColor = Color.FromName(corpDetails.Color);
                                    currentRow.Cells[posMonth].Style.BackColor = cellColor;
                                    currentRow.Cells[posMonth].Style.ForeColor = cellColor;
                                    currentRow.Cells[posMonth].Style.SelectionBackColor = cellColor;
                                    currentRow.Cells[posMonth].Style.SelectionForeColor = cellColor;
                                    currentRow.Cells[posMonth].Value = corpDetails.Name;
                                }
                            }
                            else
                            {
                                if (startYear == int.Parse(comboYear.SelectedItem.ToString()))
                                {
                                    for (int posMonth = startmonth; posMonth <= 12; ++posMonth)
                                    {
                                        Corp corpDetails = listCorpItems.Find(c => c.Name == obj.Corp);
                                        Color cellColor = Color.FromName(corpDetails.Color);
                                        currentRow.Cells[posMonth].Style.BackColor = cellColor;
                                        currentRow.Cells[posMonth].Style.ForeColor = cellColor;
                                        currentRow.Cells[posMonth].Style.SelectionBackColor = cellColor;
                                        currentRow.Cells[posMonth].Style.SelectionForeColor = cellColor;
                                        currentRow.Cells[posMonth].Value = corpDetails.Name;
                                    }
                                }
                                else
                                {
                                    for (int posMonth = 1; posMonth <= endMonth; ++posMonth)
                                    {
                                        Corp corpDetails = listCorpItems.Find(c => c.Name == obj.Corp);
                                        Color cellColor = Color.FromName(corpDetails.Color);
                                        currentRow.Cells[posMonth].Style.BackColor = cellColor;
                                        currentRow.Cells[posMonth].Style.ForeColor = cellColor;
                                        currentRow.Cells[posMonth].Style.SelectionBackColor = cellColor;
                                        currentRow.Cells[posMonth].Style.SelectionForeColor = cellColor;
                                        currentRow.Cells[posMonth].Value = corpDetails.Name;
                                    }
                                }

                            }
                        }

                    }
                }


            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadFarmViewResult " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void LoadGridFarmView()
        {
            try
            {
                int pos = 0;
                foreach (string item in comboFarmSection.Items)
                {
                    dgvFarmView.Rows.Add();
                    dgvFarmView.Rows[pos].Cells[0].Value = item;
                    pos++;
                }


            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadGridFarmView " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void LoadFarmCrops()
        {
            try
            {
                listCorpItems = FarmDAO.GetAllCorps();
                int pos = 0;

                foreach (Corp item in listCorpItems)
                {
                    listCrops.Items.Add(item.Name + "-" + item.Period);
                    dgvCorps.Rows.Add();
                    dgvCorps.Rows[pos].Cells[0].Value = item.Name;
                    dgvCorps.Rows[pos].Cells[1].Value = item.Period;
                    dgvCorps.Rows[pos].Cells[2].Value = item.Color;
                    dgvCorps.Rows[pos].Cells[2].Style.BackColor = Color.FromName(item.Color);
                    dgvCorps.Rows[pos].Cells[2].Style.ForeColor = Color.FromName(item.Color);
                    dgvCorps.Rows[pos].Cells[2].Style.SelectionBackColor = Color.FromName(item.Color);
                    dgvCorps.Rows[pos].Cells[2].Style.SelectionForeColor = Color.FromName(item.Color);

                    pos++;
                }




            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadFarmCrops " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void LoadFarmSectionItems()
        {
            try
            {

                List<Section> listSections = new List<Section>();
                listSections = FarmDAO.GetAllSection();

                foreach (Section ob in listSections)
                {
                    comboFarmSection.Items.Add(ob.SecName);
                }

            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadFarmSectionItems " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void comboFarmSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelectionCorps();

        }

        private void comboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelectionCorps();
        }
        protected void ClearSelectionCorps()
        {
            foreach (int i in listCrops.CheckedIndices)
            {
                listCrops.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Equals("") || txtPeriod.Text.Equals("") || comboColor.Text.Equals(""))
                {
                    ShowMessage("Please Enter the Name, Period and Color", "Farm Planner-  AddCorps", MessageBoxIcon.Warning);
                }
                else
                {

                    Corp corpItem = new Corp(txtName.Text, comboColor.Text.ToString(), int.Parse(txtPeriod.Text));
                    if (!FarmDAO.CheckCorpExist(corpItem))
                    {
                        FarmDAO.AddCorps(corpItem);
                        ShowMessage("Successfully entered Item " + txtName.Text, "Farm Planner - Info", MessageBoxIcon.Information);
                        txtName.Text = "";
                        txtPeriod.Text = "";
                        comboColor.Text = "";
                        listCorpItems.Add(corpItem);
                        listCrops.Items.Add(corpItem.Name + "-" + corpItem.Period);
                        dgvCorps.Rows.Add();
                        int pos = dgvCorps.Rows.Count - 2;
                        dgvCorps.Rows[pos].Cells[0].Value = corpItem.Name;
                        dgvCorps.Rows[pos].Cells[1].Value = corpItem.Period;
                        dgvCorps.Rows[pos].Cells[2].Value = corpItem.Color;
                        dgvCorps.Rows[pos].Cells[2].Style.BackColor = Color.FromName(corpItem.Color);
                        dgvCorps.Rows[pos].Cells[2].Style.ForeColor = Color.FromName(corpItem.Color);
                        dgvCorps.Rows[pos].Cells[2].Style.SelectionBackColor = Color.FromName(corpItem.Color);
                        dgvCorps.Rows[pos].Cells[2].Style.SelectionForeColor = Color.FromName(corpItem.Color);
                    }
                    else
                    {
                        ShowMessage("Item with Name or Color is already exist ", "Farm Planner - Info", MessageBoxIcon.Warning);
                        txtName.Text = "";
                        txtPeriod.Text = "";
                        comboColor.Text = "";
                    }
                }
            }
            catch (Exception exp)
            {
                ShowMessage("Error in Adding Corps " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void txtCorp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void dgvCorps_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvCorps_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCorps.SelectedRows.Count > 0)
            {
               // btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtName.Text = dgvCorps.SelectedRows[0].Cells[0].Value.ToString();
                txtPeriod.Text = dgvCorps.SelectedRows[0].Cells[1].Value.ToString();
                comboColor.Text = dgvCorps.SelectedRows[0].Cells[2].Value.ToString();
            }
            else
            {
                //btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtName.Text.Equals("") || txtPeriod.Text.Equals("") || comboColor.Text.Equals(""))
                {
                    ShowMessage("Please Enter the Name, Period and Color", "Farm Planner-  AddCorps", MessageBoxIcon.Warning);
                }
                else
                {

                    Corp corpItem = new Corp(txtName.Text, comboColor.Text.ToString(), int.Parse(txtPeriod.Text));
                    if (!FarmDAO.CheckCorpExistWithoutColor(corpItem))
                    {
                        string selectedItem = dgvCorps.SelectedRows[0].Cells[0].Value.ToString();
                        int pos = dgvCorps.Rows.IndexOf(dgvCorps.SelectedRows[0]);
                        FarmDAO.EditCorps(corpItem, selectedItem);
                        ShowMessage("Successfully Edited the Item " + txtName.Text, "Farm Planner - Info", MessageBoxIcon.Information);
                        txtName.Text = "";
                        txtPeriod.Text = "";
                        comboColor.Text = "";
                        var index = listCorpItems.FindIndex(c => c.Name == selectedItem);
                        // listCorpItems.Add(corpItem);
                        listCorpItems[index] = corpItem;
                        //listCrops.Items.Add(corpItem.Name + "-" + corpItem.Period);
                        // listCrops.Items.f= .Add(corpItem.Name + "-" + corpItem.Period);
                        string ItemwithPeriod = selectedItem + "-" + dgvCorps.SelectedRows[0].Cells[1].Value.ToString();
                        var ind = listCrops.Items.IndexOf(ItemwithPeriod);
                        listCrops.Items[ind] = corpItem.Name + "-" + corpItem.Period;



                        dgvCorps.Rows[pos].Cells[0].Value = corpItem.Name;
                        dgvCorps.Rows[pos].Cells[1].Value = corpItem.Period;
                        dgvCorps.Rows[pos].Cells[2].Value = corpItem.Color;
                        dgvCorps.Rows[pos].Cells[2].Style.BackColor = Color.FromName(corpItem.Color);
                        dgvCorps.Rows[pos].Cells[2].Style.ForeColor = Color.FromName(corpItem.Color);
                        dgvCorps.Rows[pos].Cells[2].Style.SelectionBackColor = Color.FromName(corpItem.Color);
                        dgvCorps.Rows[pos].Cells[2].Style.SelectionForeColor = Color.FromName(corpItem.Color);
                       // btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        ShowMessage("Item with Name or Color is already exist ", "Farm Planner - Info", MessageBoxIcon.Warning);
                        txtName.Text = "";
                        txtPeriod.Text = "";
                        comboColor.Text = "";
                    }
                }
            }
            catch (Exception exp)
            {
                ShowMessage("Error in Editing Corps " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                Corp corpItem = new Corp(txtName.Text, comboColor.Text.ToString(), int.Parse(txtPeriod.Text));
                if (FarmDAO.DeleteCorp(corpItem))
                {
                    ShowMessage("Successfullly Deleted Corp ", "Farm Planner - Info", MessageBoxIcon.Information);
                    btnDelete.Enabled = false;
                    // btnEdit.Enabled = false;
                    

                    txtName.Text = "";
                    txtPeriod.Text = "";
                    comboColor.Text = "";

                    

                    var index = listCorpItems.FindIndex(c => c.Name == corpItem.Name);
                    listCorpItems.RemoveAt(index);
                    string ItemwithPeriod = corpItem.Name + "-" + dgvCorps.SelectedRows[0].Cells[1].Value.ToString();
                    var ind = listCrops.Items.IndexOf(ItemwithPeriod);
                    listCrops.Items.RemoveAt(ind);
                    dgvCorps.Rows.RemoveAt(dgvCorps.SelectedRows[0].Index);

                    // Clean the Entries for the Deleted Corp from the TABLE -START

                    FarmDAO.DeleteCorpFromFarmView(corpItem);
                    listFarmViewSection.RemoveAll(c => c.Corp == corpItem.Name);
                    listModifiedFarmSection.RemoveAll(c => c.Corp == corpItem.Name);
                    ClearFarmViewColor();
                    LoadFarmViewResult();
                    ReColorModifedFarmDetails();
                    ClearSelectionCorps();
                    // Clean the Entries for the Deleted Corp from the TABLE - END



                }
                else
                {
                    ShowMessage("An Error occured during the Deltetion of the Corp", "Farm Planner - Info", MessageBoxIcon.Warning);
                    btnDelete.Enabled = false;
                }


            }
            catch (Exception exp)
            {
                ShowMessage("Error in Deleting Corps " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtSecction.Text.Equals(""))
                {

                    Section sec = new Section(txtSecction.Text);
                    if (!FarmDAO.CheckSectionExist(sec))
                    {
                        if (FarmDAO.AddSections(sec))
                        {
                            ShowMessage("Successfully Added Section " + sec.SecName, "Farm Planner - Info", MessageBoxIcon.Information);
                            comboFarmSection.Items.Add(sec.SecName);
                            dgvFarmView.Rows.Add();
                            dgvFarmView.Rows[dgvFarmView.Rows.Count - 2].Cells[0].Value = sec.SecName;
                            txtSecction.Text = "";
                        }
                        else
                        {
                            ShowMessage("An Error occured during adding the Section", "Farm Planner - Info", MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        ShowMessage("Section with the Name is already exist", "Farm Planner - Info", MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    ShowMessage("Please Enter the Section Name", "Farm Planner-  AddSection", MessageBoxIcon.Warning);
                }

            }
            catch (Exception exp)
            {
                ShowMessage("Error in Adding Sections " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void ClearFarmViewColor()
        {
            try
            {
                for (int i = 0; i < dgvFarmView.Rows.Count - 1; ++i)
                {
                    DataGridViewRow currentRow = dgvFarmView.Rows[i];
                    for (int j = 1; j < dgvFarmView.Rows[i].Cells.Count; ++j)
                    {
                        currentRow.Cells[j].Style.BackColor = Color.White;
                        currentRow.Cells[j].Style.ForeColor = Color.White;
                        currentRow.Cells[j].Style.SelectionBackColor = Color.White;
                        currentRow.Cells[j].Style.SelectionForeColor = Color.White;
                        currentRow.Cells[j].Value = null;
                    }
                }

            }
            catch (Exception exp)
            {
                ShowMessage("Error in ClearFarmViewColor the Application" + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void ReColorModifedFarmDetails()
        {
            try
            {

                foreach (FarmView obj in listModifiedFarmSection)
                {
                    for (int i = 0; i < dgvFarmView.Rows.Count - 1; i++)
                    {
                        DataGridViewRow currentRow = dgvFarmView.Rows[i];

                        if (dgvFarmView.Rows[i].Cells[0].Value.ToString().Equals(obj.Section))
                        {

                            int startmonth = obj.StartDate.Month;
                            int endMonth = obj.EndDate.Month;

                            for (int posMonth = startmonth; posMonth <= endMonth; ++posMonth)
                            {
                                Corp corpDetails = listCorpItems.Find(c => c.Name == obj.Corp);
                                Color cellColor = Color.FromName(corpDetails.Color);
                                currentRow.Cells[posMonth].Style.BackColor = cellColor;
                                currentRow.Cells[posMonth].Style.ForeColor = cellColor;
                                currentRow.Cells[posMonth].Style.SelectionBackColor = cellColor;
                                currentRow.Cells[posMonth].Style.SelectionForeColor = cellColor;
                                currentRow.Cells[posMonth].Value = null;
                            }
                        }

                    }
                }

            }
            catch (Exception exp)
            {
                ShowMessage("Error in ClearFarmViewColor the Application" + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listModifiedFarmSection.Count > 0)
                {
                    FarmDAO.AddFarmDetails(listModifiedFarmSection);
                    listModifiedFarmSection.Clear();
                    ClearSelectionCorps();
                    ShowMessage("Successfully Saved the DATA", "Farm Planner - Info", MessageBoxIcon.Information);

                }
                else
                {
                    ShowMessage("There is no Data to Save", "Farm Planner - Info", MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                ShowMessage("Error in Saving FarmView Result " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                ResetModifedFarmDetails();
                ClearSelectionCorps();
                listModifiedFarmSection.Clear();
                LoadFarmViewResult();
            }
            catch (Exception exp)
            {
                ShowMessage("Error in Resting FarmView Modifications " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }


        }

        private void ResetModifedFarmDetails()
        {
            try
            {
                foreach (FarmView obj in listModifiedFarmSection)
                {
                    for (int i = 0; i < dgvFarmView.Rows.Count - 1; i++)
                    {
                        DataGridViewRow currentRow = dgvFarmView.Rows[i];

                        if (dgvFarmView.Rows[i].Cells[0].Value.ToString().Equals(obj.Section))
                        {

                            int startmonth = obj.StartDate.Month;
                            int endMonth = obj.EndDate.Month;

                            for (int posMonth = startmonth; posMonth <= endMonth; ++posMonth)
                            {
                                Corp corpDetails = listCorpItems.Find(c => c.Name == obj.Corp);
                                Color cellColor = Color.FromName(corpDetails.Color);
                                currentRow.Cells[posMonth].Style.BackColor = Color.White;
                                currentRow.Cells[posMonth].Style.ForeColor = Color.White;
                                currentRow.Cells[posMonth].Style.SelectionBackColor = Color.White;
                                currentRow.Cells[posMonth].Style.SelectionForeColor = Color.White;
                                currentRow.Cells[posMonth].Value = null;
                            }
                        }

                    }
                }

            }


            catch (Exception exp)
            {
                ShowMessage("Error in Resting FarmView Modifications " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboFarmSection.SelectedItem != null)
                {
                    FarmSectionDetails farmViewSection = new FarmSectionDetails(comboFarmSection.SelectedItem.ToString(),comboYear.SelectedItem.ToString());
                    farmViewSection.ShowDialog();

                }
                else
                {
                    ShowMessage("Choose any Farm Section from Farm Section ", "Farm Planner - Info", MessageBoxIcon.Information);
                }

            }
            catch (Exception exp)
            {
                ShowMessage("Error in Before Loading the Selected Farm Section " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void dgvFarmView_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFarmView.SelectedRows.Count > 0)
            {
                btnClearSelection.Enabled = true;
                btnDeleteSection.Enabled = true;
            }
            else
            {
                btnClearSelection.Enabled = false;
                btnDeleteSection.Enabled = false;
            }
          
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvFarmView.SelectedRows.Count >0)
                {
                    Section sec = new Section(dgvFarmView.SelectedRows[0].Cells[0].Value.ToString());
                    if (FarmDAO.ClearFarmViewSection(sec))
                    {
                        DataGridViewRow currentRow = dgvFarmView.SelectedRows[0];
                        ClearSelectedFarmViewSection(currentRow);
                        listModifiedFarmSection.RemoveAll(s => s.Section == sec.SecName);
                        LoadFarmViewResult();
                    }
               
                }
            }
            catch (Exception exp)
            {
                ShowMessage("Error in Clearing the Selected Farm Section " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        private void ClearSelectedFarmViewSection(DataGridViewRow row)
        {
            try
            {
                for (int i = 1; i < row.Cells.Count; ++i)
                {
                    row.Cells[i].Style.BackColor = Color.White;
                    row.Cells[i].Style.ForeColor = Color.White;
                    row.Cells[i].Style.SelectionBackColor = Color.White;
                    row.Cells[i].Style.SelectionForeColor = Color.White;
                    row.Cells[i].Value = null;
                }
            }
            catch (Exception exp)
            {

            }
        }


        /*
         * 
         * alter table tbl_FarmView add quantity money default 0.0
            alter table tbl_FarmView add expectedOpt money default 0.0
            alter table tbl_FarmView add rate money default 0.0
            alter table tbl_FarmView add expense money default 0.0
            alter table tbl_FarmView add totalProfit money default 0.0

            alter table tbl_FarmView drop column totalProfit
         * 
         * 
         * 
         * */


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                Microsoft.Office.Interop.Excel.Range oRng = null;
                app.Visible = true;

                var excelSheets = workbook.Sheets as Microsoft.Office.Interop.Excel.Sheets; 

                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "FarmView - ALL - YEAR - " + comboYear.SelectedItem.ToString();
                worksheet.UsedRange.EntireRow.RowHeight = 30;

                oRng = worksheet.get_Range("A1", "M1");

                oRng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Wheat);
                oRng.EntireColumn.ColumnWidth = 13;
                


                for (int i = 1; i < dgvFarmView.Columns.Count + 1; i++)
                {
                   
                    worksheet.Cells[1, i] = dgvFarmView.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Beige);
                    worksheet.Cells[1, i].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black);
                    worksheet.Cells[1,i].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    worksheet.Cells[1, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                }

                
                for (int i = 0; i < dgvFarmView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvFarmView.Columns.Count; j++)
                    {
                        if (dgvFarmView.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvFarmView.Rows[i].Cells[j].Value.ToString();
                            if (j + 1 > 1)
                            {

                                worksheet.Cells[i + 2, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(dgvFarmView.Rows[i].Cells[j].Style.BackColor);
                                worksheet.Cells[i + 2, j + 1].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                                worksheet.Cells[i + 2, j + 1].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                worksheet.Cells[i+2, j+1].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                worksheet.UsedRange.EntireRow.RowHeight = 30;
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Blue);
                                worksheet.Cells[i + 2, j + 1].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                                worksheet.Cells[i + 2, j + 1].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                worksheet.Cells[i + 2, j + 1].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                worksheet.UsedRange.EntireRow.RowHeight = 30;
                            }
                            
                        }
                    }
                }

                int sheet = 1;
                double totalProfitPerSection = 0.0;
                double totalProfitAllSection = 0.0;
                double totalExpenseAllSection = 0.0;
                double totalExpensePerSection = 0.0;
               
                foreach (Section section in FarmDAO.GetAllSectionFromFarmView())
                {
                    List<FarmView> listFarmViewOfSection = FarmDAO.GetFarmDetailsSection(section.SecName,int.Parse(comboYear.SelectedItem.ToString()));
                    
                    var xlNewSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.Add(Type.Missing, workbook.Worksheets[sheet], Type.Missing, Type.Missing);
                    //worksheet = workbook.Sheets[];"Sheet"+sheet
                    worksheet = workbook.ActiveSheet;
                    xlNewSheet.Name = "FarmView - " + section.SecName +" - "+ comboYear.SelectedItem.ToString();
                    oRng = worksheet.get_Range("A1", "H1");
                    oRng.EntireColumn.ColumnWidth = 16;
                    xlNewSheet.UsedRange.EntireRow.RowHeight = 30;
                    bool HeaderAdded = false;
                    int row = 2;
                    totalProfitPerSection = 0.0;
                    totalExpensePerSection = 0.0;
                    foreach (FarmView objFarmView in listFarmViewOfSection)
                    {
                      
                        int pos = 1;
                        if (HeaderAdded == false)
                        {
                            foreach (var prop in objFarmView.GetType().GetProperties())
                            {
                                if (!prop.Name.Equals("Section"))
                                {
                                    xlNewSheet.Cells[1, pos] = prop.Name;
                                    xlNewSheet.Cells[1, pos].Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Beige);
                                    xlNewSheet.Cells[1, pos].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black);
                                    xlNewSheet.Cells[1, pos].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                    xlNewSheet.Cells[1, pos].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    pos++;
                                    HeaderAdded = true;
                                  
                                }
                            }
                        }
                         
                       
                            worksheet.Cells[row, 1] = objFarmView.Corp.ToString();
                            worksheet.Cells[row, 2] = objFarmView.StartDate.ToShortDateString();
                            worksheet.Cells[row, 3] = objFarmView.EndDate.ToShortDateString();
                            worksheet.Cells[row, 4] = objFarmView.Quantity.ToString();
                            worksheet.Cells[row, 5] = objFarmView.ExpectedOutput.ToString();
                            worksheet.Cells[row, 6] = objFarmView.Rate.ToString();
                            worksheet.Cells[row, 7] = objFarmView.Expense.ToString();
                            worksheet.Cells[row, 8] = objFarmView.TotalProfit.ToString();

                            if (objFarmView.Expense < objFarmView.TotalProfit)
                            {
                                xlNewSheet.Cells[row, 8].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Green);
                            }
                            else
                            {
                                xlNewSheet.Cells[row, 8].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);
                            }
                            
                            worksheet.UsedRange.EntireRow.RowHeight = 30;

                            totalProfitPerSection += objFarmView.TotalProfit;
                            totalExpensePerSection += objFarmView.Expense;

                            row++;
                        



                    }
                    worksheet.Cells[row, 7] = "Total Profit ";
                    worksheet.UsedRange.EntireRow.RowHeight = 30;
                    worksheet.Cells[row, 8] = totalProfitPerSection.ToString();

                    totalProfitAllSection += totalProfitPerSection;
                    totalExpenseAllSection += totalExpensePerSection;

                    if (totalExpensePerSection < totalProfitPerSection)
                    {
                        worksheet.Cells[row, 8].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Green);
                       
                    }
                    else
                    {
                        worksheet.Cells[row, 8].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);
                       
                    }
                    sheet++;
                    
                }

                List<FarmSummary> listFarmSumamry = FarmDAO.GetAllExpensesProfits();
                var xlChartSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelSheets.Add(Type.Missing, workbook.Worksheets[sheet], Type.Missing, Type.Missing);
                worksheet = workbook.ActiveSheet;
                xlChartSheet.Name = "FarmView - Summary";
                oRng = worksheet.get_Range("A1", "D1");
                oRng.EntireColumn.ColumnWidth = 20;
                xlChartSheet.UsedRange.EntireRow.RowHeight = 30;

                int newPos = 1;
                foreach (var prop in new FarmSummary().GetType().GetProperties())
                {
                    xlChartSheet.Cells[1, newPos] = prop.Name;
                    xlChartSheet.Cells[1, newPos].Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Beige);
                    xlChartSheet.Cells[1, newPos].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black);
                    xlChartSheet.Cells[1, newPos].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    xlChartSheet.Cells[1, newPos].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    newPos++;
                    
                }
                int newRow = 2;
                foreach (FarmSummary farmSummary in listFarmSumamry)
                {
                    xlChartSheet.Cells[newRow, 1] = farmSummary.CropName.ToString();
                    xlChartSheet.Cells[newRow, 2] = farmSummary.Period.ToString();
                    xlChartSheet.Cells[newRow, 3] = farmSummary.TotalExpense.ToString();
                    xlChartSheet.Cells[newRow, 4] = farmSummary.TotalProfit.ToString();
                    xlChartSheet.UsedRange.EntireRow.RowHeight = 30;

                    if (farmSummary.TotalExpense < farmSummary.TotalProfit)
                    {
                        xlChartSheet.Cells[newRow, 4].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Green);
                    }
                    else
                    {
                        xlChartSheet.Cells[newRow, 4].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);
                    }

                    newRow++;
                }



                worksheet.Cells[newRow, 3].Font.Size = 20;
                worksheet.Cells[newRow, 4].Font.Size = 20;

                worksheet.Cells[newRow, 3] = totalExpenseAllSection.ToString();
                worksheet.Cells[newRow, 4] = totalProfitAllSection.ToString();

                if (totalExpenseAllSection < totalProfitAllSection)
                {
                    worksheet.Cells[newRow, 4].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Green);
                    worksheet.Cells[newRow, 4].Font.Size = 20;
                    worksheet.Cells[newRow, 3].Font.Size = 12;
                }
                else
                {
                    worksheet.Cells[newRow, 4].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Red);
                    worksheet.Cells[newRow, 4].Font.Size = 12;
                    worksheet.Cells[newRow, 3].Font.Size = 20;
                }

                Microsoft.Office.Interop.Excel.Range chartRange;

                Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)xlChartSheet.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(450, 50, 400, 300);
                Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;

                newRow--;

                string startRange = "A" + newRow;
                string lastRange = "D" + newRow;


                chartRange = xlChartSheet.get_Range("A1", lastRange);
                chartPage.SetSourceData(chartRange, Microsoft.Office.Interop.Excel.XlRowCol.xlColumns);
                chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnStacked;
                chartPage.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabelAndPercent,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                

                Microsoft.Office.Interop.Excel.Worksheet currentSheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets[1];
                currentSheet.Select(Type.Missing);

                FileInfo fileinfo = new FileInfo("C:\\Export.xlsx");

                if (fileinfo.Exists)
                {
                    fileinfo.Delete();
                }



                workbook.SaveAs("C:\\Export.xlsx", Type.Missing, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                app.DisplayAlerts = false;
            }
            catch (Exception exp)
            {
                ShowMessage("Error in Exporting Data to Excel " + exp.Message, "Farm Planner - Error", MessageBoxIcon.Error);
            }
        }

        void chartPage_SeriesChange(int SeriesIndex, int PointIndex)
        {
            throw new NotImplementedException();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure want to Permanantly Deleted the Section !!! ","Delete Section",MessageBoxButtons.YesNo))
            {
                if (dgvFarmView.SelectedRows.Count > 0)
                {
                    Section sec = new Section(dgvFarmView.SelectedRows[0].Cells[0].Value.ToString());
                    if (FarmDAO.DeleteSection(sec))
                    {
                        DataGridViewRow currentRow = dgvFarmView.SelectedRows[0];
                        ClearSelectedFarmViewSection(currentRow);
                        listModifiedFarmSection.RemoveAll(s => s.Section == sec.SecName);
                        comboFarmSection.Items.Remove(sec.SecName);
                        dgvFarmView.Rows.Remove(currentRow);
                        LoadFarmViewResult();
                    }

                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listModifiedFarmSection.Count > 0)
            {
                DialogResult check = MessageBox.Show("Do You want to Save the Modified FarmView details", "Save FarmView", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (check == DialogResult.Yes)
                {
                    button3_Click(sender, new EventArgs());
                }
            }            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSelectionCorps();
            ClearFarmViewColor();
            LoadFarmViewResult();
         
        }
    }
}
