﻿using DVLD.Properties;
using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD
{
    internal static class clsGlobal
    {
        public static DVLD MainForm { get; set; }


        static public clsPeople_BLL userPerson;
        static clsUsers_BLL private_user; // private user
        internal static clsUsers_BLL user
        {
            get
            {
                if (private_user != null)
                    return private_user;
                else
                    return new clsUsers_BLL();
            }
            set
            {
                if (value != null && value.UserID != -1)
                {
                    private_user = value;
                    userPerson = clsPeople_BLL.Find(user.PersonID);
                    MainForm.RefreshUserInfo();
                }
            }
        }
        public static string LoginFilePath { get; } = "D:\\DVLD\\Login.txt";

        public enum ApplicationType
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6
        }

        public enum enApplicationStatus { New = 1, Cancelled, Completed }
       
        public enum enLocalLicenseStatus
        {
            EyeTest = 0,
            WrittenTest = 1,
            PracticalTest = 2,
            IssueLicense = 3,
        }

        public enum enLicencsesClasses
        {
            SmallMotorcycle = 1, HeavyMotorcycleLicense,
            OrdinaryDrivingLicense, Commercial, Agricultural, SmallAndMediumBus,
            TruckAndHeavyVehicle, RetakeTest = 8
        }

        public enum enTestType
        {
            EyeTest = 1,
            WrittenTest = 2,
            PracticalTest = 3
        }

        public static string ConverLicenseClassEnumToString(enLicencsesClasses LicenseClass)
        {
            string NewLicenseClass = "", Temp = LicenseClass.ToString();

            foreach (char c in Temp)
            {
                if (char.IsUpper(c))
                    NewLicenseClass += $" {c}";
                else
                    NewLicenseClass += c;
            }

            NewLicenseClass = NewLicenseClass.TrimStart();

            return NewLicenseClass;
        }

        public static Image FillPersonImage(Byte[] ImageFile, clsPeople_BLL.enGender gender)
        {
            if (ImageFile != null) // set image to pbProfile
                return clsUtility.Image.ByteArrayToImage(ImageFile);
            else if (gender == clsPeople_BLL.enGender.Male)
                return Resources.Man;
            else if (gender == clsPeople_BLL.enGender.Female)
                return Resources.Woman;
            else
                return Resources.Question_Mark;
        }

        public enum enApplicationType
        {
            NewLocalLicense = 1, Renew, LostReplacement,
            DamagedReplacement, ReleaseDetained, NewInternational, RetakeTest = 8
        }
    }
}
