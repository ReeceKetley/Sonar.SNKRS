using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace SonarSNKRS.Forms
{
    public partial class CheckoutForm : TemplateForm
    {
        private string _url;
        private string _product;
        public CheckoutForm(string url, string product)
        {
            _url = url;
            _product = product;
            InitializeComponent();
            webControl1.WebView.CustomUserAgent = "onenikecommerce-inhouse/1.0.2 (iPhone; iOS 7.1; Scale/2.00)";
            ////Debug.WriteLine(_url);
            webControl1.WebView.LoadUrl(_url);
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            lblProduct.Text = _product;
        }
    }
}
