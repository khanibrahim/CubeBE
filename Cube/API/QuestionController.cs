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

        public ApiResponse<Question> Post(BO.Master.Question question)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //question.RUT = new System.DateTime();
            //question.RCT = new System.DateTime();

            

            return service.Add(question);

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