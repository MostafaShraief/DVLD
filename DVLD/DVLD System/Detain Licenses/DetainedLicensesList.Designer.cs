namespace DVLD.DVLD_System.Applications.Detain_Licenses
{
    partial class DetainedLicensesList
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
            this.ucList1 = new ucList();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.cmsRow = new ReaLTaiizor.Controls.CrownContextMenuStrip();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnReleaseLicense = new Guna.UI2.WinForms.Guna2Button();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRow.SuspendLayout();
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
            // cmsRow
            // 
            this.cmsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmsRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cmsRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.cmsRow.Name = "cmsRow";
            this.cmsRow.Size = new System.Drawing.Size(272, 169);
            this.cmsRow.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRow_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showToolStripMenuItem.Image = global::DVLD.Properties.Resources.Person_ID;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.showToolStripMenuItem.Text = "Show person details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.License;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.editToolStripMenuItem.Text = "Show license details";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.History;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.deleteToolStripMenuItem.Text = "Show person licenses history";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.Unlock;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(271, 26);
            this.toolStripMenuItem1.Text = "Release license";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Animated = true;
            this.btnDetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.BorderThickness = 2;
            this.btnDetainLicense.CheckedState.Parent = this.btnDetainLicense;
            this.btnDetainLicense.CustomImages.Parent = this.btnDetainLicense;
            this.btnDetainLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.Black;
            this.btnDetainLicense.HoverState.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Image = global::DVLD.Properties.Resources.Lock;
            this.btnDetainLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDetainLicense.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnDetainLicense.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDetainLicense.Location = new System.Drawing.Point(1605, 242);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.ShadowDecoration.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Size = new System.Drawing.Size(158, 38);
            this.btnDetainLicense.TabIndex = 62;
            this.btnDetainLicense.Text = "Detain License";
            this.btnDetainLicense.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Animated = true;
            this.btnReleaseLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.BorderThickness = 2;
            this.btnReleaseLicense.CheckedState.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.CustomImages.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicense.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnReleaseLicense.ForeColor = System.Drawing.Color.Black;
            this.btnReleaseLicense.HoverState.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.Image = global::DVLD.Properties.Resources.Unlock;
            this.btnReleaseLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReleaseLicense.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnReleaseLicense.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReleaseLicense.Location = new System.Drawing.Point(1434, 242);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.ShadowDecoration.Parent = this.btnReleaseLicense;
            this.btnReleaseLicense.Size = new System.Drawing.Size(165, 38);
            this.btnReleaseLicense.TabIndex = 63;
            this.btnReleaseLicense.Text = "Release License";
            this.btnReleaseLicense.TextOffset = new System.Drawing.Point(10, 0);
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem2.Image = global::DVLD.Properties.Resources.Lock;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(271, 26);
            this.toolStripMenuItem2.Text = "Detain license";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // DetainedLicensesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.ucTitleScreen1);
            this.Controls.Add(this.ucList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetainedLicensesList";
            this.Text = "DetainLicenseList";
            this.cmsRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucList ucList1;
        private ucTitleScreen ucTitleScreen1;
        private ReaLTaiizor.Controls.CrownContextMenuStrip cmsRow;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicense;
        private Guna.UI2.WinForms.Guna2Button btnReleaseLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}