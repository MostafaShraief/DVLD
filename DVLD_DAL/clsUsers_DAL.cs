using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsUsers_DAL
    {
        private static void _FillCommandWithParameters(ref SqlCommand command, int PersonID,
            string UserName, string Password, bool IsActive)
        {
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
        }

        public static int AddUser(int PersonID,
            string UserName, string Password, bool IsActive)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; INSERT INTO [dbo].[Users] ([PersonID]," +
                " [UserName], [Password], [IsActive]) VALUES (@PersonID, @UserName," +
                " @Password, @IsActive); Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            _FillCommandWithParameters(ref command, PersonID,
            UserName, Password, IsActive);

            if (command == null)
                return UserID;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                UserID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT   'User ID' = Users.UserID, 'Person ID' = Users.PersonID," +
                " 'Full Name' = FirstName + ' ' + SecondName + ' ' + (Case When " +
                "ThirdName is not null then ThirdName + ' ' end) + People.LastName, " +
                "Users.UserName, 'Is Active' = Users.IsActive FROM Users INNER JOIN " +
                "People ON Users.PersonID = People.PersonID";
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

        public static bool GetUserByUserID(int UserID, ref int PersonID, ref string FullName,
            ref string UserName, ref string Password, ref bool IsActive)
        {
            if (IsUserExistByUserID(UserID) == false)
                return false;

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE DVLD; SELECT   'User ID' = Users.UserID, 'Person ID' = Users.PersonID, " +
                "'Full Name' = FirstName + ' ' + SecondName + ' ' + " +
                "(Case When ThirdName is not null then ThirdName + ' ' end) + " +
                "People.LastName, Users.UserName, 'Is Active' = Users.IsActive " +
                "FROM Users INNER JOIN People ON Users.PersonID = People.PersonID " +
                "Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    PersonID = Convert.ToInt32(reader["Person ID"]);
                    FullName = reader["Full Name"].ToString();
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["Is Active"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetUserByPersonID(int PersonID, ref int UserID, ref string FullName,
            ref string UserName, ref string Password, ref bool IsActive)
        {
            if (IsUserExistByPersonID(PersonID) == false)
                return false;

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "SELECT   'User ID' = Users.UserID, 'Person ID' = Users.PersonID, " +
                "'Full Name' = FirstName + ' ' + SecondName + ' ' + " +
                "(Case When ThirdName is not null then ThirdName + ' ' end) + " +
                "People.LastName, Users.UserName, 'Is Active' = Users.IsActive " +
                "FROM Users INNER JOIN People ON Users.PersonID = People.PersonID " +
                "Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    UserID = Convert.ToInt32(reader["User ID"]);
                    FullName = reader["Full Name"].ToString();
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["Is Active"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetUserByUserName(string UserName, ref int UserID,
            ref int PersonID, ref string FullName, ref string Password, ref bool IsActive)
        {
            if (IsUserExistByUserID(PersonID) == false)
                return false;

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "SELECT   'User ID' = Users.UserID, 'Person ID' = Users.PersonID, " +
                "'Full Name' = FirstName + ' ' + SecondName + ' ' + " +
                "(Case When ThirdName is not null then ThirdName + ' ' end) + " +
                "People.LastName, Users.UserName, 'Is Active' = Users.IsActive " +
                "FROM Users INNER JOIN People ON Users.PersonID = People.PersonID " +
                "Where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    UserID = Convert.ToInt32(reader["User ID"]);
                    PersonID = Convert.ToInt32(reader["Person ID"]);
                    FullName = reader["Full Name"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["Is Active"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateUser(int UserID, int PersonID,
            string UserName, string Password, bool IsActive)
        {
            if (IsUserExistByUserID(UserID) == false)
                return false;

            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Users] SET [PersonID] " +
                "= @PersonID, [UserName] = @UserName, [Password] = @Password, " +
                "[IsActive] = @IsActive WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            _FillCommandWithParameters(ref command, PersonID, UserName, Password,
                IsActive);

            if (command == null)
                return false;

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

        public static bool DeleteUserByUserID(int UserID) =>
            clsUtility_DAL.DeleteRecord("Users", "UserID", UserID, true);

        public static bool DeleteUserByPersonID(int PersonID) =>
            clsUtility_DAL.DeleteRecord("Users", "UserID", PersonID, true);

        public static bool DeleteUserByUserName(string UserName) =>
            clsUtility_DAL.DeleteRecord("Users", "UserName", UserName, false);

        public static bool IsUserExistByUserID(int UserID) =>
            clsUtility_DAL.CheckIsExist("Users", "UserID", UserID, true);

        public static bool IsUserExistByPersonID(int PersonID) =>
            clsUtility_DAL.CheckIsExist("Users", "NationalNo", PersonID, true);

        public static bool IsUserExistByUserName(string UserName) =>
            clsUtility_DAL.CheckIsExist("Users", "UserName", UserName, false);
    }
}
