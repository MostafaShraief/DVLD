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
    public partial class ucTitleScreen : System.Windows.Forms.UserControl
    {
        public ucTitleScreen(string Title = "")
        {
            InitializeComponent();
            lblFormTitle.Text = Title;
        }

        public void ChangeTitle(string Title)
        {
            lblFormTitle.Text = Title;
        }

        public ucTitleScreen()
        {
            InitializeComponent();
        }
    }
}
