using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Master
{
   public class Course:Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long PropertyId { get; set; }
    }
}
