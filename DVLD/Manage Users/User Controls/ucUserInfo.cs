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
        }

        clsUsers_BLL user;

        void ResetUserInfo()
        {
            user = new clsUsers_BLL();
            FillUserInfo();
        }

        void FillUserInfo()
        {
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
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.UserLinker += GetUserObject;
            clsGlobal.MainForm.PushNewForm(addEditUser);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (clsUtility.clsForms.DeleteUser(user.UserID))
                ResetUserInfo();
        }
    }
}
