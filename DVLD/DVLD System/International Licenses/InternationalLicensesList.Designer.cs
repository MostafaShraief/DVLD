namespace DVLD.DVLD_System.International_Licenses
{
    partial class InternationalLicensesList
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
            this.btnAddInternationalLicense = new Guna.UI2.WinForms.Guna2Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ucTitleScreen1.TabIndex = 2;
            // 
            // cmsRow
            // 
            this.cmsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmsRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cmsRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.cmsRow.Name = "cmsRow";
            this.cmsRow.Size = new System.Drawing.Size(277, 136);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showToolStripMenuItem.Image = global::DVLD.Properties.Resources.Person_ID;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.showToolStripMenuItem.Text = "Show person details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.License;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.editToolStripMenuItem.Text = "Show license details";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.History;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.deleteToolStripMenuItem.Text = "Show person licenses history";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnAddInternationalLicense
            // 
            this.btnAddInternationalLicense.Animated = true;
            this.btnAddInternationalLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnAddInternationalLicense.BorderThickness = 2;
            this.btnAddInternationalLicense.CheckedState.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.CustomImages.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnAddInternationalLicense.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddInternationalLicense.ForeColor = System.Drawing.Color.Black;
            this.btnAddInternationalLicense.HoverState.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.Image = global::DVLD.Properties.Resources.World;
            this.btnAddInternationalLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddInternationalLicense.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAddInternationalLicense.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddInternationalLicense.Location = new System.Drawing.Point(1605, 242);
            this.btnAddInternationalLicense.Name = "btnAddInternationalLicense";
            this.btnAddInternationalLicense.ShadowDecoration.Parent = this.btnAddInternationalLicense;
            this.btnAddInternationalLicense.Size = new System.Drawing.Size(158, 38);
            this.btnAddInternationalLicense.TabIndex = 61;
            this.btnAddInternationalLicense.Text = "Add I.License";
            this.btnAddInternationalLicense.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddInternationalLicense.Click += new System.EventHandler(this.btnAddInternationalLicense_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.World;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(276, 26);
            this.toolStripMenuItem1.Text = "Show international license info";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // InternationalLicensesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.btnAddInternationalLicense);
            this.Controls.Add(this.ucTitleScreen1);
            this.Controls.Add(this.ucList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InternationalLicensesList";
            this.Text = "InternationalLicensesList";
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
        private Guna.UI2.WinForms.Guna2Button btnAddInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}