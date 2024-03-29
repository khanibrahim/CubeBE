﻿using System.Web;
using System.Web.Mvc;
using WebApplication1.App_Start;

namespace WebApplication1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new CustomAuthorize());
        
        }
    }
}
