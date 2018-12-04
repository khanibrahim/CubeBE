using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_GuestApp_M = BO.GuestApp.Master; 

namespace DL.Master
{
   public class Userdetail : Base, IBasicOperation<BO_GuestApp_M.Userdetail, BO_GuestApp_M.Userdetail>
    {

 public List<BO_GuestApp_M.Userdetail> Get_Record_SingleUser(string ID=null,string Username=null)
      
       {
           queryString = "GA.USP_M_GuestUser_Record";
           try
           {
               List<BO_GuestApp_M.Userdetail> returnModel = new List<BO_GuestApp_M.Userdetail>();
               using (SqlConnection conn = new SqlConnection(ConnectionString))
               {
                   SqlCommand cmd = new SqlCommand(queryString, conn);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@ID", ID);
                   cmd.Parameters.AddWithValue("@Username", Username);
                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   DataSet ds = new DataSet();
                   da.Fill(ds);
                   if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                   {
                       if (ds.Tables[0].Rows.Count > 0)
                       {
                           foreach (DataRow dr in ds.Tables[0].Rows)
                           {
                               returnModel.Add(new BO_GuestApp_M.Userdetail()
                               {
                                   UserId = dr["UserId"].NulllToLong(),
                                   Username = dr["Username"].NulllToString(),
                                   GuestId = dr["GuestId"].NulllToString(),
                                   PropertyId = dr["PropertyId"].NulllToString(),
                                   IsActive= dr["IsActive"].NulllToBoolean(),
                                   CreatedBy = dr["CreatedBy"].NulllToString(),
                                   ModifiedBy = dr["ModifiedBy"].NulllToString(),
                                   CreatedOn = dr["CreatedOn"].NulllToDate(),
                                   ModifiedOn = dr["ModifiedOn"].NulllToDate(),

                               }
                                   );
                           }
                           return returnModel;
                       }

                   }
               }
           }
           catch
           {
               return null;
           }
           return null;
       }

        public List<BO_GuestApp_M.Userdetail> Get_Record(string ID, string PropertyID, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BO_GuestApp_M.Userdetail model, out SP_Result_Transaction message)
        {
            throw new NotImplementedException();
        }

        public bool Update(BO_GuestApp_M.Userdetail model, out SP_Result_Transaction message)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string ID, string PropertyID, string User, out SP_Result_Transaction message)
        {
            throw new NotImplementedException();
        }

        public bool Active(string ID, string PropertyID, string User, out SP_Result_Transaction message)
        {
            throw new NotImplementedException();
        }
    }
}
