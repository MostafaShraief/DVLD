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

namespace DVLD.DVLD_System.Applications.Local_Driving_License_Application.User_Controls
{
    public partial class ucLocalLicenseInfoWithApplication : System.Windows.Forms.UserControl
    {
        public ucLocalLicenseInfoWithApplication()
        {
            InitializeComponent();
        }

        public void SetLocalLicenseId(int LocalLicenseId)
        {
            clsLocalDrivingLicenseApplication_BLL LocalLicenseObj = clsLocalDrivingLicenseApplication_BLL.Find(LocalLicenseId);

            SetLocalLicenseObject(LocalLicenseObj);
        }

        public void SetLocalLicenseObject(clsLocalDrivingLicenseApplication_BLL LocalLicenesObj)
        {
            if (LocalLicenesObj == null ||
                LocalLicenesObj.LocalDrivingLicenseApplicationID == -1)
                return;

            localLicenseObj = LocalLicenesObj;
            // fill local license info.
            lblLocalLicenseID.Text = localLicenseObj.LocalDrivingLicenseApplicationID.ToString();
            lblPassedTests.Text = localLicenseObj.PassedTest.ToString();
            lblLicenseClassType.Text = localLicenseObj.LicenseClassName;
            // fill ucapplication info.
            ucApplicationInfo1.SetApplicationID(localLicenseObj.ApplicationID);
        }

        public clsLocalDrivingLicenseApplication_BLL localLicenseObj;

        public clsLocalDrivingLicenseApplication_BLL GetLocalLicenseObject()
        {
            return localLicenseObj;
        }

        public clsApplications_BLL GetApplicationObj()
        {
            return ucApplicationInfo1.GetApplicationObj();
        }

        public void RefreshTestPassedCounter()
        {
            localLicenseObj.PassedTest = 
                clsLocalDrivingLicenseApplication_BLL.CountPassedTests(
                    localLicenseObj.LocalDrivingLicenseApplicationID);

            lblPassedTests.Text = localLicenseObj.PassedTest.ToString();
        }
    }
}
