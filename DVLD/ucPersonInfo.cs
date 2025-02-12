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
        DVLD _mainForm;

        public ucPersonInfo()
        {
            InitializeComponent();
        }

        public void GetMainFormObject(DVLD mainForm)
        {
            _mainForm = mainForm;
        }

        clsPeople_BLL person;
        AddEditPerson addEditPerson;

        void ResetPersonInfo()
        {
            person = new clsPeople_BLL();
            FillPersonInfo();
        }

        void FillPersonInfo()
        {
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

            if (person.ImageFile != null) // set image to pbProfile
                pbProfile.Image = clsUtility.Image.ByteArrayToImage(person.ImageFile);
            else if (person.Gender == clsPeople_BLL.enGender.Male)
                pbProfile.Image = Resources.Man;
            else
                pbProfile.Image = Resources.Woman;
        }

        public void GetPersonID(int personID)
        {
            if (personID != -1)
                person = clsPeople_BLL.Find(personID);

            if (person.PersonID != -1)
                FillPersonInfo();
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
            this.person = person;
            FillPersonInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addEditPerson = new AddEditPerson(_mainForm);
            addEditPerson.GetPerson(person);
            addEditPerson.Linker += ResetPersonInfo;
            _mainForm.PushNewForm(addEditPerson);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (clsUtility.DeletePerson(person))
            {
                _mainForm.PopFormForever();

                // this step don`t let the user back to edit mode
                if (addEditPerson != null)
                    addEditPerson.AddMode();
            }
        }
    }
}
