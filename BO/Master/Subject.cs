using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Master
{
    public class Subject:Base
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public long CourseId { get; set; }
        public Nullable<short> Part { get; set; }
    }
}
