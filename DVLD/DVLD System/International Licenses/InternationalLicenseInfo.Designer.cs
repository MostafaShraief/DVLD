﻿namespace DVLD.DVLD_System.International_Licenses
{
    partial class InternationalLicenseInfo
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
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.ucTopBar1 = new User_Controls.ucTopBar();
            this.ucInternationalLicenseInfo1 = new DVLD_System.International_Licenses.ucInternationalLicenseInfo();
            this.SuspendLayout();
            // 
            // ucTopBar1
            // 
            this.ucTopBar1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTopBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTopBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTopBar1.Name = "ucTopBar1";
            this.ucTopBar1.Size = new System.Drawing.Size(1047, 52);
            this.ucTopBar1.TabIndex = 128;
            // 
            // ucInternationalLicenseInfo1
            // 
            this.ucInternationalLicenseInfo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucInternationalLicenseInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucInternationalLicenseInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucInternationalLicenseInfo1.Location = new System.Drawing.Point(0, 52);
            this.ucInternationalLicenseInfo1.Name = "ucInternationalLicenseInfo1";
            this.ucInternationalLicenseInfo1.Size = new System.Drawing.Size(1047, 419);
            this.ucInternationalLicenseInfo1.TabIndex = 0;
            // 
            // InternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1047, 471);
            this.Controls.Add(this.ucTopBar1);
            this.Controls.Add(this.ucInternationalLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InternationalLicenseInfo";
            this.Text = "InternationalLicenseInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_System.International_Licenses.ucInternationalLicenseInfo ucInternationalLicenseInfo1;
        private User_Controls.ucTopBar ucTopBar1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}