using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DAL.clsApplications_DAL;
using static System.Net.Mime.MediaTypeNames;

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
            CASE 
                WHEN Applications.ApplicationStatus = 1 THEN 'New' 
                WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled' 
                WHEN Applications.ApplicationStatus = 3 THEN 'Completed' 
                ELSE NULL 
            END AS Status,
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

        public static int AddLocalLicense(int ApplicantPersonID, 
            clsLicenseClasses_DAL.enLicencsesClasses LicencseClass,
            int CreatedByUserID)
        {
            int ApplicationID = clsApplications_DAL.AddApplication(ApplicantPersonID,
                clsApplicationTypes_DAL.enApplicationType.NewLocalLicense, CreatedByUserID);

            if (ApplicationID == -1) // check if ID is valid
                return -1; // Add procces failed.. not completed

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
    }
}
