using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsUsers_BLL
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; }
        public string UserName { get; set; }
        private string Password { get; set; }
        public bool IsActive { get; set; }

        clsSave_BLL.enMode _Mode;

        public clsUsers_BLL()
        {
            UserID = -1;
            PersonID = -1;
            FullName = "";
            Password = "";
            IsActive = false;
            _Mode = clsSave_BLL.enMode.New;
        }

        clsUsers_BLL(int userID, int personID, string fullName,
            string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            FullName = fullName;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            _Mode = clsSave_BLL.enMode.Existing;
        }

        bool _CheckData()
        {
            bool IsOk = false;

            if (clsPeople_BLL.IsPersonExist(PersonID) &&
                (!String.IsNullOrEmpty(UserName) && clsUtility_BLL._IsValidUsernameOrPassword(UserName, 5) &&
                !clsUsers_BLL.IsUserExistByUserName(UserName)) &&
                (!String.IsNullOrEmpty(UserName) && clsUtility_BLL._IsValidUsernameOrPassword(Password, 8)))
                IsOk = true;

            return IsOk;
        }

        private bool _AddUser()
        {
            bool IsAdded = false;

            if (!_CheckData())
                return IsAdded;

            UserID = clsUsers_DAL.AddUser(PersonID, UserName,
                clsUtility_BLL.Decrypt(Password, clsSettings.DeffaultShiftValue), IsActive);

            IsAdded = (UserID != -1);

            return IsAdded;
        }

        private bool _UpdateUser()
        {
            bool IsUpdated = false;

            if (!_CheckData())
                return IsUpdated;

            IsUpdated = clsUsers_DAL.UpdateUser(UserID, PersonID, UserName,
                clsUtility_BLL.Encrypt(Password, clsSettings.DeffaultShiftValue), IsActive);

            return IsUpdated;
        }

        public bool Save() =>
            clsSave_BLL.Save(ref _Mode, _AddUser, _UpdateUser);

        public static clsUsers_BLL FindByUserID(int UserID)
        {
            int PersonID = -1;
            string FullName = "";
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUsers_DAL.GetUserByUserID(UserID, ref PersonID, ref FullName, ref UserName, ref Password, ref IsActive))
                return new clsUsers_BLL(UserID, PersonID, FullName, UserName, Password, IsActive);
            else
                return new clsUsers_BLL();
        }

        public static clsUsers_BLL FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string FullName = "";
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUsers_DAL.GetUserByPersonID(PersonID, ref UserID, ref FullName, ref UserName, ref Password, ref IsActive))
                return new clsUsers_BLL(UserID, PersonID, FullName, UserName, Password, IsActive);
            else
                return new clsUsers_BLL();
        }

        public static clsUsers_BLL FindByUserName(string UserName)
        {
            int PersonID = -1;
            int UserID = -1;
            string FullName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUsers_DAL.GetUserByUserName(UserName, ref UserID, ref PersonID, ref FullName, ref Password, ref IsActive))
                return new clsUsers_BLL(UserID, PersonID, FullName, UserName, Password, IsActive);
            else
                return new clsUsers_BLL();
        }

        public static DataTable GetListOfUsers() =>
            clsUsers_DAL.GetAllUsers();

        public static bool DeleteUser(int UserID) =>
            clsUsers_DAL.DeleteUserByUserID(UserID);

        public static bool DeleteUserByPersonID(int PersonID) =>
            clsUsers_DAL.DeleteUserByPersonID(PersonID);

        public static bool DeleteUserByUserName(string UserName) =>
            clsUsers_DAL.DeleteUserByUserName(UserName);

        public static bool IsUserExist(int UserID) =>
            clsUsers_DAL.IsUserExistByUserID(UserID);

        public static bool IsUserExistByPersonID(int PersonID) =>
            clsUsers_DAL.IsUserExistByPersonID(PersonID);

        public static bool IsUserExistByUserName(string UserName) =>
            clsUsers_DAL.IsUserExistByUserName(UserName);

        bool CheckPassword(string Password) =>
            (clsUtility_BLL.Decrypt(this.Password, clsSettings.DeffaultShiftValue) == Password);

        public void SetPassword(string Password)
        {
            if (_Mode == clsSave_BLL.enMode.New)
                this.Password = Password;
        }

        public void ChangePassword(string NewPassword, string OldPassword)
        {
            if (_Mode == clsSave_BLL.enMode.Existing &&
                    clsUtility_BLL.Decrypt(this.Password, clsSettings.DeffaultShiftValue) == OldPassword)
                this.Password = NewPassword;
        }
    }
}
