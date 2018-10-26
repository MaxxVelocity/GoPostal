using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GoPostal.Configuration
{
    public class HttpOperationTarget
    {
        public Uri Url { get; }

        public HttpMethod Method { get; }

        public Dictionary<string,string> HeaderTemplates { get; }
    }
}
