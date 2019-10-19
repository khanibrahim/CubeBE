using BL.Master;
using BO;
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
            return new List<QuestionPaper>();
        }

        public QuestionPaper Get(int id)
        {
            return service.GetById(id);
        }

        public ApiResponse<QuestionPaper> Post(QuestionPaper item)
        {

            return service.Add(item);
        }

        public ApiResponse<QuestionPaper> Put(QuestionPaper item)
        {

            return service.Update(item);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        
        }
    }
}
