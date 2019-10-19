using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DL
{
    public interface IRepository<T> 
        where T : Base

    {
        T GetById(long id);
        ApiResponse<T> GetByQuery(ListQuery<T> query);
        ApiResponse<T> Add(T item);
        ApiResponse<T> Update(T item);
        void Delete(long id);


    }


}
