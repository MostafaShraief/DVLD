using DVLD.DVLD_System.Licenses;
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

namespace DVLD.DVLD_System.Applications
{
    public partial class ReleaseLicense : Form
    {
        public ReleaseLicense()
        {
            InitializeComponent();
            ucFindLicenseInfo1.LincenseLinker += SetLicenseObjectByUcFind;
        }

        clsLicenses_BLL licenseObj = new clsLicenses_BLL();
        clsDetainedLicenses_BLL detainedLicenseObj = new clsDetainedLicenses_BLL();

        public void SetLicenseID(int LicenseID)
        {
            clsLicenses_BLL LicenseObj = clsLicenses_BLL.Find(LicenseID);
            SetLicenseObject(LicenseObj);
        }

        public void SetLicenseObject(clsLicenses_BLL LicenseObj)
        {
            if (LicenseObj == null || 
                LicenseObj.LicenseID == -1)
            {
                ucDetainLicenseInfo1.Visible = false;
                return;
            }

            licenseObj = LicenseObj;
            btnShowHistory.Enabled = btnShowLicense.Enabled = true;
            btnShowLicense.Enabled = true;
            ucFindLicenseInfo1.SetLicenseObj(licenseObj);
            SetDetainLicenseByLicenseID(licenseObj.LicenseID);
        }

        void SetLicenseObjectByUcFind(clsLicenses_BLL LicenseObj)
        {
            licenseObj = LicenseObj;
            btnShowHistory.Enabled = btnShowLicense.Enabled = true;
            ucFindLicenseInfo1.SetLicenseObj(licenseObj);
            SetDetainLicenseByLicenseID(licenseObj.LicenseID);
        }

        void SetDetainLicenseByLicenseID(int LicenseID)
        {
            int DetainID = clsDetainedLicenses_BLL.GetActiveDetainIDByLicenseID(LicenseID);

            if (DetainID == -1)
            {
                MessageBox.Show("License is not detained", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucDetainLicenseInfo1.Visible = false;
                return;
            }

            detainedLicenseObj = clsDetainedLicenses_BLL.Find(DetainID);
            ucDetainLicenseInfo1.SetDetainedObject(detainedLicenseObj);
            ucDetainLicenseInfo1.Visible = true;
            btnReleaseLicense.Enabled = true;
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            DriverLicensesList driverLicensesList = new DriverLicensesList();
            driverLicensesList.GetDriverId(licenseObj.DriverID);
            clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }

        private void btnShowLicense_Click(object sender, EventArgs e)
        {
            LicenseInfo licenseInfo = new LicenseInfo();
            licenseInfo.SetLicenseObj(licenseObj);
            clsGlobal.MainForm.PushNewForm(licenseInfo);
        }

        void SwitchToReleaseStatus()
        {
            licenseObj.IsActive = true;
            ucFindLicenseInfo1.SwitchDetainLicenseStatus(false);
        }

        void releaseLicense()
        {
            detainedLicenseObj.ReleasedByUserID = clsGlobal.user.UserID;

            if (detainedLicenseObj.Save())
            {
                MessageBox.Show("License has been released successfully.", "Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                detainedLicenseObj = clsDetainedLicenses_BLL.Find(detainedLicenseObj.DetainID);
                ucDetainLicenseInfo1.SetDetainedObject(detainedLicenseObj);
                SwitchToReleaseStatus();
            }
            else
                MessageBox.Show("License was not detained, please check data entered", "Not Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            btnReleaseLicense.Enabled = false;
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to release this license id = {detainedLicenseObj.LicenseID}?",
                "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                releaseLicense();
            else
                MessageBox.Show("Release license has been canceled", "Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
