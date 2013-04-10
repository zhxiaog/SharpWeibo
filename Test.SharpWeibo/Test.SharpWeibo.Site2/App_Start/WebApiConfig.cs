using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Test.SharpWeibo.Site2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "weiboAPI",
                routeTemplate: "api/{controller}/{action}/{UserId}",
                defaults: new { }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{action}/{userName}/{password}",
                defaults: new { }
            );
        }
    }
}
