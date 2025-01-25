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
            {
                panel.Controls[0].Dispose();
                panel.Controls.Clear();
            }

            panel.Enabled = true;
            if (form != null)
            {
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                panel.Controls.Add(form);
                form.Show();
            }
        }

        private void PushForm(Form frm)
        {
            if (frm == null)
                return;

            stkForms.Push(frm);
            LoadForm(stkForms.First(), main_panel);

            if (stkForms.Count > 1)
                btnBack.Enabled = true;
        }

        private void PopForm()
        {
            stkForms.Pop();

            byte count = (Byte)stkForms.Count;

            if (count > 0)
                LoadForm(stkForms.First(), main_panel);
            if (count <= 0)
                btnBack.Enabled = false;
        }
    }
}
