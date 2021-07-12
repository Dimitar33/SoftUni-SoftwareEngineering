using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Resposes
{
    public class TextResponse : HttpResponse
    {
        public TextResponse(string text)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            var contentLenght = Encoding.UTF8.GetBytes(text).ToString();

            Headers.Add("Content-Type:", "text/html; charset=UTF-8");
            Headers.Add("Content-Length:", $"{contentLenght}");
        }
    }
}
