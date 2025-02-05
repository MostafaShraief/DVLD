using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Manage_People.User_Controls
{
    public partial class ucAddPerson : System.Windows.Forms.UserControl
    {

        public ucAddPerson()
        {
            InitializeComponent();
            cbGender.SelectedItem = clsUtility.DeffaultGender;
            clsUtility._LoadCountryToComboBox(cbCountries, clsUtility.DefaultCountry);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPeople_BLL Person = new clsPeople_BLL();

            Person.FirstName = tbFirstName.Text;
            Person.LastName = tbLastName.Text;
            Person.Email = tbEmail.Text;
            Person.Phone = tbPhone.Text;
            Person.SecondName = tbSecondName.Text;
            Person.ThirdName = tbThirdName.Text;
            Person.NationalNo = tbNationalNo.Text;
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.Address = tbAddress.Text;
            Person.Gender = Convert.ToByte(cbGender.SelectedIndex);
            Person.NationalityCountryID = 1;

            if (Person.Save())
                MessageBox.Show("Person Card Saved Successfuly.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Person Card Not Saved.", "Failed To Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
