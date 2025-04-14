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

namespace DVLD.DVLD_System.Licenses.User_Control
{
    public partial class ucRenewLicense : System.Windows.Forms.UserControl
    {
        public ucRenewLicense()
        {
            InitializeComponent();
            ucFindLicenseInfo1.LincenseLinker += SetOldLicenseObj;
            oldLicenseObj = new clsLicenses_BLL();
            newLicenseObj = new clsLicenses_BLL();
        }

        clsLicenses_BLL oldLicenseObj;
        clsLicenses_BLL newLicenseObj;

        void SetOldLicenseId(int LicenseID)
        {
            clsLicenses_BLL OldLicenseObj = clsLicenses_BLL.Find(LicenseID);
            SetOldLicenseObj(OldLicenseObj);
        }

        void SetOldLicenseObj(clsLicenses_BLL OldLicenseObj)
        {
            if (OldLicenseObj == null || OldLicenseObj.LicenseID == -1)
                return;

            oldLicenseObj = OldLicenseObj;

            if (IsRenewLicenesQualified())
            {
                btnRenewLicense.Enabled = true;
                ucrenewLicenseInfo1.SetLicensesObject(oldLicenseObj, null);
                ucrenewLicenseInfo1.Visible = true;
            }
            else
            {
                ucrenewLicenseInfo1.Visible = false;
                btnRenewLicense.Enabled = false;
                btnShowLicense.Enabled = false;
            }

            btnShowHistory.Enabled = true;
        }

        bool IsRenewLicenesQualified()
        {
            if (clsLicenses_BLL.IsLicenseQualifiedForRenewal(oldLicenseObj.LicenseID) == false)
            {
                MessageBox.Show("this license is not qualified to renew it, maybe is not expired or it's detained.",
                    "Not Qualified", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (clsLicenses_BLL.HasActiveOrDetainedLicense(oldLicenseObj.DriverID,
                oldLicenseObj.LicenseClassID, oldLicenseObj.LicenseID))
            {
                MessageBox.Show("this license is not qualified to renew it, " +
                    "driver allready has an active license or detained license in the system", "Not Qualified",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        public bool RenewLicense()
        {
            if (MessageBox.Show("Are you sure you want to renew license?", "Renew License",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                MessageBox.Show("Renew licenes cancelled.", "Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return true;
            }

            newLicenseObj.Notes = ucrenewLicenseInfo1.tbNote.Text;
            newLicenseObj.CreatedByUserID = clsGlobal.user.UserID;

            if (newLicenseObj.RenewLicense(oldLicenseObj.LicenseID,
                newLicenseObj.Notes, newLicenseObj.CreatedByUserID))
            {
                MessageBox.Show("License renewed successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnShowLicense.Enabled = true;
                btnRenewLicense.Enabled = false;
                newLicenseObj = clsLicenses_BLL.Find(newLicenseObj.LicenseID);
                ucrenewLicenseInfo1.SetLicensesObject(oldLicenseObj, newLicenseObj);
                return true;
            }
            else
            {
                MessageBox.Show("License can not be saved, please check data entered again.", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return false;
            }
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            RenewLicense();
        }

        private void btnShowLicenes_Click(object sender, EventArgs e)
        {
            LicenseInfo licenseInfo = new LicenseInfo();
            licenseInfo.SetLicenseObj(newLicenseObj);
            clsGlobal.MainForm.PushNewForm(licenseInfo);
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            DriverLicensesList driverLicensesList = new DriverLicensesList();
            driverLicensesList.GetDriverId(oldLicenseObj.DriverID);
            clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }
    }
}
