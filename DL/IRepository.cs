using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DL
{
    public interface IRepository<T> :IReadableRepository<T>, IWritableRepository<T>
        where T : Base
        
    {
        List<T> ToList { get; }
        ListQueryResult<T> GetByQuery(ListQuery<T> query);
        T GetById(int id);

      //  ListQueryResult<Core.Domian.Settings.Reason> GetByQuery(ListQuery<Core.Domian.Settings.Reason> query);

    }

  
}
