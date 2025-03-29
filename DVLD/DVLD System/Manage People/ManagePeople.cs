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
    public partial class ManagePeople : Form
    {
        DVLD _mainForm = clsGlobal.MainForm;

        public ManagePeople(DVLD mainForm)
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Manage People");
            _mainForm = mainForm;
        }

        private void btnListPeople_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Show list of people in a table with all details," +
                " you can filter the table and sort any column," +
                " or right click on specific record to show fast context menu.";
        }

        private void btnAddPerson_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Add person on DVLD system with own info like " +
                "name, national number, gender and etc.";
        }

        private void btnFindPerson_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Find any person on the system by person ID or" +
                " national number of the person, then person info will be shown and " +
                "you can edit or delete person card directly.";
        }

        private void btnOption_MouseLeave(object sender, EventArgs e)
        {
            lblDescription.Text = "Hover on any option to show details.";
        }

        private void btnListPeople_Click(object sender, EventArgs e)
        {
            _mainForm.PushNewForm(new PeopleList(_mainForm));
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            _mainForm.PushNewForm(new AddEditPerson());
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            _mainForm.PushNewForm(new FindPerson(_mainForm));
        }
    }
}
