using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsInternationalLicenses_DAL
    {
        public static DataRow GetInternationalLicenseDetails(int internationalLicenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT   
                        I.InternationalLicenseID, 
                        I.ApplicationID, 
                        I.DriverID, 
                        I.LicenseID, 
                        I.IssueDate, 
                        I.ExpirationDate, 
                        I.IsActive, 
                        I.CreatedByUserID, 
                        People.NationalNo, 
                        People.FirstName + ' ' + People.SecondName + ' ' + 
                            (CASE WHEN People.ThirdName IS NOT NULL THEN People.ThirdName + ' ' ELSE '' END) + 
                            People.LastName AS [FullName], 
                        People.DateOfBirth, 
                        People.Gender,
                        People.ImagePath, 
                        Licenses.IssueReason, 
                        Licenses.Notes,
                        A.ApplicationDate,
                        A.PaidFees
                    FROM InternationalLicenses AS I 
                    INNER JOIN Licenses ON I.LicenseID = Licenses.LicenseID 
                    INNER JOIN Drivers ON I.DriverID = Drivers.DriverID 
                    INNER JOIN People ON Drivers.PersonID = People.PersonID
					INNER JOIN Applications A On A.ApplicationID = I.ApplicationID
                    WHERE I.InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

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

        public static DataTable GetAllSammurizedInternationicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                      SELECT   
                          InternationalLicenseID AS [International License ID],
                          ApplicationID AS [Application ID],
                          DriverID AS [Driver ID],
                          LicenseID AS [License ID],
                          IssueDate AS [Issue Date],
                          ExpirationDate AS [Expiration Date],
                          IsActive AS [Is Active]
                      FROM InternationalLicenses I";

            SqlCommand command = new SqlCommand(query, connection);

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

        public static DataTable GetInternationalLicensesByLicenseID(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                      SELECT   
                          InternationalLicenseID AS [International License ID],
                          ApplicationID AS [Application ID],
                          LicenseID AS [Local License ID],
                          IssueDate AS [Issue Date],
                          ExpirationDate AS [Expiration Date],
                          IsActive AS [Is Active]
                      FROM InternationalLicenses I
                      Where I.DriverID = @DriverID;";

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

        public static DataRow GetByInternationalLicenseID(int internationalLicenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; SELECT I.*, A.ApplicationDate As [Application Created Date], A.PaidFees
                           FROM InternationalLicenses I 
                           JOIN Applications A ON I.ApplicationID = A.ApplicationID 
                           WHERE I.InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

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

        public static DataRow GetByApplicationID(int applicationID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; SELECT I.*, A.ApplicationDate As [Application Created Date] , A.PaidFees
                           FROM InternationalLicenses I 
                           JOIN Applications A ON I.ApplicationID = A.ApplicationID 
                           WHERE I.ApplicationID = @ApplicationID";

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

        public static DataRow GetByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; SELECT I.*, A.ApplicationDate As [Application Created Date], A.PaidFees
                           FROM InternationalLicenses I 
                           JOIN Applications A ON I.ApplicationID = A.ApplicationID 
                           WHERE I.LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static int Add(int applicationID, int driverID, int LicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int internationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                           INSERT INTO [dbo].[InternationalLicenses] 
                           ([ApplicationID], [DriverID], [LicenseID], [IssueDate], 
                           [ExpirationDate], [IsActive], [CreatedByUserID]) 
                           VALUES 
                           (@ApplicationID, @DriverID, @LicenseID, @IssueDate, 
                           @ExpirationDate, @IsActive, @CreatedByUserID); 
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                internationalLicenseID = Convert.ToInt32(result);
            }
            finally
            {
                connection.Close();
            }

            return internationalLicenseID;
        }

        public static bool UpdateIsActive(int internationalLicenseID, bool isActive)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                           UPDATE [dbo].[InternationalLicenses] 
                           SET [IsActive] = @IsActive 
                           WHERE [InternationalLicenseID] = @InternationalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);
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
    }
}