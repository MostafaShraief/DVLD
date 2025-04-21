using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ListScreen : Form
    {
        // Global variables for data table and filter process
        private clsUtility.clsDataTable _clsDataTable;
        private clsUtility.clsFilterProcess _clsFilterProcess;

        // Constructor with parameters
        public ListScreen(Func<DataTable> getAllLocalLicensesFunction, List<string> columnIdNames, string FormTitle, CrownContextMenuStrip cmsRow = null)
        {
            InitializeComponent();
            InitializeDataTable(getAllLocalLicensesFunction);
            InitializeFilterProcess(columnIdNames);
            ucTitleScreen1.ChangeTitle(FormTitle);

            // Attach the context menu strip to the DataGridView if provided
            if (cmsRow != null)
            {
                dgvList.ContextMenuStrip = cmsRow;
            }
        }

        // Initialize the data table
        private void InitializeDataTable(Func<DataTable> getAllLocalLicensesFunction)
        {
            _clsDataTable = new clsUtility.clsDataTable(lblNumberOfRecords, dgvList, getAllLocalLicensesFunction.Invoke);
            _clsDataTable.LoadData();
            _clsDataTable.LoadColumnsToComboBox(cbFilter);
        }

        // Initialize the filter process
        private void InitializeFilterProcess(List<string> columnIdNames)
        {
            _clsFilterProcess = new clsUtility.clsFilterProcess(cbFilter, tbFilter, _clsDataTable);
            foreach (var columnName in columnIdNames)
            {
                _clsFilterProcess.AddColumnIdName(columnName);
            }
        }

        // Event handlers for filtering
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = string.Empty;
            _clsFilterProcess?.ComboBoxFilterCriterionChange();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _clsFilterProcess?.TextBoxFilterChange();
        }

        private void cbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbFilter.Visible)
            {
                tbFilter.Focus();
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_clsFilterProcess._DigitColumns.Contains(cbFilter.Text))
            {
                clsUtility.InputValidator.ValidateKeyPress(sender, e, clsUtility.InputValidator.ValidationType.OnlyNumbers, errorProvider);
            }
        }

        // Helper method to get the selected ID from the DataGridView
        public int GetIdFromSelectedRow()
        {
            return (int)dgvList.SelectedRows[0].Cells[0].Value;
        }
    }
}
