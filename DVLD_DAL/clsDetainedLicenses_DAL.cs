using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsDetainedLicenses_DAL
    {
        public static DataTable GetAllDetainedLicenses()
        {
            string query = @"USE DVLD; SELECT D.DetainID As [D.ID], D.LicenseID AS [L.ID], 
                           D.DetainDate AS [D.Date], D.IsReleased [Is Released], 
                           D.FineFees AS [Fine Fees], D.ReleaseDate AS [Release Date], 
                           P.NationalNo AS [N.NO], 
                           P.FirstName + ' ' + P.SecondName + ' ' + 
                           (CASE WHEN P.ThirdName IS NOT NULL THEN P.ThirdName + ' ' ELSE '' END) + P.LastName AS [Full Name], 
                           D.ReleaseApplicationID AS [Release App.ID]
                           FROM DetainedLicenses D
                           INNER JOIN Licenses L ON D.LicenseID = L.LicenseID 
                           INNER JOIN Drivers DR ON L.DriverID = DR.DriverID 
                           INNER JOIN People P ON DR.PersonID = P.PersonID";

            return clsUtility_DAL.GetAllItems(query);
        }

        public static int AddDetainedLicense(int licenseID, DateTime detainDate,
                                           decimal fineFees, int createdByUserID,
                                           bool isReleased)
        {
            string query = @"USE DVLD; INSERT INTO [dbo].[DetainedLicenses]
                           ([LicenseID], [DetainDate], [FineFees], 
                           [CreatedByUserID], [IsReleased])
                           VALUES
                           (@LicenseID, @DetainDate, @FineFees, 
                           @CreatedByUserID, @IsReleased);
                           SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@LicenseID", licenseID),
                new SqlParameter("@DetainDate", detainDate),
                new SqlParameter("@FineFees", fineFees),
                new SqlParameter("@CreatedByUserID", createdByUserID),
                new SqlParameter("@IsReleased", isReleased)
            };

            return clsUtility_DAL.ExecuteScalarToInt(query, parameters);
        }

        public static bool UpdateDetainedLicenseByLicenseID(int licenseID, bool isReleased,
                                                          DateTime? releaseDate,
                                                          int? releasedByUserID,
                                                          int? releaseApplicationID)
        {
            string query = @"USE DVLD; UPDATE [dbo].[DetainedLicenses]
                           SET [IsReleased] = @IsReleased,
                               [ReleaseDate] = @ReleaseDate,
                               [ReleasedByUserID] = @ReleasedByUserID,
                               [ReleaseApplicationID] = @ReleaseApplicationID
                           WHERE [LicenseID] = @LicenseID";

            SqlParameter[] parameters = {
                new SqlParameter("@LicenseID", licenseID),
                new SqlParameter("@IsReleased", isReleased),
                new SqlParameter("@ReleaseDate", releaseDate ?? (object)DBNull.Value),
                new SqlParameter("@ReleasedByUserID", releasedByUserID ?? (object)DBNull.Value),
                new SqlParameter("@ReleaseApplicationID", releaseApplicationID ?? (object)DBNull.Value)
            };

            return clsUtility_DAL.ExecuteNonQuery(query, parameters);
        }

        public static bool UpdateDetainedLicenseByDetainID(int detainID, bool isReleased,
                                                        DateTime? releaseDate,
                                                        int? releasedByUserID,
                                                        int? releaseApplicationID)
        {
            string query = @"USE DVLD; UPDATE [dbo].[DetainedLicenses]
                           SET [IsReleased] = @IsReleased,
                               [ReleaseDate] = @ReleaseDate,
                               [ReleasedByUserID] = @ReleasedByUserID,
                               [ReleaseApplicationID] = @ReleaseApplicationID
                           WHERE [DetainID] = @DetainID";

            SqlParameter[] parameters = {
                new SqlParameter("@DetainID", detainID),
                new SqlParameter("@IsReleased", isReleased),
                new SqlParameter("@ReleaseDate", releaseDate ?? (object)DBNull.Value),
                new SqlParameter("@ReleasedByUserID", releasedByUserID ?? (object)DBNull.Value),
                new SqlParameter("@ReleaseApplicationID", releaseApplicationID ?? (object)DBNull.Value)
            };

            return clsUtility_DAL.ExecuteNonQuery(query, parameters);
        }

        //public static DataRow GetDetainedLicenseByDetainID(int detainID)
        //{
        //    string query = @"USE DVLD; SELECT D.DetainID, D.LicenseID, D.DetainDate, U.UserName, 
        //                A.PaidFees, D.FineFees, A.ApplicationID
        //                FROM DetainedLicenses D 
        //                INNER JOIN Users U ON D.CreatedByUserID = U.UserID 
        //                LEFT JOIN Applications A ON A.ApplicationID = D.ReleaseApplicationID
        //                WHERE D.DetainID = @DetainID";

        //    return clsUtility_DAL.ExecuteRow(query,
        //        new SqlParameter("@DetainID", detainID));
        //}

        //public static DataTable GetDetainedLicenseByLicenseID(int licenseID)
        //{
        //    string query = @"USE DVLD; SELECT D.DetainID, D.LicenseID, D.DetainDate, U.UserName, 
        //                    A.PaidFees, D.FineFees, A.ApplicationID
        //                    FROM DetainedLicenses D 
        //                    INNER JOIN Users U ON D.CreatedByUserID = U.UserID 
        //                    LEFT JOIN Applications A ON A.ApplicationID = D.ReleaseApplicationID
        //                    WHERE D.LicenseID = @LicenseID";

        //    DataTable dt = clsUtility_DAL.GetAllItems(query,
        //        new SqlParameter("@LicenseID", licenseID));

        //    return dt;
        //}

        public static int GetPersonIDByDetainID(int detainID)
        {
            string query = @"USE DVLD; SELECT TOP (1) People.PersonID
                           FROM DetainedLicenses 
                           INNER JOIN Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID 
                           INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID 
                           INNER JOIN People ON Drivers.PersonID = People.PersonID
                           WHERE DetainID = @DetainID";

            SqlParameter parameter = new SqlParameter("@DetainID", detainID);
            return clsUtility_DAL.ExecuteScalarToInt(query, parameter);
        }

        public static int GetLicenseIDByDetainID(int detainID)
        {
            string query = "USE DVLD; SELECT TOP (1) LicenseID FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlParameter parameter = new SqlParameter("@DetainID", detainID);
            return clsUtility_DAL.ExecuteScalarToInt(query, parameter);
        }

        public static bool IsDetainedLicenseExist(int DetainedLicenseID)
        {
            string query = @"
                USE DVLD; Select Top 1 x = 1 From DetainedLicenses D Where D.DetainID = @DetainID";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@DetainID", DetainedLicenseID)
            };

            // ExecuteScalar returns the first column of the first row, or null if no results
            var result = clsUtility_DAL.ExecuteScalar(query, parameters);
            return result != null; // Returns true if a detained record exists
        }

        public static bool IsDetainedLicenseExistByLicenseID(int DetainedLicenseID)
        {
            string query = @"
                USE DVLD; Select Top 1 x = 1 From DetainedLicenses D Where D.DetainID = @DetainID";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@DetainID", DetainedLicenseID)
            };

            // ExecuteScalar returns the first column of the first row, or null if no results
            var result = clsUtility_DAL.ExecuteScalar(query, parameters);
            return result != null; // Returns true if a detained record exists
        }

        public static int? GetDriverIdByDetainId(int detainId)
        {
            string query = @"
            USE DVLD; SELECT TOP 1 L.DriverID 
            FROM DetainedLicenses D 
            JOIN Licenses L ON D.LicenseID = L.LicenseID 
            WHERE D.DetainID = @DetainID";

            var parameters = new SqlParameter[]
            {
            new SqlParameter("@DetainID", detainId)
            };

            // ExecuteScalar returns the first column of the first row (DriverID), or null if no match
            var result = clsUtility_DAL.ExecuteScalar(query, parameters);

            return result != null ? Convert.ToInt32(result) : (int?)null;
        }

        public static int GetActiveDetainIDByLicenseID(int licenseID)
        {
            string query = @"USE DVLD; SELECT TOP 1 D.DetainID 
                           FROM DetainedLicenses D 
                           WHERE D.LicenseID = @LicenseID 
                           AND D.IsReleased = 0";

            SqlParameter parameter = new SqlParameter("@LicenseID", licenseID);
            return clsUtility_DAL.ExecuteScalarToInt(query, parameter);
        }

        public static bool IsQualifiedForRelease(int detainID)
        {
            string query = @"USE DVLD; SELECT TOP 1 D.DetainID 
                           FROM DetainedLicenses D 
                           WHERE D.DetainID = @DetainID 
                           AND D.IsReleased = 0";

            SqlParameter parameter = new SqlParameter("@DetainID", detainID);
            int result = clsUtility_DAL.ExecuteScalarToInt(query, parameter);
            return result != -1; // Returns true if found (not released), false otherwise
        }

        public static DataRow GetDetainedLicenseByDetainID(int detainID)
        {
            string query = "USE DVLD; SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlParameter parameter = new SqlParameter("@DetainID", detainID);
            return clsUtility_DAL.ExecuteRow(query, parameter);
        }
    }
}