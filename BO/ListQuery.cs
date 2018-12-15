using BO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BO
{

    public class ListQuery<T>:Base
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<QueryParameter> Parameters { get; set; }
        
        public void AddParameter(QueryParameter queryParameter)
        {
            if (this.Parameters == null) Parameters = new List<QueryParameter>();
            Parameters.Add(queryParameter);
        }

        public void AddParameter(string name, string value)
        {
            this.AddParameter(new QueryParameter() { Name = name, Value = value });
        }

        public string QueryType { get; set; }
        public long CurrentUserId { get; set; }
    }
}
