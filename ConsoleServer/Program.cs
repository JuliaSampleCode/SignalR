using Microsoft.Owin.Hosting;
using System;

namespace ConsoleServer
{
   class Program
   {
      static void Main(string[] args)
      {
         string url = "http://localhost:8080";
         using (WebApp.Start<Startup>(url))
         {
            Console.WriteLine($"Server started at {url}");
            Console.ReadLine();
         }
      }
   }
}
