using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace FootballApi.Startup
{
    public class WebApiConfiguration
    {
        public static void Configure(IAppBuilder appBuilder, HttpConfiguration httpConfiguration)
        {
            ConfigureJsonFormatter(httpConfiguration);
            MapRoutes(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }

        private static void MapRoutes(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Routes.MapHttpRoute(
                name: "Default Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});
        }

        private static void ConfigureJsonFormatter(HttpConfiguration httpConfiguration)
        {
            var jsonMediaTypeFormatter = httpConfiguration.Formatters.JsonFormatter;
            jsonMediaTypeFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonMediaTypeFormatter.SerializerSettings.Culture = CultureInfo.GetCultureInfo("en-GB");
        }
    }
}