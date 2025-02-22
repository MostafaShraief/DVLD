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

namespace DVLD
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Login");
            tbPassword.UseSystemPasswordChar = true;
            tbUserName.Focus();
        }

        clsUsers_BLL user;

        void Login()
        {
            if (String.IsNullOrEmpty(tbUserName.Text) || 
                String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserName.Focus();
                return;
            }

            user = clsUsers_BLL.FindByUserName(tbUserName.Text);

            if (user != null && user.CheckPassword(tbPassword.Text))
            {
                if (!user.IsActive)
                {
                    MessageBox.Show("This user is not active, " +
                        "contact your admin to activate it and try again.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Hide();
                DVLD dVLD = new DVLD();
                dVLD.user = user;
                dVLD.FormClosed += (s, args) => this.Close(); // Close the login form when the main form is closed
                dVLD.Show();
            }
            else
                MessageBox.Show("Invalid username or password.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tbUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                Login();
        }

        private void icbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Guna2ImageCheckBox icb)
                tbPassword.UseSystemPasswordChar = !icb.Checked;
            tbPassword.Focus();
        }

        void NextControl()
        {
            Control currentControl = this.ActiveControl;
            this.SelectNextControl(currentControl, true, true, true, true);
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NextControl();
        }
    }
}
