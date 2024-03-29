﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; init; }

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();

        public string Content { get; private set; }
     }
}
