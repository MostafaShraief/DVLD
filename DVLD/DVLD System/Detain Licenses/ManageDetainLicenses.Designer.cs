namespace DVLD.DVLD_System.Detain_Licenses
{
    partial class ManageDetainLicenses
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
            this.btnDetainLicensesList = new Guna.UI2.WinForms.Guna2Button();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(1042, 409);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(680, 570);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Hover on any option to show details.";
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(1042, 350);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(233, 40);
            this.lblDescriptionTitle.TabIndex = 20;
            this.lblDescriptionTitle.Text = "• Description:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDetainLicensesList);
            this.flowLayoutPanel1.Controls.Add(this.btnDetainLicense);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(52, 350);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 629);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // btnDetainLicensesList
            // 
            this.btnDetainLicensesList.Animated = true;
            this.btnDetainLicensesList.BackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicensesList.CheckedState.Parent = this.btnDetainLicensesList;
            this.btnDetainLicensesList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDetainLicensesList.CustomImages.Parent = this.btnDetainLicensesList;
            this.btnDetainLicensesList.FillColor = System.Drawing.Color.Transparent;
            this.btnDetainLicensesList.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnDetainLicensesList.ForeColor = System.Drawing.Color.Black;
            this.btnDetainLicensesList.HoverState.Parent = this.btnDetainLicensesList;
            this.btnDetainLicensesList.Image = global::DVLD.Properties.Resources.License;
            this.btnDetainLicensesList.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDetainLicensesList.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnDetainLicensesList.ImageSize = new System.Drawing.Size(200, 200);
            this.btnDetainLicensesList.Location = new System.Drawing.Point(3, 3);
            this.btnDetainLicensesList.Name = "btnDetainLicensesList";
            this.btnDetainLicensesList.ShadowDecoration.Parent = this.btnDetainLicensesList;
            this.btnDetainLicensesList.Size = new System.Drawing.Size(300, 300);
            this.btnDetainLicensesList.TabIndex = 4;
            this.btnDetainLicensesList.Text = "D.Licenses List";
            this.btnDetainLicensesList.TextOffset = new System.Drawing.Point(0, 100);
            this.btnDetainLicensesList.Click += new System.EventHandler(this.btnDetainLicensesList_Click);
            this.btnDetainLicensesList.MouseEnter += new System.EventHandler(this.btnDetainLicensesList_MouseEnter);
            this.btnDetainLicensesList.MouseLeave += new System.EventHandler(this.btnLocalLicense_MouseLeave);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Animated = true;
            this.btnDetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.CheckedState.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDetainLicense.CustomImages.Parent = this.btnDetainLicense;
            this.btnDetainLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.Black;
            this.btnDetainLicense.HoverState.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Image = global::DVLD.Properties.Resources.Lock;
            this.btnDetainLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDetainLicense.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnDetainLicense.ImageSize = new System.Drawing.Size(200, 200);
            this.btnDetainLicense.Location = new System.Drawing.Point(309, 3);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.ShadowDecoration.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Size = new System.Drawing.Size(300, 300);
            this.btnDetainLicense.TabIndex = 3;
            this.btnDetainLicense.Text = "Detain License";
            this.btnDetainLicense.TextOffset = new System.Drawing.Point(0, 100);
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            this.btnDetainLicense.MouseEnter += new System.EventHandler(this.btnDetainLicense_MouseEnter);
            this.btnDetainLicense.MouseLeave += new System.EventHandler(this.btnLocalLicense_MouseLeave);
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 18;
            // 
            // ManageDetainLicenses
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
            this.Name = "ManageDetainLicenses";
            this.Text = "ManageDetainLicenses";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicensesList;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicense;
        private ucTitleScreen ucTitleScreen1;
    }
}