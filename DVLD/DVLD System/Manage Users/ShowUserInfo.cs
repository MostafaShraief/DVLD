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

namespace DVLD.Manage_Users
{
    public partial class ShowUserInfo : Form
    {
        public ShowUserInfo()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("User Info");
        }

        public void GetUserID(int UserID) =>
            ucUserInfo1.GetUserID(UserID);

        public void GetUserObject(clsUsers_BLL user) =>
            ucUserInfo1.GetUserObject(user);
    }
}
