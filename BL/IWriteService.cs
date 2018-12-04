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
       
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
