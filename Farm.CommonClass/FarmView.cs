using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farm.CommonClass
{
    public class FarmView
    {
        string section;
        string corps;
        DateTime startDate;
        DateTime endDate;

        public string Corp
        {
            get { return corps; }
            set { corps = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public string Section
        {
            get { return section; }
            set { section = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        double quantity;

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        double expectedOutput;

        public double ExpectedOutput
        {
            get { return expectedOutput; }
            set { expectedOutput = value; }
        }
        double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        double expense;

        public double Expense
        {
            get { return expense; }
            set { expense = value; }
        }
        double totalProfit;

        public double TotalProfit
        {
            get { return totalProfit; }
            set { totalProfit = value; }
        }

        public FarmView(string sec, string corp, DateTime sDate, DateTime eDate)
        {
            this.section = sec;
            this.corps = corp;
            this.startDate = sDate;
            this.endDate = eDate;

        }

        public FarmView(string sec, string corp, DateTime sDate, DateTime eDate, double qty, double expOpt, double rate, double exp, double totProfit)
        {
            this.section = sec;
            this.corps = corp;
            this.startDate = sDate;
            this.endDate = eDate;
            this.quantity = qty;
            this.expectedOutput = expOpt;
            this.rate = rate;
            this.expense = exp;
            this.totalProfit = totProfit;

        }

    }
}
