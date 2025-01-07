using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace UserLibraryApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "UserV1",
            //    routeTemplate: "user/v1/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "UserV1" }
            //);
            
            //config.Routes.MapHttpRoute(
            //    name: "UserV2",
            //    routeTemplate: "user/v2/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "UserV2" }
            //);

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
