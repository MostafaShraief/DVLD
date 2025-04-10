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
    public partial class ucReplacementLicense : System.Windows.Forms.UserControl
    {
        public ucReplacementLicense()
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

            if (IsLicenseQualified())
            {
                btnReplaceLicense.Enabled = true;
                ucrenewLicenseInfo1.SetLicensesObject(oldLicenseObj, null);
                ucrenewLicenseInfo1.Visible = true;
            }
            else
            {
                ucrenewLicenseInfo1.Visible = false;
                btnReplaceLicense.Enabled = false;
                btnShowLicense.Enabled = false;
            }

            btnShowHistory.Enabled = true;
        }

        bool IsLicenseQualified()
        {
            if (clsLicenses_BLL.IsLicenseQualifiedForReplacement(oldLicenseObj.LicenseID) == false)
            {
                MessageBox.Show("this license is not qualified to replace it, maybe is not expired or it's detained.",
                    "Not Qualified", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void SavedProcesss()
        {
            MessageBox.Show("License replaced successfully.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnShowLicense.Enabled = true;
            btnReplaceLicense.Enabled = false;
            newLicenseObj = clsLicenses_BLL.Find(newLicenseObj.LicenseID);
            ucrenewLicenseInfo1.SetLicensesObject(oldLicenseObj, newLicenseObj);
        }

        public bool replaceLicense()
        {
            if (rbDamage.Checked == rbLost.Checked)
            {
                MessageBox.Show("Please choocse replacement reason.", "No Replacement Reason",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (MessageBox.Show("Are you sure you want to replace license?", "replace License",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                MessageBox.Show("replace licenes cancelled.", "Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return true;
            }

            newLicenseObj.Notes = ucrenewLicenseInfo1.tbNote.Text;
            newLicenseObj.CreatedByUserID = clsGlobal.user.UserID;

            if (rbDamage.Checked && newLicenseObj.ReplaceLicenseForDamage(oldLicenseObj.LicenseID,
                newLicenseObj.Notes, newLicenseObj.CreatedByUserID))
            {
                SavedProcesss();
                return true;
            }
            else if (rbLost.Checked && newLicenseObj.ReplaceLicenseForLost(oldLicenseObj.LicenseID,
                newLicenseObj.Notes, newLicenseObj.CreatedByUserID))
            {
                SavedProcesss();
                return true;
            }
            else
            {
                MessageBox.Show("License can not be saved, please check data intered again.", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplaceLicense.Enabled = false;
                return false;
            }
        }

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            replaceLicense();
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
