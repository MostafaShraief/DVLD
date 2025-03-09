using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsApplicationTypes_DAL
    {
        public enum enApplicationType
        {
            NewLocalLicense = 1, Renew, LostReplacement,
            DamagedReplacement, ReleaseDetained, NewInternational
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; Select 'ID' = ApplicationTypeID, " +
                "'Title' = ApplicationTypeTitle, 'Fees' = ApplicationFees " +
                "From ApplicationTypes;";
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

        public static bool GetApplicationType(int ID, ref string Title, ref float Fees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; Select * From ApplicationTypes Where " +
                "ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    ID = clsUtility_DAL.ConvertObjectToIntID(reader["ApplicationTypeID"]);
                    Title = reader["ApplicationTypeTitle"].ToString();
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateApplicationType(int ID, string Title, float Fees)
        {
            bool IsUpdated = false;

            SqlConnection sqlConnection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[ApplicationTypes] SET " +
                "[ApplicationTypeTitle] = @ApplicationTypeTitle, " +
                "[ApplicationFees] = @ApplicationFees WHERE " +
                "ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

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

        public static float GetApplicationTypeFees(enApplicationType ApplicationTypeID)
        {
            float Fees = 0;

            SqlConnection sqlConnection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Use DVLD; Select Top 1 ApplicationFees From ApplicationTypes Where " +
                "ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ApplicationTypeID", (int)ApplicationTypeID);

            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                float.TryParse(clsUtility_DAL.ConvertObjectToString(result), out Fees);
            }
            finally 
            { 
                sqlConnection.Close();
            }

            return Fees;
        }
    }
}
