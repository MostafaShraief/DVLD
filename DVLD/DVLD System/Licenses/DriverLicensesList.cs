using DVLD.Manage_People;
using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Licenses
{
    public partial class DriverLicensesList : Form
    {
        public DriverLicensesList()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Driver Licenses");
        }

        public bool GetDriverId(int DriverId)
        {
            this.DriverId = DriverId;
            clsDrivers_BLL driverObj = clsDrivers_BLL.FindByDriverID(DriverId);

            if (driverObj == null)
            {
                MessageBox.Show($"{Person.GetFullName()} is not a driver yet.", "Person is not driver",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Person = clsPeople_BLL.Find(driverObj.PersonID);
            lnklblPersonInfo.Text = $"Show {Person.GetFullName()} info";
            
            rbLocal.Checked = true;
            return true;
        }

        public bool GetPersonId(int PersonId)
        {
            Person = clsPeople_BLL.Find(PersonId);

            if (Person == null)
                return false;

            lnklblPersonInfo.Text = $"Show {Person.GetFullName()} info";

            clsDrivers_BLL driverObj = clsDrivers_BLL.FindByPersonID(Person.PersonID);

            if (driverObj == null)
            {
                MessageBox.Show($"{Person.GetFullName()} is not a driver yet.", "Person is not driver",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DriverId = driverObj.DriverID;
            rbLocal.Checked = true;
            return true;
        }

        public bool GetNationalNo(string NationalNo)
        {
            Person = clsPeople_BLL.Find(NationalNo);

            if (Person == null)
                return false;

            lnklblPersonInfo.Text = $"Show {Person.GetFullName()} info";

            clsDrivers_BLL driverObj = clsDrivers_BLL.FindByPersonID(Person.PersonID);

            if (driverObj == null)
            {
                MessageBox.Show($"{Person.GetFullName()} is not a driver yet.", "Person is not driver",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DriverId = driverObj.DriverID;
            rbLocal.Checked = true;
            return true;
        }

        clsPeople_BLL Person;

        int DriverId = -1;

        DataTable getLocalLicenseByDriverId()
        {
            return clsLicenses_BLL.GetLicensesByDriverID(DriverId);
        }

        void SwitchToLocal()
        {
            List<string> Ids = new List<string>()
            {
                "Lic.ID", "App.ID"
            };

            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>()
            {
                { "Is Active", new List<string> { "0", "1"} }
            };

            ucList1.FillListObject(getLocalLicenseByDriverId, Ids, keyValuePairs, null);
        }

        DataTable getInternationalLicenseByDriverId()
        {
            return clsInternationalLicenses_BLL.GetInternationalLicensesByDriverID(DriverId);
        }


        void SwitchToInternational()
        {
            List<string> Ids = new List<string>()
            {
                "International License ID", "Application ID", "Local License ID"
            };

            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>()
            {
                { "Is Active", new List<string> { "0", "1"} }
            };

            ucList1.FillListObject(getInternationalLicenseByDriverId, Ids, keyValuePairs, null);
        }

        private void rbLocal_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as Guna2RadioButton).Checked)
                SwitchToLocal();
        }

        private void rbInternational_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as Guna2RadioButton).Checked)
                SwitchToInternational();
        }

        private void lnklblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonInfo showPersonInfo = new ShowPersonInfo();
            showPersonInfo.GetPerson(Person);
            clsGlobal.MainForm.PushNewForm(showPersonInfo);
        }
    }
}
