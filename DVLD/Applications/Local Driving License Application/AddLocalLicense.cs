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

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class AddLocalLicense : Form
    {
        public AddLocalLicense()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Add/Edit Local License");
        }

        public void EditMode(int LocalLicenseId)
        {
            clsLocalDrivingLicenseApplication_BLL localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication_BLL.Find(LocalLicenseId);
            ucAddLocalLicense1.EditMode(localDrivingLicenseApplication);
        }
    }
}
