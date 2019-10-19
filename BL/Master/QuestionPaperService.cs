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

        public ApiResponse<QuestionPaper> GetByQuery(ListQuery<QuestionPaper> query)
        {
            return repository.GetByQuery(query);
        }

        public ApiResponse<QuestionPaper> Update(QuestionPaper entity)
        {
            return repository.Update(entity);
        }
    }
}
