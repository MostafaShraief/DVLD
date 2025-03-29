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
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // ucFindPerson
            // 
            this.ucFindPerson.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucFindPerson.Location = new System.Drawing.Point(3, 3);
            this.ucFindPerson.Name = "ucFindPerson";
            this.ucFindPerson.Size = new System.Drawing.Size(484, 198);
            this.ucFindPerson.TabIndex = 6;
            // 
            // ucPersonInfo
            // 
            this.ucPersonInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucPersonInfo.Location = new System.Drawing.Point(3, 207);
            this.ucPersonInfo.Name = "ucPersonInfo";
            this.ucPersonInfo.Size = new System.Drawing.Size(1500, 557);
            this.ucPersonInfo.TabIndex = 7;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Animated = true;
            this.btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.BorderThickness = 2;
            this.btnAddPerson.CheckedState.Parent = this.btnAddPerson;
            this.btnAddPerson.CustomImages.Parent = this.btnAddPerson;
            this.btnAddPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddPerson.HoverState.Parent = this.btnAddPerson;
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.Add_Person;
            this.btnAddPerson.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAddPerson.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddPerson.Location = new System.Drawing.Point(493, 163);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.ShadowDecoration.Parent = this.btnAddPerson;
            this.btnAddPerson.Size = new System.Drawing.Size(139, 38);
            this.btnAddPerson.TabIndex = 60;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // ucFindAndShowInfoPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.ucPersonInfo);
            this.Controls.Add(this.ucFindPerson);
            this.Name = "ucFindAndShowInfoPerson";
            this.Size = new System.Drawing.Size(1507, 767);
            this.ResumeLayout(false);

        }

        #endregion
        private ucFindPerson ucFindPerson;
        private UserControl.ucPersonInfo ucPersonInfo;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
    }
}
