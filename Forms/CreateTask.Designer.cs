namespace SonarSNKRS.Forms
{
    partial class CreateTask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtProxy = new MetroFramework.Controls.MetroTextBox();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.btnNext = new MetroFramework.Controls.MetroButton();
            this.spPages = new StackPanel();
            this.tpRegion = new System.Windows.Forms.TabPage();
            this.chkMutliATC = new System.Windows.Forms.CheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cboRegions = new MetroFramework.Controls.MetroComboBox();
            this.tpProducts = new System.Windows.Forms.TabPage();
            this.productsGrid = new MetroFramework.Controls.MetroGrid();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.tpNikeAccount = new System.Windows.Forms.TabPage();
            this.nikeAccountsGrid = new MetroFramework.Controls.MetroGrid();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnTest = new MetroFramework.Controls.MetroButton();
            this.txtProxie = new MetroFramework.Controls.MetroTextBox();
            this.btnGrab = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.spPages.SuspendLayout();
            this.tpRegion.SuspendLayout();
            this.tpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsGrid)).BeginInit();
            this.tpNikeAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nikeAccountsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(192, 422);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(68, 18);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Select All";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // txtProxy
            // 
            this.txtProxy.Lines = new string[0];
            this.txtProxy.Location = new System.Drawing.Point(24, 360);
            this.txtProxy.Margin = new System.Windows.Forms.Padding(2);
            this.txtProxy.MaxLength = 32767;
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.PasswordChar = '\0';
            this.txtProxy.PromptText = "Proxy i.e 127.0.0.1:8123:admin:admin";
            this.txtProxy.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProxy.SelectedText = "";
            this.txtProxy.Size = new System.Drawing.Size(360, 18);
            this.txtProxy.TabIndex = 8;
            this.txtProxy.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtProxy.UseSelectable = true;
            this.txtProxy.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(24, 422);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(68, 18);
            this.btnBack.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(359, 422);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(68, 18);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // spPages
            // 
            this.spPages.Controls.Add(this.tpRegion);
            this.spPages.Controls.Add(this.tpProducts);
            this.spPages.Controls.Add(this.tpNikeAccount);
            this.spPages.HotTrack = true;
            this.spPages.Location = new System.Drawing.Point(24, 51);
            this.spPages.Margin = new System.Windows.Forms.Padding(2);
            this.spPages.Name = "spPages";
            this.spPages.SelectedIndex = 0;
            this.spPages.Size = new System.Drawing.Size(403, 327);
            this.spPages.TabIndex = 3;
            // 
            // tpRegion
            // 
            this.tpRegion.Controls.Add(this.chkMutliATC);
            this.tpRegion.Controls.Add(this.metroLabel2);
            this.tpRegion.Controls.Add(this.cboRegions);
            this.tpRegion.Location = new System.Drawing.Point(0, 0);
            this.tpRegion.Name = "tpRegion";
            this.tpRegion.Padding = new System.Windows.Forms.Padding(3);
            this.tpRegion.Size = new System.Drawing.Size(403, 327);
            this.tpRegion.TabIndex = 2;
            this.tpRegion.Text = "tpRegion";
            this.tpRegion.UseVisualStyleBackColor = true;
            // 
            // chkMutliATC
            // 
            this.chkMutliATC.AutoSize = true;
            this.chkMutliATC.Location = new System.Drawing.Point(22, 73);
            this.chkMutliATC.Name = "chkMutliATC";
            this.chkMutliATC.Size = new System.Drawing.Size(91, 17);
            this.chkMutliATC.TabIndex = 2;
            this.chkMutliATC.Text = "Use SNKRS?";
            this.chkMutliATC.UseVisualStyleBackColor = true;
            this.chkMutliATC.CheckedChanged += new System.EventHandler(this.chkMutliATC_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(18, 12);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Region (Locale)";
            // 
            // cboRegions
            // 
            this.cboRegions.FormattingEnabled = true;
            this.cboRegions.ItemHeight = 23;
            this.cboRegions.Location = new System.Drawing.Point(22, 37);
            this.cboRegions.Name = "cboRegions";
            this.cboRegions.Size = new System.Drawing.Size(354, 29);
            this.cboRegions.TabIndex = 0;
            this.cboRegions.UseSelectable = true;
            // 
            // tpProducts
            // 
            this.tpProducts.Controls.Add(this.productsGrid);
            this.tpProducts.Controls.Add(this.txtSearch);
            this.tpProducts.Location = new System.Drawing.Point(0, 0);
            this.tpProducts.Margin = new System.Windows.Forms.Padding(2);
            this.tpProducts.Name = "tpProducts";
            this.tpProducts.Padding = new System.Windows.Forms.Padding(2);
            this.tpProducts.Size = new System.Drawing.Size(403, 327);
            this.tpProducts.TabIndex = 0;
            this.tpProducts.Text = "Products";
            this.tpProducts.UseVisualStyleBackColor = true;
            this.tpProducts.Click += new System.EventHandler(this.tpProducts_Click);
            // 
            // productsGrid
            // 
            this.productsGrid.AllowUserToAddRows = false;
            this.productsGrid.AllowUserToDeleteRows = false;
            this.productsGrid.AllowUserToResizeRows = false;
            this.productsGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.productsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.productsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.productsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Style});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.productsGrid.EnableHeadersVisualStyles = false;
            this.productsGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.productsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.productsGrid.Location = new System.Drawing.Point(0, 2);
            this.productsGrid.Margin = new System.Windows.Forms.Padding(2);
            this.productsGrid.MultiSelect = false;
            this.productsGrid.Name = "productsGrid";
            this.productsGrid.ReadOnly = true;
            this.productsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.productsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.productsGrid.RowTemplate.Height = 24;
            this.productsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.productsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsGrid.Size = new System.Drawing.Size(403, 303);
            this.productsGrid.Style = MetroFramework.MetroColorStyle.Teal;
            this.productsGrid.TabIndex = 2;
            this.productsGrid.Theme = MetroFramework.MetroThemeStyle.Light;
            this.productsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsGrid_CellClick);
            this.productsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsGrid_CellContentClick);
            this.productsGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productsGrid_CellMouseDoubleClick);
            this.productsGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productsGrid_CellMouseUp);
            // 
            // Product
            // 
            this.Product.HeaderText = "Product (Right click for more info)";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 245;
            // 
            // Style
            // 
            this.Style.FillWeight = 125F;
            this.Style.HeaderText = "Style Code";
            this.Style.Name = "Style";
            this.Style.ReadOnly = true;
            this.Style.Width = 125;
            // 
            // txtSearch
            // 
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(0, 306);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PromptText = "Style Code Search (If no product then click next)";
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(403, 18);
            this.txtSearch.Style = MetroFramework.MetroColorStyle.Teal;
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // tpNikeAccount
            // 
            this.tpNikeAccount.Controls.Add(this.nikeAccountsGrid);
            this.tpNikeAccount.Controls.Add(this.metroLabel1);
            this.tpNikeAccount.Location = new System.Drawing.Point(0, 0);
            this.tpNikeAccount.Margin = new System.Windows.Forms.Padding(2);
            this.tpNikeAccount.Name = "tpNikeAccount";
            this.tpNikeAccount.Padding = new System.Windows.Forms.Padding(2);
            this.tpNikeAccount.Size = new System.Drawing.Size(403, 327);
            this.tpNikeAccount.TabIndex = 1;
            this.tpNikeAccount.Text = "NikeAccount";
            this.tpNikeAccount.UseVisualStyleBackColor = true;
            this.tpNikeAccount.Click += new System.EventHandler(this.tpNikeAccount_Click);
            // 
            // nikeAccountsGrid
            // 
            this.nikeAccountsGrid.AllowUserToAddRows = false;
            this.nikeAccountsGrid.AllowUserToDeleteRows = false;
            this.nikeAccountsGrid.AllowUserToResizeRows = false;
            this.nikeAccountsGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nikeAccountsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nikeAccountsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.nikeAccountsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nikeAccountsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.nikeAccountsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nikeAccountsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Active,
            this.Email,
            this.Password,
            this.Size});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nikeAccountsGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.nikeAccountsGrid.EnableHeadersVisualStyles = false;
            this.nikeAccountsGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nikeAccountsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nikeAccountsGrid.Location = new System.Drawing.Point(0, 33);
            this.nikeAccountsGrid.Name = "nikeAccountsGrid";
            this.nikeAccountsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nikeAccountsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.nikeAccountsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.nikeAccountsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.nikeAccountsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nikeAccountsGrid.Size = new System.Drawing.Size(403, 294);
            this.nikeAccountsGrid.Style = MetroFramework.MetroColorStyle.Teal;
            this.nikeAccountsGrid.TabIndex = 15;
            this.nikeAccountsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.nikeAccountsGrid_CellValueChanged);
            // 
            // Active
            // 
            this.Active.FillWeight = 40F;
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.Width = 40;
            // 
            // Email
            // 
            this.Email.FillWeight = 150F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // Password
            // 
            this.Password.FillWeight = 120F;
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 120;
            // 
            // Size
            // 
            this.Size.FillWeight = 52F;
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.Width = 52;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(141, 2);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(120, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Nike Accounts";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(346, 387);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(54, 23);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "Test";
            this.btnTest.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnTest.UseSelectable = true;
            this.btnTest.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // txtProxie
            // 
            this.txtProxie.AllowDrop = true;
            this.txtProxie.Lines = new string[0];
            this.txtProxie.Location = new System.Drawing.Point(24, 387);
            this.txtProxie.MaxLength = 32767;
            this.txtProxie.Name = "txtProxie";
            this.txtProxie.PasswordChar = '\0';
            this.txtProxie.PromptText = "Proxy i.e 127.0.0.1:8123:admin:admin";
            this.txtProxie.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProxie.SelectedText = "";
            this.txtProxie.Size = new System.Drawing.Size(273, 23);
            this.txtProxie.TabIndex = 17;
            this.txtProxie.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtProxie.UseSelectable = true;
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(303, 387);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(37, 23);
            this.btnGrab.TabIndex = 18;
            this.btnGrab.Text = "Grab";
            this.btnGrab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnGrab.UseSelectable = true;
            this.btnGrab.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(406, 387);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(21, 23);
            this.metroButton2.TabIndex = 19;
            this.metroButton2.Text = "A";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click_1);
            // 
            // CreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(453, 455);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.txtProxie);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.spPages);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtProxy);
            this.Name = "CreateTask";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Text = "Create Task";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateTask_FormClosing);
            this.Load += new System.EventHandler(this.CreateTask_Load);
            this.spPages.ResumeLayout(false);
            this.tpRegion.ResumeLayout(false);
            this.tpRegion.PerformLayout();
            this.tpProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productsGrid)).EndInit();
            this.tpNikeAccount.ResumeLayout(false);
            this.tpNikeAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nikeAccountsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnNext;
        private MetroFramework.Controls.MetroButton btnBack;
        private StackPanel spPages;
        private System.Windows.Forms.TabPage tpProducts;
        private System.Windows.Forms.TabPage tpNikeAccount;
        private MetroFramework.Controls.MetroTextBox txtProxy;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroGrid productsGrid;
        private MetroFramework.Controls.MetroGrid nikeAccountsGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Style;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroButton btnTest;
        private MetroFramework.Controls.MetroTextBox txtProxie;
        private MetroFramework.Controls.MetroButton btnGrab;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TabPage tpRegion;
        private MetroFramework.Controls.MetroComboBox cboRegions;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.CheckBox chkMutliATC;
    }
}