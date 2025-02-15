using DVLD.UserControl;

namespace DVLD.Manage_People.User_Controls
{
    partial class ucFindAndShowInfoPerson
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
            this.ucFindPerson = new Manage_People.User_Controls.ucFindPerson();
            this.ucPersonInfo = new UserControl.ucPersonInfo();
            this.SuspendLayout();
            // 
            // ucFindPerson
            // 
            this.ucFindPerson.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucFindPerson.Location = new System.Drawing.Point(3, 3);
            this.ucFindPerson.Name = "ucFindPerson";
            this.ucFindPerson.Size = new System.Drawing.Size(484, 198);
            this.ucFindPerson.TabIndex = 6;
            // 
            // ucPersonInfo
            // 
            this.ucPersonInfo.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucPersonInfo.Location = new System.Drawing.Point(3, 207);
            this.ucPersonInfo.Name = "ucPersonInfo";
            this.ucPersonInfo.Size = new System.Drawing.Size(1500, 557);
            this.ucPersonInfo.TabIndex = 7;
            // 
            // FindAndShowInfoPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.ucPersonInfo);
            this.Controls.Add(this.ucFindPerson);
            this.Name = "FindAndShowInfoPerson";
            this.Size = new System.Drawing.Size(1507, 767);
            this.ResumeLayout(false);

        }

        #endregion
        private ucFindPerson ucFindPerson;
        private UserControl.ucPersonInfo ucPersonInfo;
    }
}
