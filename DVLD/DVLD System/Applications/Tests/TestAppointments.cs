using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.clsGlobal;

namespace DVLD.DVLD_System.Applications.Tests
{
    public partial class TestAppointments : Form
    {
        public TestAppointments()
        {
            InitializeComponent();
            ucTitleScreen1.ChangeTitle("Test Appointment");
        }

        internal void GetTestAppointmentInfo(int LocalLicenseID, 
            clsGlobal.enTestType testType)
        {
            this.LocalLicenseID = LocalLicenseID;
            this.testType = testType;

            ucTitleScreen1.ChangeTitle($"{testType.ToString()} Appointment");

            // fill ucList.
            List<string> ColumnsIds = new List<string>()
            {
                "Appointment ID", "Test Fees"
            };

            ucList1.FillListObject(GetTestAppointments, ColumnsIds, null, cmsRow);

            // fill ucLocalLicenseInfoWithApplication.
            ucLocalLicenseInfoWithApplication1.SetLocalLicenseId(LocalLicenseID);
        }


        int LocalLicenseID;

        clsGlobal.enTestType testType;

        DataTable GetTestAppointments()
        {
            return clsTestAppointments_BLL.GetSummarizedTestAppointmentsByApplicationAndTestType(LocalLicenseID, (int)testType);
        }

        private void btnAddTestAll_Click(object sender, EventArgs e)
        {
            ScheduleTest scheduleTest = new ScheduleTest();
            clsTestAppointments_BLL testAppointmentObj = new clsTestAppointments_BLL();
            clsLocalDrivingLicenseApplication_BLL LocalLicenseObj = ucLocalLicenseInfoWithApplication1.GetLocalLicenseObject();

            if (clsTestAppointments_BLL.IsTestPassed(LocalLicenseObj.LocalDrivingLicenseApplicationID, (int)testType))
            {
                MessageBox.Show("Test already passed", "Add test canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointments_BLL.IsThereTestAppointmentNotLocked(LocalLicenseObj.LocalDrivingLicenseApplicationID, (int)testType))
            {
                MessageBox.Show("there is already pending test appointment", "Add test canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // fill testAppointmentObj.
            testAppointmentObj.LocalDrivingLicenseApplicationID = LocalLicenseObj.LocalDrivingLicenseApplicationID;
            testAppointmentObj.ClassName = LocalLicenseObj.LicenseClassName;
            testAppointmentObj.FullName = LocalLicenseObj.FullName;
            testAppointmentObj.AppointmentDate = DateTime.Now;
            testAppointmentObj.TestTypeID = (clsTestAppointments_BLL.enTestType)testType;
            testAppointmentObj.TestFees = clsTestTypes_BLL.GetTestTypeFees((int)testAppointmentObj.TestTypeID);
            testAppointmentObj.Trials = clsTestAppointments_BLL.GetTestTrialsCount(testAppointmentObj.LocalDrivingLicenseApplicationID, (int)testAppointmentObj.TestTypeID);
            if (clsTestAppointments_BLL.IsRetakeFeesApplied(testAppointmentObj.LocalDrivingLicenseApplicationID, (int)testAppointmentObj.TestTypeID))
                testAppointmentObj.RetakeFees = (decimal)clsApplicationType_BLL.GetApplicationTypeFees((int)clsGlobal.enLicencsesClasses.RetakeTest);
            testAppointmentObj.CreatedByUserID = clsGlobal.user.UserID;

            scheduleTest.GetTestAppointmentObject(testAppointmentObj);
            scheduleTest.ShowDialog();
            ucList1.RefreshDataSet();
        }

        int GetTestappointmentIdFromSelectedRow() =>
            ucList1.GetIdFromSelectedRow();

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointments_BLL testAppointmentObj = clsTestAppointments_BLL.Find(GetTestappointmentIdFromSelectedRow());
            
            if (testAppointmentObj.IsLocked)
            {
                MessageBox.Show("Test appointment already sat, please choose another one.", "Test Sat",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ScheduleTest scheduleTest = new ScheduleTest();
            scheduleTest.GetTestAppointmentObject(testAppointmentObj);
            scheduleTest.ShowDialog();
            ucList1.RefreshDataSet();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointments_BLL testAppointmentObj = clsTestAppointments_BLL.Find(GetTestappointmentIdFromSelectedRow());

            if (testAppointmentObj.IsLocked)
            {
                MessageBox.Show("Test appointment already sat, please choose another one.", "Test Sat",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            TakeTest takeTest = new TakeTest();
            takeTest.SetTestInfoByObject(testAppointmentObj);
            takeTest.ShowDialog();
            ucList1.RefreshDataSet();
            ucLocalLicenseInfoWithApplication1.RefreshTestPassedCounter();
        }
    }
}
