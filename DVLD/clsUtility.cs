using DVLD_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static string DestinationFolder { get { return "D:\\DVLD\\Profile-Images"; } }

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
    }
}
