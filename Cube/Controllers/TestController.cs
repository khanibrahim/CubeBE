using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO_GuestApp_M = BO.GuestApp.Master;
namespace WebApplication1.Controllers
{   
[AllowAnonymous]
    public class TestController : ApiController
    {
       
        // GET api/<controller>
        [AcceptVerbs("GET","POST")]
        public BO_GuestApp_M.Guest Get()
        {

            return new BO_GuestApp_M.Guest();
            throw new NotImplementedException();
            //var result = obj.Get_Record("GST00001", "", true, "", "");
          //  return result.FirstOrDefault();
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            BL.GuestApp.Master.Guest obj = new BL.GuestApp.Master.Guest();
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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