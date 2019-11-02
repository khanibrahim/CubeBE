using BO;
using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cube.API
{
    public class ExaminationController : ApiController
    {
        private BL.Master.ExaminationService service = new BL.Master.ExaminationService();
        private BL.Master.UserService userService = new BL.Master.UserService();

        public Examination Get(long id)
        {
            return service.GetById(id);
        }

     
        public ApiResponse<Examination> Post(ListQuery<Examination> listQuery)
        {
            if (listQuery.RequestType == "Post")
            {
                var currentUser = userService.GetCurrentUser();
                listQuery.Item.RCB = currentUser.UserId;
                listQuery.Item.PropertyId = currentUser.PropertyId;
                return service.Add(listQuery.Item);
            }
            else if (listQuery.RequestType == "Get")
            {
                return service.GetByQuery(listQuery);
            }
            return new ApiResponse<Examination>() { Success = false, ErrorMessage = "Invalid Request" };
        }

        public ApiResponse<Examination> Put(Examination value)
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