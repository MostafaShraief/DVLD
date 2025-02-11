﻿using DVLD.Properties;
using DVLD_BLL;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Manage_People.User_Controls
{
    public partial class ucAddPerson : System.Windows.Forms.UserControl
    {
        clsPeople_BLL Person;
        enum enGender { Male, Female }

        public ucAddPerson(int PersonID = -1)
        {
            // if person id is given then switch to edit mode,
            // else switch to add mode.
            InitializeComponent();
            clsUtility._LoadCountryToComboBox(cbCountries, clsUtility.DefaultCountry);
            dtpDateOfBirth.MaxDate = (DateTime.Today.AddYears(-18));
            dtpDateOfBirth.MinDate = (DateTime.Today.AddYears(-100));

            if (PersonID > -1)
                _EditMode(PersonID);
            else
                _AddMode();
        }

        public void GetPerson(clsPeople_BLL person)
        {
            if (person.PersonID != -1)
            {
                this.Person = person;
                _EditMode();
            }
        }

        void FillWithPersonData()
        {
            tbFirstName.Text = Person.FirstName;
            tbLastName.Text = Person.LastName;
            tbEmail.Text = Person.Email;
            tbPhone.Text = Person.Phone;
            tbSecondName.Text = Person.SecondName;
            tbThirdName.Text = Person.ThirdName;
            tbNationalNo.Text = Person.NationalNo;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            tbAddress.Text = Person.Address;
            cbGender.Text = (Person.Gender == clsPeople_BLL.enGender.Male ? "Male" : "Female");

            // Find and set the country in the ComboBox
            var country = clsCountry_BLL.FindCountry(Person.NationalityCountryID);
            if (country != null)
                cbCountries.Text = country.CountryName;

            // Set the profile image
            if (Person.ImageFile != null && Person.ImageFile.Length > 0)
            {
                pbProfileImage.Image = clsUtility.Image.ByteArrayToImage(Person.ImageFile);
                pbProfileImage.Tag = null;
            }
            else
                _SetGenderImage();
        }

        void _AddMode()
        {
            Person = new clsPeople_BLL();
            lblTitle.Text = "Add Person";
            lblPersonID.Visible = false;
            lblPersonIDTitle.Visible = false;
            pbPersonID.Visible = false;
            cbGender.SelectedItem = clsUtility.DeffaultGender;
            _SetGenderImage();
        }

        private void _EditMode(int PersonID = -1)
        {
            // if personid is given then search about it and update all text box.
            // else only update personid in 'lblPersonID' from person object.
            if (PersonID > -1)
                Person = clsPeople_BLL.Find(PersonID);

            lblTitle.Text = "Edit Person Card";
            lblPersonID.Text = Person.PersonID.ToString();
            lblPersonID.Visible = true;
            lblPersonIDTitle.Visible = true;
            pbPersonID.Visible = true;
            FillWithPersonData();
        }

        private void AllowLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow letters, backspace, white space and control keys
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignore the input

                Guna2TextBox textBox = sender as Guna2TextBox;
                tooltipHint.Show("Only letters and spaces are allowed.",
                    textBox, new Point(0, textBox.Size.Height), 2000); // 2000ms = 2 seconds
            }
        }

        void _Save()
        {
            // save person info in the database,
            // if data saved successfuly, then switch to edit mode.
            Person.FirstName = tbFirstName.Text;
            Person.LastName = tbLastName.Text;
            Person.Email = tbEmail.Text;
            Person.Phone = tbPhone.Text;
            Person.SecondName = tbSecondName.Text;
            Person.ThirdName = tbThirdName.Text;
            Person.NationalNo = tbNationalNo.Text;
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.Address = tbAddress.Text;
            Person.Gender = (cbGender.Text[0] == 'M' ?
                clsPeople_BLL.enGender.Male : clsPeople_BLL.enGender.Female);
            Person.NationalityCountryID = clsCountry_BLL.FindCountry(cbCountries.Text).CountryID;
            if (_IsGenderImage() == false)
                Person.ImageFile = clsUtility.Image.ImageToByteArray(pbProfileImage.Image);
            else
                Person.ImageFile = null;

            if (Person.Save())
            {
                _EditMode();

                MessageBox.Show("Person Card Saved Successfuly.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Person Card Not Saved.", "Failed To Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        void _SetImage()
        {
            try
            {
                // Load the selected image into the PictureBox
                pbProfileImage.Image = clsUtility.Image.LoadImageFromFile(fileDialog.FileName);
                pbProfileImage.Tag = null;
                _ImageChange();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while loading the image
                fileDialog.FileName = "";
                MessageBox.Show("Error loading image: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool _IsGenderImage()
        {
            return pbProfileImage.Tag != null;
        }

        void _ImageChange()
        {
            if (_IsGenderImage())
            {
                btnSetImage.Visible = true;
                btnRemoveImage.Visible = false;
            }
            else
            {
                btnRemoveImage.Visible = true;
                btnSetImage.Visible = false;
            }
        }

        void _SetGenderImage()
        {
            // if there is no custom image, then set image depending on gender.
            if (cbGender.Text == enGender.Male.ToString())
                pbProfileImage.Image = Resources.Man;
            else if (cbGender.Text == enGender.Female.ToString())
                pbProfileImage.Image = Resources.Woman;

            pbProfileImage.Tag = 1;

            _ImageChange();
        }

        void _SelectImage()
        {
            // Set properties for the OpenFileDialog
            fileDialog.Title = "Select a File";
            fileDialog.Filter = "Image Files (*.jpg; *.jpeg)|*.jpg; *.jpeg";
            fileDialog.Multiselect = false; // Allow only single file selection
            fileDialog.FileName = string.Empty;

            if (fileDialog.ShowDialog() == DialogResult.OK)
                _SetImage();
        }

        void _UnsetImage()
        {
            _SetGenderImage();
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            _SelectImage();
        }

        private void cbGender_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_IsGenderImage())
                _SetGenderImage();
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _UnsetImage();
        }

        private void tbNationalNo_TextChanged(object sender, EventArgs e)
        {
            if (clsPeople_BLL.Find(tbNationalNo.Text).PersonID != -1)
                errorProviderNationalNo.SetError(tbNationalNo, "National Number Is Already Used");
            else
                errorProviderNationalNo.SetError((sender as Guna2TextBox), "");
        }

        private void tbCheckOnlyGlobalLetters_Validating(object sender, CancelEventArgs e)
        {
            if (clsUtility.Characters.AllLanguages.ValidateOnlyLettersWithSpaces((sender as Guna2TextBox).Text) == false)
                errorProviderLettersAndSpaces.SetError((sender as Guna2TextBox), "Only letters and spaces are allowed.");
            else
                errorProviderLettersAndSpaces.SetError((sender as Guna2TextBox), "");
        }

        private void tbThirdName_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as Guna2TextBox).Text.Length != 0 && clsUtility.Characters.AllLanguages.ValidateOnlyLettersWithSpaces((sender as Guna2TextBox).Text) == false)
                errorProviderLettersAndSpaces.SetError((sender as Guna2TextBox), "Only letters and spaces are allowed.");
            else
                errorProviderLettersAndSpaces.SetError((sender as Guna2TextBox), "");
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as Guna2TextBox).Text.Length != 0 && clsUtility.Characters.English.ValidateEmail((sender as Guna2TextBox).Text) == false)
                errorProviderEmail.SetError((sender as Guna2TextBox), "Email address is not valid.");
            else
                errorProviderEmail.SetError((sender as Guna2TextBox), "");
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (clsUtility.Characters.English.ValidateOnlyNumbers((sender as Guna2TextBox).Text) == false)
                errorProviderPhoneNumber.SetError((sender as Guna2TextBox), "Only english numbers are allowed.");
            else
                errorProviderPhoneNumber.SetError((sender as Guna2TextBox), "");
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow numbers and control keys
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the input

                Guna2TextBox textBox = sender as Guna2TextBox;
                tooltipHint.Show("Only numbers are allowed.",
                    textBox, new Point(0, textBox.Size.Height), 2000); // 2000ms = 2 seconds
            }
        }
    }
}
