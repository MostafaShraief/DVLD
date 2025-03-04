﻿using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Test_Types
{
    public partial class TestTypesList : Form
    {
        public TestTypesList()
        {
            InitializeComponent();
            clsDataTable = new clsUtility.clsDataTable(lblNumberOfRecords,
                dgvTestTypesList, clsTestTypes_BLL.GetListOfTestTypes);
            clsDataTable.LoadData();
            clsDataTable.LoadColumnsToComboBox(cbFilter);

            clsFilterProcess = new clsUtility.clsFilterProcess(cbFilter, tbFilter, clsDataTable);
            clsFilterProcess.AddColumnIdName("ID");
            clsFilterProcess.AddColumnIdName("Fees");
        }

        clsUtility.clsDataTable clsDataTable;
        clsUtility.clsFilterProcess clsFilterProcess;

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = string.Empty;
            if (clsFilterProcess != null)
                clsFilterProcess.FilterChange();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (clsFilterProcess != null)
                clsFilterProcess.FilterChange();
        }

        private void cbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (tbFilter.Visible)
                    tbFilter.Focus();
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clsFilterProcess._columnIdNames.Contains(cbFilter.Text))
                clsUtility.InputValidator.ValidateKeyPress(sender, e,
                    clsUtility.InputValidator.ValidationType.OnlyNumbers, errorProvider);
        }

        int GetIdFromSelectedRow() => ((int)dgvTestTypesList.SelectedRows[0].Cells[0].Value);

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTestType editTestType = new EditTestType(GetIdFromSelectedRow());
            editTestType.ShowDialog();
            clsDataTable.LoadData();
        }
    }
}
