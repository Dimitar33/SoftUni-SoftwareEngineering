﻿using MyWebServer.Server.Http;
using MyWebServer.Server.Routing;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAdress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAdress, int port, Action<IRoutingTable> routing)
        {
            this.ipAdress = IPAddress.Parse(ipAdress);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAdress, this.port);

            routing(this.routingTable = new RoutingTable());
        }

        public async Task Start()
        {

            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}");

            while (true)
            {
                TcpClient connection = await serverListener.AcceptTcpClientAsync();

                NetworkStream stream = connection.GetStream();

                var requestText = await ReadRequest(stream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                await WriteResponse(stream);

                connection.Close();
            }
        }

        private async Task WriteResponse(NetworkStream stream)
        {
            string content = @"
<html>
    <head>
        <link rel=""icon"" href=""data;,"">
    </head>
      <body>
          Hello from my server!
      </body>
</html>";
            int contentLenght = Encoding.UTF8.GetByteCount(content);


            string response = $@"
HTTP/1.1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow:R}
Content-Length: {contentLenght}
Content-Type: text/html; charset=UTF-8

{content}";

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            await stream.WriteAsync(responseBytes);
        }

        private async Task<string> ReadRequest(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];

            StringBuilder requestBuilder = new StringBuilder();

            int totalBytes = 0;
        
            do
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, 1024);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("File to big!");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (stream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
