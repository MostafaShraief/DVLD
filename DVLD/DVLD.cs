using DVLD.Manage_People;
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
    public partial class DVLD : Form
    {
        public DVLD()
        {
            InitializeComponent();
            PushForm(new Main_Menu());
        }

        private Stack<Form> stkForms = new Stack<Form>();

        private void LoadForm(Form form, Panel panel)
        {
            if (panel.Controls.Count > 0)
                panel.Controls.Clear();

            panel.Enabled = true;
            if (form != null)
            {
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                panel.Controls.Add(form);
                form.Focus();
                form.Show();
            }
        }

        private void PushForm(Form frm)
        {
            if (frm == null)
                return;

            if (stkForms.Count > 0 && frm.Tag == stkForms.First().Tag)
                return;

            stkForms.Push(frm);
            LoadForm(stkForms.First(), main_panel);

            if (stkForms.Count > 1)
                btnBack.Enabled = true;
        }

        private void PopForm()
        {
            byte count = (Byte)stkForms.Count;

            if (count == 0)
                return;

            stkForms.First().Dispose();
            stkForms.Pop();
            --count;

            if (count > 0)
                LoadForm(stkForms.First(), main_panel);
            if (count <= 1)
                btnBack.Enabled = false;
        }

        private void btnManagePeople_Click(object sender, EventArgs e)
        {
            PushForm(new ManagePeople());
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
    }
}
