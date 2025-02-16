namespace DVLD.Manage_Users
{
    partial class ShowUserInfo
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
            this.ucUserInfo1 = new Manage_Users.User_Controls.ucUserInfo();
            this.SuspendLayout();
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
            // ucUserInfo1
            // 
            this.ucUserInfo1.Location = new System.Drawing.Point(137, 231);
            this.ucUserInfo1.Name = "ucUserInfo1";
            this.ucUserInfo1.Size = new System.Drawing.Size(1500, 725);
            this.ucUserInfo1.TabIndex = 2;
            // 
            // ShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucUserInfo1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowUserInfo";
            this.Text = "ShowUserInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private Manage_Users.User_Controls.ucUserInfo ucUserInfo1;
    }
}