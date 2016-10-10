using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BCMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //name: "Application",
            //url: "{*url}",
            //defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BCMS.Controllers" }
            );

            //routes.MapRoute(
            //    name: "Account",
            //    url: "Account/{*all}",
            //    defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            //    );
        }
    }
}
