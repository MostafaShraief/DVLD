using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Manage_People
{
    public partial class FindPerson : Form
    {
        public FindPerson()
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Find Persoon"); ;
        }

        clsPeople_BLL person;

        void _Find()
        {
            if (rbNationalNumebr.Checked && clsPeople_BLL.IsPersonExist(tbFind.Text))
            {
                person = clsPeople_BLL.Find(tbFind.Text);
            }
            else if (rbID.Checked && int.TryParse(tbFind.Text, out int ID) && clsPeople_BLL.IsPersonExist(ID))
            {
                person = clsPeople_BLL.Find(ID);
            }
            else
            {
                MessageBox.Show("Person Not Found", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _Find();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _Find();
        }
    }
}
