using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Http
{
    public class HttpRequest
    {
        private static string NewLine = "\r\n";
        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public HttpHeaderCollection Headers { get; private set; } 

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            string[] lines = request.Split(NewLine);

            var firstLine = lines.First().Split();

            var method = ParseHttpMethod(firstLine[0]);
            var path = firstLine[1];

            var headerCollection = ParseHeaders(lines.Skip(1));

            var body = string.Join(NewLine, lines.Skip(headerCollection.Count + 2).ToArray());

            return new HttpRequest
            {
                Headers = headerCollection,
                Method = method,
                Url = path,
                Body = body
            };

        }

        public static HttpMethod ParseHttpMethod(string method)
            => method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new ArgumentException($"Method {method} not supported!")
            };

        private static HttpHeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headers = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                var header = new HttpHeader
                {
                    Name = headerParts[0],
                    Value = headerParts[1].Trim()
                };

                headers.Add(header);
            }

            return headers;
        }
    }
}
