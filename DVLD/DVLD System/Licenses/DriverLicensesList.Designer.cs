﻿namespace DVLD.DVLD_System.Licenses
{
    partial class DriverLicensesList
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
            this.ucList1 = new Applications.Local_Driving_License_Application.ucList();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.rbLocal = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbInternational = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lnklblPersonInfo = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ucList1
            // 
            this.ucList1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucList1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucList1.Location = new System.Drawing.Point(0, 242);
            this.ucList1.Name = "ucList1";
            this.ucList1.Size = new System.Drawing.Size(1775, 786);
            this.ucList1.TabIndex = 0;
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 1;
            // 
            // rbLocal
            // 
            this.rbLocal.AutoSize = true;
            this.rbLocal.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbLocal.CheckedState.BorderThickness = 0;
            this.rbLocal.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbLocal.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbLocal.CheckedState.InnerOffset = -4;
            this.rbLocal.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLocal.Location = new System.Drawing.Point(1165, 247);
            this.rbLocal.Name = "rbLocal";
            this.rbLocal.Size = new System.Drawing.Size(174, 33);
            this.rbLocal.TabIndex = 61;
            this.rbLocal.Text = "Local license";
            this.rbLocal.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbLocal.UncheckedState.BorderThickness = 2;
            this.rbLocal.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbLocal.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbLocal.UseVisualStyleBackColor = true;
            this.rbLocal.CheckedChanged += new System.EventHandler(this.rbLocal_CheckedChanged);
            // 
            // rbInternational
            // 
            this.rbInternational.AutoSize = true;
            this.rbInternational.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbInternational.CheckedState.BorderThickness = 0;
            this.rbInternational.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbInternational.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbInternational.CheckedState.InnerOffset = -4;
            this.rbInternational.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInternational.Location = new System.Drawing.Point(1371, 247);
            this.rbInternational.Name = "rbInternational";
            this.rbInternational.Size = new System.Drawing.Size(248, 33);
            this.rbInternational.TabIndex = 62;
            this.rbInternational.Text = "Internaional license";
            this.rbInternational.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbInternational.UncheckedState.BorderThickness = 2;
            this.rbInternational.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbInternational.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbInternational.UseVisualStyleBackColor = true;
            this.rbInternational.CheckedChanged += new System.EventHandler(this.rbInternational_CheckedChanged);
            // 
            // lnklblPersonInfo
            // 
            this.lnklblPersonInfo.AutoSize = true;
            this.lnklblPersonInfo.Font = new System.Drawing.Font("Gadugi", 15F);
            this.lnklblPersonInfo.Location = new System.Drawing.Point(12, 207);
            this.lnklblPersonInfo.Name = "lnklblPersonInfo";
            this.lnklblPersonInfo.Size = new System.Drawing.Size(140, 29);
            this.lnklblPersonInfo.TabIndex = 63;
            this.lnklblPersonInfo.TabStop = true;
            this.lnklblPersonInfo.Text = "Person Info";
            this.lnklblPersonInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblPersonInfo_LinkClicked);
            // 
            // DriverLicensesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.lnklblPersonInfo);
            this.Controls.Add(this.rbInternational);
            this.Controls.Add(this.rbLocal);
            this.Controls.Add(this.ucTitleScreen1);
            this.Controls.Add(this.ucList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DriverLicensesList";
            this.Text = "DriverLicensesList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Local_Driving_License_Application.ucList ucList1;
        private ucTitleScreen ucTitleScreen1;
        private Guna.UI2.WinForms.Guna2RadioButton rbLocal;
        private Guna.UI2.WinForms.Guna2RadioButton rbInternational;
        private System.Windows.Forms.LinkLabel lnklblPersonInfo;
    }
}