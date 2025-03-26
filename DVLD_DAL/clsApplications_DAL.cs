using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsApplications_DAL
    {
        public enum enStatus { New = 1, Cancelled, Completed }

        //private static void _FillCommandWithParameters(ref SqlCommand command, int ApplicantPersonID,
        //    DateTime ApplicationDate, enApplicationType ApplicationTypeID, enStatus ApplicationStatus,
        //    int CreatedByUserID)
        //{
        //    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
        //    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
        //    command.Parameters.AddWithValue("@ApplicationTypeID", (int)ApplicationTypeID);
        //    command.Parameters.AddWithValue("@ApplicationStatus", (int)ApplicationStatus);
        //    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
        //    command.Parameters.AddWithValue("@PaidFees", clsApplicationTypes_DAL.GetApplicationTypeFees((int)ApplicationTypeID));
        //    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
        //}

        public static int AddApplication(int ApplicantPersonID,
            clsApplicationTypes_DAL.enApplicationType ApplicationType, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; INSERT INTO [dbo].[Applications] ([ApplicantPersonID], " +
                "[ApplicationDate], [ApplicationTypeID], [ApplicationStatus], [LastStatusDate], " +
                "[PaidFees], [CreatedByUserID]) VALUES (@ApplicantPersonID, @ApplicationDate, " +
                "@ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, " +
                "@CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationTypeID", (int)ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", (int)enStatus.New);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@PaidFees", 
                clsApplicationTypes_DAL.GetApplicationTypeFees(ApplicationType));
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                ApplicationID = clsUtility_DAL.ConvertObjectToIntID(result);
            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

        public static DataTable GetAllApplications() =>
            clsUtility_DAL.GetAllItems("Use DVLD; Select 'Application ID ' = A.ApplicationID, " +
                "A.ApplicantPersonID As 'Application Person ID', A.ApplicationDate As " +
                "'Application Date', A.ApplicationTypeID As 'Application Type ID', " +
                "A.ApplicationStatus As 'Application Status', A.LastStatusDate As " +
                "'Last Status Date', A.PaidFees As 'Paid Fees', 'Created By User ID' " +
                "= A.CreatedByUserID From Applications A;");

        public static bool GetApplication(int ApplicationID, ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref clsApplicationTypes_DAL.enApplicationType ApplicationTypeID, ref enStatus ApplicationStatus,
            ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "Use DVLD; Select * From Applications Where ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    ApplicantPersonID = clsUtility_DAL.ConvertObjectToIntID(reader["ApplicantPersonID"]);
                    DateTime.TryParse(reader["ApplicationDate"].ToString(), out ApplicationDate);
                    ApplicationTypeID = (clsApplicationTypes_DAL.enApplicationType)Convert.ToSByte(reader["ApplicationTypeID"]);
                    ApplicationStatus = (enStatus)Convert.ToSByte(reader["ApplicationStatus"]);
                    float.TryParse(reader["PaidFees"].ToString(), out PaidFees);
                    DateTime.TryParse(reader["LastStatusDate"].ToString(), out LastStatusDate);
                    CreatedByUserID = clsUtility_DAL.ConvertObjectToIntID(reader["CreatedByUserID"]);
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        //public static bool GetApplicationByPersonID(int ApplicantPersonID, ref int ApplicationID, ref DateTime ApplicationDate, 
        //    ref enApplicationType ApplicationTypeID, ref enStatus ApplicationStatus,
        //    ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        //{
        //    bool IsFound = false;

        //    SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
        //    string query = "Use DVLD; Select * From Applications Where ApplicantPersonID = @ApplicantPersonID;";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            IsFound = true;
        //            ApplicationID = clsUtility_DAL.ConvertObjectToIntID(reader["ApplicationID"]);
        //            DateTime.TryParse(reader["ApplicationDate"].ToString(), out ApplicationDate);
        //            ApplicationTypeID = (enApplicationType)Convert.ToSByte(reader["ApplicationTypeID"]);
        //            ApplicationStatus = (enStatus)Convert.ToSByte(reader["ApplicationStatus"]);
        //            float.TryParse(reader["PaidFees"].ToString(), out PaidFees);
        //            DateTime.TryParse(reader["LastStatusDate"].ToString(), out LastStatusDate);
        //            CreatedByUserID = clsUtility_DAL.ConvertObjectToIntID(reader["CreatedByUserID"]);
        //        }

        //        reader.Close();
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return IsFound;
        //}

        //public static bool GetApplicationByNationalNumber(ref string NatuinalNo, ref int ApplicationID, ref int ApplicantPersonID,
        //    ref DateTime ApplicationDate, ref enApplicationType ApplicationTypeID, ref enStatus ApplicationStatus,
        //    ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        //{
        //    bool IsFound = false;

        //    SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
        //    string query = "USE DVLD; SELECT Applications.* FROM Applications INNER JOIN " +
        //        "People ON Applications.ApplicantPersonID = People.PersonID WHERE NationalNo = @NationalNo;";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@NatuinalNo", NatuinalNo);

        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            IsFound = true;
        //            ApplicationID = clsUtility_DAL.ConvertObjectToIntID(reader["ApplicationID"]);
        //            ApplicantPersonID = clsUtility_DAL.ConvertObjectToIntID(reader["ApplicantPersonID"]);
        //            DateTime.TryParse(reader["ApplicationDate"].ToString(), out ApplicationDate);
        //            ApplicationTypeID = (enApplicationType)Convert.ToSByte(reader["ApplicationTypeID"]);
        //            ApplicationStatus = (enStatus)Convert.ToSByte(reader["ApplicationStatus"]);
        //            float.TryParse(reader["PaidFees"].ToString(), out PaidFees);
        //            DateTime.TryParse(reader["LastStatusDate"].ToString(), out LastStatusDate);
        //            CreatedByUserID = clsUtility_DAL.ConvertObjectToIntID(reader["CreatedByUserID"]);
        //        }

        //        reader.Close();
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return IsFound;
        //}

        public static bool UpdateApplication(int ApplicationID, enStatus ApplicationStatus)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Applications] SET [ApplicationStatus] = " +
                "@ApplicationStatus, [LastStatusDate] = @LastStatusDate WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", (int)ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", (short)ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

        public static bool UpdateApplication(string SelectQueryStatement, SqlCommand command, enStatus ApplicationStatus)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
            string query = "USE [DVLD]; UPDATE [dbo].[Applications] SET [ApplicationStatus] = " +
                "@ApplicationStatus, [LastStatusDate] = @LastStatusDate WHERE ApplicationID = " + SelectQueryStatement;
            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@ApplicationStatus", (short)ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

        public static bool IsApplicationExistByID(int ApplicationID) =>
            clsUtility_DAL.CheckIsExist("Applications", "ApplicationID", ApplicationID, true);

        //public static bool IsApplicationRequestAlreadyPending(int ApplicantPersonID, enApplicationType ApplicationTypes)
        //{
        //    // this method is used to check if there is no new application that is in pending mode to avoid duplicate requests in the system.
        //    bool IsExist = false;

        //    SqlConnection connection = new SqlConnection(clsSettings_DAL.ConStr);
        //    string query = $"use dvld; select top 1 x = 1 From Applications " +
        //        $"where ApplicantPersonID = @ApplicantPersonID And ApplicationTypes = @ApplicationTypes And ApplicationStatus = 1;";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
        //    command.Parameters.AddWithValue("@ApplicationTypes", (short)ApplicationTypes);

        //    try
        //    {
        //        connection.Open();
        //        object result = command.ExecuteScalar();
        //        IsExist = (clsUtility_DAL.ConvertObjectToIntID(result) == 1);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return IsExist;
        //}

        public static float GetApplicationFees(int ApplicatonId)
        {
            float Fees = 0;

            object result = clsUtility_DAL.GetTop1Value(ApplicatonId, "Applications", "PaidFees", "ApplicationID");

            if (result != null)
                Fees = Convert.ToSingle(result);

            return Fees;
        }
    }
}
