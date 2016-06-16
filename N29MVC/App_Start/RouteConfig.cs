using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace N29MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",  // 注册一些占位符
                defaults: new { controller = "Home"/*占位符默认值*/, action = "Index", id = UrlParameter.Optional/*可写可不写*/ }
            );
        }
    }
}