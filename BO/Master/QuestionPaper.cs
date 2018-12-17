using System;

namespace BO.Master
{
    public class QuestionPaper:Base
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public long? SubjectId { get; set; }
    }
}
