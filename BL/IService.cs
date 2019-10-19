using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IService<T>
        where T : Base
    {
        T GetById(long Id);
        ApiResponse<T> GetByQuery(ListQuery<T> query);
        ApiResponse<T> Add(T entity);
        ApiResponse<T> Update(T entity);
        void Delete(long id);
    }
}
