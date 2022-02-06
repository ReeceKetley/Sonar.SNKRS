namespace SonarSNKRS.Forms
{
    partial class CheckoutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProduct = new MetroFramework.Controls.MetroLabel();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(24, 64);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(87, 20);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "metroLabel1";
            this.lblProduct.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Location = new System.Drawing.Point(23, 87);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(554, 590);
            this.webControl1.TabIndex = 1;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.AllowDropLoad = true;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.lblProduct);
            this.Name = "CheckoutForm";
            this.Load += new System.EventHandler(this.CheckoutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblProduct;
        private EO.WebBrowser.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;
    }
}