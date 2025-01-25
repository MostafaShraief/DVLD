using Guna.UI2.WinForms;
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
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        void OpenURL(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void btnOpenURL_Click(object sender, EventArgs e)
        {
            OpenURL((sender as Guna2Button).Tag.ToString());
        }
    }
}
