namespace SonarSNKRS.Forms
{
    partial class NikeAccountsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.txtSize = new MetroFramework.Controls.MetroTextBox();
            this.cboProviders = new MetroFramework.Controls.MetroComboBox();
            this.txtCell = new MetroFramework.Controls.MetroTextBox();
            this.txtNikePassword = new MetroFramework.Controls.MetroTextBox();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.btnAutoGen = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.CreateBtn = new MetroFramework.Controls.MetroButton();
            this.olvNikeAccounts = new BrightIdeasSoftware.ObjectListView();
            this.olvEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPassword = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvContact = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.olvNikeAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(324, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Amount: 1";
            // 
            // txtContact
            // 
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(26, 424);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.PromptText = "Contact Email";
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.Size = new System.Drawing.Size(630, 18);
            this.txtContact.TabIndex = 16;
            this.txtContact.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtContact.UseSelectable = true;
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(386, 480);
            this.metroTrackBar1.Maximum = 20;
            this.metroTrackBar1.Minimum = 1;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(65, 17);
            this.metroTrackBar1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroTrackBar1.TabIndex = 15;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBar1.Value = 1;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            // 
            // txtSize
            // 
            this.txtSize.Lines = new string[] {
        "9.5"};
            this.txtSize.Location = new System.Drawing.Point(26, 378);
            this.txtSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtSize.MaxLength = 32767;
            this.txtSize.Name = "txtSize";
            this.txtSize.PasswordChar = '\0';
            this.txtSize.PromptText = "Nike Size";
            this.txtSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSize.SelectedText = "";
            this.txtSize.Size = new System.Drawing.Size(630, 18);
            this.txtSize.TabIndex = 14;
            this.txtSize.Text = "9.5";
            this.txtSize.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtSize.UseSelectable = true;
            // 
            // cboProviders
            // 
            this.cboProviders.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cboProviders.FormattingEnabled = true;
            this.cboProviders.ItemHeight = 19;
            this.cboProviders.Location = new System.Drawing.Point(440, 446);
            this.cboProviders.Margin = new System.Windows.Forms.Padding(2);
            this.cboProviders.Name = "cboProviders";
            this.cboProviders.Size = new System.Drawing.Size(216, 25);
            this.cboProviders.Style = MetroFramework.MetroColorStyle.Teal;
            this.cboProviders.TabIndex = 13;
            this.cboProviders.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cboProviders.UseSelectable = true;
            // 
            // txtCell
            // 
            this.txtCell.Lines = new string[0];
            this.txtCell.Location = new System.Drawing.Point(26, 449);
            this.txtCell.Margin = new System.Windows.Forms.Padding(2);
            this.txtCell.MaxLength = 32767;
            this.txtCell.Name = "txtCell";
            this.txtCell.PasswordChar = '\0';
            this.txtCell.PromptText = "Cell Number";
            this.txtCell.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCell.SelectedText = "";
            this.txtCell.Size = new System.Drawing.Size(410, 18);
            this.txtCell.TabIndex = 12;
            this.txtCell.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtCell.UseSelectable = true;
            this.txtCell.TextChanged += new System.EventHandler(this.txtCell_TextChanged);
            this.txtCell.Click += new System.EventHandler(this.txtCell_Click);
            this.txtCell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCell_KeyPress);
            // 
            // txtNikePassword
            // 
            this.txtNikePassword.Lines = new string[0];
            this.txtNikePassword.Location = new System.Drawing.Point(26, 401);
            this.txtNikePassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtNikePassword.MaxLength = 32767;
            this.txtNikePassword.Name = "txtNikePassword";
            this.txtNikePassword.PasswordChar = '\0';
            this.txtNikePassword.PromptText = "Nike Password";
            this.txtNikePassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNikePassword.SelectedText = "";
            this.txtNikePassword.Size = new System.Drawing.Size(630, 18);
            this.txtNikePassword.TabIndex = 5;
            this.txtNikePassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtNikePassword.UseSelectable = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(26, 355);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PromptText = "Nike Email";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(630, 18);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtEmail.UseSelectable = true;
            // 
            // btnAutoGen
            // 
            this.btnAutoGen.Location = new System.Drawing.Point(199, 480);
            this.btnAutoGen.Margin = new System.Windows.Forms.Padding(2);
            this.btnAutoGen.Name = "btnAutoGen";
            this.btnAutoGen.Size = new System.Drawing.Size(120, 18);
            this.btnAutoGen.TabIndex = 3;
            this.btnAutoGen.Text = "AutoGenerate";
            this.btnAutoGen.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAutoGen.UseSelectable = true;
            this.btnAutoGen.Click += new System.EventHandler(this.btnAutoGen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(459, 479);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 18);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(26, 480);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(169, 18);
            this.CreateBtn.TabIndex = 1;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CreateBtn.UseSelectable = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // olvNikeAccounts
            // 
            this.olvNikeAccounts.AllColumns.Add(this.olvEmail);
            this.olvNikeAccounts.AllColumns.Add(this.olvPassword);
            this.olvNikeAccounts.AllColumns.Add(this.olvContact);
            this.olvNikeAccounts.AllColumns.Add(this.olvSize);
            this.olvNikeAccounts.AllColumns.Add(this.olvNumber);
            this.olvNikeAccounts.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvNikeAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvEmail,
            this.olvPassword,
            this.olvContact,
            this.olvSize,
            this.olvNumber});
            this.olvNikeAccounts.FullRowSelect = true;
            this.olvNikeAccounts.Location = new System.Drawing.Point(26, 50);
            this.olvNikeAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.olvNikeAccounts.Name = "olvNikeAccounts";
            this.olvNikeAccounts.ShowGroups = false;
            this.olvNikeAccounts.Size = new System.Drawing.Size(630, 301);
            this.olvNikeAccounts.TabIndex = 0;
            this.olvNikeAccounts.UseCompatibleStateImageBehavior = false;
            this.olvNikeAccounts.UseOverlays = false;
            this.olvNikeAccounts.View = System.Windows.Forms.View.Details;
            this.olvNikeAccounts.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvNikeAccounts_CellEditFinishing);
            this.olvNikeAccounts.SelectedIndexChanged += new System.EventHandler(this.olvNikeAccounts_SelectedIndexChanged);
            // 
            // olvEmail
            // 
            this.olvEmail.CellPadding = null;
            this.olvEmail.Text = "Email";
            this.olvEmail.Width = 200;
            // 
            // olvPassword
            // 
            this.olvPassword.CellPadding = null;
            this.olvPassword.Text = "Password";
            this.olvPassword.Width = 75;
            // 
            // olvContact
            // 
            this.olvContact.CellPadding = null;
            this.olvContact.Text = "Contact Email";
            this.olvContact.Width = 150;
            // 
            // olvSize
            // 
            this.olvSize.CellPadding = null;
            this.olvSize.IsEditable = false;
            this.olvSize.Text = "Size";
            this.olvSize.Width = 40;
            // 
            // olvNumber
            // 
            this.olvNumber.CellPadding = null;
            this.olvNumber.IsEditable = false;
            this.olvNumber.Text = "Number";
            this.olvNumber.Width = 180;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(569, 479);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(87, 18);
            this.metroButton1.TabIndex = 18;
            this.metroButton1.Text = "Import";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "accounts.csv";
            // 
            // NikeAccountsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(685, 516);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.metroTrackBar1);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.cboProviders);
            this.Controls.Add(this.txtCell);
            this.Controls.Add(this.txtNikePassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnAutoGen);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.olvNikeAccounts);
            this.Name = "NikeAccountsForm";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Text = "Nike Accounts";
            this.Load += new System.EventHandler(this.NikeAccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvNikeAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvNikeAccounts;
        private BrightIdeasSoftware.OLVColumn olvEmail;
        private BrightIdeasSoftware.OLVColumn olvPassword;
        private MetroFramework.Controls.MetroButton CreateBtn;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnAutoGen;
        private MetroFramework.Controls.MetroTextBox txtEmail;
        private MetroFramework.Controls.MetroTextBox txtNikePassword;
        private BrightIdeasSoftware.OLVColumn olvNumber;
        private MetroFramework.Controls.MetroComboBox cboProviders;
        private MetroFramework.Controls.MetroTextBox txtCell;
        private MetroFramework.Controls.MetroTextBox txtSize;
        private BrightIdeasSoftware.OLVColumn olvSize;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private BrightIdeasSoftware.OLVColumn olvContact;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}