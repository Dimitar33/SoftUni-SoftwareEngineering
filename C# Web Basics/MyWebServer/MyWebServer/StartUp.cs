﻿using MyWebServer.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class StartUp
    {
        // localhost 127.0.0.1
        public static async Task Main()       
           => await new HttpServer("127.0.0.1", 9090, routes => routes.Map).Start();

            
        
    }
}
