using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        void Map(string url, HttpResponse response);

        void Map(string url, HttpMethod method, HttpResponse response);

        void MapGet(string url, HttpResponse response);
    }
}
