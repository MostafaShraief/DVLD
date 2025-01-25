using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    internal interface CRUD
    {
        int Add();

        DataTable GetAllItems();

        void GetItemByID();

        bool UpdateItem();

        bool DeleteItem();

        bool IsItemExist();
    }
}
