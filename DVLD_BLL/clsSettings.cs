using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    internal class clsSettings
    {
        public static string DeffaultImageFolder { get { return "D:\\DVLD\\Profile-Images"; } } // folder path to save images
        public static int DeffaultShiftValue { get; } = 3; // shift to encrypt and decrypt password for users.
    }
}
