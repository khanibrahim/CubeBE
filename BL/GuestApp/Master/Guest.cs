using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL.GuestApp.Master ;

namespace BL.GuestApp.Master
{
    public class Guest
    {
        DL.GuestApp.Master.Guest obj = new DL.GuestApp.Master.Guest();
        public List<BO.GuestApp.Master.Guest> Get_Record(string ID = "", string PropertyID = null, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return obj.Get_Record(ID, PropertyID, ActiveOnly, SortBy, SearchText);
        }
    }
}
