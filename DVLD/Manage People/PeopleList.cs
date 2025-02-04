using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
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
            cbFilter.SelectedItem = "None";
        }

        private enum _enFilterMode { None, PersonID, NationalNo, FirstName,
            SecondName, ThirdName, LastName, DateOfBirth,
            Gender, Address, Phone, Email, CountryName, ImagePath}

        _enFilterMode _FilterMode = _enFilterMode.None;

        DataTable dtPeople;

        void _FillDataTable()
        {
            dtPeople = clsPeople_BLL.GetListOfPeople();
        }

        void _FillDataGridViewWithData()
        {
            dgvPeopleList.DataSource = dtPeople;
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
            tbFilter.Visible = false;
            cbFilterCriterion.Visible = false;
            lblDateOfBirthFilter.Visible = false;
            dtpDateOfBirth.Visible = false;
        }

        void _LoadCountryToComboBox()
        {
            //DataTable dtCountry;
            // Code...
        }

        void _CountryFilterMode()
        {
            _FilterMode = _enFilterMode.CountryName;
            _DisableAllFilterControls();

            cbFilterCriterion.Visible = true;
            _LoadCountryToComboBox();
        }

        void _GenedrFilterMode()
        {
            _FilterMode = _enFilterMode.Gender;
            _DisableAllFilterControls();

            cbFilterCriterion.Visible = true;
            cbFilterCriterion.Items.Add("None");
            cbFilterCriterion.SelectedItem = "None";
            cbFilterCriterion.Items.Add("Male");
            cbFilterCriterion.Items.Add("Female");
        }

        void _DateOfBirthFilterMode()
        {
            _FilterMode = _enFilterMode.DateOfBirth;
            _DisableAllFilterControls();

            lblDateOfBirthFilter.Visible = true;
            cbFilterCriterion.Visible = true;
            cbFilterCriterion.Items.Add("Day");
            cbFilterCriterion.Items.Add("Month");
            cbFilterCriterion.Items.Add("Year");
            cbFilterCriterion.Items.Add("All");
            cbFilterCriterion.SelectedItem = "Year";
            tbFilter.Visible = true;
        }

        void _TextFilterMode(string FilterType)
        {
            _DisableAllFilterControls();

            tbFilter.Visible = true;

            if (FilterType == "PersonID")
                _FilterMode = _enFilterMode.PersonID;
            else if (FilterType == "NationalNo")
                _FilterMode = _enFilterMode.NationalNo;
            else if (FilterType == "FirstName")
                _FilterMode = _enFilterMode.FirstName;
            else if (FilterType == "SecondName")
                _FilterMode = _enFilterMode.SecondName;
            else if (FilterType == "ThirdName")
                _FilterMode = _enFilterMode.ThirdName;
            else if (FilterType == "LastName")
                _FilterMode = _enFilterMode.LastName;
            else if (FilterType == "Gender")
                _FilterMode = _enFilterMode.Gender;
            else if (FilterType == "Address")
                _FilterMode = _enFilterMode.Address;
            else if (FilterType == "Phone")
                _FilterMode = _enFilterMode.Phone;
            else if (FilterType == "Email")
                _FilterMode = _enFilterMode.Email;
            else
                _FilterMode = _enFilterMode.ImagePath;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem == null ||
                cbFilter.SelectedItem.ToString() == "None")
            {
                _FilterMode = _enFilterMode.None;
                _DisableAllFilterControls();
                return;
            }

            string FilterType = cbFilter.SelectedItem.ToString();

            if (FilterType == "CountryName")
                _CountryFilterMode();
            else if (FilterType == "Gender")
                _GenedrFilterMode();
            else if (FilterType == "DateOfBirth")
                _DateOfBirthFilterMode();
            else
                _TextFilterMode(FilterType);
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

        void _DisposeUnusedDataTable()
        {
            if ((DataTable)dgvPeopleList.DataSource != dtPeople)
                ((DataTable)dgvPeopleList.DataSource).Dispose();
        }

        void FilterPeopleByExpression(Func <DataRow, bool> exp)
        {
            if (tbFilter.Text == null ||
                tbFilter.Text == string.Empty)
                dgvPeopleList.DataSource = dtPeople;

            DataTable dataTableFilter = new DataTable();

            foreach (DataColumn col in dtPeople.Columns)
                dataTableFilter.Columns.Add(
                    new DataColumn(col.ColumnName, col.DataType));

            foreach (DataRow row in dtPeople.Rows)
                if (exp(row))
                    dataTableFilter.Rows.Add(row.ItemArray);

            _DisposeUnusedDataTable();

            dgvPeopleList.DataSource = dataTableFilter;
        }

        void _RenewDataTable()
        {
            dtPeople.Dispose();
            _FillDataTable();
            _FillDataGridViewWithData();
        }

        void _FilterPersonIDOrNationalNo(bool ByID)
        {
            dtPeople.Rows.Clear();

            if (tbFilter.Text == null ||
                tbFilter.Text == string.Empty)
            {
                _RenewDataTable();
                return;
            }

            clsPeople_BLL person;

            if (ByID)
            {
                if (int.TryParse(tbFilter.Text,
                    out int ID) == false)
                    return;
                person = clsPeople_BLL.Find(ID);
            }
            else
                person = clsPeople_BLL.Find(tbFilter.Text);


            if (person.PersonID == -1) 
                return;

            DataRow row = person.ConvertToDataRow(ref dtPeople);

            if (row != null)
                dtPeople.Rows.Add(row);
        }

        bool _CompareStrings(List<string> list1, List<string> list2)
        {
            // this function will split both string then
            // compare each word of str1 with each word of str2,
            // all words will be convert to lower characters.
            bool IsOk = false;

            foreach (string substr1 in list1)
            {
                foreach (string substr2 in list2)
                {
                    if (substr1.Contains(substr2))
                    {
                        IsOk = true;
                        break;
                    }
                }
            }

            return IsOk;
        }

        bool CompareExperssion(string RowItem, List<string> List2)
        {
            List<string> List1 = 
                clsUtility.ConvertStringToListOfLowerCaseWords(RowItem);

            return _CompareStrings(List1 , List2);
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            switch (_FilterMode)
            {
                case _enFilterMode.None:
                    _RenewDataTable();
                    break;
                case _enFilterMode.PersonID:
                    _FilterPersonIDOrNationalNo(true);
                    break;
                case _enFilterMode.NationalNo:
                    _FilterPersonIDOrNationalNo(false);
                    break;
                case _enFilterMode.FirstName:
                    FilterPeopleByExpression(r =>
                        r["SecondName"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.SecondName:
                    FilterPeopleByExpression((r) =>
                        r["SecondName"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.ThirdName:
                    FilterPeopleByExpression((r) =>
                        r["ThirdName"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.LastName:
                    FilterPeopleByExpression((r) =>
                        r["LastName"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.Address:
                    FilterPeopleByExpression((r) =>
                        r["Address"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.Phone:
                    FilterPeopleByExpression((r) =>
                        r["Phone"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.Email:
                    FilterPeopleByExpression((r) =>
                        r["Email"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.ImagePath:
                    FilterPeopleByExpression((r) =>
                        r["ImagePath"].ToString().ToLower().StartsWith(tbFilter.Text.ToLower()));
                    break;
                case _enFilterMode.Gender:
                    if (cbFilterCriterion.Text != null &&
                        cbFilterCriterion.Text != string.Empty &&
                        cbFilterCriterion.SelectedIndex != 0)
                        FilterPeopleByExpression(r =>
                        (r["Gender"].ToString()[0] == cbFilterCriterion.Text[0]));
                    else
                    {
                        _DisposeUnusedDataTable();
                        dgvPeopleList.DataSource = dtPeople;
                    }
                    break;
                default:
                    FilterPeopleByExpression((r) => true);
                    break;
            }
        }
    }
}
