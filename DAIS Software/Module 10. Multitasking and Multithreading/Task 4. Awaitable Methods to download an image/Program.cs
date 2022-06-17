using System.Drawing;
using System.Net;
using System.Text;

namespace Task_4._Awaitable_Methods_to_download_an_image
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://i.natgeofe.com/n/8071137b-2890-4ded-8420-41e3485b1eb9/domestic-cat.jpg?w=1272&h=848";

            await DownloadImg(url);
            Thread.Sleep(2000);
        }

        public static async Task DownloadImg(string url)
        {

            await Task.Yield();

            WebClient client = new WebClient();

            client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");

        }
    }
}