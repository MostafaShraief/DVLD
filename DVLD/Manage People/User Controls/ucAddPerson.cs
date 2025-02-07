using DVLD.Properties;
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
        enum enImage { Gender, Custom }
        enImage _Image;

        public ucAddPerson(int PersonID = -1)
        {
            // if person id is given then switch to edit mode,
            // else switch to add mode.
            InitializeComponent();
            clsUtility._LoadCountryToComboBox(cbCountries, clsUtility.DefaultCountry);

            if (PersonID > -1)
                _EditMode(PersonID);
            else
                _AddMode();
        }

        void _AddMode()
        {
            Person = new clsPeople_BLL();
            lblTitle.Text = "Add Person";
            lblPersonID.Visible = false;
            lblPersonIDTitle.Visible = false;
            pbPersonID.Visible = false;
            cbGender.SelectedItem = clsUtility.DeffaultGender;
        }

        void _EditMode(int PersonID = -1)
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

        string _SaveImage()
        {
            string strPath = "";

            if (_Image == enImage.Custom)
            {
                try
                {
                    // Create path for image with new name (as Guid).
                    strPath = Path.Combine(clsUtility.DestinationFolder,
                        Guid.NewGuid().ToString() + Path.GetExtension(fileDialog.FileName));

                    // Check if the destination folder exists, if not, create it
                    if (!Directory.Exists(clsUtility.DestinationFolder))
                        Directory.CreateDirectory(clsUtility.DestinationFolder);

                    // Copy the file to the destination folder
                    File.Copy(fileDialog.FileName, strPath, true);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur while copying the file
                    MessageBox.Show("Error copying file: " + ex.Message, "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return strPath;
        }

        void _RemoveImageFile(string ImagePath, bool FailedToSave = false)
        {
            // FailedToSave = true, then assign null to Person.ImagePath.
            try
            {
                // Check if the file exists
                if (File.Exists(ImagePath))
                {
                    // Delete the file
                    File.Delete(ImagePath);

                    if (FailedToSave)
                        Person.ImagePath = null;
                }
            }
            catch
            {
                // log file.
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
            Person.Gender = ((clsPeople_BLL.enGender)cbGender.SelectedIndex);
            Person.NationalityCountryID = 1;
            string oldImagePath = Person.ImagePath; // to delete this file after save operation done.
            Person.ImagePath = _SaveImage();

            if (Person.Save())
            {
                if (String.IsNullOrEmpty(oldImagePath)) // delete old image.
                    _RemoveImageFile(oldImagePath);

                _EditMode();

                MessageBox.Show("Person Card Saved Successfuly.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_Image == enImage.Custom)
                    _RemoveImageFile(Person.ImagePath, true);

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
                pbProfileImage.Image = System.Drawing.Image.FromFile(fileDialog.FileName);
                _Image = enImage.Custom;
                _ImageChange();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while loading the image
                MessageBox.Show("Error loading image: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void _ImageChange()
        {
            if (_Image == enImage.Custom)
            {
                btnRemoveImage.Visible = true;
                btnSetImage.Visible = false;
            }
            else
            {
                btnSetImage.Visible = true;
                btnRemoveImage.Visible = false;
            }
        }

        void _SetGenderImage()
        {
            // if there is no custom image, then set image depending on gender.
            if (cbGender.Text == enGender.Male.ToString())
            {
                pbProfileImage.Image = Resources.Man;
                _Image = enImage.Gender;
                _ImageChange();
            }
            else if (cbGender.Text == enGender.Female.ToString())
            {
                pbProfileImage.Image = Resources.Woman;
                _Image = enImage.Gender;
                _ImageChange();
            }
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
            if (_Image == enImage.Gender)
                _SetGenderImage();
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _UnsetImage();
        }
    }
}
