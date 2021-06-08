using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Http
{
    public abstract class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers.Add("Server:", "My Web Server");
            Headers.Add("Date:", $"{DateTime.UtcNow:R}");
        }
        public HttpStatusCode StatusCode { get; init; }

        public HttpHeadersCollection Headers { get; } = new HttpHeadersCollection();

        public string Content { get; init; }
    }
}
