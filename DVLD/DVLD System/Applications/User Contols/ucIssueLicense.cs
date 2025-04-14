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
    public partial class ucIssueLicense : System.Windows.Forms.UserControl
    {
        public ucIssueLicense()
        {
            InitializeComponent();
            localLicenseObj = new clsLocalDrivingLicenseApplication_BLL();
            licenseObj = new clsLicenses_BLL();
        }

        clsLocalDrivingLicenseApplication_BLL localLicenseObj;

        clsLicenses_BLL licenseObj;

        public void SetLocalLicenseID(int LocalLicenseID)
        {
            localLicenseObj = clsLocalDrivingLicenseApplication_BLL.Find(LocalLicenseID);

            if (localLicenseObj == null)
                return;

            FillInfo();
        }

        void FillInfo()
        {
            ucLocalLicenseInfoWithApplication1.SetLocalLicenseObject(localLicenseObj);
            licenseObj.ApplicationID = localLicenseObj.ApplicationID;
            licenseObj.LicenseClassID = localLicenseObj.LicenseClassID;
            licenseObj.IssueReason = clsLicenses_BLL.enIssueReason.New;
            licenseObj.CreatedByUserID = clsGlobal.user.UserID;
        }

        int GetDriverID()
        {
            clsDrivers_BLL driverObj = clsDrivers_BLL.FindByNationalNo(localLicenseObj.NationalNumber);

            if (driverObj.PersonID == -1)
            {
                driverObj.PersonID = clsPeople_BLL.Find(localLicenseObj.NationalNumber).PersonID;
                driverObj.Save(clsGlobal.user.UserID);
            }

            return driverObj.DriverID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue licenes?", "Issue License",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {

                MessageBox.Show("License issued has been canceled", "Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int DriverID = GetDriverID();

            if (DriverID == -1)
            {
                MessageBox.Show("License has not been issued, please check data interred", "License Not Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            licenseObj.Notes = tbNote.Text;
            licenseObj.DriverID = DriverID;

            if (licenseObj.Save())
            {
                MessageBox.Show("License has been issued successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsGlobal.MainForm.PopFormForever();
            }
            else
                MessageBox.Show("License has not been issued, please check data entered", "License not issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
