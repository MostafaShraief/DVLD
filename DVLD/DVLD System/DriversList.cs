using DVLD.DVLD_System.Licenses;
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

namespace DVLD.DVLD_System
{
    public partial class DriversList : Form
    {
        public DriversList()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Drivers");

            List<string> IdsColumns = new List<string>()
            {
                "Dirver ID", "Person ID", "Active Licenses"
            };

            ucList1.FillListObject(clsDrivers_BLL.GetAllDrivers, IdsColumns, null, cmsRow);
        }

        int GetDriverId()
        {
            object result = ucList1.GetFromSelectedRow(0);
            return (result == null) ? -1 : (int)result;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverLicensesList driverLicensesList = new DriverLicensesList();
            driverLicensesList.GetDriverId(GetDriverId());
            clsGlobal.MainForm.PushNewForm(driverLicensesList);
        }
    }
}
