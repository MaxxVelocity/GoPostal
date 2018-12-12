using GoPostal.ComandLine;
using Mono.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal.CommandLine
{
    public class VerbOptionY 
    {
        public static Verb Selected { get; private set; }

        public static void Initialize(string[] args)
        {
            Selected = MutuallyExclusiveOptionFactory<Verb>.Create(
                new Dictionary<string, Verb>
                    {
                        { "g|get", Verb.Get },
                        { "d|delete", Verb.Delete },
                        { "p|post", Verb.Post },
                        { "u|put", Verb.Put },
                    }, 
                args);
        }
    }
}
