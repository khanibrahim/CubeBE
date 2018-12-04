using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace BO
{
    //public interface IBasicOperation<T, TCustom>
    //{
    //    //List<TCustom> Get_Record(string ID, bool ActiveOnly = false);
    //    List<TCustom> Get_Record(string ID, string PropertyID, bool ActiveOnly = false, string SortBy = null, string SearchText = null);
    //    bool Insert(T model, out SP_Result_Transaction message);
    //    bool Update(T model, out SP_Result_Transaction message);
    //    bool Delete(string ID, string PropertyID, string User, out SP_Result_Transaction message);
    //    bool Active(string ID, string PropertyID, string User, out SP_Result_Transaction message);
    //}
    //public interface IBasicOperation_Transction<T, TCustom>
    //{
    //    List<TCustom> Get_Record();
    //    bool Insert(T model, out SP_Result_Transaction message);
    //    bool Update(T model, out SP_Result_Transaction message);
    //    bool Delete(string No, string PropertyID, string User, string Reason, out SP_Result_Transaction message);
    //    bool Active(string No, string PropertyID, string User, out SP_Result_Transaction message);
    //}
    public enum T_CheckedBy
    {
        Watchman = 1,
        Supervisor = 2,
        Receiver = 3
    }
    public enum SP_ItemType
    {
        Paid = 1,
        Free = 0
    }
    public enum SP_StoreType
    {
        Direct = 1,
        Store = 0
    }
    public enum SP_RejectionType
    {
        MRA = 1,
        MIN = 2
    }
    public enum SP_Result_Flag
    {
        Success = 1,
        Fail = 0,
        Error = -1
    }
    public enum SP_Result
    {
        Flag
        ,
        Message
            ,
        ID
            ,
        TranNo
            ,
        No
            ,
        ReturnVal_1
            ,
        ReturnVal_2
            ,
        ReturnVal_3
            ,
        ReturnVal_4
    }
    public enum SP_Record_Status
    {
        Delete = 0,
        Active = 1,
        Reject = 10,
        Approve = 11,
        Close = 21
    }
    public enum DD_Column
    {
        ID
        ,
        Name
            ,
        KitchenID
            ,
        KitchenName
            ,
        MenugroupID
            ,
        ShortName
            ,
        OutletTypeID
            ,
        GroupID
            ,
        OutletName
            ,
        ItemName
            ,
        SessionName
            ,
        KOTName
        ,
        ReasonTypeID
        ,
        ReasonType
        ,
        Floor
        ,
        GuestID
         ,
        DepartmentDesc

       ,
        PayHeadName
        ,
        SalaryClauseName,
        PayHeadTypeName,
        City,
        LedgerHeadName,
        Value,
        Text
         ,
        SupplierID
            ,
        SupplierName
        ,
        ItemID
       ,
        itemName
            ,
        TaxName
            ,
        CancelllationType
            , category
    }
    public static class Extensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
        public static DateTime ChangeTime(this DateTime dateTime, string time)
        {
            string[] t = time.NulllToString().Split(':');
            int hours = t.Length >= 1 ? t[0].NulllToInt() : 0;
            int minutes = t.Length >= 2 ? t[1].NulllToInt() : 0;
            int seconds = t.Length >= 3 ? t[2].NulllToInt() : 0;
            int milliseconds = t.Length >= 4 ? t[3].NulllToInt() : 0;
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
        public static string Left(this object value, int len)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToString(value).Substring(0, len);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static string NulllToString(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToString(value);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static int NulllToInt(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    return default(int);
                }
            }
            catch (Exception)
            {
                return default(int);
            }
        }

        public static Int64 NulllToLong(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToInt64(value);
                }
                else
                {
                    return default(Int64);
                }
            }
            catch (Exception)
            {
                return default(Int64);
            }
        }

        public static decimal NulllToDecimal(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDecimal(value);
                }
                else
                {
                    return default(decimal);
                }
            }
            catch (Exception)
            {
                return default(decimal);
            }
        }


        public static bool NulllToBoolean(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToBoolean(value);
                }
                else
                {
                    return default(bool);
                }
            }
            catch (Exception)
            {
                return default(bool);
            }
        }

        //Added on 2016-09-22
        public static Double NulllToDouble(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDouble(value);
                }
                else
                {
                    return default(Double);
                }
            }
            catch (Exception)
            {
                return default(Double);
            }
        }

        public static DateTime NulllToDate(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDateTime(value);
                }
                else
                {
                    return default(DateTime);
                }
            }
            catch (Exception)
            {
                return default(DateTime);
            }
        }
        public static DateTime? NulllToDateNull(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDateTime(value);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
