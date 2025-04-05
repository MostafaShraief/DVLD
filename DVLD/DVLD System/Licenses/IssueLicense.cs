using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Licenses
{
    public partial class IssueLicense : Form
    {
        public IssueLicense()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Issue License");
        }

        public void SetLocalLicenseID(int LocalLicenseID)
        {
            ucIssueLicense1.SetLocalLicenseID(LocalLicenseID);
        }
    }
}
