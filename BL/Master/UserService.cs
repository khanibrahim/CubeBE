using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Master
{
    public class UserService : IService<Userdetail>
    {
        UserRepository repositor = new UserRepository();


        public ApiResponse<Userdetail> Add(Userdetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Userdetail GetById(long Id)
        {
            return repositor.GetById(Id);
        }

        public ListQueryResult<Userdetail> GetByQuery(ListQuery<Userdetail> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Userdetail> Update(Userdetail entity)
        {
            return this.repositor.Update(entity);
        }
    }
}