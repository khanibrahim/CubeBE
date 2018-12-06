using BO;
using BO.Master;
using DL.Mappings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL.Master
{
    public class UserRepository : IRepository<Userdetail>
    { UserMapper mapper = new UserMapper();
        public List<Userdetail> ToList => throw new NotImplementedException();

        public ApiResponse<Userdetail> Add(Userdetail item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Userdetail GetById(long id)
        {
            using (var dbcontext = new SQL.CubeEntities())
            {
                var result = new Userdetail();
                var lquery = dbcontext.Userdetails.FirstOrDefault(it => it.UserId == id);
                result = mapper.Map(lquery); 
                return result;
            }
        }

        public ListQueryResult<Userdetail> GetByQuery(ListQuery<Userdetail> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Userdetail> Update(Userdetail item)
        {
            throw new NotImplementedException();
        }
    }
}
