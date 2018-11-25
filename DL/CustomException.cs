using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BO;
using System.Threading.Tasks;

namespace DL
{
    public partial class ExceptionErrorLog
    {
        public long ID { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string URL { get; set; }
        public string FunctionName { get; set; }
        public DateTime? Date { get; set; }
        public string TransactionID { get; set; }
        public bool? IsActive { get; set; }
        public string User { get; set; }
        public string ClosedBy { get; set; }
        public DateTime? ClosedOn { get; set; }
    }
    public class CustomException : Base
    {
        public static void Save(Exception exp, string User = null, string URL = null, string FunctionName = null)
        {
            ExceptionErrorLog Excep = new ExceptionErrorLog();
            //Excep.Message = exp.Message.ToString();
            Excep.Type = exp.GetType().Name.ToString();
            Excep.URL = URL;
            Excep.FunctionName = FunctionName;
            Excep.Source = exp.StackTrace.ToString();
            Excep.User = User;
            Excep.IsActive = true;
            try
            {
                StringBuilder sbExceptionMessage = new StringBuilder();
                do
                {
                    sbExceptionMessage.Append("Exception Type :" + exp.GetType().Name + Environment.NewLine);
                    sbExceptionMessage.Append("Message : " + exp.Message + Environment.NewLine);
                    sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
                    sbExceptionMessage.Append(exp.StackTrace + Environment.NewLine + Environment.NewLine);
                    exp = exp.InnerException;
                }
                while (exp != null);
                Excep.Message = sbExceptionMessage.ToString();
                string logProvider = ConfigurationManager.AppSettings["LogProvider"];
                string logMessage = "User : " + Excep.User + Environment.NewLine +
                "Area : " + FunctionName.Substring(0, FunctionName.IndexOf('.')) + Environment.NewLine +
                "Function : " + Excep.FunctionName + Environment.NewLine +
                "Message : " + Excep.Message;

                if (logProvider.ToLower() == "both")
                {
                    Insert(Excep);
                    LogToEventViewer(logMessage);
                }
                else if (logProvider.ToLower() == "database")
                {
                    Insert(Excep);
                }
                else if (logProvider.ToLower() == "eventviewer")
                {
                    LogToEventViewer(logMessage);
                }
            }
            catch
            {

            }
        }
        public static void Save(string exp, string User = null, string URL = null, string FunctionName = null)
        {
            ExceptionErrorLog Excep = new ExceptionErrorLog();
            Excep.Message = exp;
            Excep.Type = exp.GetType().Name.ToString();
            Excep.URL = URL;
            Excep.FunctionName = FunctionName;
            Excep.Source = "SQL Error";
            Excep.User = User;
            Excep.IsActive = true;
            try
            {
                string logProvider = ConfigurationManager.AppSettings["LogProvider"];
                string logMessage = "User : " + Excep.User + Environment.NewLine +
                    "Area : " + FunctionName.Substring(0, FunctionName.IndexOf('.')) + Environment.NewLine +
                    "Function : " + Excep.FunctionName + Environment.NewLine +
                    "Message : " + Excep.Message;
                if (logProvider.ToLower() == "both")
                {
                    Insert(Excep);
                    LogToEventViewer(logMessage);
                }
                else if (logProvider.ToLower() == "database")
                {
                    Insert(Excep);
                }
                else if (logProvider.ToLower() == "eventviewer")
                {
                    LogToEventViewer(logMessage);
                }
            }
            catch
            {

            }
        }
        public static List<ExceptionErrorLog> Get_Record(string No = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            string queryString = "Select * from dbo.T_ExceptionLog " +
                "where (case when @ActiveOnly=1 then (case when IsActive=1 then 1 else 0 end) else 1 end)=1 " +
                " and (case when @No='' then 1 when ID=@No then 1 else 0 end)=1" +
                " and (case @SortBy " +
                " when 'Message' then (case when Message like @SearchText then 1 else 0 end)" +
                " when 'Type' then (case when Type like @SearchText then 1 else 0 end)" +
                " when 'Source' then (case when Source like @SearchText then 1 else 0 end)" +
                " when 'URL' then (case when URL like @SearchText then 1 else 0 end)" +
                " when 'FunctionName' then (case when FunctionName like @SearchText then 1 else 0 end)" +
                " when 'Date' then (case when cast([Date] as varchar(10)) like @SearchText then 1 else 0 end)" +
                " else 0 end)=1";
            try
            {
                List<ExceptionErrorLog> returnModel = new List<ExceptionErrorLog>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActiveOnly", ActiveOnly);
                    cmd.Parameters.AddWithValue("@No", No);
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
                                returnModel.Add(new ExceptionErrorLog()
                                {
                                    ID = dr["ID"].NulllToInt()
                                    ,
                                    Message = dr["Message"].NulllToString()
                                    ,
                                    Type = dr["Type"].NulllToString()
                                    ,
                                    Source = dr["Source"].NulllToString()
                                    ,
                                    URL = dr["URL"].NulllToString()
                                    ,
                                    FunctionName = dr["FunctionName"].NulllToString()
                                    ,
                                    Date = dr["Date"].NulllToDateNull()
                                    ,
                                    TransactionID = dr["TransactionID"].NulllToString()
                                    ,
                                    User = dr["UserName"].NulllToString()
                                    ,
                                    ClosedBy = dr["ClosedBy"].NulllToString()
                                    ,
                                    ClosedOn = dr["ClosedOn"].NulllToDateNull()
                                    ,
                                    IsActive = dr["IsActive"].NulllToBoolean()
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
        public static bool Delete(string ID, string User)
        {
            queryString = "uppdate dbo.T_ExceptionLog set IsActive=0 , ModifiedBy=@User, ModifiedOn=getdate() where [ID]=@ID";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", User);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        static bool Insert(ExceptionErrorLog model)
        {
            queryString = "insert into dbo.T_ExceptionLog (Message,Type,Source,URL,FunctionName,TransactionID,UserName)" +
                "values(@Message,@Type,@Source,@URL,@FunctionName,@TransactionID,@UserName)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@Message", model.Message);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@Source", model.Source);
                    cmd.Parameters.AddWithValue("@URL", model.URL.NulllToString());
                    cmd.Parameters.AddWithValue("@FunctionName", model.FunctionName.NulllToString());
                    cmd.Parameters.AddWithValue("@TransactionID", model.TransactionID.NulllToString());
                    cmd.Parameters.AddWithValue("@UserName", model.User.NulllToString());
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
            return false;
        }

        static void LogToEventViewer(string log)
        {
            try
            {
                if (!EventLog.SourceExists("HotelERP"))
                {
                    System.Diagnostics.EventLog.CreateEventSource("HotelERP", "HotelERP_Logs");
                }
                EventLog eventLog = new EventLog("HotelERP_Logs");
                eventLog.Source = "HotelERP";
                eventLog.WriteEntry(log, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
    }
}
