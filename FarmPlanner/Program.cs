using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FarmPlanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CheckDBSettings())
            {
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("Database Not Configured ! Please try again");
            }
        }
        static bool CheckDBSettings()
        {
            bool dbCreated = false;
            try
            {
                RegistryKey rkey = Registry.LocalMachine;
                RegistryKey FarmPlannerKey = rkey.OpenSubKey(@"SOFTWARE\SF\FarmPlanner", true);
                if (FarmPlannerKey == null)
                {
                    FarmDBSettings frmFarmDB = new FarmDBSettings();
                    frmFarmDB.ShowDialog();
                    dbCreated = true;
                }
                dbCreated = true;
                
            }
            catch (UnauthorizedAccessException exp)
            {
                dbCreated = false;
            }
            return dbCreated;
        }

    }
}
