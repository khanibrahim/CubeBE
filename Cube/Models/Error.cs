using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Error
    {
        public int error_code { get; set; }

        public string error { get; set; }
        public string error_description { get; set; }
    }
}