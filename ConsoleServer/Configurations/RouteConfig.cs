using System.Web.Http;

namespace ConsoleServer.Configurations
{
   public class RouteConfig
   {
      public static void RegisterRoute(HttpConfiguration route)
      {
         route.Routes.MapHttpRoute(
            name: "DefaultAPI",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
      }
   }
}
