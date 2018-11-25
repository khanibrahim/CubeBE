using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Base
    {
        public static string ConnectionString;
        public static string queryString;
        public Base()
        {
            string appkey = ConfigurationManager.AppSettings["Constr"].ToString();
            ConnectionString = ConfigurationManager.ConnectionStrings[appkey].ConnectionString;
        }
    }

    public static class Common_Function
    {
        public static SP_Result_Transaction ConvertResultToFail(Exception exp, string FunctionName = null, string User = null, string URL = null)
        {
            try
            {
                SP_Result_Transaction message = new SP_Result_Transaction();
                message.Flag = -1;
                message.TranNo = 0;
                message.No = "";
                message.message = exp.Message;
                message.Color = SP_Result_Transaction.Color_Fail;
                message.Icon = SP_Result_Transaction.Icon_Fail;
                if (!ConfigurationManager.AppSettings["ShowSQLError"].NulllToBoolean())
                    message.message = ConfigurationManager.AppSettings["SQLErrorMessage"].NulllToString();// "Please contact IT.";
                try
                {
                    CustomException.Save(exp, User, URL, FunctionName);
                }
                catch (Exception ex)
                {
                    message = ConvertResultToFail(ex.Message);
                }
                return message;
            }
            catch
            {
                return null;
            }
        }
        public static SP_Result_Transaction ConvertResultToFail(string msg)
        {
            try
            {
                SP_Result_Transaction message = new SP_Result_Transaction();
                message.Flag = -1;
                message.TranNo = 0;
                message.No = "";
                message.message = msg;
                message.Color = SP_Result_Transaction.Color_Fail;
                message.Icon = SP_Result_Transaction.Icon_Fail;
                return message;
            }
            catch
            {
                return null;
            }
        }
        public static SP_Result_Transaction ConvertResultToAlert(SqlDataReader dr, string FunctionName = null, string User = null, string URL = null)
        {
            SP_Result_Transaction message = new SP_Result_Transaction();
            try
            {
                message.Flag = dr[SP_Result.Flag.ToString()].NulllToInt();
                message.message = dr[SP_Result.Message.ToString()].NulllToString();
                if (message.Flag == 1)
                {
                    message.Color = SP_Result_Transaction.Color_Success;
                    message.Icon = SP_Result_Transaction.Icon_Success;
                }
                else
                {
                    message.Color = SP_Result_Transaction.Color_Fail;
                    message.Icon = SP_Result_Transaction.Icon_Fail;
                    CustomException.Save(message.message, User, URL, FunctionName);
                }
                message.TranNo = dr[SP_Result.TranNo.ToString()].NulllToInt();
                message.No = dr[SP_Result.No.ToString()].NulllToString();
                message.ReturnVal_1 = dr[SP_Result.ReturnVal_1.ToString()].NulllToString();
                message.ReturnVal_2 = dr[SP_Result.ReturnVal_2.ToString()].NulllToString();
                message.ReturnVal_3 = dr[SP_Result.ReturnVal_3.ToString()].NulllToString();
                message.ReturnVal_4 = dr[SP_Result.ReturnVal_4.ToString()].NulllToString();
                return message;
            }
            catch
            {
                return message;
            }
        }
        public static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();
            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }
            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }
            return table;
        }
    }
}
