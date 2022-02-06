using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Faker;
using MetroFramework.Forms;
using System.Web;
using System.Web.UI;
using MetroFramework;
using Newtonsoft.Json.Linq;

namespace SonarSNKRS.Forms
{
    public partial class NikeAccountsForm : TemplateForm
    {
        private string _lastEmail;
        private string _lastPassword;
        public List<JObject> SaveFileList = new List<JObject>(); 
        public NikeAccountsForm()
        {
            InitializeComponent();
            Win32.SetWindowTheme(olvNikeAccounts.Handle, "explorer", null);
            olvEmail.AspectGetter = model => ((NikeAccount)model).NikeEmail;
            olvContact.AspectGetter = model => ((NikeAccount) model).ContactEmail;
            olvPassword.AspectGetter = model => ((NikeAccount)model).NikePassword;
            olvNumber.AspectGetter = model => ((NikeAccount) model).CellNumber;
            olvSize.AspectGetter = model => ((NikeAccount)model).NikeSize;
        }

        private void NikeAccountsForm_Load(object sender, EventArgs e)
        {
            foreach (var nikeAccount in SNKRSActions.NikeAccounts)
            {
                olvNikeAccounts.AddObject(nikeAccount);
                SaveFileList.Add(nikeAccount.ConvertToJObject());
            }
            foreach (var provider in SMSProviders.Providers)
            {
                cboProviders.Items.Add(provider.Key);
            }
        }

        public void updateJSONFile()
        {
            var accountArray = new JArray();
            foreach (JObject jObject in SaveFileList)
            {
                accountArray.Add(jObject);
            }
            if (File.Exists("accounts.json"))
            {
                try
                {
                    File.Delete("accounts.json");
                }
                catch
                {
                     MetroMessageBox.Show(this, "Error writing to accounts.json (Is the file open?)");
                }
            }
            try
            {
                File.WriteAllText("accounts.json", accountArray.ToString());
            }
            catch
            {
                MetroMessageBox.Show(this, "Error writing to accounts.json (Is the file open?)");
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var cell = "";
            var size = "9";
            if (!string.IsNullOrEmpty(txtCell.Text) && cboProviders.SelectedItem != null)
            {
                cell = txtCell.Text.Trim() + SMSProviders.Providers[cboProviders.SelectedItem.ToString()];
                //Debug.WriteLine(cell);
            }
            if (!string.IsNullOrEmpty(txtSize.Text))
            {
                size = txtSize.Text;
            }
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtNikePassword.Text))
            {
                var account = new NikeAccount(txtEmail.Text.ToLower(), txtContact.Text, txtNikePassword.Text, cell);
                account.NikeSize = size;
                //Debug.WriteLine(account.CellNumber);
                SNKRSActions.NikeAccounts.Add(account);
                olvNikeAccounts.AddObject(account);
                txtEmail.Text = "";
                txtNikePassword.Text = "";
                SaveFileList.Add(account.ConvertToJObject());
                updateJSONFile();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (var selectedObject in olvNikeAccounts.SelectedObjects)
            {
                var account = (NikeAccount)selectedObject;
                SNKRSActions.NikeAccounts.Remove(account);
                olvNikeAccounts.RemoveObject(selectedObject);
                foreach (var jobj in SaveFileList.ToList())
                {
                    if (jobj["email"].ToString() == account.NikeEmail)
                    {
                        SaveFileList.Remove(jobj);
                    }
                }
                updateJSONFile();           
            }
        }

        private bool GenerateAccountMobile()
        {
            var firstName = Faker.Name.First();
            var lastName = Faker.Name.Last();
            var email =  RandomNumber.Next(600000) + "_" + Internet.FreeEmail();
            HTTP http = new HTTP("Mozilla/5.0 (iPhone; U; CPU iPhone OS 3_0 like Mac OS X; en-us) AppleWebKit/528.18 (KHTML, like Gecko) Version/4.0 Mobile/7A341 Safari/528.16");
            var postData = http.Post("https://www.nike.com/profile/services/users/", "{\"account\":{\"passwordSettings\":{\"password\":\"Icecream123!\",\"passwordConfirm\":\"Icecream123!\"},\"type\":\"0\",\"email\":\"" + email + "\",\"screenName\":\"BarnyBarnsBarnsworthsTheThird_" + RandomNumber.Next(600000) + "\"},\"locale\":\"en_US\",\"registrationSiteId\":\"1420\",\"firstName\":\"" + firstName + "\",\"lastName\":\"" + lastName + "\",\"gender\":\"2\",\"country\":\"US\",\"postalCode\":\"" + Faker.Address.ZipCode() + "\",\"optIns\":[{\"id\":\"1420\",\"email\":true}],\"receiveEmail\":true,\"dateOfBirth\":\"1994-07-13\"}", "application/json; charset=UTF-8");
            Console.WriteLine(postData);
            if (postData.Contains("https://www.nike.com/profile/services/users/"))
            {
                _lastEmail = email;
                _lastPassword = "Icecream123!";
                return true;
            }
            return false;
        }

