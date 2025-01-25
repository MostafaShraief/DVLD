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
        public ManagePeople()
        {
            InitializeComponent();
        }

        public delegate void delLinker();

        public event delLinker Linker;

        private void btnListPeople_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Show list of people in a table with all details," +
                " you can filter the table and sort any column," +
                " or right click on specific record to show fast context menu.";
        }

        private void btnAddPerson_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Add person on DVLD system with own info like name, national number, gender and etc.";
        }

        private void btnFindPerson_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Find any person on the system by person ID or" +
                " national number of the person.";
        }

        private void btnEditPerson_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Find the person then edit all details directly.";
        }

        private void btnRemovePerson_MouseHover(object sender, EventArgs e)
        {
            lblDescription.Text = "Remove person from the system at all, " +
                "the person who have any driving license or linked with at least" +
                " one user can not removed!";
        }
    }
}
