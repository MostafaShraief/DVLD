using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DVLD_BLL
{
    public class clsLicenses_BLL
    {
        public enum enIssueReason { New = 1, ReplacementForLost = 2, ReplacementForDamaged = 3, Renewal = 4 }

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        private clsSave_BLL.enMode _Mode;

        public clsLicenses_BLL()
        {
            _Mode = clsSave_BLL.enMode.New;
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.New;
            CreatedByUserID = -1;
        }

        public static DataTable GetLicenses()
        {
            DataTable dt = clsLicenses_DAL.GetLicenses();
            return dt;
        }

        public static DataTable GetLicensesByDriverID(int DriverID)
        {
            DataTable dt = clsLicenses_DAL.GetLicensesByDriverID(DriverID);
            return dt;
        }

        private clsLicenses_BLL(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            _Mode = clsSave_BLL.enMode.Existing;
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddLicense()
        {
            this.LicenseID = clsLicenses_DAL.AddLicense(
                ApplicationID, DriverID, LicenseClass,
                IssueDate, ExpirationDate, Notes, PaidFees,
                IsActive, (clsLicenses_DAL.enIssueReason)IssueReason, CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenses_DAL.UpdateLicense(
                LicenseID, ApplicationID, DriverID, LicenseClass,
                IssueDate, ExpirationDate, Notes, PaidFees,
                IsActive, (clsLicenses_DAL.enIssueReason)IssueReason, CreatedByUserID);
        }

        public bool Save()
        {
            return clsSave_BLL.Save(ref _Mode, _AddLicense, _UpdateLicense);
        }

        public static clsLicenses_BLL FindByLicenseID(int LicenseID)
        {
            DataRow row = clsLicenses_DAL.FindByLicenseID(LicenseID);

            if (row != null)
            {
                int ApplicationID = Convert.ToInt32(row["ApplicationID"]);
                int DriverID = Convert.ToInt32(row["DriverID"]);
                int LicenseClass = Convert.ToInt32(row["LicenseClass"]);
                DateTime IssueDate = Convert.ToDateTime(row["IssueDate"]);
                DateTime ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]);
                string Notes = clsUtility_BLL.ConvertObjectToString(row["Notes"]);
                decimal PaidFees = Convert.ToDecimal(row["PaidFees"]);
                bool IsActive = Convert.ToBoolean(row["IsActive"]);
                enIssueReason IssueReason = (enIssueReason)Convert.ToByte(row["IssueReason"]);
                int CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);

                return new clsLicenses_BLL(
                    LicenseID, ApplicationID, DriverID, LicenseClass,
                    IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return new clsLicenses_BLL();
            }
        }

        public static DataTable GetLicensesByApplicationID(int ApplicationID)
        {
            return clsLicenses_DAL.GetLicensesByApplicationID(ApplicationID);
        }

        public static DataTable GetLicensesByLicenseClass(int LicenseClass)
        {
            return clsLicenses_DAL.GetLicensesByLicenseClass(LicenseClass);
        }

        public static DataTable GetLicensesByIssueReason(enIssueReason IssueReason)
        {
            return clsLicenses_DAL.GetLicensesByIssueReason((byte)IssueReason);
        }

        public static DataTable GetLicensesByIsActive(bool IsActive)
        {
            return clsLicenses_DAL.GetLicensesByIsActive(IsActive);
        }

        public static int GetDriverLicenseCount(int DriverID)
        {
            return clsLicenses_DAL.GetDriverLicenseCount(DriverID);
        }

        // Replace the existing DeactivateLicense and ActivateLicense methods with these:
        public static bool SetLicenseActiveStatus(int LicenseID, bool IsActive)
        {
            return clsLicenses_DAL.UpdateIsActiveByLicenseID(LicenseID, IsActive);
        }

        public static bool SetLicenseActiveStatusByApplicationID(int ApplicationID, bool IsActive)
        {
            return clsLicenses_DAL.UpdateIsActiveByApplicationID(ApplicationID, IsActive);
        }
    }
}