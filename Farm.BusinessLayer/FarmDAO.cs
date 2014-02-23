using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Farm.CommonClass;
using System.Data.SqlClient;
using Farm.DataLayer;
using System.IO;
namespace Farm.BusinessLayer
{
    public class FarmDAO
    {
        public static List<Section> GetAllSection()
        {
            List<Section> listSections = new List<Section>();
            string sqlString = "select Name from tbl_Section";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(sqlString, DbConnection.GetConnection());
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    listSections.Add(new Section(myReader["Name"].ToString()));
                }

            }
            catch (Exception exp) { throw exp; }
            finally { DbConnection.CloseConnection(command.Connection); }

            return listSections;
        }

        public static List<FarmSummary> GetAllExpensesProfits()
        {
             List<FarmSummary> listFarmSummary = new List<FarmSummary>();
             string sqlString = " select a.CorpsName , b.Period , ISNULL(SUM( expense ),0) as 'TotalExpense',  ISNULL(SUM(totalProfit),0)  as 'TotalProfit'  from tbl_FarmView a inner join tbl_Corps b  on a.CorpsName = b.Name group by a.CorpsName ,b.Period ";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(sqlString, DbConnection.GetConnection());
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    listFarmSummary.Add(new FarmSummary(myReader["CorpsName"].ToString(),int.Parse(myReader["Period"].ToString()),double.Parse(myReader["TotalExpense"].ToString()),double.Parse(myReader["TotalProfit"].ToString())));
                }

            }
            catch (Exception exp) { throw exp; }
            finally { DbConnection.CloseConnection(command.Connection); }

            return listFarmSummary;
        }

        /*
         * 
         use restDB;

            if not exists (select * from sysobjects where name in ('tbl_Corps','tbl_Section','tbl_FarmView') and xtype='U')
              create table tbl_Corps (CorpId int primary key identity(100,1), Name varchar(45), Period int, Color varchar(45));
            create table tbl_Section (SectionId int primary key identity(1,1), Name varchar(45)) 
            create table tbl_FarmView(SectionName varchar(45), CorpsName varchar(45), StartDate date, EndDate date, quantity money, expectedOpt money,rate money, expense money, totalProfit money);

            go

 
         */


        public static bool InsertDB()
        {
            bool status = false;
            SqlCommand command = null;
            try
            {
                FileInfo fileInfo = new FileInfo("FarmSQL.sql");
                if (fileInfo.Exists)
                {
                    using (StreamReader sr = new StreamReader("FarmSQL.sql"))
                    {
                        String line = sr.ReadToEnd();
                        command = new SqlCommand(line, DbConnection.GetConnection());
                        int count = command.ExecuteNonQuery();
                        status = true;
                    }

                }
                else
                {
                    status = false;
                }

            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }


        public static bool CheckFarmViewExist(FarmView farmViewObj)
        {
            bool status = false;
            string checkCorpExist = "select COUNT(*) from tbl_FarmView where SectionName='" + farmViewObj.Section + "' and (('" + farmViewObj.StartDate.ToShortDateString() + "' between StartDate and EndDate) or ('" + farmViewObj.EndDate.ToShortDateString() + "' between StartDate and EndDate))";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(checkCorpExist, DbConnection.GetConnection());
                myReader = command.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = int.Parse(myReader[0].ToString());

                }
                if (count == 0)
                    status = true;
                else
                    status = false;


            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }

        public static bool DeleteSection(Section sectionObj)
        {
            bool status = false;
            string deleteFamView = "DELETE from [tbl_FarmView] where SectionName= '" + sectionObj.SecName + "'";
            string deleteSection = "DELETE from tbl_Section where Name= '" + sectionObj.SecName  + "'";
            SqlCommand command = null;
            int count = 0;

            try
            {
                command = new SqlCommand(deleteFamView, DbConnection.GetConnection());
                count = command.ExecuteNonQuery();

                command = new SqlCommand(deleteSection, DbConnection.GetConnection());
                count = command.ExecuteNonQuery();

                if (count > 0)
                    status = true;
                else
                    status = false;


            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }



        public static List<Section> GetAllSectionFromFarmView()
        {
            List<Section> listSections = new List<Section>();
            string sqlString = "SELECT distinct SectionName from tbl_FarmView";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(sqlString, DbConnection.GetConnection());
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    listSections.Add(new Section(myReader["SectionName"].ToString()));
                }

            }
            catch (Exception exp) { throw exp; }
            finally { DbConnection.CloseConnection(command.Connection); }

            return listSections;
        }

   


        public static List<Corp> GetAllCorps()
        {
            List<Corp> listCorps = new List<Corp>();
            string sqlString = "select Name,Period,Color from tbl_Corps";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(sqlString, DbConnection.GetConnection());
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    listCorps.Add(new Corp(myReader["Name"].ToString(),myReader["Color"].ToString(),int.Parse(myReader["Period"].ToString())));
                }

            }
            catch (Exception exp) { throw exp; }
            finally { DbConnection.CloseConnection(command.Connection); }

            return listCorps;

        }

        public static List<FarmView> GetFarmDetailsSection(string farmSection, int planYear)
        {

            List<FarmView> listFarmViewSection = new List<FarmView>();
            string sqlString = "";
            SqlCommand command = null;
            SqlDataReader myReader;
            try
            {
                sqlString = "select SectionName, CorpsName, StartDate, EndDate, quantity, expectedOpt, rate, expense, totalProfit  from tbl_FarmView where SectionName='" + farmSection + "' and (DATEPART(YEAR,StartDate) = "+ planYear +" or DATEPART(YEAR,EndDate)= "+planYear +")";
                command = new SqlCommand(sqlString, DbConnection.GetConnection());
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    double qty = ConvertToDouble(myReader["quantity"].ToString());
                    double expOpt = ConvertToDouble(myReader["expectedOpt"].ToString());
                    double rate = ConvertToDouble(myReader["rate"].ToString());
                    double expense = ConvertToDouble(myReader["expense"].ToString());
                    double totProfit = ConvertToDouble(myReader["totalProfit"].ToString());

                    listFarmViewSection.Add(new FarmView(myReader["SectionName"].ToString(), myReader["CorpsName"].ToString(), DateTime.Parse(myReader["StartDate"].ToString()), DateTime.Parse(myReader["EndDate"].ToString()), qty,
                        expOpt, rate, expense, totProfit));
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return listFarmViewSection;
        }

        private static double ConvertToDouble(string p)
        {
            try
            {
                return Convert.ToDouble(p);
            }
            catch (Exception exp)
            {
                return 0.0;
            }
        }

        public static bool UpdateExpenseFarmViewSection(List<FarmView> listFarmView)
        {
            bool status = false;
            SqlCommand command = null;
              try
                {
                    foreach(FarmView farmViewObj in listFarmView)
                    {
                        string addCorps = "update tbl_FarmView set quantity=" + farmViewObj.Quantity + ", expectedOpt=" + farmViewObj.ExpectedOutput + ", rate=" + farmViewObj.Rate +

                                           ", expense = " + farmViewObj.Expense + ", totalProfit = " + farmViewObj.TotalProfit + " where SectionName='" + farmViewObj.Section + "' and CorpsName= '"+farmViewObj.Corp+"' and StartDate = '"+farmViewObj.StartDate.ToShortDateString() +"' and EndDate = '" +farmViewObj.EndDate.ToShortDateString() +"'" ;

                        // SectionName, CorpsName, StartDate, EndDate
              
                            command = new SqlCommand(addCorps, DbConnection.GetConnection());
                            int count = command.ExecuteNonQuery();
                            if (count > 0)
                                status = true;
                            else
                                status = false;
                
                    }
                }
                  catch (Exception exp)
                  {
                      status = false;
                      throw exp;

                  }
                finally { DbConnection.CloseConnection(command.Connection); }

            return status;
        }



        public static List<FarmView> GetAllFarmSections(int startYear)
        {
            List<FarmView> listFarmViews = new List<FarmView>();
            string sqlString = "select SectionName, CorpsName, StartDate, EndDate from tbl_FarmView where DATEPART(YEAR,StartDate) = " + startYear + " or DATEPART(YEAR,EndDate)= "+ startYear;
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(sqlString, DbConnection.GetConnection());
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    listFarmViews.Add(new FarmView(myReader["SectionName"].ToString(), myReader["CorpsName"].ToString(), DateTime.Parse(myReader["StartDate"].ToString()), DateTime.Parse(myReader["EndDate"].ToString())));
                }

            }
            catch (Exception exp) { throw exp; }
            finally { DbConnection.CloseConnection(command.Connection); }

            return listFarmViews;

        }

        public static bool CheckCorpExist(Corp corpObj)
        {
            bool status = false;
            string checkCorpExist = "select COUNT(*) AS Count from tbl_Corps where Name= '" + corpObj.Name + "' OR Color='" + corpObj.Color + "'";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(checkCorpExist, DbConnection.GetConnection());
                myReader = command.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = int.Parse(myReader["Count"].ToString());
                    
                }
                if (count == 0)
                    status = false;
                else
                    status = true;


            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }

        public static bool DeleteCorp(Corp corpObj)
        {
            bool status = false;
            string checkCorpExist = "DELETE from tbl_Corps where Name= '" + corpObj.Name + "'";
            SqlCommand command = null;
            int count = 0;

            try
            {
                command = new SqlCommand(checkCorpExist, DbConnection.GetConnection());
                count = command.ExecuteNonQuery();
                
               
                if (count > 0)
                    status = true;
                else
                    status = false;


            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }

        public static bool ClearFarmViewSection(Section section)
        {
            bool status = false;
            string clearSection = "DELETE from tbl_FarmView where SectionName= '" + section.SecName + "'";
            SqlCommand command = null;
            int count = 0;

            try
            {
                command = new SqlCommand(clearSection, DbConnection.GetConnection());
                count = command.ExecuteNonQuery();


                if (count > 0)
                    status = true;
                else
                    status = false;
            }
            catch (Exception exp)
            {

            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }

       // public static bool SaveExpenseDetails(List<FarmExpense> listFarmExpense)
        //{
        //    string addCorps = "INSERT into tbl_Corps(Name, Period, Color) values('" + corpObj.Name + "'," + corpObj.Period + ",'" + corpObj.Color + "')";
        //    SqlCommand command = null;
        //    SqlDataReader reader = null;
        //    bool status = false;

        //    try
        //    {

        //    }catch(Exception exp)
        //    {
        //        status = false;
        //        throw exp;
        //    }
        //    finally { DbConnection.CloseConnection(command.Connection); }

        //}

        public static bool CheckCorpExistWithoutColor(Corp corpObj)
        {
            bool status = false;
            string checkCorpExist = "select COUNT(*) AS Count from tbl_Corps where Name= '" + corpObj.Name + "'";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(checkCorpExist, DbConnection.GetConnection());
                myReader = command.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = int.Parse(myReader["Count"].ToString());

                }
                if (count == 0)
                    status = false;
                else
                    status = true;


            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }


        public static bool AddCorps(Corp corpObj)
        {
            bool status = false;
            string addCorps = "INSERT into tbl_Corps(Name, Period, Color) values('"+corpObj.Name+"',"+corpObj.Period+",'"+corpObj.Color+"')";
            SqlCommand command = null;
            
            try
            {
                command = new SqlCommand(addCorps, DbConnection.GetConnection());
                int count= command.ExecuteNonQuery();
                if (count > 0)
                    status = true;
                else
                    status = false;
            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
               
            }
            finally { DbConnection.CloseConnection(command.Connection);  }

            return status;
        }

        public static bool AddSections(Section secObj)
        {
            bool status = false;
            string addCorps = "INSERT into tbl_Section(Name) values('" + secObj.SecName + "')";
            SqlCommand command = null;

            try
            {
                command = new SqlCommand(addCorps, DbConnection.GetConnection());
                int count = command.ExecuteNonQuery();
                if (count > 0)
                    status = true;
                else
                    status = false;
            }
            catch (Exception exp)
            {
                status = false;
                throw exp;

            }
            finally { DbConnection.CloseConnection(command.Connection); }

            return status;
        }
        
        public static bool EditCorps(Corp corpObj,string itemName)
        {
            bool status = false;
            string addCorps = "update tbl_Corps set Name='" + corpObj.Name + "', Period=" + corpObj.Period + ", Color='" + corpObj.Color + "' where Name='"+itemName +"'";
            SqlCommand command = null;

            try
            {
                command = new SqlCommand(addCorps, DbConnection.GetConnection());
                int count = command.ExecuteNonQuery();
                if (count > 0)
                    status = true;
                else
                    status = false;
            }
            catch (Exception exp)
            {
                status = false;
                throw exp;

            }
            finally { DbConnection.CloseConnection(command.Connection); }

            return status;
        }

        public static bool DeleteCorpFromFarmView(Corp corpObj)
        {
            bool status = false;
            SqlCommand command = null;
            string delCorpQuery = "";
            try
            {
                delCorpQuery = "DELETE from tbl_FarmView where CorpsName='" + corpObj.Name + "'";
                command = new SqlCommand(delCorpQuery, DbConnection.GetConnection());
                int count = command.ExecuteNonQuery();

                if(count >0)
                   status = true;
                else
                    status = false;

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }

       
        public static bool AddFarmDetails(List<FarmView> listFarmView)
        {
            bool status = false;
            SqlCommand command = null;
            string addCorps = "";
            try
           {
               command = new SqlCommand(addCorps, DbConnection.GetConnection());
                  

            foreach (FarmView farmObj in listFarmView)
            {

                string startDate = farmObj.StartDate.ToShortDateString();
                string endDate = farmObj.EndDate.ToShortDateString();
                addCorps = "INSERT into tbl_FarmView(SectionName, CorpsName, StartDate, EndDate) values('" + farmObj.Section + "','" + farmObj.Corp + "','" + startDate + "','" + endDate + "')";
                

                  command = new SqlCommand(addCorps, DbConnection.GetConnection());
                  command.ExecuteNonQuery();
                  status = true;

            }

           }
            catch (Exception exp)
            {
                status = false;
                throw exp;

            }
  
            finally { DbConnection.CloseConnection(command.Connection); }
            
            return status;
        }

        public static bool AddFarmDetails(FarmView farmObj)
        {
            bool status = false;
            
            string startDate = farmObj.StartDate.ToShortDateString();
            string endDate = farmObj.EndDate.ToShortDateString();
            string addCorps = "INSERT into tbl_FarmView(secName, corpName, startDate, endDate) values('" + farmObj.Section + "','" + farmObj.Corp + "','" + startDate + "','" +endDate +"')";
            SqlCommand command = null;

            try
            {
                command = new SqlCommand(addCorps, DbConnection.GetConnection());
                status = true;
            }
            catch (Exception exp)
            {
                status = false;
                throw exp;

            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }

        public static bool CheckSectionExist(Section sectionObj)
        {
            bool status = false;
            string checkCorpExist = "select COUNT(*) AS Count from tbl_Section where Name= '" + sectionObj.SecName + "'";
            SqlCommand command = null;
            SqlDataReader myReader;

            try
            {
                command = new SqlCommand(checkCorpExist, DbConnection.GetConnection());
                myReader = command.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = int.Parse(myReader["Count"].ToString());

                }
                if (count == 0)
                    status = false;
                else
                    status = true;


            }
            catch (Exception exp)
            {
                status = false;
                throw exp;
            }
            finally { DbConnection.CloseConnection(command.Connection); }
            return status;
        }




    }
}
