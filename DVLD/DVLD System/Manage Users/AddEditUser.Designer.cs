using DVLD.Manage_Users.User_Controls;

namespace DVLD.Manage_Users
{
    partial class AddEditUser
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
            this.ucAddEditUser1 = new Manage_Users.User_Controls.ucAddEditUser();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.SuspendLayout();
            // 
            // ucAddEditUser1
            // 
            this.ucAddEditUser1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucAddEditUser1.Location = new System.Drawing.Point(137, 204);
            this.ucAddEditUser1.Name = "ucAddEditUser1";
            this.ucAddEditUser1.Size = new System.Drawing.Size(1507, 767);
            this.ucAddEditUser1.TabIndex = 11;
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 10;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucAddEditUser1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private Manage_Users.User_Controls.ucAddEditUser ucAddEditUser1;
    }
}