namespace DVLD.DVLD_System.Licenses
{
    partial class ReplaceLicense
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
            this.ucReplacementLicense1 = new DVLD_System.Licenses.User_Control.ucReplacementLicense();
            this.SuspendLayout();
            // 
            // ucReplacementLicense1
            // 
            this.ucReplacementLicense1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucReplacementLicense1.Location = new System.Drawing.Point(366, 40);
            this.ucReplacementLicense1.Name = "ucReplacementLicense1";
            this.ucReplacementLicense1.Size = new System.Drawing.Size(1042, 948);
            this.ucReplacementLicense1.TabIndex = 12;
            // 
            // ReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucReplacementLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReplaceLicense";
            this.Text = "ReplaceLicense";
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_System.Licenses.User_Control.ucReplacementLicense ucReplacementLicense1;
    }
}