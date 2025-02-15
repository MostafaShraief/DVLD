using DVLD.Manage_People;
using DVLD.Manage_People.User_Controls;
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

namespace DVLD.Manage_Users.User_Controls
{
    public partial class ucAddEditUser : System.Windows.Forms.UserControl
    {
        DVLD _mainForm;

        public ucAddEditUser()
        {
            InitializeComponent();
            ucfindAndShowInfoPerson.LinkerGetPerson += FillPersonInfo;
            ucfindAndShowInfoPerson.HideDeleteButton();
            tbPassword.UseSystemPasswordChar =
                tbConfirmPassword.UseSystemPasswordChar = true;
            user = new clsUsers_BLL();
        }

        public void GetMainForm(DVLD mainForm)
        {
            _mainForm = mainForm;
            ucfindAndShowInfoPerson.GetMainFormObject(_mainForm);
        }

        clsPeople_BLL person;
        clsUsers_BLL user;

        void FillPersonInfo(clsPeople_BLL person)
        {
            this.person = person;
            if (person != null && person.PersonID != -1)
            {
                user.PersonID = person.PersonID;
                pnlUser.Visible = true;
                btnSave.Visible = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            AddEditPerson addEditPerson = new AddEditPerson(_mainForm);
            addEditPerson.GetPersonIDLinker += FillPersonInfo;
            _mainForm.PushNewForm(addEditPerson);
        }

        private void tbUserName_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbUserName.Text))
            {
                errorProvider.SetError(sender as Guna2TextBox, "");
                return;
            }

            if (clsUtility.IsValidUsernameOrPassword(tbUserName.Text, 5))
            {
                if (!clsUsers_BLL.IsUserExistByUserName(tbUserName.Text))
                    errorProvider.SetError(sender as Guna2TextBox, "");
                else
                    errorProvider.SetError(sender as Guna2TextBox, "User name already exist.");
            }
            else
                errorProvider.SetError(sender as Guna2TextBox, "User name must " +
                    "contain upper case and lower case letters and digits.");
        }

        void CheckConfirmPassword()
        {
            string input = tbConfirmPassword.Text;
            
            if (!String.IsNullOrEmpty(input) &&
                input == tbPassword.Text)
                errorProvider.SetError(tbConfirmPassword, "");
            else
                errorProvider.SetError(tbConfirmPassword, "Does not match.");
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            string input = tbPassword.Text;
            if (!String.IsNullOrEmpty(input) &&
                clsUtility.IsValidUsernameOrPassword(input, 8))
            {
                errorProvider.SetError(sender as Guna2TextBox, "");
                CheckConfirmPassword();
            }
            else
                errorProvider.SetError(sender as Guna2TextBox, "Password must " +
                    "contain upper case and lower case letters and digits.");
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            CheckConfirmPassword();
        }

        private void icbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Guna2ImageCheckBox icb)
                tbPassword.UseSystemPasswordChar = !icb.Checked;
        }

        private void icbConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Guna2ImageCheckBox icb)
                tbConfirmPassword.UseSystemPasswordChar = !icb.Checked;
        }

        void _EditMode()
        {
            lblUserID.Visible = pbPersonID.Visible = lblUserIDTitle.Visible = true;
            lblUserID.Text = user.PersonID.ToString();
            tbUserName.Text = user.UserName;
            cbIsActive.Checked = user.IsActive;
            ucfindAndShowInfoPerson.GetPersonID(user.PersonID);

            tbPassword.Text = string.Empty;
            tbConfirmPassword.Text = string.Empty;
            lblPassword.Text = "New Password";
            lblPassword.Font = new Font("Gadugi", 12, FontStyle.Bold);
        }

        void Save()
        {
            user.PersonID = person.PersonID;
            user.UserName = tbUserName.Text;
            user.SetPassword(tbPassword.Text);
            user.IsActive = cbIsActive.Checked;

            if (tbPassword.Text == tbConfirmPassword.Text && user.Save())
            {
                _EditMode();

                MessageBox.Show("User Saved Successfuly.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User Not Saved," +
                    " Please Check Data Intered And Try Again.", "Failed To Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
