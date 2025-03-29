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

namespace DVLD.Manage_Users.User_Controls
{
    public partial class ucFindAndShowUserInfo : System.Windows.Forms.UserControl
    {
        public ucFindAndShowUserInfo()
        {
            InitializeComponent();
            ucFindUser1.GetUserLinker += SendUserToShowUserInfo;
        }

        void SendUserToShowUserInfo(clsUsers_BLL user) =>
            ucUserInfo1.GetUserObject(user);

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.UserLinker += SendUserToShowUserInfo;
            clsGlobal.MainForm.PushNewForm(addEditUser);
        }
    }
}
