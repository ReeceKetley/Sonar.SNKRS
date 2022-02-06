using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ServiceModel.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MetroFramework;
using Microsoft.Win32;
using SonarSNKRS.Forms;

namespace SonarSNKRS
{
    public static class NikeCheck
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        public static bool Main()
        {
            bool isDebuggerPresent = false;
            return CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);

        }
    }
    public class AppSystem
    {
        private static bool nikeUs;
        private static MainForm form;
        static Mutex mutex = new Mutex(false, "412d51d9-fb19-47a3-x453-d78564f5ba66");
        private static string i = "vFPy2ZQJxoGfW6ts1E/PWG3Dpa/S84aUNUe1N2WMLKQ=";
        public static void Main()
        {
            if (NikeCheck.Main())
            {
                APIUser.iBool = false;
                nikeUs = false;
            }

            if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                Console.WriteLine("Only one instance of nikesonar can be run");
                Environment.Exit(1);
                return;
            }
              
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                //return;          

            if (!IsAdministrator())
            {
                MessageBox.Show("This application requires administrator rights please right click the icon and \"Run as administrator\"");
                Environment.Exit(1);
            }
            try
            {
                Thread.Sleep(1000);
                Process.Start("Updater.exe");
            } catch {}
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(
               (sender, e) =>
               {
                   if (e.IsTerminating)
                   {
                       object o = e.ExceptionObject;
                       MessageBox.Show("Uhh ohh you found a bug print screen this and send it to @nikesonar " +
                                       o.ToString());
                       ErrorForm frm = new ErrorForm(o.ToString(), "");
                       frm.Show();
                   }
               }
                );

            //AutoUpdater.Start("http://nikesonar.com/Nike/SNKRS/update.xml");
            if (!DoLogin())
            {

              return;
            }
            form = new MainForm();
            Application.Run(form);
            Thread loginThread = new Thread(LoginChecker);
            loginThread.Start();
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }  

        public static void LoginChecker()
        {
            string username = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Username", "").ToString();
            string password = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Password", "").ToString();
            for (; ; )
            {
                if (ApiLogin.Login(ApiLogin.GetUDID(), username, password) != LoginResponseCode.Sucess)
                {
                    return;
                    MetroMessageBox.Show(form,
                        "There was a problem when checking your licence this could be a connection issue. The program will now close.",
                        "API Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Thread.Sleep(5000);
                    Environment.Exit(10);
                }
                Thread.Sleep(300000);
            }
        }

        static bool DoLogin()
        {
            //return true;
                var loginForm = new Login();

                Application.Run(loginForm);
                if (!loginForm.Result)
                {
                    return false;
                }
            return true;
        }
    }
}
