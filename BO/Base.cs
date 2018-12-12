using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public abstract class Base
    {
        public long Id { get; set; }
        public long RCB { get; set; }
        public long RUB { get; set; }
        public DateTime RCT { get; set; }
        public DateTime RUT { get; set; }
        public bool? IsActive { get; set; }
    }
}
