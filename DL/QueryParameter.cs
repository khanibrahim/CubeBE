using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL
{
    public class QueryParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateRange Range { get; set; }
        public CompareOperator Operator { get; set; }

        public string MaxValue { get; set; }
    }
}
