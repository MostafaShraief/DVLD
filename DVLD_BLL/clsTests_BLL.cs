using DVLD_DAL;
using System;
using System.Data;

namespace DVLD_BLL
{
    public class clsTests_BLL
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        private clsSave_BLL.enMode _Mode;

        public clsTests_BLL()
        {
            _Mode = clsSave_BLL.enMode.New;
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
        }

        private clsTests_BLL(int testID, int testAppointmentID, bool testResult,
                            string notes, int createdByUserID)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }

        private bool _AddTest()
        {
            bool? IsLocked = clsTestAppointments_BLL.IsTestAppointmentLocked(TestAppointmentID);

            if (IsLocked == null || IsLocked == true)
                return false;

            this.TestID = clsTests_DAL.AddTest(
                this.TestAppointmentID,
                this.TestResult,
                this.Notes,
                this.CreatedByUserID);

            return (this.TestID != -1);
        }

        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _AddTest, null);
        }

        public static DataTable GetAllTests()
        {
            return clsTests_DAL.GetAllTests();
        }

        public static clsTests_BLL FindByTestID(int testID)
        {
            DataRow row = clsTests_DAL.GetTestByID(testID);

            if (row != null)
            {
                int testAppointmentID = Convert.ToInt32(row["TestAppointmentID"]);
                bool testResult = Convert.ToBoolean(row["TestResult"]);
                string notes = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString();
                int createdByUserID = Convert.ToInt32(row["CreatedByUserID"]);

                return new clsTests_BLL(
                    testID, testAppointmentID, testResult, notes, createdByUserID);
            }
            else
            {
                return new clsTests_BLL();
            }
        }

        public static clsTests_BLL FindByAppointmentID(int testAppointmentID)
        {
            DataRow row = clsTests_DAL.GetTestByAppointmentID(testAppointmentID);

            if (row != null)
            {
                int testID = Convert.ToInt32(row["TestID"]);
                bool testResult = Convert.ToBoolean(row["TestResult"]);
                string notes = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString();
                int createdByUserID = Convert.ToInt32(row["CreatedByUserID"]);

                return new clsTests_BLL(
                    testID, testAppointmentID, testResult, notes, createdByUserID);
            }
            else
            {
                return new clsTests_BLL();
            }
        }

        public static bool DeleteTestByAppointmentID(int testAppointmentID)
        {
            return clsTests_DAL.DeleteTestByAppointmentID(testAppointmentID);
        }
    }
}