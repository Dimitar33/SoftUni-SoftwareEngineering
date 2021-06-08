using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Http;

namespace WebServer
{
    public class Server
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public Server(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            listener = new TcpListener(this.ipAddress, this.port);
        }

        public async Task Start()
        {

            this.listener.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient connection = await listener.AcceptTcpClientAsync();

                NetworkStream netwotkStream = connection.GetStream();

                var requestText = await ReadRequest(netwotkStream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                await WriteResponse(netwotkStream);

                connection.Close();

            }
        }
        private async Task<string> ReadRequest(NetworkStream netwotkStream)
        {
            int bufferLenght = 1024;
            byte[] buffer = new byte[bufferLenght];
            int totalBytes = 0;

            StringBuilder requestText = new StringBuilder();
           
            do
            {
                int bytesRead = await netwotkStream.ReadAsync(buffer, 0, bufferLenght);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("File to big!");
                }

                requestText.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (netwotkStream.DataAvailable);

            return requestText.ToString();
        }

        private static async Task WriteResponse(NetworkStream networkStream)
        {
            string responseText = @"
<html>
    <head>
        <link rel=""icon"" href=""data:,"">
    </head>
    <body>
        Hello from the server!
    </body>
</html>";


            var responseLengt = Encoding.UTF8.GetBytes(responseText);

            string response = $@"
HTTP/1.1 200 OK
Date: {DateTime.UtcNow:R}
Server: My Web Server
Content-Length: {responseLengt.Length}
Content-Type: text/html; charset=UTF-8

{responseText}";

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);
        }
    }
}
