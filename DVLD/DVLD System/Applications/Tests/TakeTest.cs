using DVLD_BLL;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Applications.Tests
{
    public partial class TakeTest : Form
    {
        public TakeTest()
        {
            InitializeComponent();
            ucTopBar1.ChangeTitle("Take Test");
            ucTopBar1.delClose += () => this.Close();
            ucTopBar1.delMinimize += () => this.WindowState = FormWindowState.Minimized;
            testObj = new clsTests_BLL();
        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        clsTests_BLL testObj;
        clsTestAppointments_BLL testAppointmentObj;

        public void SetTestInfoByObject(clsTestAppointments_BLL testAppointmentObj)
        {
            this.testAppointmentObj = testAppointmentObj;

            ucTopBar1.ChangeTitle($"Take {testAppointmentObj.TestTypeTitle}");

            if (testAppointmentObj == null)
            {
                MessageBox.Show("No valid test appoinment.", "Invalid appointment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (testAppointmentObj.IsLocked)
            {
                MessageBox.Show("Test appointment already sat, please check data again.", "Test Sat",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            else
            {
                FillInfo();
            }
        }

        public void SetTestInfoByTestAppointmentID(int testAppointmentID)
        {
            testAppointmentObj = clsTestAppointments_BLL.Find(testAppointmentID);

            SetTestInfoByObject(testAppointmentObj);
        }

        void FillInfo()
        {
            // test appoinment id
            testObj.TestAppointmentID = testAppointmentObj.TestAppointmentID;

            // user id
            testObj.CreatedByUserID = clsGlobal.user.UserID;

            // Test Appointment ID
            lblTestID.Text = testObj.TestID.ToString();

            // Local Driving License Application ID
            lblLocDrvLicAppValue.Text = testAppointmentObj.LocalDrivingLicenseApplicationID.ToString();

            lblDate.Text = testAppointmentObj.AppointmentDate.ToString();

            // Total Fees (Test Fees + Retake Fees)
            lblPaidFees.Text = (testAppointmentObj.TestFees + testAppointmentObj.RetakeFees).ToString("0.00");

            // License Class
            lblLicenseClass.Text = testAppointmentObj.ClassName;

            // Trials
            lblTrialsTests.Text = testAppointmentObj.Trials.ToString();

            lblFullName.Text = testAppointmentObj.FullName;

            if (testObj.TestID != -1)
            {
                if (testObj.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = false;
            }

            tbNote.Text = testObj.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((rbPass.Checked || rbFail.Checked) == false)
            {
                MessageBox.Show("Select test result to save", "Failed to save", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointments_BLL.IsTestPassed(testAppointmentObj.LocalDrivingLicenseApplicationID, (int)testAppointmentObj.TestTypeID))
            {
                MessageBox.Show("Test already passed", "save test result canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (MessageBox.Show("Are you sure you want to save this test result?",
                "Confirm Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
            {
                MessageBox.Show("Test result not saved", "Operation Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            testObj.TestResult = rbPass.Checked;
            testObj.Notes = tbNote.Text;

            testAppointmentObj.IsLocked = false;

            if (testObj.Save() && testAppointmentObj.LockTestAppointment())
            {
                MessageBox.Show("Test result saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save test result. Please verify your data and try again.",
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
