using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {

        private const string NewLine = "\r\n";
        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public HttpHeadersCollection Headers { get; private set; }
        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            string[] lines = request.Split(NewLine);

            string[] startLIne = lines.First().Split(" ");

            HttpMethod method = ParseMethod(startLIne[0]);
            string url = startLIne[1];

            var headerCollection = ParseHeaderCollection(lines.Skip(1));

            var body = string.Join(NewLine, lines.Skip(headerCollection.Count + 2).ToArray());

            return new HttpRequest
            {
                Method = method,
                Url = url,
                Headers = headerCollection,
                Body = body
            };
        }

        private static HttpHeadersCollection ParseHeaderCollection(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeadersCollection();

            foreach (var item in headerLines)
            {
                if (item == string.Empty)
                {
                    break;
                }

                int indexOfColon = item.IndexOf(":");

                if (indexOfColon < 0)
                {
                    throw new InvalidOperationException("Invalid request");
                }

                HttpHeader header = new HttpHeader
                {
                    Name = item.Substring(0, indexOfColon),
                    Value = item.Substring(indexOfColon + 1).Trim()
                };

                headerCollection.Add(header);

            }

            return headerCollection;
        }

        private static HttpMethod ParseMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Enum {method} is not supported")
            };
        }


    }
}
