﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Maha.Microservices.Host
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("json.rpc");
            routes.IgnoreRoute("json.rpchelp");

            routes.MapRoute(
               name: "HomeIndex",
               url: "",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Method",
               url: "method",
               defaults: new { controller = "Home", action = "Method", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
