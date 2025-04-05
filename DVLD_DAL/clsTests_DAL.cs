using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsTests_DAL
    {
        public static DataTable GetAllTests()
        {
            string query = "USE DVLD; SELECT * FROM Tests;";
            return clsUtility_DAL.GetAllItems(query);
        }

        public static DataRow GetTestByID(int testID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT * FROM Tests WHERE TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", testID);

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

        public static DataRow GetTestByAppointmentID(int testAppointmentID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT TOP 1 * FROM Tests WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

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


        public static int AddTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int testID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE [DVLD]; 
                INSERT INTO [dbo].[Tests] 
                ([TestAppointmentID], [TestResult], [Notes], [CreatedByUserID]) 
                VALUES 
                (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID); 
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@TestResult", testResult);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? DBNull.Value : (object)notes);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                testID = Convert.ToInt32(result);
            }
            finally
            {
                connection.Close();
            }

            return testID;
        }
    }
}