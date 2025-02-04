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

        public static bool DeleteRecord(string TableName, string WordFilter,
            object objArgument, bool IsInt)
        {
            bool IsDeleted = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = string.Format($"DELETE FROM {TableName} WHERE {WordFilter} = @{WordFilter};");
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

                int RowsAffected = command.ExecuteNonQuery();

                IsDeleted = (RowsAffected > 0);
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
    }
}
