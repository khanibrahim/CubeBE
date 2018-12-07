using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cube.API
{
    public class PropertyController : ApiController
    {
        BL.Master.PropertyService service = new BL.Master.PropertyService();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Property Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<controller>
        [AllowAnonymous]
        public Property Post(Property value)
        {
            return new Property() { Name = value.Name };
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}