using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD
{
    internal class clsUtility
    {
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
    }
}
