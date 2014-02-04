using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace Farm.DataLayer
{
    public class DbConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = string.Empty;
            SqlConnection conn = null;
            try
            {
                RegistryKey rkey = Registry.LocalMachine;
                RegistryKey FarmPlannerKey = rkey.OpenSubKey(@"SOFTWARE\SF\FarmPlanner", true);
                if (FarmPlannerKey != null)
                {
                    connectionString = FarmPlannerKey.GetValue("DB_CONN_STRING").ToString();
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    return conn;
                }
                
                
                return conn;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void CloseConnection(SqlConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

    }
}
