using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User_Controls
{
    public partial class ucTopBar : System.Windows.Forms.UserControl
    {
        public ucTopBar()
        {
            InitializeComponent();
        }

        public void ChangeTitle(string Title)
        {
            lblTitle.Text = Title;
        }

        public delegate void Close();
        public Close delClose;

        public delegate void Minimize();
        public Minimize delMinimize;

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (delClose != null)
                delClose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (delMinimize != null)
                delMinimize();
        }
    }
}
