using DVLD.Manage_People;
using DVLD.Manage_People.User_Controls;
using DVLD.Properties;
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

namespace DVLD.UserControl
{
    public partial class ucPersonInfo : System.Windows.Forms.UserControl
    {
        DVLD _mainForm = clsGlobal.MainForm;

        public ucPersonInfo()
        {
            InitializeComponent();
        }

        bool ShowDeleteButton = true;

        public void HideDeleteButton() =>
            ShowDeleteButton = false;

        clsPeople_BLL person;
        AddEditPerson addEditPerson;

        public bool PopForm = true;

        public clsPeople_BLL SendPerson()
        {
            if (person != null)
                return person;

            return new clsPeople_BLL();
        }

        public void ResetPersonInfo()
        {
            person = new clsPeople_BLL();
            btnEditPerson.Visible = false;
            btnDeleteCard.Visible = false;
            lblPersonID.Text = "???";
            lblFullName.Text = "None";
            lblCountry.Text = "None";
            lblDateOfBirth.Text = "None";
            lblAddress.Text = "None";
            lblEmail.Text = "None";
            lblGender.Text = "None";
            lblNationalNo.Text = "None";
            lblPhone.Text = "None";
            pbProfile.Image = Resources.Question_Mark;
        }

        void FillPersonInfo()
        {
            btnEditPerson.Visible = true;
            btnDeleteCard.Visible = ShowDeleteButton;
            lblPersonID.Text = person.PersonID.ToString();
            lblFullName.Text = String.Format(@"{0} {1} {2} {3}", person.FirstName,
                person.SecondName, person.ThirdName, person.LastName);
            lblCountry.Text = clsCountry_BLL.FindCountry(person.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = person.DateOfBirth.ToString();
            lblAddress.Text = person.Address;
            lblEmail.Text = person.Email;
            lblGender.Text = (person.Gender == clsPeople_BLL.enGender.Male ? "Male" : "Female");
            lblNationalNo.Text = person.NationalNo;
            lblPhone.Text = person.Phone;

            pbProfile.Image = clsGlobal.FillPersonImage(person.ImageFile, person.Gender);
        }

        public void GetPersonID(int personID)
        {
            if (personID != -1 && clsPeople_BLL.IsPersonExist(personID))
                person = clsPeople_BLL.Find(personID);
            else
                person = new clsPeople_BLL();
            
            if (person != null && person.PersonID != -1)
                FillPersonInfo();
            else
                ResetPersonInfo();
        }

        public void GetNationalNo(string NationalNo)
        {
            if (!String.IsNullOrEmpty(NationalNo))
                person = clsPeople_BLL.Find(NationalNo);

            if (person.PersonID != -1)
                FillPersonInfo();
        }

        public void GetPerson(clsPeople_BLL person)
        {
            if (person == null || person.PersonID == -1)
                ResetPersonInfo();
            else
            {
                this.person = person;
                FillPersonInfo();
            }
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                addEditPerson = new AddEditPerson();
                addEditPerson.GetPerson(person);
                addEditPerson.GetPersonObjectLinker += GetPerson;
                _mainForm.PushNewForm(addEditPerson);
            }
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            if (clsUtility.clsForms.DeletePerson(person.PersonID))
            {
                if (PopForm)
                    _mainForm.PopFormForever();

                ResetPersonInfo();

                // this step don`t let the user back to edit mode
                if (addEditPerson != null)
                    addEditPerson.AddMode();
            }
        }
    }
}
