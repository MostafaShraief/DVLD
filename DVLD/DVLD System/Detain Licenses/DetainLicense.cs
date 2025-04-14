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

namespace DVLD.DVLD_System.Detain_Licenses
{
    public partial class DetainLicense : Form
    {
        public DetainLicense()
        {
            InitializeComponent();
            ucFindLicenseInfo1.LincenseLinker += SetFoundLiceneObject;
            ucAddDetainLicense1.detainedLicenseObjLinker += SetDetainLiceneObj;
        }

        void SetDetainLiceneObj(clsDetainedLicenses_BLL DetainLicenseObj)
        {
            ucFindLicenseInfo1.SwitchDetainLicenseStatus(!DetainLicenseObj.IsReleased);
        }

        clsLicenses_BLL licenseObj = new clsLicenses_BLL();

        public void SetLicenseID(int LicenseID)
        {
            clsLicenses_BLL LicenseObj = clsLicenses_BLL.Find(LicenseID);
            SetLicenseObject(LicenseObj);
        }

        public void SetLicenseObject(clsLicenses_BLL LicenseObj)
        {
            if (LicenseObj == null || LicenseObj.LicenseID == -1)
            {
                MessageBox.Show("License not found.", "No License",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnShowHistory.Enabled = false;
                btnShowLicense.Enabled = false;
                return;
            }

            licenseObj = LicenseObj;

            ucFindLicenseInfo1.SetLicenseObj(licenseObj);
            ucAddDetainLicense1.SetLicenseId(licenseObj.LicenseID);
            btnShowHistory.Enabled = true;
            btnShowLicense.Enabled = true;
        }

        void SetFoundLiceneObject(clsLicenses_BLL LicenseObj)
        {
            licenseObj = LicenseObj;
            ucAddDetainLicense1.SetLicenseId(licenseObj.LicenseID);
            btnShowHistory.Enabled = true;
            btnShowLicense.Enabled = true;
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
    }
}
