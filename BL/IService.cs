using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IService<T>:IReadService<T>, IWriteService<T> where T : Base
    {
        
    }
}
