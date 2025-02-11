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

namespace DVLD.Manage_People
{
    public partial class ShowPersonInfo : Form
    {
        DVLD _mainForm;

        public ShowPersonInfo(DVLD mainForm)
        {
            InitializeComponent();
            ((ucTitleScreen)ucTitleScreen1).ChangeTitle("Person Info");
            _mainForm = mainForm;
            ucPersonInfo1.GetMainFormObject(mainForm);
        }

        clsPeople_BLL person;

        void OpenPersonInfoForm()
        {
            if (person.PersonID != -1)
                ucPersonInfo1.GetPerson(person);
        }

        public void GetPersonID(int personID)
        {
            if (personID != -1)
                person = clsPeople_BLL.Find(personID);

            if (person.PersonID != -1)
                OpenPersonInfoForm();
        }

        public void GetNationalNo(string NationalNo)
        {
            if (!String.IsNullOrEmpty(NationalNo))
                person = clsPeople_BLL.Find(NationalNo);

            if (person.PersonID != -1)
                OpenPersonInfoForm();
        }

        public void GetPerson(clsPeople_BLL person)
        {
            this.person = person;
            OpenPersonInfoForm();
        }
    }
}
