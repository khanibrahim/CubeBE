using BO.GuestApp.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BO_GuestApp_M = BO.GuestApp.Master;

namespace WebApplication1.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class GuestController : ApiController
    {


       
        // GET api/<controller>
       public  BO_GuestApp_M.Guest Get()
        {
            return new Guest() {
                Name="Nazih",
                GuestEmail = "Nazih@gmail.com"
            };
        }

        // GET api/<controller>/5
        public BO_GuestApp_M.Guest Get(int id)
        {
            throw new NotImplementedException();
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