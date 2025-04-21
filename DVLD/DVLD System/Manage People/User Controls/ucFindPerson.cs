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

namespace DVLD.Manage_People.User_Controls
{
    public partial class ucFindPerson : System.Windows.Forms.UserControl
    {
        DVLD _mainForm = clsGlobal.MainForm;

        public ucFindPerson()
        {
            InitializeComponent();
        }
        public void GetMainFormObject(DVLD mainForm) =>
            _mainForm = mainForm;

        clsPeople_BLL person;

        public delegate void deLinker(clsPeople_BLL person);
        public deLinker Linker;

        void ShowPersonInfoForm(clsPeople_BLL person) => Linker(person);

        void _Find()
        {
            if (rbNationalNumebr.Checked && clsPeople_BLL.IsPersonExist(tbFind.Text))
            {
                person = clsPeople_BLL.Find(tbFind.Text);
                ShowPersonInfoForm(person);
            }
            else if (rbID.Checked && int.TryParse(tbFind.Text, out int ID) && clsPeople_BLL.IsPersonExist(ID))
            {
                person = clsPeople_BLL.Find(ID);
                ShowPersonInfoForm(person);
            }
            else
            {
                MessageBox.Show("Person Not Found", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _Find();
            }
        }

        private void btnFind_Click(object sender, EventArgs e) => _Find();

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbID.Checked)
                clsUtility.InputValidator.ValidateKeyPress(sender, e, clsUtility.InputValidator.ValidationType.OnlyNumbers, errorProvider);
        }
    }
}
