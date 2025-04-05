using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DVLD_BLL
{
    public class clsTestAppointments_BLL
    {
        public enum enTestType { EyeTest = 1, WrittenTest = 2, PracticalTest = 3 }

        public int TestAppointmentID { get; set; }
        public enTestType TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal TestFees { get; set; }
        public int CreatedByUserID { get; set; }
        public int Trials { get; set; }
        public bool IsLocked { get; set; }
        public decimal RetakeFees { get; set; }
        public string TestTypeTitle { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }

        private clsSave_BLL.enMode _Mode;

        public clsTestAppointments_BLL()
        {
            _Mode = clsSave_BLL.enMode.New;
            TestAppointmentID = -1;
            TestTypeID = enTestType.WrittenTest;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            TestFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeFees = 0;
            TestTypeTitle = "";
            ClassName = "";
            FullName = "";
            Trials = 0;
        }

        private clsTestAppointments_BLL(int testAppointmentID, enTestType testTypeID,
            int localDrivingLicenseAppID, DateTime appointmentDate, decimal testFees,
            int createdByUserID, bool isLocked, decimal retakeFees, string testTypeTitle,
            string className, string fullName, int trials)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseAppID;
            AppointmentDate = appointmentDate;
            TestFees = testFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeFees = retakeFees;
            TestTypeTitle = testTypeTitle;
            ClassName = className;
            FullName = fullName;
            Trials = trials;
        }

        private bool _AddTestAppointment()
        {
            // check is status valid
            byte? Status = clsLocalDrivingLicenseApplication_BLL.GetApplicationStatus(LocalDrivingLicenseApplicationID);

            if (Status == null || Status != 1)
                return false;

            // check test appointment type valud
            Byte PassedTest = clsLocalDrivingLicenseApplication_BLL.CountPassedTests(LocalDrivingLicenseApplicationID);

            if (PassedTest != ((Byte)TestTypeID) - 1)
                return false;

            // chcek is there not unlocked test appointment
            if (IsThereTestAppointmentNotLocked(LocalDrivingLicenseApplicationID, (int)TestTypeID))
                return false;

            if (IsRetakeFeesApplied(LocalDrivingLicenseApplicationID, (int)TestTypeID))
                RetakeFees = (decimal)clsApplicationType_BLL.GetApplicationTypeFees((int)clsApplicationTypes_DAL.enApplicationType.RetakeTest);

            this.TestAppointmentID = clsTestAppointments_DAL.AddTestAppointment(
                (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.TestFees, this.CreatedByUserID,
                this.IsLocked, this.RetakeFees);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            bool? IsLocked = IsTestAppointmentLocked(TestAppointmentID);

            if (IsLocked == null || IsLocked == true)
                return false;

            return clsTestAppointments_DAL.UpdateTestAppointment(
                this.TestAppointmentID, this.AppointmentDate);
        }

        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _AddTestAppointment, _UpdateTestAppointment);
        }

        public static DataTable GetAllSummarizedTestAppointments()
        {
            return clsTestAppointments_DAL.GetAllSummarizedTestAppointments();
        }

        public static DataTable GetSummarizedTestAppointmentsByApplicationAndTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_DAL.GetTestAppointmentsByApplicationAndTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static clsTestAppointments_BLL Find(int testAppointmentID)
        {
            DataRow row = clsTestAppointments_DAL.GetTestAppointmentByID(testAppointmentID);

            if (row != null)
            {
                enTestType testTypeID = (enTestType)Convert.ToInt32(row["TestTypeID"]);
                int localDrivingLicenseAppID = Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]);
                DateTime appointmentDate = Convert.ToDateTime(row["AppointmentDate"]);
                decimal testFees = Convert.ToDecimal(row["Test Fees"]);
                decimal retakeFees = Convert.ToDecimal(row["Retake Fees"]);
                bool isLocked = Convert.ToBoolean(row["Is Locked"]);
                string testTypeTitle = row["Test Type Title"].ToString();
                string className = row["ClassName"].ToString();
                string fullName = row["Full Name"].ToString();
                int trials = Convert.ToInt32(row["Trial"]);

                return new clsTestAppointments_BLL(
                    testAppointmentID, testTypeID, localDrivingLicenseAppID,
                    appointmentDate, testFees, -1, isLocked, retakeFees,
                    testTypeTitle, className, fullName, trials);
            }
            else
            {
                return new clsTestAppointments_BLL();
            }
        }

        public static bool IsRetakeFeesApplied(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_DAL.IsRetakeFeesApplied(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static int GetTestTrialsCount(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_DAL.GetTestTrialsCount(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsTestPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_DAL.IsTestPassed(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsThereTestAppointmentNotLocked(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointments_DAL.IsThereTestAppointmentNotLocked(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool LockTestAppointment(int testAppointmentID)
        {
            return clsTestAppointments_DAL.LockTestAppointment(testAppointmentID);
        }

        public bool LockTestAppointment()
        {
            return clsTestAppointments_DAL.LockTestAppointment(TestAppointmentID);
        }

        public static bool? IsTestAppointmentLocked(int testAppointmentID)
        {
            return clsTestAppointments_DAL.IsTestAppointmentLocked(testAppointmentID);
        }
    }
}