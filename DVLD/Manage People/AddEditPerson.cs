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

        clsPeople_BLL person;

        public AddEditPerson()
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Person Card");
            _mainForm = clsGlobal.MainForm;
            ucAddPerson1.Linker += LinkerMethod;
            ucAddPerson1.GetPersonIDLinker += GetPersonLinker;
        }

        public void GetPersonID(int personID)
        {
            if (personID != -1)
                person = clsPeople_BLL.Find(personID);

            ucAddPerson1.GetPerson(person);
        }
        public void GetPerson(clsPeople_BLL person)
        {
            if (person != null && person.PersonID != -1)
            {
                this.person = person;
                ucAddPerson1.GetPerson(person);
            }
        }

        public delegate void _deLinker();
        public event _deLinker Linker;

        public delegate void _deGetPersonObject(clsPeople_BLL person);
        public event _deGetPersonObject GetPersonObjectLinker;

        void GetPersonLinker(clsPeople_BLL person)
        {
            if (GetPersonObjectLinker != null)
                GetPersonObjectLinker(person);
        }

        void LinkerMethod()
        {
            if (Linker != null)
                Linker.Invoke();
        }

        internal void AddMode() =>
            ucAddPerson1.AddMode();
    }
}
