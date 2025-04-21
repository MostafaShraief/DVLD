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

namespace DVLD.DVLD_System.International_License
{
    public partial class ucInternationalLicense : System.Windows.Forms.UserControl
    {
        public ucInternationalLicense()
        {
            InitializeComponent();
        }

        clsInternationalLicenses_BLL internationalLicenseObj;

        public void SetInternationalLicenseObject(clsInternationalLicenses_BLL InternationalLicenseObj)
        {
            if (InternationalLicenseObj != null && InternationalLicenseObj.InternationalLicenseID != -1)
            {
                internationalLicenseObj = InternationalLicenseObj;
                FillInfo();
            }
        }

        public void SetInternationalLicenseId(int InternationalLicenseId)
        {
            clsInternationalLicenses_BLL InternationalLicenseObj = 
                clsInternationalLicenses_BLL.FindDetailsByInternationalLicenseID(InternationalLicenseId);
            SetInternationalLicenseObject(InternationalLicenseObj);
        }

        public void SetLocalLicenseId(int LocalLicenseID)
        {
            clsInternationalLicenses_BLL InternationalLicenseObj =
                clsInternationalLicenses_BLL.FindSammurizedByLicenseID(LocalLicenseID);
            SetInternationalLicenseObject(InternationalLicenseObj);
        }

        public void SetApplicationId(int ApplicationId)
        {
            clsInternationalLicenses_BLL InternationalLicenseObj =
                clsInternationalLicenses_BLL.FindSammurizedByApplicationID(ApplicationId);
            SetInternationalLicenseObject(InternationalLicenseObj);
        }

        void FillInfo()
        {
            lblInternationalLicenseID.Text = internationalLicenseObj.InternationalLicenseID.ToString();
            lblApplicationID.Text = internationalLicenseObj.ApplicationID.ToString();
            lblLocalLicenseID.Text = internationalLicenseObj.LicenseID.ToString();
            lblApplicationDate.Text = internationalLicenseObj.IssueDate.ToString("yyyy-MM-dd");
            lblExpirationDate.Text = internationalLicenseObj.ExpirationDate.ToString("yyyy-MM-dd");
            lblIsActive.Text = internationalLicenseObj.IsActive ? "Yes" : "No";
            lblCreatedByValue.Text = internationalLicenseObj.CreatedByUserID.ToString();
            lblCreatedDateValue.Text = internationalLicenseObj.ApplicationCreatedDate.ToString("yyyy-MM-dd");
            lblFeesValue.Text = internationalLicenseObj.Fees.ToString();
        }

        public void ResetDeffault()
        {
            lblFeesValue.Text = 
                clsApplicationType_BLL.GetApplicationTypeFees((int)clsGlobal.enApplicationType.NewInternational).ToString();
            lblApplicationID.Text = lblInternationalLicenseID.Text = lblLocalLicenseID.Text = lblIsActive.Text = "-1";
            lblCreatedByValue.Text = lblCreatedDateValue.Text = lblApplicationDate.Text = lblExpirationDate.Text = "None";
        }
    }
}
