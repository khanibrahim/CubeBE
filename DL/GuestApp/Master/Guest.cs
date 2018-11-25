using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  BO;
using System.Data.SqlClient;
using System.Data;
using BO_GuestApp_M = BO.GuestApp.Master; 

namespace DL.GuestApp.Master
{
    public class Guest : Base, IBasicOperation<BO_GuestApp_M.Guest, BO_GuestApp_M.Guest>
    {
        public List<BO_GuestApp_M.Guest> Get_Record(string ID, string PropertyID, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            queryString = "dbo.USP_M_Guest_Record";
            try
            {
                List<BO_GuestApp_M.Guest> returnModel = new List<BO_GuestApp_M.Guest>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@ActiveOnly", ActiveOnly);
                    cmd.Parameters.AddWithValue("@SortBy", SortBy);
                    cmd.Parameters.AddWithValue("@SearchText", SearchText);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                returnModel.Add(new BO_GuestApp_M.Guest()
                                {
                                    ID = dr["GuestID"].NulllToString()
                                    ,
                                    GuestTitle = dr["GuestTitle"].NulllToString()
                                    ,
                                    Name = dr["GuestName"].NulllToString()
                                    ,
                                    GuestGender = dr["GuestGender"].NulllToString()
                                    ,
                                    GuestMaritalStatus = dr["GuestMaritalStatus"].NulllToString()
                                    ,
                                    GuestAddress = dr["GuestAddress"].NulllToString()
                                    ,
                                    GuestCity = dr["GuestCity"].NulllToString()
                                    ,
                                    GuestState = dr["GuestState"].NulllToString()
                                    ,
                                    GuestCountry = dr["GuestCountry"].NulllToString()
                                    ,
                                    GuestZipCode = dr["GuestZipCode"].NulllToString()
                                    ,
                                    GuestTelePhone = dr["GuestTelePhone"].NulllToString()
                                    ,
                                    GuestMobile = dr["GuestMobile"].NulllToString()
                                    ,
                                    GuestFaxNo = dr["GuestFaxNo"].NulllToString()
                                    ,
                                    GuestEmail = dr["GuestEmail"].NulllToString()
                                    ,
                                    GuestDOB = dr["GuestDOB"].NulllToString()
                                    ,
                                    GuestAnniversaryDate = dr["GuestAnniversaryDate"].NulllToString()
                               
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

        public bool Insert(BO_GuestApp_M.Guest model, out SP_Result_Transaction message)
        {
            throw new NotImplementedException();
        }

        public bool Update(BO_GuestApp_M.Guest model, out SP_Result_Transaction message)
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