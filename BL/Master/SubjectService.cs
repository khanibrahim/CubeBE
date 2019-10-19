using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class SubjectService : IService<Subject>
    {
        private readonly SubjectRepository repository = new SubjectRepository();
        public ApiResponse<Subject> Add(Subject entity)
        {
            return this.repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public Subject GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Subject> GetByQuery(ListQuery<Subject> query)
        {
            return repository.GetByQuery(query);
        }

        public ApiResponse<Subject> Update(Subject entity)
        {

            return this.repository.Update(entity);
        }
    }
}
