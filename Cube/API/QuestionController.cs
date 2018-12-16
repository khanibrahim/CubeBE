using BO.Master;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;

namespace Cube.API
{
    public class QuestionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BL.Master.QuestionService service = new BL.Master.QuestionService();
        private BL.Master.UserService userService = new BL.Master.UserService();

        //GET: api/Question
        public List<Question> Get()
        {
            return service.List().Item;
        }

        // POST: api/Question
        //[ResponseType(typeof(Question))]
        public List<Question> Post(Question question)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //question.RUT = new System.DateTime();
            //question.RCT = new System.DateTime();

            service.Add(question);

            return service.List().Item;

        }

        // DELETE: api/Question/5
        public List<Question> Delete(int id)
        {
            //if (question == null)
            //{
            //    return NotFound();
            //}

            service.Delete(id);

            return service.List().Item;
        }

        // PUT: api/Question/5
        public List<Question> Put(Question question)
        {
            if(question.Id != 0)
            service.Update(question);

            return service.List().Item;        
        }

        // GET: api/Question/5
        //[ResponseType(typeof(Question))]
        //public IHttpActionResult GetQuestion(int id)
        //{
        //    Question question = db.Questions.Find(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(question);
        //}




        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool QuestionExists(int id)
        //{
        //    return db.Questions.Count(e => e.id == id) > 0;
        //}
    }
}