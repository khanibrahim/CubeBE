using BO.Master;
using System;
using System.Collections.Generic;
using System.Web.Http;

using WebApplication1.Models;
using BO;

namespace Cube.API
{
    public class QuestionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BL.Master.QuestionService service = new BL.Master.QuestionService();
        private BL.Master.UserService userService = new BL.Master.UserService();

        public List<BO.Master.Question> Get(string subjectid)
        {
            return new List<BO.Master.Question>();
        }

        public ApiResponse<Question> Post(ListQuery<Question> listQuery)
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
            return new ApiResponse<Question>() { Success = false, ErrorMessage = "Invalid Request" };

        }

        public void Delete(int id)
        {

            service.Delete(id);

           
        }

        public ApiResponse<Question> Put(BO.Master.Question question)
        {
          

            return service.Update(question);
        }

    }
}