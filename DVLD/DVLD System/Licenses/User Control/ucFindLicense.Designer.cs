namespace DVLD.DVLD_System.Applications.Local_Driving_License_Application.User_Controls
{
    partial class ucFindLicense
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFindLicense));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.tbFind = new Guna.UI2.WinForms.Guna2TextBox();
            this.rbID = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 3;
            this.guna2Panel1.Controls.Add(this.btnFind);
            this.guna2Panel1.Controls.Add(this.tbFind);
            this.guna2Panel1.Controls.Add(this.rbID);
            this.guna2Panel1.Controls.Add(this.lblDescriptionTitle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(490, 149);
            this.guna2Panel1.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Animated = true;
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.BorderThickness = 2;
            this.btnFind.CheckedState.Parent = this.btnFind;
            this.btnFind.CustomImages.Parent = this.btnFind;
            this.btnFind.FillColor = System.Drawing.Color.Transparent;
            this.btnFind.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.HoverState.Parent = this.btnFind;
            this.btnFind.Image = global::DVLD.Properties.Resources.Search;
            this.btnFind.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFind.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnFind.ImageSize = new System.Drawing.Size(30, 30);
            this.btnFind.Location = new System.Drawing.Point(360, 96);
            this.btnFind.Name = "btnFind";
            this.btnFind.ShadowDecoration.Parent = this.btnFind;
            this.btnFind.Size = new System.Drawing.Size(103, 38);
            this.btnFind.TabIndex = 63;
            this.btnFind.Text = "Find";
            this.btnFind.TextOffset = new System.Drawing.Point(10, 0);
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Animated = true;
            this.tbFind.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFind.DefaultText = "";
            this.tbFind.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFind.DisabledState.Parent = this.tbFind;
            this.tbFind.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFind.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbFind.FocusedState.Parent = this.tbFind;
            this.tbFind.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.tbFind.ForeColor = System.Drawing.Color.Black;
            this.tbFind.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbFind.HoverState.Parent = this.tbFind;
            this.tbFind.Location = new System.Drawing.Point(20, 90);
            this.tbFind.Margin = new System.Windows.Forms.Padding(4);
            this.tbFind.Name = "tbFind";
            this.tbFind.PasswordChar = '\0';
            this.tbFind.PlaceholderText = "";
            this.tbFind.SelectedText = "";
            this.tbFind.ShadowDecoration.Parent = this.tbFind;
            this.tbFind.Size = new System.Drawing.Size(321, 44);
            this.tbFind.TabIndex = 62;
            this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
            // 
            // rbID
            // 
            this.rbID.AutoSize = true;
            this.rbID.Checked = true;
            this.rbID.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbID.CheckedState.BorderThickness = 0;
            this.rbID.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbID.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbID.CheckedState.InnerOffset = -4;
            this.rbID.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Bold);
            this.rbID.Location = new System.Drawing.Point(20, 53);
            this.rbID.Name = "rbID";
            this.rbID.Size = new System.Drawing.Size(153, 34);
            this.rbID.TabIndex = 60;
            this.rbID.TabStop = true;
            this.rbID.Text = "License ID";
            this.rbID.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbID.UncheckedState.BorderThickness = 2;
            this.rbID.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbID.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbID.UseVisualStyleBackColor = true;
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(13, 10);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(269, 40);
            this.lblDescriptionTitle.TabIndex = 59;
            this.lblDescriptionTitle.Text = "Find License By:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ucFindLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ucFindLicense";
            this.Size = new System.Drawing.Size(490, 149);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2TextBox tbFind;
        private Guna.UI2.WinForms.Guna2RadioButton rbID;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
