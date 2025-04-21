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

namespace DVLD.Applications.Test_Types
{
    public partial class TestTypesList : Form
    {
        public TestTypesList()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Test Types List");
            List<string> numericColumns = new List<string>()
            {
                "ID", "Fees"
            };
            ucList1.FillListObject(clsTestTypes_BLL.GetListOfTestTypes, numericColumns, null, cmsRow, null);
        }

        int GetIdFromSelectedRow() => ((int)ucList1.GetFromSelectedRow(0));

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTestType editTestType = new EditTestType(GetIdFromSelectedRow());
            editTestType.ShowDialog();
            ucList1.RefreshDataSet();
        }
    }
}
