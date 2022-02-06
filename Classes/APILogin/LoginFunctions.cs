using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework;

namespace SonarSNKRS
{
    class LoginFunctions
    {
        private static void LoginCheck()
        {
            for (;;)
            {
                if (!GlobalSettings.VaultUser.LoggedIn)
                {
                    MetroMessageBox.Show(MainForm.ActiveForm, "You are not logged in.", "Fatal Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                Thread.Sleep(500);
            }
        }

        public static void BeginLogedInChecker()
        {
            Thread thread = new Thread(LoginCheck);
            thread.Start();
        }
    }
}
