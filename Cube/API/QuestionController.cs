using BO.Master;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Cube.Models;
using WebApplication1.Models;

namespace Cube.API
{
    public class QuestionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BL.Master.QuestionService service = new BL.Master.QuestionService();
        private BL.Master.UserService userService = new BL.Master.UserService();

        public List<BO.Master.Question> Get(string subjectid)
        {
            return service.List(Convert.ToInt32(subjectid)).Item;
        }

        public List<BO.Master.Question> Post(BO.Master.Question question)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //question.RUT = new System.DateTime();
            //question.RCT = new System.DateTime();

            service.Add(question);

            return service.List(0).Item;

        }

        public List<BO.Master.Question> Delete(int id)
        {
            //if (question == null)
            //{
            //    return NotFound();
            //}

            service.Delete(id);

            return service.List(0).Item;
        }

        public List<BO.Master.Question> Put(BO.Master.Question question)
        {
            if (question.Id != 0)
            {
                service.Update(question);
            }

            return service.List(0).Item;
        }

    }
}