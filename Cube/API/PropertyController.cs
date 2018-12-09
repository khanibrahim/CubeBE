using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web.Http.Cors;
using BO;

namespace Cube.API
{
   // [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class PropertyController : ApiController
    {
        BL.Master.PropertyService service = new BL.Master.PropertyService();
        BL.Master.UserService userService = new BL.Master.UserService();
        // GET api/<controller>

        public Property Get()
        {
            var currentUser = userService.GetCurrentUser();
            return service.GetById(currentUser.PropertyId); 
            //return new Property() { Name = "name" };
        }

        // GET api/<controller>/5
        //public Property Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        // POST api/<controller>
        [AllowAnonymous]
        public Property Post(Property value)
        {
            return new Property() { Name = value.Name };
        }

        // PUT api/<controller>/5
        public ApiResponse<Property> Put([FromBody]Property value)
        {
            var currentUser = userService.GetCurrentUser();
            value.RUB = currentUser.UserId;
            return service.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}