using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsDrivers_DAL
    {
        // Method to get all drivers
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT * FROM Drivers_MyView;";
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

        // Method to add a driver
        public static int AddDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; INSERT INTO [dbo].[Drivers] ([PersonID], [CreatedByUserID], [CreatedDate]) VALUES (@PersonID, @CreatedByUserID, @CreatedDate); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                DriverID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }
            return DriverID;
        }

        // Method to check if a person is already a driver
        public static bool IsPersonAlreadyDriver(int PersonID)
        {
            return clsUtility_DAL.CheckIsExist("Drivers", "PersonID", PersonID, true);
        }

        // Method to find driver by Driver ID
        public static DataTable GetDriverByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT * FROM Drivers_MyView D WHERE D.[Driver ID] = @DriverID;";
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

        // Method to find driver by Person ID
        public static DataTable GetDriverByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT * FROM Drivers_MyView D WHERE D.[Person ID] = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        // Method to find driver by National Number
        public static DataTable GetDriverByNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT * FROM Drivers_MyView D WHERE D.[National No] = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
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

        public static int GetPersonIDByDriverID(int driverID)
        {
            // Using your utility class for cleaner code
            string query = "USE DVLD; SELECT TOP 1 D.PersonID FROM Drivers D WHERE D.DriverID = @DriverID;";

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                return clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}