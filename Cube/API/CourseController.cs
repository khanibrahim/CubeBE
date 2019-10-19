using BO;
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

        public ApiResponse<Course> Get()
        {
            return service.List();
        }

        public ApiResponse<Course> Post(ListQuery<Course> listQuery)
        {
            if (listQuery.RequestType == "Post")
            {
                var currentUser = userService.GetCurrentUser();
                listQuery.Item.RCB = currentUser.UserId;
                listQuery.Item.PropertyId = currentUser.PropertyId;
                return service.Add(listQuery.Item);
            }
            else if (listQuery.RequestType=="Get")
            {
                return service.GetByQuery(listQuery);
            }
            return new ApiResponse<Course>() { Success = false, ErrorMessage = "Invalid Request" };
        }

        public ApiResponse<Course> Put(Course value)
        {
            value.RUB = userService.GetCurrentUser().UserId;
            
            return service.Update(value);
        }

        public void Delete(int id)
        {

             service.Delete(id);
        }
    }
}