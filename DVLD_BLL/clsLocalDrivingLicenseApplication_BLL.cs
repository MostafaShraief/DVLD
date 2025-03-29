using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsLocalDrivingLicenseApplication_BLL
    {
        // Properties
        public int LocalDrivingLicenseApplicationID { get; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public string DrivingClassName { get; }
        public string NationalNumber { get; }
        public string FullName { get; }
        public DateTime ApplicationDate { get; }
        public Byte PassedTest { get; }
        public Byte Status { get; }
        public int CreatedByUserID { get; set; }
        private clsSave_BLL.enMode _Mode;


        // Constructor for new mode
        public clsLocalDrivingLicenseApplication_BLL()
        {
            LocalDrivingLicenseApplicationID = -1; // Default value for new mode
            ApplicationID = -1; // Default value
            LicenseClassID = -1; // Default value
            DrivingClassName = ""; // Default value
            NationalNumber = ""; // Default value
            FullName = ""; // Default value
            ApplicationDate = DateTime.MinValue; // Default value
            PassedTest = 0; // Default value
            Status = 1; // Default value
            CreatedByUserID = -1; // Default value
            _Mode = clsSave_BLL.enMode.New; // Set mode to New
        }

        // Constructor for existing mode
        private clsLocalDrivingLicenseApplication_BLL(
            int localDrivingLicenseApplicationID,
            int applicationID,
            int licenseClassID,
            string drivingClassName,
            string nationalNumber,
            string fullName,
            DateTime applicationDate,
            byte passedTest,
            Byte status,
            int createdByUserID)
        {
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.ApplicationID = applicationID;
            this.LicenseClassID = licenseClassID;
            this.DrivingClassName = drivingClassName;
            this.NationalNumber = nationalNumber;
            this.FullName = fullName;
            this.ApplicationDate = applicationDate;
            this.PassedTest = passedTest;
            this.Status = status;
            this.CreatedByUserID = createdByUserID;
            _Mode = clsSave_BLL.enMode.Existing; // Set mode to Existing
        }

        public static DataTable GetAllLocalLicenses() =>
            clsLocalDrivingLicenseApplication_DAL.GetAllRecords();

        // Private method to add a new local driving license application
        public static int Add(int PersonId, Byte LicenseClassID, int CreatedByUserId)
        {
            //if (_CheckData())
            //    return false; // If data is corrupted, return false.

            // Step 1: Check if the person already has a completed local license for the specified license class.
            if (clsLocalDrivingLicenseApplication_DAL.CheckExistLicense(PersonId, 
                (clsLicenseClasses_DAL.enLicencsesClasses)LicenseClassID))
            {
                // Business rule violation: The person already has a completed license for this class.
                return -1; // Return -1 to indicate failure due to an existing license.
            }

            // Step 2: Add application before add local license.
            int ApplicationID = clsApplications_DAL.AddApplication(PersonId,
                clsApplicationTypes_DAL.enApplicationType.NewLocalLicense, CreatedByUserId);

            if (ApplicationID == -1) // check if ID is valid
                return -1; // Add procces failed.. not completed

            // Step 3: Add the local driving license application to the database table.
            int newLocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplication_DAL.AddLocalLicense(ApplicationID, 
                (clsLicenseClasses_DAL.enLicencsesClasses)LicenseClassID);

            return newLocalDrivingLicenseApplicationID; // Return the ID of the newly added local driving license application.
        }

        // Private method to update an existing local driving license application
        //private bool _UpdateLocalDrivingLicenseApplication()
        //{
        //    //if (_CheckData() == false)
        //    //    return false; // If data is corrupted, return false.

        //    //// Update the local driving license application in the database table.
        //    //return clsLocalDrivingLicenseApplication_DAL.ChangeStatusByLocalLicenseID(LocalDrivingLicenseApplicationID, );
        //    return false;
        //}

        //// Public method to save the local driving license application
        //public bool Save()
        //{
        //    return clsSave_BLL.Save(ref _Mode, Add, _UpdateLocalDrivingLicenseApplication);
        //}

        // Private method to check if data is valid
        //private static bool _CheckData()
        //{
        //    // Ensure ApplicationID and LicenseClassID are valid.
        //    return ApplicationID > 0 && LicenseClassID > 0;
        //}

        public static bool CancelLocalLicenseOrder(int LocalLicenseId) =>
            clsLocalDrivingLicenseApplication_DAL.ChangeStatusByLocalLicenseID(LocalLicenseId, clsApplications_DAL.enStatus.Cancelled);

        public bool CancelLocalLicenseOrder()
        {
            if (_Mode == clsSave_BLL.enMode.New)
                return false;

            return clsLocalDrivingLicenseApplication_DAL.ChangeStatusByApplicationID(ApplicationID, clsApplications_DAL.enStatus.Cancelled);
        }

        public static clsLocalDrivingLicenseApplication_BLL Find(int LocalDrivingLicenseApplicationID)
        {
            // Initialize variables to hold retrieved data
            int applicationID = -1;
            int licenseClassID = -1;
            string drivingClassName = "";
            string nationalNumber = "";
            string fullName = "";
            DateTime applicationDate = DateTime.MinValue;
            byte passedTest = 0;
            clsApplications_DAL.enStatus status = clsApplications_DAL.enStatus.New;
            int createdByUserID = -1;

            // Call the GetLocalLicense function to retrieve data
            bool isFound = clsLocalDrivingLicenseApplication_DAL.GetLocalLicense(
                LocalDrivingLicenseApplicationID,
                ref applicationID,
                ref licenseClassID,
                ref drivingClassName,
                ref nationalNumber,
                ref fullName,
                ref applicationDate,
                ref passedTest,
                ref status,
                ref createdByUserID);

            // If data is found, return a new clsLocalDrivingLicenseApplication_BLL object
            if (isFound)
            {
                return new clsLocalDrivingLicenseApplication_BLL(
                    LocalDrivingLicenseApplicationID,
                    applicationID,
                    licenseClassID,
                    drivingClassName,
                    nationalNumber,
                    fullName,
                    applicationDate,
                    passedTest,
                    (Byte)status,
                    createdByUserID);
            }
            else
            {
                // If no data is found, return a new object with default values
                return new clsLocalDrivingLicenseApplication_BLL();
            }
        }

        // Method to check if a person has more than one completed local license for a specific license class.
        public static bool CheckExistLicense(int ApplicantPersonID, Byte LicenseClassID)
        {
            // Call the DAL method to check if the license exists.
            return clsLocalDrivingLicenseApplication_DAL.CheckExistLicense(ApplicantPersonID, (clsLicenseClasses_DAL.enLicencsesClasses)LicenseClassID);
        }
    }
}
