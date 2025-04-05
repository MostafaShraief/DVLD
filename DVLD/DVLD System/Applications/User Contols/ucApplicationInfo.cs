using DVLD.Manage_People;
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

namespace DVLD.DVLD_System.Applications.User_Contols
{
    public partial class ucApplicationInfo : System.Windows.Forms.UserControl
    {
        public ucApplicationInfo()
        {
            InitializeComponent();
        }

        clsApplications_BLL applicationObj;

        public void SetApplicationID(int ApplicationID)
        {
            applicationObj = clsApplications_BLL.GetApplicationDetailsByID(ApplicationID);

            if (applicationObj != null)
                FillApplicationInfo();
        }

        public clsApplications_BLL GetApplicationObj()
        {
            return applicationObj;
        }

        void FillApplicationInfo()
        {
            // Application ID
            lblApplicationID.Text = applicationObj.ApplicationID.ToString();

            // Person Info (LinkLabel)
            lnklblPersonInfo.Text = applicationObj.FullName;

            // Application Date
            lblCreatedDateValue.Text = applicationObj.ApplicationDate.ToString("dd/MM/yyyy");

            // Application Type
            lblApplicationType.Text = applicationObj.ApplicationTypeTitle;

            // Application Status
            lblStatus.Text = applicationObj.ApplicationStatus;

            // Last Status Date
            lblLastStatusDate.Text = applicationObj.LastStatusDate.ToString("dd/MM/yyyy");

            // Paid Fees
            lblFeesValue.Text = applicationObj.PaidFees.ToString("0.00");

            // Created By User
            lblCreatedByValue.Text = applicationObj.CreatedByUserName;
        }

        private void lnklblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonInfo personInfo = new ShowPersonInfo();
            personInfo.GetPersonID(applicationObj.ApplicantPersonID);
            clsGlobal.MainForm.PushNewForm(personInfo);
        }
    }
}
