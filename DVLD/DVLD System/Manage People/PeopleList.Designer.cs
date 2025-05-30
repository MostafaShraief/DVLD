﻿namespace DVLD.Manage_People
{
    partial class PeopleList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeopleList));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPeopleList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsRow = new ReaLTaiizor.Controls.CrownContextMenuStrip();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.flpTools = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDateOfBirthFilter = new System.Windows.Forms.Label();
            this.cbFilterCriterion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnRefreshAll = new Guna.UI2.WinForms.Guna2Button();
            this.ucTitleScreen1 = new ucTitleScreen();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).BeginInit();
            this.cmsRow.SuspendLayout();
            this.flpTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.guna2Panel1.TabIndex = 2;
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
            // dgvPeopleList
            // 
            this.dgvPeopleList.AllowUserToAddRows = false;
            this.dgvPeopleList.AllowUserToDeleteRows = false;
            this.dgvPeopleList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPeopleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeopleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeopleList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeopleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeopleList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPeopleList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvPeopleList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeopleList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeopleList.ColumnHeadersHeight = 30;
            this.dgvPeopleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeopleList.ContextMenuStrip = this.cmsRow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeopleList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPeopleList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPeopleList.EnableHeadersVisualStyles = false;
            this.dgvPeopleList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPeopleList.Location = new System.Drawing.Point(0, 285);
            this.dgvPeopleList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPeopleList.MultiSelect = false;
            this.dgvPeopleList.Name = "dgvPeopleList";
            this.dgvPeopleList.ReadOnly = true;
            this.dgvPeopleList.RowHeadersVisible = false;
            this.dgvPeopleList.RowHeadersWidth = 51;
            this.dgvPeopleList.RowTemplate.Height = 24;
            this.dgvPeopleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeopleList.Size = new System.Drawing.Size(1775, 694);
            this.dgvPeopleList.TabIndex = 3;
            this.dgvPeopleList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvPeopleList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeopleList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPeopleList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPeopleList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPeopleList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPeopleList.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeopleList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPeopleList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPeopleList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPeopleList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvPeopleList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPeopleList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeopleList.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvPeopleList.ThemeStyle.ReadOnly = true;
            this.dgvPeopleList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeopleList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPeopleList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvPeopleList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPeopleList.ThemeStyle.RowsStyle.Height = 24;
            this.dgvPeopleList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPeopleList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cmsRow
            // 
            this.cmsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmsRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cmsRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsRow.Name = "cmsRow";
            this.cmsRow.Size = new System.Drawing.Size(145, 82);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showToolStripMenuItem.Image = global::DVLD.Properties.Resources.Person_ID;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.showToolStripMenuItem.Text = "Show Info";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.trash_bin;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            // 
            // flpTools
            // 
            this.flpTools.Controls.Add(this.lblManagePeople);
            this.flpTools.Controls.Add(this.cbFilter);
            this.flpTools.Controls.Add(this.lblDateOfBirthFilter);
            this.flpTools.Controls.Add(this.cbFilterCriterion);
            this.flpTools.Controls.Add(this.tbFilter);
            this.flpTools.Controls.Add(this.dtpDateOfBirth);
            this.flpTools.Location = new System.Drawing.Point(0, 238);
            this.flpTools.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpTools.Name = "flpTools";
            this.flpTools.Size = new System.Drawing.Size(1415, 43);
            this.flpTools.TabIndex = 7;
            // 
            // lblDateOfBirthFilter
            // 
            this.lblDateOfBirthFilter.AutoSize = true;
            this.lblDateOfBirthFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblDateOfBirthFilter.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDateOfBirthFilter.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold);
            this.lblDateOfBirthFilter.Location = new System.Drawing.Point(420, 0);
            this.lblDateOfBirthFilter.Name = "lblDateOfBirthFilter";
            this.lblDateOfBirthFilter.Size = new System.Drawing.Size(214, 36);
            this.lblDateOfBirthFilter.TabIndex = 8;
            this.lblDateOfBirthFilter.Text = "Filter Date By:";
            this.lblDateOfBirthFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbFilterCriterion.Location = new System.Drawing.Point(640, 2);
            this.cbFilterCriterion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFilterCriterion.Name = "cbFilterCriterion";
            this.cbFilterCriterion.ShadowDecoration.Parent = this.cbFilterCriterion;
            this.cbFilterCriterion.Size = new System.Drawing.Size(247, 36);
            this.cbFilterCriterion.TabIndex = 7;
            this.cbFilterCriterion.SelectedValueChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.cbFilterCriterion.VisibleChanged += new System.EventHandler(this.cbFilterByValue_VisibleChanged);
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
            this.tbFilter.Location = new System.Drawing.Point(897, 6);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.PasswordChar = '\0';
            this.tbFilter.PlaceholderText = "";
            this.tbFilter.SelectedText = "";
            this.tbFilter.ShadowDecoration.Parent = this.tbFilter;
            this.tbFilter.Size = new System.Drawing.Size(247, 32);
            this.tbFilter.TabIndex = 6;
            this.tbFilter.Visible = false;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.VisibleChanged += new System.EventHandler(this.tbFilter_VisibleChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CheckedState.Parent = this.dtpDateOfBirth;
            this.dtpDateOfBirth.FillColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDateOfBirth.HoverState.Parent = this.dtpDateOfBirth;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(1154, 2);
            this.dtpDateOfBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.ShadowDecoration.Parent = this.dtpDateOfBirth;
            this.dtpDateOfBirth.Size = new System.Drawing.Size(247, 36);
            this.dtpDateOfBirth.TabIndex = 9;
            this.dtpDateOfBirth.Value = new System.DateTime(2025, 1, 27, 23, 33, 22, 811);
            this.dtpDateOfBirth.Visible = false;
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
            this.btnRefreshAll.TabIndex = 59;
            this.btnRefreshAll.Text = "Refresh All";
            this.btnRefreshAll.TextOffset = new System.Drawing.Point(10, 0);
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // ucTitleScreen1
            // 
            this.ucTitleScreen1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTitleScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleScreen1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleScreen1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTitleScreen1.Name = "ucTitleScreen1";
            this.ucTitleScreen1.Size = new System.Drawing.Size(1775, 145);
            this.ucTitleScreen1.TabIndex = 8;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
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
            this.btnAddPerson.Location = new System.Drawing.Point(1485, 240);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.ShadowDecoration.Parent = this.btnAddPerson;
            this.btnAddPerson.Size = new System.Drawing.Size(139, 38);
            this.btnAddPerson.TabIndex = 61;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextOffset = new System.Drawing.Point(10, 0);
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // PeopleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1775, 1028);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.ucTitleScreen1);
            this.Controls.Add(this.flpTools);
            this.Controls.Add(this.dgvPeopleList);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnRefreshAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PeopleList";
            this.Tag = "2";
            this.Text = "PeopleList";
            this.Load += new System.EventHandler(this.PeopleList_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).EndInit();
            this.cmsRow.ResumeLayout(false);
            this.flpTools.ResumeLayout(false);
            this.flpTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPeopleList;
        private System.Windows.Forms.Label lblManagePeople;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private System.Windows.Forms.FlowLayoutPanel flpTools;
        private Guna.UI2.WinForms.Guna2TextBox tbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterCriterion;
        private System.Windows.Forms.Label lblDateOfBirthFilter;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private ucTitleScreen ucTitleScreen1;
        private ReaLTaiizor.Controls.CrownContextMenuStrip cmsRow;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnRefreshAll;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
    }
}