using BO;
using BO.Master;
using DL;
using DL.Master;
using System;
using System.Collections.Generic;

namespace BL.Master
{
    public class LessonService : IService<BO.Master.Lesson>
    {
        private LessonRepository repository = new LessonRepository();

        public List<Lesson> ToList => throw new NotImplementedException();

        public ApiResponse<List<Lesson>> List()
        {
            return repository.List();
        }

        public ApiResponse<Lesson> Add(Lesson entity)
        {
            return repository.Add(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public Lesson GetById(long Id)
        {
            return repository.GetById(Id);
        }

        public ListQueryResult<Lesson> GetByQuery(ListQuery<Lesson> query)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Lesson> Update(Lesson entity)
        {
            return repository.Update(entity);
        }
    }
}
