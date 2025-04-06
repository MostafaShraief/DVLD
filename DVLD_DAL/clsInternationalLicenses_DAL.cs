using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public class clsInternationalLicenses_DAL
    {
        public static DataTable GetInternationalLicensesByLocalLicenseID(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = @"USE DVLD; 
                            SELECT   
                                InternationalLicenseID AS [International License ID],
                                ApplicationID AS [Application ID],
                                IssuedUsingLocalLicenseID AS [Local License ID],
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
    }
}