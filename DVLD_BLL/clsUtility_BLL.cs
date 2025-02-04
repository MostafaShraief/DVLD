using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    internal class clsUtility_BLL
    {
        public static bool CheckOnlyLettersAndSpaces(string str)
        {
            if (str == null)
                return false;

            bool IsOk = true;

            foreach (char ch in str)
            {
                if (!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || ch == ' ')) // check if character is not letter or space, then break.
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static bool CheckCharactersByExpression(Func<char, bool> exp, string str)
        {
            bool IsOk = true;

            foreach (char ch in str)
            {
                if (!exp(ch)) // check if character is not meet expression conditions.
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static bool CheckOnlyLettersInListOfString(ref List<string> Strings)
        {
            bool IsOk = true;

            foreach (string str in Strings)
            {
                if (!CheckOnlyLettersAndSpaces(str))
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static Func <string, bool> CheckStringNotNullableOrEmpty = 
            (str) => (str == null || str == string.Empty);

        public static bool CheckStringsInListNotNullableOrEmpty(ref List<string> list)
        {
            bool IsOk = true;

            foreach (string str in list)
            {
                if (CheckStringNotNullableOrEmpty(str))
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static bool CheckListOfStringByExpression(Func<char, bool> exp, ref List<string> list)
        {
            bool IsOk = true;

            foreach (string str in list)
            {
                if (!CheckCharactersByExpression(exp ,str)) // if str not meet conditions in the experstion then break.
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static Func<string, bool> CheckOnlyLettersAndNotEmpty = 
            (str) => (str != string.Empty && clsUtility_BLL.CheckOnlyLettersAndSpaces(str));

        public static bool CheckEmail(string Email)
        {
            if (Email == null)
                return false;

            bool IsOk = true;

            List<string> list = Email.Split('@').ToList();

            if (list.Count != 2)
                return false;

            string part = list[1];

            list.RemoveAt(1);

            list.AddRange(part.Split('.').ToList());

            if (list.Count != 3)
                return false;

            foreach (string str in list)
                if (str.Length == 0) // Check if str is empty.
                    return false;

            if (CheckListOfStringByExpression(((c) => ((c >= 'a' && c <= 'z') ||
            (c >= 'A' && c <= 'Z') ||
            (c >= '0' && c <= '9'))),
            ref list) == false) // check if characters only numbers and letters.
                return false;

            return IsOk;
        }
    }
}
