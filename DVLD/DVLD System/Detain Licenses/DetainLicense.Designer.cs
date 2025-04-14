namespace DVLD.DVLD_System.Detain_Licenses
{
    partial class DetainLicense
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
            this.ucFindLicenseInfo1 = new DVLD_System.Licenses.User_Control.ucFindLicenseInfo();
            this.ucAddDetainLicense1 = new DVLD_System.Applications.Detain_Licenses.User_Controls.ucAddDetainLicense();
            this.btnShowHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowLicense = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // ucFindLicenseInfo1
            // 
            this.ucFindLicenseInfo1.Location = new System.Drawing.Point(366, 85);
            this.ucFindLicenseInfo1.Name = "ucFindLicenseInfo1";
            this.ucFindLicenseInfo1.Size = new System.Drawing.Size(1042, 707);
            this.ucFindLicenseInfo1.TabIndex = 1;
            // 
            // ucAddDetainLicense1
            // 
            this.ucAddDetainLicense1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucAddDetainLicense1.Location = new System.Drawing.Point(366, 798);
            this.ucAddDetainLicense1.Name = "ucAddDetainLicense1";
            this.ucAddDetainLicense1.Size = new System.Drawing.Size(1042, 145);
            this.ucAddDetainLicense1.TabIndex = 0;
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
            this.btnShowHistory.Location = new System.Drawing.Point(859, 196);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.ShadowDecoration.Parent = this.btnShowHistory;
            this.btnShowHistory.Size = new System.Drawing.Size(158, 38);
            this.btnShowHistory.TabIndex = 65;
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
            this.btnShowLicense.Location = new System.Drawing.Point(1054, 196);
            this.btnShowLicense.Name = "btnShowLicense";
            this.btnShowLicense.ShadowDecoration.Parent = this.btnShowLicense;
            this.btnShowLicense.Size = new System.Drawing.Size(158, 38);
            this.btnShowLicense.TabIndex = 63;
            this.btnShowLicense.Text = "Show License";
            this.btnShowLicense.TextOffset = new System.Drawing.Point(10, 0);
            this.btnShowLicense.Click += new System.EventHandler(this.btnShowLicense_Click);
            // 
            // DetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.btnShowHistory);
            this.Controls.Add(this.btnShowLicense);
            this.Controls.Add(this.ucFindLicenseInfo1);
            this.Controls.Add(this.ucAddDetainLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetainLicense";
            this.Text = "DetainLicense";
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_System.Applications.Detain_Licenses.User_Controls.ucAddDetainLicense ucAddDetainLicense1;
        private DVLD_System.Licenses.User_Control.ucFindLicenseInfo ucFindLicenseInfo1;
        private Guna.UI2.WinForms.Guna2Button btnShowHistory;
        private Guna.UI2.WinForms.Guna2Button btnShowLicense;
    }
}