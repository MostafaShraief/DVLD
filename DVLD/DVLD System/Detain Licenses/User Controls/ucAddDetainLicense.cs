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

namespace DVLD.DVLD_System.Applications.Detain_Licenses.User_Controls
{
    public partial class ucAddDetainLicense : System.Windows.Forms.UserControl
    {
        public ucAddDetainLicense()
        {
            InitializeComponent();
            detainedLicenseObj = new clsDetainedLicenses_BLL();
        }

        public delegate void delDetainedLicenseObj(clsDetainedLicenses_BLL detainedLicenseObj);
        public delDetainedLicenseObj detainedLicenseObjLinker;
        clsDetainedLicenses_BLL detainedLicenseObj;

        void SwitchEnableStatus(bool IsEnabled) =>
            btnDetainLicense.Enabled = tbFees.Enabled = IsEnabled;

        bool CheckLicenseStatus()
        {
            if (detainedLicenseObj.LicenseID == -1)
            {
                MessageBox.Show("System detect invalid license id entered.", "Detain Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!clsLicenses_BLL.IsLicenseExist(detainedLicenseObj.LicenseID))
            {
                MessageBox.Show("License is not exist.", "Detain Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!clsLicenses_BLL.IsLicenseActiveAndNotDetained(detainedLicenseObj.LicenseID))
            {
                MessageBox.Show("License is not active.", "Detain Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void SetLicenseId(int LicenseId)
        {
            detainedLicenseObj.LicenseID = LicenseId;

            if (!CheckLicenseStatus())
            {
                SwitchEnableStatus(false);
                return;
            }

            lblLicenseID.Text = LicenseId.ToString();
            SwitchEnableStatus(true);
        }

        void FillInfo()
        {
            lblDetainID.Text = detainedLicenseObj.DetainID.ToString();
            lblLicenseID.Text = detainedLicenseObj.LicenseID.ToString();
            lblDetainDate.Text = detainedLicenseObj.DetainDate.ToString();
            lblCreatedByValue.Text = clsUsers_BLL.FindByUserID(detainedLicenseObj.CreatedByUserID).UserName;
            SwitchEnableStatus(false);
            tbFees.Text = detainedLicenseObj.FineFees.ToString();
            if (detainedLicenseObjLinker != null)
                detainedLicenseObjLinker(detainedLicenseObj);
        }

        public bool DetainLicense()
        {
            if (!CheckLicenseStatus())
                return false;

            float detainFees;

            if (!float.TryParse(tbFees.Text, out detainFees))
            {
                MessageBox.Show("Please enter valid fees amount to detain.", "Detain Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (detainFees < 0)
            {
                MessageBox.Show("Please enter positive fees amount and larger than 0.", "Detain Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            detainedLicenseObj.FineFees = (decimal)detainFees;
            detainedLicenseObj.CreatedByUserID = clsGlobal.user.UserID;

            bool IsDetained = false;

            if (detainedLicenseObj.Save())
            {
                MessageBox.Show("License has been detained successfully.", "Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsDetained = true;
                if (detainedLicenseObjLinker != null)
                    detainedLicenseObjLinker(detainedLicenseObj);
                detainedLicenseObj.DetainDate = DateTime.Now;
                FillInfo();
            }
            else
                MessageBox.Show("License was not detained, please check data entered", "Not Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            return IsDetained;
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to detain this license id = {detainedLicenseObj.LicenseID}?",
                "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                DetainLicense();
            else
                MessageBox.Show("Detain license has been canceled", "Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
