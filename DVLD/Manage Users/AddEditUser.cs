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

namespace DVLD.Manage_Users
{
    public partial class AddEditUser : Form
    {
        DVLD _mainForm;

        public AddEditUser()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Add User");
            _mainForm = clsGlobal.MainForm;
            ucAddEditUser1.GetMainForm(_mainForm);
            ucAddEditUser1.ChangeTitleLinker += ChangeTitle;
        }

        public delegate void delGetUser(clsUsers_BLL user);
        public event delGetUser UserLinker;

        public void GetUserObject(clsUsers_BLL user) =>
            ucAddEditUser1.GetUserObject(user);

        public void GetUserID(int UserID) =>
            ucAddEditUser1.GetUserID(UserID);

        void ChangeTitle(string Title) =>
            ucTitleScreen1.ChangeTitle(Title);

        void GetUserLinker(clsUsers_BLL user)
        {
            if (UserLinker != null)
                UserLinker(user);
        }
    }
}
