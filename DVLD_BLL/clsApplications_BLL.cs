using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;
using static DVLD_DAL.clsApplications_DAL;

namespace DVLD_BLL
{
    public class clsApplications_BLL
    {
        //public int ApplicationID { get; set; }
        //public int ApplicantPersonID { get; set; }
        //private clsApplications_DAL.enApplicationType _ApplicationType { get; set; }
        //public clsApplications_DAL.enStatus _Status { get; set; }
        //public int CreatedByUserID { get; set; }

        //public clsApplications_BLL()
        //{
        //    ApplicationID = -1;
        //    ApplicantPersonID = -1;
        //    _ApplicationType = clsApplications_DAL.enApplicationType.NewLocalLicense;
        //    _Status = clsApplications_DAL.enStatus.New;
        //    CreatedByUserID = -1;
        //}

        //clsApplications_BLL(int applicationID, int applicantPersonID, 
        //    clsApplications_DAL.enApplicationType applicationType, clsApplications_DAL.enStatus status, int createdByUserID)
        //{
        //    ApplicationID = applicationID;
        //    ApplicantPersonID = applicantPersonID;
        //    _ApplicationType = applicationType;
        //    _Status = status;
        //    CreatedByUserID = createdByUserID;
        //}

        public static int AddApplication(int ApplicantPersonID,
            clsApplicationTypes_DAL.enApplicationType ApplicationType, int CreatedByUserID) =>
            clsApplications_DAL.AddApplication(ApplicantPersonID, 
                ApplicationType, CreatedByUserID);

        public static bool UpdateApplication(int ApplicationID, enStatus Status) =>
            clsApplications_DAL.UpdateApplication(ApplicationID, Status);

        public bool IsApplicationExist(int ApplicationID) =>
            clsApplications_DAL.IsApplicationExistByID(ApplicationID);
    }
}
