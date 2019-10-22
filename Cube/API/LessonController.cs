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

        public ApiResponse<Lesson> Post(ListQuery<Lesson> listQuery)
        {
            var currentUser = userService.GetCurrentUser();
            if (listQuery.RequestType == "Post")
            {
                
                listQuery.Item.RCB = currentUser.UserId;
                return service.Add(listQuery.Item);
            }
            else if (listQuery.RequestType == "Get")
            {
                listQuery.AddParameter(new QueryParameter() { Name = "CurrentUserId", Value = currentUser.UserId.ToString() });
                return service.GetByQuery(listQuery);
            }
            return new ApiResponse<Lesson>() { Success = false, ErrorMessage = "Invalid Request" };
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
