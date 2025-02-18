using DVLD_BLL;
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
    public partial class ucUserInfo : System.Windows.Forms.UserControl
    {
        public ucUserInfo()
        {
            InitializeComponent();
            user = new clsUsers_BLL();
            ucPersonInfo1.HideDeleteButton();
            ResetUserInfo();
        }

        clsUsers_BLL user;
        bool ShowDeleteButton = true;

        public void HideDeleteButton() =>
            ShowDeleteButton = false;

        void ResetUserInfo()
        {
            user = new clsUsers_BLL();
            btnEditUser.Visible = false;
            btnDeleteUser.Visible = false;
            lblUserID.Text = "???";
            lblUserName.Text = "Unkown";
            cbIsActive.Checked = false;
            ucPersonInfo1.ResetPersonInfo();
        }

        void FillUserInfo()
        {
            if (user == null)
                user = new clsUsers_BLL();
            if (user.UserID != -1)
            {
                btnEditUser.Visible = true;
                btnDeleteUser.Visible = ShowDeleteButton;
            }

            lblUserID.Text = user.UserID.ToString();
            lblUserName.Text = user.UserName.ToString();
            cbIsActive.Checked = user.IsActive;
            ucPersonInfo1.GetPersonID(user.PersonID);
        }

        public void GetUserID(int UserID)
        {
            if (UserID != -1 && clsUsers_BLL.IsUserExist(UserID))
            {
                user = clsUsers_BLL.FindByUserID(UserID);
                FillUserInfo();
            }
        }

        public void GetUserObject(clsUsers_BLL user)
        {
            if (user != null && user.UserID != -1)
            {
                this.user = user;
                FillUserInfo();
            }
            else
                ResetUserInfo();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (user != null && user.UserID != -1)
            {
                AddEditUser addEditUser = new AddEditUser();
                addEditUser.GetUserObject(user);
                addEditUser.UserLinker += GetUserObject;
                clsGlobal.MainForm.PushNewForm(addEditUser);
            }
            else
                MessageBox.Show("Please choose a user to edit its info.",
                    "No Selected User", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (clsUtility.clsForms.DeleteUser(user.UserID))
                ResetUserInfo();
        }

        private void cbIsActive_Click(object sender, EventArgs e)
        {
            cbIsActive.Checked = user.IsActive;
        }

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            cbIsActive.Checked = user.IsActive;
        }
    }
}
