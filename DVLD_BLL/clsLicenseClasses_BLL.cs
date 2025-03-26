using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsLicenseClasses_BLL
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        short MinimumAge { get; set; }
        short ValidityLength { get; set; }
        public float ClassFees { get; set; }
        clsSave_BLL.enMode _Mode;

        public clsLicenseClasses_BLL()
        {
            LicenseClassID = -1;
            ClassName = Description = string.Empty;
            MinimumAge = ValidityLength = 0;
            ClassFees = 0;
            _Mode = clsSave_BLL.enMode.New;
        }

        private clsLicenseClasses_BLL(int LicenseClassID, string ClassName,
            string Description, short MinimumAge, short ValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.Description = Description;
            this.MinimumAge = MinimumAge;
            this.ValidityLength = ValidityLength;
            this.ClassFees = ClassFees;
            this._Mode = clsSave_BLL.enMode.Existing;
        }

        public static DataTable GetListOfTestLicenseClasses() =>
            clsLicenseClasses_DAL.GetAllLicensesClasses();

        public static clsLicenseClasses_BLL Find(int LicenseClassID)
        {
            string ClassName = "";
            string Description = "";
            short MinimumAge = 0, ValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClasses_DAL.GetLicenseClass(LicenseClassID,
                ref ClassName, ref Description, ref MinimumAge, ref ValidityLength, ref ClassFees))
                return new clsLicenseClasses_BLL(LicenseClassID,
                    ClassName, Description, MinimumAge, ValidityLength, ClassFees);
            else
                return new clsLicenseClasses_BLL(); // Return an empty object if not found
        }

        bool _CheckData()
        {
            bool IsValid = false;

            if (_Mode == clsSave_BLL.enMode.Existing &&
                ClassName.Length <= 50 &&
                Description.Length <= 500 &&
                MinimumAge <= 100 &&
                ValidityLength <= 100 &&
                ClassFees >= 0)
                IsValid = true;

            return IsValid;
        }

        private bool UpdateTestType()
        {
            bool IsUpdated = false;

            // Check if data is valid before proceeding
            if (_CheckData() == false)
                return false; // If data is invalid, return false

            // Attempt to update the Test type in the database
            IsUpdated = clsLicenseClasses_DAL.UpdateLicenseClass(LicenseClassID,
                ClassName, Description, MinimumAge, ValidityLength, ClassFees);

            return IsUpdated;
            return IsUpdated;
        }

        public bool Save() =>
            clsSave_BLL.Save(ref _Mode, null, UpdateTestType);
    }
}
