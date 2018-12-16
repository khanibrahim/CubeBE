using AutoMapper;
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
    public class CourseController : ApiController
    {
        // GET api/<controller>
        BL.Master.CourserService service = new BL.Master.CourserService();
        BL.Master.UserService userService = new BL.Master.UserService();

        [AllowAnonymous]
        public ListQueryResult<Course> Get(ListQuery<Course> query)
        {
            if (query == null) {
                query = new ListQuery<Course>();
            }
            query.CurrentUserId = userService.GetCurrentUser().UserId;
            return service.GetByQuery(query);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public ApiResponse<Course> Post([FromBody]Course value)
        {
            var currentUser = userService.GetCurrentUser();
          value.RCB= currentUser.UserId;
            value.PropertyId = currentUser.PropertyId;
            return service.Add(value);
        }

        // PUT api/<controller>/5
        public ApiResponse<Course> Put(int id, [FromBody]Course value)
        {
            value.RUB = userService.GetCurrentUser().UserId;
            return service.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}