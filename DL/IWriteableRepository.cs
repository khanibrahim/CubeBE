using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DL
{
    public interface IWritableRepository<T> where T : Base
    {
        ApiResponse<T> Add(T item);
        ApiResponse<T> Update(T item);
        void Delete(long id);


      //  ListQueryResult<Core.Domian.Settings.Reason> GetByQuery(ListQuery<Core.Domian.Settings.Reason> query);
    }
}
