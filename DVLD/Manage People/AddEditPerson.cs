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
    public partial class AddEditPerson : Form
    {
        DVLD _mainForm;

        public AddEditPerson(DVLD mainForm, clsPeople_BLL person = null)
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Add Person");
            _mainForm = mainForm;

            if (person != null)
                ucAddPerson1.GetPerson(person);
        }
    }
}
