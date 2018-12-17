using BL.Master;
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
            return service.List().Item;
        }

        public Subject Get(int id)
        {
            return service.GetById(id);
        }

        public List<Subject> Post(Subject item)
        {
            service.Add(item);
            return service.List().Item;
        }

        public List<Subject> Put(Subject item)
        {
            service.Update(item);
            return service.List().Item;
        }

        public List<Subject> Delete(int id)
        {
            service.Delete(id);
            return service.List().Item;
        }

    }
}
