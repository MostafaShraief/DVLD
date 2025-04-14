using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Licenses.User_Control
{
    public partial class ucFindLicenseInfo : System.Windows.Forms.UserControl
    {
        public ucFindLicenseInfo()
        {
            InitializeComponent();
            ucFindLicense1.GetLicenseIdLinker += SetLicenseId;
        }

        public delegate void delLicense(clsLicenses_BLL LicenseObj);
        public delLicense LincenseLinker;
        clsLicenses_BLL licenseObj = new clsLicenses_BLL();

        public void SetLicenseId(int LicenseId)
        {
            licenseObj = clsLicenses_BLL.Find(LicenseId);
            if (LincenseLinker != null)
                LincenseLinker(licenseObj);
            SetLicenseObj(licenseObj);
        }

        public void SetLicenseObj(clsLicenses_BLL LicenseObj)
        {
            licenseObj = LicenseObj;
            ucLicenseInfo1.SetLicenseObj(LicenseObj);
        }

        public void SwitchDetainLicenseStatus(bool IsDetained)
        {
            licenseObj.IsDetained = IsDetained;
            licenseObj.IsActive = !IsDetained;
            ucLicenseInfo1.SetLicenseObj(licenseObj);
        }
    }
}
