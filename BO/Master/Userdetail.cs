using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Master
{
   public class Userdetail
    {
       public long UserId { get; set; }
       public string Username { get; set; }
        public string GuestId { get; set; }
        public string MobileNo { get; set; }        
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
         public string PropertyId { get; set; }
        public string RoleName { get; set; }
    }
}
