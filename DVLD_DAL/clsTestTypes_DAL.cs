using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsTestTypes_DAL
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; Select 'ID' = TestTypeID, " +
                "'Title' = TestTypeTitle, 'Description' = TestTypeDescription, 'Fees' = TestTypeFees " +
                "From TestTypes;";
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

        public static bool GetTestType(int ID, ref string Title, ref string Description, ref float Fees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; Select * From TestTypes Where " +
                "TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    ID = clsUtility_DAL.ConvertObjectToIntID(reader["TestTypeID"]);
                    Title = reader["TestTypeTitle"].ToString();
                    Description = reader["TestTypeDescription"].ToString();
                    Fees = Convert.ToSingle(reader["TestTypeFees"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateTestType(int ID, string Title, string Description, float Fees)
        {
            bool IsUpdated = false;

            SqlConnection sqlConnection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[TestTypes] SET " +
                "[TestTypeTitle] = @TestTypeTitle, [TestTypeDescription] = @TestTypeDescription," +
                "[TestTypeFees] = @TestTypeFees WHERE " +
                "TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@TestTypeID", ID);
            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);

            try
            {
                sqlConnection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                IsUpdated = (RowsAffected > 0);
            }
            finally
            {
                sqlConnection.Close();
            }

            return IsUpdated;
        }

        public static decimal GetTestTypeFees(int TestTypeID)
        {
            decimal Fees = 0;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT TOP 1 TestTypeFees FROM TestTypes T WHERE T.TestTypeID = @TestTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out Fees))
                {
                    return Fees;
                }
            }
            finally
            {
                connection.Close();
            }

            return Fees; // Return 0 if no fees are found or an error occurs.
        }
    }
}
