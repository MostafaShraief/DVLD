namespace DVLD.Manage_Users
{
    partial class FindUser
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
            this.ucFindAndShowUserInfo1 = new Manage_Users.User_Controls.ucFindAndShowUserInfo();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.SuspendLayout();
            // 
            // ucFindAndShowUserInfo1
            // 
            this.ucFindAndShowUserInfo1.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucFindAndShowUserInfo1.Location = new System.Drawing.Point(137, 105);
            this.ucFindAndShowUserInfo1.Name = "ucFindAndShowUserInfo1";
            this.ucFindAndShowUserInfo1.Size = new System.Drawing.Size(1500, 920);
            this.ucFindAndShowUserInfo1.TabIndex = 2;
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 1;
            // 
            // FindUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucFindAndShowUserInfo1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindUser";
            this.Text = "FindUser";
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private Manage_Users.User_Controls.ucFindAndShowUserInfo ucFindAndShowUserInfo1;
    }
}