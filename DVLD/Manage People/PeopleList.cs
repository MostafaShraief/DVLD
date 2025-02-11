using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_People
{
    public partial class PeopleList : Form
    {
        public PeopleList()
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("People List");
            cbFilter.SelectedItem = clsUtility.DefaultFilter;
        }

        private enum _enFilterMode { None, PersonID, NationalNo, FirstName,
            SecondName, ThirdName, LastName, DateOfBirth,
            Gender, Address, Phone, Email, CountryName, ImagePath}

        private enum _enDateFilterMode { All, Day, Month, Year }

        _enFilterMode _FilterMode = _enFilterMode.None;

        DataTable dtPeople;
        bool IsLoad = true; // this important to ignore filling table twice at the same time when loading the form.

        void _FillDataTable()
        {
            dtPeople = clsPeople_BLL.GetListOfPeople();
        }

        void _FillDataGridViewWithData()
        {
            dgvPeopleList.DataSource = dtPeople;
        }

        void _RenewDataTable()
        {
            if (dgvPeopleList.DataSource 
                is DataTable currentDataSource && 
                currentDataSource != dtPeople)
                currentDataSource.Dispose();

            dtPeople.Dispose();
            _FillDataTable();
            _FillDataGridViewWithData();
        }

        void _DisposeUnusedDataTable()
        {
            if ((DataTable)dgvPeopleList.DataSource != dtPeople) // check if dt is not the main table.
                ((DataTable)dgvPeopleList.DataSource).Dispose();
        }

        void _SwitchToAnotherDataTable(ref DataTable newdt)
        {
            _DisposeUnusedDataTable(); // Dispose old table.
            dgvPeopleList.DataSource = newdt;
        }

        void _FillDataTableWithPeopleColumns(ref DataTable dt)
        {
            foreach (DataColumn col in dtPeople.Columns)
                dt.Columns.Add(
                    new DataColumn(col.ColumnName, col.DataType));
        }

        void _FillComboBoxWithColumnNames()
        {
            foreach (DataColumn column in dtPeople.Columns)
                cbFilter.Items.Add(column.ColumnName);
        }

        private void PeopleList_Load(object sender, EventArgs e)
        {
            _FillDataTable();
            _FillDataGridViewWithData();
            _FillComboBoxWithColumnNames();
        }

        void _DisableAllFilterControls()
        {
            tbFilter.Visible = cbFilterCriterion.Visible =
                lblDateOfBirthFilter.Visible = false;
            dtpDateOfBirth.Visible = false;
        }

        void _CountryFilterMode()
        {
            cbFilterCriterion.Visible = true;
            clsUtility._LoadCountryToComboBox(cbFilterCriterion, clsUtility.DefaultCountry);
        }

        void _GenedrFilterMode()
        {
            cbFilterCriterion.Visible = true;
            cbFilterCriterion.Items.Add("None");
            cbFilterCriterion.Items.Add("Male");
            cbFilterCriterion.Items.Add("Female");
            cbFilterCriterion.SelectedItem = clsUtility.DefaultFilter;
        }

        void _DateOfBirthFilterMode()
        {
            lblDateOfBirthFilter.Visible = true;
            cbFilterCriterion.Visible = true;
            cbFilterCriterion.Items.Add("Day");
            cbFilterCriterion.Items.Add("Month");
            cbFilterCriterion.Items.Add("Year");
            cbFilterCriterion.Items.Add("All");
            cbFilterCriterion.SelectedItem = "Year";
            tbFilter.Visible = true;
        }

        void _TextFilterMode()
        {
            _DisableAllFilterControls();
            _SwitchToAnotherDataTable(ref dtPeople);
            tbFilter.Visible = true;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DisableAllFilterControls();

            if (cbFilter.SelectedItem == null ||
                Enum.TryParse(cbFilter.SelectedItem.ToString(),
                out _FilterMode) == false)
                return;

            if (IsLoad == true)
                IsLoad = false;
            else if (_FilterMode == _enFilterMode.None)
                _RenewDataTable();
            else if (_FilterMode == _enFilterMode.CountryName)
                _CountryFilterMode();
            else if (_FilterMode == _enFilterMode.Gender)
                _GenedrFilterMode();
            else if (_FilterMode == _enFilterMode.DateOfBirth)
                _DateOfBirthFilterMode();
            else
                _TextFilterMode();
        }

        private void cbFilterByValue_VisibleChanged(object sender, EventArgs e)
        {
            if (!cbFilterCriterion.Visible)
                cbFilterCriterion.Items.Clear();
        }

        private void tbFilter_VisibleChanged(object sender, EventArgs e)
        {
            if (!tbFilter.Visible)
                tbFilter.Text = string.Empty;
        }

        void FilterPeopleByExpression(Func <DataRow, bool> exp)
        {
            if (string.IsNullOrEmpty(tbFilter.Text))
                dgvPeopleList.DataSource = dtPeople;

            DataTable dataTableFilter = new DataTable();

            _FillDataTableWithPeopleColumns(ref dataTableFilter);

            foreach (DataRow row in dtPeople.Rows)
                if (exp(row))
                    dataTableFilter.Rows.Add(row.ItemArray);
            
            _SwitchToAnotherDataTable(ref dataTableFilter);
        }

        void _StartWithFilter(string objectName)
        {
            FilterPeopleByExpression((r) =>
                r[objectName].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
        }

        void _FilterByGender()
        {
            if (!string.IsNullOrEmpty(cbFilterCriterion.Text) &&
                cbFilterCriterion.SelectedIndex != 0)
                FilterPeopleByExpression(r =>
                (r["Gender"].ToString()[0] == cbFilterCriterion.Text[0]));
            else
            {
                _DisposeUnusedDataTable();
                dgvPeopleList.DataSource = dtPeople;
            }
        }

        void _FilterPersonIDOrNationalNo()
        {
            if (tbFilter.Text == null ||
                tbFilter.Text == string.Empty)
            {
                _RenewDataTable();
                return;
            }

            clsPeople_BLL person;

            if (_FilterMode == _enFilterMode.PersonID)
            {
                if (int.TryParse(tbFilter.Text,
                    out int ID) == false)
                    return;
                person = clsPeople_BLL.Find(ID);
            }
            else
                person = clsPeople_BLL.Find(tbFilter.Text);

            DataTable dtFilterd = new DataTable();

            _FillDataTableWithPeopleColumns(ref dtFilterd);

            dgvPeopleList.DataSource = dtFilterd;

            if (person.PersonID == -1)
                return; // Show empty table of people
            else
                person.AddToTable(ref dtFilterd);
        }

        void _FilterByCountry()
        {
            if (!String.IsNullOrEmpty(cbFilterCriterion.Text))
                FilterPeopleByExpression(r =>
                    (r["CountryName"].ToString() == cbFilterCriterion.Text));
            else
            {
                _DisposeUnusedDataTable();
                dgvPeopleList.DataSource = dtPeople;
            }
        }

        void _FilterByDateofBirth()
        {

        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            switch (_FilterMode)
            {
                case _enFilterMode.None:
                    _RenewDataTable();
                    break;
                case _enFilterMode.PersonID:
                case _enFilterMode.NationalNo:
                    _FilterPersonIDOrNationalNo();
                    break;
                case _enFilterMode.FirstName:
                case _enFilterMode.SecondName:
                case _enFilterMode.ThirdName:
                case _enFilterMode.LastName:
                case _enFilterMode.Address:
                case _enFilterMode.Phone:
                case _enFilterMode.Email:
                case _enFilterMode.ImagePath:
                    _StartWithFilter(_FilterMode.ToString());
                    break;
                case _enFilterMode.Gender:
                    _FilterByGender();
                    break;
                case _enFilterMode.CountryName:
                    _FilterByCountry();
                    break;
                case _enFilterMode.DateOfBirth:
                    _FilterByDateofBirth();
                    break;
                default:
                    break;
            }
        }
    }
}
