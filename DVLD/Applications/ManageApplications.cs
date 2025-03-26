using DVLD.Applications.Test_Types;
using DVLD_BLL;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class ManageApplications : Form
    {
        public ManageApplications()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Applications");
        }

        private void btnOption_MouseLeave(object sender, EventArgs e) =>
            lblDescription.Text = "Hover on any option to show details.";


        private void btnListUsers_Click(object sender, EventArgs e)
        {
            clsGlobal.MainForm.PushNewForm(new ApplicationTypesList());
        }

        private void btnListUsers_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Show list of applications that available in " +
            "the system, where you can only edit them.";

        private void btnTestTypes_Click(object sender, EventArgs e)
        {
            clsGlobal.MainForm.PushNewForm(new TestTypesList());
        }

        private void btnTestTypes_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Show list of tests that available in " +
            "the system, where you can only edit them.";

        private void btnLocalLicense_Click(object sender, EventArgs e)
        {
            clsGlobal.MainForm.PushNewForm(new LocalDrivingLicenseApplicationList());
        }

        private void btnLocalLicense_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Show list of local licenses that available in " +
            "the system, where you can add or find license.";
    }
}
