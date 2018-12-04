using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Master
{
  public  class Property:Base
    {
        public string Name { get; set; }
        public string Slogan { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Mobile { get; set; }
        public byte[] Logo { get; set; }
        public string ContactPerson { get; set; }

    }
}
