namespace DVLD.Applications.Local_Driving_License_Application
{
    partial class ShowLocalLicenseInfo
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
            this.ucTitleScreen1 = new ucTitleScreen();
            this.ucLocalLicenseInfo1 = new Applications.Local_Driving_License_Application.User_Controls.ucLocalLicenseInfo();
            this.SuspendLayout();
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 0;
            // 
            // ucLocalLicenseInfo1
            // 
            this.ucLocalLicenseInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucLocalLicenseInfo1.Location = new System.Drawing.Point(137, 215);
            this.ucLocalLicenseInfo1.Name = "ucLocalLicenseInfo1";
            this.ucLocalLicenseInfo1.Size = new System.Drawing.Size(1500, 749);
            this.ucLocalLicenseInfo1.TabIndex = 1;
            // 
            // ShowLocalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucLocalLicenseInfo1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowLocalLicenseInfo";
            this.Text = "ShowLocalLicenseInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private Applications.Local_Driving_License_Application.User_Controls.ucLocalLicenseInfo ucLocalLicenseInfo1;
    }
}