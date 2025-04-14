using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsLicenses_DAL
    {
        public enum enGender { Male = 0, Female = 1 }
        public enum enIssueReason { New = 1, LostReplacement = 2, DamagedReplacement = 3, Renewal = 4 }

        public static DataTable GetAllLicenses()
        {
            string query = "USE DVLD; SELECT * FROM GetLicensesTable_View;";
            return clsUtility_DAL.GetAllItems(query);
        }

        public static DataRow GetLicenseByLicenseID(int licenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                            SELECT   
                                Licenses.LicenseID AS [License ID],
                                Licenses.ApplicationID AS [Application ID],
                                Licenses.DriverID AS [Driver ID],
	                            Licenses.LicenseClass AS [License Class ID],
                                People.FirstName + ' ' + People.SecondName + ' ' + (CASE WHEN People.ThirdName IS NOT NULL THEN People.ThirdName + ' ' ELSE '' END) + People.LastName AS [Full Name],
                                People.NationalNo AS [National Number],
                                People.Gender AS [Gender],
                                People.DateOfBirth AS [Date Of Birth],
                                LC.ClassName AS [License Class Name],
                                Licenses.IssueDate AS [Issue Date],
                                Licenses.ExpirationDate AS [Expiration Date],
                                Licenses.Notes AS [Notes],
                                Licenses.PaidFees AS [Paid Fees],
                                Licenses.IsActive AS [Is Active],
                                Licenses.IssueReason AS [Issue Reason],
                                CASE Licenses.IssueReason WHEN 1 THEN 'New' WHEN 2 THEN 'Lost replacement' WHEN 3 THEN 'Damaged replacement' WHEN 4 THEN 'Renewal' END AS [Issue Reason Name],
                                Licenses.CreatedByUserID AS [Created By User ID],
                                CASE 
                                    WHEN (SELECT TOP 1 x = 1 
                                        FROM DetainedLicenses D 
                                        WHERE D.LicenseID = Licenses.LicenseID 
                                        AND D.IsReleased = 0) IS NULL 
                                    THEN 0 
                                    ELSE 1
                                END AS [Is Detained]
                            FROM Licenses 
                            INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID 
                            INNER JOIN People ON Drivers.PersonID = People.PersonID 
                            INNER JOIN LicenseClasses LC ON LC.LicenseClassID = Licenses.LicenseClass
                            Where LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataRow GetLicenseByApplicationID(int applicationID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                            SELECT   
                                Licenses.LicenseID AS [License ID],
                                Licenses.ApplicationID AS [Application ID],
                                Licenses.DriverID AS [Driver ID],
	                            Licenses.LicenseClass AS [License Class ID],
                                People.FirstName + ' ' + People.SecondName + ' ' + (CASE WHEN People.ThirdName IS NOT NULL THEN People.ThirdName + ' ' ELSE '' END) + People.LastName AS [Full Name],
                                People.NationalNo AS [National Number],
                                People.Gender AS [Gender],
                                People.DateOfBirth AS [Date Of Birth],
                                LC.ClassName AS [License Class Name],
                                Licenses.IssueDate AS [Issue Date],
                                Licenses.ExpirationDate AS [Expiration Date],
                                Licenses.Notes AS [Notes],
                                Licenses.PaidFees AS [Paid Fees],
                                Licenses.IsActive AS [Is Active],
                                Licenses.IssueReason AS [Issue Reason],
                                CASE Licenses.IssueReason WHEN 1 THEN 'New' WHEN 2 THEN 'Lost replacement' WHEN 3 THEN 'Damaged replacement' WHEN 4 THEN 'Renewal' END AS [Issue Reason Name],
                                Licenses.CreatedByUserID AS [Created By User ID],
                                CASE 
                                    WHEN (SELECT TOP 1 x = 1 
                                        FROM DetainedLicenses D 
                                        WHERE D.LicenseID = Licenses.LicenseID 
                                        AND D.IsReleased = 0) IS NULL 
                                    THEN 0 
                                    ELSE 1
                                END AS [Is Detained]
                            FROM Licenses 
                            INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID 
                            INNER JOIN People ON Drivers.PersonID = People.PersonID 
                            INNER JOIN LicenseClasses LC ON LC.LicenseClassID = Licenses.LicenseClass
                            WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static int AddNewLicense(int applicationID, int driverID, int licenseClass,
            string notes, enIssueReason issueReason, int createdByUserID, float paidFees)
        {
            int licenseID = -1;

            // Calculate automatic values
            DateTime issueDate = DateTime.Now;
            int validityLength = clsLicenseClasses_DAL.GetLicenseClassValidityLength(licenseClass);
            DateTime expirationDate = issueDate.AddYears(validityLength);
            bool isActive = true;
            //float paidFees = issueReason == enIssueReason.New ? 0 :
            //    clsApplicationTypes_DAL.GetApplicationTypeFees((clsApplicationTypes_DAL.enApplicationType)issueReason);

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                            INSERT INTO [dbo].[Licenses] 
                            ([ApplicationID], [DriverID], [LicenseClass], [IssueDate], 
                            [ExpirationDate], [Notes], [PaidFees], [IsActive], [IssueReason], [CreatedByUserID]) 
                            VALUES 
                            (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, 
                            @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID); 
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseClass);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? DBNull.Value : (object)notes);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@IssueReason", (byte)issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                licenseID = Convert.ToInt32(result);
            }
            finally
            {
                connection.Close();
            }

            return licenseID;
        }

        public static bool UpdateIsActiveByLicenseID(int licenseID, bool isActive)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; UPDATE Licenses SET IsActive = @IsActive WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isUpdated = (rowsAffected > 0);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool UpdateIsActiveByApplicationID(int applicationID, bool isActive)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; UPDATE Licenses SET IsActive = @IsActive WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isUpdated = (rowsAffected > 0);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool IsActiveByLicenseID(int licenseID)
        {
            bool isActive = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 x = 1 
                    FROM Licenses 
                    WHERE LicenseID = @LicenseID 
                    AND IsActive = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                isActive = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return isActive;
        }

        public static bool IsActiveByApplicationID(int applicationID)
        {
            bool isActive = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 x = 1 
                    FROM Licenses 
                    WHERE ApplicationID = @ApplicationID 
                    AND IsActive = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                isActive = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return isActive;
        }

    public static bool IsQualifiedToIssueLicense(int applicationID)
    {
        string query = @"USE DVLD; SELECT TOP 1 x = 1 
                    FROM Applications A 
                    JOIN LocalDrivingLicenseApplications LD ON A.ApplicationID = LD.ApplicationID 
                    LEFT JOIN Licenses L ON L.ApplicationID = A.ApplicationID 
                    WHERE A.ApplicationID = @ApplicationID 
                    AND A.ApplicationStatus = 1 And A.ApplicationTypeID = 1 
                    AND L.LicenseID IS NULL And (SELECT COUNT(*) 
                    FROM dbo.TestAppointments AS TA 
                    INNER JOIN dbo.Tests AS T ON TA.TestAppointmentID = T.TestAppointmentID
                    WHERE TA.LocalDrivingLicenseApplicationID = LD.LocalDrivingLicenseApplicationID 
                    AND T.TestResult = 1) = 3";

        SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ApplicationID", applicationID);

        try
        {
            connection.Open();
            object result = command.ExecuteScalar();
            return (result != null);
        }
        finally
        {
            connection.Close();
        }
    }

    public static DataTable GetLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"Use DVLD; 
        SELECT 
            L.LicenseID AS [License ID],
            L.ApplicationID AS [Application ID],
            LC.ClassName AS [Class Name],
            L.IssueDate AS [Issue Date],
            L.ExpirationDate AS [Expiration Date],
            L.IsActive AS [Is Active]
        FROM 
            Licenses L
        JOIN 
            LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID
        WHERE 
            L.DriverID = @DriverID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool IsLicenseExist(int licenseID)
        {
            bool exists = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 x = 1 
                    FROM Licenses 
                    WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                exists = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return exists;
        }

        public static bool IsLicenseActiveAndBelongToLicenseClass(int licenseID, int licenseClass)
        {
            bool exists = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 x = 1 
                    FROM Licenses 
                    WHERE LicenseID = @LicenseID 
                    AND LicenseClass = @LicenseClass 
                    AND IsActive = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            command.Parameters.AddWithValue("@LicenseClass", licenseClass);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                exists = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return exists;
        }

        public static bool DoesLicenseExist(int licenseID)
        {
            string query = "USE DVLD; SELECT TOP 1 x = 1 FROM Licenses WHERE LicenseID = @LicenseID";
            SqlParameter parameter = new SqlParameter("@LicenseID", licenseID);
            return clsUtility_DAL.ExecuteScalarToBool(query, parameter);
        }

        public static bool IsLicenseQualifiedForRenewal(int licenseID)
        {
            string query = @"USE DVLD; SELECT TOP 1 x = 1 FROM Licenses L 
                            WHERE L.LicenseID = @LicenseID 
                            AND L.IsActive = 0 
                            AND (Select Top 1 x = 1 From DetainedLicenses D Where D.LicenseID = 
                            L.LicenseID and D.IsReleased = 0) is null;";

            SqlParameter parameter = new SqlParameter("@LicenseID", licenseID);
            return clsUtility_DAL.ExecuteScalarToBool(query, parameter);
        }

        public static bool IsLicenseActiveAndNotDetained(int licenseID)
        {
            string query = @"USE DVLD; SELECT TOP 1 x = 1 FROM Licenses L 
                            WHERE L.LicenseID = @LicenseID 
                            AND L.IsActive = 1
                            AND (Select Top 1 x = 1 From DetainedLicenses D Where D.LicenseID = 
                            L.LicenseID and D.IsReleased = 0) is null;";

            SqlParameter parameter = new SqlParameter("@LicenseID", licenseID);
            return clsUtility_DAL.ExecuteScalarToBool(query, parameter);
        }

        public static int GetLastLicenseIDForDriver(int driverID, int licenseClass)
        {
            string query = @"USE DVLD; SELECT TOP 1 LicenseID FROM Licenses 
                          WHERE DriverID = @DriverID 
                          AND LicenseClass = @LicenseClass 
                          ORDER BY IssueDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@DriverID", driverID),
                new SqlParameter("@LicenseClass", licenseClass)
            };

            return clsUtility_DAL.ExecuteScalarToInt(query, parameters);
        }

        public static bool HasActiveOrDetainedLicense(int driverID, int licenseClass, int excludeLicenseID)
        {
            string query = @"USE DVLD; SELECT TOP 1 x = 1 FROM Licenses L 
                          LEFT JOIN DetainedLicenses D ON L.LicenseID = D.LicenseID 
                          WHERE L.LicenseID != @ExcludeLicenseID 
                          AND L.DriverID = @DriverID 
                          AND L.LicenseClass = @LicenseClass 
                          AND (L.IsActive = 1 OR (D.DetainID IS NOT NULL AND D.IsReleased = 0))";

            SqlParameter[] parameters = {
                new SqlParameter("@DriverID", driverID),
                new SqlParameter("@LicenseClass", licenseClass),
                new SqlParameter("@ExcludeLicenseID", excludeLicenseID)
            };

            return clsUtility_DAL.ExecuteScalarToBool(query, parameters);
        }
    }
}