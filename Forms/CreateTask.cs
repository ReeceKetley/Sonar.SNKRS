using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Faker;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Drawing.Html;
using ThreadState = System.Threading.ThreadState;

namespace SonarSNKRS.Forms
{
    public partial class CreateTask : TemplateForm
    {
        private NikeProduct _product;
        private MainForm _form;
        private NikeAccount _nikeAccount;
        private List<NikeAccount> _nikeAccounts = new List<NikeAccount>();
        public TaskContainer TaskResult { get; private set; }
        public List<NikeProduct> NikeProducts;
        public string grabproxy;
        private Thread scanThread;
        private NikeRegion region = new NikeRegion("", "", "", "");
        public CreateTask(MainForm form)
        {
            _form = form;
            InitializeComponent();
        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            foreach (var nikeRegion in NikeRegions.Regions)
            {
                cboRegions.Items.Add(nikeRegion.Label);
            }

            metroButton1.Enabled = false;
            NikeProducts = SNKRSActions.Products;
            foreach (var nikeAccount in SNKRSActions.NikeAccounts)
            {
                nikeAccountsGrid.Rows.Add(false, nikeAccount.NikeEmail, nikeAccount.NikePassword, nikeAccount.NikeSize);
            }
            Thread t = new Thread(PopulateList);
            t.Start();
        }

