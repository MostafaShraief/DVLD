using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsApplications_DAL
    {
        public enum enStatus { New = 1, Cancelled, Completed }

        /// <summary>
        /// Retrieves all applications with detailed information.
        /// </summary>
        /// <returns>DataTable containing all application details.</returns>
        public static DataTable GetAllApplicationsDetails()
        {
            string query = @"
                SELECT 
                    Applications.ApplicationID, Applications.ApplicantPersonID,
                    P.FirstName + ' ' + P.SecondName + ' ' + 
                        (CASE WHEN P.ThirdName IS NOT NULL THEN P.ThirdName + ' ' ELSE '' END) + P.LastName AS [Full Name],
                    Applications.ApplicationDate,
                    AT.ApplicationTypeTitle,
                    CASE Applications.ApplicationStatus
                        WHEN 1 THEN 'New'
                        WHEN 2 THEN 'Canceled'
                        WHEN 3 THEN 'Completed'
                        ELSE 'Unknown'
                    END AS ApplicationStatus,
                    Applications.LastStatusDate,
                    Applications.PaidFees,
                    u.UserName
                FROM 
                    Applications
                INNER JOIN 
                    People P ON Applications.ApplicantPersonID = P.PersonID
                LEFT JOIN 
                    ApplicationTypes AT ON Applications.ApplicationTypeID = AT.ApplicationTypeID
                JOIN 
                    Users u ON u.UserID = Applications.CreatedByUserID;";

            return clsUtility_DAL.GetAllItems(query);
        }

        /// <summary>
        /// Retrieves detailed information for a specific application by ID.
        /// </summary>
        /// <param name="ApplicationID">The ID of the application.</param>
        /// <returns>DataRow containing the application details.</returns>
        public static DataRow GetApplicationDetailsByID(int ApplicationID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
                USE DVLD; SELECT 
                    Applications.ApplicationID, Applications.ApplicantPersonID,
                    P.FirstName + ' ' + P.SecondName + ' ' + 
                        (CASE WHEN P.ThirdName IS NOT NULL THEN P.ThirdName + ' ' ELSE '' END) + P.LastName AS [Full Name],
                    Applications.ApplicationDate,
                    AT.ApplicationTypeTitle,
                    CASE Applications.ApplicationStatus
                        WHEN 1 THEN 'New'
                        WHEN 2 THEN 'Canceled'
                        WHEN 3 THEN 'Completed'
                        ELSE 'Unknown'
                    END AS ApplicationStatus,
                    Applications.LastStatusDate,
                    Applications.PaidFees,
                    u.UserName
                FROM 
                    Applications
                INNER JOIN 
                    People P ON Applications.ApplicantPersonID = P.PersonID
                LEFT JOIN 
                    ApplicationTypes AT ON Applications.ApplicationTypeID = AT.ApplicationTypeID
                JOIN 
                    Users u ON u.UserID = Applications.CreatedByUserID
                WHERE 
                    Applications.ApplicationID = @ApplicationID;";

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

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static int AddApplication(int ApplicantPersonID,
            clsApplicationTypes_DAL.enApplicationType ApplicationType, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; INSERT INTO [dbo].[Applications] ([ApplicantPersonID], " +
                "[ApplicationDate], [ApplicationTypeID], [ApplicationStatus], [LastStatusDate], " +
                "[PaidFees], [CreatedByUserID]) VALUES (@ApplicantPersonID, @ApplicationDate, " +
                "@ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, " +
                "@CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationTypeID", (int)ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", (int)enStatus.New);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@PaidFees", 
                clsApplicationTypes_DAL.GetApplicationTypeFees(ApplicationType));
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                ApplicationID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

        public static DataTable GetAllApplications() =>
            clsUtility_DAL.GetAllItems("Use DVLD; Select 'Application ID ' = A.ApplicationID, " +
                "A.ApplicantPersonID As 'Application Person ID', A.ApplicationDate As " +
                "'Application Date', A.ApplicationTypeID As 'Application Type ID', " +
                "A.ApplicationStatus As 'Application Status', A.LastStatusDate As " +
                "'Last Status Date', A.PaidFees As 'Paid Fees', 'Created By User ID' " +
                "= A.CreatedByUserID From Applications A;");

        public static bool GetApplication(int ApplicationID, ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref clsApplicationTypes_DAL.enApplicationType ApplicationTypeID, ref enStatus ApplicationStatus,
            ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Use DVLD; Select * From Applications Where ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    ApplicantPersonID = clsUtility_DAL.ConvertObjectToIntID(reader["ApplicantPersonID"]);
                    DateTime.TryParse(reader["ApplicationDate"].ToString(), out ApplicationDate);
                    ApplicationTypeID = (clsApplicationTypes_DAL.enApplicationType)Convert.ToSByte(reader["ApplicationTypeID"]);
                    ApplicationStatus = (enStatus)Convert.ToSByte(reader["ApplicationStatus"]);
                    float.TryParse(reader["PaidFees"].ToString(), out PaidFees);
                    DateTime.TryParse(reader["LastStatusDate"].ToString(), out LastStatusDate);
                    CreatedByUserID = clsUtility_DAL.ConvertObjectToIntID(reader["CreatedByUserID"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateApplication(int ApplicationID, enStatus ApplicationStatus)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Applications] SET [ApplicationStatus] = " +
                "@ApplicationStatus, [LastStatusDate] = @LastStatusDate WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", (int)ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", (short)ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

        public static bool UpdateApplication(string SelectQueryStatement, SqlCommand command, enStatus ApplicationStatus)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Applications] SET [ApplicationStatus] = " +
                "@ApplicationStatus, [LastStatusDate] = @LastStatusDate WHERE ApplicationID = (" + SelectQueryStatement + ") and ApplicationStatus = 1";
            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@ApplicationStatus", (short)ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

        public static bool IsApplicationExistByID(int ApplicationID) =>
            clsUtility_DAL.CheckIsExist("Applications", "ApplicationID", ApplicationID, true);

        public static float GetApplicationFees(int ApplicatonId)
        {
            float Fees = 0;

            object result = clsUtility_DAL.GetTop1Value(ApplicatonId, "Applications", "PaidFees", "ApplicationID");

            if (result != null)
                Fees = Convert.ToSingle(result);

            return Fees;
        }

        public static bool DeleteApplication(int ApplicationId) =>
            clsUtility_DAL.DeleteRecord("Applications", "ApplicationID", ApplicationId, true);

        public static byte? GetApplicationStatus(int applicationID)
        {
            byte? status = null;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT TOP 1 ApplicationStatus FROM Applications WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    status = Convert.ToByte(result);
                }
            }
            finally
            {
                connection.Close();
            }

            return status;
        }
    }
}
