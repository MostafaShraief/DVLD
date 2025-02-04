using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsPeople_BLL
    {
        private clsSave_BLL.enMode _Mode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPeople_BLL()
        {
            _Mode = clsSave_BLL.enMode.New;
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;
        }

        private clsPeople_BLL(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, Byte Gender,
            string Address, string Phone, string Email, int NationalityCountryID,
            string ImagePath)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
        }

        private bool CheckIsStringsNotNullableOrEmpty(ref List<string> list)
        {
            return clsUtility_BLL.CheckStringsInListNotNullableOrEmpty(ref list);
        }

        private bool _CheckStringsLength()
        {
            bool IsOk = false;

            if (NationalNo.Length <= 20 && FirstName.Length <= 20 &&
                SecondName.Length <= 20 &&
                (ThirdName == null || ThirdName.Length <= 20) &&
                LastName.Length <= 20 &&
                Address.Length <= 500 && Phone.Length <= 20 &&
                (Email == null || Email.Length <= 20) &&
                (ImagePath == null || ImagePath.Length <= 250))
                IsOk = true;

            return IsOk;
        }

        private bool _CheckOnlyLettersInStrings(ref List<string> list)
        {
            list.Remove(NationalNo);
            return clsUtility_BLL.CheckOnlyLettersInListOfString(ref list);
        }

        private bool _CheckStrings()
        {
            List<string> list = new List<string> { NationalNo, FirstName,
                SecondName, LastName, Address };

            if (ThirdName != null)
                list.Add(ThirdName);

            return CheckIsStringsNotNullableOrEmpty(ref list) &&
                _CheckStringsLength() &&
                _CheckOnlyLettersInStrings(ref list);
        }

        private bool _CheckData()
        {
            bool IsOk = false;

            if (_CheckStrings() &&
                (DateOfBirth.Year > DateTime.Now.Year - 100 && DateOfBirth.Year <= DateTime.Now.Year - 10) &&
                (Email == null || clsUtility_BLL.CheckEmail(Email)))
                IsOk = true;

            return IsOk;
        }

        private bool _AddPerson()
        {
            bool IsAdded = false;

            if (_CheckData() == false || clsPeople_DAL.IsPersonExist(NationalNo))
                return false; // check if data is valid and national No is not exist before.

            int PersonID = clsPeople_DAL.AddPerson(NationalNo, FirstName, SecondName,
                ThirdName, LastName, DateOfBirth, Gender,
                Address, Phone, Email, NationalityCountryID, ImagePath);

            IsAdded = (PersonID != -1);

            return IsAdded;
        }

        private bool _UpdatePerson()
        {
            bool IsUpdated = false;

            if (_CheckData() == false)
                return false; // check if data is valid and national No is not exist before.

            clsPeople_DAL.UpdatePerson(PersonID ,NationalNo, FirstName, SecondName,
                ThirdName, LastName, DateOfBirth, Gender,
                Address, Phone, Email, NationalityCountryID, ImagePath);

            return IsUpdated;
        }

        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _AddPerson, _UpdatePerson);
        }

        public static clsPeople_BLL Find(int PersonID)
        {
            string FirstName = "";
            string NationalNo = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.MinValue;
            Byte Gender = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (clsPeople_DAL.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref
                Address, ref Phone, ref Email, ref NationalityCountryID,
                ref ImagePath))
                return new clsPeople_BLL(PersonID, NationalNo, FirstName, SecondName,
                    ThirdName, LastName, DateOfBirth, Gender,
                    Address, Phone, Email, NationalityCountryID,
                    ImagePath);
            else
                return new clsPeople_BLL();
        }

        public static clsPeople_BLL Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.MinValue;
            Byte Gender = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (clsPeople_DAL.GetPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref
                Address, ref Phone, ref Email, ref NationalityCountryID,
                ref ImagePath))
                return new clsPeople_BLL(PersonID, NationalNo, FirstName, SecondName,
                    ThirdName, LastName, DateOfBirth, Gender,
                    Address, Phone, Email, NationalityCountryID,
                    ImagePath);
            else
                return new clsPeople_BLL();
        }

        public static DataTable GetListOfPeople()
        {
            return clsPeople_DAL.GetAllPeople();
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeople_DAL.DeletePerson(PersonID);
        }

        public static bool DeletePerson(string NationalNo)
        {
            return clsPeople_DAL.DeletePerson(NationalNo);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPeople_DAL.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPeople_DAL.IsPersonExist(NationalNo);
        }

        public DataRow ConvertToDataRow(ref DataTable dataTable)
        {
            if (_Mode == clsSave_BLL.enMode.New)
                return null;

            // Create a new DataRow and fill it with the Person's data
            DataRow row = dataTable.NewRow();
            row["PersonID"] = PersonID;
            row["NationalNo"] = NationalNo;
            row["FirstName"] = FirstName;
            row["SecondName"] = SecondName;
            row["ThirdName"] = ThirdName;
            row["LastName"] = LastName;
            row["DateOfBirth"] = DateOfBirth;
            row["Gender"] = Gender;
            row["Address"] = Address;
            row["Phone"] = Phone;
            row["Email"] = Email;
            row["CountryName"] = NationalityCountryID;
            row["ImagePath"] = ImagePath;

            return row;
        }
    }
}
