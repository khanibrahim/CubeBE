using BO.Master;
using Microsoft.AspNet.Identity;
using System.Web;
namespace Cube
{
    public static class UserServiceExtention
    {

        public static Userdetail GetCurrentUser(this BL.IService<Userdetail> userService)
        {
            // var currentUser = new Userdetail();
            // var currentUserId = HttpContext.Current.User.Identity.GetUserId<long>();
            // currentUser = userService.GetById(currentUserId);
            return userService.GetById(HttpContext.Current.User.Identity.GetUserId<long>());
        }
    }
}