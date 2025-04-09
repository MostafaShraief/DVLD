using DVLD.DVLD_System.International_Licenses;
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

namespace DVLD.DVLD_System.International_License
{
    public partial class ucAddInternationalLicense : System.Windows.Forms.UserControl
    {
        public ucAddInternationalLicense()
        {
            InitializeComponent();
            licenseObj = new clsLicenses_BLL();
            internationalLicenseObj = new clsInternationalLicenses_BLL();
            ucFindLicenseInfo1.LincenseLinker += SetLicenseObject;
        }

        clsLicenses_BLL licenseObj;
        clsInternationalLicenses_BLL internationalLicenseObj;

        public void SetLicenseId(int LicenseId)
        {
            clsLicenses_BLL LicenseObj = clsLicenses_BLL.Find(LicenseId);

            if (LicenseObj.LicenseID != -1)
                SetLicenseObject(LicenseObj);
        }

        public void SetLicenseObject(clsLicenses_BLL LicenseObj)
        {
            if (LicenseObj == null || LicenseObj.LicenseID == -1)
            {
                MessageBox.Show("No license found", "License Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnShowInternationalLicense.Enabled = false;
                ucInternationalLicense1.Visible = false;
                return;
            }

            licenseObj = LicenseObj;
            FillLicenseInfo();
        }

        void FillLicenseInfo()
        {
            ucInternationalLicense1.Visible = false;
            ucFindLicenseInfo1.SetLicenseObj(licenseObj);

            if (clsLicenses_BLL.IsLicenseQualifiedToInternationalLicense(licenseObj.LicenseID))
                btnIssueInternationalLicense.Enabled = true;
            else
            {
                MessageBox.Show("This licenese" +
                    "is not ordinary vehicle license class or it's not activated.", "Not Qualified",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueInternationalLicense.Enabled = false;
            }
        }

        void FillInternationalLicenseInfo()
        {
            ucInternationalLicense1.SetInternationalLicenseObject(internationalLicenseObj);
            btnShowInternationalLicense.Enabled = true;
            ucInternationalLicense1.Visible = true;
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            if (licenseObj == null)
                return;

            DriverLicensesList driverLicensesList = new DriverLicensesList();
            driverLicensesList.GetNationalNo(licenseObj.NationalNumber);
            clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            internationalLicenseObj.ApplicationID = licenseObj.ApplicationID;
            internationalLicenseObj.LicenseID = licenseObj.LicenseID;
            internationalLicenseObj.DriverID = licenseObj.DriverID;
            internationalLicenseObj.CreatedByUserID = clsGlobal.user.UserID;
            
            if (MessageBox.Show("Do you want to issue international license?", "Issue License",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                MessageBox.Show("Issue international license has been canceled", "Not Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            clsInternationalLicenses_BLL TempObj = clsInternationalLicenses_BLL.FindSammurizedByLicenseID(licenseObj.LicenseID);

            if (TempObj != null && TempObj.InternationalLicenseID != -1)
            {
                MessageBox.Show("This licenese" +
                    "is allready have international license.", "allready issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                internationalLicenseObj = TempObj;
                btnIssueInternationalLicense.Enabled = false;
                FillInternationalLicenseInfo();
                return;
            }

            if (internationalLicenseObj.Save())
            {
                MessageBox.Show("International license has been issued.", "Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                internationalLicenseObj = clsInternationalLicenses_BLL.FindSammurizedByApplicationID(licenseObj.ApplicationID);
                FillInternationalLicenseInfo();
                btnIssueInternationalLicense.Enabled = false;
            }
            else
                MessageBox.Show("International license has been failed to issued, please check data intered", "Failed To Issue",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnShowInternationalLicense_Click(object sender, EventArgs e)
        {
            InternationalLicenseInfo internationalLicenseInfo = new InternationalLicenseInfo();
            internationalLicenseInfo.SetInternationalLicenseId(internationalLicenseObj.InternationalLicenseID);
            internationalLicenseInfo.ShowDialog();
        }
    }
}