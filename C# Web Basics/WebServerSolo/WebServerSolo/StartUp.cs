using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer;

namespace WebServerSolo
{
    public class Program
    {
        public static async Task Main()
        {
            
            Server server = new Server("127.0.0.1", 9090);

           await server.Start();       
        }
    }
}
