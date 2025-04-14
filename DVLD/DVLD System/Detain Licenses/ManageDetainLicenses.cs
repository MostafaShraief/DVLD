using DVLD.DVLD_System.Applications.Detain_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Detain_Licenses
{
    public partial class ManageDetainLicenses : Form
    {
        public ManageDetainLicenses()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Manage Detain Licenses");
        }

        private void btnDetainLicensesList_Click(object sender, EventArgs e)
        {
            DetainedLicensesList detainedLicensesList = new DetainedLicensesList();
            clsGlobal.MainForm.PushNewForm(detainedLicensesList);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicense detainLicense = new DetainLicense();
            clsGlobal.MainForm.PushNewForm(detainLicense);
        }

        private void btnLocalLicense_MouseLeave(object sender, EventArgs e)
        {
            lblDescription.Text = "Hover on any option to show details.";
        }

        private void btnDetainLicensesList_MouseEnter(object sender, EventArgs e)
        {
            lblDescription.Text = "Show list of detain licenses that available in " +
                "the system, where you can show detain license or release license directly, " +
                "show person info, show license info and show person licenses history.";
        }

        private void btnDetainLicense_MouseEnter(object sender, EventArgs e)
        {
            lblDescription.Text = "Find license and enter fine fees then detain the license.";
        }
    }
}
