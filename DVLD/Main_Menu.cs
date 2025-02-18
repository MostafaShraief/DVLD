using DVLD.Manage_People;
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
        DVLD _mainForm = clsGlobal.MainForm;

        public Main_Menu()
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Main Menu");
        }

        void OpenURL(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void btnOpenURL_Click(object sender, EventArgs e)
        {
            OpenURL((sender as Guna2Button).Tag.ToString());
        }

        private void lblManagePeople_Click(object sender, EventArgs e)
        {
            _mainForm.PushNewForm(new ManagePeople(_mainForm));
        }
    }
}
