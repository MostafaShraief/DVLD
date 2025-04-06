using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;
using static DVLD_DAL.clsApplications_DAL;

namespace DVLD_BLL
{
    public class clsApplications_BLL
    {
        // Properties for the BLL object
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public string FullName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public string CreatedByUserName { get; set; }

        // Default constructor
        public clsApplications_BLL()
        {
            ApplicationID = -1;
            FullName = string.Empty;
            ApplicationDate = DateTime.MinValue;
            ApplicationTypeTitle = string.Empty;
            ApplicationStatus = string.Empty;
            LastStatusDate = DateTime.MinValue;
            PaidFees = 0;
            CreatedByUserName = string.Empty;
        }

        // Parameterized constructor
        public clsApplications_BLL(int ApplicationID, int ApplicantPersonID, string FullName, DateTime ApplicationDate,
            string ApplicationTypeTitle, string ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, string CreatedByUserName)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.FullName = FullName;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserName = CreatedByUserName;
        }

        /// <summary>
        /// Retrieves all applications with detailed information.
        /// </summary>
        /// <returns>DataTable containing all application details.</returns>
        public static DataTable GetAllApplicationsDetails()
        {
            return clsApplications_DAL.GetAllApplicationsDetails();
        }

        /// <summary>
        /// Retrieves detailed information for a specific application by ID.
        /// </summary>
        /// <param name="ApplicationID">The ID of the application.</param>
        /// <returns>clsApplications_BLL object containing the application details.</returns>
        public static clsApplications_BLL GetApplicationDetailsByID(int ApplicationID)
        {
            DataRow row = clsApplications_DAL.GetApplicationDetailsByID(ApplicationID);

            if (row != null)
            {
                return new clsApplications_BLL
                {
                    ApplicationID = Convert.ToInt32(row["ApplicationID"]),
                    ApplicantPersonID = Convert.ToInt32(row["ApplicantPersonID"]),
                    FullName = row["Full Name"].ToString(),
                    ApplicationDate = Convert.ToDateTime(row["ApplicationDate"]),
                    ApplicationTypeTitle = row["ApplicationTypeTitle"].ToString(),
                    ApplicationStatus = row["ApplicationStatus"].ToString(),
                    LastStatusDate = Convert.ToDateTime(row["LastStatusDate"]),
                    PaidFees = Convert.ToSingle(row["PaidFees"]),
                    CreatedByUserName = row["UserName"].ToString()
                };
            }
            else
            {
                return new clsApplications_BLL();
            }
        }

        public static int AddApplication(int ApplicantPersonID,
            clsApplicationTypes_DAL.enApplicationType ApplicationType, int CreatedByUserID) =>
            clsApplications_DAL.AddApplication(ApplicantPersonID, 
                ApplicationType, CreatedByUserID);

        public static bool UpdateApplication(int ApplicationID, Byte Status) =>
            clsApplications_DAL.UpdateApplication(ApplicationID, (enStatus)Status);

        public bool IsApplicationExist(int ApplicationID) =>
            clsApplications_DAL.IsApplicationExistByID(ApplicationID);

        public static float GetApplicationFees(int ApplicationID) =>
            clsApplications_DAL.GetApplicationFees(ApplicationID);

        public static byte? GetApplicationStatus(int applicationID)
        {
            return clsApplications_DAL.GetApplicationStatus(applicationID);
        }

        public static bool DeleteApplication(int applicationID)
        {
            return clsApplications_DAL.DeleteApplication(applicationID);
        }
    }
}
