using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_Users
{
    public partial class UsersList : Form
    {
        DVLD _mainForm;

        public UsersList(DVLD mainForm)
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Users List");
            this._mainForm = mainForm;
        }

        private class clsUsersDataTable
        {
            public DataTable dtUsers;
            private Label lblRecordsCounter { get; set; }

            public clsUsersDataTable(Label lblRecordsCounter) =>
                this.lblRecordsCounter = lblRecordsCounter;

            public void RefreshTable()
            {
                dtUsers.DefaultView.RowFilter = null;
                RefreshRecordsCounter();
            }

            public void LoadData()
            {
                dtUsers = clsUsers_BLL.GetListOfUsers();
                RefreshTable();
            }

            public void LoadColumnsToComboBox(Guna2ComboBox comboBox)
            {
                foreach (DataColumn col in dtUsers.Columns)
                    comboBox.Items.Add(col.ColumnName);
                comboBox.SelectedIndex = 0;
            }

            public void RefreshRecordsCounter() =>
                lblRecordsCounter.Text = dtUsers.DefaultView.Count.ToString();

            public void ChangeFilter(string FilterFormat)
            {
                try
                {
                    dtUsers.DefaultView.RowFilter = FilterFormat;
                    RefreshRecordsCounter();
                }
                catch
                {
                    RefreshTable();
                    MessageBox.Show("error has been occured while filtering table.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        clsUsersDataTable _usersDataTable;

        void _FillFilterCriterion()
        {
            cbFilterCriterion.Items.Add("All");
            cbFilterCriterion.Items.Add("Yes");
            cbFilterCriterion.Items.Add("No");
            cbFilterCriterion.SelectedIndex = 0;
        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            _usersDataTable = new clsUsersDataTable(lblNumberOfRecords);
            filterProcess = new clsFilterProcess(cbFilter, tbFilter, cbFilterCriterion, _usersDataTable);
            _usersDataTable.LoadData();
            _usersDataTable.LoadColumnsToComboBox(cbFilter);
            _FillFilterCriterion();
            filterProcess.FillListWithItems();
            dgvUsersList.DataSource = _usersDataTable.dtUsers;
        }

        private class clsFilterProcess
        {
            Guna2ComboBox _cbFilter { get; set; }
            Guna2TextBox _tbFilter { get; set; }
            Guna2ComboBox _cbFilterCriterion { get; set; }
            clsUsersDataTable _usersDataTable { get; set; }
            List<string> _columnNames = new List<string>();

            public void FillListWithItems()
            {
                foreach (string columnName in _cbFilter.Items)
                    _columnNames.Add(columnName);
            }

            public clsFilterProcess(Guna2ComboBox cbFilter, Guna2TextBox tbFilter,
                Guna2ComboBox cbFilterCriterion, clsUsersDataTable usersDataTable)
            {
                _cbFilter = cbFilter;
                _tbFilter = tbFilter;
                _cbFilterCriterion = cbFilterCriterion;
                _usersDataTable = usersDataTable;
            }

            void TextBoxChange()
            {
                string ColumnName = _cbFilter.Text;
                string FilterValue = _tbFilter.Text;

                if (String.IsNullOrEmpty(FilterValue) || FilterValue.Trim() == string.Empty)
                    _usersDataTable.RefreshTable();
                else if ((ColumnName == "User ID" || ColumnName == "Person ID") &&
                    int.TryParse(FilterValue, out int ID))
                    _usersDataTable.ChangeFilter(String.Format(@"[{0}] = {1}", ColumnName, ID));
                else
                    _usersDataTable.ChangeFilter(String.Format(@"[{0}] like '{1}%'", ColumnName, FilterValue));
            }

            void FilterCriterionChange()
            {
                string ColumnName = _cbFilter.Text;
                string FilterValue = _cbFilterCriterion.Text;

                if (_cbFilterCriterion.Text == "All")
                    _usersDataTable.RefreshTable();
                else
                    _usersDataTable.ChangeFilter(String.Format(@"[{0}] = {1}", ColumnName,
                        (FilterValue == "Yes" ? true : false).ToString()));
            }

            public void FilterChange()
            {
                string ColumnName = _cbFilter.Text;

                if (String.IsNullOrEmpty(ColumnName) || !_columnNames.Contains(ColumnName) ||
                    ColumnName == "None")
                {
                    _tbFilter.Visible = false;
                    _usersDataTable.RefreshTable();
                }
                else
                {
                    if (ColumnName != "Is Active")
                    {
                        _tbFilter.Visible = true;
                        _cbFilterCriterion.Visible = false;
                        TextBoxChange();
                    }
                    else
                    {
                        _cbFilterCriterion.Visible = true;
                        _tbFilter.Visible = false;
                        FilterCriterionChange();
                    }
                }
            }
        }

        clsFilterProcess filterProcess;

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e) =>
            filterProcess.FilterChange();

        private void cbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tbFilter.Visible)
                    tbFilter.Focus();
                else if (cbFilterCriterion.Visible)
                    tbFilter.Focus();
            }    
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserInfo showUserInfo = new ShowUserInfo();
            showUserInfo.GetUserID(GetUserIdFromSelectedRow());
            clsGlobal.MainForm.PushNewForm(showUserInfo);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.MainForm.PushNewForm(new AddEditUser());
        }

        int GetUserIdFromSelectedRow() => ((int)dgvUsersList.SelectedRows[0].Cells[0].Value);

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUtility.clsForms.DeleteUser(GetUserIdFromSelectedRow()))
                _usersDataTable.LoadData();
        }
    }
}
