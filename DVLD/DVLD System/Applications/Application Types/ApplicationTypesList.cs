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

namespace DVLD.Applications
{
    public partial class ApplicationTypesList : Form
    {
        public ApplicationTypesList()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Application Types List");
            List<string> numericColumns = new List<string>()
            {
                "ID", "Fees"
            };
            ucList1.FillListObject(clsApplicationType_BLL.GetListOfApplicationTypes, numericColumns, null, cmsRow, null);
        }

        int GetIdFromSelectedRow() => ((int)ucList1.GetFromSelectedRow(0));

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditApplicationType applicationType = new EditApplicationType(GetIdFromSelectedRow());
            applicationType.ShowDialog();
            ucList1.RefreshDataSet();
        }
    }
}