        private void PopulateList()
        {
            foreach (var product in NikeProducts)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    productsGrid.Rows.Add(product.Name, product.StyleCode);
                });
            }
        }

        private void SetProduct(string stylecode)
        {
            if (spPages.SelectedIndex < spPages.TabPages.Count - 1)
            {
                spPages.SelectTab(spPages.SelectedIndex + 1);
            };

            _product = SNKRSActions.SearchProducts("", stylecode);
            //////Debug.WriteLine(_product.Name);
            foreach (var productImageCach in SNKRSActions.ProductImageCaches.Where(productImageCach => productImageCach.StyleCode == stylecode))
            {
                //////Debug.WriteLine(productImageCach.StyleCode);
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static bool IsValidProxy(string input)
        {
            string pattern = @"\A\d{1,3}(\.\d{1,3}){3}:\d{1,5}\z";
            Match match = Regex.Match(input, pattern);
            return match.Success;
            /*
        if (match.Success)
        {
            Console.WriteLine(match.Groups[0].Value);
        }
        */
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            //metroButton2.Visible = false;
            //txtProxy.Visible = false;
            //metroButton2.BringToFront();
            //txtProxy.BringToFront();
            if (spPages.SelectedTab.Text == "tpRegion")
            {
                if (cboRegions.SelectedItem == null)
                {
                    foreach (var nikeRegion in NikeRegions.Regions.Where(nikeRegion => nikeRegion.Country == "US"))
                    {
                        region = nikeRegion;
                        Debug.WriteLine("Default Region US Selected");
                    }
                }
                else
                {
                    foreach (var nikeRegion in NikeRegions.Regions.Where(nikeRegion => nikeRegion.Label == cboRegions.SelectedItem.ToString()))
                    {
                        region = nikeRegion;
                        Debug.WriteLine("Region: " + region.Label + " Selected.");
                    }
                }
                if (region.Country != "US")
                {
                    //productsGrid.Rows.Clear();
                }
                if (region.Country == "US")
                {
                    if (productsGrid.Rows.Count <= 0)
                    {
                        //PopulateList();
                    }
                }
            }
            if (_product == null && spPages.SelectedTab.Text != "tpRegion")
            {
                ////Debug.WriteLine("Product NULL");
                if (txtSearch.Text != "")
                {
                    
                    _product = new NikeProduct("Unkown Product", "", txtSearch.Text, "", "", true);
                    spPages.SelectedIndex = spPages.SelectedIndex + 1;
                    metroButton1.Enabled = true;
                    //txtProxy.Visible = true;
                    //metroButton2.BringToFront();
                    //txtProxy.BringToFront();
                    return;
                }
                MetroMessageBox.Show(this, "You didnt select a product please double click on the product you want.");
                return;
            }
            if (spPages.SelectedIndex == 2)
            {
                //metroButton2.Visible = true;
                //txtProxy.Visible = true;
                //metroButton2.BringToFront();
                //txtProxy.BringToFront();
                btnNext.Text = "Finish";
                if (_nikeAccounts.Count < 1)
                {
                    if (nikeAccountsGrid.SelectedRows.Count > 0)
                    {

                    }
                    MetroMessageBox.Show(this, "Missing required feilds", "Missing feilds", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    spPages.SelectedIndex = 1;
                    return;
                }
            }
            if (spPages.SelectedIndex == 2)
            {
                TaskContainer tasksContainer = new TaskContainer();
                if (_nikeAccounts.Count() > 5)
                {
                    MetroMessageBox.Show(this, "You have more than 5 Nike accounts selected this may result in a ban if you are not using proxies.", "Potential Ban Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                foreach (var nikeAccount in _nikeAccounts)
                {
                    var taskConfig = new SNKRSTaskConfig();
                    taskConfig.ItemName = _product.Name;
                    taskConfig.NikeUsername = nikeAccount.NikeEmail;
                    taskConfig.NikePassword = nikeAccount.NikePassword;
                    taskConfig.ContactEmail = nikeAccount.ContactEmail;
                    taskConfig.Size = nikeAccount.NikeSize;
                    taskConfig.StyleCode = _product.StyleCode;
                    taskConfig.ImageUrl = _product.ImageUrl;
                    taskConfig.Proxy = "";
                    taskConfig.Region = region; 
                    if (!string.IsNullOrEmpty(txtProxie.Text) && IsValidProxyCredential(txtProxie.Text.Trim()))
                    {
                        taskConfig.Proxy = txtProxie.Text.Trim();
                    }
                    taskConfig.SmsNotify = nikeAccount.CellNumber;
                    var Task = new SNKRSTask(null, taskConfig);
                    Task.useOldATC = !chkMutliATC.Checked;
                    Task.Session = new SnkrsSession(taskConfig.Proxy);
                    tasksContainer.AddTask(Task);
                }
                TaskResult = tasksContainer;
                Close();
            }
            if (spPages.SelectedIndex < spPages.TabPages.Count - 1)
            {
                spPages.SelectTab(spPages.SelectedIndex + 1);
            }
        }

        public static bool ValidateProxy(string input)
        {
            string pattern = @"\A\d{1,3}(\.\d{1,3}){3}:\d{1,5}\z";
            Match match = Regex.Match(input, pattern);
            return match.Success;
        }

        public static bool IsValidProxyCredential(string input)
        {
            string[] chunks = input.Split(':');
            if (chunks.Length == 2 || chunks.Length == 4)
            {
                string proxy = chunks[0] + ":" + chunks[1];

                if (ValidateProxy(proxy))
                {
                    if (chunks.Length == 4 && (chunks[2].Length < 1 || chunks[3].Length < 1))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (_nikeAccount != null && !String.IsNullOrEmpty(_nikeAccount.NikeEmail) && !String.IsNullOrEmpty(_nikeAccount.NikePassword))
            {
                if (SNKRSActions.NikeMainLogin(_nikeAccount.NikeEmail, _nikeAccount.NikePassword))
                {
                    MetroMessageBox.Show(this, "Logged in succesfully", "Login result");
                    return;
                }
                MetroMessageBox.Show(this, "Logged in failed", "Login result");
            }
        }


        private void tpNikeAccount_Click(object sender, EventArgs e)
        {

        }


        private void tpProducts_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                PopulateList();
            }
            for (var index = 0; index < productsGrid.Rows.Count; index++)
            {
                var row = productsGrid.Rows[index];
                var Row = (DataGridViewRow)row;
                if (!Row.Cells[1].Value.ToString().Contains(txtSearch.Text))
                {
                    productsGrid.Rows.Remove(Row);
                }
            }
        }



        private void productsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productsGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (var nikeProduct in SNKRSActions.Products)
            {
                if (nikeProduct.StyleCode == productsGrid.SelectedRows[0].Cells[1].Value)
                {
                    _product = nikeProduct;
                    metroButton1.Enabled = true;
                    spPages.SelectedIndex = spPages.SelectedIndex + 1;
                    //metroButton2.Visible = true;
                    //txtProxy.Visible = true;
                    //metroButton2.BringToFront();
                    //txtProxy.BringToFront();
                }
            }
        }

        private void nikeAccountsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (var account in nikeAccountsGrid.SelectedRows.Cast<DataGridViewRow>())
                {
                    NikeAccount nikeAccount = null;
                    //Debug.WriteLine(account.Cells[0].Value.ToString());
                    if (account.Cells[0].Value.ToString() == "True")
                    {
                        foreach (var nikeA in SNKRSActions.NikeAccounts)
                        {
                            if (nikeA.NikeEmail == account.Cells[1].Value.ToString())
                            {
                                nikeAccount = nikeA;
                            }
                        }
                        if (account.Cells[3].Value == null)
                        {
                            return;
                        }
                        nikeAccount.NikeSize = account.Cells[3].Value.ToString().Trim();
                        foreach (var nikeAccount1 in _nikeAccounts.ToList())
                        {
                            if (nikeAccount1.NikeEmail.Contains(nikeAccount.NikeEmail))
                            {
                                _nikeAccounts.Remove(nikeAccount1);
                            }
                        }
                        foreach (
                            var accc in
                                SNKRSActions.NikeAccounts.Where(accc => accc.NikeEmail.Contains(nikeAccount.NikeEmail)))
                        {
                            nikeAccount.CellNumber = accc.CellNumber;
                        }
                        _nikeAccounts.Add(nikeAccount);
                        //Debug.WriteLine(_nikeAccounts.Count);
                    }
                    if (account.Cells[0].Value.ToString() == "False")
                    {
                        //var nikeAccount = new NikeAccount(account.Cells[1].Value.ToString(), account.Cells[2].Value.ToString());
                        //nikeAccount.NikeSize = account.Cells[3].Value.ToString().Trim();
                        foreach (
                            var account1 in
                                _nikeAccounts.ToList()
                                    .Where(account1 => account1.NikeEmail.Contains(nikeAccount.NikeEmail)))
                        {
                            _nikeAccounts.Remove(account1);
                        }
                        //Debug.WriteLine(_nikeAccounts.Count);
                    }
                }
            }
            catch
            {
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in nikeAccountsGrid.Rows)
            {
                nikeAccountsGrid.SelectAll();
                row.Cells[0].Value = true;
            }
        }

        private void productsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void productsGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var nikeProduct in SNKRSActions.Products)
                {
                    if (nikeProduct.StyleCode == productsGrid.Rows[e.RowIndex].Cells["Style"].Value)
                    {
                        var productInfo = new ProductInfo(nikeProduct);
                        productInfo.ShowDialog();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (spPages.SelectedIndex > 0)
            {
                spPages.SelectedIndex = spPages.SelectedIndex - 1;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            txtProxie.Text = SNKRSActions.GetRandomProxy().Trim();
        }

        public bool proxyIsBanned(string ip)
        {
            HTTP http = new HTTP("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0", ip);
            var response = http.Get("http://secure-store.nike.com/us/checkout/mobile/cart.jsp?country=US&country=US&l=cart", 8 * 1000);
            Debug.WriteLine("Test: " + ip);
            Debug.WriteLine(http.ResponseException);
            Debug.WriteLine("Proxy test response: " + response);
            if (response.Contains("Your cart") || response.Contains("Select Your Country"))
            {
                return false;
            }
            return true;
        }

        public void TestProxy()
        {
            var curTime = Functions.CurrentTimeMillis();
            if (!proxyIsBanned(grabproxy))
            {
                var finishTime = Functions.CurrentTimeMillis() - curTime;
                this.Invoke((MethodInvoker)delegate
                {
                    MetroMessageBox.Show(this, "Proxy seems to work Speed: " + finishTime + " MS", "Proxy Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrab.Enabled = true;
                    btnTest.Enabled = true;
                    btnTest.Text = "Test";
                });
            }
            else
            {
                this.Invoke((MethodInvoker) delegate
                {
                    MetroMessageBox.Show(this, "Proxy connection failed", "Proxy Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGrab.Enabled = true;
                    btnTest.Enabled = true;
                    btnTest.Text = "Test";
                });
            }
        }

        public bool OldInitNikeSession(string proxy)
        {
            HTTP _http = new HTTP("Mozilla/5.0 (iPhone; U; CPU iPhone OS 3_0 like Mac OS X; en-us) AppleWebKit/528.18 (KHTML, like Gecko) Version/4.0 Mobile/7A341 Safari/528.16", proxy);
            var resp = _http.Get("http://m.nike.com/us/en_us", 10 * 1000);
            {
                if (!string.IsNullOrEmpty(resp) && resp.Contains("<a class=\"home\" href=\"http://m.nike.com/"))
                {
                    return true;
                }
            }
            return false;
        }

        public void TestProxyAuto()
        {
            List<string> testedList = new List<string>();
            while (autoScan)
            {
                var proxy = SNKRSActions.GetRandomProxy();
                Debug.WriteLine("Testing: " + proxy);
                this.Invoke((MethodInvoker) delegate
                {
                    txtProxie.Text = proxy;
                });
                if (testedList.Any(p => p == proxy))
                {
                    continue;
                }
                var curTime = Functions.CurrentTimeMillis();
                if (!proxyIsBanned(proxy))
                {
                    var finishTime = Functions.CurrentTimeMillis() - curTime;
                    this.Invoke((MethodInvoker) delegate
                    {
                        txtProxie.Text = proxy;
                        this.WindowState = FormWindowState.Minimized;
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        this.BringToFront();
                        Console.Beep(800, 500);
                        MetroMessageBox.Show(this, "Proxy seems to work Speed: " + finishTime + " MS", "Proxy Test",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGrab.Enabled = true;
                        btnTest.Enabled = true;
                        btnTest.Text = "Test";
                        txtProxie.Enabled = true;
                    });
                    autoScan = false;
                }
                testedList.Add(proxy);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (IsValidProxyCredential(txtProxie.Text.Trim()))
            {
                btnGrab.Enabled = false;
                btnTest.Enabled = false;
                btnTest.Text = "Testing";
                grabproxy = txtProxie.Text.Trim();
                Thread t = new Thread(TestProxy);
                t.Start();
            }
        }

        private bool autoScan;

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            if (!autoScan)
            {
                autoScan = true;
                MetroMessageBox.Show(this,
                    "Sonar is now scanning for a working proxy and will alert you when one is found. Press the button marked A to stop",
                    "Proxy Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrab.Enabled = false;
                btnTest.Enabled = false;
                btnTest.Text = "Testing";
                txtProxie.Text = "Automatic scan in progress.";
                txtProxie.Enabled = false;
                scanThread = new Thread(TestProxyAuto);
                scanThread.Start();
            }
            else
            {
                autoScan = false;
                btnGrab.Enabled = true;
                btnTest.Enabled = true;
                btnTest.Text = "Test";
                txtProxie.Enabled = true;
                txtProxie.Text = "";
            }
        }

        private void CreateTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scanThread != null && scanThread.ThreadState == ThreadState.Running)
            {
                MetroMessageBox.Show(this,
                "Proxy scanner stopping",
                "Proxy Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                scanThread.Abort();
                while (scanThread.IsAlive)
                {
                    
                }
            }
        }

        private void chkMutliATC_CheckedChanged(object sender, EventArgs e)
        {

        }
      
    }
}
