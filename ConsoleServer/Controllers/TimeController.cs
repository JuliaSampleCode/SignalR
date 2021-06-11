using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ConsoleServer.Controllers
{
   public class TimeController : ApiController
   {
      public IEnumerable<string> Get()
      {
         Console.WriteLine("Controller method called!");
         return new string[] { "second", "minute", "hour", "day", "week" };
      }
   }
}
