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

namespace DVLD.Manage_Users
{
    public partial class ChangeUserPassword : Form
    {
        public ChangeUserPassword(int UserID)
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Change Password");
            user = clsUsers_BLL.FindByUserID(UserID);
            FillUserForm();
        }

        clsUsers_BLL user;

        void FillUserForm()
        {
            if (user != null && user.UserID != -1)
            {
                lblUserID.Text = user.UserID.ToString();
                lblUserName.Text = user.UserName.ToString();
            }
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

        bool ChangePassword()
        {
            bool Ok = false;

            if (tbPassword.Text == tbConfirmPassword.Text) // edit mode: change password
                Ok = user.ChangePassword(tbPassword.Text, tbOldPassword.Text);
            else
                Ok = false; // edit mode: don`t change password.

            return Ok;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ChangePassword())
            {
                if (user.Save())
                    MessageBox.Show("Password Changed Successfuly.", "Changed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("User Pasword Not Saved," +
                        " Please Check Data entered And Try Again.", "Failed To Save",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(tbPassword.Text))
                MessageBox.Show("Password field is empty",
                    "Password Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbPassword.Text != tbConfirmPassword.Text)
                MessageBox.Show("Password is not match confirm password",
                    "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Old password is not correct!",
                    "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
