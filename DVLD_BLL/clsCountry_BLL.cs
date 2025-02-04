using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    internal class clsCountry_BLL
    {
        public int CountryID { get; }
        public string CountryName { get; set; }
        private clsSave_BLL.enMode _Mode;

        public clsCountry_BLL()
        {
            CountryID = -1;
            CountryName = "";
            _Mode = clsSave_BLL.enMode.New;
        }

        private clsCountry_BLL(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            _Mode = clsSave_BLL.enMode.Existing;
        }

        private bool _CheckData()
        {
            // check if data is corrupted or not.
            bool IsOk = false;

            IsOk = (clsUtility_BLL.CheckStringNotNullableOrEmpty(CountryName) // Check is not empty
                && clsUtility_BLL.CheckOnlyLettersAndSpaces(CountryName)); // then check is only letters and characters

            return IsOk;
        }

        private bool _AddCountry()
        {
            if (_CheckData() == false)
                return false; // if data corrupted then return false.

            bool IsAdded = false;

            int CountryID = clsCountry_DAL.AddCountry(CountryName); // Add country to database table.

            IsAdded = (CountryID != -1);

            return IsAdded;
        }

        bool _UpdateCountry()
        {
            if (_CheckData() == false)
                return false; // if data corrupted then return false.

            return clsCountry_DAL.UpdateCountry(CountryID, CountryName);
        }

        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _AddCountry, _UpdateCountry);
        }

        public static clsCountry_BLL FindCountry(int CountryID)
        {
            string CountryName = "";

            if (clsCountry_DAL.GetCoutnryByID(CountryID, ref CountryName))
                return new clsCountry_BLL(CountryID, CountryName);
            else
                return new clsCountry_BLL();
        }

        public static DataTable GetListofCountries()
        {
            return clsCountry_DAL.GetAllCountries();
        }

        public static bool DeleteCountry(int CountryID)
        {
            return clsCountry_DAL.DeleteCountry(CountryID);
        }

        public static bool ISCountryExist(int CountryID)
        {
            return clsCountry_DAL.IsCountryExist(CountryID);
        }
    }
}
