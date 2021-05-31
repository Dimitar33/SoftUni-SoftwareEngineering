using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Http
{
   public class HttpHeadersCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeadersCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public int Count => headers.Count;
        public void Add(HttpHeader header)
        {
            this.headers.Add(header.Name, header);
        }
    }
}
