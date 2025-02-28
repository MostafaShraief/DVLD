namespace DVLD.Manage_Users
{
    partial class UsersList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersList));
            this.flpTools = new System.Windows.Forms.FlowLayoutPanel();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFilterCriterion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvUsersList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsRow = new ReaLTaiizor.Controls.CrownContextMenuStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshAll = new Guna.UI2.WinForms.Guna2Button();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.cmsRow.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpTools
            // 
            this.flpTools.Controls.Add(this.lblManagePeople);
            this.flpTools.Controls.Add(this.cbFilter);
            this.flpTools.Controls.Add(this.cbFilterCriterion);
            this.flpTools.Controls.Add(this.tbFilter);
            this.flpTools.Location = new System.Drawing.Point(0, 238);
            this.flpTools.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpTools.Name = "flpTools";
            this.flpTools.Size = new System.Drawing.Size(933, 43);
            this.flpTools.TabIndex = 12;
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.BackColor = System.Drawing.Color.Transparent;
            this.lblManagePeople.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblManagePeople.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblManagePeople.Location = new System.Drawing.Point(3, 0);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(158, 40);
            this.lblManagePeople.TabIndex = 4;
            this.lblManagePeople.Text = "Filter By:";
            this.lblManagePeople.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilter.FocusedState.Parent = this.cbFilter;
            this.cbFilter.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Bold);
            this.cbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.HoverState.Parent = this.cbFilter;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "None"});
            this.cbFilter.ItemsAppearance.Parent = this.cbFilter;
            this.cbFilter.Location = new System.Drawing.Point(167, 2);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.ShadowDecoration.Parent = this.cbFilter;
            this.cbFilter.Size = new System.Drawing.Size(247, 36);
            this.cbFilter.TabIndex = 5;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            this.cbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFilter_KeyPress);
            // 
            // cbFilterCriterion
            // 
            this.cbFilterCriterion.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterCriterion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterCriterion.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilterCriterion.FocusedState.Parent = this.cbFilterCriterion;
            this.cbFilterCriterion.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Bold);
            this.cbFilterCriterion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilterCriterion.FormattingEnabled = true;
            this.cbFilterCriterion.HoverState.Parent = this.cbFilterCriterion;
            this.cbFilterCriterion.ItemHeight = 30;
            this.cbFilterCriterion.ItemsAppearance.Parent = this.cbFilterCriterion;
            this.cbFilterCriterion.Location = new System.Drawing.Point(420, 2);
            this.cbFilterCriterion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilterCriterion.Name = "cbFilterCriterion";
            this.cbFilterCriterion.ShadowDecoration.Parent = this.cbFilterCriterion;
            this.cbFilterCriterion.Size = new System.Drawing.Size(247, 36);
            this.cbFilterCriterion.TabIndex = 7;
            this.cbFilterCriterion.Visible = false;
            this.cbFilterCriterion.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // tbFilter
            // 
            this.tbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFilter.DefaultText = "";
            this.tbFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFilter.DisabledState.Parent = this.tbFilter;
            this.tbFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tbFilter.FocusedState.Parent = this.tbFilter;
            this.tbFilter.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Bold);
            this.tbFilter.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.tbFilter.HoverState.Parent = this.tbFilter;
            this.tbFilter.Location = new System.Drawing.Point(677, 6);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.PasswordChar = '\0';
            this.tbFilter.PlaceholderText = "";
            this.tbFilter.SelectedText = "";
            this.tbFilter.ShadowDecoration.Parent = this.tbFilter;
            this.tbFilter.Size = new System.Drawing.Size(247, 32);
            this.tbFilter.TabIndex = 6;
            this.tbFilter.Visible = false;
            this.tbFilter.TextChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvUsersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsersList.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dgvUsersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsersList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsersList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvUsersList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsersList.ColumnHeadersHeight = 30;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsersList.ContextMenuStrip = this.cmsRow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsersList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvUsersList.EnableHeadersVisualStyles = false;
            this.dgvUsersList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsersList.Location = new System.Drawing.Point(0, 285);
            this.dgvUsersList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUsersList.MultiSelect = false;
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.RowHeadersVisible = false;
            this.dgvUsersList.RowHeadersWidth = 51;
            this.dgvUsersList.RowTemplate.Height = 24;
            this.dgvUsersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersList.Size = new System.Drawing.Size(1775, 694);
            this.dgvUsersList.TabIndex = 11;
            this.dgvUsersList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvUsersList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsersList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUsersList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUsersList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUsersList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUsersList.ThemeStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.dgvUsersList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsersList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvUsersList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsersList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvUsersList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsersList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsersList.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvUsersList.ThemeStyle.ReadOnly = true;
            this.dgvUsersList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsersList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsersList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvUsersList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUsersList.ThemeStyle.RowsStyle.Height = 24;
            this.dgvUsersList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsersList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cmsRow
            // 
            this.cmsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmsRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cmsRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
            this.cmsRow.Name = "cmsRow";
            this.cmsRow.Size = new System.Drawing.Size(215, 150);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 979);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1775, 49);
            this.guna2Panel1.TabIndex = 10;
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblNumberOfRecords.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.Location = new System.Drawing.Point(177, 2);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(37, 40);
            this.lblNumberOfRecords.TabIndex = 6;
            this.lblNumberOfRecords.Text = "0";
            this.lblNumberOfRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "Record/s:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.LavenderBlush;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 9;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.Password;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.toolStripMenuItem1.Text = "Change Password";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Animated = true;
            this.btnAddUser.BackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.BorderThickness = 2;
            this.btnAddUser.CheckedState.Parent = this.btnAddUser;
            this.btnAddUser.CustomImages.Parent = this.btnAddUser;
            this.btnAddUser.FillColor = System.Drawing.Color.Transparent;
            this.btnAddUser.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.Black;
            this.btnAddUser.HoverState.Parent = this.btnAddUser;
            this.btnAddUser.Image = global::DVLD.Properties.Resources.Add_User;
            this.btnAddUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddUser.ImageOffset = new System.Drawing.Point(-6, 0);
            this.btnAddUser.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddUser.Location = new System.Drawing.Point(1485, 240);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.ShadowDecoration.Parent = this.btnAddUser;
            this.btnAddUser.Size = new System.Drawing.Size(139, 38);
            this.btnAddUser.TabIndex = 61;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.Animated = true;
            this.btnRefreshAll.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshAll.BorderThickness = 2;
            this.btnRefreshAll.CheckedState.Parent = this.btnRefreshAll;
            this.btnRefreshAll.CustomImages.Parent = this.btnRefreshAll;
            this.btnRefreshAll.FillColor = System.Drawing.Color.Transparent;
            this.btnRefreshAll.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshAll.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshAll.HoverState.Parent = this.btnRefreshAll;
            this.btnRefreshAll.Image = global::DVLD.Properties.Resources.Refresh;
            this.btnRefreshAll.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefreshAll.ImageOffset = new System.Drawing.Point(-8, 0);
            this.btnRefreshAll.ImageSize = new System.Drawing.Size(28, 28);
            this.btnRefreshAll.Location = new System.Drawing.Point(1630, 240);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.ShadowDecoration.Parent = this.btnRefreshAll;
            this.btnRefreshAll.Size = new System.Drawing.Size(133, 38);
            this.btnRefreshAll.TabIndex = 60;
            this.btnRefreshAll.Text = "Refresh All";
            this.btnRefreshAll.TextOffset = new System.Drawing.Point(10, 0);
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUserInfoToolStripMenuItem,
            this.showPersonInfoToolStripMenuItem});
            this.showToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showToolStripMenuItem.Image")));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // showUserInfoToolStripMenuItem
            // 
            this.showUserInfoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showUserInfoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showUserInfoToolStripMenuItem.Name = "showUserInfoToolStripMenuItem";
            this.showUserInfoToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.showUserInfoToolStripMenuItem.Text = "User Info";
            this.showUserInfoToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showPersonInfoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.showPersonInfoToolStripMenuItem.Text = "Person Info";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.personToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.userToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // personToolStripMenuItem
            // 
            this.personToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.personToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.personToolStripMenuItem.Name = "personToolStripMenuItem";
            this.personToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.personToolStripMenuItem.Text = "Person";
            this.personToolStripMenuItem.Click += new System.EventHandler(this.personToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // UsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.flpTools);
            this.Controls.Add(this.dgvUsersList);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.ucTitleScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersList";
            this.Text = "UsersList";
            this.Load += new System.EventHandler(this.UsersList_Load);
            this.flpTools.ResumeLayout(false);
            this.flpTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.cmsRow.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleScreen ucTitleScreen1;
        private System.Windows.Forms.FlowLayoutPanel flpTools;
        private System.Windows.Forms.Label lblManagePeople;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterCriterion;
        private Guna.UI2.WinForms.Guna2TextBox tbFilter;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsersList;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.CrownContextMenuStrip cmsRow;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Guna.UI2.WinForms.Guna2Button btnRefreshAll;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}