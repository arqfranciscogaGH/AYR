
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiFiltro",
            //    routeTemplate: "api/{controller}/{filtro}",
            //    defaults: new { filtro = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "DefaultApipPorPagina",
                routeTemplate: "api/{controller}/{pagina}/{registros}",
                defaults: new { pagina = RouteParameter.Optional , registros = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                 name: "DefaultApipPorPaginaFiltro",
                 routeTemplate: "api/{controller}/{pagina}/{registros}/{filtro}",
                 defaults: new { pagina = RouteParameter.Optional, registros = RouteParameter.Optional , filtro = RouteParameter.Optional }
             );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
