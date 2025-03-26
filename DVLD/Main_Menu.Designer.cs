using DVLD;

namespace DVLD
{
    partial class Main_Menu
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
            this.main_panel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.btnGithub = new Guna.UI2.WinForms.Guna2Button();
            this.btnLinkedin = new Guna.UI2.WinForms.Guna2Button();
            this.btnTelegram = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblManageLicenses = new System.Windows.Forms.Label();
            this.lblManageUsers = new System.Windows.Forms.Label();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.ucTitleScreen1);
            this.main_panel.Controls.Add(this.poisonLabel1);
            this.main_panel.Controls.Add(this.btnGithub);
            this.main_panel.Controls.Add(this.btnLinkedin);
            this.main_panel.Controls.Add(this.btnTelegram);
            this.main_panel.Controls.Add(this.label7);
            this.main_panel.Controls.Add(this.label6);
            this.main_panel.Controls.Add(this.lblManageLicenses);
            this.main_panel.Controls.Add(this.lblManageUsers);
            this.main_panel.Controls.Add(this.lblManagePeople);
            this.main_panel.Controls.Add(this.label2);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.main_panel.FillColor2 = System.Drawing.Color.WhiteSmoke;
            this.main_panel.FillColor3 = System.Drawing.Color.WhiteSmoke;
            this.main_panel.FillColor4 = System.Drawing.Color.WhiteSmoke;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Quality = 1;
            this.main_panel.ShadowDecoration.Parent = this.main_panel;
            this.main_panel.Size = new System.Drawing.Size(1775, 1028);
            this.main_panel.TabIndex = 3;
            this.main_panel.Tag = "0";
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 11;
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.Location = new System.Drawing.Point(-19, -19);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(88, 20);
            this.poisonLabel1.TabIndex = 10;
            this.poisonLabel1.Text = "poisonLabel1";
            // 
            // btnGithub
            // 
            this.btnGithub.Animated = true;
            this.btnGithub.BackColor = System.Drawing.Color.Transparent;
            this.btnGithub.CheckedState.Parent = this.btnGithub;
            this.btnGithub.CustomImages.Parent = this.btnGithub;
            this.btnGithub.FillColor = System.Drawing.Color.Transparent;
            this.btnGithub.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnGithub.ForeColor = System.Drawing.Color.Black;
            this.btnGithub.HoverState.Parent = this.btnGithub;
            this.btnGithub.Image = global::DVLD.Properties.Resources.github;
            this.btnGithub.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGithub.ImageOffset = new System.Drawing.Point(35, -20);
            this.btnGithub.ImageSize = new System.Drawing.Size(50, 50);
            this.btnGithub.Location = new System.Drawing.Point(1317, 904);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.ShadowDecoration.Parent = this.btnGithub;
            this.btnGithub.Size = new System.Drawing.Size(139, 112);
            this.btnGithub.TabIndex = 9;
            this.btnGithub.Tag = "https://github.com/MostafaShraief";
            this.btnGithub.Text = "GitHub";
            this.btnGithub.TextOffset = new System.Drawing.Point(0, 30);
            this.btnGithub.Click += new System.EventHandler(this.btnOpenURL_Click);
            // 
            // btnLinkedin
            // 
            this.btnLinkedin.Animated = true;
            this.btnLinkedin.BackColor = System.Drawing.Color.Transparent;
            this.btnLinkedin.CheckedState.Parent = this.btnLinkedin;
            this.btnLinkedin.CustomImages.Parent = this.btnLinkedin;
            this.btnLinkedin.FillColor = System.Drawing.Color.Transparent;
            this.btnLinkedin.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnLinkedin.ForeColor = System.Drawing.Color.Black;
            this.btnLinkedin.HoverState.Parent = this.btnLinkedin;
            this.btnLinkedin.Image = global::DVLD.Properties.Resources.linkedin;
            this.btnLinkedin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLinkedin.ImageOffset = new System.Drawing.Point(35, -20);
            this.btnLinkedin.ImageSize = new System.Drawing.Size(50, 50);
            this.btnLinkedin.Location = new System.Drawing.Point(815, 904);
            this.btnLinkedin.Name = "btnLinkedin";
            this.btnLinkedin.ShadowDecoration.Parent = this.btnLinkedin;
            this.btnLinkedin.Size = new System.Drawing.Size(139, 112);
            this.btnLinkedin.TabIndex = 8;
            this.btnLinkedin.Tag = "https://www.linkedin.com/in/mostafa-shraief/";
            this.btnLinkedin.Text = "LinkedIn";
            this.btnLinkedin.TextOffset = new System.Drawing.Point(0, 30);
            this.btnLinkedin.Click += new System.EventHandler(this.btnOpenURL_Click);
            // 
            // btnTelegram
            // 
            this.btnTelegram.Animated = true;
            this.btnTelegram.BackColor = System.Drawing.Color.Transparent;
            this.btnTelegram.CheckedState.Parent = this.btnTelegram;
            this.btnTelegram.CustomImages.Parent = this.btnTelegram;
            this.btnTelegram.FillColor = System.Drawing.Color.Transparent;
            this.btnTelegram.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnTelegram.ForeColor = System.Drawing.Color.Black;
            this.btnTelegram.HoverState.Parent = this.btnTelegram;
            this.btnTelegram.Image = global::DVLD.Properties.Resources.telegram;
            this.btnTelegram.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTelegram.ImageOffset = new System.Drawing.Point(35, -20);
            this.btnTelegram.ImageSize = new System.Drawing.Size(50, 50);
            this.btnTelegram.Location = new System.Drawing.Point(313, 904);
            this.btnTelegram.Name = "btnTelegram";
            this.btnTelegram.ShadowDecoration.Parent = this.btnTelegram;
            this.btnTelegram.Size = new System.Drawing.Size(139, 112);
            this.btnTelegram.TabIndex = 7;
            this.btnTelegram.Tag = "https://t.me/Mostafa_Shraief";
            this.btnTelegram.Text = "Telegram";
            this.btnTelegram.TextOffset = new System.Drawing.Point(0, 30);
            this.btnTelegram.Click += new System.EventHandler(this.btnOpenURL_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(736, 847);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 40);
            this.label7.TabIndex = 6;
            this.label7.Text = "○ Mostafa Shraief";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Gadugi", 25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(257, 839);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 50);
            this.label6.TabIndex = 5;
            this.label6.Text = "Developed By:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblManageLicenses
            // 
            this.lblManageLicenses.AutoSize = true;
            this.lblManageLicenses.BackColor = System.Drawing.Color.Transparent;
            this.lblManageLicenses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblManageLicenses.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblManageLicenses.Location = new System.Drawing.Point(1222, 414);
            this.lblManageLicenses.Name = "lblManageLicenses";
            this.lblManageLicenses.Size = new System.Drawing.Size(308, 40);
            this.lblManageLicenses.TabIndex = 4;
            this.lblManageLicenses.Text = "• Manage Licenses";
            this.lblManageLicenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblManageUsers
            // 
            this.lblManageUsers.AutoSize = true;
            this.lblManageUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblManageUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblManageUsers.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblManageUsers.Location = new System.Drawing.Point(746, 414);
            this.lblManageUsers.Name = "lblManageUsers";
            this.lblManageUsers.Size = new System.Drawing.Size(265, 40);
            this.lblManageUsers.TabIndex = 3;
            this.lblManageUsers.Text = "• Manage Users";
            this.lblManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.BackColor = System.Drawing.Color.Transparent;
            this.lblManagePeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblManagePeople.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblManagePeople.Location = new System.Drawing.Point(248, 414);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(287, 40);
            this.lblManagePeople.TabIndex = 2;
            this.lblManagePeople.Text = "• Manage People";
            this.lblManagePeople.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblManagePeople.Click += new System.EventHandler(this.lblManagePeople_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(248, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Available Services:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Menu";
            this.Text = "Main_Menu";
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel main_panel;
        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblManageLicenses;
        private System.Windows.Forms.Label lblManageUsers;
        private Guna.UI2.WinForms.Guna2Button btnTelegram;
        private Guna.UI2.WinForms.Guna2Button btnGithub;
        private Guna.UI2.WinForms.Guna2Button btnLinkedin;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ucTitleScreen ucTitleScreen1;
    }
}