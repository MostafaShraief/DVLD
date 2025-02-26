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
    public partial class EditTestType : Form
    {
        public EditTestType(int ID)
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Edit Test Type");
            TestTypeObject = clsTestTypes_BLL.Find(ID);
            FillData();
        }

        void FillData()
        {
            if (TestTypeObject == null)
                return;

            lblID.Text = TestTypeObject.TestTypeID.ToString();
            tbTitle.Text = TestTypeObject.TestTypeTitle;
            tbDescription.Text = TestTypeObject.TestTypeDescription;
            tbFees.Text = TestTypeObject.TestTypeFees.ToString();
        }

        clsTestTypes_BLL TestTypeObject;

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
            TestTypeObject.TestTypeTitle = tbTitle.Text;
            TestTypeObject.TestTypeDescription = tbDescription.Text;

            if (!string.IsNullOrEmpty(tbFees.Text) && float.TryParse(tbFees.Text, out float fees))
                TestTypeObject.TestTypeFees = fees;

            if (TestTypeObject.Save())
                MessageBox.Show("Data saved successfuly", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Data not saved, check data enterd and try again.", "Failed To Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
