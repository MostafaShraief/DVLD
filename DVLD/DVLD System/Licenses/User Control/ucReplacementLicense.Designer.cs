namespace DVLD.DVLD_System.Licenses.User_Control
{
    partial class ucReplacementLicense
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
            this.btnShowHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnReplaceLicense = new Guna.UI2.WinForms.Guna2Button();
            this.rbDamage = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbLost = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.ucrenewLicenseInfo1 = new DVLD_System.Licenses.User_Control.ucRenewLicenseInfo();
            this.ucFindLicenseInfo1 = new DVLD_System.Licenses.User_Control.ucFindLicenseInfo();
            this.SuspendLayout();
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Animated = true;
            this.btnShowHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHistory.BorderThickness = 2;
            this.btnShowHistory.CheckedState.Parent = this.btnShowHistory;
            this.btnShowHistory.CustomImages.Parent = this.btnShowHistory;
            this.btnShowHistory.Enabled = false;
            this.btnShowHistory.FillColor = System.Drawing.Color.Transparent;
            this.btnShowHistory.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowHistory.ForeColor = System.Drawing.Color.Black;
            this.btnShowHistory.HoverState.Parent = this.btnShowHistory;
            this.btnShowHistory.Image = global::DVLD.Properties.Resources.History;
            this.btnShowHistory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowHistory.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnShowHistory.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowHistory.Location = new System.Drawing.Point(492, 111);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.ShadowDecoration.Parent = this.btnShowHistory;
            this.btnShowHistory.Size = new System.Drawing.Size(158, 38);
            this.btnShowHistory.TabIndex = 69;
            this.btnShowHistory.Text = "Show History";
            this.btnShowHistory.TextOffset = new System.Drawing.Point(10, 0);
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // btnShowLicense
            // 
            this.btnShowLicense.Animated = true;
            this.btnShowLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnShowLicense.BorderThickness = 2;
            this.btnShowLicense.CheckedState.Parent = this.btnShowLicense;
            this.btnShowLicense.CustomImages.Parent = this.btnShowLicense;
            this.btnShowLicense.Enabled = false;
            this.btnShowLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnShowLicense.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowLicense.ForeColor = System.Drawing.Color.Black;
            this.btnShowLicense.HoverState.Parent = this.btnShowLicense;
            this.btnShowLicense.Image = global::DVLD.Properties.Resources.License;
            this.btnShowLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowLicense.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnShowLicense.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowLicense.Location = new System.Drawing.Point(882, 111);
            this.btnShowLicense.Name = "btnShowLicense";
            this.btnShowLicense.ShadowDecoration.Parent = this.btnShowLicense;
            this.btnShowLicense.Size = new System.Drawing.Size(158, 38);
            this.btnShowLicense.TabIndex = 68;
            this.btnShowLicense.Text = "Show License";
            this.btnShowLicense.TextOffset = new System.Drawing.Point(10, 0);
            this.btnShowLicense.Click += new System.EventHandler(this.btnShowLicenes_Click);
            // 
            // btnReplaceLicense
            // 
            this.btnReplaceLicense.Animated = true;
            this.btnReplaceLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnReplaceLicense.BorderThickness = 2;
            this.btnReplaceLicense.CheckedState.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.CustomImages.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.Enabled = false;
            this.btnReplaceLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnReplaceLicense.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnReplaceLicense.ForeColor = System.Drawing.Color.Black;
            this.btnReplaceLicense.HoverState.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.Image = global::DVLD.Properties.Resources.renew;
            this.btnReplaceLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReplaceLicense.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnReplaceLicense.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReplaceLicense.Location = new System.Drawing.Point(687, 111);
            this.btnReplaceLicense.Name = "btnReplaceLicense";
            this.btnReplaceLicense.ShadowDecoration.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.Size = new System.Drawing.Size(158, 38);
            this.btnReplaceLicense.TabIndex = 67;
            this.btnReplaceLicense.Text = "Replace License";
            this.btnReplaceLicense.TextOffset = new System.Drawing.Point(10, 0);
            this.btnReplaceLicense.Click += new System.EventHandler(this.btnReplaceLicense_Click);
            // 
            // rbDamage
            // 
            this.rbDamage.AutoSize = true;
            this.rbDamage.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDamage.CheckedState.BorderThickness = 0;
            this.rbDamage.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbDamage.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDamage.CheckedState.InnerOffset = -4;
            this.rbDamage.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbDamage.Location = new System.Drawing.Point(503, 46);
            this.rbDamage.Name = "rbDamage";
            this.rbDamage.Size = new System.Drawing.Size(130, 34);
            this.rbDamage.TabIndex = 70;
            this.rbDamage.Text = "Damage";
            this.rbDamage.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDamage.UncheckedState.BorderThickness = 2;
            this.rbDamage.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDamage.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbDamage.UseVisualStyleBackColor = true;
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbLost.CheckedState.BorderThickness = 0;
            this.rbLost.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbLost.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbLost.CheckedState.InnerOffset = -4;
            this.rbLost.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbLost.Location = new System.Drawing.Point(639, 46);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(83, 34);
            this.rbLost.TabIndex = 71;
            this.rbLost.Text = "Lost";
            this.rbLost.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbLost.UncheckedState.BorderThickness = 2;
            this.rbLost.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbLost.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbLost.UseVisualStyleBackColor = true;
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(496, 3);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(273, 40);
            this.lblDescriptionTitle.TabIndex = 72;
            this.lblDescriptionTitle.Text = "Replace Reason:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucrenewLicenseInfo1
            // 
            this.ucrenewLicenseInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucrenewLicenseInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucrenewLicenseInfo1.Location = new System.Drawing.Point(0, 714);
            this.ucrenewLicenseInfo1.Name = "ucrenewLicenseInfo1";
            this.ucrenewLicenseInfo1.Size = new System.Drawing.Size(1042, 234);
            this.ucrenewLicenseInfo1.TabIndex = 73;
            this.ucrenewLicenseInfo1.Visible = false;
            // 
            // ucFindLicenseInfo1
            // 
            this.ucFindLicenseInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucFindLicenseInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFindLicenseInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucFindLicenseInfo1.Name = "ucFindLicenseInfo1";
            this.ucFindLicenseInfo1.Size = new System.Drawing.Size(1042, 707);
            this.ucFindLicenseInfo1.TabIndex = 66;
            // 
            // ucReplacementLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ucrenewLicenseInfo1);
            this.Controls.Add(this.lblDescriptionTitle);
            this.Controls.Add(this.rbLost);
            this.Controls.Add(this.rbDamage);
            this.Controls.Add(this.btnShowHistory);
            this.Controls.Add(this.btnShowLicense);
            this.Controls.Add(this.btnReplaceLicense);
            this.Controls.Add(this.ucFindLicenseInfo1);
            this.Name = "ucReplacementLicense";
            this.Size = new System.Drawing.Size(1042, 948);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnShowHistory;
        private Guna.UI2.WinForms.Guna2Button btnShowLicense;
        private Guna.UI2.WinForms.Guna2Button btnReplaceLicense;
        private Guna.UI2.WinForms.Guna2RadioButton rbDamage;
        private Guna.UI2.WinForms.Guna2RadioButton rbLost;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private DVLD_System.Licenses.User_Control.ucFindLicenseInfo ucFindLicenseInfo1;
        private DVLD_System.Licenses.User_Control.ucRenewLicenseInfo ucrenewLicenseInfo1;
    }
}
