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
    public partial class AddUser : Form
    {
        DVLD _mainForm;

        public AddUser(DVLD mainForm)
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Add User");
            ucAddEditUser1.GetMainForm(mainForm);
            ucAddEditUser1.ChangeTitleLinker += ChangeTitle;
            _mainForm = mainForm;
        }

        void ChangeTitle(string Title) =>
            ucTitleScreen1.ChangeTitle(Title);
    }
}
