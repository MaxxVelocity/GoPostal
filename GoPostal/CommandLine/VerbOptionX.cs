using GoPostal.ComandLine;
using Mono.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GoPostal.CommandLine
{
    public class VerbOptionX
    {
        public static bool IsPopulated => Selected != null;

        public static HttpMethod Selected { get; private set; }

        public static void Initialize(string[] args)
        {
            Selected = MutuallyExclusiveOptionFactory<HttpMethod>.Create(
                new Dictionary<string, HttpMethod>
                    {
                        { "g|get", HttpMethod.Get },
                        { "d|delete", HttpMethod.Delete },
                        { "p|post", HttpMethod.Post },
                        { "u|put", HttpMethod.Put },
                    },
                args);
        }
    }
}
