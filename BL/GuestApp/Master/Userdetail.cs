using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.GuestApp.Master
{
    public class Userdetail
    {
        DL.GuestApp.Master.Userdetail obj = new DL.GuestApp.Master.Userdetail();
        public List<BO.GuestApp.Master.Userdetail> Get_Record(string ID = "", string PropertyID = null, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return obj.Get_Record(ID, PropertyID, ActiveOnly, SortBy, SearchText);
        }

        public List<BO.GuestApp.Master.Userdetail> Get_Record_SingleUser(string ID = null, string Username = null)

        {
            return obj.Get_Record_SingleUser(ID, Username);
        }
    }
}