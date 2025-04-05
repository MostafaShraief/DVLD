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

namespace DVLD.Applications
{
    public partial class EditApplicationType : Form
    {
        public EditApplicationType(int ID)
        {
            InitializeComponent();
            ucTopBar1.ChangeTitle("Edit Application Type");
            ucTopBar1.delClose += () => this.Close();
            ucTopBar1.delMinimize += () => this.WindowState = FormWindowState.Minimized;
            ApplicationTypeObject = clsApplicationType_BLL.Find(ID);
            FillData();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        void FillData()
        {
            if (ApplicationTypeObject == null)
                return;

            lblID.Text = ApplicationTypeObject.ApplicationTypeID.ToString();
            tbTitle.Text = ApplicationTypeObject.ApplicationTypeTitle;
            tbFees.Text = ApplicationTypeObject.ApplicationFees.ToString();
        }

        clsApplicationType_BLL ApplicationTypeObject;

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.InputValidator.ValidateKeyPress(sender, e,
                clsUtility.InputValidator.ValidationType.OnlyNumbers, 
                errorProvider);
        }

        private void tbTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.InputValidator.ValidateKeyPress(sender, e,
                clsUtility.InputValidator.ValidationType.OnlyLetters, 
                errorProvider, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplicationTypeObject.ApplicationTypeTitle = tbTitle.Text;

            if (!string.IsNullOrEmpty(tbFees.Text) && float.TryParse(tbFees.Text, out float fees))
                ApplicationTypeObject.ApplicationFees = fees;

            if (ApplicationTypeObject.UpdateApplicationType())
                MessageBox.Show("Data saved successfuly", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Data not saved, check data enterd and try again.", "Failed To Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditApplicationType_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
    }
}
