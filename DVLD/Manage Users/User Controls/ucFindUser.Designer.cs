namespace DVLD.Manage_Users.User_Controls
{
    partial class ucFindUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFindUser));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.rbNationalNumber = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbPersonID = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.tbFind = new Guna.UI2.WinForms.Guna2TextBox();
            this.rbUsername = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbUserID = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 3;
            this.guna2Panel1.Controls.Add(this.rbNationalNumber);
            this.guna2Panel1.Controls.Add(this.rbPersonID);
            this.guna2Panel1.Controls.Add(this.btnFind);
            this.guna2Panel1.Controls.Add(this.tbFind);
            this.guna2Panel1.Controls.Add(this.rbUsername);
            this.guna2Panel1.Controls.Add(this.rbUserID);
            this.guna2Panel1.Controls.Add(this.lblDescriptionTitle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(484, 198);
            this.guna2Panel1.TabIndex = 1;
            // 
            // rbNationalNumber
            // 
            this.rbNationalNumber.AutoSize = true;
            this.rbNationalNumber.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.rbNationalNumber.CheckedState.BorderThickness = 0;
            this.rbNationalNumber.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbNationalNumber.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbNationalNumber.CheckedState.InnerOffset = -4;
            this.rbNationalNumber.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbNationalNumber.Location = new System.Drawing.Point(224, 93);
            this.rbNationalNumber.Name = "rbNationalNumber";
            this.rbNationalNumber.Size = new System.Drawing.Size(239, 34);
            this.rbNationalNumber.TabIndex = 65;
            this.rbNationalNumber.Text = "National Number";
            this.rbNationalNumber.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rbNationalNumber.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbNationalNumber.UncheckedState.BorderThickness = 2;
            this.rbNationalNumber.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbNationalNumber.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbNationalNumber.UseVisualStyleBackColor = true;
            this.rbNationalNumber.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPersonID
            // 
            this.rbPersonID.AutoSize = true;
            this.rbPersonID.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.rbPersonID.CheckedState.BorderThickness = 0;
            this.rbPersonID.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbPersonID.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbPersonID.CheckedState.InnerOffset = -4;
            this.rbPersonID.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbPersonID.Location = new System.Drawing.Point(224, 53);
            this.rbPersonID.Name = "rbPersonID";
            this.rbPersonID.Size = new System.Drawing.Size(147, 34);
            this.rbPersonID.TabIndex = 64;
            this.rbPersonID.Text = "Person ID";
            this.rbPersonID.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbPersonID.UncheckedState.BorderThickness = 2;
            this.rbPersonID.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbPersonID.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbPersonID.UseVisualStyleBackColor = true;
            this.rbPersonID.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.Animated = true;
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.BorderThickness = 2;
            this.btnFind.CheckedState.Parent = this.btnFind;
            this.btnFind.CustomImages.Parent = this.btnFind;
            this.btnFind.FillColor = System.Drawing.Color.Transparent;
            this.btnFind.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.HoverState.Parent = this.btnFind;
            this.btnFind.Image = global::DVLD.Properties.Resources.Search;
            this.btnFind.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFind.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnFind.ImageSize = new System.Drawing.Size(30, 30);
            this.btnFind.Location = new System.Drawing.Point(360, 140);
            this.btnFind.Name = "btnFind";
            this.btnFind.ShadowDecoration.Parent = this.btnFind;
            this.btnFind.Size = new System.Drawing.Size(103, 38);
            this.btnFind.TabIndex = 63;
            this.btnFind.Text = "Find";
            this.btnFind.TextOffset = new System.Drawing.Point(10, 0);
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Animated = true;
            this.tbFind.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFind.DefaultText = "";
            this.tbFind.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFind.DisabledState.Parent = this.tbFind;
            this.tbFind.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFind.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbFind.FocusedState.Parent = this.tbFind;
            this.tbFind.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.tbFind.ForeColor = System.Drawing.Color.Black;
            this.tbFind.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbFind.HoverState.Parent = this.tbFind;
            this.tbFind.Location = new System.Drawing.Point(20, 134);
            this.tbFind.Margin = new System.Windows.Forms.Padding(4);
            this.tbFind.Name = "tbFind";
            this.tbFind.PasswordChar = '\0';
            this.tbFind.PlaceholderText = "";
            this.tbFind.SelectedText = "";
            this.tbFind.ShadowDecoration.Parent = this.tbFind;
            this.tbFind.Size = new System.Drawing.Size(321, 44);
            this.tbFind.TabIndex = 62;
            this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
            this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            // 
            // rbUsername
            // 
            this.rbUsername.AutoSize = true;
            this.rbUsername.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.rbUsername.CheckedState.BorderThickness = 0;
            this.rbUsername.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbUsername.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbUsername.CheckedState.InnerOffset = -4;
            this.rbUsername.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbUsername.Location = new System.Drawing.Point(20, 93);
            this.rbUsername.Name = "rbUsername";
            this.rbUsername.Size = new System.Drawing.Size(152, 34);
            this.rbUsername.TabIndex = 61;
            this.rbUsername.Text = "Username";
            this.rbUsername.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbUsername.UncheckedState.BorderThickness = 2;
            this.rbUsername.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbUsername.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbUsername.UseVisualStyleBackColor = true;
            this.rbUsername.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbUserID
            // 
            this.rbUserID.AutoSize = true;
            this.rbUserID.Checked = true;
            this.rbUserID.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.rbUserID.CheckedState.BorderThickness = 0;
            this.rbUserID.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbUserID.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbUserID.CheckedState.InnerOffset = -4;
            this.rbUserID.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbUserID.Location = new System.Drawing.Point(20, 53);
            this.rbUserID.Name = "rbUserID";
            this.rbUserID.Size = new System.Drawing.Size(120, 34);
            this.rbUserID.TabIndex = 60;
            this.rbUserID.TabStop = true;
            this.rbUserID.Text = "User ID";
            this.rbUserID.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbUserID.UncheckedState.BorderThickness = 2;
            this.rbUserID.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbUserID.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbUserID.UseVisualStyleBackColor = true;
            this.rbUserID.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(13, 10);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(226, 40);
            this.lblDescriptionTitle.TabIndex = 59;
            this.lblDescriptionTitle.Text = "Find User By:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ucFindUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ucFindUser";
            this.Size = new System.Drawing.Size(484, 198);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2TextBox tbFind;
        private Guna.UI2.WinForms.Guna2RadioButton rbUsername;
        private Guna.UI2.WinForms.Guna2RadioButton rbUserID;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private Guna.UI2.WinForms.Guna2RadioButton rbNationalNumber;
        private Guna.UI2.WinForms.Guna2RadioButton rbPersonID;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
