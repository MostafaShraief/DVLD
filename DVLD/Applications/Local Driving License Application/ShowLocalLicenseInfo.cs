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
    public partial class ShowLocalLicenseInfo : Form
    {
        public ShowLocalLicenseInfo()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Local License Info");
        }

        public void GetLocalLicenseId(int LocalLicenseId) =>
            ucLocalLicenseInfo1.GetLocalLicenseId(LocalLicenseId);
    }
}
