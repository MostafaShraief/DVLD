using DVLD.Manage_People;
using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.clsUtility;

namespace DVLD
{
    internal class clsUtility
    {
        public static string DefaultCountry { get { return "Syria"; } }
        public static string DefaultFilter { get { return "None"; } }
        public static string DeffaultGender { get { return "Male"; } }

        public static List<string> ConvertStringToListOfLowerCaseWords(string str)
        {
            List<string> strings = new List<string>();

            StringBuilder stringBuilder = new StringBuilder(str.Trim()),
                Temp = new StringBuilder();

            for (int i = 0; i < stringBuilder.Length; ++i)
            {
                if (stringBuilder[i] == ' ')
                {
                    strings.Add(Temp.ToString());
                    Temp.Clear();
                    stringBuilder = stringBuilder.Remove(0, i + 1);
                    i = 0;
                }
                else
                {
                    stringBuilder[i] =
                        Convert.ToChar(stringBuilder[i].ToString().ToLower());
                    Temp.Append(stringBuilder[i]);
                }
            }

            return strings;
        }

        public static class clsForms
        {
            public static bool DeletePerson(int PersonID)
            {
                if (PersonID == -1)
                    return false;

                if (MessageBox.Show("Are you sure that you want to delete this person card," +
                    " it will be removed from the system forever.", "Delete Card",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (clsPeople_BLL.DeletePerson(PersonID))
                    {
                        MessageBox.Show("Person card has been deleted from the system.", "Deleted Successfully",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                        MessageBox.Show("Person may deleted before or have a license in" +
                            " the system or is a user", "Delete Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Process canceled.", "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                return false;
            }

            public static bool DeleteUser(int UserID)
            {
                if (UserID == -1)
                    return false;

                if (MessageBox.Show("Are you sure that you want to delete this user," +
                    " it will be removed from the system forever.", "Delete Card",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (clsUsers_BLL.DeleteUser(UserID))
                    {
                        MessageBox.Show("User has been deleted from the system.", "Deleted Successfully",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                        MessageBox.Show("User may deleted before or" +
                            " have user logs", "Delete Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Process canceled.", "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                return false;
            }
        }

        public static class Characters
        {
            private static bool ValidateCharacters(string input, string pattern)
            {
                return Regex.IsMatch(input, pattern);
            }

            public static class English
            {
                public static bool ValidateOnlyLetters(string input) => ValidateCharacters(input, @"^[a-zA-Z]+$");
                public static bool ValidateLettersAndNumbers(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9]+$");
                public static bool ValidateOnlyNumbers(string input) => ValidateCharacters(input, @"^\d+$");
                public static bool ValidateEmail(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                public static bool ValidateOnlyLettersWithSpaces(string input) => ValidateCharacters(input, @"^[a-zA-Z\s]+$");
                public static bool ValidateLettersAndNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9\s]+$");
                public static bool ValidateOnlyNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\d\s]+$");
            }

            public static class AllLanguages
            {
                public static bool ValidateOnlyLetters(string input) => ValidateCharacters(input, @"^[\p{L}]+$");
                public static bool ValidateLettersAndNumbers(string input) => ValidateCharacters(input, @"^[\p{L}\p{N}]+$");
                public static bool ValidateOnlyNumbers(string input) => English.ValidateOnlyNumbers(input);
                public static bool ValidateEmail(string input) => ValidateCharacters(input, @"^[\p{L}0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                public static bool ValidateOnlyLettersWithSpaces(string input) => ValidateCharacters(input, @"^[\p{L}\s]+$");
                public static bool ValidateLettersAndNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\p{L}\p{N}\s]+$");
                public static bool ValidateOnlyNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\d\s]+$");
            }
        }

        public static class InputValidator
        {
            public enum ValidationType
            {
                OnlyLetters,
                LettersAndNumbers,
                OnlyNumbers,
                OnlyLettersWithSpaces,
                LettersAndNumbersWithSpaces,
                OnlyNumbersWithSpaces
            }

            private static readonly Dictionary<ValidationType, (string Pattern, string ErrorMessage)> EnglishValidationRules = new Dictionary<ValidationType, (string Pattern, string ErrorMessage)>()
            {
                { ValidationType.OnlyLetters, ("^[a-zA-Z]+$", "Only letters allowed!") },
                { ValidationType.LettersAndNumbers, ("^[a-zA-Z0-9]+$", "Only letters and numbers allowed!") },
                { ValidationType.OnlyNumbers, ("^\\d+$", "Only numbers allowed!") },
                { ValidationType.OnlyLettersWithSpaces, ("^[a-zA-Z\\s]+$", "Only letters and spaces allowed!") },
                { ValidationType.LettersAndNumbersWithSpaces, ("^[a-zA-Z0-9\\s]+$", "Only letters, numbers, and spaces allowed!") },
                { ValidationType.OnlyNumbersWithSpaces, ("^[\\d\\s]+$", "Only numbers and spaces allowed!") }
            };

            private static readonly Dictionary<ValidationType, (string Pattern, string ErrorMessage)> AllLanguagesValidationRules = new Dictionary<ValidationType, (string Pattern, string ErrorMessage)>()
            {
                { ValidationType.OnlyLetters, ("^[\\p{L}]+$", "Only letters allowed!") },
                { ValidationType.LettersAndNumbers, ("^[\\p{L}\\p{N}]+$", "Only letters and numbers allowed!") },
                { ValidationType.OnlyNumbers, ("^\\d+$", "Only numbers allowed!") },
                { ValidationType.OnlyLettersWithSpaces, ("^[\\p{L}\\s]+$", "Only letters and spaces allowed!") },
                { ValidationType.LettersAndNumbersWithSpaces, ("^[\\p{L}\\p{N}\\s]+$", "Only letters, numbers, and spaces allowed!") },
                { ValidationType.OnlyNumbersWithSpaces, ("^[\\d\\s]+$", "Only numbers and spaces allowed!") }
            };

            public static void ValidateKeyPress(object sender, KeyPressEventArgs e, ValidationType validationType, ErrorProvider errorProvider, bool IsEnglishOnly = true)
            {
                if (sender is Guna2TextBox textBox == false) return;

                var validationRules = IsEnglishOnly ? EnglishValidationRules : AllLanguagesValidationRules;
                if (!validationRules.ContainsKey(validationType)) return;

                var (pattern, errorMessage) = validationRules[validationType];
                string newText = e.KeyChar.ToString();

                if (!Regex.IsMatch(newText, pattern) && !char.IsControl(e.KeyChar))
                {
                    errorProvider.SetError(textBox, errorMessage);
                    e.Handled = true;
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                }
            }
        }

        public static void _LoadCountryToComboBox(Guna2ComboBox cb, string DefaultCountry = null)
        {
            DataTable dtCountries = clsCountry_BLL.GetListofCountries();

            foreach (DataRow row in dtCountries.Rows)
                cb.Items.Add(row["CountryName"]);

            if (!String.IsNullOrEmpty(DefaultCountry))
                cb.SelectedItem = DefaultCountry;

            dtCountries.Dispose();
        }

        public static class Image
        {
            public static bool IsImageValid(byte[] imageBytes)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Use System.Drawing.Image.FromStream
                        using (var image = System.Drawing.Image.FromStream(ms))
                        {
                            var test = image.Size; // Accessing properties forces validation
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }

            public static bool IsFileExist(string Path)
            {
                return File.Exists(Path);
            }

            public static Byte[] ImageToByteArray(System.Drawing.Image image)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Save the image to the MemoryStream in the specified format
                        image.Save(ms, image.RawFormat);
                        return ms.ToArray(); // Convert the stream to a byte array
                    }
                }
                catch
                {
                    return null;
                }
            }

            public static System.Drawing.Image ByteArrayToImage(Byte[] imageBytes)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(imageBytes);
                    return System.Drawing.Image.FromStream(ms);
                }
                catch
                {
                    return null;
                }
            }

            public static System.Drawing.Image LoadImageFromFile(string imagePath)
            {
                System.Drawing.Image image = null;

                if (IsFileExist(imagePath))
                {
                    try
                    {
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                    catch
                    {
                        MessageBox.Show("Failed To Retrieve Image", "Select Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return image;
            }
        }
        public static bool IsValidUsernameOrPassword(string input, int Length)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{" + Length.ToString() + ",}$";
            return Regex.IsMatch(input, pattern);
        }

        internal class clsDataTable
        {
            public DataTable dataTable;
            private Label lblRecordsCounter { get; set; }
            Guna2DataGridView dataGridView { get; set; }
            public delegate DataTable delLoadDataTable();
            delLoadDataTable loadDataTable;

            public clsDataTable(Label lblRecordsCounter, Guna2DataGridView dataGridView, delLoadDataTable loadDataTable)
            {
                this.dataGridView = dataGridView;
                this.lblRecordsCounter = lblRecordsCounter;
                this.loadDataTable = loadDataTable;
                LoadData();
            }

            public void RefreshTable()
            {
                dataTable.DefaultView.RowFilter = null;
                RefreshRecordsCounter();
            }

            public void LoadData()
            {
                if (loadDataTable != null)
                    dataTable = loadDataTable();
                dataGridView.DataSource = dataTable;
                RefreshTable();
            }

            public void LoadColumnsToComboBox(Guna2ComboBox comboBox)
            {
                comboBox.Items.Clear();
                comboBox.Items.Add("None");
                foreach (DataColumn col in dataTable.Columns)
                    comboBox.Items.Add(col.ColumnName);
                comboBox.SelectedIndex = 0;
            }

            public void RefreshRecordsCounter() =>
                lblRecordsCounter.Text = dataTable.DefaultView.Count.ToString();

            public void ChangeFilter(string FilterFormat)
            {
                try
                {
                    dataTable.DefaultView.RowFilter = FilterFormat;
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

        internal class clsFilterProcess
        {
            Guna2ComboBox _cbFilter { get; set; }
            Guna2TextBox _tbFilter { get; set; }
            Guna2ComboBox _cbFilterCriterion { get; set; }
            Guna2DateTimePicker _dpFilter { get; set; }
            clsUtility.clsDataTable _DataTable { get; set; }
            List<string> _columnNames = new List<string>();
            public List<string> _DigitColumns = new List<string>();
            Dictionary<string, List<string>> _FilterCriterionDictionery = new Dictionary<string, List<string>>();
            List<string> _DatesColumns = new List<string>();
            List<string> _BooleanColumns = new List<string>();

            public void ResetAll()
            {
                _columnNames = new List<string>();
                _DigitColumns = new List<string>();
                _DatesColumns = new List<string>();
                _BooleanColumns = new List<string>();
                _FilterCriterionDictionery = new Dictionary<string, List<string>>();
                _cbFilter.Items.Clear();
                _cbFilterCriterion.Items.Clear();
                _tbFilter.Text = string.Empty;
            }

            public void FillListWithItems()
            {
                foreach (string columnName in _cbFilter.Items)
                    _columnNames.Add(columnName);
            }

            public clsFilterProcess(Guna2ComboBox cbFilter, Guna2TextBox tbFilter,
                Guna2ComboBox cbFilterCriterion, clsUtility.clsDataTable DataTable, Guna2DateTimePicker dpFilter = null,
                List<string> booleanColumns = null)
            {
                _cbFilter = cbFilter;
                _tbFilter = tbFilter;
                _cbFilterCriterion = cbFilterCriterion;
                _DataTable = DataTable;
                ResetAll();
                _DataTable.LoadColumnsToComboBox(cbFilter);
                FillListWithItems();
                if (dpFilter != null)
                    _dpFilter = dpFilter;
                else
                    _dpFilter = new Guna2DateTimePicker();
            }

            public clsFilterProcess(Guna2ComboBox cbFilter, Guna2TextBox tbFilter,
                clsUtility.clsDataTable DataTable, Guna2DateTimePicker dpFilter = null)
            {
                _cbFilter = cbFilter;
                _tbFilter = tbFilter;
                _cbFilterCriterion = new Guna2ComboBox();
                _DataTable = DataTable;
                ResetAll();
                FillListWithItems();
                if (dpFilter != null)
                    _dpFilter = dpFilter;
                else
                    _dpFilter = new Guna2DateTimePicker();
            }

            public void AddColumnIdName(string Column) =>
                _DigitColumns.Add(Column);

            public void AddCriterion(
                Dictionary<string, List<string>> dctFilterCriterionColumn)
            {
                if (dctFilterCriterionColumn != null)
                    _FilterCriterionDictionery = dctFilterCriterionColumn;
            }

            public void AddDateColumn(string Column) =>
                _DatesColumns.Add(Column);

            public void AddBooleanColumns(string Column) =>
                _BooleanColumns.Add(Column);

            void InitializeComboBoxFilter()
            {
                _cbFilterCriterion.Items.Clear();
                _cbFilterCriterion.Items.Add("All");
                _cbFilterCriterion.SelectedIndex = 0;
                foreach (var Value in _FilterCriterionDictionery[_cbFilter.Text])
                    _cbFilterCriterion.Items.Add(Value);
            }

            void InitializeComboBoxFilterWithBooleans()
            {
                _cbFilterCriterion.Items.Clear();
                _cbFilterCriterion.Items.Add("All");
                _cbFilterCriterion.SelectedIndex = 0;
                _cbFilterCriterion.Items.Add("Yes");
                _cbFilterCriterion.Items.Add("No");
            }

            // there are 2 stepe for filteration.

            // step 1: these 4 funcs below are for user changing in the screen.
            public void ComboBoxFilterChange()
            {
                if (_cbFilter == null)
                    return;

                string ColumnName = _cbFilter.Text;

                if (String.IsNullOrEmpty(ColumnName) || ColumnName == "None")
                {
                    _tbFilter.Visible = false;
                    _cbFilterCriterion.Visible = false;
                    _dpFilter.Visible = false;
                    _DataTable.RefreshTable();
                }
                else if (_cbFilterCriterion != null && _FilterCriterionDictionery.ContainsKey(ColumnName))
                {
                    _cbFilterCriterion.Visible = true;
                    _tbFilter.Visible = false;
                    _dpFilter.Visible = false;
                    InitializeComboBoxFilter();
                }
                else if (_dpFilter != null && _DatesColumns.Contains(ColumnName))
                {
                    _dpFilter.Visible = true;
                    _tbFilter.Visible = false;
                    _cbFilterCriterion.Visible = false;
                    DatePickerChange();
                }
                else if (_cbFilter != null && _BooleanColumns.Contains(ColumnName))
                {
                    _cbFilterCriterion.Visible = true;
                    _tbFilter.Visible = false;
                    _dpFilter.Visible = false;
                    InitializeComboBoxFilterWithBooleans();
                }
                else if (_columnNames.Contains(ColumnName))
                {
                    _tbFilter.Text = string.Empty;
                    _tbFilter.Visible = true;
                    _cbFilterCriterion.Visible = false;
                    _dpFilter.Visible = false;
                }
            }

            public void TextBoxFilterChange()
            {
                if (_cbFilter == null)
                    return;

                string ColumnName = _cbFilter.Text;

                if (String.IsNullOrEmpty(ColumnName) || ColumnName == "None")
                    _DataTable.RefreshTable();
                else
                    TextBoxFilteration();
            }

            public void ComboBoxFilterCriterionChange()
            {
                if (_cbFilterCriterion == null)
                    return;

                string ColumnName = _cbFilter.Text;

                if (_BooleanColumns.Contains(ColumnName))
                    BooleanFilteration();
                else if (_FilterCriterionDictionery.ContainsKey(ColumnName))
                    FilterCriterionFilteration();
            }

            public void DatePickerChange()
            {
                if (_dpFilter == null)
                    return;

                DateTime Date = _dpFilter.Value;

                if (_DatesColumns != null && _DatesColumns.Contains(_cbFilter.Text))
                    DateFilteration();
            }

            // step 2: these 3 funcs below are for data table filteration process changing.
            void TextBoxFilteration()
            {
                string ColumnName = _cbFilter.Text;
                string FilterValue = _tbFilter.Text;

                if (String.IsNullOrEmpty(FilterValue) || FilterValue.Trim() == string.Empty)
                    _DataTable.RefreshTable();
                else if (_DigitColumns.Contains(ColumnName) &&
                    int.TryParse(FilterValue, out int Number))
                    _DataTable.ChangeFilter(String.Format(@"[{0}] = {1}", ColumnName, Number));
                else
                    _DataTable.ChangeFilter(String.Format(@"[{0}] like '{1}%'", ColumnName, FilterValue));
            }

            void DateFilteration()
            {
                string ColumnName = _cbFilter.Text;
                DateTime dateTime = _dpFilter.Value;

                // Get the start of the day (00:00:00)
                DateTime startDate = dateTime.Date;
                // Get the end of the day (23:59:59)
                DateTime endDate = startDate.AddDays(1).AddSeconds(-1);

                _DataTable.ChangeFilter(string.Format(
                    "[{0}] >= #{1:MM/dd/yyyy HH:mm:ss}# AND [{0}] <= #{2:MM/dd/yyyy HH:mm:ss}#",
                    ColumnName, startDate, endDate
                ));
            }

            void FilterCriterionFilteration()
            {
                string ColumnName = _cbFilter.Text;
                string FilterValue = _cbFilterCriterion.Text;

                if (FilterValue == "All")
                    _DataTable.RefreshTable();
                else
                    _DataTable.ChangeFilter(String.Format(@"[{0}] like '{1}%'", ColumnName, FilterValue));
            }

            void BooleanFilteration()
            {
                string ColumnName = _cbFilter.Text;
                string FilterValue = _cbFilterCriterion.Text;

                if (FilterValue[0] == 'A')
                    _DataTable.RefreshTable();
                else if (FilterValue[0] == 'Y')
                    _DataTable.ChangeFilter(String.Format(@"[{0}] = 1", ColumnName, FilterValue));
                else
                    _DataTable.ChangeFilter(String.Format(@"[{0}] = 0", ColumnName, FilterValue));
            }
        }

        /// <summary>
        /// Displays a message box indicating that the current feature is under development.
        /// </summary>
        public static void ShowFeatureUnderDevelopmentMessage()
        {
            MessageBox.Show(
                "This feature is currently under development and will be available in future updates.",
                "Feature Under Development",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
