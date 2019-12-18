using System;
using System.IO;   // input output
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Lab_21_Async_Await
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {

           

            // Main method here
            // setup: create our data file
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1,bob,21");
            File.AppendAllText("data.csv", "\n2,Gina,21");
            File.AppendAllText("data.csv", "\n3,Mkhitaryan,31");

            // Sync : Wait for it
            
            // AsyncMethod: Dont wait for it
            GetWebPageSync();

           
           // ReadDataAsync();
           

            s.Start();
            // ReadDataSync();
            GetWebPageAsync();

            s.Stop();

            Console.WriteLine("Code has finished");
        

            
            
        }

        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);
        }

        async static void ReadDataAsync()  // using special async keyword
        {
            var output = await File.ReadAllTextAsync("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nAsync\n");
            Console.WriteLine(output);
        }

        static void GetWebPageSync()
        {
            var uri = new Uri("https://www.itv.com/news/sport/");

            
            var webClient = new WebClient { Proxy = null };
            
            webClient.DownloadFile(uri, "page01.html");
            Thread.Sleep(3000);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "page01.html");
            
        }

         static void GetWebPageAsync()
        {
            var uri = new Uri("https://www.arsenal.com/");

          
             var webClient = new WebClient { Proxy = null };

            webClient.DownloadFileAsync(uri, "page02.html");
            Thread.Sleep(3000);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "page02.html");

            Console.WriteLine($"WebClient page downlaoded at time {s.ElapsedMilliseconds}");
        }
    }
}
