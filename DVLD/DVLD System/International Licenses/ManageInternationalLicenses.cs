using DVLD.DVLD_System.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.International_Licenses
{
    public partial class ManageInternationalLicenses : Form
    {
        public ManageInternationalLicenses()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Manage International Licenses");
        }

        private void btnLocalLicense_Click(object sender, EventArgs e)
        {
            AddInternationalLicense internationalLicense = new AddInternationalLicense();
            clsGlobal.MainForm.PushNewForm(internationalLicense);
        }

        private void btnLocalLicense_MouseEnter(object sender, EventArgs e)
        {
            lblDescription.Text = "Issue an international license for specific existing license in the system.";
        }

        private void btnLocalLicense_MouseLeave(object sender, EventArgs e)
        {
            lblDescription.Text = "Hover on any option to show details.";
        }

        private void btnInternationalLicensesList_Click(object sender, EventArgs e)
        {
            InternationalLicensesList internationalLicensesList = new InternationalLicensesList();
            clsGlobal.MainForm.PushNewForm(internationalLicensesList);
        }

        private void btnInternationalLicensesList_MouseEnter(object sender, EventArgs e)
        {
            lblDescription.Text = "Show list of international licenses that available in " +
                "the system, where you can show person info, license or person license hisorty.";
        }
    }
}
