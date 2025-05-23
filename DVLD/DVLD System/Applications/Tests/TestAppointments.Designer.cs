﻿namespace DVLD.DVLD_System.Applications.Tests
{
    partial class TestAppointments
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
            this.ucLocalLicenseInfoWithApplication1 = new DVLD_System.Applications.Local_Driving_License_Application.User_Controls.ucLocalLicenseInfoWithApplication();
            this.ucList1 = new ucList();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.btnAddTestAll = new Guna.UI2.WinForms.Guna2Button();
            this.cmsRow = new ReaLTaiizor.Controls.CrownContextMenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucLocalLicenseInfoWithApplication1
            // 
            this.ucLocalLicenseInfoWithApplication1.Location = new System.Drawing.Point(268, 145);
            this.ucLocalLicenseInfoWithApplication1.Name = "ucLocalLicenseInfoWithApplication1";
            this.ucLocalLicenseInfoWithApplication1.Size = new System.Drawing.Size(1239, 427);
            this.ucLocalLicenseInfoWithApplication1.TabIndex = 2;
            // 
            // ucList1
            // 
            this.ucList1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucList1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucList1.Location = new System.Drawing.Point(0, 578);
            this.ucList1.Name = "ucList1";
            this.ucList1.Size = new System.Drawing.Size(1775, 450);
            this.ucList1.TabIndex = 1;
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
            // btnAddTestAll
            // 
            this.btnAddTestAll.Animated = true;
            this.btnAddTestAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTestAll.BorderThickness = 2;
            this.btnAddTestAll.CheckedState.Parent = this.btnAddTestAll;
            this.btnAddTestAll.CustomImages.Parent = this.btnAddTestAll;
            this.btnAddTestAll.FillColor = System.Drawing.Color.Transparent;
            this.btnAddTestAll.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddTestAll.ForeColor = System.Drawing.Color.Black;
            this.btnAddTestAll.HoverState.Parent = this.btnAddTestAll;
            this.btnAddTestAll.Image = global::DVLD.Properties.Resources.Test;
            this.btnAddTestAll.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddTestAll.ImageOffset = new System.Drawing.Point(-8, 0);
            this.btnAddTestAll.ImageSize = new System.Drawing.Size(28, 28);
            this.btnAddTestAll.Location = new System.Drawing.Point(1644, 581);
            this.btnAddTestAll.Name = "btnAddTestAll";
            this.btnAddTestAll.ShadowDecoration.Parent = this.btnAddTestAll;
            this.btnAddTestAll.Size = new System.Drawing.Size(119, 38);
            this.btnAddTestAll.TabIndex = 62;
            this.btnAddTestAll.Text = "Add Test";
            this.btnAddTestAll.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddTestAll.Click += new System.EventHandler(this.btnAddTestAll_Click);
            // 
            // cmsRow
            // 
            this.cmsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmsRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cmsRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsRow.Name = "cmsRow";
            this.cmsRow.Size = new System.Drawing.Size(142, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.editToolStripMenuItem.Text = "Edit Test";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.deleteToolStripMenuItem.Text = "Take Test";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // TestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.btnAddTestAll);
            this.Controls.Add(this.ucLocalLicenseInfoWithApplication1);
            this.Controls.Add(this.ucList1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestAppointments";
            this.Text = "TestAppointments";
            this.cmsRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private ucList ucList1;
        private DVLD_System.Applications.Local_Driving_License_Application.User_Controls.ucLocalLicenseInfoWithApplication ucLocalLicenseInfoWithApplication1;
        private Guna.UI2.WinForms.Guna2Button btnAddTestAll;
        private ReaLTaiizor.Controls.CrownContextMenuStrip cmsRow;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}