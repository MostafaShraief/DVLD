using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsApplicationType_BLL
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationFees { get; set; }
        clsSave_BLL.enMode _Mode { get; set; }

        public clsApplicationType_BLL()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = string.Empty;
            ApplicationFees = 0;
            _Mode = clsSave_BLL.enMode.New;
        }

        private clsApplicationType_BLL(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationFees = applicationFees;
            this._Mode = clsSave_BLL.enMode.Existing;
        }

        public static DataTable GetListOfApplicationTypes() =>
            clsApplicationTypes_DAL.GetAllApplicationTypes();

        public static clsApplicationType_BLL Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;

            if (clsApplicationTypes_DAL.GetApplicationType(ApplicationTypeID,
                ref ApplicationTypeTitle, ref ApplicationFees))
                return new clsApplicationType_BLL(ApplicationTypeID, 
                    ApplicationTypeTitle, ApplicationFees);
            else
                return new clsApplicationType_BLL(); // Return an empty object if not found
        }

        bool _CheckData()
        {
            bool IsValid = false;

            if (_Mode == clsSave_BLL.enMode.Existing &&
                clsUtility_BLL.Characters.AllLanguages.ValidateOnlyLettersWithSpaces(ApplicationTypeTitle) &&
                ApplicationFees >= 0)
                IsValid = true;

            return IsValid;
        }

        public bool UpdateApplicationType()
        {
            bool IsUpdated = false;

            // Check if data is valid before proceeding
            if (_CheckData() == false)
                return false; // If data is invalid, return false

            // Attempt to update the application type in the database
            IsUpdated = clsApplicationTypes_DAL.UpdateApplicationType(ApplicationTypeID, 
                ApplicationTypeTitle, ApplicationFees);

            return IsUpdated;
        }
    }
}
