using BO;
using BO.Master;
using DL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DL.Master
{
    public class UserRepository : IRepository<Userdetail>
    {
        private UserMapper mapper = new UserMapper();

        public List<Userdetail> ToList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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
            using (var dbcontext = new SQL.Entities())
            {
                var result = new Userdetail();
                var lquery = dbcontext.Userdetails.FirstOrDefault(it => it.UserId == id);
                result = mapper.Map(lquery);
                return result;
            }
        }

        public ApiResponse<Userdetail> GetByQuery(ListQuery<Userdetail> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Userdetail> Update(Userdetail item)
        {
            var result = new ApiResponse<Userdetail>();
            result.Success = false;
            result.Item = item;

            using (var dbcontext = new SQL.Entities()) {
                var dbitem = dbcontext.Userdetails.FirstOrDefault(it => it.UserId == item.UserId);
                dbitem.MobileNo = item.MobileNo;
                dbitem.Email = item.Email;
                //dbitem.RUB = item.RUB;
                //dbitem.RUT = DateTime.Now;
                try
                {
                    dbcontext.SaveChanges();
                    result.Success = true;
                }
                catch (Exception e) {
                    result.Success = false;
                    result.ErrorMessage = e.Message;
                    result.DetailedError = e;

                }
                }
            return result;
        }
    }
}
