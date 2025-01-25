using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsPeople_DAL
    {
        private enum _enGender { enMale, enFemale }

        private static void _FillCommandWithParameters(ref SqlCommand command, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, Byte Gender,
            string Address, string Phone, string Email, int NationalityCountryID,
            string ImagePath)
        {
            if (Gender == ((Byte)_enGender.enMale) ||
                Gender == ((Byte)_enGender.enFemale))
                command.Parameters.AddWithValue("@Gender", Gender);
            else
            {
                command = null;
                return;
            }

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", clsUtility_DAL.ConvertEmptyAndNullableString(ThirdName));
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", clsUtility_DAL.ConvertEmptyAndNullableString(Email));
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", clsUtility_DAL.ConvertEmptyAndNullableString(ImagePath));
        }

        public static int AddPerson(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, Byte Gender,
            string Address, string Phone, string Email, int NationalityCountryID,
            string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "INSERT INTO [dbo].[People]([NationalNo],[FirstName]," +
                "[SecondName],[ThirdName],[LastName],[DateOfBirth],[Gender],[Address]," +
                "[Phone],[Email],[NationalityCountryID],[ImagePath]) VALUES(@NationalNo," +
                "@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address," +
                "@Phone,@Email,@NationalityCountryID,@ImagePath); Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            _FillCommandWithParameters(ref command, NationalNo, FirstName,SecondName,
                ThirdName, LastName, DateOfBirth, Gender,
                Address, Phone, Email, NationalityCountryID,
                ImagePath);

            if (command == null)
                return PersonID;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                PersonID = clsUtility_DAL.ConvertObjectToInt(result);
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Select * From People;";
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

        public static bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref Byte Gender,
            ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID,
            ref string ImagePath)
        {
            if (IsPersonExist(PersonID) == false)
                return false;

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Select * From People Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = clsUtility_DAL.ConvertObjectToString(reader["ThirdName"]);
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gender = Convert.ToByte(reader["Gender"]);
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = clsUtility_DAL.ConvertObjectToString(reader["Email"]);
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    ImagePath = clsUtility_DAL.ConvertObjectToString(reader["ImagePath"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetPersonByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
        ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref Byte Gender,
        ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID,
        ref string ImagePath)
        {
            if (IsPersonExist(NationalNo) == false)
                return false;

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Select * From People Where NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = clsUtility_DAL.ConvertObjectToString(reader["ThirdName"]);
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gender = Convert.ToByte(reader["Gender"]);
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = clsUtility_DAL.ConvertObjectToString(reader["Email"]);
                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    ImagePath = clsUtility_DAL.ConvertObjectToString(reader["ImagePath"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, Byte Gender,
            string Address, string Phone, string Email, int NationalityCountryID,
            string ImagePath)
        {
            if (IsPersonExist(PersonID) == false)
                return false;

            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "UPDATE [dbo].[People] SET [NationalNo] = @NationalNo," +
                "[FirstName] = @FirstName,[SecondName] = @SecondName," +
                "[ThirdName] = @ThirdName,[LastName] = @LastName,[DateOfBirth] = @DateOfBirth," +
                "[Gender] = @Gender,[Address] = @Address,[Phone] = @Phone," +
                "[Email] = @Email,[NationalityCountryID] = @NationalityCountryID," +
                "[ImagePath] = @ImagePath WHERE PersonID = @PersonID;";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            _FillCommandWithParameters(ref command, NationalNo, FirstName, SecondName,
                ThirdName, LastName, DateOfBirth, Gender,
                Address, Phone, Email, NationalityCountryID,
                ImagePath);

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

        public static bool DeletePerson(int PersonID)
        {
            return clsUtility_DAL.DeleteRecord("People", "PersonID", PersonID);
        }

        public static bool DeletePerson(string NationalNo)
        {
            return clsUtility_DAL.DeleteRecord("People", "PersonID", NationalNo);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsUtility_DAL.CheckIsExist("People", "PersonID", PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsUtility_DAL.CheckIsExist("People", "NationalNo", NationalNo);
        }
    }
}
