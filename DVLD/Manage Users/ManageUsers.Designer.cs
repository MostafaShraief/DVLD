namespace DVLD.Manage_Users
{
    partial class ManageUsers
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnListUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindUser = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(1042, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(680, 570);
            this.lblDescription.TabIndex = 9;
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
            this.lblDescriptionTitle.TabIndex = 8;
            this.lblDescriptionTitle.Text = "• Description:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnListUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnAddUser);
            this.flowLayoutPanel1.Controls.Add(this.btnFindUser);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(52, 200);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 629);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnListUsers
            // 
            this.btnListUsers.Animated = true;
            this.btnListUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnListUsers.CheckedState.Parent = this.btnListUsers;
            this.btnListUsers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnListUsers.CustomImages.Parent = this.btnListUsers;
            this.btnListUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnListUsers.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnListUsers.ForeColor = System.Drawing.Color.Black;
            this.btnListUsers.HoverState.Parent = this.btnListUsers;
            this.btnListUsers.Image = global::DVLD.Properties.Resources.Users;
            this.btnListUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnListUsers.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnListUsers.ImageSize = new System.Drawing.Size(200, 200);
            this.btnListUsers.Location = new System.Drawing.Point(3, 3);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.ShadowDecoration.Parent = this.btnListUsers;
            this.btnListUsers.Size = new System.Drawing.Size(300, 300);
            this.btnListUsers.TabIndex = 1;
            this.btnListUsers.Text = "List Of Users";
            this.btnListUsers.TextOffset = new System.Drawing.Point(0, 100);
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            this.btnListUsers.MouseEnter += new System.EventHandler(this.btnListUsers_MouseEnter);
            this.btnListUsers.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Animated = true;
            this.btnAddUser.BackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.CheckedState.Parent = this.btnAddUser;
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddUser.CustomImages.Parent = this.btnAddUser;
            this.btnAddUser.FillColor = System.Drawing.Color.Transparent;
            this.btnAddUser.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.Black;
            this.btnAddUser.HoverState.Parent = this.btnAddUser;
            this.btnAddUser.Image = global::DVLD.Properties.Resources.Add_User;
            this.btnAddUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddUser.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnAddUser.ImageSize = new System.Drawing.Size(200, 200);
            this.btnAddUser.Location = new System.Drawing.Point(309, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.Parent = this.btnAddUser;
            this.btnAddUser.Size = new System.Drawing.Size(300, 300);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.TextOffset = new System.Drawing.Point(0, 100);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.btnAddUser.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Animated = true;
            this.btnFindUser.BackColor = System.Drawing.Color.Transparent;
            this.btnFindUser.CheckedState.Parent = this.btnFindUser;
            this.btnFindUser.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnFindUser.CustomImages.Parent = this.btnFindUser;
            this.btnFindUser.FillColor = System.Drawing.Color.Transparent;
            this.btnFindUser.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnFindUser.ForeColor = System.Drawing.Color.Black;
            this.btnFindUser.HoverState.Parent = this.btnFindUser;
            this.btnFindUser.Image = global::DVLD.Properties.Resources.Find_Person;
            this.btnFindUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFindUser.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnFindUser.ImageSize = new System.Drawing.Size(200, 200);
            this.btnFindUser.Location = new System.Drawing.Point(615, 3);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.ShadowDecoration.Parent = this.btnFindUser;
            this.btnFindUser.Size = new System.Drawing.Size(300, 300);
            this.btnFindUser.TabIndex = 3;
            this.btnFindUser.Text = "Find User";
            this.btnFindUser.TextOffset = new System.Drawing.Point(0, 100);
            this.btnFindUser.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDescriptionTitle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageUsers";
            this.Text = "ManageUsers";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnListUsers;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2Button btnFindUser;
    }
}