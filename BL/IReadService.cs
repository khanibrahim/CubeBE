﻿using BO;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IReadService<T> where T : Base
    {
        List<T> ToList { get; }
        ListQueryResult<T> GetByQuery(ListQuery<T> query);
        T GetById(long Id);
       
    }
}
