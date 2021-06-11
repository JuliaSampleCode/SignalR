using Microsoft.AspNet.SignalR.Client;
using System;
using System.Linq;
using System.Net.Http;

namespace ConsoleClient
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Press enter to start");
         Console.ReadLine();
         Console.WriteLine("API call to server!");
         GetTimesFromServerAPI().ToList().ForEach(time =>
         {
            Console.WriteLine($"Time: {time}");
         });

         Console.WriteLine("\nPress enter to continue");
         Console.ReadLine();
         Console.WriteLine("SignalR call to server!");
         RunSignalR();
         Console.ReadLine();
      }

      static string[] GetTimesFromServerAPI()
      {
         HttpClient client = new HttpClient();
         HttpResponseMessage response = client.GetAsync("http://localhost:8080/api/time").Result;
         var result = response.Content.ReadAsAsync<string[]>().Result;
         if (response.IsSuccessStatusCode)
         {
            return result;
         }
         return null;
      }

      static void RunSignalR()
      {
         string url = "http://localhost:8080";
         HubConnection connection = new HubConnection(url);
         var proxy = connection.CreateHubProxy("notificationHub");
         try
         {
            connection.Start().Wait();
            proxy.Invoke<string[]>("Get").Result.ToList().ForEach(g => Console.WriteLine($"Item from get: {g}"));
            Console.WriteLine();

            proxy.On<string>("displayCurrentTime", time =>
            {
               Console.WriteLine($"Time from server: {time}");
            });

            proxy.Invoke("GetServerTime");
         }
         catch (Exception e) { Console.WriteLine($"Exception caught! {e}"); };
      }
   }
}
