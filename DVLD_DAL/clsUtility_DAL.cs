﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    internal class clsUtility_DAL
    {
        public static Func<string, object> ConvertEmptyAndNullableString =
            (str) => ((str != null && str != string.Empty) ? (object)str : DBNull.Value);

        public static int ConvertObjectToIntID (object result)
        {
            int Value;
            return ((result != null &&
                int.TryParse(result.ToString(), out Value) ?
                Value : -1));
        }

        public static Func<object, string> ConvertObjectToString =
            (obj) => ((obj != DBNull.Value && obj != null) ? obj.ToString() : string.Empty);

        public static DataTable GetAllItems(string query)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
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

        public static bool DeleteRecord(string TableName, string WordFilter,
            object objArgument, bool IsInt)
        {
            bool IsDeleted = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = string.Format($"Use DVLD; DELETE FROM {TableName} WHERE {WordFilter} = @{WordFilter};");
            SqlCommand command = new SqlCommand(query, connection);

            if (IsInt)
            {
                int Value = ConvertObjectToIntID(objArgument);
                command.Parameters.AddWithValue("@" + WordFilter, Value);
            }
            else
            {
                if (objArgument != null || objArgument != DBNull.Value)
                    command.Parameters.AddWithValue("@" + WordFilter, Convert.ToString(objArgument));
            }

            try
            {
                connection.Open();

                using (command)
                {
                    int RowsAffected = command.ExecuteNonQuery();

                    IsDeleted = (RowsAffected > 0);
                }
            }
            catch
            {
                IsDeleted = false;
            }
            finally
            {
                connection.Close();
            }

            return IsDeleted;
        }

        public static bool CheckIsExist(string TableName, string WordFilter,
            object objArgument, bool IsInt)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = String.Format($"Use DVLD; Select Top 1 a = 0 From {TableName} Where {WordFilter} = @{WordFilter};");
            SqlCommand command = new SqlCommand(query, connection);

            if (IsInt)
            {
                int Value = ConvertObjectToIntID(objArgument);
                command.Parameters.AddWithValue("@" + WordFilter, Value);
            }
            else
            {
                if (objArgument != null || objArgument != DBNull.Value)
                    command.Parameters.AddWithValue("@" + WordFilter, Convert.ToString(objArgument));
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsExist = (result != null);
            }
            finally
            {
                connection.Close();
            }

            return IsExist;
        }

        public static bool IsValueAlreadyExist(string Value, int ID,
            string Table, string ValueName, string IDName)
        {
            // this method is used to natinal no or username to ensure no duplicate values.
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = $"use dvld; select top 1 x = 1 From {Table} " +
                $"where {ValueName} = @{ValueName} and {IDName} != @{IDName};";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@" + ValueName, Value);
            command.Parameters.AddWithValue("@" + IDName, ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                IsExist = (clsUtility_DAL.ConvertObjectToIntID(result) == 1);
            }
            finally
            {
                connection.Close();
            }

            return IsExist;
        }

        public static bool IsValueAlreadyExist(int Value, int ID,
            string Table, string ValueName, string IDName)
        {
            // this method is used to natinal no or username to ensure no duplicate values.
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = $"use dvld; select top 1 x = 1 From {Table}" +
                $" where {ValueName} = @{ValueName} and {IDName} != @{IDName};";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@" + ValueName, Value);
            command.Parameters.AddWithValue("@" + IDName, ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                IsExist = (clsUtility_DAL.ConvertObjectToIntID(result) == 1);
            }
            finally
            {
                connection.Close();
            }

            return IsExist;
        }

        public static object GetTop1Value(int ID,
            string Table, string ValueName, string IDName)
        {
            // this method is used to natinal no or username to ensure no duplicate values.
            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = $"use dvld; select top 1 {ValueName} From {Table} " +
                $"where {IDName} = @{IDName};";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@" + IDName, ID);

            object result = null;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        // Helper methods
        public static bool ExecuteScalarToBool(string query, params SqlParameter[] parameters)
        {
            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) == 1;
        }

        public static int ExecuteScalarToInt(string query, params SqlParameter[] parameters)
        {
            object result = ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static bool ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static DataTable GetAllItems(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch
                {
                    // Return empty DataTable on error
                }
            }

            return dt;
        }

        public static DataRow ExecuteRow(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();

                    // Create a reader with SingleRow command behavior
                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (!reader.HasRows)
                            return null;

                        // Create a minimal DataTable with correct schema
                        DataTable tempTable = new DataTable();
                        tempTable.Load(reader);

                        return tempTable.Rows.Count > 0 ? tempTable.Rows[0] : null;
                    }
                }
                catch (Exception ex)
                {
                    // Log error if needed
                    // clsLogger.LogError(ex);
                    return null;
                }
            }
        }
    }
}
