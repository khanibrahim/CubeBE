using BO;
using BO.Master;
using DL;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class QuestionService : IService<Question>
    {
        private DL.Master.QuestionRepository repository = new DL.Master.QuestionRepository();

        public List<Question> ToList => throw new NotImplementedException();

        public ApiResponse<List<Question>> List()
        {
            return repository.List();
        }

        public ApiResponse<Question> Add(Question entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public Question GetById(long Id)
        {
            return repository.GetById(Id);
        }

        public ListQueryResult<Question> GetByQuery(ListQuery<Question> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Question> Update(Question entity)
        {
            return repository.Update(entity);
        }
    }
}
