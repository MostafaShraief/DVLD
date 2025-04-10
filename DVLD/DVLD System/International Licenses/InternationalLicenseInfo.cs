using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.International_Licenses
{
    public partial class InternationalLicenseInfo : Form
    {
        public InternationalLicenseInfo()
        {
            InitializeComponent();
            ucTopBar1.ChangeTitle("International License Info");
            ucTopBar1.delClose += () => this.Close();
            ucTopBar1.delMinimize += () => this.WindowState = FormWindowState.Minimized;
            guna2ShadowForm1.SetShadowForm(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        clsInternationalLicenses_BLL internationalLicenseObj;

        public void SetInternationalLicenseId(int InernationalLicenseId)
        {
            internationalLicenseObj = 
                clsInternationalLicenses_BLL.FindDetailsByInternationalLicenseID(InernationalLicenseId);
            ucInternationalLicenseInfo1.SetInternationalLicenseObject(internationalLicenseObj);
        }

        public void SetInternationalLicenseObj(clsInternationalLicenses_BLL InternationalLicenseObj)
        {
            internationalLicenseObj = InternationalLicenseObj;
            ucInternationalLicenseInfo1.SetInternationalLicenseObject(InternationalLicenseObj);
        }
    }
}
