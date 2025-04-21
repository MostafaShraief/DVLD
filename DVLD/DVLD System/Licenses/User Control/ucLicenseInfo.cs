using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Licenses.User_Control
{
    public partial class ucLicenseInfo : System.Windows.Forms.UserControl
    {
        public ucLicenseInfo()
        {
            InitializeComponent();
        }

        clsLicenses_BLL licenseObj = new clsLicenses_BLL();

        public void SetLicenseObj(clsLicenses_BLL LicenseObj)
        {
            if (LicenseObj == null || LicenseObj.LicenseID == -1)
                return;

            licenseObj = LicenseObj;

            FillInfo();
        }

        public void SetLicenseID(int LicenseID)
        {
            clsLicenses_BLL LicenseObj = clsLicenses_BLL.Find(LicenseID);
            SetLicenseObj(LicenseObj);
        }

        void FillInfo()
        {
            // License Information
            lblLicenseID.Text = licenseObj.LicenseID.ToString();
            lblLicenseClass.Text = licenseObj.LicenseClassName;
            lblIssueReason.Text = licenseObj.IssueReason.ToString();

            // Personal Information
            lblFullName.Text = licenseObj.FullName;
            lblNationalNumber.Text = licenseObj.NationalNumber;
            lblGender.Text = licenseObj.Gender == clsLicenses_BLL.enGender.Male ? "Male" : "Female";
            lblDateOfBirth.Text = licenseObj.DateOfBirth.ToString("dd/MM/yyyy");
            // profile image
            Byte[] ImageFile = clsPeople_BLL.Find(licenseObj.NationalNumber).ImageFile;
            pbProfileImage.Image = clsGlobal.FillPersonImage(ImageFile, (clsPeople_BLL.enGender)licenseObj.Gender);

            // License Dates
            lblIssueDate.Text = licenseObj.IssueDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = licenseObj.ExpirationDate.ToString("dd/MM/yyyy");

            // Status Information
            lblIsActive.Text = licenseObj.IsActive ? "Active" : "Inactive";
            lblIsDetained.Text = licenseObj.IsDetained ? "Yes" : "No";

            // Additional Information
            lblNote.Text = string.IsNullOrEmpty(licenseObj.Notes) ? "No Notes" : licenseObj.Notes;

            // IDs (optional display)
            lblDriverID.Text = licenseObj.DriverID.ToString();

            // Formatting for status labels
            lblIsActive.ForeColor = licenseObj.IsActive ? Color.Green : Color.Red;
            lblIsDetained.ForeColor = licenseObj.IsDetained ? Color.Red : Color.Green;
        }

        public void ConvertToDetainedLicense()
        {
            // Status Information
            lblIsActive.Text = licenseObj.IsActive ? "Active" : "Inactive";
            lblIsDetained.Text = licenseObj.IsDetained ? "Yes" : "No";
            // Formatting for status labels
            lblIsActive.ForeColor = licenseObj.IsActive ? Color.Green : Color.Red;
            lblIsDetained.ForeColor = licenseObj.IsDetained ? Color.Red : Color.Green;
        }
    }
}
