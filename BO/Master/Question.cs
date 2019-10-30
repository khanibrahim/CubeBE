using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Master
{
    public class Question:Base
    {
        public string Question1 { get; set; }
        public Nullable<long> LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public Course Course { get; set; }
        public Subject Subject { get; set; }
    }
}
