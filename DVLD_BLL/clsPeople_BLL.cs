using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
using static DVLD_BLL.clsUtility_BLL;

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
        public enum enGender { Male = 0, Female = 1 }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        private Byte[] _ImageFile { get; set; }
        public Byte[] ImageFile
        { 
            get { return _ImageFile; } 

            set 
            {
                if (value != null && clsUtility_BLL.Image.IsImageValid(value))
                    _ImageFile = value;
                else
                    _ImageFile = null;
            }
        }
        private string ImagePath { get; set; }

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
            ImageFile = null;
        }

        private clsPeople_BLL(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, enGender Gender,
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
            ImageFile = _LoadImage();
        }

        private Byte[] _LoadImage()
        {
            return clsUtility_BLL.Image.LoadImageFromFile(ImagePath);
        }

        private bool _RemoveOldImage()
        {
            bool Ok = true;

            if (ImagePath != null && clsUtility_BLL.Image.IsFileExist(ImagePath))
            {
                try
                {
                    File.Delete(ImagePath);
                }
                catch
                {
                    return false;
                }
            }

            return Ok;
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
                (Email == null || Email.Length <= 50) &&
                (ImagePath == null || ImagePath.Length <= 250))
                IsOk = true;

            return IsOk;
        }

        private bool _CheckOnlyLettersInStrings(ref List<string> list)
        {
            list.Remove(NationalNo);
            list.Remove(Address);
            return clsUtility_BLL.CheckOnlyLettersInListOfString(ref list);
        }

        private bool _CheckStrings()
        {
            List<string> list = new List<string> { NationalNo, FirstName,
                SecondName, LastName, Address };

            if (!String.IsNullOrEmpty(ThirdName))
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
                (String.IsNullOrEmpty(Email) || clsUtility_BLL.CheckEmail(Email)) &&
                (Phone != null && clsUtility_BLL.Characters.English.ValidateOnlyNumbers(Phone)))
                IsOk = true;
            
            return IsOk;
        }

        void _SaveImage()
        {
            if (ImageFile == null)
            {
                _RemoveOldImage();
                ImagePath = null;
                return;
            }

            // convert to Image.
            System.Drawing.Image image = clsUtility_BLL.Image.ByteArrayToImage(ImageFile);

            // get image path.
            string NewImagePath = clsUtility_BLL.Image.CreateImagePath(image);

            // save image in folder.
            if (clsUtility_BLL.Image.SaveImageToPath(image, NewImagePath) == true)
            {
                _RemoveOldImage();
                ImagePath = NewImagePath;
            }
        }

        private bool _AddPerson()
        {
            bool IsAdded = false;

            if (_CheckData() == false || clsPeople_DAL.IsPersonExist(NationalNo))
                return false; // check if data is valid and national No is not exist before.

            _SaveImage();

            PersonID = clsPeople_DAL.AddPerson(NationalNo, FirstName, SecondName,
                ThirdName, LastName, DateOfBirth, ((Byte)Gender),
                Address, Phone, Email, NationalityCountryID, ImagePath);

            IsAdded = (PersonID != -1);

            return IsAdded;
        }

        private bool _UpdatePerson()
        {
            bool IsUpdated = false;

            if (_CheckData() == false)
                return false; // check if data is valid and national No is not exist before.

            _SaveImage();

            IsUpdated = clsPeople_DAL.UpdatePerson(PersonID ,NationalNo, FirstName, SecondName,
                ThirdName, LastName, DateOfBirth, ((Byte)Gender),
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
                    ThirdName, LastName, DateOfBirth, ((enGender)Gender),
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
                    ThirdName, LastName, DateOfBirth, ((enGender)Gender),
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

        public void AddToTable(ref DataTable dataTable)
        {
            if (_Mode == clsSave_BLL.enMode.New)
                return;

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

            dataTable.Rows.Add(row);
        }

        public string GetFullName()
        {
            return FirstName + ' ' +
                SecondName + ' ' + 
                (!String.IsNullOrEmpty(ThirdName) ? ThirdName + ' ' : "") + 
                LastName;
        }
    }
}
