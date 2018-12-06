using BO.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
namespace Cube
{
    public static class UserServiceExtention
    {

        public static BO.Master.Userdetail GetCurrentUser(this BL.IService<Userdetail> userService)
        {
            var currentUser = new Userdetail();
            var currentUserId = HttpContext.Current.User.Identity.GetUserId<long>();
            currentUser = userService.GetById(currentUserId);
            return currentUser;
        }
    }
}