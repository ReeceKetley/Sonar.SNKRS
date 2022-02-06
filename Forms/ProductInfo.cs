using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace SonarSNKRS.Forms
{
    public partial class ProductInfo : TemplateForm
    {
        private NikeProduct Product;
        public ProductInfo(NikeProduct product)
        {
            InitializeComponent();
            if (product == null)
            {
                Close();
            }
            Product = product;
        }


        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", " ");
        }
        private void ProductInfo_Load(object sender, EventArgs e)
        {
            var center =
            metroLabel4.Text = StripTagsRegex(Product.Description);
            pictureBox1.Image = Functions.GetImageFromUrl(Product.ImageUrl);
            metroLabel1.Text = Product.Name;

            metroLabel2.Text = Product.StyleCode;
            metroLabel3.Text = "Estimated Launch Date: " + Product.EstimatedLaunchDate;
        }
    }
}
