namespace DVLD.Manage_Users.User_Controls
{
    partial class ucAddEditUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddEditUser));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUser = new Guna.UI2.WinForms.Guna2Panel();
            this.cbChangePassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pbOldPassword = new System.Windows.Forms.PictureBox();
            this.tbOldPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.icbConfirmPassword = new Guna.UI2.WinForms.Guna2ImageCheckBox();
            this.icbPassword = new Guna.UI2.WinForms.Guna2ImageCheckBox();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pbConfirmPassword = new System.Windows.Forms.PictureBox();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pbPersonID = new System.Windows.Forms.PictureBox();
            this.tbConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserIDTitle = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucfindAndShowInfoPerson = new Manage_People.User_Controls.ucFindAndShowInfoPerson();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlUser);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteUser);
            this.flowLayoutPanel1.Controls.Add(this.btnAddPerson);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(492, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1010, 195);
            this.flowLayoutPanel1.TabIndex = 62;
            // 
            // pnlUser
            // 
            this.pnlUser.BorderColor = System.Drawing.Color.Black;
            this.pnlUser.BorderThickness = 3;
            this.pnlUser.Controls.Add(this.cbChangePassword);
            this.pnlUser.Controls.Add(this.pbOldPassword);
            this.pnlUser.Controls.Add(this.tbOldPassword);
            this.pnlUser.Controls.Add(this.lblOldPassword);
            this.pnlUser.Controls.Add(this.icbConfirmPassword);
            this.pnlUser.Controls.Add(this.icbPassword);
            this.pnlUser.Controls.Add(this.cbIsActive);
            this.pnlUser.Controls.Add(this.pbConfirmPassword);
            this.pnlUser.Controls.Add(this.pbPassword);
            this.pnlUser.Controls.Add(this.pictureBox6);
            this.pnlUser.Controls.Add(this.pbPersonID);
            this.pnlUser.Controls.Add(this.tbConfirmPassword);
            this.pnlUser.Controls.Add(this.lblConfirm);
            this.pnlUser.Controls.Add(this.tbPassword);
            this.pnlUser.Controls.Add(this.lblPassword);
            this.pnlUser.Controls.Add(this.label1);
            this.pnlUser.Controls.Add(this.tbUserName);
            this.pnlUser.Controls.Add(this.lblUserID);
            this.pnlUser.Controls.Add(this.lblUserIDTitle);
            this.pnlUser.Location = new System.Drawing.Point(3, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.ShadowDecoration.Parent = this.pnlUser;
            this.pnlUser.Size = new System.Drawing.Size(862, 192);
            this.pnlUser.TabIndex = 61;
            this.pnlUser.Visible = false;
            // 
            // cbChangePassword
            // 
            this.cbChangePassword.AutoSize = true;
            this.cbChangePassword.Checked = true;
            this.cbChangePassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbChangePassword.CheckedState.BorderRadius = 2;
            this.cbChangePassword.CheckedState.BorderThickness = 0;
            this.cbChangePassword.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbChangePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChangePassword.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold);
            this.cbChangePassword.Location = new System.Drawing.Point(659, 85);
            this.cbChangePassword.Name = "cbChangePassword";
            this.cbChangePassword.Size = new System.Drawing.Size(197, 28);
            this.cbChangePassword.TabIndex = 55;
            this.cbChangePassword.Text = "Change Password";
            this.cbChangePassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbChangePassword.UncheckedState.BorderRadius = 2;
            this.cbChangePassword.UncheckedState.BorderThickness = 0;
            this.cbChangePassword.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbChangePassword.UseVisualStyleBackColor = true;
            this.cbChangePassword.Visible = false;
            this.cbChangePassword.CheckedChanged += new System.EventHandler(this.cbChangePassword_CheckedChanged);
            this.cbChangePassword.VisibleChanged += new System.EventHandler(this.cbChangePassword_CheckedChanged);
            // 
            // pbOldPassword
            // 
            this.pbOldPassword.BackColor = System.Drawing.Color.Transparent;
            this.pbOldPassword.Image = global::DVLD.Properties.Resources.Password;
            this.pbOldPassword.Location = new System.Drawing.Point(470, 134);
            this.pbOldPassword.Name = "pbOldPassword";
            this.pbOldPassword.Size = new System.Drawing.Size(40, 40);
            this.pbOldPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOldPassword.TabIndex = 54;
            this.pbOldPassword.TabStop = false;
            this.pbOldPassword.Visible = false;
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Animated = true;
            this.tbOldPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOldPassword.DefaultText = "";
            this.tbOldPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbOldPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbOldPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOldPassword.DisabledState.Parent = this.tbOldPassword;
            this.tbOldPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOldPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbOldPassword.FocusedState.Parent = this.tbOldPassword;
            this.tbOldPassword.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.tbOldPassword.ForeColor = System.Drawing.Color.Black;
            this.tbOldPassword.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbOldPassword.HoverState.Parent = this.tbOldPassword;
            this.tbOldPassword.Location = new System.Drawing.Point(659, 134);
            this.tbOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '\0';
            this.tbOldPassword.PlaceholderText = "";
            this.tbOldPassword.SelectedText = "";
            this.tbOldPassword.ShadowDecoration.Parent = this.tbOldPassword;
            this.tbOldPassword.Size = new System.Drawing.Size(179, 40);
            this.tbOldPassword.TabIndex = 53;
            this.tbOldPassword.Visible = false;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblOldPassword.Font = new System.Drawing.Font("Gadugi", 11F, System.Drawing.FontStyle.Bold);
            this.lblOldPassword.Location = new System.Drawing.Point(516, 144);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(136, 21);
            this.lblOldPassword.TabIndex = 52;
            this.lblOldPassword.Text = "Old Password:";
            this.lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOldPassword.Visible = false;
            // 
            // icbConfirmPassword
            // 
            this.icbConfirmPassword.CheckedState.Image = global::DVLD.Properties.Resources.Eye;
            this.icbConfirmPassword.CheckedState.Parent = this.icbConfirmPassword;
            this.icbConfirmPassword.HoverState.Parent = this.icbConfirmPassword;
            this.icbConfirmPassword.Image = global::DVLD.Properties.Resources.image_2025_02_15_15_30_251;
            this.icbConfirmPassword.Location = new System.Drawing.Point(417, 134);
            this.icbConfirmPassword.Name = "icbConfirmPassword";
            this.icbConfirmPassword.PressedState.Parent = this.icbConfirmPassword;
            this.icbConfirmPassword.Size = new System.Drawing.Size(40, 40);
            this.icbConfirmPassword.TabIndex = 51;
            this.icbConfirmPassword.CheckedChanged += new System.EventHandler(this.icbConfirmPassword_CheckedChanged);
            // 
            // icbPassword
            // 
            this.icbPassword.CheckedState.Image = global::DVLD.Properties.Resources.Eye;
            this.icbPassword.CheckedState.Parent = this.icbPassword;
            this.icbPassword.HoverState.Parent = this.icbPassword;
            this.icbPassword.Image = global::DVLD.Properties.Resources.image_2025_02_15_15_30_251;
            this.icbPassword.Location = new System.Drawing.Point(417, 78);
            this.icbPassword.Name = "icbPassword";
            this.icbPassword.PressedState.Parent = this.icbPassword;
            this.icbPassword.Size = new System.Drawing.Size(40, 40);
            this.icbPassword.TabIndex = 50;
            this.icbPassword.CheckedChanged += new System.EventHandler(this.icbPassword_CheckedChanged);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.CheckedState.BorderRadius = 2;
            this.cbIsActive.CheckedState.BorderThickness = 0;
            this.cbIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbIsActive.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.cbIsActive.Location = new System.Drawing.Point(481, 82);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(136, 34);
            this.cbIsActive.TabIndex = 49;
            this.cbIsActive.Text = "Is Active";
            this.cbIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsActive.UncheckedState.BorderRadius = 2;
            this.cbIsActive.UncheckedState.BorderThickness = 0;
            this.cbIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // pbConfirmPassword
            // 
            this.pbConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.pbConfirmPassword.Image = global::DVLD.Properties.Resources.Password;
            this.pbConfirmPassword.Location = new System.Drawing.Point(12, 134);
            this.pbConfirmPassword.Name = "pbConfirmPassword";
            this.pbConfirmPassword.Size = new System.Drawing.Size(40, 40);
            this.pbConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConfirmPassword.TabIndex = 48;
            this.pbConfirmPassword.TabStop = false;
            // 
            // pbPassword
            // 
            this.pbPassword.BackColor = System.Drawing.Color.Transparent;
            this.pbPassword.Image = global::DVLD.Properties.Resources.Password;
            this.pbPassword.Location = new System.Drawing.Point(12, 78);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(40, 40);
            this.pbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPassword.TabIndex = 47;
            this.pbPassword.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::DVLD.Properties.Resources.UserName;
            this.pictureBox6.Location = new System.Drawing.Point(12, 22);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 40);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 46;
            this.pictureBox6.TabStop = false;
            // 
            // pbPersonID
            // 
            this.pbPersonID.BackColor = System.Drawing.Color.Transparent;
            this.pbPersonID.Image = global::DVLD.Properties.Resources.ID;
            this.pbPersonID.Location = new System.Drawing.Point(477, 25);
            this.pbPersonID.Name = "pbPersonID";
            this.pbPersonID.Size = new System.Drawing.Size(27, 30);
            this.pbPersonID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonID.TabIndex = 45;
            this.pbPersonID.TabStop = false;
            this.pbPersonID.Visible = false;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Animated = true;
            this.tbConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConfirmPassword.DefaultText = "";
            this.tbConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPassword.DisabledState.Parent = this.tbConfirmPassword;
            this.tbConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbConfirmPassword.FocusedState.Parent = this.tbConfirmPassword;
            this.tbConfirmPassword.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.tbConfirmPassword.ForeColor = System.Drawing.Color.Black;
            this.tbConfirmPassword.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbConfirmPassword.HoverState.Parent = this.tbConfirmPassword;
            this.tbConfirmPassword.Location = new System.Drawing.Point(215, 134);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '\0';
            this.tbConfirmPassword.PlaceholderText = "";
            this.tbConfirmPassword.SelectedText = "";
            this.tbConfirmPassword.ShadowDecoration.Parent = this.tbConfirmPassword;
            this.tbConfirmPassword.Size = new System.Drawing.Size(179, 40);
            this.tbConfirmPassword.TabIndex = 44;
            this.tbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPassword_Validating);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirm.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.lblConfirm.Location = new System.Drawing.Point(58, 139);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(116, 30);
            this.lblConfirm.TabIndex = 43;
            this.lblConfirm.Text = "Confirm:";
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tbPassword.Location = new System.Drawing.Point(215, 78);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.PlaceholderText = "";
            this.tbPassword.SelectedText = "";
            this.tbPassword.ShadowDecoration.Parent = this.tbPassword;
            this.tbPassword.Size = new System.Drawing.Size(179, 40);
            this.tbPassword.TabIndex = 42;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(58, 83);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(130, 30);
            this.lblPassword.TabIndex = 41;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(58, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 30);
            this.label1.TabIndex = 40;
            this.label1.Text = "User Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tbUserName.Location = new System.Drawing.Point(215, 20);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PasswordChar = '\0';
            this.tbUserName.PlaceholderText = "";
            this.tbUserName.SelectedText = "";
            this.tbUserName.ShadowDecoration.Parent = this.tbUserName;
            this.tbUserName.Size = new System.Drawing.Size(179, 40);
            this.tbUserName.TabIndex = 39;
            this.tbUserName.Validated += new System.EventHandler(this.tbUserName_Validated);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(622, 25);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(37, 30);
            this.lblUserID.TabIndex = 37;
            this.lblUserID.Text = "-1";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserID.Visible = false;
            // 
            // lblUserIDTitle
            // 
            this.lblUserIDTitle.AutoSize = true;
            this.lblUserIDTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUserIDTitle.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIDTitle.Location = new System.Drawing.Point(510, 25);
            this.lblUserIDTitle.Name = "lblUserIDTitle";
            this.lblUserIDTitle.Size = new System.Drawing.Size(106, 30);
            this.lblUserIDTitle.TabIndex = 36;
            this.lblUserIDTitle.Text = "User ID:";
            this.lblUserIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserIDTitle.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderThickness = 2;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(871, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(139, 38);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save User";
            this.btnSave.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Animated = true;
            this.btnDeleteUser.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.BorderThickness = 2;
            this.btnDeleteUser.CheckedState.Parent = this.btnDeleteUser;
            this.btnDeleteUser.CustomImages.Parent = this.btnDeleteUser;
            this.btnDeleteUser.FillColor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteUser.HoverState.Parent = this.btnDeleteUser;
            this.btnDeleteUser.Image = global::DVLD.Properties.Resources.trash_bin;
            this.btnDeleteUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDeleteUser.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnDeleteUser.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDeleteUser.Location = new System.Drawing.Point(871, 110);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.ShadowDecoration.Parent = this.btnDeleteUser;
            this.btnDeleteUser.Size = new System.Drawing.Size(139, 38);
            this.btnDeleteUser.TabIndex = 63;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDeleteUser.Visible = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Animated = true;
            this.btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.BorderThickness = 2;
            this.btnAddPerson.CheckedState.Parent = this.btnAddPerson;
            this.btnAddPerson.CustomImages.Parent = this.btnAddPerson;
            this.btnAddPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddPerson.HoverState.Parent = this.btnAddPerson;
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.Add_Person;
            this.btnAddPerson.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAddPerson.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddPerson.Location = new System.Drawing.Point(871, 66);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.ShadowDecoration.Parent = this.btnAddPerson;
            this.btnAddPerson.Size = new System.Drawing.Size(139, 38);
            this.btnAddPerson.TabIndex = 59;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddPerson.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ucfindAndShowInfoPerson
            // 
            this.ucfindAndShowInfoPerson.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucfindAndShowInfoPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucfindAndShowInfoPerson.Location = new System.Drawing.Point(0, 0);
            this.ucfindAndShowInfoPerson.Name = "ucfindAndShowInfoPerson";
            this.ucfindAndShowInfoPerson.Size = new System.Drawing.Size(1507, 767);
            this.ucfindAndShowInfoPerson.TabIndex = 63;
            // 
            // ucAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ucfindAndShowInfoPerson);
            this.Name = "ucAddEditUser";
            this.Size = new System.Drawing.Size(1507, 767);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private Guna.UI2.WinForms.Guna2Panel pnlUser;
        private System.Windows.Forms.Label lblUserIDTitle;
        private System.Windows.Forms.Label lblUserID;
        private Guna.UI2.WinForms.Guna2TextBox tbUserName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lblConfirm;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.PictureBox pbPersonID;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pbPassword;
        private Guna.UI2.WinForms.Guna2CheckBox cbIsActive;
        private System.Windows.Forms.PictureBox pbConfirmPassword;
        private Guna.UI2.WinForms.Guna2ImageCheckBox icbPassword;
        private Guna.UI2.WinForms.Guna2ImageCheckBox icbConfirmPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Manage_People.User_Controls.ucFindAndShowInfoPerson ucfindAndShowInfoPerson;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.PictureBox pbOldPassword;
        private Guna.UI2.WinForms.Guna2TextBox tbOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private Guna.UI2.WinForms.Guna2CheckBox cbChangePassword;
        private Guna.UI2.WinForms.Guna2Button btnDeleteUser;
    }
}
