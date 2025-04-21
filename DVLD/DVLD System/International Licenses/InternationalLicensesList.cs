using DVLD.DVLD_System.International_License;
using DVLD.DVLD_System.Licenses;
using DVLD.Manage_People;
using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.International_Licenses
{
    public partial class InternationalLicensesList : Form
    {
        public InternationalLicensesList()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("International Licenses List");

            List<string> numericColumns = new List<string>()
            {
                "International License ID", "Application ID", "License ID", "Driver ID"
            };

            List<string> DateColumns = new List<string>()
            {
                "Issue Date",
                "Expiration Date"
            };

            List<string> boolColummns = new List<string>()
            {
                "Is Active"
            };

            ucList1.FillListObject(clsInternationalLicenses_BLL.GetAllSammurizedInternationicenses, numericColumns, null, cmsRow, DateColumns, boolColummns);
        }

        int GetInternationalLicenseID() =>
            (int)ucList1.GetFromSelectedRow(0);

        int GetDriverID() =>
            (int)ucList1.GetFromSelectedRow(2);

        int GetLicenseID() =>
            (int)ucList1.GetFromSelectedRow(3);

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = clsDrivers_BLL.GetPersonIDByDriverID(GetDriverID());
            ShowPersonInfo showPersonInfo = new ShowPersonInfo();
            showPersonInfo.GetPersonID(PersonId);
            clsGlobal.MainForm.PushNewForm(showPersonInfo);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = GetLicenseID();
            LicenseInfo licenseInfo = new LicenseInfo();
            licenseInfo.SetLicenseID(LicenseID);
            clsGlobal.MainForm.PushNewForm(licenseInfo);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverLicensesList driverLicensesList = new DriverLicensesList();
            driverLicensesList.GetDriverId(GetDriverID());
            clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            AddInternationalLicense addInternationalLicense = new AddInternationalLicense();
            clsGlobal.MainForm.PushNewForm(addInternationalLicense);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternationalLicenseInfo internationalLicenseInfo = new InternationalLicenseInfo();
            internationalLicenseInfo.SetInternationalLicenseId(GetInternationalLicenseID());
            internationalLicenseInfo.ShowDialog();
        }
    }
}
