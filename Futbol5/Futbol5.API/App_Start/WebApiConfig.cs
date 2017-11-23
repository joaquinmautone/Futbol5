using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Futbol5.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            string client_url = ConfigurationManager.AppSettings["CLIENT_URL"].ToString();
            var corsAttr = new EnableCorsAttribute(client_url, "*", "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
