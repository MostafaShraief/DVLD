namespace DVLD
{
    partial class LoginScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.icbPassword = new Guna.UI2.WinForms.Guna2ImageCheckBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.cbRememberMe = new Guna.UI2.WinForms.Guna2CheckBox();
            this.ucTopBar1 = new User_Controls.ucTopBar();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(176, 241);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(186, 40);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbUserName
            // 
            this.tbUserName.Animated = true;
            this.tbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUserName.DefaultText = "";
            this.tbUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUserName.DisabledState.Parent = this.tbUserName;
            this.tbUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbUserName.FocusedState.Parent = this.tbUserName;
            this.tbUserName.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.tbUserName.ForeColor = System.Drawing.Color.Black;
            this.tbUserName.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbUserName.HoverState.Parent = this.tbUserName;
            this.tbUserName.Location = new System.Drawing.Point(369, 241);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PasswordChar = '\0';
            this.tbUserName.PlaceholderText = "";
            this.tbUserName.SelectedText = "";
            this.tbUserName.ShadowDecoration.Parent = this.tbUserName;
            this.tbUserName.Size = new System.Drawing.Size(354, 40);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserName_KeyDown);
            // 
            // tbPassword
            // 
            this.tbPassword.Animated = true;
            this.tbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassword.DefaultText = "";
            this.tbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.DisabledState.Parent = this.tbPassword;
            this.tbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbPassword.FocusedState.Parent = this.tbPassword;
            this.tbPassword.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.tbPassword.ForeColor = System.Drawing.Color.Black;
            this.tbPassword.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbPassword.HoverState.Parent = this.tbPassword;
            this.tbPassword.Location = new System.Drawing.Point(369, 397);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.PlaceholderText = "";
            this.tbPassword.SelectedText = "";
            this.tbPassword.ShadowDecoration.Parent = this.tbPassword;
            this.tbPassword.Size = new System.Drawing.Size(354, 40);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(184, 397);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(178, 40);
            this.lblPassword.TabIndex = 41;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // icbPassword
            // 
            this.icbPassword.CheckedState.Image = global::DVLD.Properties.Resources.Eye;
            this.icbPassword.CheckedState.Parent = this.icbPassword;
            this.icbPassword.HoverState.Parent = this.icbPassword;
            this.icbPassword.Image = global::DVLD.Properties.Resources.image_2025_02_15_15_30_251;
            this.icbPassword.Location = new System.Drawing.Point(730, 397);
            this.icbPassword.Name = "icbPassword";
            this.icbPassword.PressedState.Parent = this.icbPassword;
            this.icbPassword.Size = new System.Drawing.Size(40, 40);
            this.icbPassword.TabIndex = 66;
            this.icbPassword.CheckedChanged += new System.EventHandler(this.icbPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderThickness = 2;
            this.btnLogin.CheckedState.Parent = this.btnLogin;
            this.btnLogin.CustomImages.Parent = this.btnLogin;
            this.btnLogin.FillColor = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.HoverState.Parent = this.btnLogin;
            this.btnLogin.Image = global::DVLD.Properties.Resources.Login;
            this.btnLogin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogin.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnLogin.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogin.Location = new System.Drawing.Point(477, 553);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ShadowDecoration.Parent = this.btnLogin;
            this.btnLogin.Size = new System.Drawing.Size(139, 38);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextOffset = new System.Drawing.Point(10, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.AutoSize = true;
            this.cbRememberMe.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRememberMe.CheckedState.BorderRadius = 2;
            this.cbRememberMe.CheckedState.BorderThickness = 0;
            this.cbRememberMe.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbRememberMe.Font = new System.Drawing.Font("Gadugi", 10F);
            this.cbRememberMe.Location = new System.Drawing.Point(580, 444);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.Size = new System.Drawing.Size(143, 24);
            this.cbRememberMe.TabIndex = 67;
            this.cbRememberMe.Text = "Remember me";
            this.cbRememberMe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbRememberMe.UncheckedState.BorderRadius = 2;
            this.cbRememberMe.UncheckedState.BorderThickness = 0;
            this.cbRememberMe.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbRememberMe.UseVisualStyleBackColor = true;
            // 
            // ucTopBar1
            // 
            this.ucTopBar1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTopBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTopBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTopBar1.Name = "ucTopBar1";
            this.ucTopBar1.Size = new System.Drawing.Size(1092, 52);
            this.ucTopBar1.TabIndex = 68;
            this.ucTopBar1.Load += new System.EventHandler(this.ucTopBar1_Load);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1092, 724);
            this.Controls.Add(this.ucTopBar1);
            this.Controls.Add(this.cbRememberMe);
            this.Controls.Add(this.icbPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lblUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginScreen_FormClosed);
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox tbUserName;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Guna.UI2.WinForms.Guna2ImageCheckBox icbPassword;
        private Guna.UI2.WinForms.Guna2CheckBox cbRememberMe;
        private User_Controls.ucTopBar ucTopBar1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}