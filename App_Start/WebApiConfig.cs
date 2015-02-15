using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace PizzaDelivery01.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Product",
                routeTemplate: "api/product/{id}",
                defaults: new { controller = "product", id = RouteParameter.Optional }
            );

            //JSON format responce
            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}