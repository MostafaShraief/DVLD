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
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.btnGithub = new Guna.UI2.WinForms.Guna2Button();
            this.btnLinkedin = new Guna.UI2.WinForms.Guna2Button();
            this.btnTelegram = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.poisonLabel1);
            this.main_panel.Controls.Add(this.btnGithub);
            this.main_panel.Controls.Add(this.btnLinkedin);
            this.main_panel.Controls.Add(this.btnTelegram);
            this.main_panel.Controls.Add(this.label7);
            this.main_panel.Controls.Add(this.label6);
            this.main_panel.Controls.Add(this.label5);
            this.main_panel.Controls.Add(this.label4);
            this.main_panel.Controls.Add(this.label3);
            this.main_panel.Controls.Add(this.label2);
            this.main_panel.Controls.Add(this.label1);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.FillColor = System.Drawing.Color.LavenderBlush;
            this.main_panel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.main_panel.FillColor3 = System.Drawing.Color.LavenderBlush;
            this.main_panel.FillColor4 = System.Drawing.Color.LavenderBlush;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Quality = 30;
            this.main_panel.ShadowDecoration.Parent = this.main_panel;
            this.main_panel.Size = new System.Drawing.Size(1775, 1028);
            this.main_panel.TabIndex = 3;
            this.main_panel.Tag = "0";
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
            this.label7.Size = new System.Drawing.Size(285, 40);
            this.label7.TabIndex = 6;
            this.label7.Text = "○ Mostafa Shaief";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1222, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 40);
            this.label5.TabIndex = 4;
            this.label5.Text = "• Manage Licenses";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(746, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "• Manage Users";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(248, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "• Manage People";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(245, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1285, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To Driving And Vehicle License Department";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnTelegram;
        private Guna.UI2.WinForms.Guna2Button btnGithub;
        private Guna.UI2.WinForms.Guna2Button btnLinkedin;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
    }
}