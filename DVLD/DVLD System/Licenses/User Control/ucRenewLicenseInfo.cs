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
    public partial class ucRenewLicenseInfo : System.Windows.Forms.UserControl
    {
        public ucRenewLicenseInfo()
        {
            InitializeComponent();
        }

        clsLicenses_BLL newLicenseObj;
        clsLicenses_BLL oldLicenseObj;

        void SetDefaultFees()
        {
            float applicationFees = clsApplicationType_BLL.GetApplicationTypeFees((int)clsGlobal.ApplicationType.RenewDrivingLicenseService);
            float licenseFees = clsLicenses_BLL.GetRenewLicenseFees();
            lblApplicationFees.Text = applicationFees.ToString();
            lblLicenseFees.Text = licenseFees.ToString();
            lblTotalFees.Text = (applicationFees + licenseFees).ToString();
        }

        void SetDefaultInfo()
        {
            lblApplicationDate.Text = lblExpirationDate.Text = lblIssueDate.Text = lblCreatedByValue.Text = "None";
            tbNote.Text = "";
            lblRenewApplicationId.Text = lblNewLicenseId.Text = "-1";
        }

        public void SetLicensesId(int OldLicenseId, int NewLicenseId)
        {
            clsLicenses_BLL OldLicenseObj = clsLicenses_BLL.Find(OldLicenseId);
            clsLicenses_BLL NewLicenseObj = clsLicenses_BLL.Find(NewLicenseId);
            SetLicensesObject(OldLicenseObj, NewLicenseObj);
        }

        public void SetLicensesObject(clsLicenses_BLL OldLicenseObj, clsLicenses_BLL NewLicenseObj)
        {
            if (OldLicenseObj != null && OldLicenseObj.LicenseID != -1)
            {
                oldLicenseObj = OldLicenseObj;
                FillOldLicenseInfo();
            }

            if (NewLicenseObj != null && NewLicenseObj.LicenseID != -1)
            {
                newLicenseObj = NewLicenseObj;
                FillNewLicenseInfo();
            }
            else
            {
                SetDefaultFees();
                SetDefaultInfo();
            }
        }

        void FillOldLicenseInfo()
        {
            lblOldLicenseID.Text = oldLicenseObj.LicenseID.ToString();
        }

        void FillNewLicenseInfo()
        {
            // Application Information
            lblRenewApplicationId.Text = newLicenseObj.ApplicationID.ToString();
            lblApplicationDate.Text = newLicenseObj.IssueDate.ToShortDateString();

            // License Information
            lblNewLicenseId.Text = newLicenseObj.LicenseID.ToString();
            lblIssueDate.Text = newLicenseObj.IssueDate.ToShortDateString();
            lblExpirationDate.Text = newLicenseObj.ExpirationDate.ToShortDateString();
            lblCreatedByValue.Text = clsUsers_BLL.FindByUserID(newLicenseObj.CreatedByUserID).UserName;

            // Fees Information
            float applicationFees = clsApplications_BLL.GetApplicationFees(newLicenseObj.ApplicationID);
            lblApplicationFees.Text = applicationFees.ToString();
            lblLicenseFees.Text = newLicenseObj.PaidFees.ToString();
            lblTotalFees.Text = (applicationFees + newLicenseObj.PaidFees).ToString();
        }
    }
}
