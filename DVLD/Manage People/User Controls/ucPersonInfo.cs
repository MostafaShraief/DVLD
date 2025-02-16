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

        public void GetMainFormObject(DVLD mainForm) =>
            _mainForm = mainForm;

        bool ShowDeleteButton = true;

        public void HideDeleteButton() =>
            ShowDeleteButton = false;

        clsPeople_BLL person;
        AddEditPerson addEditPerson;

        public bool PopForm = true;

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
            pbProfile.Image = null;
        }

        void FillPersonInfo()
        {
            btnEditPerson.Visible = btnDeleteCard.Visible = true;
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
            else
                person = new clsPeople_BLL();
            
            if (person.PersonID != -1)
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
            if (person == null)
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
                addEditPerson = new AddEditPerson(_mainForm);
                addEditPerson.GetPerson(person);
                addEditPerson.Linker += FillPersonInfo;
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
