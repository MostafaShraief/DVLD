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

namespace DVLD.DVLD_System.Detain_Licenses.User_Controls
{
    public partial class ucDetainLicenseInfo : System.Windows.Forms.UserControl
    {
        public ucDetainLicenseInfo()
        {
            InitializeComponent();
        }

        clsDetainedLicenses_BLL detainedLicenseObj = new clsDetainedLicenses_BLL();

        public void SetDetainID(int DetainID)
        {

        }

        public void SetDetainedObject(clsDetainedLicenses_BLL DetainLicenseObj)
        {
            if (DetainLicenseObj == null ||
                DetainLicenseObj.DetainID == -1)
                return;

            detainedLicenseObj = DetainLicenseObj;
            FillInfo();
        }

        void FillInfo()
        {
            // Detention Information
            lblDetainID.Text = detainedLicenseObj.DetainID.ToString();
            lblLicenseID.Text = detainedLicenseObj.LicenseID.ToString();
            lblDetainDate.Text = detainedLicenseObj.DetainDate.ToString("dd/MM/yyyy");

            // Fees Information
            float ApplicationFees;
            if (detainedLicenseObj.ReleaseApplicationID != null ||
                detainedLicenseObj.ReleaseApplicationID == -1)
                ApplicationFees = clsApplications_BLL.GetApplicationFees((int)detainedLicenseObj.ReleaseApplicationID);
            else
                ApplicationFees = clsApplicationType_BLL.GetApplicationTypeFees((int)clsGlobal.enApplicationType.ReleaseDetained);
            lblFineFees.Text = detainedLicenseObj.FineFees.ToString("C"); // Format as currency
            lblApplicationFees.Text = ApplicationFees.ToString("C"); // 30% application fee
            lblTotalFees.Text = (detainedLicenseObj.FineFees + (decimal)ApplicationFees).ToString("C"); // Total fee

            // Release Information
            lblReleaseApplicationID.Text = detainedLicenseObj.ReleaseApplicationID?.ToString() ?? "N/A";

            // Created By Information
            lblCreatedByValue.Text = clsUsers_BLL.FindByUserID(detainedLicenseObj.CreatedByUserID).UserName;
        }
    }
}
