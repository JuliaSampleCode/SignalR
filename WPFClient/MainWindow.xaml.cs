using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;
using System.Windows;

namespace WPFClient
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Main_OnLoaded(object sender, RoutedEventArgs args)
      {
         string url = "http://localhost:8080";

         //API
         HttpClient client = new HttpClient();
         HttpResponseMessage response = client.GetAsync(url + "/api/time").Result;
         Dispatcher.Invoke(() => ValueFromAPI.Text = "Values from API server: " + String.Join(", ", response.Content.ReadAsAsync<string[]>().Result));

         //SignalR         
         HubConnection connection = new HubConnection(url);
         var proxy = connection.CreateHubProxy("notificationHub");
         try
         {
            connection.Start().Wait();
            Dispatcher.Invoke(() => ValueFromSignalR.Text = "Values from SignalR method: " + String.Join(", ", proxy.Invoke<string[]>("Get").Result));

            proxy.On<string>("displayCurrentTime", time =>
            {
               Dispatcher.Invoke(() =>
               {
                  ServerTime.Text = time;
               });
            });
            proxy.Invoke("GetServerTime");
         }
         catch (Exception e) { Console.WriteLine(e); };
      }
   }
}
