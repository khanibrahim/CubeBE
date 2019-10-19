using BL.Master;
using BO;
using BO.Master;
using System.Collections.Generic;
using System.Web.Http;

namespace Cube.API
{
    public class SubjectController : ApiController
    {
        private SubjectService service = new SubjectService();

        private UserService userService = new BL.Master.UserService();

        public List<Subject> Get()
        {
            return new List<Subject>();
        }

        public Subject Get(int id)
        {
            return service.GetById(id);
        }

        public ApiResponse<Subject> Post(ListQuery<Subject> listQuery)
        {
            if (listQuery.RequestType == "Post")
            {
                var currentUser = userService.GetCurrentUser();
                listQuery.Item.RCB = currentUser.UserId;
                return service.Add(listQuery.Item);


            }
            else if (listQuery.RequestType=="Get")
            {
                return service.GetByQuery(listQuery);

            }
            return new ApiResponse<Subject>() { Success=false, ErrorMessage="Invalid Request." };

                    }

        public ApiResponse<Subject> Put(Subject item)
        {
            
            return service.Update(item);
        }

        public void Delete(int id)
        {

            service.Delete(id);
        }

    }
}
