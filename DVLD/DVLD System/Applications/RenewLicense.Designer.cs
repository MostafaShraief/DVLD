namespace DVLD.DVLD_System.Licenses
{
    partial class RenewLicense
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
            this.ucRenewLicense1 = new DVLD_System.Licenses.User_Control.ucRenewLicense();
            this.SuspendLayout();
            // 
            // ucRenewLicense1
            // 
            this.ucRenewLicense1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucRenewLicense1.Location = new System.Drawing.Point(366, 40);
            this.ucRenewLicense1.Name = "ucRenewLicense1";
            this.ucRenewLicense1.Size = new System.Drawing.Size(1042, 948);
            this.ucRenewLicense1.TabIndex = 1;
            // 
            // RenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucRenewLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RenewLicense";
            this.Text = "RenewLicense";
            this.ResumeLayout(false);

        }

        #endregion
        private DVLD_System.Licenses.User_Control.ucRenewLicense ucRenewLicense1;
    }
}