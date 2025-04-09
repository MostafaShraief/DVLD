using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsDrivers_BLL
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ActiveLicenses { get; set; }

        public clsDrivers_BLL()
        {
            DriverID = -1;
            PersonID = -1;
            NationalNo = string.Empty;
            FullName = string.Empty;
            CreatedDate = DateTime.MinValue;
            ActiveLicenses = 0;
        }

        // Method to save a driver
        public bool Save(int CreatedByUserID)
        {
            if (IsPersonAlreadyDriver(PersonID))
            {
                return false; // Person is already a driver
            }

            DriverID = clsDrivers_DAL.AddDriver(PersonID, CreatedByUserID);
            return DriverID != -1;
        }

        // Method to get all drivers
        public static DataTable GetAllDrivers()
        {
            return clsDrivers_DAL.GetAllDrivers();
        }

        // Method to get driver by Driver ID
        public static clsDrivers_BLL FindByDriverID(int DriverID)
        {
            DataTable dt = clsDrivers_DAL.GetDriverByDriverID(DriverID);
            if (dt.Rows.Count > 0)
            {
                return new clsDrivers_BLL
                {
                    DriverID = Convert.ToInt32(dt.Rows[0]["Driver ID"]),
                    PersonID = Convert.ToInt32(dt.Rows[0]["Person ID"]),
                    NationalNo = dt.Rows[0]["National No"].ToString(),
                    FullName = dt.Rows[0]["Full Name"].ToString(),
                    CreatedDate = Convert.ToDateTime(dt.Rows[0]["Created Date"]),
                    ActiveLicenses = Convert.ToInt32(dt.Rows[0]["Active Licenses"])
                };
            }
            return null;
        }

        // Method to get driver by Person ID
        public static clsDrivers_BLL FindByPersonID(int PersonID)
        {
            DataTable dt = clsDrivers_DAL.GetDriverByPersonID(PersonID);
            if (dt.Rows.Count > 0)
            {
                return new clsDrivers_BLL
                {
                    DriverID = Convert.ToInt32(dt.Rows[0]["Driver ID"]),
                    PersonID = Convert.ToInt32(dt.Rows[0]["Person ID"]),
                    NationalNo = dt.Rows[0]["National No"].ToString(),
                    FullName = dt.Rows[0]["Full Name"].ToString(),
                    CreatedDate = Convert.ToDateTime(dt.Rows[0]["Created Date"]),
                    ActiveLicenses = Convert.ToInt32(dt.Rows[0]["Active Licenses"])
                };
            }
            return null;
        }

        // Method to get driver by National Number
        public static clsDrivers_BLL FindByNationalNo(string NationalNo)
        {
            DataTable dt = clsDrivers_DAL.GetDriverByNationalNo(NationalNo);
            if (dt.Rows.Count > 0)
            {
                return new clsDrivers_BLL
                {
                    DriverID = Convert.ToInt32(dt.Rows[0]["Driver ID"]),
                    PersonID = Convert.ToInt32(dt.Rows[0]["Person ID"]),
                    NationalNo = dt.Rows[0]["National No"].ToString(),
                    FullName = dt.Rows[0]["Full Name"].ToString(),
                    CreatedDate = Convert.ToDateTime(dt.Rows[0]["Created Date"]),
                    ActiveLicenses = Convert.ToInt32(dt.Rows[0]["Active Licenses"])
                };
            }
            return new clsDrivers_BLL();
        }

        // Method to check if a person is already a driver
        public static bool IsPersonAlreadyDriver(int PersonID)
        {
            return clsDrivers_DAL.IsPersonAlreadyDriver(PersonID);
        }

        public static int GetPersonIDByDriverID(int driverID)
        {
            // Directly return the DAL result since this is a simple lookup
            return clsDrivers_DAL.GetPersonIDByDriverID(driverID);
        }
    }
}