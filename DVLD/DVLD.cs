using DVLD.Manage_People;
using DVLD.Manage_Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            Main_Menu main_Menu = new Main_Menu(this);
            stackfroms.PushNewForm(main_Menu, main_panel);
            clsGlobal.MainForm = this;
        }

        clsStackForms stackfroms;

        internal void PushNewForm(Form frm)
        {
            if (stackfroms.PushNewForm(frm, main_panel))
            {
                if (stackfroms.FormsBackwardCount > 1)
                    btnBack.Enabled = true;

                    btnForward.Enabled = false;
            }
        }

        internal void PopForm()
        {
            if (stackfroms.PopForm(main_panel))
            {
                if (stackfroms.FormsBackwardCount <= 1)
                    btnBack.Enabled = false;

                btnForward.Enabled = Enabled;
            }
        }

        internal void PopFormForever()
        {
            if (stackfroms.PopFormForever(main_panel))
            {
                if (stackfroms.FormsBackwardCount <= 1)
                    btnBack.Enabled = false;

                btnForward.Enabled = Enabled;
            }
        }

        private void ForwardForm()
        {
            if (stackfroms.RestoreForm_Forwarding(main_panel))
            {
                if (stackfroms.FormsForwardCount == 0)
                    btnForward.Enabled = false;

                btnBack.Enabled = true;
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
    }
}
