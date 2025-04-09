using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.International_Licenses
{
    public partial class ucInternationalLicenseInfo : System.Windows.Forms.UserControl
    {
        public ucInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        clsInternationalLicenses_BLL internationalLicenseObj = new clsInternationalLicenses_BLL();

        public void SetInteernationalLicenseID(int InternationalLicenseId)
        {
            clsInternationalLicenses_BLL InternationalObj =
                clsInternationalLicenses_BLL.FindDetailsByInternationalLicenseID(InternationalLicenseId);

            SetInternationalLicenseObject(InternationalObj);
        }

        public void SetInternationalLicenseObject(clsInternationalLicenses_BLL InternationalLicenseObj)
        {
            if (InternationalLicenseObj == null || InternationalLicenseObj.InternationalLicenseID == -1)
                return;

            internationalLicenseObj = InternationalLicenseObj;
            FillData();
        }

        private void FillData()
        {
            lblInternationalLicenseID.Text = internationalLicenseObj.InternationalLicenseID.ToString();
            lblApplicationId.Text = internationalLicenseObj.ApplicationID.ToString();
            lblDriverID.Text = internationalLicenseObj.DriverID.ToString();
            lblLicenseId.Text = internationalLicenseObj.LicenseID.ToString();
            lblIssueDate.Text = internationalLicenseObj.IssueDate.ToString("yyyy-MM-dd");
            lblExpirationDate.Text = internationalLicenseObj.ExpirationDate.ToString("yyyy-MM-dd");
            lblIsActive.Text = internationalLicenseObj.IsActive ? "Yes" : "No";
            lblIsActive.ForeColor = lblIsActive.Text == "Yes" ? Color.Green : Color.Red;
            lblNationalNumber.Text = internationalLicenseObj.NationalNo;
            lblFullName.Text = internationalLicenseObj.FullName;
            lblDateOfBirth.Text = internationalLicenseObj.DateOfBirth.ToString("yyyy-MM-dd");
            lblGender.Text = internationalLicenseObj.Gender.ToString(); // Male or Female
            byte[] image = null;
            if (File.Exists(internationalLicenseObj.ImagePath))
                image = File.ReadAllBytes(internationalLicenseObj.ImagePath);

            pbProfileImage.Image = 
                clsGlobal.FillPersonImage(image, (clsPeople_BLL.enGender)internationalLicenseObj.Gender);
        }
    }
}
