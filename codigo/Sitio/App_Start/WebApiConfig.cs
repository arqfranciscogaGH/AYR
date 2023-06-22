
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;


namespace Sitio
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                   name: "DefaultApi",
                   routeTemplate: "api/{controller}",
                   defaults: null
               );
   
            config.Routes.MapHttpRoute(
                name: "RegistrosLlave",
                routeTemplate: "api/{controller}/{llave}",
                defaults: new { llave = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "RegistrosIdLlave",
                routeTemplate: "api/{controller}/{id}/{llave}",
                defaults: new { id = RouteParameter.Optional , llave = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "RegistrosPorPagina",
                routeTemplate: "api/{controller}/{pagina}/{registrosPorPagina}/{llave}",
                defaults: new { pagina = RouteParameter.Optional , registrosPorPagina = RouteParameter.Optional, llave = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                 name: "RegistrosPorPaginaFiltro",
                 routeTemplate: "api/{controller}/{pagina}/{registrosPorPagina}/{filtro}/{llave}",
                 defaults: new { pagina = RouteParameter.Optional, registrosPorPagina = RouteParameter.Optional , filtro = RouteParameter.Optional , llave = RouteParameter.Optional }
             );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
