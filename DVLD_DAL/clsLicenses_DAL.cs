using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsLicenses_DAL
    {
        public enum enIssueReason { New = 1, ReplacementForLost = 2, ReplacementForDamaged = 3, Renewal = 4 }

        public static DataTable GetLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"Use DVLD; 
        SELECT 
            L.LicenseID AS [Lic.ID],
            L.ApplicationID AS [App.ID],
            LC.ClassName AS [Class Name],
            L.IssueDate AS [Issue Date],
            L.ExpirationDate AS [Expiration Date],
            L.IsActive AS [Is Active]
        FROM 
            Licenses L
        JOIN 
            LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID";

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

        public static DataTable GetLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"Use DVLD; 
        SELECT 
            L.LicenseID AS [Lic.ID],
            L.ApplicationID AS [App.ID],
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

        public static int AddLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                INSERT INTO [dbo].[Licenses] 
                ([ApplicationID],[DriverID],[LicenseClass],[IssueDate],[ExpirationDate],
                [Notes],[PaidFees],[IsActive],[IssueReason],[CreatedByUserID]) 
                VALUES 
                (@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,
                @Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID); 
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", clsUtility_DAL.ConvertEmptyAndNullableString(Notes));
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", (byte)IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                LicenseID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                UPDATE [dbo].[Licenses] SET 
                [ApplicationID]=@ApplicationID,[DriverID]=@DriverID,[LicenseClass]=@LicenseClass,
                [IssueDate]=@IssueDate,[ExpirationDate]=@ExpirationDate,[Notes]=@Notes,
                [PaidFees]=@PaidFees,[IsActive]=@IsActive,[IssueReason]=@IssueReason,
                [CreatedByUserID]=@CreatedByUserID 
                WHERE [LicenseID]=@LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", clsUtility_DAL.ConvertEmptyAndNullableString(Notes));
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", (byte)IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                IsUpdated = (RowsAffected > 0);
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }

        public static int GetDriverLicenseCount(int DriverID)
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; SELECT COUNT(*) FROM Licenses WHERE DriverID = @DriverID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                Count = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return Count;
        }

        public static DataTable GetLicensesByApplicationID(int ApplicationID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; SELECT * FROM Licenses L WHERE L.ApplicationID = @ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static DataRow FindByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; SELECT * FROM Licenses L WHERE L.LicenseID = @LicenseID;";
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

        public static DataTable GetLicensesByLicenseClass(int LicenseClass)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; SELECT * FROM Licenses L WHERE L.LicenseClass = @LicenseClass;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

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

        public static DataTable GetLicensesByIssueReason(byte IssueReason)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; SELECT * FROM Licenses L WHERE L.IssueReason = @IssueReason;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);

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

        public static DataTable GetLicensesByIsActive(bool IsActive)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; SELECT * FROM Licenses L WHERE L.IsActive = @IsActive;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        // Add these new methods to the existing clsLicenses_DAL class
        public static bool UpdateIsActiveByLicenseID(int LicenseID, bool IsActive)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Licenses] SET [IsActive] = @IsActive WHERE [LicenseID] = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                IsUpdated = (RowsAffected > 0);
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }

        public static bool UpdateIsActiveByApplicationID(int ApplicationID, bool IsActive)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Licenses] SET [IsActive] = @IsActive WHERE [ApplicationID] = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                IsUpdated = (RowsAffected > 0);
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }
    }
}