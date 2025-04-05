using DVLD_BLL;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class LoginScreen : Form
    {
        string Sep = "#//#";
        void FileLogin()
        {
            if (!File.Exists(clsGlobal.LoginFilePath))
                return;

            List<string> Data = File.ReadAllText(clsGlobal.LoginFilePath).Split(new[] { Sep }, StringSplitOptions.None).ToList();

            if (Data.Count == 2 && !String.IsNullOrEmpty(Data[0])
                && !String.IsNullOrEmpty(Data[1]))
                Login(Data[0], Data[1]);
        }

        public LoginScreen()
        {
            InitializeComponent();
            ucTopBar1.ChangeTitle("Login");
            ucTopBar1.delClose += () => this.Close();
            ucTopBar1.delMinimize += () => this.WindowState = FormWindowState.Minimized;
            tbPassword.UseSystemPasswordChar = true;
            tbUserName.Focus();
            this.Show();
            FileLogin();
        }

        clsUsers_BLL user;

        void SaveLogin(string UserName, string Password)
        {
            string Content = UserName + Sep + Password;
            File.WriteAllText(clsGlobal.LoginFilePath, Content);
        }

        void Login(string UserName, string Password)
        {
            if (String.IsNullOrEmpty(UserName) ||
                String.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please enter both username and password.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUserName.Focus();
                return;
            }

            user = clsUsers_BLL.FindByUserName(UserName);

            if (user != null && user.CheckPassword(Password))
            {
                if (!user.IsActive)
                {
                    MessageBox.Show("This user is not active, " +
                        "contact your admin to activate it and try again.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbRememberMe.Checked)
                    SaveLogin(tbUserName.Text, tbPassword.Text);

                this.Hide();
                DVLD dVLD = new DVLD();
                clsGlobal.user = user;
                dVLD.Show();
            }
            else
                MessageBox.Show("Invalid username or password.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            tbUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(tbUserName.Text, tbPassword.Text);
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
                Login(tbUserName.Text, tbPassword.Text);
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

        private void LoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ensures the entire application closes
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucTopBar1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
    }
}
