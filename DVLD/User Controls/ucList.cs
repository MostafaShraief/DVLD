﻿using DVLD_BLL;
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
            List<string> columnIdNames, Dictionary<string, List<string>> dctFilterCriterion = null,
            CrownContextMenuStrip cmsRow = null, List<string> DateColumns = null, List<string> BooleanColumns = null)
        {
            InitializeDataTable(getAllLocalLicensesFunction);
            InitializeFilterProcess(columnIdNames, dctFilterCriterion, DateColumns, BooleanColumns);

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
        }

        // Initialize the filter process
        private void InitializeFilterProcess(List<string> columnIdNames,
            Dictionary<string, List<string>> dctFilterCriterion, List<string> DateColumns, List<string> BooleanColumns)
        {
            _clsFilterProcess = new clsUtility.clsFilterProcess(cbFilter, tbFilter, cbFilterCriterion, _clsDataTable, dtpDate);
            foreach (var columnName in columnIdNames)
            {
                _clsFilterProcess.AddColumnIdName(columnName);
            }

            if (dctFilterCriterion != null)
                _clsFilterProcess.AddCriterion(dctFilterCriterion);

            if (DateColumns != null)
            {
                foreach (string dateColumnName in DateColumns)
                    _clsFilterProcess.AddDateColumn(dateColumnName);
            }

            if (BooleanColumns != null)
            {
                foreach (string boolColumnName in BooleanColumns)
                    _clsFilterProcess.AddBooleanColumns(boolColumnName);
            }
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

        public object GetFromSelectedRow(int ColumnIndex)
        {
            if (dgvList.SelectedRows.Count == 0)
                return null;

            return dgvList.SelectedRows[0].Cells[ColumnIndex].Value;
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            RefreshDataSet();
        }

        public void RefreshDataSet()
        {
            _clsDataTable.LoadData();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilterCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsFilterProcess?.ComboBoxFilterCriterionChange();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            _clsFilterProcess?.DatePickerChange();
        }
    }
}