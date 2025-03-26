using DVLD_BLL;
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

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class ucList : System.Windows.Forms.UserControl
    {
        // Global variables for data table and filter process
        private clsUtility.clsDataTable _clsDataTable;
        private clsUtility.clsFilterProcess _clsFilterProcess;

        // Constructor with parameters
        //public ucList(Func<DataTable> getAllLocalLicensesFunction, 
        //    List<string> columnIdNames, 
        //    CrownContextMenuStrip cmsRow = null)
        //{
        //    InitializeComponent();
        //    InitializeDataTable(getAllLocalLicensesFunction);
        //    InitializeFilterProcess(columnIdNames);
        //    if (dctFilterCriterion != null)
        //        _clsFilterProcess.AddColumnFilterCriterionName(dctFilterCriterion);

        //    // Attach the context menu strip to the DataGridView if provided
        //    if (cmsRow != null)
        //    {
        //        dgvList.ContextMenuStrip = cmsRow;
        //    }
        //}

        public ucList()
        {
            InitializeComponent();
        }

        public void FillListObject(Func<DataTable> getAllLocalLicensesFunction,
            List<string> columnIdNames, Dictionary<string, List<string>> dctFilterCriterion = null, CrownContextMenuStrip cmsRow = null)
        {
            InitializeDataTable(getAllLocalLicensesFunction);
            InitializeFilterProcess(columnIdNames, dctFilterCriterion);

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
        private void InitializeFilterProcess(List<string> columnIdNames,
            Dictionary<string, List<string>> dctFilterCriterion)
        {
            _clsFilterProcess = new clsUtility.clsFilterProcess(cbFilter, tbFilter, cbFilterCriterion, _clsDataTable);
            foreach (var columnName in columnIdNames)
            {
                _clsFilterProcess.AddColumnIdName(columnName);
            }

            if (dctFilterCriterion != null)
                _clsFilterProcess.AddCriterion(dctFilterCriterion);
        }

        // Event handlers for filtering
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = string.Empty;
            _clsFilterProcess?.ComboBoxFilterChange();
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
            if (_clsFilterProcess._columnIdNames.Contains(cbFilter.Text))
            {
                clsUtility.InputValidator.ValidateKeyPress(sender, e, clsUtility.InputValidator.ValidationType.OnlyNumbers, errorProvider);
            }
        }

        // Helper method to get the selected ID from the DataGridView
        public int GetIdFromSelectedRow()
        {
            return (int)dgvList.SelectedRows[0].Cells[0].Value;
        }

        public object GetFromSelectedRow(int ColumnIndex) =>
            dgvList.SelectedRows[0].Cells[ColumnIndex].Value;

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            RefreshDataSet();
        }

        public void RefreshDataSet()
        {
            _clsDataTable.LoadData();
        }

        private void cbFilterCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsFilterProcess?.ComboBoxFilterCriterionChange();
        }
    }
}