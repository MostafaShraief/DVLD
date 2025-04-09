using DVLD_DAL;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace DVLD_BLL
{
    public class clsLicenses_BLL
    {
        public enum enGender { Male = 0, Female = 1 }
        public enum enIssueReason { New = 1, LostReplacement = 2, DamagedReplacement = 3, Renewal = 4 }

        private clsSave_BLL.enMode _Mode;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsDetained { get; set; }
        public string LicenseClassName { get; set; }
        public string FullName { get; set; }
        public string NationalNumber { get; set; }
        public enGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IssueReasonName { get; set; }

        public clsLicenses_BLL()
        {
            _Mode = clsSave_BLL.enMode.New;
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = true;
            IssueReason = enIssueReason.New;
            CreatedByUserID = -1;
            IsDetained = false;
            LicenseClassName = string.Empty;
            FullName = string.Empty;
            NationalNumber = string.Empty;
            Gender = enGender.Male;
            DateOfBirth = DateTime.MinValue;
            IssueReasonName = string.Empty;
        }

        private clsLicenses_BLL(int licenseID, int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees,
            bool isActive, enIssueReason issueReason, int createdByUserID, bool isDetained,
            string licenseClassName, string fullName, string nationalNumber, enGender gender,
            DateTime dateOfBirth, string issueReasonName)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            IsDetained = isDetained;
            LicenseClassName = licenseClassName;
            FullName = fullName;
            NationalNumber = nationalNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            IssueReasonName = issueReasonName;
        }

        public static DataTable GetLicensesByDriverID(int DriverID)
        {
            DataTable dt = clsLicenses_DAL.GetLicensesByDriverID(DriverID);
            return dt;
        }

        private bool _AddLicense()
        {
            // check if licenes already added
            if (IsLicenseExistForApplication(ApplicationID))
                return false;

            // Add the new license to database
            this.LicenseID = clsLicenses_DAL.AddNewLicense(
                this.ApplicationID,
                this.DriverID,
                this.LicenseClassID,
                this.Notes,
                (clsLicenses_DAL.enIssueReason)this.IssueReason,
                this.CreatedByUserID);

            if (this.LicenseID == -1)
                return false;

            if (clsApplications_BLL.UpdateApplication(ApplicationID,
                (int)clsApplications_DAL.enStatus.Completed) == false)
            {
                // delete license.
                return false;
            }

            // Refresh all properties by finding the newly created license
            clsLicenses_BLL newLicense = Find(this.LicenseID);
            if (newLicense.LicenseID == -1)
                return false;

            // Update current object with all values from database
            this.IssueDate = newLicense.IssueDate;
            this.ExpirationDate = newLicense.ExpirationDate;
            this.PaidFees = newLicense.PaidFees;
            this.IsActive = newLicense.IsActive;
            this.IsDetained = newLicense.IsDetained;
            this.LicenseClassName = newLicense.LicenseClassName;
            this.FullName = newLicense.FullName;
            this.NationalNumber = newLicense.NationalNumber;
            this.Gender = newLicense.Gender;
            this.DateOfBirth = newLicense.DateOfBirth;
            this.IssueReasonName = newLicense.IssueReasonName;

            return true;
        }

        private bool _UpdateIsActive()
        {
            return clsLicenses_DAL.UpdateIsActiveByLicenseID(this.LicenseID, this.IsActive);
        }

        /// <summary>
        /// Saves the current license to the database (adds new or updates existing)
        /// </summary>
        /// <returns>True if save succeeded, False if failed</returns>
        /// <remarks>
        /// <para>When adding a new license (Mode = New), these values must be set:</para>
        /// <list type="bullet">
        /// <item><description>ApplicationID (int)</description></item>
        /// <item><description>DriverID (int)</description></item>
        /// <item><description>LicenseClassID (int)</description></item>
        /// <item><description>Notes (string, optional)</description></item>
        /// <item><description>IssueReason (enIssueReason enum)</description></item>
        /// <item><description>CreatedByUserID (int)</description></item>
        /// </list>
        /// <para>When updating (Mode = Existing), these values must be set:</para>
        /// <list type="bullet">
        /// <item><description>LicenseID (int)</description></item>
        /// <item><description>IsActive (bool)</description></item>
        /// </list>
        /// <para>Values will refilled after add</para>
        /// </remarks>
        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _AddLicense, _UpdateIsActive);
        }

        public static clsLicenses_BLL Find(int licenseID)
        {
            DataRow row = clsLicenses_DAL.GetLicenseByLicenseID(licenseID);

            if (row != null)
            {
                return _MapDataRowToLicense(row);
            }
            else
            {
                return new clsLicenses_BLL();
            }
        }

        public static clsLicenses_BLL FindByApplicationID(int applicationID)
        {
            DataRow row = clsLicenses_DAL.GetLicenseByApplicationID(applicationID);

            if (row != null)
            {
                return _MapDataRowToLicense(row);
            }
            else
            {
                return new clsLicenses_BLL();
            }
        }

        private static clsLicenses_BLL _MapDataRowToLicense(DataRow row)
        {
            int licenseID = Convert.ToInt32(row["License ID"]);
            int applicationID = Convert.ToInt32(row["Application ID"]);
            int driverID = Convert.ToInt32(row["Driver ID"]);
            string fullName = row["Full Name"].ToString();
            string nationalNumber = row["National Number"].ToString();
            enGender gender = (enGender)Enum.Parse(typeof(enGender), row["Gender"].ToString());
            DateTime dateOfBirth = Convert.ToDateTime(row["Date Of Birth"]);
            int LicenseCLassID = Convert.ToInt32(row["License Class ID"]);
            string licenseClassName = row["License Class Name"].ToString();
            DateTime issueDate = Convert.ToDateTime(row["Issue Date"]);
            DateTime expirationDate = Convert.ToDateTime(row["Expiration Date"]);
            string notes = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString();
            float paidFees = Convert.ToSingle(row["Paid Fees"]);
            bool isActive = Convert.ToBoolean(row["Is Active"]);
            enIssueReason issueReason = (enIssueReason)Convert.ToInt32(row["Issue Reason"]);
            string issueReasonName = row["Issue Reason Name"].ToString();
            int createdByUserID = Convert.ToInt32(row["Created By User ID"]);
            bool isDetained = Convert.ToBoolean(row["Is Detained"]);

            return new clsLicenses_BLL(
                licenseID, applicationID, driverID, LicenseCLassID,
                issueDate, expirationDate, notes, paidFees,
                isActive, issueReason, createdByUserID, isDetained,
                licenseClassName, fullName, nationalNumber, gender,
                dateOfBirth, issueReasonName);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenses_DAL.GetAllLicenses();
        }

        public static bool DeactivateLicense(int licenseID)
        {
            clsLicenses_BLL license = Find(licenseID);
            if (license.LicenseID == -1)
                return false;

            license.IsActive = false;
            return license.Save();
        }

        public static bool ActivateLicense(int licenseID)
        {
            clsLicenses_BLL license = Find(licenseID);
            if (license.LicenseID == -1)
                return false;

            license.IsActive = true;
            return license.Save();
        }

        public static bool IsLicenseActive(int licenseID)
        {
            return clsLicenses_DAL.IsActiveByLicenseID(licenseID);
        }

        public static bool IsLicenseActiveByApplicationID(int applicationID)
        {
            return clsLicenses_DAL.IsActiveByApplicationID(applicationID);
        }

        public static bool IsLicenseExistForApplication(int applicationID)
        {
            return clsLicenses_DAL.IsLicenseExistForApplication(applicationID);
        }

        public string GetLicenseStatus()
        {
            if (!IsActive)
                return "Inactive";
            if (IsDetained)
                return "Detained";
            return "Active";
        }

        public static bool IsLicenseExist(int licenseID)
        {
            return clsLicenses_DAL.IsLicenseExist(licenseID);
        }

        public static bool IsLicenseActiveAndBelongToLicenseClass(int licenseID, int licenseClass)
        {
            return clsLicenses_DAL.IsLicenseActiveAndBelongToLicenseClass(licenseID, licenseClass);
        }

        // Optional: Overload with enum if you have LicenseClass enum
        public static bool IsLicenseActiveAndBelongToLicenseClass(int licenseID, clsLicenseClasses_DAL.enLicencsesClasses licenseClass)
        {
            return clsLicenses_DAL.IsLicenseActiveAndBelongToLicenseClass(licenseID, (int)licenseClass);
        }

        public static bool IsLicenseQualifiedToInternationalLicense(int licenseId)
        {
            return IsLicenseActiveAndBelongToLicenseClass(licenseId, clsLicenseClasses_DAL.enLicencsesClasses.Ordinary_Driving_License);
        }
    }
}