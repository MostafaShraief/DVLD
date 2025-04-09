namespace DVLD.DVLD_System.Licenses.User_Control
{
    partial class ucFindLicenseInfo
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
            this.ucFindLicense1 = new DVLD_System.Applications.Local_Driving_License_Application.User_Controls.ucFindLicense();
            this.ucLicenseInfo1 = new DVLD_System.Licenses.User_Control.ucLicenseInfo();
            this.SuspendLayout();
            // 
            // ucFindLicense1
            // 
            this.ucFindLicense1.Location = new System.Drawing.Point(0, 0);
            this.ucFindLicense1.Name = "ucFindLicense1";
            this.ucFindLicense1.Size = new System.Drawing.Size(490, 149);
            this.ucFindLicense1.TabIndex = 0;
            // 
            // ucLicenseInfo1
            // 
            this.ucLicenseInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucLicenseInfo1.Location = new System.Drawing.Point(0, 155);
            this.ucLicenseInfo1.Name = "ucLicenseInfo1";
            this.ucLicenseInfo1.Size = new System.Drawing.Size(1042, 552);
            this.ucLicenseInfo1.TabIndex = 1;
            // 
            // ucFindLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucLicenseInfo1);
            this.Controls.Add(this.ucFindLicense1);
            this.Name = "ucFindLicenseInfo";
            this.Size = new System.Drawing.Size(1042, 707);
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_System.Applications.Local_Driving_License_Application.User_Controls.ucFindLicense ucFindLicense1;
        private DVLD_System.Licenses.User_Control.ucLicenseInfo ucLicenseInfo1;
    }
}
