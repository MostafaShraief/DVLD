using DVLD.Applications;
using DVLD.DVLD_System;
using DVLD.DVLD_System.Detain_Licenses;
using DVLD.DVLD_System.International_Licenses;
using DVLD.Manage_People;
using DVLD.Manage_Users;
using DVLD.Manage_Users.User_Controls;
using DVLD.Properties;
using DVLD_BLL;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class DVLD : Form
    {
        public DVLD()
        {
            InitializeComponent();
            stackfroms = new clsStackForms();
            Main_Menu main_Menu = new Main_Menu();
            stackfroms.PushNewForm(main_Menu, main_panel);
            clsGlobal.MainForm = this;
        }

        clsStackForms stackfroms;

        internal void RefreshPerson()
        {
            if (clsGlobal.userPerson != null)
            {
                Image image = clsUtility.Image.ByteArrayToImage(clsGlobal.userPerson.ImageFile);

                if (image != null)
                    btnUserProfile.Image = image;
                else if (clsGlobal.userPerson.Gender == clsPeople_BLL.enGender.Male)
                    btnUserProfile.Image = Resources.Man;
                else if (clsGlobal.userPerson.Gender == clsPeople_BLL.enGender.Female)
                    btnUserProfile.Image = Resources.Woman;
            }
        }

        public void RefreshUserInfo()
        {
            btnUserProfile.Text = clsGlobal.user.UserName;
            RefreshPerson();
        }

        internal void PushNewForm(Form frm)
        {
            if (stackfroms.PushNewForm(frm, main_panel))
            {
                if (stackfroms.FormsBackwardCount > 1)
                {
                    btnBack.Enabled = true;
                    btnMainMenu.Enabled = true;
                }

                btnForward.Enabled = false;
            }
        }

        internal void PopForm()
        {
            if (stackfroms.PopForm(main_panel))
            {
                if (stackfroms.FormsBackwardCount <= 1)
                {
                    btnBack.Enabled = false;
                    btnMainMenu.Enabled = false;
                }

                btnForward.Enabled = Enabled;
            }
        }

        internal void PopFormForever()
        {
            if (stackfroms.PopFormForever(main_panel))
            {
                if (stackfroms.FormsForwardCount == 0)
                    btnForward.Enabled = false;

                if (stackfroms.FormsBackwardCount <= 1)
                {
                    btnBack.Enabled = false;
                    btnMainMenu.Enabled = false;
                }
            }
        }

        private void ForwardForm()
        {
            if (stackfroms.RestoreForm_Forwarding(main_panel))
            {
                if (stackfroms.FormsForwardCount == 0)
                    btnForward.Enabled = false;

                btnBack.Enabled = true;
                btnMainMenu.Enabled = true;
            }
        }

        private void btnManagePeople_Click(object sender, EventArgs e)
        {
            ManagePeople managePeople = new ManagePeople(this);
            PushNewForm(managePeople);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PopForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ForwardForm();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            PushNewForm(new ManageUsers(this));
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to back to " +
                "main menu? you can NOT BACK to previous opened tabs!", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.OK)
            {
                stackfroms.ClearForms();
                btnMainMenu.Enabled = btnForward.Enabled = btnBack.Enabled = false;
                PushNewForm(new Main_Menu());
            }
        }

        private void btnUserProfile_TextChanged(object sender, EventArgs e)
        {
            if (btnUserProfile.Text.Length > 10)
                btnUserProfile.Text = btnUserProfile.Text.Substring(0, 10) + "..";
        }

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            cmsRow.Show(1644, 52);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserInfo showUserInfo = new ShowUserInfo();
            if (clsGlobal.user != null)
                showUserInfo.GetUserID(clsGlobal.user.UserID);
            PushNewForm(showUserInfo);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            if (clsGlobal.user != null)
                addEditUser.GetUserID(clsGlobal.user.UserID);
            PushNewForm(addEditUser);
        }

        internal void Logout()
        {
            this.Hide();
            File.Delete(clsGlobal.LoginFilePath);
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void DVLD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ensures the entire application closes
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            PushNewForm(new ManageApplications());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PushNewForm(new DriversList());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PushNewForm(new ManageInternationalLicenses());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ManageDetainLicenses manageDetainLicenses = new ManageDetainLicenses();
            PushNewForm(manageDetainLicenses);
        }
    }
}
