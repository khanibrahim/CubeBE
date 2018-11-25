using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace WebApplication1.Controllers
{
    public class UserManageController : Controller
    {

        
       
        // GET: UserManage
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Register()
        {
            return View();
        }
    }
}