using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DAL.clsApplications_DAL;
using static System.Net.Mime.MediaTypeNames;
using static DVLD_DAL.clsLicenseClasses_DAL;

namespace DVLD_DAL
{
    public class clsLocalDrivingLicenseApplication_DAL
    {
        public static DataTable GetAllRecords() =>
            clsUtility_DAL.GetAllItems("Use DVLD; Select * From GetLocalLicenseTable_View;");

        public static bool GetLocalLicense(
            int LocalDrivingLicenseApplicationID,
            ref int ApplicationID,
            ref int LicenseClassID,
            ref string DrivingClassName,
            ref string NationalNumber,
            ref string FullName,
            ref DateTime ApplicationDate,
            ref byte PassedTest,
            ref enStatus Status,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);

            // Query to get the local driving license application details
            string query = @"
        USE DVLD;
        SELECT 
            dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS [L.D.L.AppID],
            dbo.LocalDrivingLicenseApplications.ApplicationID AS [ApplicationID],
            dbo.LocalDrivingLicenseApplications.LicenseClassID AS [LicenseClassID],
            dbo.LicenseClasses.ClassName AS [Class Name],
            P.NationalNo AS [National Number],
            P.FirstName + ' ' + P.SecondName + ' ' + 
                (CASE WHEN P.ThirdName IS NOT NULL THEN P.ThirdName + ' ' ELSE '' END) + P.LastName AS [Full Name],
            dbo.Applications.ApplicationDate AS [Application Date],
            (SELECT COUNT(*) 
            FROM dbo.TestAppointments AS TA 
            INNER JOIN dbo.Tests AS T ON TA.TestAppointmentID = T.TestAppointmentID
            WHERE TA.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
            AND T.TestResult = 1) AS [Passed Tests],
            Applications.ApplicationStatus As Status,
            dbo.Applications.CreatedByUserID AS [CreatedByUserID]
        FROM 
            dbo.LocalDrivingLicenseApplications 
            INNER JOIN dbo.Applications ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID
            INNER JOIN dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID
            INNER JOIN dbo.People AS P ON dbo.Applications.ApplicantPersonID = P.PersonID
        WHERE 
            dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    // Assign values to the referenced parameters
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                    DrivingClassName = reader["Class Name"].ToString();
                    NationalNumber = reader["National Number"].ToString();
                    FullName = reader["Full Name"].ToString();
                    ApplicationDate = Convert.ToDateTime(reader["Application Date"]);
                    PassedTest = Convert.ToByte(reader["Passed Tests"]);
                    Status = (enStatus)Convert.ToByte(reader["Status"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddLocalLicense(int ApplicationID, 
            clsLicenseClasses_DAL.enLicencsesClasses LicencseClass)
        {
            int LocalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; INSERT INTO [dbo].[LocalDrivingLicenseApplications] ([ApplicationID], " +
                "[LicenseClassID]) VALUES (@ApplicationID, @LicenseClassID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", (int)LicencseClass);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                LocalLicenseID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return LocalLicenseID;
        }

        public static bool ChangeStatusByLocalLicenseID(int LocalLicenseID, enStatus status)
        {
            string selectQuery = "(Select Top 1 ApplicationID From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalLicenseID)";
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("LocalLicenseID", LocalLicenseID);
            return clsApplications_DAL.UpdateApplication(selectQuery, command, status);
        }

        public static bool ChangeStatusByApplicationID(int ApplicationID, enStatus status) =>
            clsApplications_DAL.UpdateApplication(ApplicationID, status);

        // check if person have more than one completed local license for specific license class.
        public static bool CheckExistLicense(int ApplicantPersonID, enLicencsesClasses LicenseClassID)
        {
            bool IsExist = true;

            string query = "USE DVLD; Select top 1 x = 1 From LocalDrivingLicenseApplications l join Applications a " +
                "on l.ApplicationID = a.ApplicationID where a.ApplicantPersonID = @ApplicantPersonID and " +
                "l.LicenseClassID = @LicenseClassID and a.ApplicationStatus in (1, 3)";
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@LicenseClassID", (Byte)LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsExist = (result != null);
            }
            finally
            {
                connection.Close();
            }
            return IsExist;
        }

        public static Byte CountPassedTests(int localDrivingLicenseApplicationID)
        {
            Byte passedTestsCount = 0;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD;
                    SELECT COUNT(*) 
                    FROM dbo.TestAppointments AS TA 
                    INNER JOIN dbo.Tests AS T ON TA.TestAppointmentID = T.TestAppointmentID
                    WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                    AND T.TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                passedTestsCount = Convert.ToByte(result);
            }
            finally
            {
                connection.Close();
            }

            return passedTestsCount;
        }

        public static byte? GetApplicationStatus(int localDrivingLicenseApplicationID)
        {
            byte? applicationStatus = null;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 A.ApplicationStatus 
                    FROM LocalDrivingLicenseApplications L 
                    JOIN Applications A ON L.ApplicationID = A.ApplicationID 
                    WHERE L.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    applicationStatus = Convert.ToByte(result);
                }
            }
            finally
            {
                connection.Close();
            }

            return applicationStatus;
        }

        public static int GetLicenseIDByLocalDrivingLicenseAppID(int localDrivingLicenseApplicationID)
        {
            int licenseID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP (1) L.LicenseID
                    FROM LocalDrivingLicenseApplications LA 
                    INNER JOIN Licenses L ON L.ApplicationID = LA.ApplicationID
                    WHERE LA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    licenseID = Convert.ToInt32(result);
                }
            }
            finally
            {
                connection.Close();
            }

            return licenseID;
        }

        public static bool DeleteLocaWlDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            return clsUtility_DAL.DeleteRecord("LocalDrivingLicenseApplications",
                            "LocalDrivingLicenseApplicationID",
                            localDrivingLicenseApplicationID, true);
        }

        public static int GetLocalDrivingLicenseAppIDByApplicationID(int applicationID)
        {
            int localAppID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 LocalDrivingLicenseApplicationID 
                    FROM LocalDrivingLicenseApplications 
                    WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    localAppID = Convert.ToInt32(result);
                }
            }
            finally
            {
                connection.Close();
            }

            return localAppID;
        }

        //public static bool DeleteLocalLicense()
        //{
        //    bool IsDeleted = false;



        //    if (clsApplications_DAL.DeleteApplication())
        //}
    }
}
