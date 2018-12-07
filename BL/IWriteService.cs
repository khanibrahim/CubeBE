using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public interface IWriteService<T> where T : Base
    {

        ApiResponse<T> Add(T entity);
        ApiResponse<T> Update(T entity);
        void Delete(long id);
    }
}
