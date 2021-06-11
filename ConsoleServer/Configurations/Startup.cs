using ConsoleServer.Configurations;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

namespace ConsoleServer
{
   public partial class Startup
   {
      public void InitiateConfig(IAppBuilder app)
      {
         HttpConfiguration config = new HttpConfiguration();
         RouteConfig.RegisterRoute(config);
         app.UseCors(CorsOptions.AllowAll);
         app.Map("/signalr", map =>
         {
            HubConfiguration hub = new HubConfiguration();
            map.RunSignalR();
         });
         app.UseWebApi(config);
      }
   }
}
