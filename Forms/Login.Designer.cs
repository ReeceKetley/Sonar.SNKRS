namespace SonarSNKRS
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.spinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // spinner
            // 
            this.spinner.Location = new System.Drawing.Point(137, 171);
            this.spinner.Maximum = 100;
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(84, 45);
            this.spinner.Speed = 0.5F;
            this.spinner.Spinning = false;
            this.spinner.Style = MetroFramework.MetroColorStyle.Teal;
            this.spinner.TabIndex = 3;
            this.spinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.spinner.UseSelectable = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(23, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(318, 31);
            this.btnLogin.Style = MetroFramework.MetroColorStyle.Green;
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(24, 66);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PromptText = "Email";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(318, 23);
            this.txtEmail.Style = MetroFramework.MetroColorStyle.Green;
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtEmail.UseSelectable = true;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(24, 98);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PromptText = "Password";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(318, 23);
            this.txtPassword.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtPassword.UseSelectable = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(371, 239);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtEmail);
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtEmail;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroProgressSpinner spinner;
        private MetroFramework.Controls.MetroTextBox txtPassword;
    }
}