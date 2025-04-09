using DVLD_DAL;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BLL
{
    public class clsInternationalLicenses_BLL
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime ApplicationCreatedDate { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public clsLicenses_BLL.enGender Gender { get; set; }
        public string ImagePath {  get; set; }
        public clsLicenses_BLL.enIssueReason IssueReason { get; set; }
        public string Notes { get; set; }
        public float Fees { get; set; }

        private clsSave_BLL.enMode _Mode;

        public clsInternationalLicenses_BLL()
        {
            _Mode = clsSave_BLL.enMode.New;
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            IsActive = true;
            CreatedByUserID = -1;
            ApplicationCreatedDate = DateTime.MinValue;
            NationalNo = string.Empty;
            FullName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = clsLicenses_BLL.enGender.Male;
            ImagePath = string.Empty;
            IssueReason = clsLicenses_BLL.enIssueReason.New;
            Notes = string.Empty;
        }

        private clsInternationalLicenses_BLL(int internationalLicenseID, int applicationID, int driverID,
            int licenseID, DateTime issueDate, DateTime expirationDate, bool isActive,
            int createdByUserID, DateTime applicationCreatedDate, string nationalNo,
            string fullName, DateTime dateOfBirth, clsLicenses_BLL.enGender gender, string imagePath,
            clsLicenses_BLL.enIssueReason issueReason, string notes, float fees)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseID = licenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            ApplicationCreatedDate = applicationCreatedDate;
            NationalNo = nationalNo;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ImagePath = imagePath;
            IssueReason = issueReason;
            Notes = notes;
            this.Fees = fees;
        }

        private clsInternationalLicenses_BLL(int internationalLicenseID, int applicationID,
    int LicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, float fees)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            this.LicenseID = LicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            this.Fees = fees;
        }

        public static clsInternationalLicenses_BLL FindDetailsByInternationalLicenseID(int internationalLicenseID)
        {
            DataRow row = clsInternationalLicenses_DAL.GetInternationalLicenseDetails(internationalLicenseID);

            if (row != null)
                return  _MapDetailsDataRowToLicense(row);
            else
                return new clsInternationalLicenses_BLL();
        }

        public static DataTable GetAllSammurizedInternationicenses()
        {
            return clsInternationalLicenses_DAL.GetAllSammurizedInternationicenses();
        }

        public static DataTable GetInternationalLicensesByDriverID(int DriverID)
        {
            return clsInternationalLicenses_DAL.GetInternationalLicensesByLicenseID(DriverID);
        }

        public static clsInternationalLicenses_BLL FindSammurizedByApplicationID(int applicationID)
        {
            DataRow row = clsInternationalLicenses_DAL.GetByApplicationID(applicationID);

            if (row != null)
            {
                return _MapSummarizedDataRowToLicense(row);
            }
            else
            {
                return new clsInternationalLicenses_BLL();
            }
        }

        public static clsInternationalLicenses_BLL FindSammurizedByLicenseID(int LicenseID)
        {
            DataRow row = clsInternationalLicenses_DAL.GetByLicenseID(LicenseID);

            if (row != null)
            {
                return _MapSummarizedDataRowToLicense(row);
            }
            else
            {
                return new clsInternationalLicenses_BLL();
            }
        }

        private clsInternationalLicenses_BLL(int internationalLicenseID, int applicationID, int driverID,
            int LicenseID, DateTime issueDate, DateTime expirationDate, bool isActive,
            int createdByUserID, DateTime applicationCreatedDate, float fees)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            this.LicenseID = LicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            ApplicationCreatedDate = applicationCreatedDate;
            this.Fees = fees;
        }

        private bool _Add()
        {
            // fill auto data
            IssueDate = DateTime.Now;
            ExpirationDate = IssueDate.AddYears(1);
            IsActive = true;
            LicenseID =
                clsLicenses_BLL.FindByApplicationID(ApplicationID).LicenseID;

            clsApplications_BLL internationalApplication = clsApplications_BLL.GetApplicationDetailsByID(ApplicationID);
            ApplicationID = clsApplications_BLL.AddApplication(internationalApplication.ApplicantPersonID, clsApplicationTypes_DAL.enApplicationType.NewInternational, CreatedByUserID);
            Fees = clsApplications_BLL.GetApplicationFees(ApplicationID);

            // add to database
            this.InternationalLicenseID = clsInternationalLicenses_DAL.Add(
                this.ApplicationID,
                this.DriverID,
                this.LicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateIsActive()
        {
            return clsInternationalLicenses_DAL.UpdateIsActive(
                this.InternationalLicenseID,
                this.IsActive);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsSave_BLL.enMode.New:
                    if (_Add())
                    {
                        _Mode = clsSave_BLL.enMode.Existing;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case clsSave_BLL.enMode.Existing:
                    return _UpdateIsActive();

                default:
                    return false;
            }
        }

        public static bool Deactivate(int internationalLicenseID)
        {
            clsInternationalLicenses_BLL license = FindDetailsByInternationalLicenseID(internationalLicenseID);
            if (license.InternationalLicenseID == -1)
                return false;

            license.IsActive = false;
            return license.Save();
        }

        public static bool Activate(int internationalLicenseID)
        {
            clsInternationalLicenses_BLL license = FindDetailsByInternationalLicenseID(internationalLicenseID);
            if (license.InternationalLicenseID == -1)
                return false;

            license.IsActive = true;
            return license.Save();
        }

        private static clsInternationalLicenses_BLL _MapSummarizedDataRowToLicense(DataRow row)
        {
            int internationalLicenseID = Convert.ToInt32(row["InternationalLicenseID"]);
            int applicationID = Convert.ToInt32(row["ApplicationID"]);
            int driverID = Convert.ToInt32(row["DriverID"]);
            int LicenseID = Convert.ToInt32(row["LicenseID"]);
            DateTime issueDate = Convert.ToDateTime(row["IssueDate"]);
            DateTime expirationDate = Convert.ToDateTime(row["ExpirationDate"]);
            bool isActive = Convert.ToBoolean(row["IsActive"]);
            int createdByUserID = Convert.ToInt32(row["CreatedByUserID"]);
            DateTime applicationCreatedDate = Convert.ToDateTime(row["Application Created Date"]);
            float fees = Convert.ToSingle(row["PaidFees"]);

            return new clsInternationalLicenses_BLL(
                internationalLicenseID, applicationID, driverID,
                LicenseID, issueDate, expirationDate,
                isActive, createdByUserID, applicationCreatedDate, fees);
        }

        private static clsInternationalLicenses_BLL _MapDetailsDataRowToLicense(DataRow row)
        {
            int internationalLicenseID = Convert.ToInt32(row["InternationalLicenseID"]);
            int applicationID = Convert.ToInt32(row["ApplicationID"]);
            int driverID = Convert.ToInt32(row["DriverID"]);
            int licenseID = Convert.ToInt32(row["LicenseID"]);
            DateTime issueDate = Convert.ToDateTime(row["IssueDate"]);
            DateTime expirationDate = Convert.ToDateTime(row["ExpirationDate"]);
            bool isActive = Convert.ToBoolean(row["IsActive"]);
            int createdByUserID = Convert.ToInt32(row["CreatedByUserID"]);
            string nationalNo = row["NationalNo"].ToString();
            string fullName = row["FullName"].ToString();
            DateTime dateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
            clsLicenses_BLL.enGender gender = (clsLicenses_BLL.enGender)Enum.Parse(typeof(clsLicenses_BLL.enGender), row["Gender"].ToString());
            clsLicenses_BLL.enIssueReason issueReason = (clsLicenses_BLL.enIssueReason)Convert.ToInt32(row["IssueReason"]);
            string notes = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString();
            string imagePath = row["ImagePath"] == DBNull.Value ? string.Empty : row["ImagePath"].ToString();
            DateTime applicationCreatedDate = Convert.ToDateTime(row["ApplicationDate"]);
            float fees = Convert.ToSingle(row["PaidFees"]);

            return new clsInternationalLicenses_BLL(
                internationalLicenseID, applicationID, driverID,
                licenseID, issueDate, expirationDate,
                isActive, createdByUserID, applicationCreatedDate,
                nationalNo, fullName, dateOfBirth, gender, imagePath,
                issueReason, notes, fees);
        }
    }
}