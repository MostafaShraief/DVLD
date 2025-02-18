namespace DVLD.Manage_Users.User_Controls
{
    partial class ucFindAndShowUserInfo
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
            this.ucFindUser1 = new Manage_Users.User_Controls.ucFindUser();
            this.ucUserInfo1 = new Manage_Users.User_Controls.ucUserInfo();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // ucFindUser1
            // 
            this.ucFindUser1.Location = new System.Drawing.Point(0, 0);
            this.ucFindUser1.Name = "ucFindUser1";
            this.ucFindUser1.Size = new System.Drawing.Size(484, 198);
            this.ucFindUser1.TabIndex = 1;
            // 
            // ucUserInfo1
            // 
            this.ucUserInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucUserInfo1.Location = new System.Drawing.Point(0, 195);
            this.ucUserInfo1.Name = "ucUserInfo1";
            this.ucUserInfo1.Size = new System.Drawing.Size(1500, 725);
            this.ucUserInfo1.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Animated = true;
            this.btnAddUser.BackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.BorderThickness = 2;
            this.btnAddUser.CheckedState.Parent = this.btnAddUser;
            this.btnAddUser.CustomImages.Parent = this.btnAddUser;
            this.btnAddUser.FillColor = System.Drawing.Color.Transparent;
            this.btnAddUser.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.Black;
            this.btnAddUser.HoverState.Parent = this.btnAddUser;
            this.btnAddUser.Image = global::DVLD.Properties.Resources.Add_User;
            this.btnAddUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddUser.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAddUser.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddUser.Location = new System.Drawing.Point(490, 151);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.Parent = this.btnAddUser;
            this.btnAddUser.Size = new System.Drawing.Size(139, 38);
            this.btnAddUser.TabIndex = 60;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // ucFindAndShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.ucFindUser1);
            this.Controls.Add(this.ucUserInfo1);
            this.Name = "ucFindAndShowUserInfo";
            this.Size = new System.Drawing.Size(1500, 920);
            this.ResumeLayout(false);

        }

        #endregion

        private Manage_Users.User_Controls.ucUserInfo ucUserInfo1;
        private Manage_Users.User_Controls.ucFindUser ucFindUser1;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
    }
}
