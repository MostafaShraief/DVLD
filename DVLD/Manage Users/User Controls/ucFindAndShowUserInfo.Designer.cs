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
            this.ucUserInfo1 = new Manage_Users.User_Controls.ucUserInfo();
            this.ucFindUser1 = new Manage_Users.User_Controls.ucFindUser();
            this.SuspendLayout();
            // 
            // ucUserInfo1
            // 
            this.ucUserInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucUserInfo1.Location = new System.Drawing.Point(0, 195);
            this.ucUserInfo1.Name = "ucUserInfo1";
            this.ucUserInfo1.Size = new System.Drawing.Size(1500, 725);
            this.ucUserInfo1.TabIndex = 0;
            // 
            // ucFindUser1
            // 
            this.ucFindUser1.Location = new System.Drawing.Point(1016, 0);
            this.ucFindUser1.Name = "ucFindUser1";
            this.ucFindUser1.Size = new System.Drawing.Size(484, 198);
            this.ucFindUser1.TabIndex = 1;
            // 
            // ucFindAndShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.ucFindUser1);
            this.Controls.Add(this.ucUserInfo1);
            this.Name = "ucFindAndShowUserInfo";
            this.Size = new System.Drawing.Size(1500, 920);
            this.ResumeLayout(false);

        }

        #endregion

        private Manage_Users.User_Controls.ucUserInfo ucUserInfo1;
        private Manage_Users.User_Controls.ucFindUser ucFindUser1;
    }
}
