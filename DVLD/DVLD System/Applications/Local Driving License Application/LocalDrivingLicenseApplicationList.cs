using DVLD.Applications.Local_Driving_License_Application;
using DVLD.Applications.Local_Driving_License_Application.User_Control;
using DVLD.DVLD_System.Applications.Local_Driving_License_Application.User_Controls;
using DVLD.DVLD_System.Applications.Tests;
using DVLD.DVLD_System.Licenses;
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
            ucTitleScreen1.ChangeTitle("Local Licenses List");

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

        int GetLocalLicenseIdFromSelectedRow() =>
            (int)ucList1.GetFromSelectedRow(0);

        string GetNationalNumberFromSelectedRow() =>
            ucList1.GetFromSelectedRow(2).ToString();

        clsGlobal.enLocalLicenseStatus GetPassedTestsFromSelectedRow() =>
            (clsGlobal.enLocalLicenseStatus)ucList1.GetFromSelectedRow(5);

        clsGlobal.enApplicationStatus GetApplicationStatusFromSelectedRow()
        {
            string AppStatus = ucList1.GetFromSelectedRow(6).ToString();

            switch (AppStatus)
            {
                case "New":
                    return clsGlobal.enApplicationStatus.New;
                case "Cancelled":
                    return clsGlobal.enApplicationStatus.Cancelled;
                case "Completed":
                    return clsGlobal.enApplicationStatus.Completed;
                default:
                    return clsGlobal.enApplicationStatus.New;
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLocalLicense addLocalLicense = new AddLocalLicense();
            addLocalLicense.EditMode(GetLocalLicenseIdFromSelectedRow());
            clsGlobal.MainForm.PushNewForm(addLocalLicense);
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPerson addEditPerson = new AddEditPerson();
            addEditPerson.GetPerson(clsPeople_BLL.Find(GetNationalNumberFromSelectedRow()));
            clsGlobal.MainForm.PushNewForm(addEditPerson);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPersonInfo showPersonInfo = new ShowPersonInfo();
            showPersonInfo.GetPerson(clsPeople_BLL.Find(GetNationalNumberFromSelectedRow()));
            clsGlobal.MainForm.PushNewForm(showPersonInfo);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this local license?", "Cancel",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK &&
                clsLocalDrivingLicenseApplication_BLL.CancelLocalLicenseOrder(GetLocalLicenseIdFromSelectedRow()))
            {
                MessageBox.Show("Local license has been canceled.", "canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucList1.RefreshDataSet();
            }
            else
                MessageBox.Show("cancel process has been terminated.", "Not Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLocalLicenseInfo showLocalLicenseInfo = new ShowLocalLicenseInfo();
            showLocalLicenseInfo.GetLocalLicenseId(GetLocalLicenseIdFromSelectedRow());
            clsGlobal.MainForm.PushNewForm(showLocalLicenseInfo);
        }

        // Assuming the context menu is already created and assigned to a control
        private void EnableOrDisableLocalLicenseInfo(bool isEnabled, int MainIndex, int SubIndex)
        {
            // Find the "Show" dropdown item
            ToolStripMenuItem showItem = cmsRow.Items[MainIndex] as ToolStripMenuItem;

            if (showItem != null)
            {
                // Find the "Local License Info" item within the "Show" dropdown
                ToolStripMenuItem localLicenseInfoItem = showItem.DropDownItems[SubIndex] as ToolStripMenuItem;

                if (localLicenseInfoItem != null)
                {
                    // Enable or disable the "Local License Info" item
                    localLicenseInfoItem.Enabled = isEnabled;
                }
            }
        }

        void DisableCmsItems()
        {
            EnableOrDisableLocalLicenseInfo(false, 2, 0); // edit local license
            cmsRow.Items[4].Enabled = false; // cancel
            cmsRow.Items[5].Enabled = false; // delete
            cmsRow.Items[7].Enabled = false; // schedule
            EnableOrDisableLocalLicenseInfo(false, 7, 0); // eye test
            EnableOrDisableLocalLicenseInfo(false, 7, 1); // written
            EnableOrDisableLocalLicenseInfo(false, 7, 2); // street
            cmsRow.Items[9].Enabled = false; // issue license
            cmsRow.Items[11].Enabled = false; // show license
            //cmsRow.Items[12].Enabled = false; // person license history
        }

        private void cmsRow_Opening(object sender, CancelEventArgs e)
        {
            clsGlobal.enApplicationStatus applicationStatus = GetApplicationStatusFromSelectedRow();

            if (applicationStatus == clsGlobal.enApplicationStatus.New)
            {
                DisableCmsItems();

                // global enable section.
                EnableOrDisableLocalLicenseInfo(true, 2, 0); // edit local license
                cmsRow.Items[7].Enabled = true; // schedule
                cmsRow.Items[4].Enabled = true; // cancel
                cmsRow.Items[5].Enabled = true; // delete
                clsGlobal.enLocalLicenseStatus licenseStatus = GetPassedTestsFromSelectedRow();

                // specific enable section
                if (licenseStatus == clsGlobal.enLocalLicenseStatus.EyeTest)
                    EnableOrDisableLocalLicenseInfo(true, 7, 0); // eye test
                else if (licenseStatus == clsGlobal.enLocalLicenseStatus.WrittenTest)
                    EnableOrDisableLocalLicenseInfo(true, 7, 1); // written
                else if (licenseStatus == clsGlobal.enLocalLicenseStatus.PracticalTest)
                    EnableOrDisableLocalLicenseInfo(true, 7, 2); // street
                else
                {
                    cmsRow.Items[7].Enabled = false; // schedule
                    cmsRow.Items[9].Enabled = true; // issue license
                }
            }
            else if (applicationStatus == clsGlobal.enApplicationStatus.Cancelled)
            {
                DisableCmsItems();
                // enable section.
                cmsRow.Items[5].Enabled = false; // delete
            }
            else
            {
                DisableCmsItems();
                // enable
                cmsRow.Items[11].Enabled = true; // show license
            }
        }

        private void personLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverLicensesList driverLicensesList = new DriverLicensesList();
            if (driverLicensesList.GetNationalNo(GetNationalNumberFromSelectedRow()))
                clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }

        private void eyeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointments testAppointments = new TestAppointments();
            testAppointments.GetTestAppointmentInfo(GetLocalLicenseIdFromSelectedRow(), clsGlobal.enTestType.EyeTest);
            clsGlobal.MainForm.PushNewForm(testAppointments);
        }

        private void theoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointments testAppointments = new TestAppointments();
            testAppointments.GetTestAppointmentInfo(GetLocalLicenseIdFromSelectedRow(), clsGlobal.enTestType.WrittenTest);
            clsGlobal.MainForm.PushNewForm(testAppointments);
        }

        private void practicalStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointments testAppointments = new TestAppointments();
            testAppointments.GetTestAppointmentInfo(GetLocalLicenseIdFromSelectedRow(), clsGlobal.enTestType.PracticalTest);
            clsGlobal.MainForm.PushNewForm(testAppointments);
        }

        private void issueLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueLicense issueLicense = new IssueLicense();
            issueLicense.SetLocalLicenseID(GetLocalLicenseIdFromSelectedRow());
            clsGlobal.MainForm.PushNewForm(issueLicense);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseInfo licenseInfo = new LicenseInfo();
            licenseInfo.SetLicenseID(clsLocalDrivingLicenseApplication_BLL.GetLicenseIDByLocalDrivingLicenseAppID(GetLocalLicenseIdFromSelectedRow()));
            clsGlobal.MainForm.PushNewForm(licenseInfo);
        }
    }
}
