using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO
{
    public class ApiResponse<t>
    {
        public bool Success { get; set; }
        public long TransactionId { get; set; }
        public string ErrorMessage { get; set; }
        public Exception DetailedError { get; set; }
        public t Item { get; set; }
    }
}