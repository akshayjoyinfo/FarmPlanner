using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farm.CommonClass
{
   public class FarmSummary
    {
        string cropName;

        public string CropName
        {
            get { return cropName; }
            set { cropName = value; }
        }
        
        int period;

        public int Period
        {
            get { return period; }
            set { period = value; }
        }

        double totalexpense;

        public double TotalExpense
        {
            get { return totalexpense; }
            set { totalexpense = value; }
        }

        double totalProfit;

        public double TotalProfit
        {
            get { return totalProfit; }
            set { totalProfit = value; }
        }

        public FarmSummary(string crop, int period, double expense , double profit)
        {
            this.cropName = crop;
            this.period = period;
            this.totalexpense = expense;
            this.totalProfit = profit;

        }
        public FarmSummary()
        {

        }

    }
}
