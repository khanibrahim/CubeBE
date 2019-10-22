using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Master
{
    public class Lesson : Base
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public long SubjectId { get; set; }
        public  Subject Subject { get; set; }
    }
}
