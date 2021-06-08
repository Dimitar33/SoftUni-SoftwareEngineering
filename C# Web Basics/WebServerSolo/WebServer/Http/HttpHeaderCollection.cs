using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Http
{
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;
        public HttpHeaderCollection()
        {
            headers = new Dictionary<string, HttpHeader>();
        }

        public int Count => headers.Count;
        public void Add(HttpHeader header)
        {
            headers.Add(header.Name, header);
        }
    }
}
