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

namespace DVLD.DVLD_System.Applications.Local_Driving_License_Application.User_Controls
{
    public partial class ucFindLicense : System.Windows.Forms.UserControl
    {
        public ucFindLicense()
        {
            InitializeComponent();
        }

        public delegate void delLicenseId(int Id);
        public delLicenseId GetLicenseIdLinker;

        int LicenseId;

        void _Find()
        {
            int.TryParse(tbFind.Text, out LicenseId);

            if (clsLicenses_BLL.IsLicenseExist(LicenseId))
            {
                if (GetLicenseIdLinker != null)
                    GetLicenseIdLinker(LicenseId);
            }
            else
                MessageBox.Show("License not found", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _Find();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _Find();
        }
    }
}
