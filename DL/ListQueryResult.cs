using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL
{
    public class ListQueryResult<T> where T:Base    {
        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }


        internal void Add(T item)
        {
            if (this.Items == null) this.Items = new List<T>();
            this.Items.Add(item);
        }
    }
}
