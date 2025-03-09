using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsLicenseClasses_DAL
    {
        public enum enLicencsesClasses { SmallMotorcycle = 1, HeavyMotorcycleLicense,
            Ordinarydrivinglicense, Commercial, Agricultural, Smallandmediumbus,
            Truckandheavyvehicle
        }

        public static DataTable GetAllLicensesClasses() =>
            clsUtility_DAL.GetAllItems("Use DVLD; Select 'License Class ID' = LC.LicenseClassID, " +
                "'Class Name' = LC.ClassName, 'Class Description' = LC.ClassDescription, " +
                "'Minimum Allowed Age' = LC.MinimumAllowedAge, 'Default Validity Length' = " +
                "LC.DefaultValidityLength, 'Fees' = LC.ClassFees From LicenseClasses LC;");

        public static bool GetLicenseClass(int ID, ref string ClassName, 
            ref string Description, ref short MinimumAge, 
            ref short ValidityLength, ref float Fees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Use DVLD; Select * From LicenseClasses LC Where LC.LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    ID = clsUtility_DAL.ConvertObjectToIntID(reader["LicenseClassID"]);
                    ClassName = reader["ClassName"].ToString();
                    Description = reader["ClassDescription"].ToString();
                    short.TryParse(reader["MinimumAllowedAge"].ToString(), out MinimumAge);
                    short.TryParse(reader["DefaultValidityLength"].ToString(), out ValidityLength);
                    Fees = Convert.ToSingle(reader["ClassFees"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateLicenseClass(int ID, string ClassName,
            string Description, short MinimumAge,
            short ValidityLength, float Fees)
        {
            bool IsUpdated = false;

            SqlConnection sqlConnection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[LicenseClasses] SET [ClassName] = @ClassName, " +
                "[ClassDescription] = @ClassDescription, [MinimumAllowedAge] = @MinimumAllowedAge, " +
                "[DefaultValidityLength] = @DefaultValidityLength, [ClassFees] = @ClassFees WHERE " +
                "[LicenseClassID] = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@LicenseClassID", ID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", Description);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", ValidityLength);
            command.Parameters.AddWithValue("@ClassFees", Fees);

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
    }
}
