using BO.Master;
using System.Collections.Generic;
using System.Web.Http;

namespace Cube.API
{
    public class CourseController : ApiController
    {
        private BL.Master.CourserService service = new BL.Master.CourserService();
        private BL.Master.UserService userService = new BL.Master.UserService();

        public Course Get(long id)
        {
            return service.GetById(id);
        }

        public List<Course> Get()
        {
            return service.List().Item;
        }

        public List<Course> Post(Course value)
        {
            var currentUser = userService.GetCurrentUser();
            value.RCB = currentUser.UserId;
            value.PropertyId = currentUser.PropertyId;
            service.Add(value);
            return service.List().Item;
        }

        public List<Course> Put(Course value)
        {
            value.RUB = userService.GetCurrentUser().UserId;
            service.Update(value);
            return service.List().Item;
        }

        public List<Course> Delete(int id)
        {
            service.Delete(id);
            return service.List().Item;
        }
    }
}