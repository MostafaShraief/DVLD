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

namespace DVLD.DVLD_System.Applications.Tests
{
    public partial class ScheduleTest : Form
    {
        public ScheduleTest()
        {
            InitializeComponent();
            ucTopBar1.ChangeTitle("Schedule Test");
            ucTopBar1.delClose += () => this.Close();
            ucTopBar1.delMinimize += () => this.WindowState = FormWindowState.Minimized;
            testAppointmentObj = new clsTestAppointments_BLL();
            dtpDate.MinDate = DateTime.Now;
        }

        clsTestAppointments_BLL testAppointmentObj;

        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        public void GetTestAppointmentObject(clsTestAppointments_BLL testAppointmentObj)
        {
            this.testAppointmentObj = testAppointmentObj;

            if (testAppointmentObj == null)
            {
                MessageBox.Show("No valid test appoinment passed.", "Invalid Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (testAppointmentObj.IsLocked)
            {
                MessageBox.Show("Test appointment already sat, please choose another one.", "Test Sat",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            else
            {
                // change top bar title.
                if (testAppointmentObj.TestAppointmentID != -1)
                    ucTopBar1.ChangeTitle($"Edit {testAppointmentObj.TestTypeID.ToString()} Appointment");
                else
                    ucTopBar1.ChangeTitle($"Schedule {testAppointmentObj.TestTypeID} Appointment");

                FillTestAppointmentInfo();
            }
        }

        void FillTestAppointmentInfo()
        {
            // Test Appointment ID
            lblTestID.Text = testAppointmentObj.TestAppointmentID.ToString();

            // Local Driving License Application ID
            lblLocDrvLicAppValue.Text = testAppointmentObj.LocalDrivingLicenseApplicationID.ToString();

            // Test Fees
            lblTestFees.Text = testAppointmentObj.TestFees.ToString("0.00");

            // Retake Fees
            lblRetakeFees.Text = testAppointmentObj.RetakeFees.ToString("0.00");

            // date
            dtpDate.Value = testAppointmentObj.AppointmentDate < dtpDate.MinDate ? dtpDate.MinDate : testAppointmentObj.AppointmentDate;

            // Total Fees (Test Fees + Retake Fees)
            lblTotalFees.Text = (testAppointmentObj.TestFees + testAppointmentObj.RetakeFees).ToString("0.00");

            // License Class
            lblLicenseClass.Text = testAppointmentObj.ClassName;

            // Trials
            lblTrials.Text = testAppointmentObj.Trials.ToString();

            lblFullName.Text = testAppointmentObj.FullName;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            testAppointmentObj.AppointmentDate = dtpDate.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this test appointment?", 
                "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
            {
                MessageBox.Show("Test apppintment not saved", "Test Appointment Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (testAppointmentObj.Save())
            {
                MessageBox.Show("Test apppintment has been saved successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Test apppintment not saved, please check data entered.", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
