using BO;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Master
{
    public class CourserService : IService<Course>
    {
        DL.Master.CourseRepository repository = new DL.Master.CourseRepository();

        public List<Course> ToList => throw new NotImplementedException();

        public ApiResponse<Course> Add(Course entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
             repository.Delete(id);
        }

        public Course GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public ListQueryResult<Course> GetByQuery(ListQuery<Course> query)
        {
            return repository.GetByQuery(query);
        }

        public ApiResponse<Course> Update(Course entity)
        {
            return repository.Update(entity);
        }
    }
}
