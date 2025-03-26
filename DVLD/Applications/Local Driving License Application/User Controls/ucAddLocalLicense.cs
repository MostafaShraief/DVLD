using DVLD.Manage_People.User_Controls;
using DVLD_BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License_Application.User_Control
{
    public partial class ucAddLocalLicense : System.Windows.Forms.UserControl
    {
        public ucAddLocalLicense()
        {
            InitializeComponent();

            // When person found, then show application panel.
            ucFindAndShowInfoPerson1.LinkerFound += ShowApplicationPanel;
            ucFindAndShowInfoPerson1.HideAddButton();

            // Prepare license clas types.
            FillLicenseClassComboBox();

            // get new local license fees.
            fees = clsApplicationType_BLL.GetApplicationTypeFees((int)clsGlobal.ApplicationType.NewLocalDrivingLicenseService);
            lblFeesValue.Text = fees.ToString();

            lblDateValue.Text = DateTime.Now.Date.ToString();
            lblCreatedByValue.Text = clsGlobal.user.UserName;
        }
        float fees;

        Dictionary<string, Byte> dicClasses = new Dictionary<string, Byte>();

        clsLocalDrivingLicenseApplication_BLL LocalLicenseObj;

        void FillLicenseClassComboBox()
        {
            DataTable dataTable = clsLicenseClasses_BLL.GetListOfTestLicenseClasses();

            foreach (DataRow row in dataTable.Rows)
            {
                cbLicenseClass.Items.Add(row["Class Name"].ToString());
                dicClasses.Add(row["Class Name"].ToString(), Convert.ToByte(row["Minimum Allowed Age"]));
            }
        }

        bool CheckAge()
        {
            string SelectedClass = cbLicenseClass.SelectedItem.ToString();
            Byte MinimumeAge = dicClasses[SelectedClass];

            if (ucFindAndShowInfoPerson1.person.DateOfBirth > DateTime.Now.AddYears(-MinimumeAge))
            {
                MessageBox.Show($"Person age not allowed to take this license class," +
                    $" minimume allowed age for {SelectedClass} is {MinimumeAge}.", "Not Allowed Age",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // unvalid age
            }

            return true; // valid age
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckAge())
            {
                btnSave.Visible = true;
                btnSave.Focus();
            }
            else
            {
                btnSave.Visible = false;
                cbLicenseClass.SelectedText = "";
            }
        }

        void ShowApplicationPanel()
        {
            pnlLocDrvLicApp.Visible = true;
        }

        bool CheckData()
        {
            bool IsOk = true;

            if (ucFindAndShowInfoPerson1.person == null || String.IsNullOrEmpty(cbLicenseClass.Text))
                IsOk = false;

            return IsOk;
        }

        void FillLocalLicenseInfo()
        {
            lblLocDrvLicAppID.Text = LocalLicenseObj.LocalDrivingLicenseApplicationID.ToString();
            lblFeesValue.Text = clsApplications_BLL.GetApplicationFees(LocalLicenseObj.ApplicationID).ToString();
            lblCreatedByValue.Text = LocalLicenseObj.CreatedByUserID.ToString();
            lblDateValue.Text = LocalLicenseObj.ApplicationDate.ToString();
            ucFindAndShowInfoPerson1.FillPersonInfo(clsPeople_BLL.Find(LocalLicenseObj.NationalNumber));
            cbLicenseClass.SelectedIndex = LocalLicenseObj.LicenseClassID - 1;
        }

        public void EditMode(clsLocalDrivingLicenseApplication_BLL LocalLicenseObject)
        {
            if (LocalLicenseObject == null || LocalLicenseObject.LocalDrivingLicenseApplicationID == -1)
                return;

            if (LocalLicenseObject.Status == (Byte)clsGlobal.enApplicationStatus.Cancelled)
                btnCancel.Enabled = false;

            LocalLicenseObj = LocalLicenseObject;
            FillLocalLicenseInfo();

            btnDelete.Visible = btnCancel.Visible = true;
            cbLicenseClass.Enabled = false;
            btnSave.Visible = btnAddPerson.Visible = false;
            ucFindAndShowInfoPerson1.ChangeEnableFindPerson(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData() == false)
                return;

            int LocalLicenseId = clsLocalDrivingLicenseApplication_BLL.Add(
                ucFindAndShowInfoPerson1.person.PersonID, (Byte)(cbLicenseClass.SelectedIndex + 1),
                clsGlobal.user.UserID);

            if (LocalLicenseId != -1)
            {
                MessageBox.Show("Local license saved succesfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                EditMode(clsLocalDrivingLicenseApplication_BLL.Find(LocalLicenseId));
            }
            else
                MessageBox.Show("Failed to save local license.", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this local license?", "Delete",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show("Local license has been deleted.", "Delted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsGlobal.MainForm.PopFormForever();
            }
            else
                MessageBox.Show("delete process has been canceled.", "Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this local license?", "Cancel",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK &&
                    clsLocalDrivingLicenseApplication_BLL.CancelLocalLicenseOrder(LocalLicenseObj.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("Local license has been canceled.", "Delted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancel.Enabled = false;
            }
            else
                MessageBox.Show("cancel process has been terminated.", "Not Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
