using SampleApplication.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SampleApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Remove XML formatter to use Json only
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //加入自己定义的异常机制
            config.Filters.Add(new EziWebApiExceptionAttribute());

            //加入验证机制
            config.Filters.Add(new EziAuthorizationAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
