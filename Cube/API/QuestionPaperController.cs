using BL.Master;
using BO.Master;
using System.Collections.Generic;
using System.Web.Http;

namespace Cube.API
{
    public class QuestionPaperController : ApiController
    {
        private QuestionPaperService service = new QuestionPaperService();
        private UserService userService = new UserService();

        public List<QuestionPaper> Get()
        {
            return service.List().Item;
        }

        public QuestionPaper Get(int id)
        {
            return service.GetById(id);
        }

        public List<QuestionPaper> Post(QuestionPaper item)
        {
            service.Add(item);
            return service.List().Item;
        }

        public List<QuestionPaper> Put(QuestionPaper item)
        {
            service.Update(item);
            return service.List().Item;
        }

        public List<QuestionPaper> Delete(int id)
        {
            service.Delete(id);
            return service.List().Item;
        }
    }
}
