using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsTestTypes_BLL
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        clsSave_BLL.enMode _Mode;

        public clsTestTypes_BLL()
        {
            TestTypeID = -1;
            TestTypeTitle = TestTypeDescription = string.Empty;
            TestTypeFees = 0;
            _Mode = clsSave_BLL.enMode.New;
        }

        private clsTestTypes_BLL(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
            this._Mode = clsSave_BLL.enMode.Existing;
        }

        public static DataTable GetListOfTestTypes() =>
            clsTestTypes_DAL.GetAllTestTypes();

        public static clsTestTypes_BLL Find(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            float TestTypeFees = 0;

            if (clsTestTypes_DAL.GetTestType(TestTypeID,
                ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestTypes_BLL(TestTypeID,
                    TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return new clsTestTypes_BLL(); // Return an empty object if not found
        }

        bool _CheckData()
        {
            bool IsValid = false;

            if (_Mode == clsSave_BLL.enMode.Existing &&
                TestTypeTitle.Length <= 100 && 
                TestTypeDescription.Length <= 500 &&
                TestTypeFees >= 0)
                IsValid = true;

            return IsValid;
        }

        private bool UpdateTestType()
        {
            bool IsUpdated = false;

            // Check if data is valid before proceeding
            if (_CheckData() == false)
                return false; // If data is invalid, return false

            // Attempt to update the Test type in the database
            IsUpdated = clsTestTypes_DAL.UpdateTestType(TestTypeID,
                TestTypeTitle, TestTypeDescription, TestTypeFees);

            return IsUpdated;
        }

        public bool Save() =>
            clsSave_BLL.Save(ref _Mode, null, UpdateTestType);
    }
}
