﻿using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DL
{
    public interface IReadableRepository<T> where T : Base
    {
        //List<T> ToList { get; }
        ListQueryResult<T> GetByQuery(ListQuery<T> query);
        T GetById(int id);

        
    }
}
