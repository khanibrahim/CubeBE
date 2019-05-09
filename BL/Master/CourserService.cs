using BO;
using BO.Master;
using DL;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class CourserService : IService<Course>
    {
        private DL.Master.CourseRepository repository = new DL.Master.CourseRepository();


        public ApiResponse<List<Course>> List()
        {
            var response = new ApiResponse<List<Course>>();

            //response.Item = repository.ToList();
            return repository.List();
        }

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
            return repository.GetById(Id);
        }      

        public ListQueryResult<Course> GetByQuery(ListQuery<Course> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Course> Update(Course entity)
        {
            return repository.Update(entity);
        }
    }
}
