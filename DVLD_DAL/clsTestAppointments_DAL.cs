using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsTestAppointments_DAL
    {
        // Method to get all summarized test appointments
        public static DataTable GetAllSummarizedTestAppointments()
        {
            string query = @"
                USE DVLD;
                SELECT 
                    TestAppointmentID AS [Appointment ID], 
                    AppointmentDate AS [Appointment Date], 
                    CASE 
                        WHEN RetakeFees IS NULL THEN TestFees 
                        ELSE TestFees + RetakeFees 
                    END AS [Test Fees], 
                    IsLocked AS [Is Locked]
                FROM TestAppointments;";

            return clsUtility_DAL.GetAllItems(query);
        }

        public static DataTable GetTestAppointmentsByApplicationAndTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
        USE DVLD;
        SELECT 
            TestAppointmentID AS [Appointment ID], 
            AppointmentDate AS [Appointment Date], 
            CASE 
                WHEN RetakeFees IS NULL THEN TestFees 
                ELSE TestFees + RetakeFees 
            END AS [Test Fees], 
            IsLocked AS [Is Locked]
        FROM TestAppointments
        WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
        AND TestAppointments.TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        // Method to get a specific test appointment
        public static DataRow GetTestAppointmentByID(int TestAppointmentID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; Select T.*, TT.TestTypeID From TestAppointment_MyView T Join TestTypes TT ON T.[Test Type Title] = TT.TestTypeTitle Where T.[Test Appointment ID] = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        // Method to add a test appointment
        public static int AddTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal TestFees, int CreatedByUserID, bool IsLocked, decimal RetakeFees)
        {
            int TestAppointmentID = -1;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
                USE [DVLD]; 
                INSERT INTO [dbo].[TestAppointments] ([TestTypeID], [LocalDrivingLicenseApplicationID], 
                [AppointmentDate], [TestFees], [CreatedByUserID], [IsLocked], [RetakeFees]) 
                VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @TestFees, 
                @CreatedByUserID, @IsLocked, @RetakeFees); 
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@TestFees", TestFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@RetakeFees", RetakeFees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                TestAppointmentID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
        }

        // Method to update a test appointment
        public static bool UpdateTestAppointment(int TestAppointmentID, DateTime AppointmentDate)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
        USE [DVLD]; 
        UPDATE [dbo].[TestAppointments] 
        SET [AppointmentDate] = @AppointmentDate 
        WHERE [TestAppointmentID] = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        // Method to check if retake fees are applied
        public static bool IsRetakeFeesApplied(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsApplied = false;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
                USE DVLD; SELECT TOP 1 x = 1 
                FROM TestAppointments T 
                WHERE T.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                AND T.TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                IsApplied = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return IsApplied;
        }

        // Method to count test trials
        public static int GetTestTrialsCount(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int Trials = 0;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
                USE DVLD; SELECT COUNT(*) AS [Trials] 
                FROM TestAppointments TA 
                JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID 
                WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                AND TA.TestTypeID = @TestTypeID 
                AND T.TestResult = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                Trials = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return Trials;
        }

        // Method to check if a test has passed
        public static bool IsTestPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsPassed = false;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
                USE DVLD; SELECT TOP 1 x = 1 
                FROM TestAppointments TA 
                JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID 
                WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                AND TA.TestTypeID = @TestTypeID 
                AND T.TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                IsPassed = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return IsPassed;
        }

        // Method to check if there is an unlocked test appointment
        public static bool IsThereTestAppointmentNotLocked(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsNotLocked = false;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"
                USE DVLD; SELECT TOP 1 x = 1 
                FROM TestAppointments T 
                WHERE T.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                AND T.TestTypeID = @TestTypeID 
                AND T.IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                IsNotLocked = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return IsNotLocked;
        }

        public static bool LockTestAppointment(int testAppointmentID)
        {
            bool isLocked = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                    UPDATE [dbo].[TestAppointments] 
                    SET IsLocked = 1 
                    WHERE [TestAppointmentID] = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isLocked = (rowsAffected > 0);
            }
            finally
            {
                connection.Close();
            }

            return isLocked;
        }

        public static bool? IsTestAppointmentLocked(int testAppointmentID)
        {
            bool? isLocked = null;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                    SELECT TOP 1 IsLocked 
                    FROM TestAppointments 
                    WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isLocked = Convert.ToBoolean(result);
                }
            }
            finally
            {
                connection.Close();
            }

            return isLocked;
        }
    }
}