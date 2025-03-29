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

namespace DVLD.Applications.Local_Driving_License_Application.User_Controls
{
    public partial class ucLocalLicenseInfo : System.Windows.Forms.UserControl
    {
        public ucLocalLicenseInfo()
        {
            InitializeComponent();
        }

        clsLocalDrivingLicenseApplication_BLL localLicenseObj = null;

        public void GetLocalLicenseId(int LocalLicenseId)
        {
            localLicenseObj = clsLocalDrivingLicenseApplication_BLL.Find(LocalLicenseId);

            if (localLicenseObj != null)
            {
                FillLocalLicense();
                btnCancel.Visible = btnDelete.Visible = true;
            }
        }

        void FillLocalLicense()
        {
            lblLicenseClass.Text = clsGlobal.ConverLicenseClassEnumToString((clsGlobal.enLicencsesClasses)localLicenseObj.LicenseClassID);
            lblCreatedByValue.Text = clsUsers_BLL.FindByUserID(localLicenseObj.CreatedByUserID).UserName;
            lblDateValue.Text = localLicenseObj.ApplicationDate.ToString();
            lblFeesValue.Text = clsApplications_BLL.GetApplicationFees(localLicenseObj.ApplicationID).ToString();
            lblLocDrvLicAppValue.Text = localLicenseObj.LocalDrivingLicenseApplicationID.ToString();
            lblStatus.Text = ((clsGlobal.enApplicationStatus)localLicenseObj.Status).ToString();
            ucPersonInfo1.GetNationalNo(localLicenseObj.NationalNumber);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this local license?", "Delete",
        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MessageBox.Show("Local license has been deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsGlobal.MainForm.PopFormForever();
            }
            else
                MessageBox.Show("delete process has been canceled.", "Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this local license?", "Cancel",
        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK &&
        clsLocalDrivingLicenseApplication_BLL.CancelLocalLicenseOrder(localLicenseObj.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("Local license has been canceled.", "Delted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = clsGlobal.enApplicationStatus.Cancelled.ToString();
                btnCancel.Enabled = false;
            }
            else
                MessageBox.Show("cancel process has been terminated.", "Not Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
