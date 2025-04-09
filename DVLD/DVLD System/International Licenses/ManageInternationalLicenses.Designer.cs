namespace DVLD.DVLD_System.International_Licenses
{
    partial class ManageInternationalLicenses
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
            this.ucTitleScreen1 = new ucTitleScreen();
            this.btnInternationalLicensesList = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(1042, 359);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(680, 570);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "Hover on any option to show details.";
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(1042, 300);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(233, 40);
            this.lblDescriptionTitle.TabIndex = 16;
            this.lblDescriptionTitle.Text = "• Description:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnInternationalLicensesList);
            this.flowLayoutPanel1.Controls.Add(this.btnLocalLicense);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(52, 300);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 629);
            this.flowLayoutPanel1.TabIndex = 15;
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
            this.btnLocalLicense.Image = global::DVLD.Properties.Resources.Plus;
            this.btnLocalLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLocalLicense.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnLocalLicense.ImageSize = new System.Drawing.Size(200, 200);
            this.btnLocalLicense.Location = new System.Drawing.Point(309, 3);
            this.btnLocalLicense.Name = "btnLocalLicense";
            this.btnLocalLicense.ShadowDecoration.Parent = this.btnLocalLicense;
            this.btnLocalLicense.Size = new System.Drawing.Size(300, 300);
            this.btnLocalLicense.TabIndex = 3;
            this.btnLocalLicense.Text = "Add I.License";
            this.btnLocalLicense.TextOffset = new System.Drawing.Point(0, 100);
            this.btnLocalLicense.Click += new System.EventHandler(this.btnLocalLicense_Click);
            this.btnLocalLicense.MouseEnter += new System.EventHandler(this.btnLocalLicense_MouseEnter);
            this.btnLocalLicense.MouseLeave += new System.EventHandler(this.btnLocalLicense_MouseLeave);
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 14;
            // 
            // btnInternationalLicensesList
            // 
            this.btnInternationalLicensesList.Animated = true;
            this.btnInternationalLicensesList.BackColor = System.Drawing.Color.Transparent;
            this.btnInternationalLicensesList.CheckedState.Parent = this.btnInternationalLicensesList;
            this.btnInternationalLicensesList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnInternationalLicensesList.CustomImages.Parent = this.btnInternationalLicensesList;
            this.btnInternationalLicensesList.FillColor = System.Drawing.Color.Transparent;
            this.btnInternationalLicensesList.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnInternationalLicensesList.ForeColor = System.Drawing.Color.Black;
            this.btnInternationalLicensesList.HoverState.Parent = this.btnInternationalLicensesList;
            this.btnInternationalLicensesList.Image = global::DVLD.Properties.Resources.License;
            this.btnInternationalLicensesList.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInternationalLicensesList.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnInternationalLicensesList.ImageSize = new System.Drawing.Size(200, 200);
            this.btnInternationalLicensesList.Location = new System.Drawing.Point(3, 3);
            this.btnInternationalLicensesList.Name = "btnInternationalLicensesList";
            this.btnInternationalLicensesList.ShadowDecoration.Parent = this.btnInternationalLicensesList;
            this.btnInternationalLicensesList.Size = new System.Drawing.Size(300, 300);
            this.btnInternationalLicensesList.TabIndex = 4;
            this.btnInternationalLicensesList.Text = "I.Licenses List";
            this.btnInternationalLicensesList.TextOffset = new System.Drawing.Point(0, 100);
            this.btnInternationalLicensesList.Click += new System.EventHandler(this.btnInternationalLicensesList_Click);
            this.btnInternationalLicensesList.MouseEnter += new System.EventHandler(this.btnInternationalLicensesList_MouseEnter);
            this.btnInternationalLicensesList.MouseLeave += new System.EventHandler(this.btnLocalLicense_MouseLeave);
            // 
            // ManageInternationalLicenses
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
            this.Name = "ManageInternationalLicenses";
            this.Text = "ManageInternationalLicenses";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnLocalLicense;
        private ucTitleScreen ucTitleScreen1;
        private Guna.UI2.WinForms.Guna2Button btnInternationalLicensesList;
    }
}