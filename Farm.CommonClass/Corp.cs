using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farm.CommonClass
{
    public class Corp
    {
        int corpId;
        string name;
        string color;
        int period;

        public int CorpId
        {
            get { return corpId; }
            set { corpId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Period
        {
            get { return period; }
            set { period = value; }
        }

        public Corp(string na,string colr)
        {
            this.name = na;
            this.color = colr;
        }
        public Corp(string na, string colr, int per)
        {
            this.name = na;
            this.color = colr;
            this.period = per;
        }
    }
}
