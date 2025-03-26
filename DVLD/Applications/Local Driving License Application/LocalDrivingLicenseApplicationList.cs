using DVLD.Applications.Local_Driving_License_Application;
using DVLD.Applications.Local_Driving_License_Application.User_Control;
using DVLD.Manage_People;
using DVLD.Manage_People.User_Controls;
using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class LocalDrivingLicenseApplicationList : Form
    {
        public LocalDrivingLicenseApplicationList()
        {
            InitializeComponent();

            List<string> columnIdNames = new List<string>
            {
                "L.D.L.AppID",
                "Passed Tests"
            };

            Dictionary<string, List<string>> dctComboBoxItems = new Dictionary<string, List<string>>()
            {
                { "Status", new List<string> { "Canceled", "Completed", "New" } },
                { "Class Name", new List<string> { "Class 1", "Class 2", "Class 3", "Class 4",
                    "Class 5", "Class 6", "Class 7" } }
            };

            ucList1.FillListObject(
                clsLocalDrivingLicenseApplication_BLL.GetAllLocalLicenses,
                columnIdNames, dctComboBoxItems, cmsRow);
        }

        private void btnAddLocalLicense_Click(object sender, EventArgs e)
        {
            AddLocalLicense addLocalLicense = new AddLocalLicense();
            clsGlobal.MainForm.PushNewForm(addLocalLicense);
        }

        int GetApplicationIdFromSelectedRow() =>
            (int)ucList1.GetFromSelectedRow(0);

        string GetPersonIdFromSelectedRow() =>
            ucList1.GetFromSelectedRow(2).ToString();

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLocalLicense addLocalLicense = new AddLocalLicense();
            addLocalLicense.EditMode(GetApplicationIdFromSelectedRow());
            clsGlobal.MainForm.PushNewForm(addLocalLicense);
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPerson addEditPerson = new AddEditPerson();
            addEditPerson.GetPerson(clsPeople_BLL.Find(GetPersonIdFromSelectedRow()));
            clsGlobal.MainForm.PushNewForm(addEditPerson);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonInfo showPersonInfo = new ShowPersonInfo();
            showPersonInfo.GetPerson(clsPeople_BLL.Find(GetPersonIdFromSelectedRow()));
            clsGlobal.MainForm.PushNewForm(showPersonInfo);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this local license?", "Cancel",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK &&
                clsLocalDrivingLicenseApplication_BLL.CancelLocalLicenseOrder(GetApplicationIdFromSelectedRow()))
            {
                MessageBox.Show("Local license has been canceled.", "canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucList1.RefreshDataSet();
            }
            else
                MessageBox.Show("cancel process has been terminated.", "Not Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this local license?", "Delete",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show("Local license has been deleted.", "Delted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucList1.RefreshDataSet();
            }
            else
                MessageBox.Show("delete process has been canceled.", "Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
