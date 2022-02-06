using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SonarSNKRS
{
    [ServiceContract]
    public interface IGetNikeAccounts
    {
        [OperationContract]
        string GetNikeAccounts();
        [OperationContract]
        bool CreateRemoteTask(string account, string size, string stylecode, string region, string proxy = "");
    }



    public class GetNikeAccountsRemotely : IGetNikeAccounts
    {
        public string GetNikeAccounts()
        {
            SNKRSActions.MainFormGlobal.updateLink();
            return Directory.GetCurrentDirectory() + "\\accounts.json";

        }

        public bool CreateRemoteTask(string account, string size, string stylecode, string region, string proxy = "")
        {
            Debug.WriteLine("Create Remote Task: " + account + " - " + size + " - " + stylecode + " - " + region + " - " + proxy);
            try
            {
                NikeRegion region1 = null;
                foreach (var source in NikeRegions.Regions.ToList())
                {
                    if (source.Label == region)
                    {
                        Debug.WriteLine("Region OK");
                        region1 = source;
                    }
                }
                NikeAccount nikeAccount = new NikeAccount("", "", "", "");
                foreach (var acc in SNKRSActions.NikeAccounts.ToList())
                {
                    Debug.WriteLine(acc.NikeEmail);
                    if (acc.NikeEmail.Contains(account.Trim()))
                    {
                        Debug.WriteLine("Account OK");
                        nikeAccount = acc;
                    }
                }
                var taskConfig = new SNKRSTaskConfig();
                taskConfig.Region = region1;
                taskConfig.NikeUsername = nikeAccount.NikeEmail;
                taskConfig.NikePassword = nikeAccount.NikePassword;
                taskConfig.Proxy = proxy;
                taskConfig.Size = size;
                taskConfig.StyleCode = stylecode.Trim();
                taskConfig.ContactEmail = nikeAccount.ContactEmail;
                taskConfig.SmsNotify = nikeAccount.CellNumber;
                SnkrsSession session = new SnkrsSession(proxy);
                var task = new SNKRSTask(SNKRSActions.MainFormGlobal, taskConfig, proxy);
                task.Session = session;
                SNKRSActions.MainFormGlobal.CreateTaskRemotely(task);
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }

    class RemoteServer
    {
        private ServiceHost host;
        public RemoteServer()
        {
            try
            {
                Debug.WriteLine("Creating WCF");
                AppDomain.CurrentDomain.UnhandledException +=
                    (sender, error) => File.AppendAllText("Fatal.log", error.ExceptionObject.ToString() + "\r\n");
                host = new ServiceHost(typeof (GetNikeAccountsRemotely), new Uri("http://localhost:7728"),
                    new Uri("net.pipe://localhost"));
                host.AddServiceEndpoint(typeof (IGetNikeAccounts), new BasicHttpBinding(), "GetAccounts");
                host.AddServiceEndpoint(typeof (IGetNikeAccounts), new NetNamedPipeBinding(), "GetAccountsPiped");
                host.Open();
                host.Opened += HostOnOpened;
                host.UnknownMessageReceived +=
                    new EventHandler<UnknownMessageReceivedEventArgs>(host_UnknownMessageReceived);
            }
            catch
            {
                MessageBox.Show(
                    "Error registering SonarLINK Service. SonarRESTOCK will not be able to comunicate with Sonar. Sonar will now attempt to register the service manually.");
                string strCmdText;
                strCmdText = "netsh http add urlacl url=http://+:7728/GetAccounts user=" + Environment.UserDomainName + "\\" + Environment.UserName;
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                MessageBox.Show("Restart Sonar to see if manual linking worked.");
            }
        }

        void host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            Debug.WriteLine("WCF Unkown Message");
        }

        private void HostOnOpened(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine("WCF Online");
        }
    }
}
