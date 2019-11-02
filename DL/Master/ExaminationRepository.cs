using AutoMapper;
using BO;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Master
{
    public class ExaminationRepository : IRepository<Examination>
    {

        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SQL.Examination, BO.Master.Examination>(); ;

        });

        


        public ApiResponse<Examination> Add(Examination item)
        {
            var result = new ApiResponse<Examination>();
            using(var dbcontext = new SQL.Entities())
            {
                var dbItem = new SQL.Examination();
                dbItem.Name = item.Name;
                dbItem.IsActive = true;
                dbItem.Description = item.Description;
                dbItem.PropertyId = item.PropertyId;
                dbItem.RCT = DateTime.Now;
                dbItem.RUT = DateTime.Now;
                dbItem.RUB = item.RCB;
                dbItem.RCB = item.RCB;
                dbcontext.Examinations.Add(dbItem);
                dbcontext.SaveChanges();
                result.Success = true;
            }
            return result;
        }

        public void Delete(long id)
        {
            using (var dbcontext = new SQL.Entities())
            {
                var item = dbcontext.Examinations.FirstOrDefault(it => it.Id == id);
                item.IsActive = false;
                dbcontext.SaveChanges();

            }
        }

        public Examination GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Examination> GetByQuery(ListQuery<Examination> query)
        {
            var result = new ApiResponse<Examination>();
            result.Items = new List<Examination>();
            try
            {
                IMapper iMapper = config.CreateMapper();
                using (var dbcontext = new SQL.Entities())
                {
                    var linqQuery = dbcontext.Examinations.Where(it => it.IsActive == true);
                    foreach (var item in linqQuery)
                    {
                        result.Items.Add(iMapper.Map<SQL.Examination, BO.Master.Examination>(item));
                    }

                    result.Success = true;

                }
            }
            catch(Exception e)
            {
                result.Success = false;
                result.ErrorMessage = e.Message;
                result.DetailedError = e;

            }
            return result;
        }

        public ApiResponse<Examination> Update(Examination item)
        {
            var result = new ApiResponse<Examination>();
            using (var dbcontext = new SQL.Entities())
            {
                var dbItem = dbcontext.Examinations.FirstOrDefault(it => it.Id == item.Id);
                dbItem.Name = item.Name;
                dbItem.Description = item.Description;
                dbItem.RUT = DateTime.Now;

                dbItem.RUB = item.RUB;
                try
                {
                    dbcontext.SaveChanges();
                    result.Success = true;
                }

                catch(Exception e)
                {
                    result.Success = false;
                    result.ErrorMessage = e.Message;
                    result.DetailedError = e;

                }
                }
            return result;
        }
    }
}
