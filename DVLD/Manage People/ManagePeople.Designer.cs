namespace DVLD.Manage_People
{
    partial class ManagePeople
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnListPeople = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindPerson = new Guna.UI2.WinForms.Guna2Button();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnListPeople);
            this.flowLayoutPanel1.Controls.Add(this.btnAddPerson);
            this.flowLayoutPanel1.Controls.Add(this.btnFindPerson);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(52, 168);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 629);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnListPeople
            // 
            this.btnListPeople.Animated = true;
            this.btnListPeople.BackColor = System.Drawing.Color.Transparent;
            this.btnListPeople.CheckedState.Parent = this.btnListPeople;
            this.btnListPeople.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnListPeople.CustomImages.Parent = this.btnListPeople;
            this.btnListPeople.FillColor = System.Drawing.Color.Transparent;
            this.btnListPeople.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnListPeople.ForeColor = System.Drawing.Color.Black;
            this.btnListPeople.HoverState.Parent = this.btnListPeople;
            this.btnListPeople.Image = global::DVLD.Properties.Resources.peoples;
            this.btnListPeople.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnListPeople.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnListPeople.ImageSize = new System.Drawing.Size(200, 200);
            this.btnListPeople.Location = new System.Drawing.Point(3, 3);
            this.btnListPeople.Name = "btnListPeople";
            this.btnListPeople.ShadowDecoration.Parent = this.btnListPeople;
            this.btnListPeople.Size = new System.Drawing.Size(300, 300);
            this.btnListPeople.TabIndex = 1;
            this.btnListPeople.Text = "List Of People";
            this.btnListPeople.TextOffset = new System.Drawing.Point(0, 100);
            this.btnListPeople.Click += new System.EventHandler(this.btnListPeople_Click);
            this.btnListPeople.MouseEnter += new System.EventHandler(this.btnListPeople_MouseHover);
            this.btnListPeople.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Animated = true;
            this.btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.CheckedState.Parent = this.btnAddPerson;
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddPerson.CustomImages.Parent = this.btnAddPerson;
            this.btnAddPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnAddPerson.ForeColor = System.Drawing.Color.Black;
            this.btnAddPerson.HoverState.Parent = this.btnAddPerson;
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.Add_Person;
            this.btnAddPerson.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnAddPerson.ImageSize = new System.Drawing.Size(200, 200);
            this.btnAddPerson.Location = new System.Drawing.Point(309, 3);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.ShadowDecoration.Parent = this.btnAddPerson;
            this.btnAddPerson.Size = new System.Drawing.Size(300, 300);
            this.btnAddPerson.TabIndex = 2;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextOffset = new System.Drawing.Point(0, 100);
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            this.btnAddPerson.MouseEnter += new System.EventHandler(this.btnAddPerson_MouseHover);
            this.btnAddPerson.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Animated = true;
            this.btnFindPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.CheckedState.Parent = this.btnFindPerson;
            this.btnFindPerson.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnFindPerson.CustomImages.Parent = this.btnFindPerson;
            this.btnFindPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.btnFindPerson.ForeColor = System.Drawing.Color.Black;
            this.btnFindPerson.HoverState.Parent = this.btnFindPerson;
            this.btnFindPerson.Image = global::DVLD.Properties.Resources.Find_Person;
            this.btnFindPerson.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFindPerson.ImageOffset = new System.Drawing.Point(40, -20);
            this.btnFindPerson.ImageSize = new System.Drawing.Size(200, 200);
            this.btnFindPerson.Location = new System.Drawing.Point(615, 3);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.ShadowDecoration.Parent = this.btnFindPerson;
            this.btnFindPerson.Size = new System.Drawing.Size(300, 300);
            this.btnFindPerson.TabIndex = 3;
            this.btnFindPerson.Text = "Find Person";
            this.btnFindPerson.TextOffset = new System.Drawing.Point(0, 100);
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            this.btnFindPerson.MouseEnter += new System.EventHandler(this.btnFindPerson_MouseHover);
            this.btnFindPerson.MouseLeave += new System.EventHandler(this.btnOption_MouseLeave);
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(1042, 168);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(233, 40);
            this.lblDescriptionTitle.TabIndex = 3;
            this.lblDescriptionTitle.Text = "• Description:";
            this.lblDescriptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(1042, 227);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(680, 570);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Hover on any option to show details.";
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 5;
            // 
            // ManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.ucTitleScreen1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDescriptionTitle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagePeople";
            this.Tag = "1";
            this.Text = "ManagePeople";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnListPeople;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private Guna.UI2.WinForms.Guna2Button btnFindPerson;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.Label lblDescription;
        private ucTitleScreen ucTitleScreen1;
    }
}