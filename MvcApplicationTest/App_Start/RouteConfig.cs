using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplicationTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new
                {
                    culture = "en",
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                constraints: new { culture =  "[a-z]{2}" }
            );

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { culture = "uk", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
