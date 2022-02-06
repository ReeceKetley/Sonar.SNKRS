using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32;

namespace SonarSNKRS
{
    public partial class Login : TemplateForm
    {
        public bool Result { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private void addProxys()
        {
            SNKRSActions.DownloadBackUpProxys();
            SNKRSActions.AddBanTests();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Thread x = new Thread(addProxys);
            x.Start();
            var username = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Username", "");
            if (username == null)
            {
                username = "";
            }
            var password = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Password", "");
            if (password == null)
            {
                password = "";
            }
            txtEmail.Text = username.ToString();
            txtPassword.Text = password.ToString();
            spinner.Visible = false;
        }

        public static void LoginChecker()
        {
            string username = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Username", "").ToString();
            string password = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Password", "").ToString();
            for (; ; )
            {
                if (ApiLogin.Login(ApiLogin.GetUDID(), username, password) != LoginResponseCode.Sucess)
                {
                    //Thread.Sleep(5000);
                    //Environment.Exit(10);
                }
                Thread.Sleep(300000);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            APIUser.LoggedIn = true;
            APIUser.Password = "lollololol";
            APIUser.MaxAccounts = 1000;
            APIUser.UserLevel = UserLevel.Business;
            var form = new MainForm();
            form.Show();
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "Username", txtEmail.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "Password", txtPassword.Text);

            Thread loginThread = new Thread(LoginChecker);
            loginThread.Start();
            return;
            txtEmail.Enabled = false;
            txtEmail.Enabled = false;
            spinner.Visible = true;
            spinner.Spinning = true;
            string message = "";
            var result = ApiLogin.Login(ApiLogin.GetUDID(), txtEmail.Text, txtPassword.Text);
            if (result == LoginResponseCode.Sucess || result == LoginResponseCode.LinkedDevice)
            {

                Result = false;
                Visible = false;
                return;
            }
            if (result == LoginResponseCode.InvalidCredentials)
            {
                message = "Invalid username/password";
            }
            if (result == LoginResponseCode.MaxDevices)
            {
                message = "To many devices please remove one on SonarClOUD";
            }
            if (result == LoginResponseCode.HttpError)
            {
                message = "Http Error (Connection problem)";
            }
            if (result == LoginResponseCode.JsonFail)
            {
                message = "Failed to decode response";
            }


            Result = false;
            MetroMessageBox.Show(this, "Error: " + message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEmail.Enabled = true;
            txtEmail.Enabled = true;
            spinner.Visible = false;
            spinner.Spinning = false;
            BringToFront();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            spinner.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            spinner.Visible = false;
        }


    }
}
