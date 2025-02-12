using DVLD.Manage_People;
using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal class clsUtility
    {
        public static string DefaultCountry { get { return "Syria"; } }
        public static string DefaultFilter { get { return "None"; } }
        public static string DeffaultGender { get { return "Male"; } }

        public static List<string> ConvertStringToListOfLowerCaseWords(string str)
        {
            List<string> strings = new List<string>();

            StringBuilder stringBuilder = new StringBuilder(str.Trim()),
                Temp = new StringBuilder();

            for (int i = 0; i < stringBuilder.Length; ++i)
            {
                if (stringBuilder[i] == ' ')
                {
                    strings.Add(Temp.ToString());
                    Temp.Clear();
                    stringBuilder = stringBuilder.Remove(0, i + 1);
                    i = 0;
                }
                else
                {
                    stringBuilder[i] =
                        Convert.ToChar(stringBuilder[i].ToString().ToLower());
                    Temp.Append(stringBuilder[i]);
                }
            }

            return strings;
        }

        public static bool DeletePerson(clsPeople_BLL person)
        {
            if (person == null)
                return false;

            if (MessageBox.Show("Are you sure that you want to delete this person card," +
                " it will be removed from the system forever.", "Delete Card",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPeople_BLL.DeletePerson(person.PersonID))
                {
                    MessageBox.Show("Person card has been deleted from the system.", "Deleted Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                    MessageBox.Show("Person may deleted before or have a license in" +
                        " the system or have user logs", "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Process canceled.", "Delete Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            if (PersonID == -1)
                return false;

            if (MessageBox.Show("Are you sure that you want to delete this person card," +
                " it will be removed from the system forever.", "Delete Card",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPeople_BLL.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person card has been deleted from the system.", "Deleted Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                    MessageBox.Show("Person may deleted before or have a license in" +
                        " the system or have user logs", "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Process canceled.", "Delete Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return false;
        }

        public static class Characters
        {
            private static bool ValidateCharacters(string input, string pattern)
            {
                return Regex.IsMatch(input, pattern);
            }

            public static class English
            {
                public static bool ValidateOnlyLetters(string input) => ValidateCharacters(input, @"^[a-zA-Z]+$");
                public static bool ValidateLettersAndNumbers(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9]+$");
                public static bool ValidateOnlyNumbers(string input) => ValidateCharacters(input, @"^\d+$");
                public static bool ValidateEmail(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                public static bool ValidateOnlyLettersWithSpaces(string input) => ValidateCharacters(input, @"^[a-zA-Z\s]+$");
                public static bool ValidateLettersAndNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9\s]+$");
                public static bool ValidateOnlyNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\d\s]+$");
            }

            public static class AllLanguages
            {
                public static bool ValidateOnlyLetters(string input) => ValidateCharacters(input, @"^[\p{L}]+$");
                public static bool ValidateLettersAndNumbers(string input) => ValidateCharacters(input, @"^[\p{L}\p{N}]+$");
                public static bool ValidateOnlyNumbers(string input) => English.ValidateOnlyNumbers(input);
                public static bool ValidateEmail(string input) => ValidateCharacters(input, @"^[\p{L}0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                public static bool ValidateOnlyLettersWithSpaces(string input) => ValidateCharacters(input, @"^[\p{L}\s]+$");
                public static bool ValidateLettersAndNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\p{L}\p{N}\s]+$");
                public static bool ValidateOnlyNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\d\s]+$");
            }
        }

        public static class InputValidator
        {
            public enum ValidationType
            {
                OnlyLetters,
                LettersAndNumbers,
                OnlyNumbers,
                OnlyLettersWithSpaces,
                LettersAndNumbersWithSpaces,
                OnlyNumbersWithSpaces
            }

            private static readonly Dictionary<ValidationType, (string Pattern, string ErrorMessage)> EnglishValidationRules = new Dictionary<ValidationType, (string Pattern, string ErrorMessage)>()
            {
                { ValidationType.OnlyLetters, ("^[a-zA-Z]+$", "Only letters allowed!") },
                { ValidationType.LettersAndNumbers, ("^[a-zA-Z0-9]+$", "Only letters and numbers allowed!") },
                { ValidationType.OnlyNumbers, ("^\\d+$", "Only numbers allowed!") },
                { ValidationType.OnlyLettersWithSpaces, ("^[a-zA-Z\\s]+$", "Only letters and spaces allowed!") },
                { ValidationType.LettersAndNumbersWithSpaces, ("^[a-zA-Z0-9\\s]+$", "Only letters, numbers, and spaces allowed!") },
                { ValidationType.OnlyNumbersWithSpaces, ("^[\\d\\s]+$", "Only numbers and spaces allowed!") }
            };

            private static readonly Dictionary<ValidationType, (string Pattern, string ErrorMessage)> AllLanguagesValidationRules = new Dictionary<ValidationType, (string Pattern, string ErrorMessage)>()
            {
                { ValidationType.OnlyLetters, ("^[\\p{L}]+$", "Only letters allowed!") },
                { ValidationType.LettersAndNumbers, ("^[\\p{L}\\p{N}]+$", "Only letters and numbers allowed!") },
                { ValidationType.OnlyNumbers, ("^\\d+$", "Only numbers allowed!") },
                { ValidationType.OnlyLettersWithSpaces, ("^[\\p{L}\\s]+$", "Only letters and spaces allowed!") },
                { ValidationType.LettersAndNumbersWithSpaces, ("^[\\p{L}\\p{N}\\s]+$", "Only letters, numbers, and spaces allowed!") },
                { ValidationType.OnlyNumbersWithSpaces, ("^[\\d\\s]+$", "Only numbers and spaces allowed!") }
            };

            public static void ValidateKeyPress(object sender, KeyPressEventArgs e, ValidationType validationType, ErrorProvider errorProvider, bool isEnglish = true)
            {
                if (sender is Guna2TextBox textBox == false) return;

                var validationRules = isEnglish ? EnglishValidationRules : AllLanguagesValidationRules;
                if (!validationRules.ContainsKey(validationType)) return;

                var (pattern, errorMessage) = validationRules[validationType];
                string newText = e.KeyChar.ToString();

                if (!Regex.IsMatch(newText, pattern) && !char.IsControl(e.KeyChar))
                {
                    errorProvider.SetError(textBox, errorMessage);
                    e.Handled = true;
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                }
            }
        }



        public static void _LoadCountryToComboBox(Guna2ComboBox cb, string DefaultCountry = null)
        {
            DataTable dtCountries = clsCountry_BLL.GetListofCountries();

            foreach (DataRow row in dtCountries.Rows)
                cb.Items.Add(row["CountryName"]);

            if (!String.IsNullOrEmpty(DefaultCountry))
                cb.SelectedItem = DefaultCountry;

            dtCountries.Dispose();
        }

        public static class Image
        {
            public static bool IsImageValid(byte[] imageBytes)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Use System.Drawing.Image.FromStream
                        using (var image = System.Drawing.Image.FromStream(ms))
                        {
                            var test = image.Size; // Accessing properties forces validation
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }

            public static bool IsFileExist(string Path)
            {
                return File.Exists(Path);
            }

            public static Byte[] ImageToByteArray(System.Drawing.Image image)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Save the image to the MemoryStream in the specified format
                        image.Save(ms, image.RawFormat);
                        return ms.ToArray(); // Convert the stream to a byte array
                    }
                }
                catch
                {
                    return null;
                }
            }

            public static System.Drawing.Image ByteArrayToImage(Byte[] imageBytes)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(imageBytes);
                    return System.Drawing.Image.FromStream(ms);
                }
                catch
                {
                    return null;
                }
            }

            public static System.Drawing.Image LoadImageFromFile(string imagePath)
            {
                System.Drawing.Image image = null;

                if (IsFileExist(imagePath))
                {
                    try
                    {
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                    catch
                    {
                        MessageBox.Show("Failed To Retrieve Image", "Select Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return image;
            }
        }
    }
}
