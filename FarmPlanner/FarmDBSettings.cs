using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Farm.BusinessLayer;
namespace FarmPlanner
{
    public partial class FarmDBSettings : Form
    {
        public FarmDBSettings()
        {
            InitializeComponent();
        }

        private void FarmDBSettings_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                txtDbUser.Enabled = true;
                txtDBPassword.Enabled = true;
            }
            else
            {
                checkBox2.Checked = true;
                txtDbUser.Enabled = false;
                txtDBPassword.Enabled = false;
            }

            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                txtDbUser.Enabled = false;
                txtDBPassword.Enabled = false;
            }
            else
            {
                checkBox1.Checked = true;
                txtDbUser.Enabled = true;
                txtDBPassword.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionSTRING;
            RegistryKey companyKey = Registry.LocalMachine;
            RegistryKey FarmPlannerKey;

            try
            {

                if (!string.IsNullOrEmpty(txtDbServer.Text.ToString()) || !string.IsNullOrEmpty(txtDbName.Text.ToString()))
                {
                    if (checkBox1.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtDbUser.Text.ToString()) || !string.IsNullOrEmpty(txtDBPassword.Text.ToString()))
                        {
                            connectionSTRING = "Data Source=" + txtDbServer.Text + "; Initial Catalog =" + txtDbName.Text + ";uid=" + txtDbUser.Text + ";pwd=" + txtDBPassword.Text;
                            companyKey = Registry.LocalMachine.CreateSubKey("SF");
                            FarmPlannerKey = companyKey.CreateSubKey("FarmPlanner");
                            FarmPlannerKey.SetValue("DB_CONN_STRING", connectionSTRING);
                            FarmPlannerKey.SetValue("DB_AUTHENTICATION", "SQLSERVER");
                            companyKey.Close();

                            if (FarmDAO.InsertDB())
                            {
                                MessageBox.Show("Successfully Created Database !!");
                                this.Close();
                                MainForm frmMain = new MainForm();
                                frmMain.Show();

                            }
                            else
                            {
                                MessageBox.Show("DB not Configured");
                                this.Close();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Username Passwords are mandatory for SQL Server Authentication !!");
                        }
                    }

                    else if (checkBox2.Checked)
                    {
                        connectionSTRING = "Data Source=" + txtDbServer.Text + "; Initial Catalog =" + txtDbName.Text + ";Integrated Security=True";
                        companyKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\SF\\FarmPlanner",RegistryKeyPermissionCheck.ReadWriteSubTree);
                        companyKey.OpenSubKey("SOFTWARE\\SF\\FarmPlanner", true);
                        companyKey.SetValue("DB_CONN_STRING", connectionSTRING);
                        companyKey.SetValue("DB_AUTHENTICATION", "WINDOWS");
                        companyKey.Close();
                        if (FarmDAO.InsertDB())
                        {
                            MessageBox.Show("Successfully Created Database !!");
                            this.Close();
                            MainForm frmMain = new MainForm();
                            frmMain.Show();

                        }
                        else
                        {
                            MessageBox.Show("DB not Configured");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose any on eof SQL Server / Windows Authentication !!");
                    }
                }
                else
                {
                    MessageBox.Show("All the Fields are mandatory !!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error Occured setting Database Connection Settings " + exp.Message);
                this.Close();

            }
        }
    }
}
