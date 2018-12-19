using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class SubjectService : IService<BO.Master.Subject>
    {
        private SubjectRepository repository = new SubjectRepository();

        public List<Subject> ToList => throw new NotImplementedException();

        public ApiResponse<List<Subject>> List()
        {
            return repository.List();
        }

        public ApiResponse<Subject> Add(Subject entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public Subject GetById(long Id)
        {
            return repository.GetById(Id);
        }

        public ListQueryResult<Subject> GetByQuery(ListQuery<Subject> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Subject> Update(Subject entity)
        {
            return repository.Update(entity);
        }
    }
}
