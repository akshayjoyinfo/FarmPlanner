using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farm.CommonClass
{
    public class Section
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string secName;

        public string SecName
        {
            get { return secName; }
            set { secName = value; }
        }

        public Section(string sName)
        {
            this.secName = sName;

        }
        
      


    }
}
