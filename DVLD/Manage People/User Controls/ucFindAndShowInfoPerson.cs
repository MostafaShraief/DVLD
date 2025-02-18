using DVLD.UserControl;
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

namespace DVLD.Manage_People.User_Controls
{
    public partial class ucFindAndShowInfoPerson : System.Windows.Forms.UserControl
    {
        DVLD _mainForm = clsGlobal.MainForm;

        public ucFindAndShowInfoPerson()
        {
            InitializeComponent();
            ucFindPerson.Linker += FillPersonInfo;
        }

        public void GetMainFormObject(DVLD mainForm)
        {
            _mainForm = mainForm;
            ucFindPerson.GetMainFormObject(mainForm);
            ucPersonInfo.PopForm = false;
        }

        public void HideDeleteButton() =>
            ucPersonInfo.HideDeleteButton();

        clsPeople_BLL person;

        public delegate void delLinker(clsPeople_BLL person);
        public event delLinker LinkerGetPerson;

        public void GetPersonID(int PersonID) =>
            ucPersonInfo.GetPersonID(PersonID);

        public void FillPersonInfo(clsPeople_BLL person)
        {
            this.person = person;
            ucPersonInfo.GetPerson(person);
            if (person != null && person.PersonID != -1)
            {
                if (LinkerGetPerson != null)
                    LinkerGetPerson(person);
            }
        }

        public clsPeople_BLL SendPerson()
        {
            return ucPersonInfo.SendPerson();
        }


        public void ResetData()
        {
            person = null;
            ucPersonInfo.GetPerson(person);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPerson addEditPerson = new AddEditPerson();
            addEditPerson.GetPersonObjectLinker += FillPersonInfo;
            clsGlobal.MainForm.PushNewForm(addEditPerson);
        }
    }
}
