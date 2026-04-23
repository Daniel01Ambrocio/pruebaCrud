using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors; // 👈 AGREGA ESTO

namespace apiEmpresa
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // 🔥 HABILITAR CORS
            var cors = new EnableCorsAttribute(
                "http://localhost:5173", // tu React Vite
                "*",
                "*"
            );

            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new CorsPreflightHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}