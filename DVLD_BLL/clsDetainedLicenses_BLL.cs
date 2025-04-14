using DVLD_DAL;
using System;
using System.Data;

namespace DVLD_BLL
{
    public class clsDetainedLicenses_BLL
    {
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        private clsSave_BLL.enMode _Mode;

        public clsDetainedLicenses_BLL()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
            _Mode = clsSave_BLL.enMode.New;
        }

        private clsDetainedLicenses_BLL(int detainID, int licenseID, DateTime detainDate,
                                    decimal fineFees, int createdByUserID, bool isReleased,
                                    DateTime? releaseDate, int? releasedByUserID,
                                    int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            _Mode = clsSave_BLL.enMode.Existing;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenses_DAL.GetAllDetainedLicenses();
        }

        private bool _Add()
        {
            if (!clsLicenses_BLL.IsLicenseExist(LicenseID) ||
                !clsLicenses_BLL.IsLicenseActiveAndNotDetained(LicenseID) ||
                FineFees <= 0)
                return false;

            bool IsDeactivated = clsLicenses_BLL.DeactivateLicense(LicenseID);

            if (!IsDeactivated)
                return false;

            this.DetainID = clsDetainedLicenses_DAL.AddDetainedLicense(
                this.LicenseID,
                DateTime.Now,
                this.FineFees,
                this.CreatedByUserID,
                false);

            bool IsAdded = (this.DetainID != -1);

            return IsAdded;
        }

        private bool _Update()
        {
            if (ReleasedByUserID == null ||
                !IsQualifiedForRelease(DetainID))
                return false;

            int ApplicationID = clsApplications_BLL.AddApplication(GetPersonIDByDetainID(DetainID),
                clsApplicationTypes_DAL.enApplicationType.ReleaseDetained, (int)ReleasedByUserID);

            if (ApplicationID == -1)
                return false;

            bool IsUpdated = clsDetainedLicenses_DAL.UpdateDetainedLicenseByDetainID(
                this.DetainID,
                true,
                DateTime.Now,
                (int)this.ReleasedByUserID,
                ApplicationID);

            if (!IsUpdated)
            {
                clsApplications_BLL.DeleteApplication(ApplicationID);
                return false;
            }

            return clsLicenses_BLL.ActivateLicense(GetLicenseIDByDetainID(DetainID));
        }

        /// <summary>
        /// Saves the detained license to the database (adds new or updates existing)
        /// </summary>
        /// <returns>True if save succeeded, False if failed</returns>
        /// <remarks>
        /// <para>When adding a new detained license (Mode = New), these values must be set:</para>
        /// <list type="bullet">
        /// <item><description>LicenseID (int) - The ID of the license being detained</description></item>
        /// <item><description>FineFees (decimal) - The fine amount for detention</description></item>
        /// <item><description>CreatedByUserID (int) - ID of user creating the record</description></item>
        /// </list>
        /// <para>When releasing a detained license (Mode = Existing), these values must be set:</para>
        /// <list type="bullet">
        /// <item><description>DetainID (int) - The ID of the detention record</description></item>
        /// <item><description>ReleasedByUserID (int) - ID of user releasing the license</description></item>
        /// </list>
        /// <para>Additional behaviors:</para>
        /// <list type="bullet">
        /// <item><description>For new detentions: Automatically deactivates the associated license</description></item>
        /// <item><description>For releases: Creates release application and reactivates the license</description></item>
        /// <item><description>On failure: Rolls back any partial changes</description></item>
        /// </list>
        /// </remarks>
        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _Add, _Update);
        }

        public static clsDetainedLicenses_BLL Find(int detainID)
        {
            DataRow row = clsDetainedLicenses_DAL.GetDetainedLicenseByDetainID(detainID);
            return _DataRowToDetainedLicense(row);
        }

        //public static DataTable FindByLicenseID(int licenseID)
        //{
        //    DataTable dt = clsDetainedLicenses_DAL.GetDetainedLicenseByLicenseID(licenseID);
        //    return dt;
        //}

        public static int GetPersonIDByDetainID(int detainID)
        {
            // Directly return DAL result (-1 if not found)
            return clsDetainedLicenses_DAL.GetPersonIDByDetainID(detainID);
        }

        public static int GetLicenseIDByDetainID(int detainID)
        {
            // Returns -1 if not found (following your established pattern)
            return clsDetainedLicenses_DAL.GetLicenseIDByDetainID(detainID);
        }

        public static bool IsDetainedLicenseExist(int DetainedLicenseID)
        {
            return clsDetainedLicenses_DAL.IsDetainedLicenseExist(DetainedLicenseID);
        }

        public static int? GetDriverIdByDetainId(int detainId)
        {
            return clsDetainedLicenses_DAL.GetDriverIdByDetainId(detainId);
        }

        public static int GetActiveDetainIDByLicenseID(int licenseID)
        {
            // Returns -1 if license is not currently detained
            return clsDetainedLicenses_DAL.GetActiveDetainIDByLicenseID(licenseID);
        }

        public static bool IsQualifiedForRelease(int detainID)
        {
            // Returns true if:
            // 1. Detention record exists
            // 2. License is not already released
            return clsDetainedLicenses_DAL.IsQualifiedForRelease(detainID);
        }

        private static clsDetainedLicenses_BLL _DataRowToDetainedLicense(DataRow row)
        {
            if (row == null)
                return null;

            return new clsDetainedLicenses_BLL(
                detainID: Convert.ToInt32(row["DetainID"]),
                licenseID: Convert.ToInt32(row["LicenseID"]),
                detainDate: Convert.ToDateTime(row["DetainDate"]),
                fineFees: Convert.ToDecimal(row["FineFees"]),
                createdByUserID: Convert.ToInt32(row["CreatedByUserID"]),
                isReleased: row["IsReleased"] != DBNull.Value && Convert.ToBoolean(row["IsReleased"]),
                releaseDate: row["ReleaseDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["ReleaseDate"]),
                releasedByUserID: row["ReleasedByUserID"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["ReleasedByUserID"]),
                releaseApplicationID: row["ReleaseApplicationID"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["ReleaseApplicationID"])
            );
        }
    }
}