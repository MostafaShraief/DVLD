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

namespace DVLD.Manage_People
{
    public partial class FindPerson : Form
    {
        DVLD _mainForm;

        public FindPerson(DVLD mainForm)
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Find Persoon");
            _mainForm = mainForm;
        }

        clsPeople_BLL person;

        void ShowPersonInfoForm()
        {
            ShowPersonInfo showPersonInfo = new ShowPersonInfo(_mainForm);
            showPersonInfo.GetPerson(person);
            _mainForm.PushNewForm(showPersonInfo);
        }

        void _Find()
        {
            if (rbNationalNumebr.Checked && clsPeople_BLL.IsPersonExist(tbFind.Text))
            {
                person = clsPeople_BLL.Find(tbFind.Text);
                ShowPersonInfoForm();
            }
            else if (rbID.Checked && int.TryParse(tbFind.Text, out int ID) && clsPeople_BLL.IsPersonExist(ID))
            {
                person = clsPeople_BLL.Find(ID);
                ShowPersonInfoForm();
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            _Find();
        }
    }
}
