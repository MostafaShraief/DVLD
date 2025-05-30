﻿namespace DVLD.Applications
{
    partial class ManageApplications
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLocalLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnListUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnTestTypes = new Guna.UI2.WinForms.Guna2Button();
            this.btnRenewLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnReplaceLicense = new Guna.UI2.WinForms.Guna2Button();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.btnReleaseLicense = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(1042, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(680, 570);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Hover on any option to show details.";
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(1042, 200);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(233, 40);
            this.lblDescriptionTitle.TabIndex = 12;
            this.lblDescriptionTitle.Text = "• Description:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLocalLicense);
            this.flowLayoutPanel1.Controls.Add(this.btnListUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnTestTypes);
            this.flowLayoutPanel1.Controls.Add(this.btnRenewLicense);
            this.flowLayoutPanel1.Controls.Add(this.btnReplaceLicense);
            this.flowLayoutPanel1.Controls.Add(this.btnReleaseLicense);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(52, 200);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 629);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnLocalLicense
            // 
            this.btnLocalLicense.Animated = true;
            this.btnLocalLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnLocalLicense.CheckedState.Parent = this.btnLocalLicense;
            this.btnLocalLicense.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnLocalLicense.CustomImages.Parent = this.btnLocalLicense;
            this.btnLocalLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnLocalLicense.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnLocalLicense.ForeColor = System.Drawing.Color.Black;
            this.btnLocalLicense.HoverState.Parent = this.btnLocalLicense;
            this.btnLocalLicense.Image = global::DVLD.Properties.Resources.License;
            this.btnLocalLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLocalLicense.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnLocalLicense.ImageSize = new System.Drawing.Size(200, 200);
            this.btnLocalLicense.Location = new System.Drawing.Point(3, 3);
            this.btnLocalLicense.Name = "btnLocalLicense";
            this.btnLocalLicense.ShadowDecoration.Parent = this.btnLocalLicense;
            this.btnLocalLicense.Size = new System.Drawing.Size(300, 300);
            this.btnLocalLicense.TabIndex = 3;
            this.btnLocalLicense.Text = "Local License";
            this.btnLocalLicense.TextOffset = new System.Drawing.Point(0, 100);
            this.btnLocalLicense.Click += new System.EventHandler(this.btnLocalLicense_Click);
            this.btnLocalLicense.MouseEnter += new System.EventHandler(this.btnLocalLicense_MouseEnter);
            this.btnLocalLicense.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnListUsers
            // 
            this.btnListUsers.Animated = true;
            this.btnListUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnListUsers.CheckedState.Parent = this.btnListUsers;
            this.btnListUsers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnListUsers.CustomImages.Parent = this.btnListUsers;
            this.btnListUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnListUsers.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold);
            this.btnListUsers.ForeColor = System.Drawing.Color.Black;
            this.btnListUsers.HoverState.Parent = this.btnListUsers;
            this.btnListUsers.Image = global::DVLD.Properties.Resources.Document;
            this.btnListUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnListUsers.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnListUsers.ImageSize = new System.Drawing.Size(200, 200);
            this.btnListUsers.Location = new System.Drawing.Point(309, 3);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.ShadowDecoration.Parent = this.btnListUsers;
            this.btnListUsers.Size = new System.Drawing.Size(300, 300);
            this.btnListUsers.TabIndex = 1;
            this.btnListUsers.Text = "Application Types";
            this.btnListUsers.TextOffset = new System.Drawing.Point(0, 100);
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            this.btnListUsers.MouseEnter += new System.EventHandler(this.btnListUsers_MouseEnter);
            this.btnListUsers.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnTestTypes
            // 
            this.btnTestTypes.Animated = true;
            this.btnTestTypes.BackColor = System.Drawing.Color.Transparent;
            this.btnTestTypes.CheckedState.Parent = this.btnTestTypes;
            this.btnTestTypes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnTestTypes.CustomImages.Parent = this.btnTestTypes;
            this.btnTestTypes.FillColor = System.Drawing.Color.Transparent;
            this.btnTestTypes.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnTestTypes.ForeColor = System.Drawing.Color.Black;
            this.btnTestTypes.HoverState.Parent = this.btnTestTypes;
            this.btnTestTypes.Image = global::DVLD.Properties.Resources.Test;
            this.btnTestTypes.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTestTypes.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnTestTypes.ImageSize = new System.Drawing.Size(200, 200);
            this.btnTestTypes.Location = new System.Drawing.Point(615, 3);
            this.btnTestTypes.Name = "btnTestTypes";
            this.btnTestTypes.ShadowDecoration.Parent = this.btnTestTypes;
            this.btnTestTypes.Size = new System.Drawing.Size(300, 300);
            this.btnTestTypes.TabIndex = 2;
            this.btnTestTypes.Text = "Test Types";
            this.btnTestTypes.TextOffset = new System.Drawing.Point(0, 100);
            this.btnTestTypes.Click += new System.EventHandler(this.btnTestTypes_Click);
            this.btnTestTypes.MouseEnter += new System.EventHandler(this.btnTestTypes_MouseEnter);
            this.btnTestTypes.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnRenewLicense
            // 
            this.btnRenewLicense.Animated = true;
            this.btnRenewLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnRenewLicense.CheckedState.Parent = this.btnRenewLicense;
            this.btnRenewLicense.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRenewLicense.CustomImages.Parent = this.btnRenewLicense;
            this.btnRenewLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnRenewLicense.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnRenewLicense.ForeColor = System.Drawing.Color.Black;
            this.btnRenewLicense.HoverState.Parent = this.btnRenewLicense;
            this.btnRenewLicense.Image = global::DVLD.Properties.Resources.renew;
            this.btnRenewLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRenewLicense.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnRenewLicense.ImageSize = new System.Drawing.Size(200, 200);
            this.btnRenewLicense.Location = new System.Drawing.Point(3, 309);
            this.btnRenewLicense.Name = "btnRenewLicense";
            this.btnRenewLicense.ShadowDecoration.Parent = this.btnRenewLicense;
            this.btnRenewLicense.Size = new System.Drawing.Size(300, 300);
            this.btnRenewLicense.TabIndex = 4;
            this.btnRenewLicense.Text = "Renew License";
            this.btnRenewLicense.TextOffset = new System.Drawing.Point(0, 100);
            this.btnRenewLicense.Click += new System.EventHandler(this.btnRenewLicense_Click);
            this.btnRenewLicense.MouseEnter += new System.EventHandler(this.btnRenewLicense_MouseEnter);
            this.btnRenewLicense.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnReplaceLicense
            // 
            this.btnReplaceLicense.Animated = true;
            this.btnReplaceLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnReplaceLicense.CheckedState.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnReplaceLicense.CustomImages.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnReplaceLicense.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnReplaceLicense.ForeColor = System.Drawing.Color.Black;
            this.btnReplaceLicense.HoverState.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.Image = global::DVLD.Properties.Resources.renew;
            this.btnReplaceLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReplaceLicense.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnReplaceLicense.ImageSize = new System.Drawing.Size(200, 200);
            this.btnReplaceLicense.Location = new System.Drawing.Point(309, 309);
            this.btnReplaceLicense.Name = "btnReplaceLicense";
            this.btnReplaceLicense.ShadowDecoration.Parent = this.btnReplaceLicense;
            this.btnReplaceLicense.Size = new System.Drawing.Size(300, 300);
            this.btnReplaceLicense.TabIndex = 5;
            this.btnReplaceLicense.Text = "Replace License";
            this.btnReplaceLicense.TextOffset = new System.Drawing.Point(0, 100);
            this.btnReplaceLicense.Click += new System.EventHandler(this.btnReplaceLicense_Click);
            this.btnReplaceLicense.MouseEnter += new System.EventHandler(this.btnReplaceLicense_MouseEnter);
            this.btnReplaceLicense.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 10;
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Animated = true;
            this.btnReleaseLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.CheckedState.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnReleaseLicense.CustomImages.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnReleaseLicense.ForeColor = System.Drawing.Color.Black;
            this.btnReleaseLicense.HoverState.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.Image = global::DVLD.Properties.Resources.Unlock;
            this.btnReleaseLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReleaseLicense.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnReleaseLicense.ImageSize = new System.Drawing.Size(200, 200);
            this.btnReleaseLicense.Location = new System.Drawing.Point(615, 309);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.ShadowDecoration.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.Size = new System.Drawing.Size(300, 300);
            this.btnReleaseLicense.TabIndex = 6;
            this.btnReleaseLicense.Text = "Release License";
            this.btnReleaseLicense.TextOffset = new System.Drawing.Point(0, 100);
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            this.btnReleaseLicense.MouseEnter += new System.EventHandler(this.btnReleaseLicense_MouseEnter);
            this.btnReleaseLicense.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // ManageApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDescriptionTitle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageApplications";
            this.Text = "ManageApplications";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnListUsers;
        private ucTitleScreen ucTitleScreen1;
        private Guna.UI2.WinForms.Guna2Button btnTestTypes;
        private Guna.UI2.WinForms.Guna2Button btnLocalLicense;
        private Guna.UI2.WinForms.Guna2Button btnRenewLicense;
        private Guna.UI2.WinForms.Guna2Button btnReplaceLicense;
        private Guna.UI2.WinForms.Guna2Button btnReleaseLicense;
    }
}