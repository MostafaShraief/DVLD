using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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
