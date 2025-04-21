using DVLD.Manage_People;
using DVLD.Manage_People.User_Controls;
using DVLD.UserControl;
using DVLD_BLL;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
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
        DVLD _mainForm = clsGlobal.MainForm;

        public ucAddEditUser()
        {
            InitializeComponent();
            ucfindAndShowInfoPerson.LinkerGetPerson += FillPersonInfo;
            ucfindAndShowInfoPerson.HideDeleteButton();
            ucfindAndShowInfoPerson.HideAddButton();
            tbPassword.UseSystemPasswordChar =
                tbConfirmPassword.UseSystemPasswordChar = true;
            user = new clsUsers_BLL();
        }

        public void GetMainForm(DVLD mainForm)
        {
            _mainForm = mainForm;
            ucfindAndShowInfoPerson.GetMainFormObject(_mainForm);
        }

        public void GetUserObject(clsUsers_BLL user)
        {
            if (user == null || user.UserID == -1)
                _AddMode();
            else
            {
                this.user = user;
                _EditMode();
            }
        }

        public void GetUserID(int UserID)
        {
            if (UserID == -1 || clsUsers_BLL.IsUserExist(UserID) == false)
                _AddMode();
            else
            {
                this.user = clsUsers_BLL.FindByUserID(UserID);
                _EditMode();
            }
        }

        public delegate void delChangeTitle(string Title);
        public delChangeTitle ChangeTitleLinker;

        public delegate void delGetUser(clsUsers_BLL user);
        public event delGetUser UserLinker;

        clsUsers_BLL user;

        void FillPersonInfo(clsPeople_BLL person)
        {
            if (person == null || person.PersonID == -1)
                return;

            if (clsUsers_BLL.IsPersonIDAlreadyExist(person.PersonID, user.UserID))
            {
                ucfindAndShowInfoPerson.ResetData();
                user.PersonID = -1;
                pnlUser.Visible = false;
                btnSave.Visible = false;
                MessageBox.Show("Person is already a user in the system, please choose another",
                    "Person Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ucfindAndShowInfoPerson.person.PersonID != person.PersonID)
                    ucfindAndShowInfoPerson.GetPersonID(person.PersonID);
                user.PersonID = person.PersonID;
                pnlUser.Visible = true;
                btnSave.Visible = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            AddEditPerson addEditPerson = new AddEditPerson();
            addEditPerson.GetPersonObjectLinker += FillPersonInfo;
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
                if (!clsUsers_BLL.IsUserNameAlreadyExist(tbUserName.Text, user.UserID))
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

        void _AddMode()
        {
            if (ChangeTitleLinker != null)
                ChangeTitleLinker("Add User");
            user = new clsUsers_BLL();
            if (UserLinker != null)
                UserLinker(user);
            ucfindAndShowInfoPerson.GetPersonID(-1);
            btnDeleteUser.Visible = false;
            tbUserName.Text = tbPassword.Text = tbOldPassword.Text =
                tbConfirmPassword.Text = string.Empty;
            cbChangePassword.Visible = lblUserID.Visible = pbPersonID.Visible = lblUserIDTitle.Visible = 
                tbOldPassword.Visible = pbOldPassword.Visible = lblOldPassword.Visible = false;
            pnlUser.Visible = false;
            cbIsActive.Checked = false;
            btnSave.Visible = false;
            ucfindAndShowInfoPerson.EnableFindStatus(true);
        }

        void _EditMode()
        {
            if (ChangeTitleLinker != null)
                ChangeTitleLinker("Edit User");
            if (UserLinker != null)
                UserLinker(user);
            lblUserID.Visible = pbPersonID.Visible = lblUserIDTitle.Visible = true;
            lblUserID.Text = user.UserID.ToString();
            tbUserName.Text = user.UserName;
            cbIsActive.Checked = user.IsActive;
            ucfindAndShowInfoPerson.GetPersonID(user.PersonID);
            ucfindAndShowInfoPerson.EnableFindStatus(false);
            cbChangePassword.Visible = true;
            tbPassword.Text = tbOldPassword.Text =
                tbConfirmPassword.Text = string.Empty;
            btnSave.Visible = true;
            lblPassword.Text = "New Password";
            lblPassword.Font = new Font("Gadugi", 12, FontStyle.Bold);
            btnDeleteUser.Visible = true;
            pnlUser.Visible = true;
        }

        bool ChangePassword()
        {
            bool Ok = false;

            if (cbChangePassword.Visible == false && tbPassword.Text == tbConfirmPassword.Text)
                Ok = user.SetPassword(tbPassword.Text); // add mode: set new password
            else if (cbChangePassword.Visible && 
                cbChangePassword.Checked && 
                tbPassword.Text == tbConfirmPassword.Text) // edit mode: change password
                Ok = user.ChangePassword(tbPassword.Text, tbOldPassword.    Text);
            else
                Ok = true; // edit mode: don`t change password.

            return Ok;
        }

        void Save()
        {
            if (ChangePassword() == false)
            {
                if (String.IsNullOrEmpty(tbPassword.Text))
                    MessageBox.Show("Password field is empty",
                        "Password Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (tbPassword.Text != tbConfirmPassword.Text)
                    MessageBox.Show("Password is not match confirm password",
                        "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbChangePassword.Visible)
                    MessageBox.Show("Old password is not correct!",
                        "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.PersonID = ucfindAndShowInfoPerson.SendPerson().PersonID;
            user.UserName = tbUserName.Text;
            user.IsActive = cbIsActive.Checked;

            if (user.Save())
            {
                _EditMode();

                if (user.UserID == clsGlobal.user.UserID)
                    clsGlobal.user = user;

                MessageBox.Show("User Saved Successfuly.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User Not Saved," +
                    " Please Check Data entered And Try Again.", "Failed To Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) => Save();

        private void cbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChangePassword.Visible)
                pbPassword.Visible = pbConfirmPassword.Visible = pbOldPassword.Visible =
                    tbPassword.Visible = tbConfirmPassword.Visible = tbOldPassword.Visible =
                    lblPassword.Visible = lblConfirm.Visible = lblOldPassword.Visible =
                    icbPassword.Visible = icbConfirmPassword.Visible = cbChangePassword.Checked;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (clsUtility.clsForms.DeleteUser(user.UserID))
            {

                if (user.UserID == clsGlobal.user.UserID)
                    clsGlobal.MainForm.Logout();

                _AddMode();
            }
        }
    }
}
