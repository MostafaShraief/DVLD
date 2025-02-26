using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    internal class clsSave_BLL
    {
        public enum enMode { New, Existing } // this modes refers to the status of data in the object.

        public static bool Save(ref enMode mode, Func <bool> Add, Func <bool> Update)
        {
            // save new record or update record in database table specified.
            bool IsSaved = false;

            switch (mode)
            {
                case enMode.New:
                    if (Add != null && Add())
                    {
                        mode = enMode.Existing;
                        IsSaved = true;
                    }
                    break;
                case enMode.Existing:
                    if (Update != null)
                        IsSaved = Update();
                    break;
            }

            return IsSaved;
        }
    }
}
