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
    public partial class ucFindUser : System.Windows.Forms.UserControl
    {
        public ucFindUser()
        {
            InitializeComponent();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            tbFind.Text = string.Empty;
        }

        public delegate void delGetUser(clsUsers_BLL user);
        public delGetUser GetUserLinker;

        clsUsers_BLL user;

        bool ValidateFindTextBox()
        {
            if (rbUserID.Checked || rbPersonID.Checked &&
                (clsUtility.Characters.English.ValidateOnlyNumbers(tbFind.Text)))
            {
                errorProvider.SetError(tbFind, "Only numbers allowed");
                return false;
            }
            else if (rbUserID.Checked &&
                (clsUtility.Characters.English.ValidateLettersAndNumbers(tbFind.Text)))
            {
                errorProvider.SetError(tbFind, "Only English letters and numbers allowed");
                return false;
            }

            return true;
        }

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbUserID.Checked || rbPersonID.Checked)
                clsUtility.InputValidator.ValidateKeyPress(
                    sender, e, clsUtility.InputValidator.ValidationType.OnlyNumbers,
                    errorProvider);
            else if (rbUsername.Checked)
                clsUtility.InputValidator.ValidateKeyPress(
                    sender, e, clsUtility.InputValidator.ValidationType.LettersAndNumbers,
                    errorProvider);
        }

        void Search()
        {
            if (rbUserID.Checked && 
                int.TryParse(tbFind.Text, out int UserID) && 
                clsUsers_BLL.IsUserExist(UserID))
                user = clsUsers_BLL.FindByUserID(UserID);
            else if (rbPersonID.Checked &&
                int.TryParse(tbFind.Text, out int PersonID) &&
                clsUsers_BLL.IsUserExistByPersonID(PersonID))
                user = clsUsers_BLL.FindByPersonID(PersonID);
            else if (rbUsername.Checked &&
                clsUsers_BLL.IsUserExistByUserName(tbFind.Text))
                user = clsUsers_BLL.FindByUserName(tbFind.Text);
            else
                MessageBox.Show("User not found, check data intered again.", "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateFindTextBox())
                MessageBox.Show("Please inter only valide data", "Data Not Valid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            Search();
        }

    }
}
