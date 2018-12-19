using BL.Master;
using BO.Master;
using System.Collections.Generic;
using System.Web.Http;

namespace Cube.API
{
    public class LessonController : ApiController
    {
        private LessonService service = new LessonService();

        private UserService userService = new BL.Master.UserService();

        public List<Lesson> Get()
        {
            return service.List().Item;
        }

        public Lesson Get(int id)
        {
            return service.GetById(id);
        }

        public List<Lesson> Post(Lesson item)
        {
            service.Add(item);
            return service.List().Item;
        }

        public List<Lesson> Put(Lesson item)
        {
            service.Update(item);
            return service.List().Item;
        }

        public List<Lesson> Delete(int id)
        {
            service.Delete(id);
            return service.List().Item;
        }

    }
}
