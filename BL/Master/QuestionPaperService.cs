using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class QuestionPaperService : IService<QuestionPaper>
    {
        private QuestionPaperRepository repository = new QuestionPaperRepository();

        public List<QuestionPaper> ToList => throw new NotImplementedException();

        public ApiResponse<List<QuestionPaper>> List()
        {
            return repository.List();
        }

        public ApiResponse<QuestionPaper> Add(QuestionPaper entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public QuestionPaper GetById(long Id)
        {
            return repository.GetById(Id);
        }

        public ListQueryResult<QuestionPaper> GetByQuery(ListQuery<QuestionPaper> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<QuestionPaper> Update(QuestionPaper entity)
        {
            return repository.Update(entity);
        }
    }
}
