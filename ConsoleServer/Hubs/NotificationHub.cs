using Microsoft.AspNet.SignalR;
using System;
using System.Threading;

namespace ConsoleServer.Hubs
{
   public class NotificationHub : Hub
   {
      public string[] Get()
      {
         return new string[] { "a", "b", "c", "d", "e" };
      }

      public void GetServerTime()
      {
         do
         {
            Console.WriteLine("SignalR method called!");
            Clients.All.displayCurrentTime($"{DateTime.UtcNow}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
         } while (true);
      }
   }
}
