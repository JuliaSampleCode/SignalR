using ConsoleServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace ConsoleServer
{
   public partial class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         InitiateConfig(app);
      }
   }
}
