using System.Diagnostics;
using System.ServiceModel;


namespace SonarSNKRS
{
    using BrightIdeasSoftware;
    using MetroFramework;
    using MetroFramework.Controls;
    using Microsoft.Win32;
    using Newtonsoft.Json.Linq;
    using SonarSNKRS.Classes.General_Classes;
    using SonarSNKRS.Forms;
    using SonarSNKRS.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;



    public partial class MainForm : TemplateForm
    {
        private bool _startButtonEnabled = true;
        public List<SNKRSTask> _tasks = new List<SNKRSTask>();
        private WebServer server;
        public DateTime StartTime;
        public bool StopTimer;
        private string ip;
        private string taskPort;
        public List<Thread> Threads = new List<Thread>();
        private bool userSmtp;
        private bool useSSL;
        public string Version = "1.2";

        // Remote Server stuff

        //

        private RemoteServer remoteServer;
        public MainForm()
        {

           
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Win32.SetWindowTheme(this.olvTasks.Handle, "explorer", null);
            this.olvID.AspectGetter = model => ((SNKRSTask) model).ID;
            this.olvRegion.AspectGetter = model => ((SNKRSTask) model)._taskConfig.Region.Label;
            this.olvNikeUser.AspectGetter = model => ((SNKRSTask) model)._taskConfig.NikeUsername;
            this.olvNikePassword.AspectGetter = model => ((SNKRSTask) model)._taskConfig.NikePassword;
            this.olvProductTitle.AspectGetter = model => ((SNKRSTask) model)._taskConfig.ItemName;
            this.olvSize.AspectGetter = model => ((SNKRSTask) model)._taskConfig.Size;
            this.olvProxy.AspectGetter = model => ((SNKRSTask) model)._taskConfig.Proxy;
            this.olvStyleCode.AspectGetter = model => ((SNKRSTask) model)._taskConfig.StyleCode;
            this.olvStatus.AspectGetter = model => ((SNKRSTask) model).Status;
            this.ip = this.GetPublicIP();
            if (((string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "CustomSMTP", "False")) == "True")
            {
                this.userSmtp = true;
                EmailSender.useCustom = true;
            }
            if (((string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "UseSSL", "False")) == "True")
            {
                this.useSSL = true;
            }
            base.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void btnNikeAccounts_Click(object sender, EventArgs e)
        {
            new NikeAccountsForm().ShowDialog();
        }

        private void btnUpdateSave_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "UseSSL", this.tglSSL.Checked);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "CustomSMTP", this.smtpToggle.Checked);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPServer", this.txtSmtpServer.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPUser", this.txtSMTPUsername.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPFrom", this.txtFromEmail.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPPort", this.txtPort.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPass", this.txtSmtpPass.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPSubject", this.txtSubject.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPMessage", this.txtMessage.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPSmsMessage", this.txtSmsMessage.Text);
            EmailSender.host = this.txtSmtpServer.Text;
            EmailSender.port = this.txtPort.Text;
            EmailSender.pass = this.txtSmtpPass.Text;
            EmailSender.smtpuser = this.txtSMTPUsername.Text;
            EmailSender.subject = this.txtSubject.Text;
            EmailSender.message = this.txtMessage.Text;
            EmailSender.sms = this.txtSmsMessage.Text;
            EmailSender.from = this.txtFromEmail.Text;
            EmailSender.useSSL = this.tglSSL.Checked;
            MetroMessageBox.Show(this, "Settings saved");
        }

        private void cboProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "Provider", this.cboProviders.SelectedItem.ToString());
        }

        private void chkSounds_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "KillSounds", this.chkSounds.Checked);
        }

        private bool CleanUp()
        {
            this.UpdateStatus("Performing cleanup tasks", true);
            try
            {
                foreach (string str in Directory.GetFiles("logs"))
                {
                    File.Delete(str);
                }
                if (Directory.Exists("tasks"))
                {
                    foreach (string str2 in Directory.GetFiles("tasks"))
                    {
                        if (!str2.Contains("base.html"))
                        {
                            this.UpdateStatus("Deleting: " + str2, true);
                            File.Delete(str2);
                        }
                    }
                }
                this.UpdateStatus("Cleanup tasks done", false);
            }
            catch
            {
            }
            SMSProviders.AddProviders();
            this.Invoke((MethodInvoker)delegate {
                foreach (KeyValuePair<string, string> pair in SMSProviders.Providers)
                {
                    this.cboProviders.Items.Add(pair.Key);
                }
            });
            return true;
        }

        private void CreateTaskBtn_Click(object sender, EventArgs e)
        {
            if (this._tasks.Count > APIUser.MaxAccounts)
            {
                MetroMessageBox.Show(this, "You have reached the maximum number of tasks for your package. Please upgrade to add more.", "Account limmit reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (SNKRSActions.NikeAccounts.Count <= 0)
            {
                MetroMessageBox.Show(this, "Please add some Nike Accounts before creating a task.", "No Nike Accounts", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                using (CreateTask task = new CreateTask(this))
                {
                    task.StartPosition = FormStartPosition.CenterParent;
                    task.ShowDialog(this);
                    if (task.TaskResult != null)
                    {
                        TaskContainer taskResult = task.TaskResult;
                        this.UpdateStatus(taskResult.TaskConfigs.Count + " Tasks added", true);
                        foreach (SNKRSTask task2 in taskResult.TaskConfigs)
                        {
                            task2._form = this;
                            task2.StatusUpdated += new EventHandler<TextArgs>(this.TaskResult_StatusUpdated);
                            task2.ID = Functions.RandomString(5);
                            this._tasks.Add(task2);
                            this.olvTasks.AddObject(task2);
                        }
                    }
                }
            }
        }

        private void DeleteTaskBtn_Click(object sender, EventArgs e)
        {
            foreach (object obj2 in this.olvTasks.SelectedObjects)
            {
                SNKRSTask item = (SNKRSTask) obj2;
                if (item.Running)
                {
                    item.StopTask();
                }
                this.olvTasks.RemoveObject(obj2);
                this._tasks.Remove(item);
            }
        }

    

        public string GetPublicIP()
        {
            try
            {
                HTTP http = new HTTP("", "") {
                    IncludeHeaderInResponse = false
                };
                return http.Get("http://api.ipify.org", 0);
            }
            catch
            {
                return "127.0.0.1";
            }
        }

       
        private void LoadAccounts()
        {
            this.Invoke((MethodInvoker)delegate {
                //this.label1.Text = this.metroTrackBar1.Value.ToString();
                APIUser.UserName = "KETLEY";
                this.RemoteSettings.SelectedTab = this.metroTabPage2;
                this.metroLabel2.Text = "Version: " + Application.ProductVersion;
                this.metroLabel3.Text = string.Concat(new object[] { "Licence: ", APIUser.UserLevel, " - ", APIUser.MaxAccounts });
                this.metroLabel4.Text = "Licenced To: " + APIUser.UserName;
                if (APIUser.UserLevel != UserLevel.Business)
                {
                    this.smtpGroupBox.Visible = false;
                }
                string str = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Phone", "").ToString() ?? "";
                string str2 = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Email", "").ToString() ?? "";
                string str3 = Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "Provider", "").ToString() ?? "";
                this.smtpToggle.Checked = false;
                this.tglSSL.Checked = false;
                this.cboProviders.SelectedText = "";
                this.metroTextBox1.Text = str;
                this.txtEmail.Text = str2;
                string str4 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPServer", "") ?? "";
                string str5 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPPort", "587") ?? "";
                string str6 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPass", "") ?? "";
                string str7 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPUser", "") ?? "";
                string str8 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "KillSounds", "False") ?? "";
                string str9 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPSubject", "") ?? "";
                string str10 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPMessage", "") ?? "";
                string str11 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPSmsMessage", "") ?? "";
                string str12 = (string) Registry.GetValue(@"HKEY_CURRENT_USER\NikeSonar", "SMTPFrom", "") ?? "";
                this.txtSmtpServer.Text = str4;
                this.txtPort.Text = str5;
                this.txtSmtpPass.Text = str6;
                this.txtSubject.Text = str9;
                this.txtMessage.Text = str10;
                this.txtSmsMessage.Text = str11;
                this.txtFromEmail.Text = str12;
                this.txtSMTPUsername.Text = str7;
                this.chkSounds.Checked = str8.Contains("True");
                EmailSender.host = str4;
                EmailSender.port = str5;
                EmailSender.pass = str6;
                EmailSender.smtpuser = str7;
                EmailSender.subject = str9;
                EmailSender.message = str10;
                EmailSender.sms = str11;
                EmailSender.from = str12;
                EmailSender.useSSL = this.useSSL;
                List<JObject> list = new List<JObject>();
                if (File.Exists("accounts.csv"))
                {
                    foreach (string str13 in File.ReadAllLines("accounts.csv"))
                    {
                        string[] strArray2 = str13.Split(new char[] { ',' });
                        try
                        {
                            NikeAccount item = new NikeAccount(strArray2[0], strArray2[1], strArray2[2], strArray2[3]) {
                                NikeSize = strArray2[4]
                            };
                            SNKRSActions.NikeAccounts.Add(item);
                            list.Add(item.ConvertToJObject());
                        }
                        catch
                        {
                        }
                    }
                    JArray array = new JArray();
                    foreach (JObject obj2 in list)
                    {
                        array.Add(obj2);
                    }
                    File.WriteAllText("accounts.json", array.ToString());
                    File.Delete("accounts.csv");
                }
                if (File.Exists("accounts.json"))
                {
                    string json = File.ReadAllText("accounts.json");
                    try
                    {
                        foreach (JToken token in JArray.Parse(json))
                        {
                            NikeAccount account2 = new NikeAccount(token["email"].ToString(), token["contact"].ToString(), token["password"].ToString(), token["cell"].ToString()) {
                                NikeSize = token["size"].ToString()
                            };
                            SNKRSActions.NikeAccounts.Add(account2);
                        }
                    }
                    catch
                    {
                    }
                }
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (SNKRSTask task in this._tasks)
            {
                task.StopTask();
            }
            foreach (Thread thread in this.Threads)
            {
                try
                {
                    thread.Abort();
                }
                catch
                {
                }
            }
            Environment.Exit(1);
        }

        public object CreateMutex = new object();
        public void CreateTaskRemotely(SNKRSTask task)
        {
            Debug.WriteLine("Main Form Create Task Called");
            lock (CreateMutex)
            {
                olvTasks.AddObject(task);
                _tasks.Add(task);
                task.StatusUpdated += new EventHandler<TextArgs>(this.TaskResult_StatusUpdated);
                task.StartTask();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SNKRSActions.MainFormGlobal = this;
            //remoteServer = new RemoteServer();
            this.CleanUp();
            //this.LoadAccounts();
            //this.CreateTaskBtn.Enabled = false;
            Thread item = new Thread(new ThreadStart(this.PopulateProducts));
            item.Start();
            this.Threads.Add(item);
            if ((APIUser.UserLevel != UserLevel.Basic) || (APIUser.UserLevel != UserLevel.Standard))
            {
                Thread thread2 = new Thread(new ThreadStart(this.StartWebserver));
                thread2.Start();
                this.Threads.Add(thread2);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if ((this.metroTextBox1.Text != "") && !string.IsNullOrEmpty(this.cboProviders.SelectedItem.ToString()))
            {
                MetroMessageBox.Show(this, "Message sent.");
                this.metroButton1.Enabled = false;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "Phone", this.metroTextBox1.Text);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "EMail", this.txtEmail.Text);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            EmailSender.SendMailViaPost(this.txtEmail.Text, "", "", "Test EMail", "Test", "1");
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0x3a; i <= 0x7f; i++)
            {
                if (e.KeyChar == i)
                {
                    e.Handled = true;
                }
            }
            for (int j = 0x20; j <= 0x2f; j++)
            {
                if (e.KeyChar == j)
                {
                    e.Handled = true;
                }
            }
        }

        private void metroTextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            for (int i = 0x3a; i <= 0x7f; i++)
            {
                if (e.KeyChar == i)
                {
                    e.Handled = true;
                }
            }
            for (int j = 0x20; j <= 0x2f; j++)
            {
                if (e.KeyChar == j)
                {
                    e.Handled = true;
                }
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.label1.Text = this.metroTrackBar1.Value.ToString();
            SNKRSActions.MaxHttpErrorAttemps = this.metroTrackBar1.Value;
        }

        private void mnuContext_Opening(object sender, CancelEventArgs e)
        {
        }

        private void olvTasks_DoubleClick(object sender, EventArgs e)
        {
            foreach (object obj2 in this.olvTasks.SelectedObjects)
            {
                SNKRSTask task = (SNKRSTask) obj2;
                if ((task.CheckoutUrl != null) && (task.CheckoutUrl.Contains("http://") || task.CheckoutUrl.Contains("https://")))
                {
                    new CheckoutForm(task.CheckoutUrl, task._taskConfig.ItemName).Show();
                }
            }
        }

        private void olvTasks_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (object obj2 in this.olvTasks.SelectedObjects)
                {
                    SNKRSTask task = (SNKRSTask) obj2;
                    if ((task.CheckoutUrl != null) && (task.CheckoutUrl.Contains("http://") || task.CheckoutUrl.Contains("https://")))
                    {
                        string[] strArray = task.CheckoutUrl.Split(new char[] { '=' });
                        Clipboard.SetText("http://nikesonar.com/link.php?rsid=" + strArray[1].Trim());
                        MetroMessageBox.Show(this, "Checkout url saved to clipboard");
                    }
                }
            }
        }

        private void olvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            MethodInvoker method = null;
            if (this.olvTasks.SelectedObjects.Count <= 0)
            {
                if (method == null)
                {
                    method = () => this.txtOutput.Text = "";
                }
                base.Invoke(method);
            }
            foreach (object obj2 in this.olvTasks.SelectedObjects)
            {
                SNKRSTask task = (SNKRSTask) obj2;
                this.Invoke((MethodInvoker)delegate
                {
                    this.txtOutput.AppendText("\r\n" + task.StatusList);
                });
            }
        }

        public static void OnThreadException(Exception t)
        {

        }


        public void updateLink()
        {
            SNKRSActions.MainFormGlobal.Invoke((MethodInvoker)delegate
            {
                metroLabel18.Text = "SonarLINK: Linked & Ready";
            });
        }


        private void PopulateProducts()
        {
            MethodInvoker method = null;
            MethodInvoker invoker2 = null;
           
            this.UpdateStatus("Downloading products...", true);
            if (SNKRSActions.DownloadProducts(this) == RequestResponse.Succes)
            {
                if (method == null)
                {
                    method = () => this.CreateTaskBtn.Enabled = true;
                }
                base.Invoke(method);
                JArray array = new JArray();
                this.UpdateStatus("Products cached.", false);
                foreach (NikeProduct product in SNKRSActions.Products)
                {
                    JObject item = product.ConvertToJObject();
                    array.Add(item);
                }
                VirtualFile task = new VirtualFile("products.json", array.ToString(), null);
                if (this.server != null)
                {
                    this.server.AddFile(task);
                }
            }
            else
            {
                if (invoker2 == null)
                {
                    invoker2 = () => MetroMessageBox.Show(this, "Error downloading products list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                base.Invoke(invoker2);
            }
        }

        private void removeScheduledStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopTimer = true;
            this.StartTime = DateTime.Now;
            this.StartStopTasksBtn.Text = "Start/Stop Tasks";
            this._startButtonEnabled = true;
        }

        private void scheduleStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopTimer = false;
            new SetTimeFrm(this).ShowDialog();
            this.StartStopTasksBtn.Text = this.StartTime.ToShortTimeString();
            this._startButtonEnabled = false;
            Thread item = new Thread(new ThreadStart(this.StartTasksScheduled));
            item.Start();
            this.Threads.Add(item);
        }

        public void SendEmail(string email, string id, string item, string size, bool sms = false)
        {
            EmailSender.SendMail(email, item, "Task started go here to watch: http://" + this.ip + ":" + this.taskPort + "/" + id + ".html", size, sms);
        }

        public void SendEmailPost(string email, string id, string item, string size, bool sms = false)
        {
            EmailSender.SendMail(email, item, "Task started go here to watch: http://" + this.ip + ":" + this.taskPort + "/" + id + ".html", size, sms);
        }

        private void smtpToggle_CheckedChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "CustomSMTP", this.smtpToggle.Checked);
        }

        private void StartStopTasksBtn_Click(object sender, EventArgs e)
        {
            if (this._startButtonEnabled)
            {
                if (this._tasks.Count > APIUser.MaxAccounts)
                {
                    MetroMessageBox.Show(this, "You have reached the maximum number of tasks for your package. Please upgrade to add more.", "Account limmit reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Thread item = new Thread(new ThreadStart(this.StartTasks));
                    item.Start();
                    Threads.Add(item);
                }
            }
        }

        private void StartStopTasksBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.mnuContext.Show(this, new Point(this.StartStopTasksBtn.Location.X, this.StartStopTasksBtn.Location.Y + 20));
            }
        }

        public void StartTasks()
        {
            MethodInvoker method = null;
            MethodInvoker invoker2 = null;
            if (this.olvTasks.SelectedObjects.Count <= 0)
            {
                using (List<SNKRSTask>.Enumerator enumerator = this._tasks.GetEnumerator())
                {
                    ThreadStart start = null;
                    ThreadStart start2 = null;
                    SNKRSTask snkrsTask;
                    while (enumerator.MoveNext())
                    {
                        snkrsTask = enumerator.Current;
                        if (!snkrsTask.Running)
                        {
                            snkrsTask.StartTask();
                            this.UpdateStatus("[" + snkrsTask.ID + "] Started", true);
                            if (APIUser.UserLevel == UserLevel.Business)
                            {
                                if (!string.IsNullOrEmpty(this.ip))
                                {

                                    if (this.userSmtp)
                                    {
                                        if (start == null)
                                        {
                                            start = () => this.SendEmail(snkrsTask._taskConfig.NikeUsername, snkrsTask.ID, snkrsTask._taskConfig.ItemName, snkrsTask._taskConfig.Size, false);
                                        }
                                        new Thread(start).Start();
                                    }
                                    else
                                    {
                                        if (start2 == null)
                                        {
                                            start2 = () => this.SendEmailPost(snkrsTask._taskConfig.NikeUsername, snkrsTask.ID, snkrsTask._taskConfig.ItemName, snkrsTask._taskConfig.Size, false);
                                        }
                                        new Thread(start2).Start();
                                    }
                                }
                                Thread.Sleep(50);
                            }
                            else
                            {
                                Thread.Sleep(100);
                            }
                        }
                        else
                        {
                            if (method == null)
                            {
                                method = () => this.DeleteTaskBtn.Enabled = true;
                            }
                            base.Invoke(method);
                            snkrsTask.StopTask();
                            this.UpdateStatus("[" + snkrsTask.ID + "] Stoped", false);
                        }
                    }
                }
            }
            else
            {
                foreach (object obj2 in this.olvTasks.SelectedObjects)
                {
                    ThreadStart start3 = null;
                    ThreadStart start4 = null;
                    SNKRSTask task = (SNKRSTask) obj2;
                    if (!task.Running)
                    {
                        task.StartTask();
                        this.UpdateStatus("[" + task.ID + "] Started", true);
                        if (APIUser.UserLevel == UserLevel.Business)
                        {
                            if (!string.IsNullOrEmpty(this.ip))
                            {
                                if (this.userSmtp)
                                {
                                    if (start3 == null)
                                    {
                                        start3 = () => this.SendEmail(task._taskConfig.NikeUsername, task.ID, task._taskConfig.ItemName, task._taskConfig.Size, false);
                                    }
                                    new Thread(start3).Start();
                                }
                                else
                                {
                                    if (start4 == null)
                                    {
                                        start4 = () => this.SendEmailPost(task._taskConfig.NikeUsername, task.ID, task._taskConfig.ItemName, task._taskConfig.Size, false);
                                    }
                                    new Thread(start4).Start();
                                }
                            }
                            Thread.Sleep(100);
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        if (invoker2 == null)
                        {
                            invoker2 = () => this.DeleteTaskBtn.Enabled = true;
                        }
                        base.Invoke(invoker2);
                        task.StopTask();
                        this.UpdateStatus("[" + task.ID + "] Stoped", false);
                    }
                }
            }
        }

        private void StartTasksScheduled()
        {
            MethodInvoker method = null;
        Label_0002:
            if (this.StopTimer)
            {
                return;
            }
            if (DateTime.Now.ToShortTimeString() == this.StartTime.ToShortTimeString())
            {
                if (method == null)
                {
                    method = delegate {
                        this.StartStopTasksBtn.Enabled = true;
                        this._startButtonEnabled = true;
                        if (this._tasks.Count > APIUser.MaxAccounts)
                        {
                            MetroMessageBox.Show(this, "You have reached the maximum number of tasks for your package. Please upgrade to add more.", "Account limmit reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            Thread item = new Thread(new ThreadStart(this.StartTasks));
                            item.Start();
                            this.StartStopTasksBtn.Text = "Start/Stop Tasks";
                            this.Threads.Add(item);
                        }
                    };
                }
                base.Invoke(method);
            }
            else
            {
                Thread.Sleep(500);
                goto Label_0002;
            }
        }

        private void StartWebserver()
        {
          
        }

        private void TaskResult_StatusUpdated(object sender, TextArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                MethodInvoker method = null;
                foreach (object obj2 in this.olvTasks.SelectedObjects)
                {
                    string str = Functions.ExtractBetween(e.Message, "[", "]");
                    SNKRSTask task = (SNKRSTask) obj2;
                    if (task.ID.Contains(str))
                    {
                        if (method == null)
                        {
                            method = () => this.txtOutput.AppendText("\r\n" + e.Message);
                        }
                        this.Invoke(method);
                    }
                }
            });
        }

        private void tglSSL_CheckStateChanged(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\NikeSonar", "UseSSL", this.tglSSL.Checked);
        }

        public void UpdateStatus(string text, bool spin)
        {
            this.Invoke((MethodInvoker)delegate {
                this.StatusSpinner.Spinning = spin;
                this.StatusSpinner.Visible = spin;
                this.StatusLabel.Text = "Status: " + text;
            });
        }

        public void UpdateTask(SNKRSTask task)
        {
            this.olvTasks.UpdateObject(task);
        }
    }
}

