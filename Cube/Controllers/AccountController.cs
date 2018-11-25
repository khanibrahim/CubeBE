using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return PartialView();
        }

        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return PartialView();
        }
        public ActionResult ChangePassword()
        {
            return PartialView();
        }


    }
}