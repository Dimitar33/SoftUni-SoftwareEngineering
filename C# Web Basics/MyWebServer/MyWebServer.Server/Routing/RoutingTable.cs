using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable(Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes)
        {
            routes = new()
            {
                [HttpMethod.Get] = new (),
                [HttpMethod.Delete] = new (),
                [HttpMethod.Post] = new (),
                [HttpMethod.Put] = new ()
            };
        }

        public IRoutingTable Map(string url, HttpMethod method, HttpResponse response)
        {
            return method switch
            {
                HttpMethod.Get => MapGet(url, response),
                _ => throw new InvalidOperationException($"Method {method} is invalid !")
            };
        }

        public IRoutingTable MapGet(string url, HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[HttpMethod.Get][url] = response;

            return this;
        }
    }
}
