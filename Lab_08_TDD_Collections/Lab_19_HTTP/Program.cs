using System;
using System.Net;
using System.Diagnostics;
namespace Lab_19_HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://www.bbc.co.uk/weather");

            Console.WriteLine($"Host is {uri.Host},Prt is {uri.Port}, Path is {uri.AbsolutePath}");

            //get page

            var webClient = new WebClient { Proxy = null };
            
            webClient.DownloadFile(uri, "localPage.html");

            // run page manually
            System.Threading.Thread.Sleep(1000);
            
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localPage.html");
        }
    }
}
