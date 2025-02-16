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
    public partial class ManageUsers : Form
    {
        DVLD _mainForm;

        public ManageUsers(DVLD mainForm)
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Manage Users");
            _mainForm = mainForm;
        }

        private void btnOption_MouseLeave(object sender, EventArgs e) =>
            lblDescription.Text = "Hover on any option to show details.";

        private void btnListUsers_MouseEnter(object sender, EventArgs e) =>
            lblDescription.Text = "Show list of users in a table with all details," +
                " you can filter the table and sort any column," +
                " or right click on specific record to show fast context menu.";

        private void btnListUsers_Click(object sender, EventArgs e) =>
            _mainForm.PushNewForm(new UsersList(_mainForm));

        private void btnAddUser_Click(object sender, EventArgs e) =>
            _mainForm.PushNewForm(new AddEditUser());
    }
}
