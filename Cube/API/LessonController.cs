    using BL.Master;
using BO;
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
            return new List<Lesson>();
            //throw new NotImplimentedextion
         //   return service.List().Item;
        }

        public Lesson Get(int id)
        {
            return service.GetById(id);
        }

        public ApiResponse<Lesson> Post(Lesson item)
        {

            return service.Add(item);
        }

        public ApiResponse<Lesson>  Put(Lesson item)
        {
            
            return service.Update(item);
        }

        public void Delete(int id)
        {

             service.Delete(id);
        }

    }
}
