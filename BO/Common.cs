using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SP_Result_Transaction
    {
        public int TranNo { get; set; }
        public string No { get; set; }
        public string message { get; set; }
        public string ReturnVal_1 { get; set; }
        public string ReturnVal_2 { get; set; }
        public string ReturnVal_3 { get; set; }
        public string ReturnVal_4 { get; set; }
        public int Flag { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }

        public static string Color_Fail = "#C46A69";
        public static string Color_Success = "#739E73";
        public static string Color_Info = "#1c84c6";
        public static string Icon_Fail = "fa fa-warning shake animated";
        public static string Icon_Success = "fa fa-check";
        public static string Icon_Info = "fa fa-info-circle";
    }
}