        private bool GenerateAccount()
        {
            HTTP http = new HTTP("Mozilla/5.0 (iPhone; CPU iPhone OS 7_1 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like Gecko) Mobile/11D167");
            var res =
                http.Get(
                    "https://s3.nikecdn.com/unite/mobile.html?iOSSDKVersion=1.0.0&uxId=com.nike.valiant.ios&view=login&locale=en_US&backendEnvironment=prd");
            string clientid = Functions.ExtractBetween(res, "<!-- devcode: production -->", "<!-- endcode -->");
            clientid = clientid.Replace("'", "").Trim();
            ////Debug.WriteLine(clientid);
            string postCode = "1001";
            string firstName = Faker.Name.First();
            string lastName = Faker.Name.Last();
            string password = "!" + firstName + RandomNumber.Next(500);

            string screenName = firstName[0] + lastName + RandomNumber.Next(100);
            string emailAddress = RandomNumber.Next(1000) + "_" + firstName + "_" + lastName + "@gmail.com";
            string gender = "male";
            http.Headers.Add("Origin", "https://s3.nikecdn.com");
            http.Referer =
                "https://s3.nikecdn.com/unite/mobile.html?iOSSDKVersion=1.0.0&clientId=" + clientid + "&uxId=com.nike.valiant.ios&view=join&locale=en_US&backendEnvironment=prd";
            string post =
                "_registrationSiteId=1023&emailAddress=" + HttpUtility.UrlEncode(emailAddress) + "&passwordCreate=" + password + "&firstName=" + firstName + "&lastName=" + lastName + "&dateOfBirth=1977-03-16&gender=male&countryList=US&country=US&zipCode=10002&emailSignup=true&_locale=en_US&client_id=0239a00434d37e14e8644b9821d1322c&ux_id=com.nike.valiant.ios&transactionId=" + Guid.NewGuid() + "&_backendEnvironment=prd";
            var result = http.Post("https://unite.nikeapp.com/join", post);
            if (result.Contains("nike.unite.tokens.access.set"))
            {
                _lastEmail = emailAddress;
                _lastPassword = password;
                return true;
            }
            return false;
        }

        private void GenerateAcc()
        {
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < metroTrackBar1.Value; ++i)
            {
                if (GenerateAccountMobile())
                {
                    var cell = "";
                    var size = RandomNumber.Next(7, 15).ToString();
                    if (!string.IsNullOrEmpty(txtCell.Text) && cboProviders.SelectedItem != null)
                    {
                        cell = txtCell.Text.Trim() + SMSProviders.Providers[cboProviders.SelectedItem.ToString()];
                        //Debug.WriteLine(cell);
                    }
                    if (!string.IsNullOrEmpty(txtSize.Text))
                    {
                        size = txtSize.Text;
                    }
                    var account = new NikeAccount(_lastEmail, txtContact.Text, _lastPassword, cell);
                    account.NikeSize = size;
                    //var session = new SnkrsSession(_lastEmail, _lastPassword);
                    olvNikeAccounts.AddObject(account);
                    SNKRSActions.NikeAccounts.Add(account);
                    SaveFileList.Add(account.ConvertToJObject());
                }
                Thread.Sleep(1000);
            }
            updateJSONFile();
            Cursor.Current = Cursors.Default;
        }

        private void btnAutoGen_Click(object sender, EventArgs e)
        {
            GenerateAcc();
        }

        private void txtCell_Click(object sender, EventArgs e)
        {

        }

        private void txtCell_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int h = 58; h <= 127; h++)
            {
                if (e.KeyChar == h)             //58 to 127 is alphabets tat will be         blocked
                {
                    e.Handled = true;
                }
            }
            for (int k = 32; k <= 47; k++)
            {
                if (e.KeyChar == k)              //32 to 47 are special characters tat will 
                {
                    e.Handled = true;
                }
            }
        }

        private void olvNikeAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void olvNikeAccounts_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            foreach (var selectedObject in olvNikeAccounts.SelectedObjects)
            {
                foreach (var nikeAccount in SNKRSActions.NikeAccounts.ToList())
                {
                    SNKRSActions.NikeAccounts.Remove(nikeAccount);
                    foreach (var jobj in SaveFileList.ToList().Where(jobj => jobj["email"].ToString() == nikeAccount.NikeEmail))
                    {
                        SaveFileList.Remove(jobj);
                    }
                }
                var account = (NikeAccount)selectedObject;
                SNKRSActions.NikeAccounts.Add(account);
                SaveFileList.Add(account.ConvertToJObject());
                updateJSONFile();
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = "Amount: " + metroTrackBar1.Value;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var file = openFileDialog1.FileName;
            if (File.Exists(openFileDialog1.FileName) == false)
            {
                return;
            }
            var data = File.ReadAllLines(file);
            try
            {
                foreach (var s in data)
                {
                    var t = s.Split(',');
                    NikeAccount account = new NikeAccount(t[0], t[3], t[1], t[4]);
                    account.NikeSize = t[2];
                    SNKRSActions.NikeAccounts.Add(account);
                    olvNikeAccounts.AddObject(account);
                    SaveFileList.Add(account.ConvertToJObject());
                    updateJSONFile();
                }
            }
            catch
            {
            }
            MessageBox.Show("Accounts loaded.");
        }
    }
}
