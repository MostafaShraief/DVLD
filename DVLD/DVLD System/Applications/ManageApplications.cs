﻿using DVLD.Applications.Test_Types;
using DVLD.DVLD_System.Applications;
using DVLD.DVLD_System.Licenses;
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

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            RenewLicense renewLicense = new RenewLicense();
            clsGlobal.MainForm.PushNewForm(renewLicense);
        }

        private void btnRenewLicense_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Renew old license if it's expired with low cost.";

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            ReplaceLicense replaceLicense = new ReplaceLicense();
            clsGlobal.MainForm.PushNewForm(replaceLicense);
        }

        private void btnReplaceLicense_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Replace license that has been damaged or lost.";

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            ReleaseLicense releaseLicense = new ReleaseLicense();
            clsGlobal.MainForm.PushNewForm(releaseLicense);
        }

        private void btnReleaseLicense_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Release detained license service, enter license id then ask driver to " +
            "pay the fees then release it";
    }
}
