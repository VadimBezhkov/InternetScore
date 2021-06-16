using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InternetScore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           // routes.MapRoute(name: "Mycastom", url: "{controller}/{action}.{domain}", defaults: new {controller = "Internet", action="Index" },
           //     constraints: new { controller = "^I.*" });
       
           // routes.MapRoute(
           //    name: "Default2",
           //    url: "{controller}/{action}",
           //    defaults: new { controller = "Internet", action = "CategoryDetails" },
           //     constraints: new { controller = "^I.*" }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Internet", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
