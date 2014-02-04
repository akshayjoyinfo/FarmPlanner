using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farm.CommonClass
{
   public class FarmExpense
    {
        string section;

        public string Section
        {
            get { return section; }
            set { section = value; }
        }
        string corp;

        public string Corp
        {
            get { return corp; }
            set { corp = value; }
        }
        float quantity;

        public float Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        float expectedOutput;

        public float ExpectedOutput
        {
            get { return expectedOutput; }
            set { expectedOutput = value; }
        }
        float rate;

        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        float expense;

        public float Expense
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

        public FarmExpense(string sec, string cor, float qty, float expOpt, float rate, float exp, double totExp)
        {
            this.section = sec;
            this.corp = cor;
            this.quantity = qty;
            this.expectedOutput = expOpt;
            this.rate = rate;
            this.expense = exp;
            this.totalProfit = totExp;

        }


    }
}
