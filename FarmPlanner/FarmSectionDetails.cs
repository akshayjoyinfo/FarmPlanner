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
namespace FarmPlanner
{
    public partial class FarmSectionDetails : Form
    {
        string selectedFarmSection = string.Empty;
        List<FarmView> listFarmViewSelected = new List<FarmView>();
        List<Double> listProfits = new List<double>();

        public FarmSectionDetails(string farmSection)
        {
            this.selectedFarmSection = farmSection;
            InitializeComponent();
            this.Text = this.Text +" "+ farmSection;
        }

        protected void LoadDetailsFarmSection(string farmSection)
        {
            try
            {
                listFarmViewSelected = FarmDAO.GetFarmDetailsSection(farmSection);
                int pos = 0;
                double totalProfit = 0.0;
                foreach (FarmView obj in listFarmViewSelected)
                {
                    dgvFarmViewSection.Rows.Add();
                    
                    dgvFarmViewSection.Rows[pos].Cells[0].Value = obj.Corp;
                    dgvFarmViewSection.Rows[pos].Cells[1].Value = obj.StartDate.Month +"/" + obj.StartDate.Year;
                    dgvFarmViewSection.Rows[pos].Cells[2].Value = obj.EndDate.Month + "/" + obj.EndDate.Year;
                    dgvFarmViewSection.Rows[pos].Cells[3].Value = obj.Quantity.ToString();
                    dgvFarmViewSection.Rows[pos].Cells[4].Value = obj.ExpectedOutput.ToString();
                    dgvFarmViewSection.Rows[pos].Cells[5].Value = obj.Rate.ToString();
                    dgvFarmViewSection.Rows[pos].Cells[6].Value = obj.Expense.ToString();
                    dgvFarmViewSection.Rows[pos].Cells[7].Value = obj.TotalProfit.ToString();

                    

                    if (obj.TotalProfit > obj.Expense)
                    {
                        dgvFarmViewSection.Rows[pos].Cells[7].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        dgvFarmViewSection.Rows[pos].Cells[7].Style.ForeColor = Color.Red;
                    }

                    pos++;
                    
                }

                txtTotalProfit.Text = CalculateProfits().ToString();

               
            }
            catch (Exception exp)
            {
                ShowMessage("Error in LoadDetailsFarmSecrion " + exp.Message, "Farm Planner- Section Details", MessageBoxIcon.Error);
            }
        }
        protected void ShowMessage(string message, string title, MessageBoxIcon IconType)
        {
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

        private void FarmSectionDetails_Load(object sender, EventArgs e)
        {
            LoadDetailsFarmSection(selectedFarmSection);
        }

        private void dgvFarmViewSection_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        protected double CalculateProfits()
        {
            double profit = 0.0;
            try
            {
                
                for (int i = 0; i <= dgvFarmViewSection.Rows.Count-2; ++i)
                {
                    if (dgvFarmViewSection.Rows[i].Cells[7].Value != null)
                    {
                        profit = profit + double.Parse(dgvFarmViewSection.Rows[i].Cells[7].Value.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                profit = 0.0;
                ShowMessage("Error while Calculating Profit " + exp.Message, "Farm Planner- Section Details", MessageBoxIcon.Error);

            }
            return profit;
        }

        private void dgvFarmViewSection_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvFarmViewSection.Columns["Quantity"].Index)
            {
                dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "";
                double newInteger;

                if (dgvFarmViewSection.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(),
                    out newInteger))
                {
                    e.Cancel = true;
                    dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "Floating Point Numbers Only";
                }
            }
            if (e.ColumnIndex == dgvFarmViewSection.Columns["ExpectedOutput"].Index)
            {
                dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "";
                double newInteger;

                if (dgvFarmViewSection.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(),
                    out newInteger))
                {
                    e.Cancel = true;
                    dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "Floating Point Numbers Only";
                }
            }
            if (e.ColumnIndex == dgvFarmViewSection.Columns["Rate"].Index)
            {
                dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "";
                double newInteger;

                if (dgvFarmViewSection.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(),
                    out newInteger))
                {
                    e.Cancel = true;
                    dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "Floating Point Numbers Only";
                }
            }
            if (e.ColumnIndex == dgvFarmViewSection.Columns["Expense"].Index)
            {
                dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "";
                double newInteger;

                if (dgvFarmViewSection.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(),
                    out newInteger)) // || newInteger <= 0.0
                {
                    e.Cancel = true;
                    dgvFarmViewSection.Rows[e.RowIndex].ErrorText = "Floating Point Numbers Only";
                }
            }
        }

        private void dgvFarmViewSection_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double totalProfit = 0.0;
                if (dgvFarmViewSection.Rows[e.RowIndex].Cells[3].Value != null && dgvFarmViewSection.Rows[e.RowIndex].Cells[4].Value != null && dgvFarmViewSection.Rows[e.RowIndex].Cells[5].Value != null && dgvFarmViewSection.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    double profitPerRow = 0.0;
                    double qty = double.Parse(dgvFarmViewSection.Rows[e.RowIndex].Cells[3].Value.ToString());
                    double expectOpt = double.Parse(dgvFarmViewSection.Rows[e.RowIndex].Cells[4].Value.ToString());
                    double rate = double.Parse(dgvFarmViewSection.Rows[e.RowIndex].Cells[5].Value.ToString());
                    double expense = double.Parse(dgvFarmViewSection.Rows[e.RowIndex].Cells[6].Value.ToString());

                    profitPerRow = (qty * expectOpt * rate) - expense;

                    dgvFarmViewSection.Rows[e.RowIndex].Cells[7].Value = profitPerRow.ToString();
                    if (profitPerRow > expense)
                    {
                        dgvFarmViewSection.Rows[e.RowIndex].Cells[7].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        dgvFarmViewSection.Rows[e.RowIndex].Cells[7].Style.ForeColor = Color.Red;
                    }

                    // double totalProfit = 0.0;
                    // totalProfit += profitPerRow;
                    txtTotalProfit.Text = CalculateProfits().ToString();
                    
                }
                

            }
            catch (Exception exp)
            {
                ShowMessage("Please Enter only Flaoting Point Numbers:-    " + exp.Message, "Farm Planner- Section Details", MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<FarmView> listFarmView = new List<FarmView>();

                for (int i = 0; i < dgvFarmViewSection.Rows.Count - 1; i++)
                {

                    string[] dates = dgvFarmViewSection.Rows[i].Cells[2].Value.ToString().Split('/');
                    string[] sdates = dgvFarmViewSection.Rows[i].Cells[1].Value.ToString().Split('/');
                    string endDate = dates[0] + "/28/" + dates[1];
                    string sDate = sdates[0] + "/1/" + sdates[1];
                    listFarmView.Add(new FarmView(selectedFarmSection, dgvFarmViewSection.Rows[i].Cells[0].Value.ToString(), DateTime.Parse(sDate),
                        DateTime.Parse(endDate), double.Parse(dgvFarmViewSection.Rows[i].Cells[3].Value.ToString()), double.Parse(dgvFarmViewSection.Rows[i].Cells[4].Value.ToString()),
                        double.Parse(dgvFarmViewSection.Rows[i].Cells[5].Value.ToString()),double.Parse(dgvFarmViewSection.Rows[i].Cells[6].Value.ToString()),double.Parse(dgvFarmViewSection.Rows[i].Cells[7].Value.ToString())));
                }


                FarmDAO.UpdateExpenseFarmViewSection(listFarmView);

                ShowMessage("Successfully Saved the Expense Details","Save Expense" ,MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                ShowMessage("Error while Saving the Expense Details   " + exp.Message, "Farm Planner- Section Details", MessageBoxIcon.Error);
            }
        }

    }
}
