using DVLD.DVLD_System.Detain_Licenses;
using DVLD.DVLD_System.Licenses;
using DVLD.Manage_People;
using DVLD.UserControl;
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

namespace DVLD.DVLD_System.Applications.Detain_Licenses
{
    public partial class DetainedLicensesList : Form
    {
        public DetainedLicensesList()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Detained Licenses List");

            List<string> Ids = new List<string>()
            {
                "D.ID", "L.ID", "Release App.ID"
            };

            ucList1.FillListObject(clsDetainedLicenses_BLL.GetAllDetainedLicenses, Ids, null, cmsRow);
        }

        int GetLicenseId() =>
            (int)ucList1.GetFromSelectedRow(1);

        int GetDetainId() =>
            (int)ucList1.GetFromSelectedRow(0);

        bool IsLicenseReleased() =>
            (bool)ucList1.GetFromSelectedRow(3);

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = clsDetainedLicenses_BLL.GetPersonIDByDetainID(GetDetainId());
            ShowPersonInfo PersonInfo = new ShowPersonInfo();
            PersonInfo.GetPersonID(PersonId);
            clsGlobal.MainForm.PushNewForm(PersonInfo);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseId = GetLicenseId();
            LicenseInfo licenseInfo = new LicenseInfo();
            licenseInfo.SetLicenseID(LicenseId);
            clsGlobal.MainForm.PushNewForm(licenseInfo);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverId;

            if (!int.TryParse(clsDetainedLicenses_BLL.GetDriverIdByDetainId(GetDetainId()).ToString(), out DriverId))
            {
                MessageBox.Show("Driver not found.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucList1.RefreshDataSet();
                return;
            }

            DriverLicensesList driverLicensesList = new DriverLicensesList();
            driverLicensesList.GetDriverId(DriverId);
            clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReleaseLicense releaseLicense = new ReleaseLicense();
            releaseLicense.SetLicenseID(GetLicenseId());
            clsGlobal.MainForm.PushNewForm(releaseLicense);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DetainLicense detainLicense = new DetainLicense();
            detainLicense.SetLicenseID(GetLicenseId());
            clsGlobal.MainForm.PushNewForm(detainLicense);
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            ReleaseLicense releaseLicense = new ReleaseLicense();
            clsGlobal.MainForm.PushNewForm(releaseLicense);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicense detainLicense = new DetainLicense();
            clsGlobal.MainForm.PushNewForm(detainLicense);
        }

        private void cmsRow_Opening(object sender, CancelEventArgs e)
        {
            if (IsLicenseReleased())
                cmsRow.Items[4].Visible = false; // hide release license.
            else
                cmsRow.Items[5].Visible = false; // hide detain license.
        }
    }
}
