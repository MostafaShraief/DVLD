using DVLD_DAL;
using System;
using System.Data;

namespace DVLD_BLL
{
    public class clsInternationalLicenses_BLL
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        private clsInternationalLicenses_BLL(int internationalLicenseID, int applicationID,
            int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
        }

        public static DataTable GetInternationalLicensesByDriverID(int DriverID)
        {
            return clsInternationalLicenses_DAL.GetInternationalLicensesByLocalLicenseID(DriverID);
        }
    }
}